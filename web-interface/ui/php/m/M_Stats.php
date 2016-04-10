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

	private function get_pages_ID_and_dates_by_site_ID($site_id, $start_date, $end_date) {
		$pages = array();

		$where = array("site_id = " => $site_id, "found_date_time >= " => $start_date, "found_date_time <= " => $end_date);
		$order = "found_date_time";
		$row = M_MSQL::Instance()->Select("Pages", $where, $order);
		
		foreach ($row as $value) {
			$pages[] = array("page_id" =>$value['id'], "date" => $value['found_date_time'], "rank" => 0);
 		}
		return $pages;
	}

	private function get_all_persons_with_id() {
		$persons = M_MSQL::Instance()->Select("Persons");
		foreach ($persons as &$person) {
			$person['rank'] = 0;
		}
		unset($person);
		return $persons;
	}

	public function get_all_persons() {
		$persons = array();
		$row = M_MSQL::Instance()->Select("Persons");
		foreach ($row as $value) {
			$persons[] = $value['name'];
		}
		return $persons;
	}

	public function get_person_id_by_name($name) {
		$row = M_MSQL::Instance()->Select("Persons", array("name = " => $name));
		return (int)$row[0]['id'];
	}

	//TODO: Слишком много запросов к БД
	private function get_all_persons_and_ranks_by_site($site) {
		$site_id = self::get_site_ID_by_name($site);
		$pages = self::get_pages_ID_by_site_ID($site_id);
		$persons = self::get_all_persons_with_id();
		
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
		return $persons;
	}

	public function get_general_statistics($selected_site) {
		$general_statistics = array();
		$persons = self::get_all_persons_and_ranks_by_site($selected_site);
		foreach ($persons as $person) {
			$general_statistics[] = array('person' => $person['name'], 'rank' => $person['rank']);
		}
		return $general_statistics;
	}

	public function get_daily_stats($selected_site, $selected_person, $start_date, $end_date) {
		$daily_stats = array();
		$site_id = self::get_site_ID_by_name($selected_site);
		$pages = self::get_pages_ID_and_dates_by_site_ID($site_id, $start_date, $end_date);
		$person_id = self::get_person_id_by_name($selected_person);

		foreach ($pages as &$page) {
			$where = array("person_id = " => $person_id, "page_id = " => $page['page_id']);
			$row = M_MSQL::Instance()->Select("Person_page_ranks", $where);
			foreach ($row as $value) {
				$page['rank'] += $value['rank']; 
			}
		}
		unset($page);

		foreach ($pages as $page) {
			@$daily_stats[$page['date']] += $page['rank']; 
		}

		return $daily_stats;
	}

	public function get_total_person_count($daily_stats) {
		$total_person_count = 0;
		foreach ($daily_stats as $count) {
			$total_person_count += $count;
		}
		return $total_person_count;
	}
}