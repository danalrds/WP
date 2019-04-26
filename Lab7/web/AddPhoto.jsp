<%--
  Created by IntelliJ IDEA.
  User: diago
  Date: 4/26/2019
  Time: 9:21 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<form method="post" action="addPhoto">
    <h4>Path:</h4>
    <input type="text" name="path">
    <input type="hidden" name="username" value="<%=session.getAttribute("currentUser")%>"/>
    <button type="submit" name="add">Upload</button>
</form>
</body>
</html>
