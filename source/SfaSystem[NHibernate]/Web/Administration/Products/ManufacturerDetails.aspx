<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="ManufacturerDetails.aspx.cs" Inherits="Administration_Products_ManufacturerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">

<div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-manufacturer.png") %>" alt="" />
        <asp:Literal ID="litTitle" runat="server" /> <a href="<%=ResolveUrl("~/Administration/Products/Manufacturers.aspx") %>" title="Powrót do listy producentów">(Powrót do listy producentów)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
            OnClick="SaveButton_Click" ToolTip="Zapisz zmiany" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="CategoryTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlCategoryInfo" HeaderText="Informacje">
        <ContentTemplate>
            <sfasystem:ManufacturerInfo ID="ctrlManufacturerInfo" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

