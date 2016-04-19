<?php

class Sites
{

    private static $instance;
    private $msql;

    private function __construct() {
        $this->msql = DBWork::Instance();
    }

    public static function Instance() {
        if (self::$instance == null)
            self::$instance = new Sites();

        return self::$instance;
    }

    public function Sites_getAll()
    {
        return DBWork::Instance()->DBQuery("SELECT * FROM sites");
    }

    public function Sites_setOne($name)
    {
        $num = DBWork::Instance()->DBQueryExecut("INSERT INTO sites (name) VALUE ('$name')");
        return $num;
    }

    public function Pages_setOne($url, $site_id)
    {
        DBWork::Instance()->DBQueryExecut("INSERT INTO pages (url, site_id) VALUE  ('$url', '$site_id')");
    }

    public function Sites_deleteOne($id)
    {
        DBWork::Instance()->DBQueryExecut("DELETE FROM sites WHERE id = " . $id);
    }
}
