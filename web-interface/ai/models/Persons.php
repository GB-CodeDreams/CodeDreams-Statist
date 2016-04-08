<?php

class Persons
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

    public function Persons_setOne($Name)
    {
        $this->db->DBQueryExecut("INSERT INTO persons (Name) VALUE ('$Name')");
    }

    public function Persons_deleteOne($ID)
    {
        $this->db->DBQueryExecut("DELETE FROM persons WHERE ID = " . $ID);
    }
}
