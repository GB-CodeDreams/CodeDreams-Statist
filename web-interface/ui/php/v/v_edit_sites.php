<?/*
Шаблон страницы редактирования списка сайтов
=======================

$sites - массив сайтов, доступных для просмотра статистики

*/?>

<ul class="tabs">
    <li class="current"><a href="index.php?c=statistic&act=general_statistics">Общая статистика</a></li>
    <li><a href="index.php?c=statistic&act=daily_stats">Ежедневная статистика</a></li>
    <li><a href="../../ai/index.php?r=admin/sites">Панель администратора</a></li>
</ul>

<div class="box visible">

	<form method="post" action="index.php?c=statistic&act=edit_sites">
		<label for="site">Cайт:</label>
		<input type="text" id="site" name="site" required>
		<input type="submit" value="Добавить">
	</form>

	<table>
	<?php foreach ($sites as $site_id => $site): ?>
		<tr>
			<td><?=$site?></td>
			<td><a href="index.php?c=statistic&act=edit_sites&delete&site_id=<?=$site_id?>">Удалить</a></td>
		</tr>
	<?php endforeach ?>
	</table>

</div>
