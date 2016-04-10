<?php

class AdminController
    extends AController
{

    public function actionSites()
    {
        $view = new View();
        $model = new Sites();
        $view->sites = $model->Sites_getAll();
        global $link;

        if(isset($_POST['del']))
        {
            $id = $_POST['id'];
            $model = new Sites();
            $model->Sites_deleteOne($id);
            $view->sites = $model->Sites_getAll();
        }

        if(isset($_POST['insert']) and $_POST['name'] == ""){
            $new_error = true;
        }
        else{
            if(isset($_POST['insert']) and isset($_POST['name'])){
                $name = mysqli_real_escape_string($link, $_POST['name']);
                $model->Sites_setOne($name);
                $view->sites = $model->Sites_getAll();
            }
        }
        // Вывод в шаблон.
        $html = $view->display('sites.php');
        echo $html;
    }

    public function actionPersons()
    {
        $view = new View();
        $model = new Persons();
        $view->persons = $model->Persons_getAll();
        global $link;

        if(isset($_POST['del']))
        {
            $id = $_POST['id'];
            $model = new Persons();
            $model->Persons_deleteOne($id);
            $view->persons = $model->Persons_getAll();
        }

        if(isset($_POST['insert']) and $_POST['name'] == ""){
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
        $html = $view->display('persons.php');
        echo $html;
    }

    public function actionKeywords()
    {
        $view = new View();
        $model = new Keywords();
        global $link;
        $person_id = mysqli_real_escape_string($link, $_GET['person_id']);
        $view->person = $model->Persons_getOne($person_id);
        $view->keywords = $model->Keywords_getAll($person_id);

        if(isset($_POST['del']))
        {
            $id = $_POST['id'];
            $model = new Keywords();
            $model->Keywords_deleteOne($id);
            $view->keywords = $model->Keywords_getAll($person_id);
        }

        if(isset($_POST['insert']) and $_POST['name'] == ""){
            $new_error = true;
        }
        else {
            if (isset($_POST['insert']) and isset($_POST['name'])) {
                $name = mysqli_real_escape_string($link, $_POST['name']);
                $model->Keywords_setOne($name, $person_id);
                $view->keywords = $model->Keywords_getAll($person_id);
            }
        }

        // Вывод в шаблон.
        $html = $view->display('keywords.php');
        echo $html;
    }
}
