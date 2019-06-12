<?php
$category = null;
$startDate = null;
$endDate = null;
if (isset($_GET['category'])) {
    $category = $_GET['category'];
    if ($category == 'all') {
        $category = null;
    }
}
if (isset($_GET['startDate'])) {
    $startDate = $_GET['startDate'];
}
if (isset($_GET['endDate'])) {
    $endDate = $_GET['endDate'];
}

require_once 'DBUtils.php';
$db = new DBUtils();
$result = $db->getFilteredNews($category, $startDate, $endDate);

for ($i = 0; $i < sizeof($result); $i++) {
    $row = $result[$i];
    $username = $db->getNameOfUser($row['producer'])[0]['username'];
    echo "<tr>";
    echo "<td>" . $row['title'] . "</td>";
    echo "<td>" . $row['text'] . "</td>";
    echo "<td>" . $username . "</td>";
    echo "<td>" . $row['date'] . "</td>";
    echo "<td>" . $row['cname'] . "</td>";
    echo "</tr>";
}

?>
