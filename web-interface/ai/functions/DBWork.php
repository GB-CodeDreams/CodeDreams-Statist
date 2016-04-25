<?php

class DBWork {

    public function config(){
        return include __DIR__ . '/../config.php';
    }

    private static $instance;

    public static function Instance() {
        if (self::$instance == null)
            self::$instance = new DBWork();
        return self::$instance;
    }

    public function __construct () {
        $config = $this->config();

        global $link;
        // Настройки подключения к БД.
        $hostname = $config['hostname'];
        $username = $config['username'];
        $password = $config['password'];
        $dbname = $config['dbname'];

        // Подключение к БД.
        $link = mysqli_connect($hostname, $username, $password, $dbname) or die('No connect with data base');
        mysqli_query($link, 'SET NAMES utf8');
        header('Content-type: text/html; charset=utf-8');
    }

    public function DBQuery($sql)
    {
        global $link;
        $result = mysqli_query($link, $sql);

        if (!$result)
            die(mysqli_error($link));

        // Извлечение из БД.
        $n = mysqli_num_rows($result);
        $articles = array();

        for ($i = 0; $i < $n; $i++)
        {
            $row = mysqli_fetch_assoc($result);
            $articles[] = $row;
        }
        return $articles;
    }

    public function DBQueryOne($sql)
    {
        $rezult = $this->DBQuery($sql);
        return $rezult[0];
    }

       public function DBQueryExecut($sql)
    {
        global $link;
        $result = mysqli_query($link, $sql);
        $rez = mysqli_affected_rows($link);
        $num = mysqli_insert_id($link);
        if($rez === 1)
            return $num;
        else
            return false;
    }
}
