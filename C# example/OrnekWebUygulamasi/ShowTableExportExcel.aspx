
<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeBehind="ShowTableExportExcel.aspx.cs" Inherits="OrnekWebUygulamasi.Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <style type="text/css">
        .yeniStil1 {
            font-family: "Courier New";
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="btnConnectDB" runat="server" Text="address with names" OnClick="btnConnectDB_Click" Height="56px" />
            <asp:GridView ID="Liste" OnPageIndexChanging="gvProducts_PageIndexChanging"
            AllowPaging="true" PageSize="10" runat="server" Height="226px" Width="1054px">
            <PagerSettings Mode="NumericFirstLast" FirstPageText="İlk" LastPageText="Son" />
            </asp:GridView>

            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">ExportToExcel</asp:LinkButton>

            <br />

            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Register </asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Logout</asp:LinkButton>
    </form>
</body>
</html>

<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
