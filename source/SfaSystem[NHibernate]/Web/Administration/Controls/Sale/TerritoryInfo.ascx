<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TerritoryInfo.ascx.cs" Inherits="Administration_Controls_Sale_TerritoryInfo" %>

<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem" TagName="ToolTipLabel" %>
<%@ Register Src="~/Administration/Controls/TextBoxControl.ascx" TagPrefix="sfasystem" TagName="TextBox" %>
<%@ Register Src="~/Administration/Controls/Sale/SelectTerritoryControl.ascx" TagPrefix="sfasystem" TagName="SelectTerritoryControl" %>

<table class="adminContent">
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblTerritoryName" Text="Nazwa:" ToolTip="Nazwa regionu."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:TextBox runat="server" CssClass="adminInput" ID="txtName" ErrorMessage="Nazwa jest obowiązkowa" />
        </td>
    </tr>
    
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblTerritoryDescription" Text="Opis:"
                ToolTip="A description of the category." ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:TextBox runat="server" ID="txtDescription" CssClass="adminInput" ErrorMessage="Opis jest obowiązkowy" TextMode="Multiline" Height="200" />
        </td>
    </tr>
    
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblParentCategory" Text="Region nadrzędny:"
                ToolTip="Wybierz region nadrzędny. Pozostaw [ --- ] jeżeli brak regionu nadrzędnego"
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:SelectTerritoryControl ID="ctrlParentTerritory" CssClass="adminInput" runat="server">
            </sfasystem:SelectTerritoryControl>
        </td>
    </tr> 
</table>