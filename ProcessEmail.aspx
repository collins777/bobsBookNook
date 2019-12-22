<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcessEmail.aspx.cs" Inherits="ProcessEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Process Email</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnBackToAdmin" runat="server" OnClick="btnBackToAdmin_Click" Text="Back To Admin" />
            <asp:TextBox ID="txtOwnerID" runat="server"></asp:TextBox>
            <asp:Label ID="lblErrorMessage" runat="server" Visible="False"></asp:Label>
            <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="Process Emails" />
            <asp:Button ID="btnStep2" runat="server" OnClick="btnStep2_Click" Text="Build XML" />
            <br />
            <asp:ListBox ID="lstRawXML" runat="server" Height="615px"></asp:ListBox>
            <asp:ListBox ID="lstEmail" runat="server" Height="614px"></asp:ListBox>
            <br />
        </div>
    </form>
</body>
</html>
