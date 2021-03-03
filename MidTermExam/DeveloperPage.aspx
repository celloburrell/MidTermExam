<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeveloperPage.aspx.cs" Inherits="MidTermExam.DeveloperPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="lblBugs" runat="server" Text="Select a Bug:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:DropDownList ID="ddlBugs" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
			</asp:DropDownList>
        	<br />
			<br />
			<asp:GridView ID="gvOutput" runat="server">
			</asp:GridView>
        	<br />
			<asp:Label ID="lblChanges" runat="server" Text="Steps taken to fix bug:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="tbxChanges" runat="server"></asp:TextBox>
        	<br />
			<br />
			<asp:Button ID="btnFixed" runat="server" Text="Fixed" OnClick="btnFixed_Click" />
        </div>
    </form>
</body>
</html>
