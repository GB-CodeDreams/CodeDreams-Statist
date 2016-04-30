<?/*
Шаблон страницы входа в административную часть сайта
=======================

$user - пользователь, входящий в административную часть сайта

*/?>

<?php

$instUsers = Users::Instance();
global $link;

// Обработка отправки формы.
if (!empty($_POST))
{

    $login = mysqli_real_escape_string($link, $_POST['login']);
    $password = mysqli_real_escape_string($link, $_POST['password']);
    if ($instUsers->Login($login, $password))
    {
        header('Location: index.php?r=admin/sites');
        die();
    }else{
        $err = 'Вы ввели не верный пароль или логин';
    }
}
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Интерфейс администратора</title>
    <link rel="stylesheet" type="text/css" media="screen" href="view/style.css" />
</head>
<body>
<h1><?php echo "$title"; ?></h1>
<br>
<?php
if(isset($user)){
    echo 'Привет, '.$user['name'].'.<br/><br/><a href="index.php?r=user/logout">Выход</a>';
}else{
    echo '<a href="index.php?r=user/login">Вход</a>'; }?> |
<a href="../../web-interface/ui/php/index.php?c=statistic&act=general_statistics">Панель пользователя</a> |
<a href="index.php?r=admin/sites">Справочник сайтов</a> |
<a href="index.php?r=admin/persons">Справочник личностей</a> |
<hr/>
<h1 align="center">Авторизация</h1>
<?if(isset($err)) echo '<h3 class="stop">' . $err . '</h3><br/>';?>
<form method="post">
    <table id="logtable">
        <tr>
            <td>Логин:</td>
            <td><input type="text" name="login" id="login" /></td>
        </tr>
        <tr>
            <td>Пароль:</td>
            <td><input type="password" name="password" id="login" /></td>
        </tr>
        <tr>
            <td colspan=2><input type="checkbox" name="remember" /> Запомнить меня</td>
        </tr>
        <tr>
            <td colspan=2 id="login2"><input type="submit" /></td>
        </tr>
    </table>
</form>
<p align="center">
    <a href="index.php?r=user/register">Зарегистрироваться</a>
</p>
<hr/>
</body>
</html>

