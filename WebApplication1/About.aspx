<%@ Page Title="Datasets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <hr />

   <div class="container-fluid">
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
           </div>
       <div class="btn-group">
           <button type="button" class="btn btn-primary">Farming Data</button>
           <button type="button" class="btn btn-warning dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
               <span class="caret"></span>
               <span class="sr-only">Toggle Dropdown</span>
           </button>
           <ul class="dropdown-menu">
               <li>Option 1</li>        
               <li>Option 2</li>
           </ul>
           </div>

           <!--</div>
            <table>
                <tr>
                    <td>
                       
                    </td>
                </tr>
            </table>
        </div>-->
           <asp:Label ID="Label1" runat="server"></asp:Label>
           <asp:Chart ID="Chart" runat="server">
               <Series>
                   <asp:Series Name="Championships" YValueType="Int32" ChartType="Line" ChartArea="MainChartArea">
                   </asp:Series>
               </Series>
               <ChartAreas>
                   <asp:ChartArea Name="MainChartArea">
                   </asp:ChartArea>
               </ChartAreas>
           </asp:Chart>
       </div>
    </asp:Content>

