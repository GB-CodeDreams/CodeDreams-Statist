<?/*
Шаблон страницы редактирования списка запросов
=======================

$persons - массив запросов, доступных для просмотра статистики

*/?>

<ul class="tabs">
    <li><a href="index.php?c=statistic&act=general_statistics">Общая статистика</a></li>
    <li><a href="index.php?c=statistic&act=daily_stats">Ежедневная статистика</a></li>
    <li><a href="../../ai/index.php?r=admin/sites">Панель администратора</a></li>
</ul>

<div class="box visible">

	<form method="post" action="index.php?c=statistic&act=edit_persons">
		<label for="person">Запрос:</label>
		<input type="text" id="person" name="person" required>
		<input type="submit" value="Добавить">
	</form>

	<table>
		<tr>
			<td>Запрос</td>
			<td colspan="2">Действие</td>
		</tr>
	<?php foreach ($persons as $person_id => $person): ?>
		<tr>
			<td><?=$person?></td>
			<td><a href="index.php?c=statistic&act=edit_keywords&person_id=<?=$person_id?>">Редактировать</a></td>
			<td><a href="index.php?c=statistic&act=edit_persons&delete&person_id=<?=$person_id?>">Удалить</a></td>
		</tr>
	<?php endforeach ?>
	</table>

</div>
