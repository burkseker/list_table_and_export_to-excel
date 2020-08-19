<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="OrnekWebUygulamasi.WebForm3" %>

<!DOCTYPE html>


<%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<script>
    $(document).ready(function () {
        var num = 3

        
         
        var x = 0;
        $('Panel#Panel1').on('scroll', function () {
            <%=Newtable(DetailsView1)%>;
        });

        $("div").scroll(function () {
            $("span").text(x += 1);
        });

    });




</script--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Squada+One&display=swap" rel="stylesheet"/>
    <link href="StyleSheet1.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
        var x = 0;
        $(document).ready(function () {
            $("div").scroll(function () {
                $("span").text(x += 1);
                if (x % 10 == 0) {
                    for (z = 0; z < 5;z++)
                        <% int k = 0; Newtable(k); k++; %>;

                }
            });
        });
    </script>


    <title>Product Details Page</title>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
        <div style="border:1px solid black;width:200px;height:100px;overflow:scroll;">In my younger and more vulnerable years my father gave me some advice that I've been turning over in my mind ever since.
'Whenever you feel like criticizing anyone,' he told me, just remember that all the people in this world haven't had the advantages that you've had.'
</div>

    <div style="text-align: center"  >
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
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
        <asp:DetailsView ID="DetailsView2"  runat="server"
            AllowPaging="True"
            ForeColor="#333333" CellPadding="4" GridLines="None"
            HorizontalAlign="Center" class='input-form'
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
       
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
        <p>Scrolled <span>0</span> times.</p>
       
        <br/>
    </div>
    </form>
</body>
</html>
