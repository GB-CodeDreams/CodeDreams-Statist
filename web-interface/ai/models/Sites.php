<?php

class Sites
{
    private $db;

    public function __construct()
    {
        $this->db = new DBWork();
    }

    public function Sites_getAll()
    {
        return $this->db->DBQuery("SELECT * FROM sites");
    }

    public function Sites_setOne($Name)
    {
        $this->db->DBQueryExecut("INSERT INTO sites (Name) VALUE ('$Name')");
    }

    public function Sites_deleteOne($ID)
    {
        $this->db->DBQueryExecut("DELETE FROM sites WHERE ID = " . $ID);
    }
}
