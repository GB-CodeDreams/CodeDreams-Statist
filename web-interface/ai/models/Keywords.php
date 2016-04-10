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

    public function Persons_getOne($ID)
    {
        return $this->db->DBQueryOne("SELECT *  FROM persons WHERE id =" . $ID);
    }

    public function Keywords_getAll($PresonID = null)
    {
        return $this->db->DBQuery("SELECT * FROM keywords WHERE PersonID = " .$PresonID);
    }

    public function Keywords_setOne($Name, $PersonID)
    {
        $this->db->DBQueryExecut("INSERT INTO keywords (Name, PersonID) VALUE ('$Name', '$PersonID')");
    }

    public function Keywords_deleteOne($ID)
    {
        $this->db->DBQueryExecut("DELETE FROM keywords WHERE ID = " . $ID);
    }
}
