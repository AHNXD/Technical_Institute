<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Technical_Institute.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvGetAllBranches" runat="server"></asp:GridView>
            <br></br>
            <asp:GridView ID="gvGetBranch" runat="server"></asp:GridView>
             <br></br>
            <asp:GridView ID="gvgetSubjectFromBranch" runat="server"></asp:GridView>
             <br></br>
             <asp:GridView ID="gvgetSubjectFromBranchForSpecificYear" runat="server"></asp:GridView>
             <br></br>
            <asp:GridView ID="gvgetSubjectFromBranchForSpecificYearForSpecificSemester" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
