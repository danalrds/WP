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

        <div>
            <asp:PlaceHolder ID="urlsTable" runat="server"></asp:PlaceHolder>
        </div>

    </form>
    <button type="button" id="showUrls">Show All Urls</button>
    <table id="result" border="1"></table>
    <br/>
    <button type="button" id="showLiked">Show Liked</button>
    <table id="likedUrls" border="1"></table>

    <input type="text" id="selectedUserId"/>
     <table id="sharedUrls" border="1"></table>

    <script>
        $('#showUrls').click(function () {
  
            $.ajax({                
                type: "POST",
                url: "indexLogged.aspx/selectAllUrls",
                data: JSON.stringify({username:<%Response.Write("'"+Session["username"]+"'");%>}),
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
        function addLike(username, owner, url) {
            console.log(username, owner, url);
            $.ajax({                
                type: "POST",
                url: "indexLogged.aspx/addLike",
                data: JSON.stringify({"username": username, "owner":owner, "url":url}),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    console.log(result.d);
                    if (result.d == "no") {
                        alert('You already liked this url!');
                    }

                }
            });
        }

        function addShare(username, urlId) {
            console.log(username, urlId);
            $.ajax({                
                type: "POST",
                url: "indexLogged.aspx/addShare",
                data: JSON.stringify({ "username": username, "urlId": urlId}),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {

                }
            });
        }

        $('#showLiked').click(function () {
  
            $.ajax({                
                type: "POST",
                url: "indexLogged.aspx/selectLiked",
                data: JSON.stringify({username:<%Response.Write("'"+Session["username"]+"'");%>}),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    $("#likedUrls").html(result.d);
                    console.log(result);

                }
            });

        });

        $('#selectedUserId').change(function(){
             $.ajax({                
                type: "POST",
                url: "indexLogged.aspx/sharedUrls",
                data: JSON.stringify({"userId":$('#selectedUserId').val()}),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    $("#sharedUrls").html(result.d);
                    console.log(result);

                }
            });
        })
    </script>


</body>
</html>
