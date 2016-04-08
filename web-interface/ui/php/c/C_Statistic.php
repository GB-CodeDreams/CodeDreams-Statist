<?php

class C_Statistic extends C_Base {

	public function action_index() {
		$this->title .= '::Главная страница';
	}

	public function action_general_statistics(){

		$message = isset($_POST['site']) ? $_POST['site'] : "NULL";
		
		$vars = array('site' => $message);

		$this->title .= '::Общая статистика';
		$this->content = $this->Template('v/v_general_statistics.php', $vars);
	}

}
