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
        <p>
            <select>
                <option disabled>Выберите героя</option>
                <?php foreach ($persons as $person): ?>
                    <option value="<?=$person['ID'];?>"><?=$person['Name'];?></option>
                <?php endforeach; ?>
            </select>
            <input type="submit" name="PersonID" value="Применить" />
        </p>
        <br>
        Введите искомые слова:
        <br/>
        <input type="text" name="Name" value="" />
        <br/>
        <input type="submit" name="insert" value="Добавить" />
        <br>
        <?php foreach ($keywords as $keyword): ?>
            <article>
                <h3 class="artitle">
                    <?=$keyword['Name'];?>
                    <input type="hidden" name="ID" value="<?=$keyword['ID']?>" />
                    <input type="submit" name="del" value="Удалить" />
                </h3>
            </article>
        <?php endforeach; ?>
    </form>
</body>
</html>