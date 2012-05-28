<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Administration_Sales_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-sales.png")%>" alt="Sprzedaż" />
            Zamówienia
        </div>
        <div class="options">
            <asp:Button ID="btnSearch" runat="server" Text="Filtruj" CssClass="adminButtonBlue"
                ToolTip="Filtruj" OnClick="btnSearch_Click" />
            <asp:Button ID="btnRemoveFilter" runat="server" Text="Usuń filtr" CssClass="adminButtonBlue"
                ToolTip="Filtruj" OnClick="btnRemoveFilter_Click" />
            <asp:Button ID="btnOrder" runat="server" Text="Dodaj nowe zamówienie" CssClass="adminButtonBlue"
                ToolTip="Dodawanie zamówienia" OnClick="btnOrder_Click" />
        </div>
    </div>
    <table>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="lblAssignedTo" Text="Klient:" ToolTip="Klient, który złożył zamówienie"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectCustomerControl ID="ctrlSelectCustomer" runat="server" EmptyItemText="Wszyscy" Width="200px" />
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Region:" ToolTip="Filtruj po regionie sprzedaży"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectTerritoryControl ID="ctrlSelectTerritory" runat="server" EmptyItemText="Wszyscy" Width="200px" />
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel2" Text="Handlowiec:"
                    ToolTip="Pracownik, który utworzył zamówienie" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectEmployeeControl ID="ctrlSelectEmployee" runat="server" EmptyItemText="Wszyscy" Width="120px" />
            </td>
        </tr>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel3" Text="Status:" ToolTip="Status"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectOrderStatus ID="ctrlOrderStatus" runat="server" Width="200px" EmptyItemText="Wszystkie..."/>
            </td>
        </tr>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel5" Text="Data od:" ToolTip="Pokaz tylko od tej daty"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtStartDate" Width="180px" />
                <asp:ImageButton runat="Server" ID="iStartDate" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <ajaxToolkit:CalendarExtender ID="cStartDateButtonExtender" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="iStartDate" />
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel6" Text="Data do:" ToolTip="Pokaz tylko do tej daty"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEndDate" Width="180px" />
                <asp:ImageButton runat="Server" ID="iEndDate" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <ajaxToolkit:CalendarExtender ID="cEndDateButtonExtender" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="iEndDate" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <sfasystem:OrderList ID="ctrlOrderList" runat="server" />
</asp:Content>
