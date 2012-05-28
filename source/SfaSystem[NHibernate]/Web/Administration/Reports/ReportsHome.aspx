<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="ReportsHome.aspx.cs" Inherits="Administration_Reports_ReportsHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-reports.png")%>" alt="Sprzedaż" />
            Moduł analityczny aplikacji SFASystem
        </div>
        <div class="options">
        </div>
    </div>
    <p>
    </p>
    <ul style="line-height: 20px; padding-left: 15px;">
        <li runat="server" id="lnkCR"><a href="CustomerReport.aspx">Zobacz zestawienie klientów</a></li>
        <li runat="server" id="lnkPR"><a href="ProductReport.aspx">Zobacz zestawienie produktów</a></li>
        <li runat="server" id="lnkBPT"><a href="BProductByTerritory.aspx">Zobacz najlepiej sprzedające
            się produkty w wybranym regionie</a></li>
        <li runat="server" id="lnkER"><a href="EmployeeReport.aspx">Zobacz raport na temat wybranego
            pracownika</a></li>
        <li runat="server" id="lnkBC"><a href="BestCustomers.aspx">Zobacz zestawienie najlepszych
            klientów</a></li>
        <li runat="server" id="lnkBSR"><a href="BestSalesReps.aspx">Zobacz najlepszych przedstawicieli
            handlowych</a></li>
        <li runat="server" id="lnkSPG"><a href="SalesByProductGroup.aspx">Zobacz raport sprzedaży
            według grup produktów</a></li>
        <li runat="server" id="lnkST"><a href="SalesByTerritory.aspx">Zobacz raport sprzedaży
            według regionów</a></li>
    </ul>
</asp:Content>
