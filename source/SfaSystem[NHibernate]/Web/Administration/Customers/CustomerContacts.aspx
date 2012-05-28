<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="CustomerContacts.aspx.cs" Inherits="Administration_Customers_CustomerContacts" %>

<%@ Register TagPrefix="sfasystem" TagName="ContactList" Src="~/Administration/Controls/ContactList.ascx" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem"
    TagName="ToolTipLabel" %>
<%@ Register Src="~/Administration/Controls/Customer/SelectCustomerControl.ascx"
    TagPrefix="sfasystem" TagName="SelectCustomerControl" %>
<%@ Register Src="~/Administration/Controls/Sale/SelectTerritoryControl.ascx" TagPrefix="sfasystem"
    TagName="SelectTerritoryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-customers.png") %>" alt="Kontakty" />
            Lista kontaktów
        </div>
        <div class="options">
            <asp:Button ID="btnSearch" runat="server" Text="Filtruj" CssClass="adminButtonBlue"
                ToolTip="Filtruj" OnClick="btnSearch_Click" />
            <asp:Button ID="btnRemoveFiltr" runat="server" Text="Usuń filtr" CssClass="adminButtonBlue"
                ToolTip="Usuń filtry" OnClick="btnRemoveFilter_Click" />
            <asp:Button ID="btnAddNew" runat="server" Text="Dodaj nowy kontakt" CssClass="adminButtonBlue"
                ToolTip="Dodaj nowy kontakt" OnClick="btnAddNew_Click" />
        </div>
    </div>
    <table>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="lblFacName" Text="Nazwa placówki:" ToolTip="Nazwa placowki"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox ID="txtName" CssClass="adminInput" runat="server" Width="150px"></asp:TextBox>
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
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="lblImieNaz" Text="Imię, Nazwisko:" ToolTip="Imię, Nazwisko"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox ID="txtImieNazwisko" CssClass="adminInput" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Email:" ToolTip="Email"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox ID="txtEmail" CssClass="adminInput" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel4" Text="Telefon:" ToolTip="Telefon"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox ID="txtTelefon" CssClass="adminInput" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <p>
    </p>
    <sfasystem:ContactList ID="ctrlContactList" runat="server" />
</asp:Content>
