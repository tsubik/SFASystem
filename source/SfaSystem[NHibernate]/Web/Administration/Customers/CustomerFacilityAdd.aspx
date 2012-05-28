<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerFacilityAdd.aspx.cs" Inherits="Administration_Customers_CustomerFacilityAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
<img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
        Dodawanie placówki<a href="<%=ResolveUrl("~/Administration/Customers/CustomerFacilities.aspx") %>" title="Powrót do listy placówek">(Powrót do listy placówek)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Save"
             ToolTip="Save changes to this category" onclick="SaveButton_Click" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="CategoryTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlCategoryInfo" HeaderText="Category Info">
        <ContentTemplate>
            <sfasystem:CustomerFacilityInfo ID="ctrlFacilityInfo" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

