<?php

class AdminController
    extends AController
{

//исправил ошибку при удалении из справочника
    public function actionSites()
    {
        global $link;
        $view = new View();
        $model = new Sites();

        $id = mysqli_real_escape_string($link, $_GET['id']);
        $model->Sites_deleteOne($id);
        $view->sites = $model->Sites_getAll();


        if(isset($_POST['insert']) and $_POST['name'] == ""){
            $new_error = true;
        }
        else{
            if(isset($_POST['insert']) and isset($_POST['name'])){
                $name = mysqli_real_escape_string($link, $_POST['name']);
                $url = mysqli_real_escape_string($link, $_POST['url']);
                $site_id = $model->Sites_setOne($name);
                $model->Pages_setOne($url, $site_id);
                $view->sites = $model->Sites_getAll();
            }
        }
        // Вывод в шаблон.
        $html = $view->display('sites.html');
        echo $html;
    }

    public function actionPersons()
    {
        global $link;
        $view = new View();
        $model = new Persons();

        $id = mysqli_real_escape_string($link, $_GET['id']);
        $model->Persons_deleteOne($id);
        $view->persons = $model->Persons_getAll();

        if(isset($_POST['insert']) and $_POST['name'] == "" or $_POST['name_2'] == "" or $_POST['distance'] == ""){
            $new_error = true;
        }
        else{
            if(isset($_POST['insert']) and isset($_POST['name'])){
                $name = mysqli_real_escape_string($link, $_POST['name']);
                $model->Persons_setOne($name);
                $view->persons = $model->Persons_getAll();
            }
        }
        // Вывод в шаблон.
        $html = $view->display('persons.html');
        echo $html;
    }

    public function actionKeywords()
    {
        global $link;
        $view = new View();
        $model = new Keywords();

        $person_id = mysqli_real_escape_string($link, $_GET['person_id']);
        $view->person = $model->Persons_getOne($person_id);

        $id = mysqli_real_escape_string($link, $_GET['id']);
        $model->Keywords_deleteOne($id);
        $view->keywords = $model->Keywords_getAll($person_id);

        if(isset($_POST['insert']) and $_POST['name'] == ""){
            $new_error = "Заполните все поля";
        }
        else {
            if (isset($_POST['insert']) and isset($_POST['name'])) {
                $name = mysqli_real_escape_string($link, $_POST['name']);
                $name_2 = mysqli_real_escape_string($link, $_POST['name_2']);
                $distance = mysqli_real_escape_string($link, $_POST['distance']);
                $model->Keywords_setOne($name, $name_2, $distance, $person_id);
                $view->keywords = $model->Keywords_getAll($person_id);
            }
        }

        // Вывод в шаблон.
        $html = $view->display('keywords.html');
        echo $html;
    }
}
