<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
    <script src="jquery.js"></script>
</head>
<body>
<% String username = (String) session.getAttribute("username"); %>
<% Integer level = (Integer) session.getAttribute("level"); %>
<%if (username == null) response.sendRedirect("/Login.jsp");%>
<h2>You are logged in <%= username%>
</h2>
<br>
<form method="post" action="Logout">
    <button type="submit">Logout</button>
</form>
<table id="games" border="1"></table>
<br>
<table id="questions" border="1"></table>
<button type="button" id="completeTest">Complete Test</button>
<br>
<button type="button" id="showTotal">Total points</button>
<div id="totalPoints"></div>

<button type="button" id="showCompleted">Completed tests</button>
<table id="completed" border="1"></table>

<script>
    showGames();
    function showGames() {
       console.log("showGames");
        $.post("ShowGames", {}, function (data) {
            $('#games').html(data);
            console.log(data);
        });
    }

    function play(game) {
        console.log("PLAY GAME");

        $.post("ShowQuestions", {"game":game}, function (data) {
            $('#questions').html(data);
            console.log(data);
        });
    }
    function addAnswer(){
        console.log("correct");
        $.post("TestHandle", {"points":1}, function(d){

        });
    }
    function addWrong(){
        console.log("wrong");
        $.post("TestHandle", {"points":-1}, function(d){

        });

    }
    $('#completeTest').click(function () {
            $.post("CompleteGame", {}, function (data) {
                console.log("success completed"+data);
               showGames();
            })
        }
    );


    $('#showTotal').click(function () {
            $.post("TotalPoints", {}, function (data) {
                $('#totalPoints').html(data);

            })
        }
    );
    $('#showCompleted').click(function () {
            $.post("Completed", {}, function (data) {
                $('#completed').html(data);

            })
        }
    );
</script>
</body>
</html>

