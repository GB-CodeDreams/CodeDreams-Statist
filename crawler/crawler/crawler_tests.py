#!/usr/bin/python3

import unittest

from bd_pages_downloader import page_downloader


class TestPageDownloader(unittest.TestCase):
    """
    Downloader test class
    """

    def test_simple_good_page_download(self):
        res = page_downloader('http://example.com/')
        page_text = """<!doctype html>
<html>
<head>
    <title>Example Domain</title>

    <meta charset="utf-8" />
    <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style type="text/css">
    body {
        background-color: #f0f0f2;
        margin: 0;
        padding: 0;
        font-family: "Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
        
    }
    div {
        width: 600px;
        margin: 5em auto;
        padding: 50px;
        background-color: #fff;
        border-radius: 1em;
    }
    a:link, a:visited {
        color: #38488f;
        text-decoration: none;
    }
    @media (max-width: 700px) {
        body {
            background-color: #fff;
        }
        div {
            width: auto;
            margin: 0 auto;
            border-radius: 0;
            padding: 1em;
        }
    }
    </style>    
</head>

<body>
<div>
    <h1>Example Domain</h1>
    <p>This domain is established to be used for illustrative examples in documents. You may use this
    domain in examples without prior coordination or asking for permission.</p>
    <p><a href="http://www.iana.org/domains/example">More information...</a></p>
</div>
</body>
</html>
"""
        self.assertEqual(res, page_text)

    def test_good_page_with_ext(self):
        res = page_downloader('http://javarush.ru/login.html')
        page_text = """<!DOCTYPE html>
<html>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>
    <meta property="fb:app_id" content="163275303873171"/>

    <link rel="stylesheet" type="text/css" href="/main.css?v=4" />

    <title> JavaRush - логин </title>

    <link rel="apple-touch-icon" href="/images/apple-touch-icon_142x142.png" type="image/png"/>
    <link rel="shortcut icon" href="/images/javarush.ico" type="image/ico"/>

    <!--Page Scripts-->
    <script src="/statistics.js.jsp"></script>
    <script src="/common.js"></script>

    <!--VK API-->
    <script type="text/javascript" src="http://vk.com/js/api/openapi.js?96"></script>
    <script type="text/javascript" src="http://vk.com/js/api/share.js?11" charset="windows-1251"></script>

    <script src="/js/jquery-1.9.1.js"></script>
    <script src="/js/jquery.cookie.js"></script>

    <script>(function() {var _fbq = window._fbq || (window._fbq = []);if (!_fbq.loaded) {var fbds = document.createElement('script');fbds.async = true;fbds.src = '//connect.facebook.net/en_US/fbds.js';var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(fbds, s);_fbq.loaded = true;}_fbq.push(['addPixelId', '910397485679687']);})();window._fbq = window._fbq || [];window._fbq.push(['track', 'PixelInitialized', {}]);</script>
    <noscript><img height="1" width="1" alt="" style="display:none" src="https://www.facebook.com/tr?id=910397485679687&amp;ev=PixelInitialized" /></noscript>

</head>
<body >
<!--<script>(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){(i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)})(window,document,'script','//www.google-analytics.com/analytics.js','ga');ga('create', 'UA-35679269-1', 'auto');ga('send', 'pageview');</script>-->

<div class="course-layout" id="pSplashScreen"  >

<div class="header">
    <div class="header2">

        <div class="header3">
            <a href="/" target="_top"><div class="logo"></div></a>
            <div class="header32">
                <a href="course.html"><div class="logo2"></div></a>
            </div>

            <div class="header-menu">
                <ul class="header-menu" id="nav">

                    <li id="menu-item-user-profile-nologin" class="menu-item" style="display: block;">
                        <a href="/user/profile" target="_top">Моя страница</a>
                    </li>

                    <li id="menu-item-user-profile" class="menu-item has-sub" style="display: none;">
                        <a id="pProfileLink" href="/user/profile" target="_top">Моя страница</a>
                        <ul class="sub-menu">
                            <li id="menu-item-profile" class="menu-item">
                                <a href="/Profile.html#profile"  target="_top">Моя страница</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-messages" class="menu-item">
                                <a href="/Profile.html#messages" target="_top">Сообщения</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-friends" class="menu-item">
                                <a href="/Profile.html#friends" target="_top">Друзья</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-subscrioption" class="menu-item">
                                <a href="/Profile.html#subscriptions" target="_top">Подписки</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-exit" class="menu-item">
                                <a href="/user/logout"  target="_top">Выход</a>
                            </li>
                        </ul>
                    </li>

                    <li id="menu-item-course-java-nologin" class="menu-item" style="display: block;">
                        <a href="/user/course" target="_top">Курс Java</a>
                    </li>

                    <li id="menu-item-course-java" class="menu-item has-sub" style="display: none;">
                        <a id="pCourseLink" href="/user/course" target="_top">Курс Java</a>
                        <ul class="sub-menu">
                            <li id="menu-item-cource" class="menu-item">
                                <a href="/user/course" target="_top">Курс Java</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-task" class="menu-item">
                                <a href="/user/course/task" target="_top">Задачи</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-cource-plan" class="menu-item">
                                <a href="http://info.javarush.ru/page/learning_plan/" target="_top">План обучения</a>
                            </li>
                        </ul>
                    </li>

                    <li id="menu-item-posts" class="menu-item has-sub">
                        <a href="http://info.javarush.ru" target="_top">Сообщество</a>
                        <ul class="sub-menu">
                            <li id="menu-item-info" class="menu-item">
                                <a href="http://info.javarush.ru" title="Сообщество" target="_top">Сообщество</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-rating" class="menu-item">
                                <a href="/rating" title="Рейтинги" target="_top">Рейтинги</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-articles" class="menu-item">
                                <a href="/articles.html" title="Статьи" target="_top">Статьи</a>
                            </li>
                        </ul>
                    </li>

                    <li id="menu-item-reviews" class="menu-item has-sub">
                        <a href="/reviews.html" target="_top">Отзывы</a>
                        <ul class="sub-menu">
                            <li id="menu-item-rev" class="menu-item">
                                <a href="/reviews.html" title="Отзывы" target="_top">Отзывы</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-his" class="menu-item">
                                <a href="http://info.javarush.ru/tag/%D1%82%D1%80%D1%83%D0%B4%D0%BE%D1%83%D1%81%D1%82%D1%80%D0%BE%D0%B9%D1%81%D1%82%D0%B2%D0%BE/" title="Истории успеха" target="_top">Истории успеха</a>
                            </li>
                        </ul>
                    </li>
                    <li id="menu-item-about-us" class="menu-item has-sub">
                        <a href="/21.html" target="_top">О нас</a>
                        <ul class="sub-menu">
                            <li id="menu-item-mission" class="menu-item">
                                <a href="/21.html" title="Миссия" target="_top">Наша Команда </a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-news" class="menu-item">
                                <a href="http://info.javarush.ru/blog/news/" title="Новости проекта" target="_top">Новости проекта</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-social" class="menu-item">
                                <a href="/social.html" title="Мы в социальных сетях" target="_top">Мы в соцсетях</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-honorcode" class="menu-item">
                                <a href="http://info.javarush.ru/page/honorcode/" target="_top">Кодекс Чести</a>
                            </li>
                        </ul>
                    </li>


                    <li id="menu-item-help" class="menu-item has-sub">
                        <a href="http://help.javarush.ru/" target="_top">Помощь</a>
                        <ul class="sub-menu">
                            <li id="menu-item-help-jr" class="menu-item">
                                <a href="http://help.javarush.ru/" title="" target="_top">Помощь</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-faq" class="menu-item">
                                <a href="http://info.javarush.ru/page/FAQ/" title="FAQ" target="_top">FAQ</a>
                                <span>•</span>
                            </li>
                            <li id="menu-item-search" class="menu-item">
                                <a href="http://google.ru/search?q=site%3Ajavarush.ru" title="Поиск" target="_top">Поиск</a>
                            </li>
                        </ul>
                    </li>

                </ul>
            </div>
        </div>
    </div>
</div>


    <div class="course-content" >
        <div class="course-center" >

        <div class="course-mainlabel" style="background-color: yellow;opacity: 0.4;visibility: hidden;display: none;">
            <br>
            <br>
            Вам нужно:
            <br>
            1) Пару часов в день
            <br>
            2) Silverlight 5  &nbsp;&nbsp;(<a href="http://www.opennet.ru/opennews/art.shtml?num=37709">Pipelight</a> for Linux)
            <br>
            3) Любопытство

        </div>
        <div class="course-mainlabel2">
        </div>

        </div>
        <div  class="course-copyright" style="display: none;">
            JavaRush © 2012-2016 All rights reserved.
        </div>

        <div class="main-page-righ-tmenu-wrapper">
            <div id="rightmenu1" class="course-main-page-righ-tmenu" style="height: 313px;">

                <div>
                    Залогиниться через соц.сеть:
                </div>
                <div style="height: 5px;width: 150px;display: block"></div>
                <form action="/user/signin/twitter" method="POST">
                    <div class="main-page-righ-login-button">
                        <button class="main-page-righ-login-button" type="submit">
                            <img src="images/twitter-30.png" />
                            <div class="main-page-righ-login-button-text">Войти через Twitter</div>
                        </button>
                    </div>
                    <input id="twitter_userid" type="hidden" name="userid" value="">
                </form>

                <div style="height: 5px;width: 150px;display: block"></div>

                <form action="/user/signin/facebook" method="POST">
                    <div class="main-page-righ-login-button">
                        <button class="main-page-righ-login-button" type="submit">
                            <img src="images/facebook-30.png" />
                            <div class="main-page-righ-login-button-text">Войти через Facebook</div>
                        </button>
                    </div>
                    <input id="facebook_userid" type="hidden" name="userid" value="">
                </form>

                <div style="height: 5px;width: 150px;display: block"></div>

                <form action="/user/signin/vkontakte" method="POST">
                    <div class="main-page-righ-login-button">
                        <button class="main-page-righ-login-button" type="submit">
                            <img src="images/vkontakte-30.png" />
                            <div class="main-page-righ-login-button-text">Войти через VKontakte</div>
                        </button>
                    </div>
                    <input id="vkontakte_userid" type="hidden" name="userid" value="">
                </form>

                <div style="height: 10px;width: 150px;display: block"></div>
                <div style="height: 1px;width: 100px;margin-left: 40px;margin-right: 40px;background-color: gray"></div>
                <div style="height: 10px;width: 150px;display: block"></div>



                <div>
                    Залогиниться анонимно:
                </div>
                <div style="height: 5px;width: 150px;display: block"></div>
                <form action="" method="POST">
                    <div class="main-page-righ-login-button">
                        <button class="main-page-righ-login-button" type="button" onclick="getSecretKey()">
                            <img src="images/javarush-30.png" />
                            <div class="main-page-righ-login-button-text" style="padding-left: 40px;">Получить секретный ключ</div>
                        </button>
                    </div>
                </form>

                <div style="height: 5px;width: 150px;display: block"></div>

                <form id="secretKeyForm" action="/user/signin/anonimous" method="POST" autocomplete="on">
                    <input id="secretKeyBox" name="privateKey" type="text" class="main-page-righ-login-secretkey" onkeydown="if (event.keyCode == 13) { sendSecretKey(); return false; }" autocomplete="on">
                    <div class="main-page-righ-login-button">
                        <button class="main-page-righ-login-button" type="button" onclick="sendSecretKey()">
                            <img src="images/javarush-30.png" />
                            <div class="main-page-righ-login-button-text2" style="padding-left: 40px;margin-right: -20px;">Войти по секретному ключу</div>
                        </button>
                    </div>
                </form>







            </div>

            <div id="rightmenu2" class="course-main-page-righ-tmenu" style="height: 97px;top: 366px; display:none; ">

                <form action="/user/signin/logout" method="POST">
                    <div class="main-page-righ-login-button">
                        <button class="main-page-righ-login-button" type="submit">
                            <img src="images/javarush-30.png" />
                            <div class="main-page-righ-login-button-text" style="padding-left: 60px;">Разлогиниться</div>
                        </button>
                    </div>
                </form>

            </div>

            <div id="rightmenu3" class="course-main-page-righ-tmenu" style="top:500px;height: 250px;">
                <div id="vk_groups"></div>
            </div>
        </div>


    </div>
</div>


<script type="text/javascript">
    if (window.VK)
        VK.init({ apiId: 3167756 });
</script>

<script type="text/javascript">
    var sessionId = null;

    function main() {
        $.ajax({
            type: "GET",
            url: "/api/rest/user/server/statistics.json",
            data: "",
            success: function(info){
                sessionId = info.sessionId;
                showLoginPanel(sessionId == null);

                $("#usersCount").html(info.usersCount);
                $("#tasksSolvedCount").html(info.taskSolvedCount);
            }
        });
    }

    function showLoginPanel(show)
    {
        if (show)
        {
            $("#rightmenu1").show();
            $("#rightmenu2").hide();
        }
        else
        {
            $("#rightmenu1").hide();
            $("#rightmenu2").show();
        }
    }

    function vk_main()
    {
        try {
            VK.Widgets.Group("vk_groups", {mode: 0, width: "230", height: "250"}, 43948962);
        } catch (e) {
        }

        try {
            VK.Auth.getLoginStatus(function (response) {
                if (response.session) {
                    currentUserId = response.session.mid;
                    document.getElementById("vkontakte_userid").value = currentUserId;
                } else {
                    currentUserId = 100000000;
                }
            });
        } catch (e) {
        }


    }

    function getSecretKey()
    {
        var reference = $.cookie("javarush.reference.key");

        $.ajax({
            type: "GET",
            url: "/api/rest/user/signin/anonimous/create/"+reference,
            data: "",
            success: function(msg){
                $("#secretKeyBox").val(msg);
            }
        });

    }

    function sendSecretKey()
    {
        var key = document.getElementById("secretKeyBox").value;

        if (key == null || key.length == 0) {
            $("#secretKeyBox").val("тут должен быть ваш ключ");
            return;
        }

        if (key.length != 36) {
            $("#secretKeyBox").val("что-то не похоже это на ключ");
            return;
        }

        //send async request to a server
        $.ajax({
            type: "GET",
            url: "/api/rest/user/signin/anonimous/validate/"+key,
            data: "",
            success: function(responseIsKeyValid){
                if (responseIsKeyValid == true || responseIsKeyValid == "true")
                    $("#secretKeyForm").submit();
                else
                    $("#secretKeyBox").val("такого ключа нет :(");
            }
        });
    }

    main();
    vk_main();

</script>

<script language="JavaScript">

    $(function(){
        TOPMENU.initialize();
    })
</script>


<!-- Yandex.Metrika counter --><script type="text/javascript">(function (d, w, c) { (w[c] = w[c] || []).push(function() { try { w.yaCounter23548852 = new Ya.Metrika({id:23548852, webvisor:true, clickmap:true, trackLinks:true, accurateTrackBounce:true, trackHash:true}); } catch(e) { } }); var n = d.getElementsByTagName("script")[0], s = d.createElement("script"), f = function () { n.parentNode.insertBefore(s, n); }; s.type = "text/javascript"; s.async = true; s.src = (d.location.protocol == "https:" ? "https:" : "http:") + "//mc.yandex.ru/metrika/watch.js"; if (w.opera == "[object Opera]") { d.addEventListener("DOMContentLoaded", f, false); } else { f(); } })(document, window, "yandex_metrika_callbacks");</script><noscript><div><img src="//mc.yandex.ru/watch/23548852" style="position:absolute; left:-9999px;" alt="" /></div></noscript><!-- /Yandex.Metrika counter -->
</body>
</html>"""
        self.assertEqual(res, page_text)

    def test_empty_url_download(self):
        res = page_downloader('')
        self.assertEqual(res, '')

    def test_not_url_download(self):
        res = page_downloader('text')
        self.assertEqual(res, '')

    def test_url_not_text_download(self):
        res = page_downloader('https://geekbrains.ru/index/img/image.png')
        self.assertEqual(res, '')

    def test_num_download(self):
        res = page_downloader(12345)
        self.assertEqual(res, '')

    def test_not_existed_site_url_download(self):
        res = page_downloader('http://invalid_example62364.com/')
        self.assertEqual(res, '')

if __name__ == '__main__':
    unittest.main()
