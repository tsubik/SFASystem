<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerInfo.ascx.cs"
    Inherits="Administration_Controls_Customer_CustomerInfo" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem"
    TagName="ToolTipLabel" %>
<%@ Register Src="~/Administration/Controls/TextBoxControl.ascx" TagPrefix="sfasystem"
    TagName="TextBox" %>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblCode" Text="Kod:" ToolTip="Kod klienta."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:TextBox runat="server" CssClass="adminInput" ID="txtCode" ErrorMessage="Kod jest obowiązkowy." />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblName" Text="Nazwa:" ToolTip="Nazwa klienta."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:TextBox runat="server" ID="txtName" CssClass="adminInput" ErrorMessage="Nazwa jest obowiązkowa" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblDescription" Text="Opis:" ToolTip="Opis klienta."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtDescription" CssClass="adminInput" TextMode="MultiLine"
                Height="200" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="NIP:" ToolTip="NIP klienta." 
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtNIP" CssClass="adminInput" Width="80px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNIP"
                ErrorMessage="Pole wymagane." ToolTip="Pole wymagane.">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNIP"
                ErrorMessage="Podany nip jest niepoprawny." ToolTip="Podany nip jest niepoprawny."
                Text="*" ValidationExpression="\d\d\d-\d\d\d-\d\d-\d\d" />
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtNIP"
                Mask="999-999-99-99" ClearMaskOnLostFocus="false"  >
            </ajaxToolkit:MaskedEditExtender>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel2" Text="REGON:" ToolTip="REGON klienta."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtREGON" CssClass="adminInput" Width="80px" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel3" Text="KRS:" ToolTip="KRS klienta."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtKRS" CssClass="adminInput" Width="80px" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel4" Text="Email:" ToolTip="Email klienta."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtEmail" CssClass="adminInput" Width="150px" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel5" Text="Telefon:" ToolTip="Telefon do klienta."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtPhone" CssClass="adminInput" Width="150px" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblCustomerSince" Text="Klient firmy od:"
                ToolTip="Klient firmy od." ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtCustomerSince" runat="server" Width="200px" CssClass="adminInput"></asp:TextBox>
            <asp:ImageButton runat="Server" ID="btnCustomerSince" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
            <ajaxToolkit:CalendarExtender ID="calExtCustomerSince" runat="server" PopupPosition="Right"
                PopupButtonID="btnCustomerSince" TargetControlID="txtCustomerSince" Format="dddd, MMMM dd, yyyy">
            </ajaxToolkit:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblCustomerTo" Text="Klient firmy do:"
                ToolTip="Klient firmy do." ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtCustomerTo" runat="server" Width="200px" CssClass="adminInput"></asp:TextBox>
            <asp:ImageButton runat="Server" ID="btnCustomerTo" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
            <ajaxToolkit:CalendarExtender ID="calExtCustomerTo" runat="server" PopupPosition="Right"
                PopupButtonID="btnCustomerTo" TargetControlID="txtCustomerTo" Format="dddd, MMMM dd, yyyy">
            </ajaxToolkit:CalendarExtender>
        </td>
    </tr>
</table>
