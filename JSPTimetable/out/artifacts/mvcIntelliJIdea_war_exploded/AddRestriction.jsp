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
<form method="post" action="AddRestriction" !>
    <label>Course:</label>
    <input type="text" id="name" name="name" required><br><br>
    <label>Restrictions:</label>
    <input type="text" id="restrictions" name="restrictions" required><br><br>

    <button type="submit" name="addRestriction">Add</button>
</form>
</body>
</html>

