<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="OrnekWebUygulamasi.WebForm5" %>

<!DOCTYPE html>

<html>

<head runat="server">
     
     <link href="https://fonts.googleapis.com/css2?family=Squada+One&display=swap" rel="stylesheet">
     <link href="StyleSheet1.css" rel="stylesheet" />

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style type="text/css">
         .auto-style1 {}
     </style>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
        <div >
            <asp:Button ID="Button1" runat="server" class="myButton" OnClick="Button1_Click" Text="Home" PostBackUrl="Home"/>
            <asp:Button ID="Button2" runat="server" class="myButton" OnClick="Button2_Click" Text="About" PostBackUrl="About" />
            <asp:Button ID="Button3" runat="server" class="myButton" OnClick="Button3_Click" Text="Product" PostBackUrl="Product"/>
            <br />
            Products<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style1" Width="811px" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                <asp:HyperLinkField 
                    HeaderText="Name"
                    DataNavigateUrlFields="UrlName"
                    DataNavigateUrlFormatString="~/ProductDetails/{0}"
                    DataTextField="Name"
                    />
               
            </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
       
    </form>
</body>
</html>
