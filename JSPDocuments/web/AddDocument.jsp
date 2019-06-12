<%--
  Created by IntelliJ IDEA.
  User: diago
  Date: 6/11/2019
  Time: 11:36 AM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<form method="post" action="AddDocument" !>
    <label>Title:</label>
    <input type="text" id="title" name="title" required><br><br>
    <label>List Of Templates:</label>
    <input type="text" id="templates" name="templates" required><br><br>
    <button type="submit" name="addDocument">Add Document</button>
</form>
</body>
</html>
