#!/usr/bin/python3

from datetime import datetime

from urllib.request import urlopen, build_opener
import requests

from reppy.cache import RobotsCache
from mimetypes import guess_type
import gzip
import xml.etree.ElementTree as ET

import models
import links_finder as lf


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
        ext = False
    if not ext or not ext.startswith('xml'):
        main_page = main_page_or_xml_url
        sitemap_urls = robots.sitemaps(main_page)
        if not sitemap_urls:
            if main_page[-1] == '/':
                sitemap_url = main_page + 'sitemap.xml'
            else:
                sitemap_url = main_page + '/sitemap.xml'
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
        sitemap_xml_text = requests.get(sitemap_url, stream=True).text
    except:
        opener = build_opener()
        opener.addheaders = [('User-agent', 'Mozilla/5.0')]
        sitemap_xml_text = opener.open(sitemap_url).read()
    return sitemap_xml_text


def today_urls_from_sitemap(sitemap_xml_root,
                            today_day=datetime.utcnow().date(),
                            max_without_date=50):
    today_urls = []
    ns = {'ns': gen_ns(sitemap_xml_root.tag)}
    try:
        ignore_date = not bool(sitemap_xml_root.find("./ns:url/ns:lastmod",
                                                     ns).text)
    except AttributeError:
        ignore_date = True
        print('Lastmod information not avaliable.'
              'Will be scanned first %s urls.' % max_without_date)

    n = 0
    for url in sitemap_xml_root.iterfind("ns:url", ns):
        if not ignore_date:
            try:
                lastmod_date = datetime.strptime(url.find("ns:lastmod",
                                                          ns).text[:10],
                                                 "%Y-%m-%d").date()
            except:
                continue
        else:
            n += 1
        if ignore_date or lastmod_date == today_day:
            page_url = url.find("ns:loc", ns).text
            today_urls.append(page_url)
            if n == max_without_date:
                break
    return today_urls


def parse_sitemapindex_sitemaps(sitemap_xml_root,
                                today_day=datetime.utcnow().date()):
    urls_from_sitemaps = []
    ns = {'ns': gen_ns(sitemap_xml_root.tag)}
    for sitemap in sitemap_xml_root.iterfind("ns:sitemap", ns):
        sitemap_url = sitemap.find("ns:loc", ns).text
        print("Inserted xml: ", sitemap_url)
        sitemap_text = read_sitemap_xml(sitemap_url)
        try:
            sitemap_xml_root = ET.fromstring(sitemap_text)
        except Exception as e:
            print(e.args)
            continue
        else:
            urls_from_sitemaps.extend(today_urls_from_sitemap(sitemap_xml_root,
                                                              today_day))
    return urls_from_sitemaps


def url_new_for_db(page_url, session, site_id):
    for _ in range(2):
        try:
            same_url_page = session.query(models.Pages).filter(site_id == models.Pages.site_id).filter(page_url == models.Pages.url).first()
        except Exception:
            session.rollback()
            from main import create_db_session, DB
            session = create_db_session(DB)
        else:
            break
    if same_url_page:
        return False
    else:
        return True


def parse_sitemap_to_db(session, robots=RobotsCache()):
    today_day = datetime.utcnow().date()
    for site in session.query(models.Sites).all():
        print("Now scanning: '%s'" % site.name)

        try:
            main_page = session.query(models.Pages).filter(site.id == models.Pages.site_id).order_by(models.Pages.found_date_time).first().url
        except AttributeError:
            print('no valid pages for site %s with id %s' % (site.name,
                                                             site.id))
            continue

        robots_rules = robots.fetch(main_page)

        try:
            sitemap_text = read_sitemap_xml(main_page, robots)
            sitemap_xml_root = ET.fromstring(sitemap_text)
            recursive_scanning = False
        except Exception:
            print("Error to access the sitemap from %s" % main_page)
            recursive_scanning = True
            print("Recursive scanning Enabled")

        if not recursive_scanning:
            if sitemap_xml_root.tag.split('}')[-1] == 'sitemapindex':
                site_today_urls = parse_sitemapindex_sitemaps(sitemap_xml_root,
                                                              today_day)
            else:
                site_today_urls = today_urls_from_sitemap(sitemap_xml_root,
                                                          today_day)
        else:
            site_today_urls = lf.recursive_url_search(main_page,
                                                      robots_rules=robots_rules)
            print('%s links found on a website during recursive search.'
                  % len(site_today_urls))

        new_pages_list = []
        for url in site_today_urls:
            url_is_new = url_new_for_db(url, session=session, site_id=site.id)
            if robots_rules.allowed(url, '*') and url_is_new:
                new_pages_list.append(models.Pages(url, site.id))

        if not new_pages_list:
            print('No new pages for site "%s" with id %s' % (site.name,
                                                             site.id))
        else:
            for _ in range(2):
                try:
                    session.add_all(new_pages_list)
                    session.commit()
                except Exception:
                    session.rollback()
                    from main import create_db_session, DB
                    session = create_db_session(DB)
                    continue
                else:
                    print('%s new pages was added for site "%s"'
                          % (len(new_pages_list), site.name))
                    break
