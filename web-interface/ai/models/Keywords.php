<?php

class Keywords
{
    private $db;

    public function __construct()
    {
        $this->db = new DBWork();
    }

    public function Persons_getAll()
    {
        return $this->db->DBQuery("SELECT * FROM persons");
    }

    public function Keywords_getAll($PresonID = null)
    {
        return $this->db->DBQuery("SELECT * FROM keywords");
    }

    public function Keywords_setOne($Name)
    {
        $this->db->DBQueryExecut("INSERT INTO keywords (Name) VALUE ('$Name')");
    }

    public function Keywords_deleteOne($ID)
    {
        $this->db->DBQueryExecut("DELETE FROM keywords WHERE ID = " . $ID);
    }
}
