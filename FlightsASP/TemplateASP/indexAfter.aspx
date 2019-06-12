<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexAfter.aspx.cs" Inherits="TemplateASP.indexAfter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Most popular city for conferences is: </h2>
            <asp:PlaceHolder ID="confP" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
