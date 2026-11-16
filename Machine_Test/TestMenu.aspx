
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMenu.aspx.cs" Inherits="Machine_Test.TestMenu" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Test Menu</title>
</head>
<body>
<form id="form1" runat="server">

    <asp:Label ID="lblWelcome" runat="server" Text="Hi " />
    <br /><br />

    <asp:HyperLink ID="hlOwn" runat="server"
        NavigateUrl="Own.aspx"
        Text="Function Overloading and Object Method Calling" />
    <br /><br />

    <asp:HyperLink ID="hlIpd" runat="server"
        NavigateUrl="Ipd.aspx"
        Text="Insert Product Details" />
    <br /><br />

    <asp:HyperLink ID="hlPl" runat="server"
        NavigateUrl="Pl.aspx"
        Text="Product List" />
    <br /><br />

    <asp:Button ID="btnLogout" runat="server"
        Text="LogOut" OnClick="btnLogout_Click" />

</form>
</body>
</html>
