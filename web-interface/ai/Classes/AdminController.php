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
            $ID = $_POST['ID'];
            $model = new Sites();
            $model->Sites_deleteOne($ID);
            $view->sites = $model->Sites_getAll();
        }

        if(isset($_POST['insert']) and $_POST['Name'] == ""){
            $new_error = true;
        }
        else{
            if(isset($_POST['insert']) and isset($_POST['Name'])){
                $Name = mysqli_real_escape_string($link, $_POST['Name']);
                $model->Sites_setOne($Name);
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
            $ID = $_POST['ID'];
            $model = new Persons();
            $model->Persons_deleteOne($ID);
            $view->persons = $model->Persons_getAll();
        }

        if(isset($_POST['insert']) and $_POST['Name'] == ""){
            $new_error = true;
        }
        else{
            if(isset($_POST['insert']) and isset($_POST['Name'])){
                $Name = mysqli_real_escape_string($link, $_POST['Name']);
                $model->Persons_setOne($Name);
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
        $PersonID = mysqli_real_escape_string($link, $_GET['PersonID']);
        $view->person = $model->Persons_getOne($PersonID);
        $view->keywords = $model->Keywords_getAll($PersonID);

        if(isset($_POST['del']))
        {
            $ID = $_POST['ID'];
            $model = new Keywords();
            $model->Keywords_deleteOne($ID);
            $view->keywords = $model->Keywords_getAll($PersonID);
        }

        if(isset($_POST['insert']) and $_POST['Name'] == ""){
            $new_error = true;
        }
        else {
            if (isset($_POST['insert']) and isset($_POST['Name'])) {
                $Name = mysqli_real_escape_string($link, $_POST['Name']);
                $model->Keywords_setOne($Name, $PersonID);
                $view->keywords = $model->Keywords_getAll($PersonID);
            }
        }

        // Вывод в шаблон.
        $html = $view->display('keywords.php');
        echo $html;
    }
}
