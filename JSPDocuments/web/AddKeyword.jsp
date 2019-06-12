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
<form method="post" action="AddKeyword" !>
    <label>Key:</label>
    <input type="text" id="key" name="key" required><br><br>
    <label>Value:</label>
    <input type="text" id="value" name="value" required><br><br>
    <button type="submit" name="addKeyword">Add Keyword</button>
</form>
</body>
</html>
