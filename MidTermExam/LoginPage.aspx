﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MidTermExam.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="lblLogin" runat="server" Text="Please enter your login information"></asp:Label>
        	<br />
			<br />
            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
			&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox>
        	<br />
			<br />
			<asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
        	<br />
			<br />
			<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
