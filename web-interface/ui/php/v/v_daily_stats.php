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

<ul class="tabs">
    <li><a href="index.php?c=statistic&act=general_statistics">Общая статистика</a></li>
    <li class="current"><a href="index.php?c=statistic&act=daily_stats">Ежедневная статистика</a></li>
    <li><a href="../../ai/index.php?r=admin/sites">Панель администратора</a></li>
</ul>

<div class="box visible">
	<form method="post" action="index.php?c=statistic&act=daily_stats">
		<table class="every_day">
			<tr>
				<td>
					<label for="site">Cайт:</label>
				</td>
				<td>
					<select id="site" name="site" class="every_day_select">
						<?php foreach ($sites as $site): ?>
							<option value="<?=$site?>"><?=$site?></option>
						<?php endforeach ?>
					</select>
				</td>
			</tr>
			<tr>
				<td>
					<label for="person">Личность:</label>
				</td>
				<td>
					<select id="person" name="person" class="every_day_select">
						<?php foreach ($persons as $person): ?>
							<option value="<?=$person?>"><?=$person?></option>
						<?php endforeach ?>
					</select>
				</td>
			</tr>
			<tr>
				<td>
					<label for="date">Период с:</label>
				</td>
				<td>
					<input type="date" name="start_date" id="start_date" max="2017-06-04" min="2000-01-01">
					по:<input type="date" name="end_date" id="end_date" max="2017-06-04" min="2000-01-01">												
				</td>
			</tr>
			<tr>
				<td colspan="2"><input type="submit" value="Применить"></td>
			</tr>
		</table>
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
</div>