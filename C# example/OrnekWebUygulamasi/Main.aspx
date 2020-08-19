<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="OrnekWebUygulamasi.Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html>
<head runat="server">
     <link href="StyleSheet1.css" rel="stylesheet" />
   
     <link href="https://fonts.googleapis.com/css2?family=Squada+One&display=swap" rel="stylesheet">
   
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style type="text/css">
        .yeniStil1 {
            font-family: "Courier New";
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
            <asp:Button ID="Button3" runat="server" class="myButton" OnClick="Button3_Click" Text="Home" PostBackUrl="~/Home"/>
            <asp:Button ID="Button4" runat="server" class="myButton" OnClick="Button4_Click" Text="About" PostBackUrl="~/About" />
            <asp:Button ID="Button5" runat="server" class="myButton" OnClick="Button5_Click" Text="Product" PostBackUrl="~/Product"/>
            <br />
            <br />
            Username:
              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Click Button to Show Your Table<br />
            <asp:Button type="button" class="myButton" ID="btnConnectDB" runat="server" Text="Show Table" OnClick="btnConnectDB_Click" Height="56px" />
            
            <br />
            <br />
            <br />
            <asp:GridView ID="Liste" OnPageIndexChanging="gvProducts_PageIndexChanging"
            AllowPaging="True" runat="server" Height="200px" Width="400px" HorizontalAlign="Center" CssClass="corners" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="First" LastPageText="Last" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <br />
            Click Export to Get Table in Excel File<br />
            <br />

            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">ExportToExcel</asp:LinkButton>

            <br />
            <br />
            Enter E-mail To Send&nbsp; Excel File:<br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" class="myButton" OnClick="Button2_Click" Text="Send Mail" />

            <br />

            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Register </asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Logout</asp:LinkButton>
            <br />
            <br />
    </form>
</body>
</html>

<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
