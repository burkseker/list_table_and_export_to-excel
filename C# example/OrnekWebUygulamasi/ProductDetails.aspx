<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="OrnekWebUygulamasi.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Squada+One&display=swap" rel="stylesheet"/>
    <link href="StyleSheet1.css" rel="stylesheet" />
    <title>Product Details Page</title>
</head>

<body>
    <form id="form1" runat="server" style="text-align: center">

    <div style="text-align: center"  >
        Product Details<asp:DetailsView 
            ID="DetailsView1"
            runat="server"
            AllowPaging="True"
            ForeColor="#333333" CellPadding="4" GridLines="None"
            HorizontalAlign="Center"
            >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView>        
        
        <br />
             
        <br />
        <br />
       
        
        <p id="scroll">Scrolled <span>0</span> times.</p>
       
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal"></asp:Panel>
       
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
       
        <br/>
        <div class="container">
            <br />
        </div>
    </div>
        
    </form>
    <script type="text/javascript" src="./infiniteScroll.js"></script>
    <iframe src="https://localhost:44311/WebForm7.aspx" title="Newtable" seamless="seamless" height="200" width="300" > </iframe>
</body>
</html>
