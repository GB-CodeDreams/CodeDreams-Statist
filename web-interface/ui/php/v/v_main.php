<?/*
Шаблон главной страницы
=======================
$content - содержимое страницы
$title - заголовок страницы
*/?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title><?=$title?></title>
	<link rel="stylesheet" href="v/style.css">
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</head>
<body>
	
	<div class="wrapper">
		<div class="section">
			
			<?=$content?>

		</div>
	</div>

</body>