<?/*
Шаблон страницы общей статистики
=======================

$general_statistics - массив строк общей статистики
$isError - есть ли данные для построения таблицы
$selected_site - название сайта, выбранного для отображения статистики
$sites - массив сайтов, доступных для просмотра статистики

*/?>

<ul class="tabs">
    <li class="current"><a href="index.php?c=statistic&act=general_statistics">Общая статистика</a></li>
    <li><a href="index.php?c=statistic&act=daily_stats">Ежедневная статистика</a></li>
    <li><a href="../../ai/index.php?r=admin/sites">Панель администратора</a></li>
</ul>

<div class="box visible">

	<form method="post" action="index.php?c=statistic&act=general_statistics">
		<label for="site" >Сайт:</label>
		<select name="site" id="site" class="site">
			<?php foreach ($sites as $site): ?>
				<option value="<?=$site?>"><?=$site?></option>
			<?php endforeach ?>
		</select>
		<input type="submit" value="Применить">
	</form>

	<?/* Скрипт сохраняет выбранный сайт в поле 'Select' */?>
	<script type="text/javascript">
	  	document.getElementById('site').value = "<?php echo $selected_site;?>";
	</script>
	
	<?php if ($isError): ?>
		<p style="color:red; font-weight:bold;">Нет данных для отображения</p>
	<?php endif ?>

	<?php if (!$isError): ?>
		<table>
			<tr>
				<th>Имя</th>
				<th>Количество упоминаний</th>
			</tr>
			<?php foreach ($general_statistics as $name => $rank): ?>
				<tr>
					<td><?=$name?></td>
					<td><?=$rank?></td>
				</tr>
			<?php endforeach ?>
		</table>

		<script type="text/javascript">
				google.charts.load('current', {'packages':['corechart']});
			    google.charts.setOnLoadCallback(drawChart);
			    function drawChart() {
			    	var json_data = <?=json_encode($general_statistics)?>;
			    	var arr = [];
					for(var k in json_data) {
						arr.push([k, json_data[k]]);
					}
										
					var data = new google.visualization.DataTable();
					data.addColumn('string', 'Имя');
					data.addColumn('number', 'Кол-во упоминаний');
					data.addRows(arr);
					
					var chart = new google.visualization.BarChart(document.getElementById('chart_div'));
					var options = {
						bar: {groupWidth: "95%"},
						legend: { position: "none" },
					};
					chart.draw(data, options);
				}
		</script>
		<div id="chart_div"></div>
		
	<?php endif ?>

</div>