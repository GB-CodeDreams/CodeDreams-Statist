<?/*
Шаблон страницы управления справочником сайтов
=======================

$sites - массив строк сайтов

*/?>

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
    echo '<a href="index.php?r=user/login">Вход</a>'; }
?> |
<a href="../../web-interface/ui/php/index.php?c=statistic&act=general_statistics">Панель пользователя</a> |
<a href="index.php?r=admin/sites">Справочник сайтов</a> |
<a href="index.php?r=admin/persons">Справочник личностей</a> |
<form method="post">
    <br>
    Введите название сайта:
    <br/>
    <input  name="name" value="" autofocus required/>
    <br>
    <br>
    Введите ссылку на главную страницу сайта:
    <br/>
    <input type="url"  name="url" placeholder="http://www.sites.com"  value="" required/>
    <br/>
    <br>
    <input type="submit" name="insert" value="Добавить" />
    <br/>
    <table>
        <tr>
            <td>Название сайта</td>
            <td>Действие</td>
        </tr>
        <?php foreach ($sites as $site): ?>
        <tr>
            <td width="430">
                <?=$site['name'];?>
            </td>
            <td>
                <a href="index.php?r=admin/sites&id=<?=$site['id'];?>">Удалить</a>
            </td>
            <?php endforeach; ?>
        </tr>
    </table>
</form>
</body>
</html>