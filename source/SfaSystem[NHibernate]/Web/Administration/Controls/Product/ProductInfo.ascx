<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductInfo.ascx.cs" Inherits="Administration_Controls_Product_ProductInfo" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectProductGroup" Src="~/Administration/Controls/Product/SelectProductGroupControl.ascx" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectTaxControl" Src="~/Administration/Controls/Product/SelectTaxControl.ascx" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectManufacturer" Src="~/Administration/Controls/Product/SelectManufacturerControl.ascx" %>

<%@ Register TagPrefix="sfasystem" TagName="TextBox" Src="~/Administration/Controls/TextBoxControl.ascx" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem" TagName="ToolTipLabel" %>


<table class="adminContent">
    <tbody>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblProductIDDesc" Text="Id:" ToolTip="Id produktu"
                ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:Label ID="lblProductID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblProdCode" Text="Kod produktu:" ToolTip="Uzupełnij kod produktu."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtCode" runat="server" ErrorMessage="Kod produktu jest obowiązkowy" Width="200px" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblProdName" Text="Nazwa:" ToolTip="Nazwa produktu."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtName" runat="server" ErrorMessage="Nazwa jest obowiązkowa" Width="200px" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel2" Text="Producent:" ToolTip="Producent produktu."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:SelectManufacturer ID="ctrlSelectManufacturer" runat="server" EmptyItemText="Wybierz..." Width="200px"/>
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblProdGroup" Text="Należy do:" ToolTip="Należy do grupy produktów."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:SelectProductGroup ID="ctrlSelectProductGroup" runat="server" Width="200px" EmptyItemText="Wybierz..." ErrorMessage="Wybierz grupę produktów." />
                
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblShortDescription" Text="Krótki opis:" ToolTip="Krótki opis."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:TextBox ID="txtShortDescription" runat="server" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvShortDescription" runat="server" ControlToValidate="txtShortDescription"
                    ErrorMessage="Krótki opis jest obowiązkowy." ToolTip="Krótki opis jest obowiązkowy."
                    ValidationGroup="ProductInfo">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblDescription" Text="Opis:" ToolTip="Opis produktu."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="200" Width="400"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                    ErrorMessage="Opis jest obowiązkowy." ToolTip="Opis jest obowiązkowy." ValidationGroup="ProductInfo">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="VAT:" ToolTip="Stawka podatku VAT."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:SelectTaxControl ID="ctrlSelectTax" runat="server" />%
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblPrice" Text="Cena brutto:" ToolTip="Cena produktu brutto."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtPrice" runat="server" ErrorMessage="Cena jest obowiązkowa" Width="70px" /> zł
            </td>
        </tr>
        
    </tbody>
</table>
