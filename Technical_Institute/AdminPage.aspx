<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="Technical_Institute.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="adminPage" runat="server">
        <div style="justify-items:center;text-align:center;width:auto;">
            <h1><asp:Label ID="lblAdminName" runat="server" Text=""></asp:Label></h1><br />
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
                <h3><asp:Label ID="lblEdit" runat="server" Text="Edit Student :"></asp:Label></h3>
                <pre>Student ID: <input id="InputStdID" type="text" size="5" runat="server"/> Branch ID: <input id="inputBranchID" type="text" size="5" runat="server"/></pre>
                Student Status: <select id="InputListStatus" runat="server">
                                    <option value="Accept">Accept</option>
                                    <option value="Reject">Reject</option>
                                    <option value="Pend">Pend</option>
                                </select><br /><br />
                <asp:Button ID="btnSet" runat="server" Text="Update" OnClick="Button_Update"/><br /><br />
                <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
            <hr />
             <asp:GridView ID="viewStudents" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
