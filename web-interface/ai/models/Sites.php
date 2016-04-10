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

    public function Sites_setOne($name)
    {
        $this->db->DBQueryExecut("INSERT INTO sites (name) VALUE ('$name')");
    }

    public function Sites_deleteOne($id)
    {
        $this->db->DBQueryExecut("DELETE FROM sites WHERE id = " . $id);
    }
}
