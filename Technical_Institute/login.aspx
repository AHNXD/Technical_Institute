    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Technical_Institute.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="Login" runat="server">
        <div style="justify-items:center;text-align:center;width:auto;">
            <h1>Login</h1>
            <hr />
            <h3>National Number:</h3>
            <input id="InputNationalNumber" type="text" runat="server"/><br />
            <h3>Password:</h3>
            <input id="InputPassword" type="password" runat="server"/><br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Button_Login"/><asp:Label ID="LoginState" runat="server" Text=""></asp:Label><br /><br />
            <pre>Dont Have an Account ? <a href="signUp.aspx">Create One.</a></pre>
        </div>
    </form>
</body>
</html>
