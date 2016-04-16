#!/usr/bin/python3

import threading
import time
from datetime import datetime

from settings import DB_settings as DB
from robots_sitemap_parser import *
from bd_pages_parser import *

from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

from reppy.cache import RobotsCache


def create_db_session(db_settings_dict):
    DB = db_settings_dict
    engine_db = '{dialect}+{driver}://{user}:{password}@{host}/{database}?{charset}'\
                .format(dialect=DB['dialect'], driver=DB['driver'],
                        user=DB['user'], password=DB['password'],
                        host=DB['host'], port=DB['port'],
                        database=DB['database'], charset=DB['charset'])
    engine = create_engine(engine_db, pool_recycle=10)
    Session = sessionmaker(bind=engine)
    return Session()


class Crawler(threading.Thread):
    def __init__(self, interval=86400, delay=0):
        threading.Thread.__init__(self)
        self.daemon = True
        self.interval = interval
        self.delay = delay

    def run(self):
        print('Запуск отложен на %s секунд...' % self.delay)
        time.sleep(self.delay)
        while True:
            print("Start crawling at %s" % datetime.utcnow())

            robots_cache = RobotsCache()  # не обязательно, кэш для быстродействия
            session = create_db_session(DB)  # создаем сессию БД с настройками DB

            # из sitemap в БД пишем все новые страницы
            parse_sitemap_to_db(session=session)
            # парсим новые страницы из БД на рейтинги
            parse_pages_from_db(session=session)
            # засыпаем на self.interval часов
            time.sleep(self.interval)

            print("End crawling at %s" % datetime.utcnow())
            time.sleep(self.interval)


def main():
    try:
        # ппосчитаем задержку первого запуска в секундах до 23:30:00
        utc_now = datetime.utcnow()
        delay_sec = (utc_now.replace(hour=23, minute=30, second=0, microsecond=0) - utc_now).total_seconds()

        # интервал заупска краулера - сутки(в секундах)
        interval_sec = 86400

        crawler = Crawler(interval_sec, delay_sec)
        # crawler = Crawler(60, 5)
        crawler.start()
    except Exception as e:
        print("Возникла ошибка!")
        print(e.message, e.args)
        print("Повторим проход цикла краулера.")
        main()
    except Exception as e:
        print(e.message, e.args)
        print("Не удалось решить проблему.")

if __name__ == '__main__':
    main()
