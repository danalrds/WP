<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<% String username = (String) session.getAttribute("username"); %>
<%if (username==null)response.sendRedirect("/Login.jsp");%>
<h2>You are logged in <%= username%>
</h2>
<br>
<form method="post" action="Logout">
    <button type="submit">Logout</button>
</form>
</body>
</html>

