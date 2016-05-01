<?/*
Шаблон страницы регистрации администратора
=======================

$user - пользователь, регистрирующийся от имени администартора
*/?>

<?php

$instUsers = Users::Instance();
global $link;

// Обработка отправки формы.
	if (!empty($_POST)){
        $login = mysqli_real_escape_string($link, $_POST['login']);
        $username = mysqli_real_escape_string($link, $_POST['username']);
        $password = mysqli_real_escape_string($link, $_POST['password']);
        $password2 = mysqli_real_escape_string($link, $_POST['password2']);
        $user = $instUsers->GetByLogin($login);

        if($_POST['password'] != $_POST['password2']){
            $err = 'Пароли не совпадают!';
        }elseif(is_array($user)){
            $err = 'Такой пользователь уже существует!';
        }else{
            $instUsers->NewUser($login, $password, $username);
            header('Location: index.php');
            die();
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
     echo 'Привет, '.$user['username'].'.<br/><br/><a href="index.php?r=user/logout">Выход</a>';
 }else{
     echo '<a href="index.php?r=user/login">Вход</a>'; }?> |
<a href="../../web-interface/ui/php/index.php?c=statistic&act=general_statistics">Панель пользователя</a> |
<a href="index.php?r=admin/sites">Справочник сайтов</a> |
<a href="index.php?r=admin/persons">Справочник личностей</a> |
<hr/>
<h2 align="center">Новый пользователь</h2>
<?if(isset($err)) echo '<h3 class="stop">' . $err . '</h3><br/>';?>
<form method="post">
    <fieldset>
        <legend>Введите свои данные</legend>
        <table id="logtable">
            <tr>
                <td><label for="logname">Логин:</label></td>
                <td><input type="email" size="50" id="login" placeholder="login@mail.ru" name="login" /></td>
            </tr>
            <tr>
                <td><label for="name">Имя:</label></td>
                <td><input type="text" size="50" id="login" name="username" /></td>
            </tr>
            <tr>
                <td><label for="password">Пароль:</label></td>
                <td><input type="password" size="50" id="login" name="password" /></td>
            </tr>
            <tr>
                <td><label for="password">Повторите пароль:</label></td>
                <td><input type="password" size="50" id="login" name="password2" /></td>
            </tr>
            <tr>
                <td colspan="2"  id="login2"><input type="submit" value="Отправить" /></td>
            </tr>
        </table>
    </fieldset>
</form>
<hr/>
</body>
</html>
