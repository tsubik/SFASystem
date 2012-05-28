<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuoteInfo.ascx.cs" Inherits="Administration_Controls_SalesDir_QuoteInfo" %>
<table class="adminContent">
    <tbody>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="tipQuoteText" Text="Tekst:" ToolTip="Treść cytatu."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtText" runat="server" Width="300" ErrorMessage="Treść jest obowiązkowa" Height="100" TextMode="MultiLine"/>
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="tipQuoteAuthor" Text="Autor:" ToolTip="Autor cytatu."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:TextBox ID="txtAuthor" runat="server" Width="300"  />
            </td>
        </tr>
        <tr runat="server" id="trCreatedBy">
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="tipQuoteActive" Text="Aktywne:"
                    ToolTip="Czy cytat jest aktywny." ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:CheckBox ID="chxActive" runat="server" />
            </td>
        </tr>
    </tbody>
</table>