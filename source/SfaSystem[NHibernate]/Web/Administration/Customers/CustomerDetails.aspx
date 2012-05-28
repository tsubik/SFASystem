<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="Administration_Customers_CustomerDetails" %>

<%@ MasterType VirtualPath="~/Administration/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
            Dane kontrahenta <a href="<%=ResolveUrl("~/Administration/Customers/Customers.aspx")%>"
                title="Powrót do listy klientów">(powrót do listy klientów)</a>
        </div>
        <div class="options">
            <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
                ToolTip="Zapisz zmiany" OnClick="SaveButton_Click" CausesValidation="false" />
            <asp:Button ID="DeleteButton" runat="server" CssClass="adminButtonBlue" Text="Usuń"
                OnClick="DeleteButton_Click" CausesValidation="false" ToolTip="Usuń klienta" />
        </div>
    </div>
    <ajaxToolkit:TabContainer runat="server" ID="EmployeeTabs" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeInfo" HeaderText="Informacje">
            <HeaderTemplate>
                Informacje
            </HeaderTemplate>
            <ContentTemplate>
                <sfasystem:CustomerInfo runat="server" ID="ctrlCustomerInfo" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlCustomerContact" HeaderText="Kontakty">
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
                        <sfasystem:ContactInfo ID="ctrlContactInfo" runat="server" />
                        <br />
                        <sfasystem:ToolTipLabel ID="lblPlacowka" runat="server" ToolTip="Wybierz placówkę"
                            ToolTipImage="~/Administration/Common/ico-help.gif" Text="Placówka: " />
                        <sfasystem:SelectCustomerFacility ID="ctrlSelectFacility" runat="server" EmptyItemText="Wybierz..." Width="170px" />
                        <br />
                        <br />
                        <sfasystem:ToolTipLabel ID="ToolTipLabel1" runat="server" ToolTip="Czy główny kontakt firmy"
                            ToolTipImage="~/Administration/Common/ico-help.gif" Text="Główny kontakt: " />
                        <asp:CheckBox ID="chxContactIsMain" runat="server" />
                        <br />
                        <br />
                        <div style="text-align: center">
                            <asp:Button ID="btnContactSave" runat="server" Text="Zapisz" CssClass="adminButtonGreen"
                                CausesValidation="true" OnClick="btnContactSave_Click" />
                            <asp:Button ID="btnContactCancel" runat="server" Text="Anuluj" CssClass="adminButtonRed"
                                CausesValidation="false" /></div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlCustomerFacilities" HeaderText="Placówki">
            <ContentTemplate>
                <sfasystem:CustomerFacilityList ID="ctrlFacilityList" runat="server" />
                <asp:Button ID="btnAddFacility" runat="server" CssClass="adminButton" Text="Dodaj placówkę"
                    OnClick="btnAddFacility_Click" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlCustomerOrders" HeaderText="Zamówienia historia">
            <ContentTemplate>
                <sfasystem:OrderList ID="OrderList" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    <%--<ajaxToolkit:ConfirmButtonExtender ID="ConfirmDeleteButtonExtender" runat="server"
        TargetControlID="btnAddContact" DisplayModalPopupID="ModalPopupExtenderDelete" />--%>
</asp:Content>
