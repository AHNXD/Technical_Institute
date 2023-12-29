<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="Technical_Institute.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:RadioButtonList ID="brunchesList" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList><br /> <br />
             <asp:Button ID="Btn1" runat="server" Text="All Students" onClick="Button_Click1"/> <br /> <br />
             <asp:Button ID="Btn2" runat="server" Text="Accepted students" onClick="Button_Click2"/> <br /> <br />
             <asp:Button ID="Btn3" runat="server" Text="Rejected students" onClick="Button_Click3"/> <br /> <br />
             <asp:Button ID="Btn4" runat="server" Text="Students are in a waiting state" onClick="Button_Click4"/>
           
        </div>
    </form>
</body>
</html>
