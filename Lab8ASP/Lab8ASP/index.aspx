﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Lab8ASP.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>UserName:</h4>
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <h4>Password:</h4>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <p>
           
             <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click"/>
           
        </p>
    </form>
</body>
</html>
