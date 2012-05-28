<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="BestSalesReps.aspx.cs" Inherits="Administration_Reports_BestSalesReps" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-reports.png")%>" alt="Sprzedaż" />
            Raport sprzedaży - Top 10 przedstawicieli handlowych w wybranym czasie
        </div>
        <div class="options">
            <asp:Button ID="btnExecute" runat="server" Text="Generuj raport" CssClass="adminButtonBlue"
                ToolTip="Generowanie raportu" OnClick="btnExecute_Click" />
        </div>
    </div>
    <table>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Data sprzedaży od:"
                    ToolTip="Klient, który złożył zamówienie" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtStartDate" Width="180px" />
                <asp:ImageButton runat="Server" ID="iStartDate" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <ajaxToolkit:CalendarExtender ID="cStartDateButtonExtender" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="iStartDate" />
                <asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="txtStartDate" Font-Name="verdana"
                    Font-Size="9pt" runat="server" Display="None" ErrorMessage="Data jest obowiązkowa"></asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
                    HighlightCssClass="validatorCalloutHighlight" />
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel2" Text="Data sprzedaży do:"
                    ToolTip="Klient, który złożył zamówienie" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEndDate" Width="180px" />
                <asp:ImageButton runat="Server" ID="iEndDate" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="iEndDate" />
                <asp:RequiredFieldValidator ID="rfvValue2" ControlToValidate="txtEndDate"
                    Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="Data jest obowiązkowa"></asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                    TargetControlID="rfvValue2" HighlightCssClass="validatorCalloutHighlight" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <rsweb:ReportViewer ID="rvSales" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="800px" ProcessingMode="Remote" ShowCredentialPrompts="False" ShowDocumentMapButton="False"
        ShowExportControls="False" ShowFindControls="False" ShowPageNavigationControls="False"
        ShowParameterPrompts="False" ShowZoomControl="False" Width="100%" 
        >
        <ServerReport ReportPath="/SFASystemReports/BestSalesReps" />
    </rsweb:ReportViewer>
</asp:Content>

