<?/*
Шаблон страницы общей статистики
=======================

$general_statistics - массив строк общей статистики
$isSelectSite - хранит информацию о том, выбран ли сайт для отображения статистики
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
	
	<?php if ($isSelectSite): ?>
		<table>
			<tr>
				<th>Имя</th>
				<th>Количество упоминаний</th>
			</tr>
			<?php foreach ($general_statistics as $data): ?>
				<tr>
					<td><?=$data['person']?></td>
					<td><?=$data['rank']?></td>
				</tr>
			<?php endforeach ?>
		</table>
	<?php endif ?>

</div>