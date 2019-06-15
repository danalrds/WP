<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexRegistered.aspx.cs" Inherits="TemplateASP.indexRegistered" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            You are registered,   <%Response.Write(Session["username"]);%>
        </div>
    </form>
    <br />
    <label>Keywords</label>
    <br />
    <textarea id="keys"></textarea>
    <br />
    <button type="button" id="searchButton">Search</button>
    <br />
    <table id="result" border="1"></table>

    <br />
    <table id="chunksTable" border="1"></table>
    <br />
    <button type="button" id="next">Next</button>

    <br />
    <table id="res" border="1"></table>

    <br />
    <table id="peers" border="1"></table>

    <br />
    <table id="blackList" border="1"></table>

    <script>
        showBlackList();
        showPeers();
        function showPeers() {
            $.ajax({
                type: "POST",
                url: "indexRegistered.aspx/showPeers",
                data: {},
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    console.log(result.d);
                    $('#peers').html(result.d);

                }
            });
        }

        function showBlackList() {
            $.ajax({
                type: "POST",
                url: "indexRegistered.aspx/selectBlackList",
                data: {},
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    console.log(result.d);
                    $('#blackList').html(result.d);

                }
            });
        }


        $('#searchButton').click(function () {

            $.ajax({
                type: "POST",
                url: "indexRegistered.aspx/searchFiles",
                data: JSON.stringify({ "keywords": $('#keys').val() }),
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


        function showChunks(fileId) {
            console.log(fileId);
            $.ajax({
                type: "POST",
                url: "indexRegistered.aspx/showAllChunks",
                data: JSON.stringify({ "fileId": fileId }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    console.log(result.d);
                    $('#chunksTable').html(result.d);

                }
            });
        }

        function addPeer(chunkId, peerName) {
            console.log("chunkId", chunkId, "peerName", peerName);
            $.ajax({
                type: "POST",
                url: "indexRegistered.aspx/addPeerChunks",
                data: JSON.stringify({ "chunkId": chunkId, "peerName": peerName }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {

                }
            });
        }

        function addPeerBlack(peerName) {
            console.log("ADDD peerName", peerName);
            $.ajax({
                type: "POST",
                url: "indexRegistered.aspx/addPeerBlackList",
                data: JSON.stringify({ "peerName": peerName }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    showBlackList();
                }
            });

        }

         function removePeerBlack(peerName) {
            console.log("REMOVE peerName", peerName);
            $.ajax({
                type: "POST",
                url: "indexRegistered.aspx/removePeerBlackList",
                data: JSON.stringify({ "peerName": peerName }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    showBlackList();
                }
            });

        }


        $('#next').click(function () {

            $.ajax({
                type: "POST",
                url: "indexRegistered.aspx/nextShow",
                data: {},
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    $('#res').html(result.d);
                    console.log(result.d);

                }
            });

        });
    </script>
</body>
</html>
