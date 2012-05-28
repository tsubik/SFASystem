<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeSalesByMonthChart.ascx.cs"
    Inherits="Administration_Controls_Charts_EmployeeSalesByMonthChart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<div class="chart_box">
 <div class="title">
    Moja miesięczna sprzedaż
 </div>
 <div class="content">
    <asp:Chart ID="chartEmployeeByMonth" runat="server" Width="400px" Height="300px">
        <Series>
            <asp:Series Name="Default" XValueType="Double">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
  </div>
</div>
