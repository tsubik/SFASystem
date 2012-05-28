<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="ProductReport.aspx.cs" Inherits="Administration_Reports_ProductReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-reports.png")%>" alt="Sprzedaż" />
            Raport - zestawienie produktów
        </div>
        <div class="options">
           
        </div>
    </div>
    <table>
       
    </table>
    <p>
    </p>
    
    <rsweb:ReportViewer ID="rvSales" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="800px" ProcessingMode="Remote" 
         Width="100%" 
        >
        <ServerReport ReportPath="/SFASystemReports/ProductReport" />
    </rsweb:ReportViewer>
</asp:Content>

