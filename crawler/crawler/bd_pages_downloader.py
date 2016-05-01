#!/usr/bin/python3

from urllib.error import URLError
from urllib.request import urlopen, build_opener
import requests


def page_downloader(url):
    page_text = ""
    good_url = True

    if type(url) != str:
        good_url = False
    elif not url.startswith('https://') and not url.startswith('http://'):
        good_url = False
    elif '.' in url[url.find('/', 8):]:
        right_part = url.split('/')[-1]
        if not right_part:
            right_part = url.split('/')[-2]
        if '.' in right_part\
           and not right_part.split('.')[-1].isdigit()\
           and not right_part.split('.')[-1] in ('html', 'htm', 'php'):
            good_url = False

    if good_url:
        try:
            page_text = urlopen(url).read().decode('utf-8')
        except URLError:
            pass
        except Exception:
            page_text = requests.get(url, stream=True).text
        except:
            opener = build_opener()
            opener.addheaders = [('User-agent', 'Mozilla/5.0')]
            page_text = opener.open(url).read().decode('utf-8')

    return page_text
