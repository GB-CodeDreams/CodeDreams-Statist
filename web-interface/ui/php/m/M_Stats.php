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
		$row = M_MSQL::Instance()->Select("sites");
		foreach ($row as $value) {
			$sites[] = $value['name'];
		}
		return $sites;
	}

	public function get_all_persons() {
		$persons = array();
		$row = M_MSQL::Instance()->Select("persons");
		foreach ($row as $value) {
			$persons[] = $value['name'];
		}
		return $persons;
	}

	public function get_general_statistics($selected_site) {
		$general_statistics = array();

		$result = M_MSQL::Instance()->query
			("	SELECT persons.name AS person, SUM(person_page_ranks.rank) AS rank
				FROM persons, person_page_ranks, pages, sites
				WHERE persons.id = person_page_ranks.person_id
				AND person_page_ranks.page_id = pages.id
				AND pages.site_id = sites.id
				AND sites.name = '$selected_site'
				GROUP BY persons.name
			");
		
		while ($row = mysqli_fetch_assoc($result)) {
			$general_statistics[$row['person']] = (int)$row['rank'];
		}

		return $general_statistics;
	}

	public function get_daily_stats($selected_site, $selected_person, $start_date, $end_date) {
		for ($i = strtotime($start_date); $i < strtotime($end_date); $i+=86400) { 
			$daily_stats[date("Y-m-d", $i)] = 0;
		}
		
		$result = M_MSQL::Instance()->query
			("	SELECT DATE_FORMAT(pages.last_scan_date, '%Y-%m-%d') AS day, SUM(person_page_ranks.rank) AS rank
				FROM persons, person_page_ranks, pages, sites
				WHERE persons.id = person_page_ranks.person_id
				AND person_page_ranks.page_id = pages.id
				AND pages.site_id = sites.id
				AND persons.name = '$selected_person'
				AND sites.name = '$selected_site'
				AND pages.last_scan_date >= '$start_date'
				AND pages.last_scan_date < '$end_date'
				GROUP BY DATE_FORMAT(pages.last_scan_date, '%Y-%m-%d')
			");
	
		while ($row = mysqli_fetch_assoc($result)) {
			$daily_stats[$row['day']] = (int)$row['rank'];
		}
			
		ksort($daily_stats);
		return $daily_stats;
	}

	public function get_total_daily_count($daily_stats) {
		$total_daily_count = 0;
		foreach ($daily_stats as $count) {
			$total_daily_count += $count;
		}
		return $total_daily_count;
	}
}