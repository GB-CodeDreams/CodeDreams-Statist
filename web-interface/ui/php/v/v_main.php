<?/*
Шаблон главной страницы
=======================
$content - содержимое страницы
$title - заголовок страницы
*/?>

<!DOCTYPE html>
<html lang="en">
<head>
	<title><?=$title?></title>
	<meta content="text/html; charset=utf-8" http-equiv="content-type">
	<link rel="stylesheet" type="text/css" media="screen" href="v/style.css" /> 
</head>
<body>
	<h1><?=$title?></h1>
	<hr>

	<a href="index.php?c=statistic&act=index">Главная страница</a>
	<br>
	<a href="index.php?c=statistic&act=general_statistics">Общая статистика</a>
	<br>
	<a href="index.php?c=statistic&act=daily_stats">Ежедневная статистика</a>
	<br>
	<a href="index.php?c=admin&act=admin_panel">Панель администратора</a>
	<hr>

	<?=$content?>

</body>
</html>