<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rezerveHotel.aspx.cs" Inherits="TemplateASP.rezerveHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.js"></script>
</head>
<body>
    <button type="button" id="showHotelsButton">Rezerve</button>
    <br />
    <table id="resultHotels" border="1"></table>
    <button type="button" onclick="Redirect()">Next Step</button>

    <script>
        $('#showHotelsButton').click(function () {
            $.ajax({
                type: "POST",
                url: "rezerveHotel.aspx/showHotels",
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
                    $("#resultHotels").html(result.d);
                    console.log(result.d);

                }
            });
        })

        
        function rezerveHotel(username, hotelName) {
            console.log(username, hotelName);
            $.ajax({
                type: "POST",
                url: "rezerveHotel.aspx/addRezervation",
                data: JSON.stringify({ "username": username, "hotelName": hotelName }),
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
            window.location.href = "rezerveConference.aspx";
        }

    </script>
</body>
</html>
