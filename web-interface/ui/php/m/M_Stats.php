<?php

class M_Stats {

	private static $instance;
	private $msql;

	private function __construct() {
		$this->msql = M_MSQL::Instance();
	}

	public static function Instance() {
		if (self::$instance == null)
			self::$instance = new M_Stats();

		return self::$instance;
	}

	public function get_all_sites() {
		$sites = array();
		$row = M_MSQL::Instance()->Select("Sites");
		foreach ($row as $value) {
			$sites[] = $value['name'];
		}
		return $sites;
	}

	private function get_site_ID_by_name($site){
		$row = M_MSQL::Instance()->Select("Sites", array("name = " => $site));
		return (int)$row[0]['id'];
	}

	private function get_pages_ID_by_site_ID($site_id) {
		$pages = array();
		$row = M_MSQL::Instance()->Select("Pages", array("site_id = " => $site_id));
		foreach ($row as $value) {
			$pages[] = $value['id'];
 		}
		return $pages;
	}

	private function get_all_persons() {
		$persons = M_MSQL::Instance()->Select("Persons");
		foreach ($persons as &$person) {
			$person['rank'] = 0;
		}
		return $persons;
	}

	public function get_general_statistics($selected_site) {
		$site_id = self::get_site_ID_by_name($selected_site);
		$pages = self::get_pages_ID_by_site_ID($site_id);
		$persons = self::get_all_persons();
		
		foreach ($pages as $page) {
			$row = M_MSQL::Instance()->Select("Person_page_ranks", array("page_id = " => $page));
			foreach ($row as $value) {
				foreach ($persons as &$person) {
					if($person['id'] == $value['person_id']) {
						$person['rank'] += $value['rank'];
					}
				}	
				unset($person);	
			}
		}
		
		$general_statistics = array();
		foreach ($persons as $person) {
			$general_statistics[] = array('person' => $person['name'], 'rank' => $person['rank']);
		}
		
		return $general_statistics;
	}

	public function get_daily_stats($selected_site, $selected_person, $start_date, $end_date) {
		return array("05.05.2016" => "7", "06.05.2016" => "3", "07.05.2016" => "5", "08.05.2016" => "5");
	}

	public function get_total_person_count($daily_stats) {
		$total_person_count = 0;
		foreach ($daily_stats as $count) {
			$total_person_count += $count;
		}
		return $total_person_count;
	}
}