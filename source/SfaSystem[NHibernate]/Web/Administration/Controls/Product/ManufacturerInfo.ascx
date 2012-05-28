<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManufacturerInfo.ascx.cs"
    Inherits="Administration_Controls_Product_ManufacturerInfo" %>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblCategoryName" Text="Nazwa:" ToolTip="The category's name."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:TextBox runat="server" CssClass="adminInput" ID="txtName" ErrorMessage="Nazwa jest obowiązkowa" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Opis:" ToolTip="The category's name."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:TextBox runat="server" CssClass="adminInput" ID="txtDescription" TextMode="MultiLine"
                Width="300px" Height="100px" />
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
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel2" Text="Email:" ToolTip="The category's name."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" CssClass="adminInput" ID="txtEmail" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel3" Text="Telefon:" ToolTip="The category's name."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" CssClass="adminInput" ID="txtPhone" />
        </td>
    </tr>
    
</table>
