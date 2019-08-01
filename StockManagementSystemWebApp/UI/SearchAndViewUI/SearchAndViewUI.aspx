<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAndViewUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.SearchAndViewUI.SearchAndViewUI" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="../../CSS/ch5.css">
    <link rel="stylesheet" href="../../CSS/index.css">
    <title>স্বাধীন-৭১ Management</title>

    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>

    </head>
<body class="grid">

    <div class="container">
        <header class="center">
            <nav>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../IndexUI.aspx">Home</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UI/CompanyUI/CompanyDetailsUI.aspx">Show Details</asp:HyperLink>
            </nav>
            <h1>Item Add</h1>
            <h4>We Manage Local Events in Chittagong</h4>
        </header>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Company "></asp:Label>

                </td>
                <td colspan="" align="left">
                    <asp:DropDownList ID="companyDropDownList" runat="server" Width="108px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Catagory "></asp:Label></td>
                <td colspan="2" align="left" class="auto-style1">
                    <asp:DropDownList ID="catagoryDropDownList" runat="server" Width="108px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="searchButton" runat="server" Text="Search" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Label ID="messageLabel" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="searchAndViewGridView" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False">
                        
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        
                        <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <span>
                                                <%#Container.DataItemIndex + 1%>

                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                            <asp:HiddenField ID="HiddenField" runat="server" Value='<%#Eval("Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             <asp:TemplateField HeaderText="Company">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                            <asp:HiddenField ID="HiddenField" runat="server" Value='<%#Eval("Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                            <asp:HiddenField ID="HiddenField" runat="server" Value='<%#Eval("Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             <asp:TemplateField HeaderText="Avaliable Quantity">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                            <asp:HiddenField ID="HiddenField" runat="server" Value='<%#Eval("Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             <asp:TemplateField HeaderText="Reorder Level">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                            <asp:HiddenField ID="HiddenField" runat="server" Value='<%#Eval("Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                        
                        
                        
                        
                        
                        
                        
                        
                        

                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
     <footer>
            <nav>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="../IndexUI.aspx">Home</asp:HyperLink>
                &nbsp; |  &nbsp;
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../../Contact.html">Contact US</asp:HyperLink>&nbsp;  | &nbsp;
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="mailto:towhidulislamcse@gmail.com">Email Me</asp:HyperLink>&nbsp; |&nbsp;
                <a id="log" href="../CompanyUI/login/logout.php">Logout</a>
            </nav>
            <small>&copy; Towhidul Islam</small>
        </footer>
    </div>
</body>
</html>
