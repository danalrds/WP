<?php
session_start();
require 'DBUtils.php';
$db = new DBUtils();
$result = $db->selectNews();
echo "<script src='jquery.js'></script>";
echo "<table id='theTable' border='1'><tr><th>Title</th><th>Text</th><th>Producer</th><th>Date</th><th>Category</th></tr>";
for ($i = 0; $i < sizeof($result); $i++) {
    $row = $result[$i];
    $cat = $db->getNameOfCategory($row['cid'])[0]['cname'];
    $username = $db->getNameOfUser($row['producer'])[0]['username'];
    echo "<tr>";
    echo "<td>" . $row['title'] . "</td>";
    echo "<td>" . $row['text'] . "</td>";
    echo "<td>" . $username . "</td>";
    echo "<td>" . $row['date'] . "</td>";
    echo "<td>" . $cat . "</td>";
    echo "</tr>";
}
echo "</table>";
echo "<br>";
echo "<div>
<select id='selectedFilterCategory'>
        <option value='all'>all</option>
        <option value='politics'>politics</option>
        <option value='society'>society</option>
        <option value='health'>health</option>
    </select>
    <label>StartDate: </label>
    <input type='text' id='selectedStartDate' name='startDate'/>
    <label>EndDate: </label>
    <input type='text' id='selectedEndDate' name='endDate'/>
    <button id='filterButton' type='button'>Filter</button>
    </div>";
echo "<script>
$('#filterButton').click(function(){
    $.get('Filter.php', {'category': $('#selectedFilterCategory :selected').text(),
                        'startDate':$('#selectedStartDate').val(),
                        'endDate':$('#selectedEndDate').val()},
                         function (data) {
    $('#theTable').html(data);
    });
});
</script>";

if (isset ($_SESSION['user'])) {

    echo "<form action='addNews.html' method='post'><br><br><br><button type='submit' >Add</button></form>";
    echo "<form action='updateNews.html' method='post'><br><button type='submit' >Update</button></form>";
    echo "<form action='Logout.php' method='post'><br><button type='submit' >Logout</button></form>";
} else {
    echo "<form action='login.html' method='post'><br><br><br><button type='submit' >Login</button></form>";
}
?>