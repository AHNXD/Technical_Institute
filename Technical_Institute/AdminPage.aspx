<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Technical_Institute.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Button ID="Btn1" runat="server" Text="All Students" onClick="Button_Click1"/>
             <asp:Button ID="Btn2" runat="server" Text="All Students in specific branch " onClick="Button_Click1"/>
             <asp:Button ID="Btn3" runat="server" Text="All Students in specific branch" onClick="Button_Click1"/>
             <asp:Button ID="Btn4" runat="server" Text="" onClick="Button_Click1"/>
        </div>
    </form>
</body>
</html>
