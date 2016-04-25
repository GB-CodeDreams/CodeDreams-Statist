<?php

class Persons
{
    private static $instance;
    private $msql;

    private function __construct() {
        $this->msql = DBWork::Instance();
    }

    public static function Instance() {
        if (self::$instance == null)
            self::$instance = new Persons();

        return self::$instance;
    }
    
    public function Persons_getAll()
    {
        return DBWork::Instance()->DBQuery("SELECT * FROM persons");
    }

    public function Persons_setOne($name)
    {
        DBWork::Instance()->DBQueryExecut("INSERT INTO persons (name) VALUE ('$name')");
    }

    public function Persons_deleteOne($id)
    {
        DBWork::Instance()->DBQueryExecut("DELETE FROM persons WHERE id = " . $id);
    }
}
