<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="ProductGroupDetails.aspx.cs" Inherits="Administration_Products_ProductGroupDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-catalog.png") %>" alt="" />
            <asp:Literal ID="litTitle" runat="server" /> <a href="<%=ResolveUrl("~/Administration/Products/ProductGroups.aspx") %>"
                title="Powrót do grup produktów">(Powrót do grup produktów)</a>
        </div>
        <div class="options">
            <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Save"
                OnClick="SaveButton_Click" ToolTip="Save changes to this category" />
            <asp:Button ID="DeleteButton" runat="server" CssClass="adminButtonBlue" Text="Delete"
                OnClick="DeleteButton_Click" CausesValidation="false" ToolTip="Delete this category" />
        </div>
    </div>
    <ajaxToolkit:TabContainer runat="server" ID="CategoryTabs" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" ID="pnlCategoryInfo" HeaderText="Informacje">
            <ContentTemplate>
                <sfasystem:ProductGroupInfo ID="ctrlProductGroupInfo" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmDeleteButtonExtender" runat="server"
        TargetControlID="DeleteButton" DisplayModalPopupID="ModalPopupExtenderDelete" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDelete" runat="server" TargetControlID="DeleteButton"
        PopupControlID="pnlDeletePopup" OkControlID="deleteButtonOk" CancelControlID="deleteButtonCancel"
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
