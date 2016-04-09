#!/usr/bin/python3

from urllib.error import HTTPError

from sqlalchemy import create_engine  # , func
from sqlalchemy.orm import sessionmaker

from datetime import datetime

from urllib.request import urlopen, build_opener  # , urlretrieve
import requests

from reppy.cache import RobotsCache
from mimetypes import guess_type
import gzip
import xml.etree.ElementTree as ET

import models


def gen_ns(tag):
    if tag.startswith('{'):
        ns, tag = tag.split('}')
        return ns[1:]
    else:
        return ''


def read_sitemap_xml(main_page, robots=RobotsCache()):
    sitemap_url = robots.sitemaps(main_page)[0]
    try:
        sitemap_xml = urlopen(sitemap_url)
        if guess_type(sitemap_url)[1] == 'gzip':
            sitemap_xml = gzip.GzipFile(fileobj=sitemap_xml)
        sitemap_xml_text = sitemap_xml.read()
    except HTTPError:
        sitemap_xml_text = requests.get(sitemap_url, stream=True).\
                           content.decode('utf-8')
    except:
        opener = build_opener()
        opener.addheaders = [('User-agent', 'Mozilla/5.0')]
        sitemap_xml_text = opener.open(sitemap_url).read()
    return sitemap_xml_text


DB = {
        'dialect': 'mysql',
        'driver': 'pymysql',
        'user': 'root',
        'password': 'statistpass',
        'host': '127.0.0.1',
        'port': '3306',
        'database': 'statist_db'
    }


def main():

    robots = RobotsCache()

    engine_db = '{dialect}+{driver}://{user}:{password}@{host}:{port}/{database}'\
                .format(dialect=DB['dialect'], driver=DB['driver'],
                        user=DB['user'], password=DB['password'],
                        host=DB['host'], port=DB['port'],
                        database=DB['database'])
    engine = create_engine(engine_db, pool_recycle=3600)

    Session = sessionmaker(bind=engine)
    session = Session()

    for site in session.query(models.Sites).all():
        """
        main_page = session.query(models.Pages).\
                    filter(site.id == models.Pages.site_id).\
                    filter(models.Pages.found_date_time ==
                           func.max(models.Pages.found_date_time))
        """
        main_page = session.query(models.Pages).\
                    filter(site.id == models.Pages.site_id).\
                    order_by(models.Pages.found_date_time).all()[0].url

        new_pages_list = []

        sitemap_xml_root = ET.fromstring(read_sitemap_xml(main_page, robots))
        ns = {'ns': gen_ns(sitemap_xml_root.tag)}
        for url in sitemap_xml_root.iterfind("ns:url", ns):
            if datetime.strptime(url.find("ns:lastmod", ns).text[:10],
                                 "%Y-%m-%d").day == datetime.today().day:
                page_url = url.find("ns:loc", ns).text
                if robots.allowed(page_url, '*') and\
                   not session.query(models.Pages).\
                       filter(site.id == models.Pages.site_id).\
                       filter(page_url == models.Pages.url).all():
                    new_pages_list.append(models.Pages(page_url, site.id))

        session.add_all(new_pages_list)
        session.commit()


if __name__ == '__main__':
    main()
