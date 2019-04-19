<?php
require 'DBUtils.php';
session_start();
if (isset ($_SESSION['user'])) {
    if (isset($_POST['title'], $_POST['text'])) {
        $db = new DBUtils();
        $title = $_POST['title'];
        $text = $_POST['text'];
        $username = $_SESSION['user'];
        $date = date("Y-m-d H:i:s");
        $producer = $db->getIdOfUser($username)[0]['id'];
        $category = $_POST['selectedCategory'];
        $cid=$db->getIdOfCategory($category)[0]['id'];
        $res = $db->addNews($title, $text, $producer, $date, $cid);
        header('Location: /NewsService/index.php');
        exit(0);
    }
} else {
    header('Location: /NewsService/error.html');
    exit(0);
}
?>
