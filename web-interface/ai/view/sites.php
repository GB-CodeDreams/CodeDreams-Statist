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
        Введите название сайта:
        <br/>
        <input width="2000"  name="Name" value="" autofocus/>
        <br/>
        <input type="submit" name="insert" value="Добавить" />
        <br>
        <table width="300">
        <?php foreach ($sites as $site): ?>
            <tr>
                <td width="250">
                    <article>
                        <h3 class="artitle">
                            <div><?=$site['Name'];?></div>
                            <input type="hidden" name="ID" value="<?=$site['ID']?>" />
                        </h3>
                    </article>
                </td>
                <td>
                    <input type="submit" name="del" value="Удалить" />
                </td>
                <?php endforeach; ?>
            </tr>
        </table>
    </form>
</body>
</html>