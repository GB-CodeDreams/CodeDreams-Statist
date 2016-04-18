<?/*
Шаблон страницы редактирования списка ключевых слов
=======================

$keywords - массив ключевых слов, для запроса $person
$person_id - id текущего пользователя
$person_name - имя текущего пользователя

*/?>

<ul class="tabs">
    <li><a href="index.php?c=statistic&act=general_statistics">Общая статистика</a></li>
    <li><a href="index.php?c=statistic&act=daily_stats">Ежедневная статистика</a></li>
    <li><a href="../../ai/index.php?r=admin/sites">Панель администратора</a></li>
</ul>

<div class="box visible">
	
	<h3>Редактирование запроса <?=$person_name?>.</h3>
	<br>
	<form method="post" action="index.php?c=statistic&act=edit_keywords&person_id=<?=$person_id?>">
		<input type="text" name="word_1" placeholder="Ключекое слово 1" required>
		<input type="text" name="word_2" placeholder="Ключекое слово 2" required>
		<input type="number" name="distance" required placeholder="Интервал">
		<br>
		<br>
		<input type="submit" value="Добавить">
	</form>

	<table>
		<tr>
			<td>Ключевое слово 1</td>
			<td>Ключевое слово 2</td>
			<td>Интервал</td>
			<td>Действие</td>
		</tr>
		<?php foreach ($keywords as $keyword_id => $keyword): ?>
			<tr>
				<td><?=$keyword['word_1']?></td>
				<td><?=$keyword['word_2']?></td>
				<td><?=$keyword['distance']?></td>
				<td><a href="index.php?c=statistic&act=edit_keywords&delete&person_id=<?=$person_id?>&keyword_id=<?=$keyword_id?>">Удалить</a></td>
			</tr>
		<?php endforeach ?>
	</table>

</div>