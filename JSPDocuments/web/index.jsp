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
<form action='AddKeyword.jsp' method='post'>
    <button type='submit'>Add keyword</button>
</form>
<form action='AddTemplate.jsp' method='post'>
    <button type='submit'>Add template</button>
</form>

<form action='AddDocument.jsp' method='post'>
    <button type='submit'>Add document</button>
</form>
<input type="text" id="word">
<button type="button" id="searchButton">Search</button>
<table id="result" border="1">

</table>
<div id="content"></div>

<script>
    $("#searchButton").click(function () {
        $.post('SearchDocument', {'word': $('#word').val()}, function (data) {
            $("#result").html(' <tr>\n' +
                '        <th>Name</th>\n' +
                '        <th>List Of Templates</th>\n' +
                '    </tr>' + data);
        });

    });

    function generate(id) {
        console.log("id" + id);
        $.post("GenerateDocument", {'id': id}, function (data) {
            $('#content').html(data);
        })
    }
</script>
</body>
</html>
