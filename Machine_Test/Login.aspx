
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Machine_Test.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login Page</title>
</head>
<body>
<form id="form1" runat="server">

    <h2>Welcome to Login Page</h2>

    <asp:Label ID="lblUserName" runat="server" Text="User Name" />
    <asp:TextBox ID="txtUserName" runat="server" />
    <br /><br />

    <asp:Label ID="lblPassword" runat="server" Text="Password" />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
    <br /><br />

    <asp:Label ID="lblMsg" runat="server"
        Visible="false" ForeColor="Red" />
    <br />

    <asp:Button ID="btnSignIn" runat="server"
        Text="Sign In" OnClick="btnSignIn_Click" />

</form>
</body>
</html>
