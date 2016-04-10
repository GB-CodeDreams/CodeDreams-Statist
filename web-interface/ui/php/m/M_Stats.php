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
		return array("lenta", "kp", "ather_site");
	}

	public function get_general_statistics($selected_site) {
		return array("putin" => 179, "medvedev" => 146);
	}

	public function get_all_persons() {
		return array("putin", "medvedev");
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