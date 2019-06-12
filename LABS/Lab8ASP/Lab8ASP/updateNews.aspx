<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateNews.aspx.cs" Inherits="Lab8ASP.updateNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Enter the title and the new text for the news you want to update:</h2>
            <h4>Title:</h4>
            <asp:TextBox ID="title" runat="server"></asp:TextBox>
            <h4>Text:</h4>
            <asp:TextBox ID="text" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="updateNewsButton" runat="server" Text="Update news" OnClick="updateNewsButton_Click" />
        </p>
    </form>
</body>
</html>
