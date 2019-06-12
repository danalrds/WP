<?php
require 'DBUtils.php';
if (isset($_POST['username'], $_POST['password'])) {
    $db = new DBUtils();
    $res = $db->selectUser($_POST['username'], $_POST['password']);
    if (sizeof($res) > 0) {
        session_start();
        $_SESSION['user']=$res[0]['username'];
        header('Location: /NewsService/index.php');
        exit(0);
    } else {
        header('Location: /NewsService/error.html');
        exit(0);
    }
}
