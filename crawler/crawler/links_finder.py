#!/usr/bin/python3

from reppy.cache import RobotsCache as RC
from bs4 import BeautifulSoup
from urllib.request import urlopen
import requests
import re


def get_url_site_links(url, robots_rules=None):
    host = url[:url.find('/', 8) + 1]
    try:
        robots_rules = robots_rules if robots_rules else RC().fetch(host)
    except:
        pass
    page_links = set()
    try:
        html_page = urlopen(url)
    except Exception:
        html_page = requests.get(url, stream=True).content
    soup = BeautifulSoup(html_page, 'lxml')
    a_tags = soup.findAll('a', href=re.compile("^(%s|/[^/])" % host))
    if a_tags is not None:
        for a in a_tags:
            link = a.get('href')
            if link.startswith('/'):
                link = host + link[1:]
            if '#' in link:
                link = link.split('#')[0]
            if robots_rules and not robots_rules.allowed(link, '*'):
                continue
            if '.' in link[link.find('/', 8):]:
                right_part = link.split('/')[-1]
                if not right_part:
                    right_part = link.split('/')[-2]
                if '.' in right_part\
                   and not right_part.split('.')[-1].isdigit()\
                   and not right_part.split('.')[-1] in ('html', 'htm', 'php'):
                    continue
            page_links.add(link)
    return page_links


def recursive_url_search(url, _visited=set(), robots_rules=None,
                         visited_limit=300, depth_limit=3, depth=0):
    depth += 1
    if (not visited_limit or len(_visited) <= visited_limit)\
            and (not depth_limit or depth <= depth_limit):
        _visited.add(url)
        if len(_visited) >= 10 and not len(_visited)\
                % (10**(len(str(len(_visited))) - 1)):
            print('%s links found...' % len(_visited))
        for inner_url in get_url_site_links(url, robots_rules):
            if inner_url not in _visited:
                _visited.update(recursive_url_search(inner_url, _visited,
                                                     depth=depth))
    return _visited


def main():
    a = recursive_url_search('https://geekbrains.ru/')
    print(a)


if __name__ == '__main__':
    main()
