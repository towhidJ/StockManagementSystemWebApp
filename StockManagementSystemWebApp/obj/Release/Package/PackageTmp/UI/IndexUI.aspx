<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.IndexUI" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <title>Stock Management System</title>

    <link href="../CSS/home.css" rel="stylesheet" />
    <link rel="stylesheet" href="../CSS/Style.css" />

</head>
<body class="grid">

    <div class="container">
        <header class="center">
            <h1 align="center" class="text1">Welcome To </h1>
            <h1 align="center" class="text2">Stock Management System</h1>
        </header>

        <form id="form1" runat="server">
            <div class="navdiv">
                <table align="center" align="justify">
                    <tr align="justify">
                        <td>
                            <asp:HyperLink ID="companyHyperLink" runat="server" NavigateUrl="~/UI/CompanyUI/CompanySetupUI.aspx">Company Setup</asp:HyperLink></td>
                        <td>
                            <asp:HyperLink ID="CatagoryHyperLink" runat="server" NavigateUrl="~/UI/CatagoryUI/CatagorySetupUI.aspx">Catagory Setup</asp:HyperLink></td>
                        <td>
                            <asp:HyperLink ID="ItemHyperLink" runat="server" NavigateUrl="ItemUI/ItemSetupUI.aspx">Item Add</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>

                    <tr align="justify">
                        <td>
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/UI/CompanyUI/CompanyDetailsUI.aspx">Company List</asp:HyperLink></td>
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/StockInUI/StockInSetupUI.aspx">Stock In</asp:HyperLink></td>
                        <td>
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/UI/CatagoryUI/CatagoryDetailsUI.aspx">Catagory List</asp:HyperLink></td>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr align="justify">
                        <td>
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../UI/ViewSalesBetweenTwoDates/ViewSalesBetweenTwoDatesUI.aspx">Search Sell Stock</asp:HyperLink></td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UI/StockOutUI/StockOutSetupUI.aspx">Stock Out</asp:HyperLink></td>
                        <td>
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="SearchAndViewItemsSummary/SearchAndViewItemsSummaryUI.aspx">Search Item</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>

                        <td align="center" colspan="3">
                            <asp:HyperLink CssClass="logout" runat="server" NavigateUrl="LoginUI.aspx">Logout</asp:HyperLink></td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
</body>
</html>
