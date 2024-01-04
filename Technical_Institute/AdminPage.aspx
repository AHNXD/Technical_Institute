<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="Technical_Institute.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="adminPage" runat="server">
        <div style="justify-items:center;text-align:center;width:auto;">
             <asp:RadioButtonList ID="branchesList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                 <asp:ListItem Text="All Branches" Value="0" selected="true"/>
                 <asp:ListItem Text="Computer Engineering" Value="1" />
                 <asp:ListItem Text="Network Engineering" Value="2" />
                 <asp:ListItem Text="Software Engineering" Value="3" />
             </asp:RadioButtonList><br /> <br />
             <asp:Button ID="BtnAll" runat="server" Text="All Students" onClick="Button_Click" CommandArgument="all"/> <br /> <br />
             <asp:Button ID="BtnAccepted" runat="server" Text="Accepted students" onClick="Button_Click" CommandArgument="accepted"/> <br /> <br />
             <asp:Button ID="BtnRejected" runat="server" Text="Rejected students" onClick="Button_Click" CommandArgument="rejected"/> <br /> <br />
             <asp:Button ID="BtnPending" runat="server" Text="Pending students" onClick="Button_Click" CommandArgument="pending"/><br /> <br />
             <hr />
             <asp:GridView ID="viewStudents" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
