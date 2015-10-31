<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="WebApplication1.Testing" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome</h1>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnRain" runat="server" Text="Rain data for every year" onClick="btn_click"/>
                    <asp:Button ID="btnOutflow" runat="server" Text="Outflow data for every year" onClick="btn_click"/>
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
    </form>
</body>
</html>
