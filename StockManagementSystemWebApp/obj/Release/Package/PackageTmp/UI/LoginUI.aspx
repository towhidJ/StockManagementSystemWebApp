<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.LoginUI" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <title>Login</title>
    <link href="../CSS/Style.css" rel="stylesheet" />
</head>
<body>
<div class="hedderText"><h1 class="htext">Stock Management System</h1></div>

    <div class="login-box">
        
        <h1>Login</h1>
        <form id="form1" runat="server">
        <div class="textbox">
            <i class="fas fa-user"></i>
                <asp:TextBox ID="userNameTextBox" runat="server" placeholder="Username"></asp:TextBox>
            
        </div>
         <div class="textbox">
             <i class="fas fa-lock"></i>
                <asp:TextBox ID="passwordTextBox" runat="server" type="Password" placeholder="Password"></asp:TextBox>

        </div>
         <div class="textbox">
            
                <asp:Button ID="SignInButton" runat="server" Text="Sign in" OnClick="SignInButton_Click" />
        </div>
            <div class="textbox">
            <p style="color: red"><asp:Label ID="messageLabel" runat="server" Text=""></asp:Label></p>
                
            </div>
    </form>
    </div>




</body>
</html>
