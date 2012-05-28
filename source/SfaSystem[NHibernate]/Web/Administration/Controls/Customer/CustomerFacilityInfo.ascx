<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerFacilityInfo.ascx.cs"
    Inherits="Administration_Controls_Customer_CustomerFacilityInfo" %>
<%@ Register TagName="TextBox" TagPrefix="sfasystem" Src="~/Administration/Controls/TextBoxControl.ascx" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem"
    TagName="ToolTipLabel" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectCountryControl" Src="~/Administration/Controls/SelectCountryControl.ascx" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectTerritoryControl" Src="~/Administration/Controls/Sale/SelectTerritoryControl.ascx" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectCustomerControl" Src="~/Administration/Controls/Customer/SelectCustomerControl.ascx" %>
<table class="adminContent">
    <tbody>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblNazwa" Text="Nazwa placówki:" ToolTip="Uzupełnij nazwę."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtNazwa" runat="server" ErrorMessage="Nazwa jest obowiązkowa"
                    Width="200px" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <h2>
                    Dane adresowe</h2>
            </td>
            <td class="adminData">
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblUlica" Text="Ulica:" ToolTip="Uzupełnij ulice."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtUlica" runat="server" ErrorMessage="Ulica jest obowiązkowa"
                    Width="200px" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblNrDomu" Text="Nr domu/mieszkania:"
                    ToolTip="Numer domu./mieszkania" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtNrDomu" runat="server" ErrorMessage="Numer domu jest obowiązkowy"
                    Width="30px" />
                /
                <asp:TextBox ID="txtNrMieszkania" runat="server" Width="30px" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblKodPocztowy" Text="Kod pocztowy:" ToolTip="Kod pocztowy."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtKodPocztowy" runat="server" ErrorMessage="Kod pocztowy jest obowiązkowy"
                    Width="50px" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblMiasto" Text="Miasto:" ToolTip="Miasto."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:TextBox ID="txtMiasto" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtMiasto"
                    ErrorMessage="Miasto jest obowiązkowe." ToolTip="Miasto jest obowiązkowe.">*</asp:RequiredFieldValidator>
                <ajaxToolkit:AutoCompleteExtender ID="autoCompleteExt" TargetControlID="txtMiasto"
                    runat="server" ServicePath="~/Administration/WebServices/AutoCompleteCityService.asmx"
                    CompletionInterval="100" ServiceMethod="GetCitiesList" MinimumPrefixLength="2"
                    CompletionSetCount="10" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblKraj" Text="Kraj:" ToolTip="Wybierz kraj."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:SelectCountryControl ID="ctrlSelectCountry" EmptyItemText="Wybierz kraj..."
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblRegion" Text="Region:" ToolTip="Wybierz region sprzedaży."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:SelectTerritoryControl ID="ctrlSelectTerritory" EmptyItemText="Wybierz region sprzedaży..."
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel4" Text="Email:" ToolTip="Email klienta."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="adminInput" Width="80px" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel5" Text="Telefon:" ToolTip="Telefon do klienta."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:TextBox runat="server" ID="txtPhone" CssClass="adminInput" Width="80px" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblKlient" Text="Klient:" ToolTip="Wybierz klienta."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:SelectCustomerControl ID="ctrlSelectCustomer" EmptyItemText="Wybierz klienta..."
                    runat="server" />
                <asp:Button ID="btnCustomerDetails" runat="server" CssClass="adminButton" Text="Szczegóły..."
                    OnClick="btnCustomerDetails_Click" />
            </td>
        </tr>
    </tbody>
</table>
