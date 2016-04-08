<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Интерфейс администратора</title>
    <link rel="stylesheet" type="text/css" media="screen" href="view/style.css" />
</head>
<body>
<h1>Интерфейс администратора</h1>
<br/>
<a href="index.php?r=admin/sites">Справочник сайтов</a> |
<a href="index.php?r=admin/persons">Справочник личностей</a> |
<a href="index.php?r=admin/keywords">Справочник keywords</a> |
    <form method="post">
        <br>
        <br>
        Введите название сайта:
        <br/>
        <input type="text" name="Name" value="" />
        <br/>
        <input type="submit" name="insert" value="Добавить" />
        <br>
        <?php foreach ($sites as $site): ?>
            <article>
                <h3 class="artitle">
                    <div><?=$site['Name'];?></div>
                    <input type="hidden" name="ID" value="<?=$site['ID']?>" />
                    <input type="submit" name="del" value="Удалить" />
                </h3>
            </article>
        <?php endforeach; ?>
    </form>
</body>
</html>