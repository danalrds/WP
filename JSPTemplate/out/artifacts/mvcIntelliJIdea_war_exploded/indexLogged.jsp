<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
    <script src="jquery.js"></script>
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
<br>
<table id="contents" border="1"></table>
<br>
<label>To Delete</label>
<input type="text" id="toDelete">
<button id="deleteButton" type="button">Delete</button>
<br>
<br>
<button id='addButton' type='button' onclick="addAll()">Add News</button>
<div id='addNewsForms'>
    <form id='addForm' action='AddContent' method='post'>
        <label>Title: </label>
        <input type='text' id='titleId0' name='title'/><br><br>
        <label>Description: </label>
        <textarea id='descriptionId0' name='description'></textarea><br><br>
        <label>Url: </label>
        <textarea id='urlId0' name='url'></textarea><br><br>

    </form>
    <button type="button" onclick="AddForm()">Add more</button>

</div>

<script>
    var currentFormIndex = 1;

    function AddForm() {
        var newForm =
            "        <label>Title: </label>\n" +
            "        <input type='text' id='titleId" + currentFormIndex + "' name='title'/><br><br>\n" +
            "        <label>Description: </label>\n" +
            "        <textarea id='descriptionId" + currentFormIndex + "' name='description'></textarea><br><br>\n"+
            "        <label>Url: </label>\n" +
            "        <textarea id='urlId" + currentFormIndex + "' name='url'></textarea><br><br>\n";
        $('#addForm').html($('#addForm').html() + newForm);
        currentFormIndex += 1;
    }

    function addAll() {
        var data = "";
        for (var i = 0; i < currentFormIndex; i++) {
            data += $('#titleId' + i).val() + ',' + $('#descriptionId' + i).val() + ',' + $('#urlId' + i).val() + ';';
        }
        console.log(data);
        $.post("AddContent", {'data': data}, function (d) {
            console.log('returned'+d);
            showContents();
        });

    }

    showContents();
    function showContents() {
        console.log("ShowContents");
        $.post("ShowContents", {}, function (data) {
            $('#contents').html(data);
            console.log(data);
        });
    }

    $('#deleteButton').click(function () {
            $.post("DeleteContent", {"title":$('#toDelete').val()}, function (data) {
                console.log("deleted");
                showContents();
            })
        }
    );
</script>



</body>
</html>

