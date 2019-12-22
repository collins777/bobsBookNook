<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkOut.aspx.cs" Inherits="checkOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" Text="Please enter the email address for delivery of your books."></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="True"></asp:TextBox>
            <br />
            <asp:Button ID="btnReturn" runat="server" Enabled="False" OnClick="btnReturn_Click" Text="Return to Book Store" />

            <asp:GridView ID="gvISBN" runat="server" Visible="False">
            </asp:GridView>
            <br />
            <asp:GridView ID="gvDisplay" runat="server">
            </asp:GridView>
        </div>
    </form>
    <p>
&nbsp;</p>
</body>
</html>
