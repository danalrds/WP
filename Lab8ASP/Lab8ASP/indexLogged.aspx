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
        </div>
         <p>
           
             <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click"/>
           
        </p>
    </form>
</body>
</html>
