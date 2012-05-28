<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="TerritoryAdd.aspx.cs" Inherits="Administration_Sales_TerritoryAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-region.png") %>" alt="Region" />
        Dodawanie regionu sprzedaży <a href="<%=ResolveUrl("~/Administration/Sales/Territories.aspx") %>" title="Powrót do listy regionów">(Powrót do listy regionów)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
            OnClick="SaveButton_Click" ToolTip="Zapisz zmiany w obecnym regionie" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="CategoryTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlCategoryInfo" HeaderText="Region informacje">
        <ContentTemplate>
            <sfasystem:TerritoryInfo ID="ctrlTerritoryInfo" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

