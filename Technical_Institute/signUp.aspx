<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="Technical_Institute.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="SignUp" runat="server">
        <div>
            <h1>SignUp</h1>
            <hr />
            <h3>First Name:</h3>
            <input id="InputFirstName" type="text" /><br />
            <h3>Last Name:</h3>
            <input id="InputLastName" type="text" /><br />
            <h3>National Number:</h3>
            <input id="InputNationalNumber" type="text" /><br />
            <h3>Phone Number:</h3>
            <input id="InputPhone" type="text" /><br />
            <h3>Gender:</h3>
            <input id="GenderMale" type="radio" name="Gender" value="M"/> Male
            <input id="GenderFemale" type="radio" name="Gender" value="F"/> Female
            <h3>Certificate Type:</h3>
            <input id="" type="text" /><br />
            <h3>Degree:</h3>
            <input id="InputDegree" type="text" /><br />
            <h3>Password:</h3>
            <input id="InputPassword" type="password" /><br /><br />
            <asp:Button ID="btnSignUp" runat="server" Text="SignUp" OnClick="Button_Click"/>
        </div>
    </form>
</body>
</html>
