#!/usr/bin/python3

from settings import DB_settings as DB
from robots_sitemap_parser import *
from bd_pages_parser import *

from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

from reppy.cache import RobotsCache


def create_mysql_session(db_settings_dict):
    DB = db_settings_dict
    engine_db = '{dialect}+{driver}://{user}:{password}@{host}:{port}/{database}'\
                .format(dialect=DB['dialect'], driver=DB['driver'],
                        user=DB['user'], password=DB['password'],
                        host=DB['host'], port=DB['port'],
                        database=DB['database'])
    engine = create_engine(engine_db, pool_recycle=3600)
    Session = sessionmaker(bind=engine)
    return Session()


def main():

    robots_cache = RobotsCache()  # не обязательно, кэш для быстродействия
    session = create_mysql_session(DB)  # создаем сессию БД с настройками DB

    # парсим все sitemap на новые страницы
    parse_sitemap_to_db(session=session, robots=robots_cache)
    parse_pages_from_bd(session=session)


if __name__ == '__main__':
    main()
