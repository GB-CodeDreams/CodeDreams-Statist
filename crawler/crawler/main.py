#!/usr/bin/python3

from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from . import models


def main():
    DB = {
        'driver': 'mysql+pymysql',
        'user': 'root',
        'password': 'statistpass',
        'host': '127.0.0.1',
        'port': '3306',
        'database': 'statist_db'
    }

    engine_db = '{driver}://{user}:{password}@{host}:{port}/{database}'\
                .format(driver=DB['driver'], user=DB['user'],
                        password=DB['password'], host=DB['host'],
                        port=DB['port'], database=DB['database'])
    engine = create_engine(engine_db, pool_recycle=3600)

    Session = sessionmaker(bind=engine)
    session = Session()



    session.commit()


if __name__ == '__main__':
    main()