<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerPage.aspx.cs" Inherits="MidTermExam.ManagerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="lblBugSelector" runat="server" Text="Select a Bug:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:DropDownList ID="ddlBugs" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBugs_SelectedIndexChanged">
			</asp:DropDownList>
        	<br />
			<br />
			<asp:GridView ID="gvOutput" runat="server">
			</asp:GridView>
			<br />
			<asp:Label ID="lblDeveloper" runat="server" Text="Select Developer:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:DropDownList ID="ddlDeveloper" runat="server">
			</asp:DropDownList>
        	<br />
			<br />
			<asp:Button ID="btnAssign" runat="server" Text="Assign Developer to Bug" OnClick="btnAssign_Click" />
        </div>
    </form>
</body>
</html>
