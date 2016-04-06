<?php

abstract class C_Base extends C_Controller {

	protected $title;
	protected $content;
		
	protected function before(){
		$this->title = 'Statist v 1.0';
		$this->content = '';
	}
	
	public function render(){		
		$vars = array('title' => $this->title, 'content' => $this->content);	
		$page = $this->Template('v/v_main.php', $vars);				
		header('Content-type: text/html; charset=utf-8');
		echo $page;
	}	
}
