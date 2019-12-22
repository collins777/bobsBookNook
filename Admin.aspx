    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bob's BookNook Admin Page</title>
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
    <form runat="server">
     <asp:Button ID="toBookStore" runat="server" OnClick="toBookStore_Click" Text="To BookStore" />

        <table class="auto-style1">
            <tr>
                <td rowspan="2">
                    <asp:ListBox ID="lstProgress" runat="server" Height="350px" Width="200px"></asp:ListBox>
                </td>
                <td>Your software OwnerID<asp:TextBox ID="txtOwnerID" runat="server" Enabled="False"></asp:TextBox>
                    <asp:Button ID="btnResetUser" runat="server" Text=" Reset User" OnClick="btnResetUser_Click" />
                    <br />
                    If you click [Clear Database] you will have to reload all xml and jpg files<asp:Button ID="btnClearDB" runat="server" BackColor="Red" ForeColor="Yellow" Text="Clear Database" OnClick="btnClearDB_Click" />
                    <br />
                    Browse for and select BookJacket images, then Click [Load Images]<br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="btnLoadImages" runat="server" Text="Load Images" OnClick="btnLoadImages_Click" />
                    <br />
                    Browse for BookInventory.xml file, then click [Import Book Data]<br />
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Button ID="btnLoadXML" runat="server" Text="Import Book Data" OnClick="btnLoadXML_Click" />
                    <br />
                    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                    <br />
                </td>
                <td>
                    <asp:Button ID="btnViewInventory" runat="server" Text="View Inventory" OnClick="btnViewInventory_Click"/>
                    <br />
                    
                    <!--
                    <asp:Button ID="btnViewInventory0" runat="server" Text="View Inventory" OnClick="btnViewInventory_Click"/>
                    -->
                     
                    <asp:Button ID="btnProcessBestSellers" runat="server" OnClick="btnProcessBestSellers_Click" Text="Process Best Sellers" />
                    <br />
                    <asp:Button ID="btnRemoveBookTitle" runat="server" OnClick="btnRemoveBookTitle_Click" Text="Remove Book Titles from Category" />
                     
                    <br />
                    <asp:Button ID="btnEmailMarketing" runat="server" OnClick="btnEmailMarketing_Click" Text="Email Marketing" />
                     
                </td>
            </tr>
            <tr>

                <td colspan="2">
                 
                    <asp:GridView ID="gvDisplay" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# (string) FormatImageUrl( (string) Eval("Image")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Title" HeaderText="Title" />
                            <asp:BoundField DataField="Author" HeaderText="Author" />
                            <asp:BoundField DataField="Category" HeaderText ="Category" />
                            <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
  
        <asp:ListBox ID="lstHidden" runat="server" Visible="False"></asp:ListBox>
     

        <asp:GridView ID="gvHidden" runat="server" Visible="False">
        </asp:GridView>
     

    </form>
</body>
</html>

