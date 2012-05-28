<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductGroupInfo.ascx.cs" Inherits="Administration_Controls_Product_ProductGroupInfo" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem" TagName="ToolTipLabel" %>
<%@ Register Src="~/Administration/Controls/TextBoxControl.ascx" TagPrefix="sfasystem" TagName="TextBox" %>
<%@ Register Src="~/Administration/Controls/Product/SelectProductGroupControl.ascx" TagPrefix="sfasystem" TagName="SelectProductGroupControl" %>

<table class="adminContent">
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblCategoryName" Text="Nazwa:" ToolTip="Nazwa grupy produktów"
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:TextBox runat="server" CssClass="adminInput" ID="txtName" ErrorMessage="Nazwa jest obowiązkowa." />
        </td>
    </tr>
    
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblCategoryDescription" Text="Opis:"
                ToolTip="Opis grupy produktów." ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:TextBox runat="server" ID="txtDescription" CssClass="adminInput" ErrorMessage="Opis jest obowiązkowy" TextMode="Multiline" Height="200" />
        </td>
    </tr>
    
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblParentCategory" Text="Grupa macierzysta:"
                ToolTip="Wybierz macierzystą grupę. Zostaw [ --- ], jeżeli chcesz aby była to grupa główna."
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:SelectProductGroupControl ID="ctrlParentGroup" CssClass="adminInput" runat="server">
            </sfasystem:SelectProductGroupControl>
        </td>
    </tr> 
</table>