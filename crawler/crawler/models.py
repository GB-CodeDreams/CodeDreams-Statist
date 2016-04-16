#!/usr/bin/python3

from datetime import datetime
from sqlalchemy import Column, ForeignKeyConstraint
from sqlalchemy.dialects.mysql import INTEGER, DATETIME, VARCHAR
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import relationship


Base = declarative_base()


class Persons(Base):
    """ Persons entity class """
    __tablename__ = 'persons'

    id = Column('id', INTEGER(display_width=11, unsigned=True), nullable=False, primary_key=True)
    name = Column(VARCHAR(255), nullable=False)

    keywords = relationship('Keywords', backref='person')

    ranks = relationship('PersonPageRanks',
                         backref='person',
                         lazy='dynamic',
                         cascade="all, delete-orphan",
                         passive_deletes=True)

    __table_args__ = {
        'mysql_engine': 'InnoDB',
        'mysql_charset': 'utf8'
    }

    def __init__(self, name):
        self.name = name


class Keywords(Base):
    __tablename__ = 'keywords'

    id = Column('id', INTEGER(display_width=11, unsigned=True), nullable=False, primary_key=True)
    name = Column('name', VARCHAR(255), nullable=False)
    name_2 = Column('name_2', VARCHAR(255))
    distance = Column('distance', INTEGER(display_width=11))
    person_id = Column('person_id', INTEGER(display_width=11, unsigned=True), nullable=False)

    __table_args__ = (ForeignKeyConstraint([person_id], [Persons.id],
                                           name='fk_rails_019c8c7266',
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

    id = Column('id', INTEGER(display_width=11, unsigned=True), nullable=False, primary_key=True)
    name = Column('name', VARCHAR(255), nullable=False)

    pages = relationship('Pages',
                         backref='site',
                         cascade="all, delete-orphan",
                         passive_deletes=True)

    __table_args__ = {
        'mysql_engine': 'InnoDB',
        'mysql_charset': 'utf8'
    }

    def __init__(self, name):
        self.name = name


class Pages(Base):
    """ Pages entity class """
    __tablename__ = 'pages'

    id = Column('id', INTEGER(display_width=11, unsigned=True), nullable=False, primary_key=True)
    url = Column('url', VARCHAR(255), nullable=False)
    site_id = Column('site_id', INTEGER(display_width=11, unsigned=True), nullable=False)
    found_date_time = Column(DATETIME, default=datetime.utcnow)
    last_scan_date = Column(DATETIME)

    ranks = relationship('PersonPageRanks',
                         backref='page',
                         lazy='dynamic',
                         cascade="all, delete-orphan",
                         passive_deletes=True)

    __table_args__ = (ForeignKeyConstraint([site_id], [Sites.id],
                                           name='fk_rails_a8ad97ecff',
                                           ondelete='CASCADE'),
                      {'mysql_engine': 'InnoDB',
                       'mysql_charset': 'utf8'}
                      )

    def __init__(self, url, site_id, found_date_time=None, last_scan_date=None):
        self.url = url
        self.site_id = site_id
        self.last_scan_date = last_scan_date or None
        self.found_date_time = found_date_time or datetime.utcnow()


class PersonPageRanks(Base):
    """ PersonPageRanks entity class """
    __tablename__ = 'person_page_ranks'

    id = Column('id', INTEGER(display_width=11, unsigned=True), nullable=False, primary_key=True)
    person_id = Column('person_id', INTEGER(display_width=11, unsigned=True), nullable=False)
    page_id = Column('page_id', INTEGER(display_width=11, unsigned=True), nullable=False)
    rank = Column('rank', INTEGER(display_width=11, unsigned=True), nullable=False)

    __table_args__ = (ForeignKeyConstraint([person_id], [Persons.id],
                                           name='fk_rails_c1e71ae48d',
                                           ondelete='CASCADE'),
                      ForeignKeyConstraint([page_id], [Pages.id],
                                           name='fk_rails_4986e37e79',
                                           ondelete='CASCADE'),
                      {'mysql_engine': 'InnoDB',
                       'mysql_charset': 'utf8'}
                      )

    def __init__(self, person_id, page_id, rank):
        self.person_id = person_id
        self.page_id = page_id
        self.rank = rank
