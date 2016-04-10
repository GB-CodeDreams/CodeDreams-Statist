<?php

class C_Admin extends C_Base {

	public function action_index() {
		header( 'Location: index.php?c=statistic&act=general_statistics' );
	}
	
	public function action_admin_panel() {
		header( 'Location: index.php?c=statistic&act=general_statistics' );
	}
}
