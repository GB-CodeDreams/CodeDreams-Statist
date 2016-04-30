<?/*
Шаблон страницы запрещающей вход 
=======================

*/?>
<?php header('Content-type: text/html; charset=utf-8'); ?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="refresh" content="3; URL=index.php">
    <title>Интерфейс администратора</title>
    <link rel="stylesheet" type="text/css" media="screen" href="view/style.css" />
</head>
<body>
<h1><?php echo "$title"; ?></h1>
<br>
<p class="stop">
    <img src="images/stop.png" alt="stop" />
</p><br/>
<h1 class="stop">У Вас нет прав на выполнение данного действия!</h1>
<br/>
</body>
</html>