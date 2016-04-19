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
        $num = $this->db->DBQueryExecut("INSERT INTO sites (name) VALUE ('$name')");
        return $num;
    }

    public function Pages_setOne($url, $site_id)
    {
        $this->db->DBQueryExecut("INSERT INTO pages (url, site_id) VALUE  ('$url', '$site_id')");
    }

    public function Sites_deleteOne($id)
    {
        $this->db->DBQueryExecut("DELETE FROM sites WHERE id = " . $id);
    }
}
