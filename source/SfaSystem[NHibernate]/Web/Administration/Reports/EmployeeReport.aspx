<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeReport.aspx.cs" Inherits="Administration_Reports_EmployeeReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-reports.png")%>" alt="Sprzedaż" />
            Raport - Podsumowanie wybranego roku dla pracownika
        </div>
        <div class="options">
            <asp:Button ID="btnExecute" runat="server" Text="Generuj raport" CssClass="adminButtonBlue"
                ToolTip="Generowanie raportu" OnClick="btnExecute_Click" />
        </div>
    </div>
    <table>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="lblAssignedTo" Text="Pracownik:" ToolTip="Klient, który złożył zamówienie"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectEmployeeControl ID="ctrlSelectEmployee" runat="server" EmptyItemText="Wybierz pracownika..." ErrorMessage="Pracownik jest obowiązkowy"
                    Width="200px" />
            </td>
        </tr>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Rok:" ToolTip="Klient, który złożył zamówienie"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:DropDownList ID="lstYear" runat="server" >
                    <asp:ListItem Text="2007" Value="2007" />
                    <asp:ListItem Text="2008" Value="2008" />
                    <asp:ListItem Text="2009" Value="2009" Selected="True" />
                    <asp:ListItem Text="2010" Value="2010" />
                    <asp:ListItem Text="2011" Value="2011" />
                    <asp:ListItem Text="2012" Value="2012" />
                    <asp:ListItem Text="2013" Value="2013" />
                    <asp:ListItem Text="2014" Value="2014" />
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <p>
    </p>
    <rsweb:ReportViewer ID="rvSales" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="800px" ProcessingMode="Remote" ShowCredentialPrompts="False" ShowDocumentMapButton="False"
        ShowExportControls="False" ShowFindControls="False" ShowPageNavigationControls="False"
        ShowParameterPrompts="False" ShowZoomControl="False" Width="100%" 
        Enabled="False" Visible="False">
        <ServerReport ReportPath="/SFASystemReports/EmployeeReport" />
    </rsweb:ReportViewer>
</asp:Content>

