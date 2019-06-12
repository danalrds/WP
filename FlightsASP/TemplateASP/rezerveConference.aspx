<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rezerveConference.aspx.cs" Inherits="TemplateASP.rezerveConference" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.js"></script>
</head>
<body>
    <table id="result" border="1"></table>
    <button type="button" onclick="Redirect()">Next Step</button>

    <script>
        $.ajax({
            type: "POST",
            url: "rezerveConference.aspx/showConferences",
            data: JSON.stringify({
                "username":<%Response.Write("'" + Session["username"] + "'");%>,
                "date":<%Response.Write("'" + Session["date"] + "'");%>,
                "city":<%Response.Write("'" + Session["city"] + "'");%>
            }),
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

         function rezerveConference(username, confName) {
            console.log(username, confName);
            $.ajax({
                type: "POST",
                url: "rezerveConference.aspx/addRezConf",
                data: JSON.stringify({ "username": username, "confName": confName }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {

                

                }
            });
        }
        function Redirect() {
            window.location.href = "indexAfter.aspx";
        }
    </script>
</body>
</html>
