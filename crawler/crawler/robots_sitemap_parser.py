#!/usr/bin/python3

from urllib.error import HTTPError

from datetime import datetime

from urllib.request import urlopen, build_opener
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


def read_sitemap_xml(main_page_or_xml_url, robots=RobotsCache()):
    try:
        ext = main_page_or_xml_url.split('/')[-1].split('.')[1]
    except IndexError:
        ext = -1
    if not ext == 'xml':
        main_page = main_page_or_xml_url
        sitemap_urls = robots.sitemaps(main_page)
        if not sitemap_urls:
            sitemap_url = main_page + 'sitemap.xml' if main_page[-1] == '/' else main_page + '/sitemap.xml'
        else:
            sitemap_url = sitemap_urls[0]
    else:
        sitemap_url = main_page_or_xml_url
    try:
        sitemap_xml = urlopen(sitemap_url)
        if guess_type(sitemap_url)[1] == 'gzip':
            sitemap_xml = gzip.GzipFile(fileobj=sitemap_xml)
        sitemap_xml_text = sitemap_xml.read()
    except Exception:
        sitemap_xml_text = requests.get(sitemap_url, stream=True).\
                           content.decode('utf-8')
    except:
        opener = build_opener()
        opener.addheaders = [('User-agent', 'Mozilla/5.0')]
        sitemap_xml_text = opener.open(sitemap_url).read()
    return sitemap_xml_text


def parse_sitemap_to_db(session, robots=RobotsCache()):
    today_day = datetime.utcnow().date()
    for site in session.query(models.Sites).all():
        try:
            main_page = session.query(models.Pages).filter(site.id == models.Pages.site_id).order_by(models.Pages.found_date_time).all()[0].url
        except:
            print('no pages for site with id ', site.id)
            continue
        new_pages_list = []

        try:
            sitemap_text = read_sitemap_xml(main_page, robots)
        except:
            print("Возникла ошибка при доступе к карте сайта %s" % main_page)
        sitemap_xml_root = ET.fromstring(sitemap_text)
        ns = {'ns': gen_ns(sitemap_xml_root.tag)}

        xml_files_roots = []
        # если sitemap сам список sitemap'ов (первый тег - sitemapindex)
        if sitemap_xml_root.tag.split('}')[-1] == 'sitemapindex':
            # достаем по очереди ссылки на sitemap из списка
            for sitemap in sitemap_xml_root.iterfind("ns:sitemap", ns):
                sitemap_url = sitemap.find("ns:loc").text
                # открываем и добавляем в список их xml root'ы
                sitemap_text = read_sitemap_xml(sitemap_url, robots)
                sitemap_xml_root = ET.fromstring(sitemap_text)
                xml_files_roots.append(sitemap_xml_root)
        else:
            xml_files_roots.append(sitemap_xml_root)
        for sitemap_xml_root in xml_files_roots:
            ns = {'ns': gen_ns(sitemap_xml_root.tag)}
            for url in sitemap_xml_root.iterfind("ns:url", ns):
                if datetime.strptime(url.find("ns:lastmod", ns).text[:10],
                                     "%Y-%m-%d").date() == today_day:
                    # and url.find("ns:changefreq", ns).text == 'daily'
                    page_url = url.find("ns:loc", ns).text
                    if robots.allowed(page_url, '*') and not session.query(models.Pages).filter(site.id == models.Pages.site_id).filter(page_url == models.Pages.url).all():
                        new_pages_list.append(models.Pages(page_url, site.id))
        if not new_pages_list:
            print('no new pages for site "%s" with id %s' % (site.name, site.id))

        session.add_all(new_pages_list)
        session.commit()
