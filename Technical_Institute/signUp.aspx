﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="Technical_Institute.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="SignUp" runat="server">
        <div style="justify-items:center;text-align:center;width:auto;">
            <h1 style="color:#CC0000; font-style: italic; text-decoration: underline;" >SignUp</h1>
            <hr />
            <h3>First Name:</h3>
            <input id="InputFirstName" type="text" runat="server" style="border-style: double; border-color: #CC0000;" required="required"/><br />
            <h3>Last Name:</h3>
            <input id="InputLastName" type="text" runat="server" style="border-style: double; border-color: #CC0000;" required="required"/><br />
            <h3>National Number:</h3>
            <input id="InputNationalNumber" type="text" runat="server" style="border-style: double; border-color: #CC0000;" required="required"/><br />
            <h3>Phone Number:</h3>
            <input id="InputPhone" type="text" runat="server" style="border-style: double; border-color: #CC0000;" /><br />
            <h3>Gender:</h3>
            <input id="GenderMale" type="radio" name="Gender" value="M" runat="server"/> Male
            <input id="GenderFemale" type="radio" name="Gender" value="F" runat="server"/> Female
            <h3>Certificate Type:</h3>
            <select id="Certificate_Type" runat="server">
                <option value="Other">Other</option>
                <option value="scientific">scientific</option>
                <option value="Literary ">Literary </option>
            </select>
            <h3>Degree:</h3>
            <input id="InputDegree" type="text" runat="server" style="border-style: double; border-color: #CC0000;" required="required"/><br />
            <h3>Password:</h3>
            <input id="InputPassword" type="password" runat="server" style="border-style: double; border-color: #CC0000;" required="required"/><br /><br />
            <input id="InputIsAdmin" type="checkbox" runat="server" /> Admin<br /><br />
            <asp:Button ID="btnSignUp" runat="server" Text="SignUp" OnClick="Button_Click"/><br /><br />
            <asp:Label ID="SignUpState" style="color:red" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
