<%@ Page Title="Datasets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <hr />
   <div>
       <h3>Please select an option below.</h3>
       <hr/>
       <div class="btn-group">
           <button type="button" class="btn btn-primary">Rainfall Data</button>
           <button type="button" class="btn btn-warning dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
               <span class="caret"></span>
               <span class="sr-only">Toggle Dropdown</span>
           </button>
           <ul class="dropdown-menu">
               <li>
                   <asp:Button ID="btnRain" type="button" class="btn-default" runat="server" Text="Rain data for every year" OnClick="btn_click" /></li>
               <li>
                   <asp:Button ID="btnOutflow" type="button" class="btn-default" runat="server" Text="Outflow data for every year" OnClick="btn_click" />
               </li>
           </ul>
            <button type="button" class="btn btn-primary">Farming Data</button>
           <button type="button" class="btn btn-warning dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
               <span class="caret"></span>
               <span class="sr-only">Toggle Dropdown</span>
           </button>
           <ul class="dropdown-menu">
               <li></li>        
               <li></li>
           </ul>

           <!--</div>
            <table>
                <tr>
                    <td>
                       
                    </td>
                </tr>
            </table>
        </div>-->
           <br />    <br />
           <asp:Label ID="Label1" runat="server"></asp:Label>
           <asp:Chart ID="Chart" runat="server" Height="310px" Width="613px">
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
       </div>
           <br />    <br />    <br />    <br />    <br />    <br />
           <asp:GridView ID="GridView1" runat="server" Width="368px" Height="144px" BackColor="#E5E5E5" BorderStyle="None" Font-Names="Calibri">
    </asp:GridView>
        
       <div id="chart_div" style="width: 900px; height: 500px;">
    <br />
    <asp:Label ID="Label_Spearmans_Rank_Label" runat="server" Text="Spearman's Rank Correlation:   "></asp:Label>
    <asp:TextBox ID="Label_Spearmans_Rank_Value" runat="server"></asp:TextBox>
    
    <br />
    <br />
        <br />    
</div>
    </div>
</asp:Content>
