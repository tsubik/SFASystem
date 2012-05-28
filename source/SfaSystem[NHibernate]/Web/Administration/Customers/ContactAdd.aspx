<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="ContactAdd.aspx.cs" Inherits="Administration_Customers_ContactAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-catalog.png") %>" alt="Category" />
        Dodawanie kontaktu<a href="<%=ResolveUrl("~/Adminstration/Customers/CustomerContacts.aspx") %>"
            title="Powrót do listy kontaktów">(Powrót do listy kontaków)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Save"
            ToolTip="Save changes to this category" OnClick="SaveButton_Click" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="CategoryTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlCategoryInfo" HeaderText="Category Info">
        <ContentTemplate>
            <sfasystem:ContactInfo ID="ctrlContactInfo" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

