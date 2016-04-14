<?php

// Настройки подключения к БД.
define('MYSQL_SERVER', 'us-cdbr-iron-east-03.cleardb.net');
define('MYSQL_USER', 'bd941bf360b590');
define('MYSQL_PASSWORD', '4a3b98d8');
define('MYSQL_DB', 'heroku_e87588648c44590');

class M_MSQL extends mysqli {

	private static $instance;
	
	public static function Instance() {
		if (self::$instance == null)
			self::$instance = new M_MSQL(MYSQL_SERVER, MYSQL_USER, MYSQL_PASSWORD, MYSQL_DB);
		return self::$instance;
	}

	public function __construct($host, $user, $pass, $db) {
        parent::__construct($host, $user, $pass, $db);

        if (mysqli_connect_error()) {
            die("Error (".mysqli_connect_errno().") : ".mysqli_connect_error());
        }

		if(!self::set_charset("utf8")) {
	        printf("Error: ".self::mysqli_error());   
	    }
	}

	public function Select($table, $where=null, $order=null) {
		// SELECT
		$query = "SELECT * FROM $table";
		// WHERE
		if ($where) {
			$query .= " WHERE ";
			$values = array();
			foreach ($where as $key => $value) {
				$value = self::real_escape_string($value);
				$values[] = "$key '$value'";
			}
			$query .= implode(" AND ", $values);
		}
		// ORDER BY
		if ($order) {
			$query .= "  ORDER BY $order DESC";
		}

		$result = self::query($query);
		
		if (!$result)
			die($this->error);

		$arr = array();
		while ($row = mysqli_fetch_assoc($result)) {
			$arr[] = $row;
		}
		return $arr;	
	}

	public function Insert($table, $object) {
		$columns = array(); 
		$values = array(); 
		foreach ($object as $key => $value)
		{
			$columns[] = $key;
			
			if ($value === null) {
				$values[] = 'NULL';
			} else {
				$value = self::real_escape_string($value . '');							
				$values[] = "'$value'";
			}
		}
		$columns_s = implode(',', $columns); 
		$values_s = implode(',', $values);  
			
		$query = "INSERT INTO $table ($columns_s) VALUES ($values_s)";
		$result = self::query($query);
								
		if (!$result)
			die($this->error);
			
		return $this->insert_id;
	}

	public function Update($table, $object, $where) {
		$sets = array();
		foreach ($object as $key => $value) {
			if ($value === null) {
				$sets[] = "$value=NULL";			
			} else {
				$value = self::real_escape_string($value . '');					
				$sets[] = "$key='$value'";			
			}			
		}
		$sets_s = implode(',', $sets);

		$pick = array();
		foreach ($where as $key => $value) {
			$value = self::real_escape_string($value);
			$pick[] = "$key '$value'";
		}
		$pick_s = implode(" AND ", $pick);
		
		$query = "UPDATE $table SET $sets_s WHERE $pick_s";
		$result = self::query($query);
		
		if (!$result)
			die($this->error);

		return $this->affected_rows;
	}
	
	public function Delete($table, $where) {
		$pick = array();
		foreach ($where as $key => $value) {
				$value = self::real_escape_string($value);
				$pick[] = "$key '$value'";
			}
		$pick_s = implode(" AND ", $pick);

		$query = "DELETE FROM $table WHERE $pick_s";		
		$result = self::query($query);
					
		if (!$result)
			die($this->error);

		return $this->affected_rows;	
	}
}
