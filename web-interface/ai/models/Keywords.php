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

    public function Persons_getOne($id)
    {
        return $this->db->DBQueryOne("SELECT *  FROM persons WHERE id =" . $id);
    }

    public function Keywords_getAll($person_id = null)
    {
        return $this->db->DBQuery("SELECT * FROM keywords WHERE person_id = " .$person_id);
    }

    public function Keywords_setOne($name, $name_2, $distance, $person_id)
    {
        $this->db->DBQueryExecut("INSERT INTO keywords (name, name_2, distance, person_id) 
                                  VALUE ('$name', '$name_2', '$distance', '$person_id')");
    }

    public function Keywords_deleteOne($id)
    {
        $this->db->DBQueryExecut("DELETE FROM keywords WHERE id = " . $id);
    }
}
