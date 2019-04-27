<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNews.aspx.cs" Inherits="Lab8ASP.addNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Title:</h4>
            <asp:TextBox ID="title" runat="server"></asp:TextBox>
            <h4>Text:</h4>
            <asp:TextBox ID="text" runat="server"></asp:TextBox>
            <br/><br/>
            <asp:DropDownList runat="server" ID="dropDownList">
                <asp:ListItem Text="politics" Value="politics"></asp:ListItem>
                <asp:ListItem Text="society" Value="society"></asp:ListItem>
                <asp:ListItem Text="health" Value="health"></asp:ListItem>
            </asp:DropDownList>
            <br/><br/>
             <asp:Button ID="addNewsButton" runat="server" Text="Add news" OnClick="addNewsButton_Click"/>
        </div>
    </form>
</body>
</html>
