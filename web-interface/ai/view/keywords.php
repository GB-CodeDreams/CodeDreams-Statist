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
                    <?=$person['Name'];?>
                </h1>
            </article>
        <br>
        Введите искомые слова:
        <br/>
        <input type="text" size="10" name="Name" value="" autofocus/>
        <br/>
        <input type="submit" name="insert" value="Добавить" />
        <br>
        <table width="300">
            <?php foreach ($keywords as $keyword): ?>
                <tr>
                    <td width="250">
                        <article>
                            <h3 class="artitle">
                                <?=$keyword['Name'];?>
                                <input type="hidden" name="ID" value="<?=$keyword['ID']?>" />
                            </h3>
                        </article>
                    </td>
                    <td>
                        <input type="submit" name="del" value="Удалить" />
                    </td>
                </tr>
                <?php endforeach; ?>
        </table>
    </form>
</body>
</html>