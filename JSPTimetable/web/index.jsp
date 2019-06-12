<%--
  Created by IntelliJ IDEA.
  User: diago
  Date: 4/23/2019
  Time: 4:30 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>$Title$</title>
    <script src='jquery.js'></script>
</head>
<body>
<h2>Hello, everybody!</h2>
<form action='AddCourse.jsp' method='post'>
    <button type='submit'>Add course</button>
</form>
<form action='AddRestriction.jsp' method='post'>
    <button type='submit'>Add restriction</button>
</form>
<button type="button" id="showButton">Show Timetable</button>
<br>
<select id="combo">
</select>
<select id="days">
    <option value="Monday">Monday</option>
    <option value="Tuesday">Tuesday</option>
    <option value="Wednesday">Wednesday</option>
    <option value="Thursday">Thursday</option>
    <option value="Friday">Friday</option>
</select>
<label>Start Hour:</label>
<input type="text" id="startHour">
<br>
<table id="result" border="1"></table>
<table id="timetable" border="1"></table>
<script>
    $.post("FillCourses", {}, function (data) {
        $('#combo').html(data);
    });


    $('#startHour').change(function () {
        renderAgain();
    });
    $('#combo').change(function () {
        renderAgain();
    });
    $('#days').change(function () {
        renderAgain();
    });

    function renderAgain() {
        console.log("IT HAS ENTERED FUNCTION!");
        $.post("SelectPossibilities", {
                'course': $('#combo').val(),
                'day': $('#days').val(),
                'startHour': $('#startHour').val()
            },
            function (data) {
                $('#result').html("<tr><th>Room Name</th></tr>" + data);

            });
    }

    function addInTimetable(courseId, roomId) {
        $.post("AddInTimetable", {
                'courseId': courseId,
                'roomId': roomId,
                'day': $('#days').val(),
                'startHour': $('#startHour').val()
            }, function () {
                window.location.href = "index.jsp";
            }
        )
    }

    $('#showButton').click(function () {
            $.post("ShowTimeTable", {}, function (data) {
                $('#timetable').html(data);

            })
        }
    );


</script>
</body>
</html>
