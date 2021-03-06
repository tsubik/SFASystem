﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="ProductGroupAdd.aspx.cs" Inherits="Administration_Products_ProductGroupAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-catalog.png") %>" alt="" />
        Add product group<a href="<%=ResolveUrl("~/Administration/Products/ProductGroups.aspx") %>" title="Powrót do grup produktów">(Powrót do grup produktów)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Save"
            OnClick="SaveButton_Click" ToolTip="Save changes to this category" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="CategoryTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlCategoryInfo" HeaderText="Informacje">
        <ContentTemplate>
            <sfasystem:ProductGroupInfo ID="ctrlProductGroupInfo" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

