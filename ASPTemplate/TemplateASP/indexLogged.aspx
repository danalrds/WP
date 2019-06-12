<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexLogged.aspx.cs" Inherits="TemplateASP.indexLogged" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            You are Logged,  <%Response.Write(Session["username"]);%>
        </div>
    </form>
    <button type="button" id="showButton">Show Users</button>
    <table id="result" border="1"></table>
    

    <script>
        $('#showButton').click(function () {

            $.ajax({
                type: "POST",
                url: "indexLogged.aspx/selectUsers",
                data: {},
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    $("#result").html(result.d);
                    console.log(result);
                    
                }
            });

        });
    </script>


</body>
</html>
