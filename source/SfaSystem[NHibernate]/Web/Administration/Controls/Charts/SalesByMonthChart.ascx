<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SalesByMonthChart.ascx.cs" Inherits="Administration_Controls_Charts_SalesByMonthChart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Chart ID="chartSalesByMonth" runat="server" Width="400px" Height="400px">
    <Series>
        <asp:Series Name="Series1">
            <Points>
                <asp:DataPoint YValues="45" />
                <asp:DataPoint YValues="34" />
                <asp:DataPoint YValues="67" />
            </Points>
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
