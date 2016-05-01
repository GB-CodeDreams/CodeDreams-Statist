<?php
//include_once('model/MSQL.php');

// ***** Менеджер пользователей *****
class Users
{	
	private static $instance;	// экземпляр класса
	private $instDbConnect;		// драйвер БД
	private $sid;				// идентификатор текущей сессии
	private $uid;				// идентификатор текущего пользователя
	
	// ***** Получение экземпляра класса *****
	// ***** результат	- экземпляр класса DbConnect *****
	public static function Instance(){
		if (empty(self::$instance)) {
            self::$instance = new self();
        }
        return self::$instance;
	}

	// ***** Конструктор *****
	public function __construct()
	{
		$this->instDbConnect = DBWork::Instance();
		$this->sid = null;
		$this->uid = null;
	}


	// ***** Добавление нового пользователя *****
	public function NewUser($login, $password, $username, $admin = 1){
		$password = md5('geekbrains' .$password. $login);

		$affected_rows = DBWork::Instance()->DBQueryExecut("INSERT INTO users (login, password, username, admin) 
															VALUE  ('$login', '$password', '$username',  '$admin')");
		if ($affected_rows == 0)
			return false;
		else
			return true;
	}


	//
	// Получает пользователя по логину
	//
	public function GetByLogin($login)
	{
		global $link;
		$t = "SELECT * FROM users WHERE login = '%s'";
		$query = sprintf($t, mysqli_real_escape_string($link, $login));
		$result = DBWork::Instance()->DBQueryOne($query);
		return $result;
	}

	// Авторизация
	// $login 		- логин
	// $password 	- пароль
	// $remember 	- нужно ли запомнить в куках
	// результат	- true или false
	public function Login($login, $password, $remember = true)
	{
		// вытаскиваем пользователя из БД
		$user = $this->GetByLogin($login);

		if ($user == null)
			return false;

		$id_user = $user['id_user'];

		// проверяем пароль
		if ($user['password'] != md5($login . 'geekbrains' .$password))
			return false;

		// запоминаем имя и md5(пароль)
		if ($remember)
		{
			$expire = time() + 3600 * 24 * 100;
			setcookie('login', $login, $expire);
			setcookie('password', md5($login . 'geekbrains' .$password), $expire);
		}

		 //открываем сессию и запоминаем SID
		//$this->sid = $this->OpenSession($id_user);

		return true;
	}


	//
	// Получение пользователя
	// $id_user		- если не указан, брать текущего
	// результат	- объект пользователя
	//
	public function Get($id_user = null)
	{
		// Если id_user не указан, берем его по текущей сессии.
		if ($id_user == null)
			$id_user = $this->GetUid();

		if ($id_user == null)
			return null;

		if (isset($_COOKIE['login']) && isset($_COOKIE['password']))
		{
			$login = $_COOKIE['login'];
			$password = $_COOKIE['password'];
		}

		// А теперь просто возвращаем пользователя по id_user.
		$t = "SELECT * FROM users WHERE login = '$login' AND password = '$password'";
		$query = sprintf($t, $id_user);
		$result = DBWork::Instance()->DBQueryOne($query);
		return $result;
	}

	//
	// Получение id текущего пользователя
	// результат	- UID
	//
	public function GetUid()
	{
		global $link;
		// Проверка кеша.
		if ($this->uid != null)
			return $this->uid;

		// Берем по текущей сессии.
		$sid = $this->GetSid();

		if ($sid == null)
			return null;

		$t = "SELECT id_user FROM sessions WHERE sid = '%s'";
		$query = sprintf($t, mysqli_real_escape_string($link, $sid));
		$result =DBWork::Instance()->DBQuery($query);

		// Если сессию не нашли - значит пользователь не авторизован.
		if (count($result) == 0)
			return null;

		// Если нашли - запоминм ее.
		$this->uid = $result[0]['id_user'];
		return $this->uid;
	}

	// ***** Очистка неиспользуемых сессий *****
	public function ClearSessions()
	{
		$min = date('Y-m-d H:i:s', time() - 60 * 20); 			
		$t = "time_last < '%s'";
		$where = sprintf($t, $min);
		DBWork::Instance()->DBQueryExecut("DELETE FROM sessions WHERE time_last = " .$where);
		$this->instDbConnect->Delete('sessions', $where);
	}

	//
	// Выход
	//
	public function Logout()
	{
		setcookie('login', '', time() - 1);
		setcookie('password', '', time() - 1);
		unset($_COOKIE['login']);
		unset($_COOKIE['password']);
		unset($_SESSION['sid']);		
		$this->sid = null;
		$this->uid = null;
	}


	//
	// Функция возвращает идентификатор текущей сессии
	// результат	- SID
	//
	private function GetSid()
	{
		global $link;
		$sid = null;
		// Проверка кеша.
		if ($this->sid != null)
			return $this->sid;

		// Ищем SID в сессии.
		if(isset($_SESSION['sid']))
			$sid = $_SESSION['sid'];

		// Если нашли, попробуем обновить time_last в базе.
		// Заодно и проверим, есть ли сессия там.
		if ($sid != null)
		{
			$session = array();
			$session['time_last'] = date('Y-m-d H:i:s');
			$t = "sid = '%s'";
			$where = sprintf($t, mysqli_real_escape_string($link, $sid));
			$affected_rows = DBWork::Instance()->DBQueryExecut("UPDATE sessions SET $where");

			if ($affected_rows == 0)
			{
				$t = "SELECT count(*) FROM sessions WHERE sid = '%s' ";
				$query = sprintf($t, mysqli_real_escape_string($link, $sid));
				$result = DBWork::Instance()->DBQuery($query);

				if ($result[0]['count(*)'] == 0)
					$sid = null;
			}
		}

		// Нет сессии? Ищем логин и md5(пароль) в куках.
		// Т.е. пробуем переподключиться.
		if ($sid == null && isset($_COOKIE['login']))
		{
			$user = $this->GetByLogin($_COOKIE['login']);

			if ($user != null && $user['password'] == $_COOKIE['password']);
				$sid = $this->OpenSession($user['id_user']);
		}

		// Запоминаем в кеш.
		if ($sid != null)
			$this->sid = $sid;

		// Возвращаем, наконец, SID.
		return $sid;
	}
	
	//
	// Открытие новой сессии
	// результат	- SID
	//
	private function OpenSession($id_user)
	{
		// генерируем SID
		$sid = $this->GenerateStr(10);
				
		// вставляем SID в БД
		$now = date('Y-m-d H:i:s');
		DBWork::Instance()->DBQueryExecut("INSERT INTO sessions (id_user, sid, time_start, time_last) 
													VALUE  ('$id_user', '$sid', '$now', '$now')");
				
		// регистрируем сессию в PHP сессии
		$_SESSION['sid'] = $sid;				
				
		// возвращаем SID
		return $sid;	
	}

	//
	// Генерация случайной последовательности
	// $length 		- ее длина
	// результат	- случайная строка
	//
	private function GenerateStr($length = 10) 
	{
		$chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPRQSTUVWXYZ0123456789";
		$code = "";
		$clen = strlen($chars) - 1;  

		while (strlen($code) < $length) 
            $code .= $chars[mt_rand(0, $clen)];  

		return $code;
	}

}
