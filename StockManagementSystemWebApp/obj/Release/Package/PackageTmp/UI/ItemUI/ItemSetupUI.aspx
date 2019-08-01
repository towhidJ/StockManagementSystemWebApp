<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetupUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.ItemUI.ItemSetupUI" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="../../CSS/ch5.css">
    <link rel="stylesheet" href="../../CSS/index.css">
    <link href="../../CSS/nav.css" rel="stylesheet" />
    <title>Item Addt</title>

    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>

</head>
<body class="grid">

    <div class="container">
        <header class="center">
            <nav>
                <div class="navigationBar">
                    <ul>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../IndexUI.aspx">Home</asp:HyperLink></li>
                        <li><a>Add Rcoard</a>
                            <ul>
                                <li>
                                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/UI/CompanyUI/CompanySetupUI.aspx">Company Add</asp:HyperLink></li>
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
            <h1 class="h">Item Add</h1>
        </div>
        <form id="form1" runat="server">
            <table class="tab" align="center">
                <tr>
                    <td align="right">
                        <asp:Label CssClass="textbox" ID="Label2" runat="server" Text="Company"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="textbox" ID="companyDropDownList" runat="server" DataTextField="CompanyName" DataValueField="Id" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label CssClass="textbox" ID="Label1" runat="server" Text="Catagory"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="textbox" ID="catagoryDropDownList" runat="server" DataTextField="CatagoryName" DataValueField="Id" AutoPostBack="True" >
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td align="right">
                        <asp:Label CssClass="textbox" ID="Label3" runat="server" Text="Item Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox CssClass="textbox" ID="itemNameTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label CssClass="textbox" ID="Label4" runat="server" Text="Reorder Level"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox CssClass="textbox" ID="reorderLevelTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button CssClass="Button" ID="saveButton" runat="server" Text="Save" Style="margin-left: 0px" OnClick="saveButton_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" class="auto-style1">
                        <p style="color: red"><asp:Label CssClass="textbox" ID="messageLabel" runat="server"></asp:Label></p>
                    </td>
                </tr>
            </table>
        </form>
        <footer>
            <nav>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="../IndexUI.aspx">Home</asp:HyperLink>
                &nbsp; |  &nbsp;
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../../Contact.html">Contact US</asp:HyperLink>&nbsp;  | &nbsp;
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="mailto:towhidulislamcse@gmail.com">Email Me</asp:HyperLink>&nbsp; |&nbsp;
                <asp:HyperLink ID="log" runat="server" NavigateUrl="../LoginUI.aspx">Logout</asp:HyperLink>
                
            </nav>
            <small>&copy; Sa71 Group</small>
        </footer>
    </div>
</body>
</html>
