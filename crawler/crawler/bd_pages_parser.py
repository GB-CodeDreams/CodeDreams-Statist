#!/usr/bin/python3

from datetime import datetime

import os

# Позже улучшу с помощью дополнительных модулей загрузчик страниц 
from urllib.request import urlopen, build_opener, urlretrieve 
import requests

from string import punctuation
from bs4 import BeautifulSoup
import lxml  # возможно, не нужен, надо проверить
from html2text import html2text

import models


def page_downloader(page_db_object):
    page = page_db_object
    page_dir = os.path.join('pages', page.site.name)
    if not os.path.exists(page_dir):
        os.makedirs(page_dir)
    n = 0
    filename = str(n) + page.url.split('/')[-1].split('#')[0].split('?')[0]
    file_path = os.path.join(page_dir, filename)
    while os.path.exists(file_path):
        lnum = len(str(n))
        n += 1
        filename = str(n) + filename[lnum:]
        file_path = os.path.join(page_dir, filename)
    urlretrieve(page.url, file_path)
    return file_path


def count_words(text):
    word_list = text.replace('>', ' ').replace('<', ' ').replace('(', ' ').replace(')', ' ').split()
    for i in range(len(word_list)):
        word_list[i] = word_list[i].strip(punctuation+" ").lower()
    return {word:word_list.count(word) for word in tuple(set(word_list))}


def parse_pages_from_bd(session):
    for page in session.query(models.Pages).filter(models.Pages.last_scan_date == None):
        page_html = open(page_downloader(page), 'r').read()
        html_text = html2text(BeautifulSoup(page_html, "lxml").text)  # or 'html.parse' parser

        words_count_dict = count_words(html_text)

        for person in session.query(models.Persons).all():
            new_person_ranks = []
            person_page_rank = 0
            for kw in person.keywords:
                person_page_rank += words_count_dict.get(kw.name.lower(), 0)

            new_person_ranks.append(models.PersonPageRanks(person.id, page.id, person_page_rank))
            session.add_all(new_person_ranks)
        page.last_scan_date = datetime.utcnow()
        session.commit()