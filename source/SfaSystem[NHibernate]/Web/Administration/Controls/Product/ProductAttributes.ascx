<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductAttributes.ascx.cs"
    Inherits="Administration_Controls_Product_ProductAttributes" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagName="ToolTipLabel" TagPrefix="sfasystem" %>
<%@ Register Src="~/Administration/Controls/TextBoxControl.ascx" TagPrefix="sfasystem" TagName="TextBox" %>

<div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-catalog.png") %>" alt="" />
        Atrybuty produktów
    </div>
</div>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            <sfasystem:tooltiplabel runat="server" id="lblProductAttribute" text="Wybierz atrybut:"
                tooltip="Wybierz atrybut z listy." tooltipimage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:DropDownList ID="ddlAttributes" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:tooltiplabel runat="server" id="Tooltiplabel1" text="Dodaj nowy:"
                tooltip="Dodaj nowy atrybut." tooltipimage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:Button ID="btnAddNewAttribute" runat="server" Text="Dodaj" 
                CssClass="adminButtonBlue" onclick="btnAddNewAttribute_Click" />
        </td>
    </tr>
</table>

<asp:Panel ID="panelEditAttribute" runat="server" Visible="false">
    <table class="adminContent">
    <tr>
        <td class="adminTitle">
            <sfasystem:tooltiplabel runat="server" id="lblAttributeName" text="Nazwa atrybutu:"
                tooltip="Wpisz nazwę atrybutu." tooltipimage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <sfasystem:TextBox ID="txtAttributeName" runat="server" ErrorMessage="Nazwa jest obowiązkowa" CssClass="adminInput" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <sfasystem:tooltiplabel runat="server" id="lblAttributeDesc" text="Opis:"
                tooltip="Opis atrybutu." tooltipimage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtAttributeDesc" runat="server" TextMode="MultiLine" CssClass="adminInput" Height="200" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Opcje
        </td>
        <td class="adminData">
            <asp:Button ID="btnSaveAttribute" runat="server" CssClass="adminButtonBlue" 
                Text="Zapisz zmiany" onclick="btnSaveAttribute_Click" />
        </td>
    </tr>
</table>
</asp:Panel>

<table class="adminContent">
    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmDeleteButtonExtender" runat="server"
        TargetControlID="DeleteButton" DisplayModalPopupID="ModalPopupExtenderDelete" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDelete" runat="server" TargetControlID="DeleteButton"
        PopupControlID="pnlDeletePopup" OkControlID="deleteButtonOk" CancelControlID="deleteButtonCancel"
        BackgroundCssClass="modalBackground" />
    <asp:Panel ID="pnlDeletePopup" runat="server" Style="display: none; width: 250px;
        background-color: White; border-width: 2px; border-color: Black; border-style: solid;
        padding: 20px;">
        <div style="text-align: center;">
            Jesteś pewien?
            <br />
            <br />
            <asp:Button ID="deleteButtonOk" runat="server" Text="OK" CssClass="adminButton" CausesValidation="false" />
            <asp:Button ID="deleteButtonCancel" runat="server" Text="Cancel" CssClass="adminButton"
                CausesValidation="false" />
        </div>
    </asp:Panel>
