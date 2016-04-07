<?/*
Шаблон страницы ежедневной статистики
=======================

$daily_stats - массив строк ежедневной статистики
$isError - хранит информацию о том, есть ли ошибка в заполнении формы
$selected_site - название сайта, выбранного для отображения статистики
$selected_person - личность, выбранная для отображения статистики
$start_date - дата, выбранная пользователем, или дата по-умолчанию
$end_date - дата, выбранная пользователем, или дата по-умолчанию
$sites - массив сайтов, доступных для просмотра статистики
$persons - массив личностей, доступных для просмотра статистики
$tatal_count - суммарное количество новых упоминаний

*/?>

<form method="post" action="index.php?c=statistic&act=daily_stats">

	Сайт:
	<select name="site" id="site">
		<?php foreach ($sites as $site): ?>
			<option value="<?=$site?>"><?=$site?></option>
		<?php endforeach ?>
	</select>
	<br>

	Личность:
	<select name="person" id="person">
		<?php foreach ($persons as $person): ?>
			<option value="<?=$person?>"><?=$person?></option>
		<?php endforeach ?>
	</select>
	<br>

	Период с:
	<input type="date" name="start_date" id="start_date" max="2017-06-04" min="2000-01-01">
	по: 
	<input type="date" name="end_date" id="end_date" max="2017-06-04" min="2000-01-01">
	
	<input type="submit" value="Применить">

</form>

<?/* Скрипт сохраняет выбранный сайт, личность и даты в форме */?>
<script type="text/javascript">
  	document.getElementById('site').value = "<?php echo $selected_site;?>";
  	document.getElementById('person').value = "<?php echo $selected_person;?>";
  	document.getElementById('start_date').value = "<?php echo $start_date;?>";
  	document.getElementById('end_date').value = "<?php echo $end_date;?>";
</script>



<?php if ($isError): ?>

	<p style="color:red; font-weight:bold;">Заполните все поля формы</p>

<?php else: ?>

	<table>
		<tr>
			<th>Дата</th>
			<th>Количество новых упоминаний</th>
		</tr>
		
		<?php foreach ($daily_stats as $date => $count): ?>
			<tr>
				<td><?=$date?></td>
				<td><?=$count?></td>
			</tr>
		<?php endforeach ?>
		
		<tr>
			<td colspan="2">Всего за период: <?=$total_count?></td>
		</tr>
	</table>

<?php endif ?>