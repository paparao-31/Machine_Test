
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Own.aspx.cs" Inherits="Machine_Test.Own" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Shape Volume</title>
</head>
<body>
<form id="form1" runat="server">

    <asp:HyperLink ID="hlMainMenu" runat="server"
        NavigateUrl="TestMenu.aspx" Text="Main Menu" />

    &nbsp;&nbsp;

    <asp:Label ID="lblWelcome" runat="server" Text="Hi " />

    &nbsp;&nbsp;

    <asp:Button ID="btnLogout" runat="server"
        Text="LogOut" OnClick="btnLogout_Click" />

    <hr />

    Shape:
    <asp:DropDownList ID="ddlShape" runat="server"
        AutoPostBack="true"
        OnSelectedIndexChanged="ddlShape_SelectedIndexChanged">

        <asp:ListItem Text="--Select--" Value="0" />
        <asp:ListItem Text="Rectangle" Value="1" />
        <asp:ListItem Text="Cylinder" Value="2" />

    </asp:DropDownList>

    <br /><br />

    <asp:Panel ID="pnlRectangle" runat="server" Visible="false">

        <h3>Rectangle</h3>

        Length:
        <asp:TextBox ID="txtLength" runat="server" />
        <br /><br />

        Width:
        <asp:TextBox ID="txtWidth" runat="server" />
        <br /><br />

        Height:
        <asp:TextBox ID="txtHeight" runat="server" />
        <br /><br />

        Volume:
        <asp:TextBox ID="txtRectVolume" runat="server" ReadOnly="true" />
        <br /><br />

        <asp:Button ID="btnRectangleVolume" runat="server"
            Text="Calculate Volume"
            OnClick="btnRectangleVolume_Click" />

    </asp:Panel>

    <br />

    <asp:Panel ID="pnlCylinder" runat="server" Visible="false">

        <h3>Cylinder</h3>

        Diameter:
        <asp:TextBox ID="txtDiameter" runat="server" />
        <br /><br />

        Height:
        <asp:TextBox ID="txtCHeight" runat="server" />
        <br /><br />

        Volume:
        <asp:TextBox ID="txtCVolume" runat="server" ReadOnly="true" />
        <br /><br />

        <asp:Button ID="btnCylinderVolume" runat="server"
            Text="Calculate Volume"
            OnClick="btnCylinderVolume_Click" />

    </asp:Panel>

    <br />

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

</form>
</body>
</html>
