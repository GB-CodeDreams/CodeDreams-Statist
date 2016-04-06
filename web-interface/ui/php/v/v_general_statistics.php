<?/*
Шаблон страницы общей статистики
=======================

*/?>

<form method="post" action="index.php?c=statistic&act=general_statistics">
	<select name="site">
		<option value="lenta">lenta.ru</option>
		<option value="kp">kp.ru</option>
	</select>
	<input type="submit" value="Применить">
</form>

<?=$site?>