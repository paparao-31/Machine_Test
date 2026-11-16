
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ipd.aspx.cs" Inherits="Machine_Test.Ipd" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Insert Product Details</title>
</head>
<body>
<form id="form1" runat="server">

    <asp:HyperLink ID="hlMainMenu" runat="server"
        NavigateUrl="TestMenu.aspx" Text="Main Menu" />

    &nbsp;&nbsp;

    <asp:Label ID="lblWelcome" runat="server" Text="Hi " />

    &nbsp;&nbsp;

    <asp:Button ID="btnLogOut" runat="server"
        Text="LogOut" OnClick="btnLogOut_Click" />

    <hr />

    Customer Name:
    <asp:TextBox ID="txtCName" runat="server" MaxLength="50" />
    <br /><br />

    Product Name:
    <asp:TextBox ID="txtPName" runat="server" MaxLength="50" />
    <br /><br />

    Product Type:
    <asp:DropDownList ID="sbProductType" runat="server" />
    <br /><br />

    UOM:
    <asp:DropDownList ID="sbUom" runat="server" />
    <br /><br />

    Weight:
    <asp:TextBox ID="txtWeight" runat="server" />
    <br /><br />

    Manufacture Date:
    <asp:TextBox ID="txtMDate" runat="server" />
    <br /><br />

    Expiry Date:
    <asp:TextBox ID="txtEDate" runat="server" />
    <br /><br />

    Returnable:
    <asp:RadioButtonList ID="rblReturnable" runat="server">
        <asp:ListItem Text="Yes" Value="true" />
        <asp:ListItem Text="No" Value="false" />
    </asp:RadioButtonList>

    <br />

    Status:
    <asp:CheckBox ID="chkStatus" runat="server"
        Text="Active" Checked="true" />

    <br /><br />

    <asp:Label ID="lblMsg" runat="server"
        Visible="false" />

    <br />

    <asp:Button ID="btnInsert" runat="server"
        Text="Insert" OnClick="btnInsert_Click" />

</form>
</body>
</html>
