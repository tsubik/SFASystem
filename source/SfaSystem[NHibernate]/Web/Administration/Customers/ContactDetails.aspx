<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="ContactDetails.aspx.cs" Inherits="Administration_Customers_ContactDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-catalog.png") %>" alt="Category" />
        Edycja kontaktu<a href="<%=ResolveUrl("~/Administration/Customers/CustomerContacts.aspx") %>"
            title="Powrót do listy kontaktów">(Powrót do listy kontaków)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Save"
            ToolTip="Save changes to this category" OnClick="SaveButton_Click" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="CategoryTabs" ActiveTabIndex="1">
    <ajaxToolkit:TabPanel runat="server" ID="pnlCategoryInfo" HeaderText="Kontakt">
        <ContentTemplate>
            <sfasystem:ContactInfo ID="ctrlContactInfo" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Klient - placówki">
        <ContentTemplate>
            <asp:UpdatePanel ID="updatePanel" runat="server">
                <ContentTemplate>
                    <h3>
                        Kontakt skojarzony z</h3>
                    <sfasystem:SelectCustomerControl ID="ctrlSelectCustomer" runat="server" AutoPostBack="true"  />
                    <asp:Panel ID="panelPlacowki" runat="server" Visible="false">
                    <h3>
                        Dodaj placówkę</h3>
                    <sfasystem:SelectCustomerFacility ID="ctrlSelectFacility" runat="server" />
                    <asp:Button ID="btnAddNew" runat="server" CssClass="adminButtonBlue" Text="Dodaj nową placówkę"
                        OnClick="btnAddNew_Click" />
                    </asp:Panel>
                    <h3>
                        Lista placówek</h3>
                    <sfasystem:CustomerFacilityList ID="ctrlFacilityList" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

