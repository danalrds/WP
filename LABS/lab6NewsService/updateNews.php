<?php
require 'DBUtils.php';
session_start();
if (isset ($_SESSION['user'])) {
    if (isset($_POST['title'], $_POST['text'])) {
        $db = new DBUtils();
        $title = $_POST['title'];
        $text = $_POST['text'];
        $username = $_SESSION['user'];
        $theProducer=$db->getProducerFromTitle($title);
        if ($theProducer[0]['username']=$username) {
            $date = date("Y-m-d H:i:s");
            $producer = $db->getIdOfUser($username)[0]['id'];
            $cid = $db->getCategoryFromNews($title, $producer)[0]['cid'];
            $res = $db->updateNews($title, $text, $producer, $date, $cid);
            header('Location: /NewsService/index.php');
            exit(0);
        }
        else
        {
            header("Refresh:200 index.php");
            exit(0);
        }
    }
} else {
    header('Location: /NewsService/error.html');
    exit(0);
}
?>
