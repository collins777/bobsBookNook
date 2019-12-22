<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bob's Book Nook</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }

        td {
            vertical-align: top; 
        }
        .auto-style2 {
            width: 100%;
        }

        .imgLogo {
            background-image: url("https://cdn.pixabay.com/photo/2017/09/08/00/05/icon-2727224_960_720.png");
            background-position: center; 
            background-size: contain; 
            background-repeat: no-repeat; 
            height: 200px; 
           
        }

        .imgBanner {
            background-image: url("https://torange.biz/photofx/187/8/design-layout-responsive-brochure-business-banner-template-books-powerpoint-website-187843.jpg");
            background-position: center; 
            background-size: cover; 
            background-repeat: no-repeat; 
            height: 200px; 

            display: flex; 
            justify-content: center; 
            align-items: center; 
        }

        h1 {
            color: #ffffff;
        }
     
        .auto-style3 {
            height: 636px;
        }
     
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblErrorMessage" runat="server" Text="Label"></asp:Label>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="imgLogo"></td>
                    <td class="imgBanner">
                        <h1>Bobs Book Nook</h1>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <table class="auto-style2">
                            <tr>
                                <td>
                                    <asp:Button ID="btnClearSearchOptions" runat="server" OnClick="btnClearSearchOptions_Click" Text="Clear Search Options" />
                                    <asp:GridView ID="gvAuthors" runat="server" AutoGenerateColumns="False" DataKeyNames="Author" OnSelectedIndexChanged="gvAuthors_SelectedIndexChanged" BackColor="#0099FF" ForeColor="White">
                                        <Columns>
                                            <asp:BoundField DataField="Author" HeaderText="Author" />
                                            <asp:CommandField ButtonType="Button" CausesValidation="False" SelectText="View" ShowCancelButton="False" ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </td>
                                <td>
                                    <asp:Button ID="btnViewBestSeller" runat="server" OnClick="btnViewBestSeller_Click" Text="View Best Sellers" />
                                    <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" DataKeyNames="Category" OnSelectedIndexChanged="gvCategories_SelectedIndexChanged" BackColor="#0099FF" ForeColor="White">
                                        <Columns>
                                            <asp:BoundField DataField="Category" HeaderText="Category" />
                                            <asp:CommandField ButtonType="Button" CausesValidation="False" SelectText="View" ShowCancelButton="False" ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                     
                    </td>
                    <td class="auto-style3">
                        <asp:GridView ID="gvCatalog" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# (string) FormatImageUrl( (string) Eval("Image")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Title" HeaderText="Title" />
                                <asp:BoundField DataField="Author" HeaderText="Author" />
                                <asp:BoundField DataField="Category" HeaderText="Category" />
                                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:HyperLinkField DataNavigateUrlFields="ISBN" DataNavigateUrlFormatString="ShoppingCart.aspx?Id={0}" DataTextField="ISBN" DataTextFormatString="Buy Me" HeaderText="Click to Purchase" NavigateUrl="~/ShoppingCart.aspx" Target="_top" Text="ISBN" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
