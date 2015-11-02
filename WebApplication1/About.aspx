<%@ Page Title="Datasets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <hr />
   <div>
       <h3>Please select an option below. A graph will be generated showing your data.</h3>
       <hr />
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
</asp:Content>
