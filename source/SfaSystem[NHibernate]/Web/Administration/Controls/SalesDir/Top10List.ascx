<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top10List.ascx.cs" Inherits="Administration_Controls_SalesDir_Top10Lists" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<div class="dashboard_box top10_box">
    <div class="title">
        Raporty top 10
    </div>
    <div class="content">
        <rsweb:reportviewer id="rvTop10Customers" runat="server" font-names="Verdana" font-size="8pt"
            height="270px" processingmode="Remote" backcolor="Red" showparameterprompts="False"
            showtoolbar="False" width="350px">
    <ServerReport ReportPath="/SFASystemReports/Top10Customers" />
    </rsweb:reportviewer>
       <rsweb:ReportViewer ID="rvTop10Products" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="270px" ProcessingMode="Remote" BackColor="Red"
    ShowParameterPrompts="False" ShowToolBar="False" Width="350px">
    <ServerReport ReportPath="/SFASystemReports/Top10Products" />
    </rsweb:ReportViewer>
    </div>
</div>
