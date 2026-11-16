
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pl.aspx.cs" Inherits="Machine_Test.Pl" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Product List</title>
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

    <h2>Product List</h2>

    <asp:GridView ID="GridView1" runat="server"
        AutoGenerateColumns="false"
        DataKeyNames="Id"
        OnRowCommand="GridView1_RowCommand"
        OnRowDataBound="GridView1_RowDataBound">

        <Columns>

            <asp:BoundField DataField="CustomerName"
                HeaderText="Customer Name" />

            <asp:BoundField DataField="ProductName"
                HeaderText="Product Name" />

            <asp:BoundField DataField="ProductType"
                HeaderText="Product Type" />

            <asp:BoundField DataField="Uom"
                HeaderText="UOM" />

            <asp:BoundField DataField="Weight"
                HeaderText="Weight" />

            <asp:BoundField DataField="ManufactureDate"
                HeaderText="Mfg Date" DataFormatString="{0:dd/MM/yyyy}" />

            <asp:BoundField DataField="ExpiryDate"
                HeaderText="Expiry Date" DataFormatString="{0:dd/MM/yyyy}" />

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("Status")) ? "Active" : "Inactive" %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Expires In (Days)">
                <ItemTemplate>
                    <asp:Label ID="lblDays" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:ButtonField Text="Edit"
                CommandName="EditRow" />

        </Columns>

    </asp:GridView>

</form>
</body>
</html>
