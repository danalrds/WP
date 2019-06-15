<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rezerveFlight.aspx.cs" Inherits="TemplateASP.rezerveFlight" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.js"></script>
</head>
<body>
    <label>Departure</label>
    <input type="text" id="departure" />
    <br />
    <label>Destination</label>
    <input type="text" id="destination" />
    <br />
    <label>Date</label>
    <input type="text" id="date" />
    <button type="button" id="showButton">Rezerve</button>
    <br />
    <table id="result" border="1"></table>
    <button type="button" onclick="Redirect()">Next Step</button>
    <script>
        $('#showButton').click(function () {
            $.ajax({
                type: "POST",
                url: "rezerveFlight.aspx/showFlights",
                data: JSON.stringify({ "username":<%Response.Write("'" + Session["username"] + "'");%>, "departure": $('#departure').val(), "destination": $('#destination').val(), "date": $('#date').val() }),
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
        })

        function rezerveFlight(username, flightName) {
            console.log(username, flightName);
            $.ajax({
                type: "POST",
                url: "rezerveFlight.aspx/addRezervation",
                data: JSON.stringify({ "username": username, "flightName": flightName }),
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
            window.location.href = "rezerveHotel.aspx";
        }
    </script>

</body>
</html>
