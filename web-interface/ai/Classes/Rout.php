<?php

class Rout
{

    public $controller;
    public $action;
    public $rout;

    public function __construct($r)
    {
            $this->rout = $r;
            $routParts = explode('/', $this->rout);
            if(2 === count($routParts))
            {
                $this->controller = $routParts[0];
                $this->action = $routParts[1];
            }else{
                $this->controller = 'admin';
                $this->action = 'sites';
            }

    }
}