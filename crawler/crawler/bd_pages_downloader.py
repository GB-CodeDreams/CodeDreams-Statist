#!/usr/bin/python3

import os
import shutil

from urllib.request import urlopen, build_opener, urlretrieve
import requests


def page_downloader(db_page_object):
    page = db_page_object
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
    try:
        urlretrieve(page.url, file_path)
    except Exception:
        with urlopen(page.url) as response, open(file_path, 'wb') as out_file:
            shutil.copyfileobj(response, out_file)
    except Exception:
        with requests.get(page.url, stream=True).raw as response,\
                open(file_path, 'wb') as out_file:
            shutil.copyfileobj(response, out_file)
    except:
        opener = build_opener()
        opener.addheaders = [('User-agent', 'Mozilla/5.0')]
        with opener.open(page.url) as response,\
                open(file_path, 'wb') as out_file:
            shutil.copyfileobj(response, out_file)
    return file_path
