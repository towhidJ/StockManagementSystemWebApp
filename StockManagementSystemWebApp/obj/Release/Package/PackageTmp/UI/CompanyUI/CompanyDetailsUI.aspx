<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyDetailsUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.CompanyUI.CompanyDetailsUI" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="../../CSS/ch5.css">
    <link rel="stylesheet" href="../../CSS/index.css">
    <link href="../../CSS/gridView.css" rel="stylesheet" />
    <link href="../../CSS/nav.css" rel="stylesheet" />
    <title>Company Details</title>

</head>
<body class="grid">

    <div class="container">
        <header class="center">
            <nav>
                <div class="navigationBar">
                    <ul>
                        <li>
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../IndexUI.aspx">Home</asp:HyperLink></li>
                        <li><a>Add Rcoard</a>
                            <ul>
                                <li>
                                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="CompanySetupUI.aspx">Company Add</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="../CatagoryUI/CatagorySetupUI.aspx">Catagory Add</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="../ItemUI/ItemSetupUI.aspx">Item Add</asp:HyperLink></li>
                            </ul>
                        </li>

                        <li><a>Show Recoard</a>
                            <ul>
                                <li>
                                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="../CompanyUI/CompanyDetailsUI.aspx">Company</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="../CatagoryUI/CatagoryDetailsUI.aspx">Catagory</asp:HyperLink></li>
                            </ul>
                        </li>

                        <li><a>Stock</a>
                            <ul>
                                <li>
                                    <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="../StockInUI/StockInSetupUI.aspx">Stock In</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="../StockOutUI/StockOutSetupUI.aspx">Stock Out</asp:HyperLink></li>

                            </ul>
                        </li>
                        <li><a>Search</a>
                            <ul>
                                <li>
                                    <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="../SearchAndViewItemsSummary/SearchAndViewItemsSummaryUI.aspx">Item</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="../../UI/ViewSalesBetweenTwoDates/ViewSalesBetweenTwoDatesUI.aspx">Sales</asp:HyperLink></li>
                            </ul>
                        </li>
                        <li class="logout">
                            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="../LoginUI.aspx">Logout</asp:HyperLink></li>
                    </ul>
                </div>
            </nav>

        </header> 
        <div class="title">     
            <h1 class="h">Company List</h1>
        </div>
        <form id="form1" runat="server">

            <div class="ItemDown" align="center">
                <asp:GridView ID="companyGridView" runat="server" AutoGenerateColumns="False" Width="100%">

                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <span>
                                                <%#Container.DataItemIndex + 1%>

                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                            <asp:HiddenField ID="HiddenField" runat="server" Value='<%#Eval("Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ActionList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ActionList_OnSelectedIndexChanged">
                                                <asp:ListItem Value="0">Please Select</asp:ListItem>
                                                <asp:ListItem Value="update">Update</asp:ListItem>
                                                <asp:ListItem Value="delete">Delete </asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>



                            </asp:GridView>
            </div>
        </form>
        <footer>
            <nav>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="../IndexUI.aspx">Home</asp:HyperLink>
                &nbsp; |  &nbsp;
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="mailto:towhidulislamcse@gmail.com">Email Me</asp:HyperLink>&nbsp; |&nbsp;
                <asp:HyperLink ID="log" runat="server" NavigateUrl="../LoginUI.aspx">Logout</asp:HyperLink>
            </nav>
            <small>&copy; Towhidul Islam</small>
        </footer>
    </div>
</body>
</html>
