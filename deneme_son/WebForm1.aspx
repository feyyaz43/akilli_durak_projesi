<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="deneme_son.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        #sol{ width:600px; height:auto; float:left; margin-right:10px;  }
        #sol_ust { width:100%; height:300px; float:left;box-shadow: 2px 4px 6px #333333;}
        #sol_orta { width:100%; height:auto; float:left; margin-top:10px; margin-bottom:10px;}
        #sol_alt { width:100%; height:auto; float:left;}
        #sag{ width:600px; height:auto; float:left;}
        #sag_ust{ width:100%; height:60px; float:left;}
        #sag_alt{ width:100%; height:auto; float:left;}
        #sag_alt-1{width:300px; margin-right: 15px; height:auto; float:left;}
        #sag_alt-2{width:250px; height:auto; float:left;}
        
        #map-canvas{height:300px; width:590px; margin-left:0px; padding-left:0px;margin-right:5px; padding-right:5px; float:left;}
        
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 249px;
        }
        
    </style>

    <script type="text/javascript"
      src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCBROxTN3AnsN4iKEuHL2T1naim2PfQ8nk &sensor=false">
    </script>
    <script type="text/javascript">
        
        function initialize() {
            var directionsDisplay;
            var directionsService = new google.maps.DirectionsService();
            var map;

            
            var sira = '<%=sira %>';
            if (sira == 1) {
                x23_0 = 40.814702; x23_1 = 29.920768;                
                x23_2 = 40.801291; x23_3 = 29.9742;
                x23_4 = 40.795098; x23_5 = 29.979197;
                x23_6 = 40.776593; x23_7 = 29.966193;
                x23_8 = 40.775261; x23_9 = 29.971644;
                x23_10 = 40.767672; x23_11 = 29.968575;
                x23_12 = 40.76746; x23_13 = 29.971215;
                x23_14 = 40.762959; x23_15 = 29.972738;
                x23_16 = 40.762747; x23_17 = 29.97773;
                x23_18 = 40.762853; x23_19 = 29.981387;
            }
            if (sira == 2) {
                x23_0 = 40.814702; x23_1 = 29.920768;                
                x23_2 = 40.797925; x23_3 = 29.972974;
                x23_4 = 40.795001; x23_5 = 29.979154;
                x23_6 = 40.776626; x23_7 = 29.966279;
                x23_8 = 40.775326; x23_9 = 29.971622;
                x23_10 = 40.767688; x23_11 = 29.96864;
                x23_12 = 40.767509; x23_13 = 29.971215;
                x23_14 = 40.762975; x23_15 = 29.972953;                
                x23_16 = 40.762642; x23_17 = 29.939995;
                x23_18 = 40.737421; x23_19 = 29.94171;
            }

            var x1 = '<%=x1 %>';
            var x2 = '<%=x2 %>';
     
            var mapOptions = {
                center: new google.maps.LatLng(40.78, 29.97),
                zoom: 12
            };

            var mapOptions3 = {
                center: new google.maps.LatLng(40.78, 29.97),
                zoom: 12
            };

            
            var map = new google.maps.Map(document.getElementById("map-canvas"),
            mapOptions);
           
            var map3 = new google.maps.Map(document.getElementById("map-canvas"),
            mapOptions3);



            if (x1 != 40.78 && x2 != 29.97) {
                var mapOptions2 = {
                    center: new google.maps.LatLng(x1, x2),
                    zoom: 17
                };

                var map2 = new google.maps.Map(document.getElementById("map-canvas"),
            mapOptions2);


                var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(x1, x2),
                    title: "durak"

                });
                marker.setMap(map2);
            }

            var directionsDisplay = new google.maps.DirectionsRenderer();
            directionsDisplay.setMap(map3);

            // yeni bir yol isteği hazırladık, başlangıç ve bitiş noktalarını, mod u belirttik  
            var request = {
                origin: new google.maps.LatLng(x23_0, x23_1),
                destination: new google.maps.LatLng(x23_18, x23_19),
                travelMode: google.maps.DirectionsTravelMode.DRIVING,
                waypoints: [
                { location: new google.maps.LatLng(x23_2, x23_3) },
                { location: new google.maps.LatLng(x23_4, x23_5) },
                { location: new google.maps.LatLng(x23_6, x23_7) },
                { location: new google.maps.LatLng(x23_8, x23_9) },
                { location: new google.maps.LatLng(x23_10, x23_11) },
                { location: new google.maps.LatLng(x23_12, x23_13) },
                { location: new google.maps.LatLng(x23_14, x23_15) },
                { location: new google.maps.LatLng(x23_16, x23_17) },
                ]
            };

            // yeni bir servis oluşturduk ve yol tarifi istedik
            // cevap olumlu gelirse yol göstericiye atadık ve yolumuz görüntülendi  
            var service = new google.maps.DirectionsService();
            service.route(request, function (result, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(result);
                }
            });

        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div id="sol">
            <div id="sol_ust">
                <div id="map-canvas" ></div>
            </div>
            <div id="sol_orta">
                <asp:Label ID="Label1" runat="server" BackColor="#FFCCCC" BorderStyle="None" 
                Font-Bold="True" Font-Size="15pt"></asp:Label>
            </div>
            <div id="sol_alt">
                 <asp:GridView ID="GridView1" runat="server"
                        Height="20px" Width="500px" Visible = "true"
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="Medium" Font-Strikeout="False" 
                        Font-Underline="False" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                 <asp:GridView ID="GridView2" runat="server"
                        Height="20px" Width="500px" 
                        BackColor="White"  Visible = "true"
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="Medium" Font-Strikeout="False" 
                        Font-Underline="False" HorizontalAlign="Left"  >
                        <AlternatingRowStyle BackColor="#DCDCDC" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        <SortedDescendingHeaderStyle BackColor="#000065" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        </asp:GridView>
            </div>  
        </div>
        <div id="sag">
            <div id="sag_ust">
                <table><!-- 4 BUTONU BURAYA YERLEŞTİRİYORUZ. -->
                    <tr>
                        <td><asp:Button ID="Button1" runat="server" Text="23" onclick="Button1_Click" 
                        BorderColor="#33CCFF" BorderStyle="Solid" Font-Bold="True" Font-Size="13pt" 
                        Font-Strikeout="False" Font-Underline="False" Width="118px" /></td>
                        <td><asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                        Text="Sefer Saatleri" BorderColor="#33CCFF" BorderStyle="Solid" 
                        Font-Bold="True" Font-Size="13pt" Font-Strikeout="False" Font-Underline="False" 
                        Height="28px" /></td>
                        <td><asp:Button ID="Button2" runat="server" Text="24" onclick="Button2_Click" 
                        BorderColor="#33CCFF" BorderStyle="Solid" Font-Bold="True" Font-Size="13pt" 
                        Font-Strikeout="False" Font-Underline="False" Width="118px" /></td>
                        <td><asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                        Text="Sefer Saatleri" BorderColor="#33CCFF" BorderStyle="Solid" 
                        Font-Bold="True" Font-Size="13pt" Font-Strikeout="False" 
                        Font-Underline="False" /></td>
                    </tr>
                </table>
                <table class="style1">
                    <tr>
                        <td class="style2">
                            <asp:Button ID="Button5" runat="server" Text="23 Haritada Göster" Width="254px" 
                            BorderColor="#33CCFF" BorderStyle="Solid" Font-Bold="True" Font-Size="13pt" 
                            Font-Strikeout="False" Font-Underline="False" onclick="Button5_Click"/>
                        </td>
                        <td>
                            <asp:Button ID="Button6" runat="server" Text="24 Haritada Göster" Width="254px" 
                            BorderColor="#33CCFF" BorderStyle="Solid" Font-Bold="True" Font-Size="13pt" 
                            Font-Strikeout="False" Font-Underline="False" onclick="Button6_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="sag_alt">
                <div id="sag_alt-1">
                    <br />
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="AccessDataSource1"
                        Height="65px" Width="300px" 
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False" onrowcommand="GridView3_RowCommand" 
                        Visible="False">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        <Columns>
                            <asp:BoundField DataField="Sira" HeaderText="Sira" SortExpression="Sira" />
                            <asp:BoundField DataField="Durak" HeaderText="Durak" SortExpression="Durak" />
                            <asp:BoundField DataField="Ilce" HeaderText="Ilce" SortExpression="Ilce" />
                            <asp:TemplateField HeaderText="Ne Zaman Gelecek">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" 
                            ImageUrl="~/resimler/Man-With-Question-01.png" Width="44px" CommandArgument='<%# Eval("Sira") %>'
                            CommandName="Ne Zaman Gelecek" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Geçen Diğer Hatlar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                         CommandName="Geçen Diğer Hatlar" 
                            ImageUrl="~/resimler/bus_logo.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Haritada Göster">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="29px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                        CommandName="Haritada Göster" 
                            ImageUrl="~/resimler/Durak1.png"  />
                    </ItemTemplate>
                </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                        DataFile="~/App_Data/HATLAR.accdb" SelectCommand="SELECT * FROM [HAT23_gidis]">
                    </asp:AccessDataSource>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="AccessDataSource3"
                        Height="65px" Width="300px" 
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False" onrowcommand="GridView5_RowCommand" 
                        Visible="False" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        <Columns>
                            <asp:BoundField DataField="Sira" HeaderText="Sira" SortExpression="Sira" />
                            <asp:BoundField DataField="Durak" HeaderText="Durak" SortExpression="Durak" />
                            <asp:BoundField DataField="Ilce" HeaderText="Ilce" SortExpression="Ilce" />
                            <asp:TemplateField HeaderText="Ne Zaman Gelecek">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" 
                            ImageUrl="~/resimler/Man-With-Question-01.png" Width="44px" CommandArgument='<%# Eval("Sira") %>'
                            CommandName="Ne Zaman Gelecek" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Geçen Diğer Hatlar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                         CommandName="Geçen Diğer Hatlar" 
                            ImageUrl="~/resimler/bus_logo.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Haritada Göster">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="29px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                        CommandName="Haritada Göster" 
                            ImageUrl="~/resimler/Durak1.png"  />
                    </ItemTemplate>
                </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource3" runat="server" 
                        DataFile="~/App_Data/HATLAR.accdb" SelectCommand="SELECT * FROM [HAT24_gidis]">
                    </asp:AccessDataSource>
                </div>

                <div id="sag_alt-2">
                    <br />
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="AccessDataSource2"
                        Height="65px" Width="300px" 
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False" onrowcommand="GridView4_RowCommand" 
                        Visible="False" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        <Columns>
                            <asp:BoundField DataField="Sira" HeaderText="Sira" SortExpression="Sira" />
                            <asp:BoundField DataField="Durak" HeaderText="Durak" SortExpression="Durak" />
                            <asp:BoundField DataField="Ilce" HeaderText="Ilce" SortExpression="Ilce" />
                            <asp:TemplateField HeaderText="Ne Zaman Gelecek">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" 
                            ImageUrl="~/resimler/Man-With-Question-01.png" Width="44px" CommandArgument='<%# Eval("Sira") %>'
                            CommandName="Ne Zaman Gelecek"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Geçen Diğer Hatlar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                         CommandName="Geçen Diğer Hatlar" 
                            ImageUrl="~/resimler/bus_logo.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Haritada Göster">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="29px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                        CommandName="Haritada Göster" 
                            ImageUrl="~/resimler/Durak1.png"  />
                    </ItemTemplate>
                </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
                        DataFile="~/App_Data/HATLAR.accdb" SelectCommand="SELECT * FROM [HAT23_donus]">
                    </asp:AccessDataSource>
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="AccessDataSource4"
                        Height="65px" Width="300px" 
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False" onrowcommand="GridView6_RowCommand" 
                        Visible="False" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        <Columns>
                            <asp:BoundField DataField="Sira" HeaderText="Sira" SortExpression="Sira" />
                            <asp:BoundField DataField="Durak" HeaderText="Durak" SortExpression="Durak" />
                            <asp:BoundField DataField="Ilce" HeaderText="Ilce" SortExpression="Ilce" />
                            <asp:TemplateField HeaderText="Ne Zaman Gelecek">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" 
                            ImageUrl="~/resimler/Man-With-Question-01.png" Width="44px" CommandArgument='<%# Eval("Sira") %>'
                            CommandName="Ne Zaman Gelecek" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Geçen Diğer Hatlar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                         CommandName="Geçen Diğer Hatlar" 
                            ImageUrl="~/resimler/bus_logo.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Haritada Göster">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="29px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                        CommandName="Haritada Göster" 
                            ImageUrl="~/resimler/Durak1.png"  />
                    </ItemTemplate>
                </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource4" runat="server" 
                        DataFile="~/App_Data/HATLAR.accdb" SelectCommand="SELECT * FROM [HAT24_donus]">
                    </asp:AccessDataSource>
                    <br />
                </div>
            </div>
        </div>







    <%--<div style="width:600px; height:620px; float:left;"><!-- SOL -->
        <div id="map-canvas"; ></div>
        <div style="width:600px; height:auto; float:left;">
            <br />
            <asp:Label ID="Label1" runat="server" BackColor="#FFCCCC" BorderStyle="None" 
                Font-Bold="True" Font-Size="15pt"></asp:Label>
            <br />
        </div>
        <div style="width:100%; height:auto; float:left; padding-top:6px;">
        
            <table class="style1">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server"
                        Height="20px" Width="290px" Visible = "true"
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:GridView ID="GridView2" runat="server"
                        Height="20px" Width="290px" 
                        BackColor="White"  Visible = "true"
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False"  >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        
        </div>
    </div>--%> <!-- Sol -->
    
    <%--<div style="width:300px; height:auto; float:left;"><!--Sağ -->

        <table class="style2">
            <tr>
                <td class="style3" width="300px">
                    <asp:Button ID="Button1" runat="server" Text="23" onclick="Button1_Click" 
                        BorderColor="#33CCFF" BorderStyle="Solid" Font-Bold="True" Font-Size="13pt" 
                        Font-Strikeout="False" Font-Underline="False" Width="118px" />
                </td>

                <td class="style4" width="300px">
                    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                        Text="Sefer Saatleri" BorderColor="#33CCFF" BorderStyle="Solid" 
                        Font-Bold="True" Font-Size="13pt" Font-Strikeout="False" Font-Underline="False" 
                        Height="28px" />
                </td>

                <td class="style3">
                    <asp:Button ID="Button2" runat="server" Text="24" onclick="Button2_Click" 
                        BorderColor="#33CCFF" BorderStyle="Solid" Font-Bold="True" Font-Size="13pt" 
                        Font-Strikeout="False" Font-Underline="False" Width="118px" />
                </td>

                <td class="style3" style="width: 150px" width="300px">
                    <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                        Text="Sefer Saatleri" BorderColor="#33CCFF" BorderStyle="Solid" 
                        Font-Bold="True" Font-Size="13pt" Font-Strikeout="False" 
                        Font-Underline="False" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="AccessDataSource1"
                        Height="65px" Width="300px" 
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False" onrowcommand="GridView3_RowCommand" 
                        Visible="False">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        <Columns>
                            <asp:BoundField DataField="Sira" HeaderText="Sira" SortExpression="Sira" />
                            <asp:BoundField DataField="Durak" HeaderText="Durak" SortExpression="Durak" />
                            <asp:BoundField DataField="Ilce" HeaderText="Ilce" SortExpression="Ilce" />
                            <asp:TemplateField HeaderText="Ne Zaman Gelecek">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" 
                            ImageUrl="~/resimler/Man-With-Question-01.png" Width="44px" CommandArgument='<%# Eval("Sira") %>'
                            CommandName="Ne Zaman Gelecek" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Geçen Diğer Hatlar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                         CommandName="Geçen Diğer Hatlar" 
                            ImageUrl="~/resimler/bus_logo.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Haritada Göster">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="29px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                        CommandName="Haritada Göster" 
                            ImageUrl="~/resimler/Durak1.png"  />
                    </ItemTemplate>
                </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                        DataFile="~/App_Data/HATLAR.accdb" SelectCommand="SELECT * FROM [HAT23_gidis]">
                    </asp:AccessDataSource>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="AccessDataSource3"
                        Height="65px" Width="300px" 
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False" onrowcommand="GridView5_RowCommand" 
                        Visible="False" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        <Columns>
                            <asp:BoundField DataField="Sira" HeaderText="Sira" SortExpression="Sira" />
                            <asp:BoundField DataField="Durak" HeaderText="Durak" SortExpression="Durak" />
                            <asp:BoundField DataField="Ilce" HeaderText="Ilce" SortExpression="Ilce" />
                            <asp:TemplateField HeaderText="Ne Zaman Gelecek">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" 
                            ImageUrl="~/resimler/Man-With-Question-01.png" Width="44px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Geçen Diğer Hatlar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                         CommandName="Geçen Diğer Hatlar" 
                            ImageUrl="~/resimler/bus_logo.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Haritada Göster">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="29px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                        CommandName="Haritada Göster" 
                            ImageUrl="~/resimler/Durak1.png"  />
                    </ItemTemplate>
                </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource3" runat="server" 
                        DataFile="~/App_Data/HATLAR.accdb" SelectCommand="SELECT * FROM [HAT24_gidis]">
                    </asp:AccessDataSource>
                </td>
                <td colspan="2">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="AccessDataSource2"
                        Height="65px" Width="300px" 
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False" onrowcommand="GridView4_RowCommand" 
                        Visible="False" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        <Columns>
                            <asp:BoundField DataField="Sira" HeaderText="Sira" SortExpression="Sira" />
                            <asp:BoundField DataField="Durak" HeaderText="Durak" SortExpression="Durak" />
                            <asp:BoundField DataField="Ilce" HeaderText="Ilce" SortExpression="Ilce" />
                            <asp:TemplateField HeaderText="Ne Zaman Gelecek">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" 
                            ImageUrl="~/resimler/Man-With-Question-01.png" Width="44px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Geçen Diğer Hatlar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                         CommandName="Geçen Diğer Hatlar" 
                            ImageUrl="~/resimler/bus_logo.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Haritada Göster">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="29px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                        CommandName="Haritada Göster" 
                            ImageUrl="~/resimler/Durak1.png"  />
                    </ItemTemplate>
                </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
                        DataFile="~/App_Data/HATLAR.accdb" SelectCommand="SELECT * FROM [HAT23_donus]">
                    </asp:AccessDataSource>
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="AccessDataSource4"
                        Height="65px" Width="300px" 
                        BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Font-Size="XX-Small" Font-Strikeout="False" 
                        Font-Underline="False" onrowcommand="GridView6_RowCommand" 
                        Visible="False" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" Font-Underline="True" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                        <Columns>
                            <asp:BoundField DataField="Sira" HeaderText="Sira" SortExpression="Sira" />
                            <asp:BoundField DataField="Durak" HeaderText="Durak" SortExpression="Durak" />
                            <asp:BoundField DataField="Ilce" HeaderText="Ilce" SortExpression="Ilce" />
                            <asp:TemplateField HeaderText="Ne Zaman Gelecek">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" 
                            ImageUrl="~/resimler/Man-With-Question-01.png" Width="44px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Geçen Diğer Hatlar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                         CommandName="Geçen Diğer Hatlar" 
                            ImageUrl="~/resimler/bus_logo.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Haritada Göster">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="29px" Width="40px" CommandArgument='<%# Eval("Sira") %>'
                        CommandName="Haritada Göster" 
                            ImageUrl="~/resimler/Durak1.png"  />
                    </ItemTemplate>
                </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:AccessDataSource ID="AccessDataSource4" runat="server" 
                        DataFile="~/App_Data/HATLAR.accdb" SelectCommand="SELECT * FROM [HAT24_donus]">
                    </asp:AccessDataSource>
                    <br />
                </td>
            </tr>
        </table>

    </div>--%>
    
    </form>
</body>
</html>
