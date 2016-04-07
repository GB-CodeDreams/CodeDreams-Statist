<?/*
Шаблон страницы общей статистики
=======================

$general_statistics - массив строк общей статистики
$isSelectSite - хранит информацию о том, выбран ли сайт для отображения статистики
$site - название сайта, выбранного для отображения статистики
*/?>

<form method="post" action="index.php?c=statistic&act=general_statistics">
	<select name="site" id="site">
		<option value="lenta">lenta.ru</option>
		<option value="kp">kp.ru</option>
	</select>
	<input type="submit" value="Применить">
</form>

<?/* Скрипт сохраняет выбранный сайт в поле 'Select' */?>
<script type="text/javascript">
  	document.getElementById('site').value = "<?php echo $site;?>";
</script>



<?php if ($isSelectSite): ?>
	
	<table>
		<tr>
			<th>Имя</th>
			<th>Количество упоминаний</th>
		</tr>

		<?php foreach ($general_statistics as $name => $count): ?>
			<tr>
				<td><?=$name?></td>
				<td><?=$count?></td>
			</tr>
		<?php endforeach ?>

	</table>

<?php endif ?>