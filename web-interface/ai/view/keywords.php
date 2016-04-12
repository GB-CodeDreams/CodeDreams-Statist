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
            <article>
                <h1>
                    <?=$person['name'];?>
                </h1>
            </article>
        <br>
        Введите искомые слова:
        <br/>
        <input type="text" size="10" name="name" value="" autofocus/>
        <br/>
        <input type="submit" name="insert" value="Добавить" />
        <br>
        <table width="300">
            <?php foreach ($keywords as $keyword): ?>
                <tr>
                    <td width="250">
                        <article>
                            <h3 class="artitle">
                                <?=$keyword['name'];?>
                                <input type="hidden" name="id" value="<?=$keyword['id']?>" />
                            </h3>
                        </article>
                    </td>
                    <td>
                        <a href="index.php?r=admin/keywords&person_id=<?=$person['id'];?>&id=<?=$keyword['id']?>">Удалить</a>
                    </td>
                </tr>
                <?php endforeach; ?>
        </table>
    </form>
</body>
</html>