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
    <script src='jquery.js'></script>
</head>
<body>
<label>Name:</label>
<input type="text" id="name" name="name" required><br><br>
<label>Text:</label>
<textarea id="text" name="text" required></textarea><br><br>
<select id="combo">
    <option value="1">private</option>
    <option value="0">public</option>
</select>
<button type="button" id="addTemplateButton">Add Template</button>
<button type="submit" formmethod="get" formaction="index.jsp" id="redirect">Home</button>


<script>
    $("#addTemplateButton").click(function () {
        console.log($('#combo').val());
        $.post("AddTemplate", {
            'name': $("#name").val(),
            'text': $("#text").val(),
            'priv': $('#combo').val()
        },function (f) {
            $("#name").val("");
            $("#text").val("");
            window.location.href = "index.jsp";

        });

    });
</script>
</body>
</html>
