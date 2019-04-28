<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexLogged.aspx.cs" Inherits="Lab8ASP.indexlogged" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>You are logged in</h1>
            <asp:PlaceHolder ID="placeHolder1" runat="server"></asp:PlaceHolder>
        </div>
         <p>           
             <asp:Button ID="addButton" runat="server" Text="Add news" OnClick="addButton_Click"/>           
        </p>
        <p>           
             <asp:Button ID="updateButton" runat="server" Text="Update news" OnClick="updateButton_Click"/>           
        </p>
         <p>           
             <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click"/>           
        </p>
        
    </form>
</body>
</html>
