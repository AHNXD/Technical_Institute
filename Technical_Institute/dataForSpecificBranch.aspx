<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dataForSpecificBranch.aspx.cs" Inherits="Technical_Institute.dataForSpecificBranch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Branch Information</title>
</head>
<body>
    <form id="BranchInfo" runat="server">
        <asp:Label ID="BranchName" runat="server" Text="Branch"></asp:Label>
        <br/><br/>
        <asp:Label ID="FirstYear" runat="server" Text="First Year"></asp:Label>
        <br/><br/>
        <asp:Label ID="FirstSemesterOne" runat="server" Text="Semester 1"></asp:Label>
        <asp:GridView ID="FirstYearSemesterOne" runat="server"></asp:GridView>
        <br/><br/>
        <asp:Label ID="FirstSemesterTwo" runat="server" Text="Semester 2"></asp:Label>
        <asp:GridView ID="FirstYearSemesterTwo" runat="server"></asp:GridView>
        <br/><br/>
        <asp:Label ID="SecondYear" runat="server" Text="Second Year"></asp:Label>
        <br/><br/>
        <asp:Label ID="SecondSemesterOne" runat="server" Text="Semester 1"></asp:Label>
        <asp:GridView ID="SecondYearSemesterOne" runat="server"></asp:GridView>
        <br/><br/>
        <asp:Label ID="SecondSemesterTwo" runat="server" Text="Semester 2"></asp:Label>
        <asp:GridView ID="SecondYearSemesterTwo" runat="server"></asp:GridView>
    </form>
</body>
</html>
