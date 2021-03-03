<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministratorPage.aspx.cs" Inherits="MidTermExam.AdministratorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="lblAdmin" runat="server" Text="Enter a new user:"></asp:Label>
        	<br />
			<br />
			<asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
        	<br />
			<br />
			<asp:Label ID="lblLogin" runat="server" Text="Login username:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="tbxLogin" runat="server"></asp:TextBox>
        	<br />
			<br />
			<asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox>
        	<br />
			<br />
			<asp:Label ID="lblType" runat="server" Text="User type:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:DropDownList ID="ddlType" runat="server">
			</asp:DropDownList>
        	<br />
			<br />
			<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
