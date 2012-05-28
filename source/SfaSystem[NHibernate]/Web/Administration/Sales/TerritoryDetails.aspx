<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="TerritoryDetails.aspx.cs" Inherits="Administration_Sales_TerritoryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-region.png") %>" alt="Region" />
        <asp:Literal ID="litTitle" runat="server" /> <a href="<%=ResolveUrl("~/Administration/Sales/Territories.aspx") %>" title="Powrót do listy regionów">(Powrót do listy regionów)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
            OnClick="SaveButton_Click" ToolTip="Zapisz zmiany" />
        <asp:Button ID="DeleteButton" runat="server" CssClass="adminButtonBlue" Text="Delete"
            OnClick="DeleteButton_Click" CausesValidation="false" ToolTip="Usuń region" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="CategoryTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlCategoryInfo" HeaderText="Informacje">
        <ContentTemplate>
            <sfasystem:TerritoryInfo ID="ctrlTerritoryInfo" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
<ajaxToolkit:ConfirmButtonExtender ID="ConfirmDeleteButtonExtender" runat="server"
    TargetControlID="DeleteButton" DisplayModalPopupID="ModalPopupExtenderDelete" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDelete" runat="server" TargetControlID="DeleteButton"
    PopupControlID="pnlDeletePopup"  CancelControlID="deleteButtonCancel"
    BackgroundCssClass="modalBackground" />
<asp:Panel ID="pnlDeletePopup" runat="server" Style="display: none; width: 250px;
    background-color: White; border-width: 2px; border-color: Black; border-style: solid;
    padding: 20px;">
    <div style="text-align: center;">
        Are you sure?
        <p>
        </p>
        <asp:Button ID="deleteButtonOk" runat="server" Text="OK" CssClass="adminButton" CausesValidation="false" />
        <asp:Button ID="deleteButtonCancel" runat="server" Text="Cancel" CssClass="adminButton"
            CausesValidation="false" />
    </div>
</asp:Panel>
</asp:Content>

