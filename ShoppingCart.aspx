<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="toBrowsing" runat="server" OnClick="toBrowsing_Click" Text="Back to Browsing" />
            <br />
            <asp:Button ID="btnCheckout" runat="server" OnClick="btnCheckout_Click" Text="Checkout" />
            <br />
            <asp:Label ID="lblErrorMessage" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:GridView ID="gvShoppingCart" runat="server" DataKeyNames="ISBN" Visible="False">
            </asp:GridView>
            <br />
            <asp:GridView ID="gvDisplay" runat="server" AutoGenerateColumns="false" DataKeyNames="ISBN" OnSelectedIndexChanged="gvDisplay_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# (string) FormatImageUrl( (string) Eval("Image")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:CommandField ButtonType="Button" ShowCancelButton="false" ShowSelectButton="true" SelectText="Place Back on Shelf" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblPeopleWhoPurchased" runat="server" Text="People who purchased this book also purchase the following"></asp:Label>
            <br />



            <asp:GridView ID="gvPeopleWhoPurchasedThis" runat="server" AutoGenerateColumns="false" DataKeyNames="ISBN" OnSelectedIndexChanged="gvPeopleWhoPurchasedThis_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# (string) FormatImageUrl( (string) Eval("Image")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author"/>
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN"/>
                    <asp:CommandField ButtonType="Button" InsertVisible="false" SelectText="Purchase" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
 
    </form>
</body>
</html>
