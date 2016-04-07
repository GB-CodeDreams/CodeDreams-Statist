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

	public function action_daily_stats(){
		$daily_stats = array();
		$total_count = 0;
		$isError = false;

		//temporal data
		$sites = array("lenta.ru", "kp.ru", "any_other_site.com");
		$persons = array("Pytin", "Medvedev", "Noval'ny");

		$selected_site = $sites[0];
		$selected_person = $persons[0];

		if ($this->IsPost()) {
			
			if (isset($_POST['site'])) {
				$selected_site = $_POST['site'];
			} else {
				$isError = true;
			}

			if (isset($_POST['person'])) {
				$selected_person = $_POST['person'];
			} else {
				$isError = true;
			}

			if(!$isError) {
				//temporal data
				$daily_stats = array("01.04.2016" => "146", "02.04.2016" => "79", "03.04.2016" => "15");
				$total_count = 100500;
			}
		} else {
			$isError = true;
		} 	

		$vars = array(
			'daily_stats' => $daily_stats,
			'isError' => $isError,
			'selected_site' => $selected_site,
			'selected_person' => $selected_person,
			'sites' => $sites,
			'persons' => $persons,
			'total_count' => $total_count
		);
		$this->title .= '::Ежедневная статистика';
		$this->content = $this->Template('v/v_daily_stats.php', $vars);
	}

}
