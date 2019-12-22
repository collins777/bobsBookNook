<%@ Page Language="C#" AutoEventWireup="true" CodeFile="processBestsellers.aspx.cs" Inherits="processBestSellers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Process Best Sellers</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        td {
            vertical-align: top; 
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnReturnToAdmin" runat="server" OnClick="btnReturnToAdmin_Click" Text="Return to Admin" />
            <br />
            <asp:Label ID="lblErrorMessage" runat="server" Visible="False"></asp:Label>
            <br />
            <table class="auto-style1">
                <tr>
                    <td>Select ISBN to Add Best Seller</td>
                    <td>Select ISBN to Remove Best Seller</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvCatalog" runat="server" DataKeyNames="ISBN" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCatalog_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ButtonType="Button" SelectText="Add to Best Sellers" ShowCancelButton="False" ShowSelectButton="True" />
                                <asp:BoundField DataField="Title" HeaderText="Title" />
                                <asp:BoundField DataField="Author" HeaderText="Author" />
                                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:GridView ID="gvBestSellers" runat="server" DataKeyNames="ISBN" AutoGenerateColumns="False" OnSelectedIndexChanged="gvBestSellers_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ButtonType="Button" SelectText="Remove" ShowCancelButton="False" ShowSelectButton="True" />
                                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
