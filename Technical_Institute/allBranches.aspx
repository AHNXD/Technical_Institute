<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allBranches.aspx.cs" Inherits="Technical_Institute.allBranches" EnableEventValidation="false" %>

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


            <div style="display:flex;justify-content:space-evenly;justify-items:center;text-align:center;width:auto;">
                <asp:Repeater runat="server" ID="rptBranches" OnItemCommand="rptBranches_ItemCommand">
                    <ItemTemplate>
                        <div style="justify-items:center;text-align:center;width:200px;border:solid;">
                            <h2><%# Eval("Branch_Name") %></h2>
                            <h4>Hours: <%# Eval("NumberOfHours") %></h4>
                            <h4>Years: <%# Eval("NumberOfYear") %></h4>
                            <h4>Minimum Degree: <%# Eval("Minimum_Degree") %></h4>
                            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="Button_Register" CommandArgument='<%# Eval("ID") %>' style="background-color:green"/><br /><br />
                            <asp:LinkButton ID="btnSeeMore" runat="server" Text='See More' CommandName="OpenBranch" CommandArgument='<%# Eval("ID") %>' />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

<%--         <asp:Button ID="B1" runat="server" Text="" onClick="Button_Click1"/>
             <asp:Button ID="B2" runat="server" Text="" onClick="Button_Click2"/>
             <asp:Button ID="B3" runat="server" Text="" onClick="Button_Click3"/>--%>
        </div>
    </form>
</body>
</html>