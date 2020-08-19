<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OrnekWebUygulamasi.WebForm4" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
     <link href="https://fonts.googleapis.com/css2?family=Squada+One&display=swap" rel="stylesheet">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" class="myButton" OnClick="Button1_Click" Text="Home" PostBackUrl="Home"/>
            <asp:Button ID="Button2" runat="server" class="myButton" OnClick="Button2_Click" Text="About" PostBackUrl="About" />
            <asp:Button ID="Button3" runat="server" class="myButton" OnClick="Button3_Click" Text="Product" PostBackUrl="Product"/>
            <br />
            <br />
            This is about</div>
    </form>
</body>
</html>
