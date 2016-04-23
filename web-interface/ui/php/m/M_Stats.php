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
			$sites[$value['id']] = $value['name'];
		}
		return $sites;
	}

	public function get_all_persons() {
		$persons = array();
		$row = M_MSQL::Instance()->Select("persons");
		foreach ($row as $value) {
			$persons[$value['id']] = $value['name'];
		}
		return $persons;
	}

	public function get_all_keywords($person_id) {
		$keywords = array();
		$row = M_MSQL::Instance()->Select("keywords", ['person_id =' => $person_id]);
		foreach ($row as $value) {
			$keywords[$value['id']] = array('word_1' => $value['name'], 'word_2' => $value['name_2'], 'distance' => $value['distance']);
		}
		return $keywords;	
	}

	public function get_person_name_by_id($id) {
		$result = M_MSQL::Instance()->Select("persons", ['id =' => $id]);
		return $result[0]['name'];
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

	public function add_new_site($site) {
		M_MSQL::Instance()->Insert("sites", ['name' => $site]);
	}

	public function delete_site($site_id) {
		M_MSQL::Instance()->Delete("sites", ['id =' => $site_id]);
	}

	public function add_new_person($person) {
		M_MSQL::Instance()->Insert("persons", ['name' => $person]);		
	}

	public function delete_person($person_id) {
		M_MSQL::Instance()->Delete("persons", ['id =' => $person_id]);
	}

	public function add_new_keyword($person_id, $word_1, $word_2, $distance) {
		M_MSQL::Instance()->Insert("keywords", array('person_id' => $person_id, 'name' => $word_1, 'name_2' => $word_2, 'distance' => $distance ));
	}

	public function delete_keyword($keyword_id) {
		M_MSQL::Instance()->Delete("keywords", ['id =' => $keyword_id]);
	}
	
}