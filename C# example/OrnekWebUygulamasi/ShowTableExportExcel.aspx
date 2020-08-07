
<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeBehind="ShowTableExportExcel.aspx.cs" Inherits="OrnekWebUygulamasi.Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
   <h1>Click Button to Show Your Table</h1>
   <h1>Click Export to Get Table in Excel File</h1>
    <form id="form1" runat="server" style="text-align: center">
            Username:
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button type="button" class="myButton" ID="btnConnectDB" runat="server" Text="Show Table" OnClick="btnConnectDB_Click" Height="56px" />
            
            <br />

            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">ExportToExcel</asp:LinkButton>

            <br />

            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Register </asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Logout</asp:LinkButton>
            <br />
            <asp:GridView ID="Liste" OnPageIndexChanging="gvProducts_PageIndexChanging"
            AllowPaging="true" PageSize="10" runat="server" Height="226px" Width="1054px" HorizontalAlign="Center" CssClass="corners">
            <PagerSettings Mode="NumericFirstLast" FirstPageText="İlk" LastPageText="Son" />
            </asp:GridView>
    </form>
</body>
</html>

<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
