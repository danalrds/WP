<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexLogged.aspx.cs" Inherits="Lab8ASP.indexlogged" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:DropDownList runat="server" ID="dropDownListIndex">
            <asp:ListItem Text="all" Value="all"></asp:ListItem>
            <asp:ListItem Text="politics" Value="politics"></asp:ListItem>
            <asp:ListItem Text="society" Value="society"></asp:ListItem>
            <asp:ListItem Text="health" Value="health"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="startDate" runat="server"></asp:TextBox>
        <asp:TextBox ID="endDate" runat="server"></asp:TextBox>
        <asp:Button ID="filterButton" runat="server" Text="Filter" OnClick="filterButton_Click" />
        <br />
        <br />
        <div>
            <asp:PlaceHolder ID="placeHolder1" runat="server"></asp:PlaceHolder>
        </div>
        <p>
            <asp:Button ID="addButton" runat="server" Text="Add news" OnClick="addButton_Click" />
        </p>
        <p>
            <asp:Button ID="updateButton" runat="server" Text="Update news" OnClick="updateButton_Click" />
        </p>

        <p>
            <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
        </p>

    </form>
</body>
</html>
