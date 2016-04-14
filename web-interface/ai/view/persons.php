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
    <form method="post">
        <br>
        <br>
        Введите имя:
        <br/>
        <input type="text" name="name" value="" autofocus/>
        <br/>
        <input type="submit" name="insert" value="Добавить" />
        <br>
        <table width="700">
            <?php foreach ($persons as $person): ?>
                <tr>
                    <td width="200">
                        <article>
                            <h3 class="artitle">
                                <?=$person['name'];?>
                                <input type="hidden" name="id" value="<?=$person['id']?>" />
                            </h3>
                        </article>
                    </td>
                    <td width="100">
                        <input type="submit" name="del" value="Удалить" />
                    </td>
                    <td>
                        <a href="index.php?r=admin/keywords&person_id=<?=$person['id']?>">Задать набор искомых слов</a>
                    </td>
                </tr>
            <?php endforeach; ?>
        </table>
    </form>
</body>
</html>