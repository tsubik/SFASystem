<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="CustomerFacilities.aspx.cs" Inherits="Administration_Customers_CustomerFacilities" %>

<%@ Register TagPrefix="sfasystem" TagName="FacilityList" Src="~/Administration/Controls/Customer/CustomerFacilityList.ascx" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem"
    TagName="ToolTipLabel" %>
<%@ Register Src="~/Administration/Controls/Customer/SelectCustomerControl.ascx"
    TagPrefix="sfasystem" TagName="SelectCustomerControl" %>
<%@ Register Src="~/Administration/Controls/Sale/SelectTerritoryControl.ascx" TagPrefix="sfasystem"
    TagName="SelectTerritoryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-facility.png")%>" alt="Facilities" />
            Lista obsługiwanych placówek
        </div>
        <div class="options">
            <asp:Button ID="btnSearch" runat="server" Text="Filtruj" CssClass="adminButtonBlue"
                ToolTip="Filtruj" OnClick="btnSearch_Click" />
            <asp:Button ID="btnRemoveFilter" runat="server" Text="Usuń filtr" CssClass="adminButtonBlue"
                ToolTip="Usuń filtry" OnClick="btnRemoveFilter_Click" />
            <asp:Button ID="btnAddNew" runat="server" Text="Dodaj nową placówkę" CssClass="adminButtonBlue"
                ToolTip="Dodaj nową placówkę" OnClick="btnAddNew_Click" />
        </div>
    </div>
    <table>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="lblFacName" Text="Nazwa:" ToolTip="Nazwa placowki"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox ID="txtName" CssClass="adminInput" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="lblRegion" Text="Wybierz region sprzedaży:"
                    ToolTip="Search by a specific category." ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectTerritoryControl ID="ctrlSelectTerritory" CssClass="adminInput"
                    runat="server" EmptyItemText="Wszystkie regiony" Width="200px" />
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="lblProductGroup" Text="Wybierz klienta:"
                    ToolTip="Search by a specific category." ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectCustomerControl ID="ctrlSelectCustomer" CssClass="adminInput" runat="server"
                    EmptyItemText="Wybierz klienta..." Width="200px" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <sfasystem:FacilityList ID="ctrlFacilityList" runat="server" />
</asp:Content>
