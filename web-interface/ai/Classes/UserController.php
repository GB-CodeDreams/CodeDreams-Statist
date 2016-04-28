<?php
// ***** Контроллер пользователей. *****

class UserController extends AController
{	
	// ***** Добавление нового комментария в БД *****
	public function actionLogin(){
		$view = new View();

		// Вывод в шаблон.
		$view->title = 'Вход';
		$html = $view->display('login.php');
		echo $html;
	}
	
	public function actionLogout(){
		$instUsers = Users::Instance();
		$instUsers->Logout();
		header('Location: index.php');
	}
	
	public function actionRegister(){
		$view = new View();

		// Вывод в шаблон.
		$view->title = 'Регистрация';
		$html = $view->display('register.php');
		echo $html;
	}
}
