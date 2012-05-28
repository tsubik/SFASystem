﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="ProductAdd.aspx.cs" Inherits="Administration_Products_ProductAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
         <img src="<%=ResolveUrl("~/Administration/Common/ico-catalog.png") %>" alt="" />
        Dodawanie produktu <a href="<%=ResolveUrl("~/Administration/Products/Products.aspx") %>" title="Powrót do listy produktów">(Powrót do listy produktów)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
            OnClick="SaveButton_Click" ToolTip="Zapisz zmiany" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="ProductTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductInfo" HeaderText="Produkt - informacje">
        <ContentTemplate>
            <sfasystem:ProductInfo ID="ctrlProductInfo" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

