﻿    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Technical_Institute.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="Login" runat="server">
        <div style="justify-items:center;text-align:center;width:auto;">
            <h1 style="color:#CC0000; font-style: italic; text-decoration: underline;" >Login</h1>
            <hr/>
            <h3>National Number:</h3>
            <input id="InputNationalNumber" type="text" runat="server" style="border-style: double; border-color: #CC0000;" /><br />
            <h3>Password:</h3>
            <input id="InputPassword" type="password" runat="server" style="border-style: double; border-color: #CC0000" /><br /><br />
            <asp:Button CssClass="btnLog" ID="btnLogin" runat="server" Text="Login" OnClick="Button_Login"/><br /><br />
            <asp:Label ID="LoginState" style="color:red" runat="server" Text="" Font-Italic="True"></asp:Label><br /><br />
            <pre>Don't Have an Account ? <a href="signUp.aspx">Create One.</a></pre>
        </div>
    </form>
</body>
</html>
