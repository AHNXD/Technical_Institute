<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allBranches.aspx.cs" Inherits="Technical_Institute.allBranches" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All Branches</title>
</head>
<body>
    <form id="AllBranches" runat="server">
        <div style="display:flex;flex-direction:column;text-align:center">
            <h1><asp:Label ID="Title" runat="server" Text="Technical Institute"></asp:Label></h1>
            <h3><asp:Label ID="username" runat="server" Text="Label"></asp:Label></h3>
            <h3><asp:Label ID="degree" runat="server" Text="Label"></asp:Label></h3>
             <asp:Button ID="B1" runat="server" Text="" onClick="Button_Click1"/>
             <asp:Button ID="B2" runat="server" Text="" onClick="Button_Click2"/>
             <asp:Button ID="B3" runat="server" Text="" onClick="Button_Click3"/>
        </div>
    </form>
</body>
</html>