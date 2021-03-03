<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TesterPage.aspx.cs" Inherits="MidTermExam.TesterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="lblWelcome" runat="server" Text="Enter new bug information here:"></asp:Label>
        	<br />
			<br />
			<asp:Label ID="lblSubject" runat="server" Text="Subject Title:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="tbxSubject" runat="server" Width="214px"></asp:TextBox>
        	<br />
			<br />
			<asp:Label ID="lblPriority" runat="server" Text="Priority Level:"></asp:Label>
&nbsp;&nbsp;&nbsp;
			<asp:DropDownList ID="ddlPriority" runat="server">
			</asp:DropDownList>
        	<br />
			<br />
			<asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="tbxDescription" runat="server" Height="80px" Width="218px"></asp:TextBox>
        	<br />
			<br />
			<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
