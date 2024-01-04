<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dataForSpecificBranch.aspx.cs" Inherits="Technical_Institute.dataForSpecificBranch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Branch Information</title>
</head>
<body>
    <form id="BranchInfo" runat="server">
        <div style="justify-items:center;text-align:center;width:auto;">
            <h1><asp:Label ID="BranchName" runat="server" Text="Branch"></asp:Label></h1>


            <asp:Repeater runat="server" ID="Repeater_Years">
                <ItemTemplate>
                    <br/><br/>
                    <h3>Year: <asp:Label runat="server" Text='<%# Eval("year") %>'></asp:Label></h3>
                    <h5>Semester: <asp:Label runat="server" Text='<%# Eval("semester") %>'></asp:Label></h5>

                    <asp:GridView runat="server" DataSource='<%# GetSubjects(Eval("year").ToString(), Eval("semester").ToString()) %>'></asp:GridView>
                </ItemTemplate>
            </asp:Repeater>


        <!--<br/><br/>
            <h3><asp:Label ID="FirstYear" runat="server" Text="*First Year:"></asp:Label></h3>
            <br/><br/>
            <h5><asp:Label ID="FirstSemesterOne" runat="server" Text="Semester 1"></asp:Label></h5>
            <asp:GridView ID="FirstYearSemesterOne" runat="server"></asp:GridView>
            <br/><br/>
            <h5><asp:Label ID="FirstSemesterTwo" runat="server" Text="Semester 2"></asp:Label></h5>
            <asp:GridView ID="FirstYearSemesterTwo" runat="server"></asp:GridView>
            <br/><br/>
            <h3><asp:Label ID="SecondYear" runat="server" Text="*Second Year:"></asp:Label></h3>   
            <br/><br/>
            <h5><asp:Label ID="SecondSemesterOne" runat="server" Text="Semester 1"></asp:Label></h5> 
            <asp:GridView ID="SecondYearSemesterOne" runat="server"></asp:GridView>
            <br/><br/>
            <h5><asp:Label ID="SecondSemesterTwo" runat="server" Text="Semester 2"></asp:Label></h5>      
            <asp:GridView ID="SecondYearSemesterTwo" runat="server"></asp:GridView>-->
        </div>
    </form>
</body>
</html>
