<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerFacilityDetails.aspx.cs" Inherits="Administration_Customers_CustomerFacilityDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
        <asp:Literal ID="litTitle" runat="server" /> <a href="<%=ResolveUrl("~/Administration/Customers/CustomerFacilities.aspx") %>"
            title="Powrót do listy placówek">(Powrót do listy placówek)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
            OnClick="SaveButton_Click" ToolTip="Zapisz zmiany" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="ProductTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductInfo" HeaderText="Placówka - informacje">
        <ContentTemplate>
            <sfasystem:CustomerFacilityInfo ID="ctrlFacilityInfo" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="Placówka - Osoby kontaktowe">
        <ContentTemplate>
            <sfasystem:ContactList runat="server" ID="ctrlContactList" />
                <br />
                <asp:Button ID="btnAddContact" runat="server" CssClass="adminButton" Text="Dodaj kontakt"
                    CausesValidation="false" />
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDelete" runat="server" TargetControlID="btnAddContact"
                    PopupControlID="pnlContactPopup" CancelControlID="btnContactCancel" BackgroundCssClass="modalBackground" />
                <asp:Panel ID="pnlContactPopup" runat="server" Style="display: none; width: 300px;
                    background-color: White; border-width: 2px; border-color: Black; border-style: solid;">
                    <div class="modalTitle">
                        Dodawanie kontaktu
                    </div>
                    <div style="text-align: left; padding: 20px;">
                        <sfasystem:ContactInfo ID="ctrlContactInfo" runat="server" ValidationGroup="contactModal" />
                        <br />
                       
                        <div style="text-align: center">
                            <asp:Button ID="btnContactSave" runat="server" Text="Zapisz" CssClass="adminButtonGreen"
                                CausesValidation="true" OnClick="btnContactSave_Click" ValidationGroup="contactModal" />
                            <asp:Button ID="btnContactCancel" runat="server" Text="Cancel" CssClass="adminButtonRed"
                                CausesValidation="false" /></div>
                    </div>
                </asp:Panel>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="Placówka - Zamówienia">
        <ContentTemplate>
            <sfasystem:OrderList ID="OrderList" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>

</asp:Content>

