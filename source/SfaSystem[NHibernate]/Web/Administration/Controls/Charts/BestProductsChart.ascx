<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BestProductsChart.ascx.cs" Inherits="Administration_Controls_Charts_BestProductsChart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Chart ID="chartBestProducts" runat="server" Width="300px" Height="300px">
   <Series>
        <asp:Series Name="Default">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>