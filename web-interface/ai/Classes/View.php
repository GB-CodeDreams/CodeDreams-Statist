<?php

//include_once __DIR__ . '/Storage.php';

class View
    extends Storage
{
    public function display($template)
    {
        ob_start();
        foreach($this as $k => $v) {
            $$k = $v;
        }
        include __DIR__ . '/../view/' . $template;
        $rez = ob_get_contents();
        ob_clean();

        return $rez;
    }
}