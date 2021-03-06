#!/usr/bin/python3

import threading
import time
from datetime import datetime

from settings import DB_settings as DB
from robots_sitemap_parser import *
from bd_pages_parser import *

from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker


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


class CrawlerThread(threading.Thread):
    def __init__(self, delay=None, interval=None):
        super().__init__()
        self._stop = threading.Event()
        self.daemon = True
        self.interval = interval or 86400
        self.delay = delay

    def run(self):
        self.__now = datetime.utcnow()
        if self.delay is None:
            self.delay = (self.__now.replace(hour=23, minute=30,
                                             second=0, microsecond=0) -
                          self.__now).total_seconds()
        if self.delay > 0:
            print('Launch presponded for %s seconds...' % self.delay)
            time.sleep(self.delay)
        while True:
            print("\n{text:*^80}".format(text='Start crawling at %s' %
                                         datetime.now()))
            start_time_sec = time.time()

            # создаем сессию БД с настройками DB
            session = create_db_session(DB)

            # из sitemap в БД пишем все новые страницы
            parse_sitemap_to_db(session=session)

            # парсим новые страницы из БД на рейтинги
            parse_pages_from_db(session=session)

            print("End crawling at %s" % datetime.now())
            # засыпаем на self.interval часов
            iter_duration_sec = time.time() - start_time_sec
            print("Next crawling after %s seconds" %
                  self.interval - iter_duration_sec)
            time.sleep(self.interval - iter_duration_sec)

    def stop(self):
        self._stop.set()

    def stopped(self):
        return self._stop.isSet()


def main():
    # создаем краулер в отдельном потоке 
    # первый вргумент - задержка в секундах (по умолчанию - до 23:30 по местному времени)
    # второй вргумент - периодичность в секундах автоматического запуска краулера (по умолчанию - сутки)
    crawler = CrawlerThread(5)
    crawler.start()

if __name__ == '__main__':
    main()
