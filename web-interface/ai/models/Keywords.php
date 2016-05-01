<?php

class Keywords
{
    private static $instance;
    private $msql;

    private function __construct() {
        $this->msql = DBWork::Instance();
    }

    public static function Instance() {
        if (self::$instance == null)
            self::$instance = new Keywords();

        return self::$instance;
    }

    public function Persons_getAll()
    {
        return DBWork::Instance()->DBQuery("SELECT * FROM persons");
    }

    public function Persons_getOne($id)
    {
        return DBWork::Instance()->DBQueryOne("SELECT *  FROM persons WHERE id =" . $id);
    }

    public function Keywords_getAll($person_id = null)
    {
        return DBWork::Instance()->DBQuery("SELECT * FROM keywords WHERE person_id = " .$person_id);
    }

    public function Keywords_setOne($name, $name_2, $distance, $person_id)
    {
        DBWork::Instance()->DBQueryExecut("INSERT INTO keywords (name, name_2, distance, person_id) 
                                  VALUE ('$name', '$name_2', '$distance', '$person_id')");
    }

    public function Keywords_deleteOne($id)
    {
        DBWork::Instance()->DBQueryExecut("DELETE FROM keywords WHERE id = " . $id);
    }
}
