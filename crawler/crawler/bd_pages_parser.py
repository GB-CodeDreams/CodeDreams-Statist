#!/usr/bin/python3

from sqlalchemy import and_, func

from datetime import datetime

from string import punctuation
from bs4 import BeautifulSoup
from html2text import html2text

import models
from bd_pages_downloader import page_downloader


def make_word_indexes_dict(text):
    text = text.lower()
    word_list = text.replace('>', ' ').replace('<', ' ')\
        .replace('(', ' ').replace(')', ' ').split()
    for i in range(len(word_list)):
        word_list[i] = word_list[i].strip(punctuation + " ")
    index_dict = {word: [] for word in word_list}
    for word in index_dict:
        search_start = 0
        for _n in range(word_list.count(word)):
            # index = text.index(word, search_start)
            # search_start = index + 1
            list_index = word_list.index(word, search_start)
            index = sum(map(lambda s: len(s), word_list[:list_index]), list_index)
            search_start = list_index + 1
            index_dict[word].append(index)
    return index_dict


def count_page_person_rank(person, word_index_dict):
    rank = 0
    for kw in person.keywords:
        word1 = kw.name.lower()
        if not kw.name_2 or not kw.distance:
            word1_ind_list = word_index_dict.get(word1, [])
            return len(word1_ind_list)
        word2 = kw.name_2.lower()
        word1_ind_list = word_index_dict.get(word1, [])
        word2_ind_list = word_index_dict.get(word2, [])
        distance = kw.distance
        for ind1 in word1_ind_list:
            for ind2 in word2_ind_list:
                i1, i2 = ind1, ind2
                w1, w2 = word1, word2
                if i1 > i2:
                    i1, i2 = i2, i1
                    w1, w2 = w2, w1
                start_distance = i2 - i1
                if start_distance == 0 or start_distance < len(w1):
                    continue
                word_distance = start_distance - len(w1)
                if word_distance <= distance:
                    rank += 1
    return rank


def count_person_old_ranks_sum(session, page, person):
    person_old_common_rank = 0
    person_url_prev_ranks = session.query(models.PersonPageRanks).join(models.Pages, models.Pages.url==page.url).filter(models.PersonPageRanks.person_id==person.id).filter(models.Pages.id==models.PersonPageRanks.page_id)
    for url_rank in person_url_prev_ranks.all():
        person_old_common_rank += url_rank.rank
    return person_old_common_rank


def parse_pages_from_db(session):
    print("\nStart person page rank counting.")
    n = 0
    today_date = datetime.utcnow().date()
    stmt = session.query(models.Pages.url, func.max(models.Pages.last_scan_date).label('lsd')).group_by(models.Pages.url).subquery()
    last_scanned_pages = session.query(models.Pages).join(stmt, and_(models.Pages.last_scan_date == stmt.c.lsd, models.Pages.url == stmt.c.url)).filter(func.DATE(models.Pages.last_scan_date) != today_date)
    never_scanned_pages = session.query(models.Pages).filter(models.Pages.last_scan_date == None)
    for page in last_scanned_pages.union(never_scanned_pages).order_by(models.Pages.id):
        new_url = None
        if not page.last_scan_date:
            page.last_scan_date = datetime.utcnow()
            new_url = True
        new_ranks = []
        # скачиваем и открываем страницу в программе
        try:
            page_html = page_downloader(page.url)
            n += 1
        except:
            print("failed to download: ", page.url)
            continue

        # удаляем все лишнее из html
        html_text = html2text(BeautifulSoup(page_html, "lxml").text)

        # преобразуем текст в словарь, где ключи - индексы слов,
        # а значения - список его индексов
        word_indexes_dict = make_word_indexes_dict(html_text)
        for _ in range(2):
            try:
                persons_list = session.query(models.Persons).all()
            except:
                session.rollback()
                from main import DB, create_db_session
                session = create_db_session(DB)
            else:
                break
        for person in persons_list:
            # считаем ранк персоны на странице
            person_new_common_rank = count_page_person_rank(person,
                                                            word_indexes_dict)
            if new_url:
                if person_new_common_rank:
                    new_ranks.append(models.PersonPageRanks(person.id,
                                                            page.id,
                                                            person_new_common_rank))
            else:
                # считаем текущий обий ранк персоны в базе
                person_old_common_rank = count_person_old_ranks_sum(session,
                                                                    page,
                                                                    person)

                # в случае изменения ранка, создаем новый, с количеством новых
                # упоминаний и добавляем в список новых ранков
                if person_new_common_rank > person_old_common_rank:
                    new_mentions = person_new_common_rank - person_old_common_rank
                    new_ranks.append(models.PersonPageRanks(person.id,
                                                            None,
                                                            new_mentions))
        # если в списке новых ранков есть объекты,
        # создаем для них страницу с текущей датой и привязываем ранки к ней
        if new_ranks:
            if not new_url:
                new_page = models.Pages(page.url, page.site_id,
                                        page.found_date_time, datetime.utcnow())
                session.add(new_page)
                session.commit()
                for rank in new_ranks:
                    rank.page_id = new_page.id
            session.add_all(new_ranks)
        session.commit()

        if n >= 10 and not n % (10**(len(str(n)) - 1)):
            print('%s pages scanned...' % n)
