<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SalesRepSalesChart.ascx.cs" Inherits="Administration_Controls_Charts_SalesRepSalesChart" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<div class="chart_box">
 <div class="title">
    Moja roczna sprzedaż
 </div>
 <div class="content">
    <rsweb:ReportViewer ID="rvSales" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="240px" ProcessingMode="Remote" BackColor="Red"
    ShowParameterPrompts="False" ShowToolBar="False" Width="400px">
    <ServerReport ReportPath="/SFASystemReports/SalesRepYearSalesChart" />
</rsweb:ReportViewer>
  </div>
</div>