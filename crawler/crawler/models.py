#!/usr/bin/python3

from datetime import datetime
from sqlalchemy import Column, ForeignKeyConstraint
from sqlalchemy.dialects.mysql import INTEGER, DATETIME, VARCHAR
from sqlalchemy.ext.declarative import declarative_base


Base = declarative_base()


class Persons(Base):
    """ Persons entity class """
    __tablename__ = 'persons'

    id = Column('id', INTEGER(unsigned=True), nullable=False, primary_key=True)
    name = Column(VARCHAR(2048), nullable=False)

    __table_args__ = {
        'mysql_engine': 'InnoDB',
        'mysql_charset': 'utf8'
    }

    def __init__(self, name):
        self.name = name


class Keywords(Base):
    __tablename__ = 'keywords'

    id = Column('id', INTEGER(unsigned=True), nullable=False, primary_key=True)
    name = Column('name', VARCHAR(2048), nullable=False)
    person_id = Column('person_id', INTEGER(unsigned=True), nullable=False)

    __table_args__ = (ForeignKeyConstraint([person_id], [Persons.id],
                                           name='fk_keywords_persons',
                                           ondelete='CASCADE'),
                      {'mysql_engine': 'InnoDB',
                       'mysql_charset': 'utf8'}
                      )

    def __init__(self, name, person_id):
        self.name = name
        self.person_id = person_id


class Sites(Base):
    """ Sites entity class """
    __tablename__ = 'sites'

    id = Column('id', INTEGER(unsigned=True), nullable=False, primary_key=True)
    name = Column('name', VARCHAR(256), nullable=False)

    __table_args__ = {
        'mysql_engine': 'InnoDB',
        'mysql_charset': 'utf8'
    }

    def __init__(self, name):
        self.name = name


class Pages(Base):
    """ Pages entity class """
    __tablename__ = 'pages'

    id = Column('id', INTEGER(unsigned=True), nullable=False, primary_key=True)
    url = Column('url', VARCHAR(2048), nullable=False)
    site_id = Column('site_id', INTEGER(unsigned=True), nullable=False)
    found_date_time = Column(DATETIME, default=datetime.utcnow)
    last_scan_date = Column(DATETIME)

    __table_args__ = (ForeignKeyConstraint([site_id], [Sites.id],
                                           name='fk_pages_sites',
                                           ondelete='CASCADE'),
                      {'mysql_engine': 'InnoDB',
                       'mysql_charset': 'utf8'}
                      )

    def __init__(self, url, site_id):
        self.url = url
        self.site_id = site_id


class PersonPageRanks(Base):
    """ PersonPageRanks entity class """
    __tablename__ = 'person_page_ranks'

    id = Column('id', INTEGER(unsigned=True), nullable=False, primary_key=True)
    person_id = Column('person_id', INTEGER(unsigned=True), nullable=False)
    page_id = Column('page_id', INTEGER(unsigned=True), nullable=False)
    rank = Column('rank', INTEGER(unsigned=True), nullable=False)

    __table_args__ = (ForeignKeyConstraint([person_id], [Persons.id],
                                           name='fk_ranks_persons',
                                           ondelete='CASCADE'),
                      ForeignKeyConstraint([page_id], [Pages.id],
                                           name='fk_ranks_pages',
                                           ondelete='CASCADE'),
                      {'mysql_engine': 'InnoDB',
                       'mysql_charset': 'utf8'}
                      )

    def __init__(self, person_id, page_id, rank):
        self.person_id = person_id
        self.page_id = page_id
        self.rank = rank
