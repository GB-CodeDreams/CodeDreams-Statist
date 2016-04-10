#!/usr/bin/python3

DB_settings = {
        'dialect': 'mysql',
        'driver': 'pymysql',
        'user': 'root',
        'password': 'statistpass',
        'host': '127.0.0.1',
        'port': '3306',
        'database': 'statist_db'
    }
# Database engine: '{dialect}+{driver}://{user}:{password}@{host}:{port}/{database}'