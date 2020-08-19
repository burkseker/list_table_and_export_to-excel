<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OrnekWebUygulamasi.WebForm2" %>

<!DOCTYPE html>

<html>
<head runat="server">
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   
    <link href="https://fonts.googleapis.com/css2?family=Squada+One&display=swap" rel="stylesheet">
    <link href="StyleSheet1.css" rel="stylesheet" />

    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            Username:<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" class="myButton" Font-Strikeout="False" />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Register</asp:LinkButton>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
