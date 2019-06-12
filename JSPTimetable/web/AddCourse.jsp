<%--
  Created by IntelliJ IDEA.
  User: diago
  Date: 6/11/2019
  Time: 11:09 AM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<form method="post" action="AddCourse" !>
    <label>Name:</label>
    <input type="text" id="name" name="name" required><br><br>
    <label>Teacher:</label>
    <input type="text" id="teacher" name="teacher" required><br><br>
    <label>Duration:</label>
    <input type="text" id="duration" name="duration" required><br><br>
    <button type="submit" name="addCourse">Add</button>
</form>
</body>
</html>

