#!/usr/bin/python3

from reppy.cache import RobotsCache

from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

from . import models


def main():

    robots = RobotsCache()
    # example: robots.allowed('https://4brain.ru/eyesight/','*')
    # example: robots.sitemaps('https://geekbrains.ru')

    DB = {
        'dialect': 'mysql',
        'driver': 'pymysql',
        'user': 'root',
        'password': 'statistpass',
        'host': '127.0.0.1',
        'port': '3306',
        'database': 'statist_db'
    }

    engine_db = '{dialect}+{driver}://{user}:{password}@{host}:{port}/{database}'\
                .format(dialect=DB['dialect'], driver=DB['driver'],
                        user=DB['user'], password=DB['password'],
                        host=DB['host'], port=DB['port'],
                        database=DB['database'])
    engine = create_engine(engine_db, pool_recycle=3600)

    Session = sessionmaker(bind=engine)
    session = Session()

    for site in session.query(models.User).all():
        pass

    session.commit()


if __name__ == '__main__':
    main()