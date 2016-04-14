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

    public function Persons_setOne($name)
    {
        $this->db->DBQueryExecut("INSERT INTO persons (name) VALUE ('$name')");
    }

    public function Persons_deleteOne($id)
    {
        $this->db->DBQueryExecut("DELETE FROM persons WHERE id = " . $id);
    }
}
