<?php

class C_Statistic extends C_Base {

	const  ONE_WEEK = 604800;

	public function action_index() {
		header( 'Location: index.php?c=statistic&act=general_statistics' );
	}

	public function action_general_statistics(){
		$general_statistics = array();
		$isSelectSite = false;

		$sites = M_Stats::Instance()->get_all_sites();
		$selected_site = $sites[0];

		if ($this->IsPost()) {
			$isSelectSite = true;
			$selected_site = $_POST['site'];
			
			$general_statistics = M_Stats::Instance()->get_general_statistics($selected_site);
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
		$start_date = date('Y-m-d', time() - self::ONE_WEEK);
		$end_date = date('Y-m-d', time());
		
		$sites = M_Stats::Instance()->get_all_sites();
		$persons = M_Stats::Instance()->get_all_persons();

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

			if ( strlen($_POST['start_date']) == 0 || strlen($_POST['end_date']) == 0) {
				$isError = true;
			}

			$end_date = $_POST['end_date'];
			$start_date = $_POST['start_date'];

			if ($end_date < $start_date) {
				$tmp_date = $end_date;
				$end_date = $start_date;
				$start_date = $tmp_date;
			}
			
			if(!$isError) {
				
				$daily_stats = M_Stats::Instance()->get_daily_stats($selected_site, $selected_person, $start_date, $end_date);
				$total_count = M_Stats::Instance()->get_total_person_count($daily_stats);
			}
		} else {
			$isError = true;
		} 	

		$vars = array(
			'daily_stats' => $daily_stats,
			'isError' => $isError,
			'sites' => $sites,
			'persons' => $persons,
			'selected_site' => $selected_site,
			'selected_person' => $selected_person,
			'start_date' => $start_date,
			'end_date' => $end_date,
			'total_count' => $total_count
		);
		$this->title .= '::Ежедневная статистика';
		$this->content = $this->Template('v/v_daily_stats.php', $vars);
	}

	public function action_admin_panel() {
		header( 'Location: index.php' );
	}
}
