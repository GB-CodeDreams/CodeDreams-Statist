<?php

function __autoload($classname){
	$type = mb_strtolower( mb_substr($classname, 0, 1) );
	include_once("$type/$classname.php");
}

session_start();

error_reporting(-1);
setlocale(LC_ALL, 'ru_RU.UTF-8');	// Устанавливаем нужную локаль (для дат, денег, запятых и пр.)
mb_internal_encoding("UTF-8");		// Устанавливаем кодировку строк

$action = 'action_';
$action .= (isset($_GET['act'])) ? $_GET['act'] : 'index';

switch (@$_GET['c'])
{
	case 'statistic':
		$controller = new C_Statistic();
		break;
	case 'admin':
		$controller = new C_Admin();
		break;	
	default:
		$controller = new C_Statistic();
}

$controller->Request($action);