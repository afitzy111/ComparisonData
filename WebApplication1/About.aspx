<%@ Page Title="Datasets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <hr />

   <div class="container-fluid">
       <h3>Please select an option below.</h3>
       <hr/>
       <h3>Rainfall</h3>
            <asp:Button ID ="btnRainFall" type ="button" class="btn-default" runat="server" Text="Total Rainfall" OnClick="btn_click" />        
            <asp:Button ID ="btnOutflow" type ="button" class="btn-default" runat="server" Text="Total Outflow" OnClick="btn_click" /><hr />
        <h3>Farming Incomes</h3>
                <asp:Button ID ="btnTotalProduction" type ="button" class="btn-default" runat="server" Text="Total Production value (Real Prices)" OnClick="btn_click" />        
                <asp:Button ID ="cattle" type ="button" class="btn-default" runat="server" Text="Total Cattle Production value" OnClick="btn_click" /><hr />
        <h3>Agricultural Exports</h3>
                <asp:Button ID ="btnTotalExport" type ="button" class="btn-default" runat="server" Text="Total Agricultural Export value" OnClick="btn_click" />        
                <asp:Button ID ="btnExportNAmerica" type ="button" class="btn-default" runat="server" Text="Total Agricultural Export to N America" OnClick="btn_click" /><hr />
       <h3>Comparison Options</h3>
                   <asp:Button ID="btnRainCattle" type="button" class="btn-default" runat="server" Text="Rainfall/Cattle Production" OnClick="btn_click" />
                   <asp:Button ID="btnOutflowCattle" type="button" class="btn-default" runat="server" Text="Outflow/Cattle Production" OnClick="btn_click" />
                   <asp:Button ID="btnTotalFarmingTotalExports" type="button" class="btn-default" runat="server" Text="Total Farming Production/Total Agricultural Exports" OnClick="btn_click" />
                   <asp:Button ID="btnSummerRainfallCereal" type="button" class="btn-default" runat="server" Text="Summer Rainfall Total/Cereal Production" OnClick="btn_click" /><hr />
       <br />
      
          
       <div class="row">
           <br />          
           <asp:Chart ID="Chart" runat="server" Height="419px" Width="944px">
               <Series>
                   <asp:Series Name="Series1" ChartType="Line" Color="DarkRed" MarkerStyle="Diamond">
                   </asp:Series>
                <asp:Series Name="Series2" ChartType="Line" Color="DarkBlue" MarkerStyle="Diamond"></asp:Series>
               </Series>
               <ChartAreas>
                   <asp:ChartArea Name="ChartArea1">
                   </asp:ChartArea>
               </ChartAreas>
           </asp:Chart>
       </div><br />
       </div>
        <div class="row">
           

      <asp:GridView ID="GridView1" runat="server" Width="902px" Height="178px" GridLines="None" BackColor="#DADADA" BorderStyle="Solid" Font-Names="Calibri" ForeColor="Black" CellPadding="5" CellSpacing="5">
               <RowStyle BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" />
               <SelectedRowStyle BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" />
           </asp:GridView>

       </div>
        

    
    
</asp:Content>
