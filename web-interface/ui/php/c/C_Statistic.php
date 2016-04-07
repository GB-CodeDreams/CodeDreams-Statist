<?php

class C_Statistic extends C_Base {

	public function action_index() {
		$this->title .= '::Главная страница';
	}

	public function action_general_statistics(){
		$general_statistics = array();
		$isSelectSite = false;

		//temporal data
		$sites = array("lenta.ru", "kp.ru", "any_other_site.com");

		$selected_site = $sites[0];

		if ($this->IsPost()) {
			$isSelectSite = true;
			$selected_site = $_POST['site'];
			
			//temporal data
			$general_statistics = array("Pytin" => "146", "Medved" => "79");
		} 	

		$vars = array(
			'general_statistics' => $general_statistics,
			'isSelectSite' => $isSelectSite,
			'selected_site' => $selected_site,
			'sites' => $sites
		);
		$this->title .= '::Общая статистика';
		$this->content = $this->Template('v/v_general_statistics.php', $vars);
	}

}
