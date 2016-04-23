#!/usr/bin/python3

from urllib.request import urlopen, build_opener
import requests


def page_downloader(url):
    try:
        page_text = urlopen(url).read().decode('utf-8')
    except Exception:
        page_text = requests.get(url, stream=True).text
    except:
        opener = build_opener()
        opener.addheaders = [('User-agent', 'Mozilla/5.0')]
        page_text = opener.open(url).read().decode('utf-8')
    return page_text
