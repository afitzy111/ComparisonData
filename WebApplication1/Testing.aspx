<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Testing.aspx.cs" Inherits="WebApplication1.Testing" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<form id="form1" runat="server">-->
        <div>
            <h1>Welcome</h1>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRain" runat="server" Text="Rain data for every year" OnClick="btn_click" /> 
                        <asp:Button ID="btnOutflow" runat="server" Text="Outflow data for every year" OnClick="btn_click" /> 
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Chart ID="chtNBAChampionships" runat="server">
            <Series>
                <asp:Series Name="Championships" YValueType="Int32" ChartType="Line" ChartArea="MainChartArea">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="MainChartArea">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
   <!--</form>-->
       </asp:Content>
  

 