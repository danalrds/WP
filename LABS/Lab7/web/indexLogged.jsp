<%@ page import="sun.security.pkcs11.Secmod" %>
<%@ page import="utils.DBUtil" %>
<%@ page import="utils.Photo" %>
<%@ page import="java.util.List" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<h2>You are logged in</h2>
<form method='post' action='AddPhoto.jsp'>
    <button type='submit' name="addPhoto">Add Photo</button>
</form>
<form method='post' action='top.jsp'>
    <input type="text" name="topNumber" required>
    <button type='submit' name="top">Top</button>
</form>

<%
    DBUtil db = new DBUtil();
    List<Photo> photos = db.findPhotos();
    for (Photo p : photos) { %>
<tr>
    <img src="<%out.println(p.getPath());%>" height="320" width="420">

    <h4><%
        out.print("Nr votes: "+p.getVotes());
    %></h4>
    <h4><%
        out.print("Posted by: "+p.getUser());
    %></h4>
    <form method='post' action='Vote'>
        <button type='submit' name="vote">Vote</button>
        <input type="hidden" name="photoPath" value="<%=p.getPath()%>"/>
        <input type="hidden" name="currentUser" value="<%=session.getAttribute("currentUser")%>"/>
    </form>
</tr>
<% } %>
</body>
</html>

