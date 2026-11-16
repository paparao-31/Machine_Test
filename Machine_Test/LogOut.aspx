
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="Machine_Test.LogOut" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Logout</title>
</head>
<body>
<form id="form1" runat="server">

    <h2>
        <asp:Label ID="lblLogout" runat="server"
            Text="You are successfully logout." />
    </h2>

    <asp:HyperLink ID="hlLogin" runat="server"
        NavigateUrl="Login.aspx" Text="Login" />

</form>
</body>
</html>
