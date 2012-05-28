﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductGroupTree.ascx.cs" Inherits="Administration_Controls_ProductGroupList" %>
<div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-catalog.png") %>" alt="" />
        Grupy produktów
    </div>
    <div class="options">
        
    </div>
</div>
<p>
</p>
<asp:TreeView ID="ProductGroupTreeView" runat="server" AutoGenerateDataBindings="False"
    ExpandDepth="0" DataSourceID="ds" 
    onselectednodechanged="ProductGroupTreeView_SelectedNodeChanged">
    <DataBindings>
        <asp:TreeNodeBinding TextField="title" NavigateUrlField="url" />
    </DataBindings>
</asp:TreeView>
<asp:XmlDataSource ID="ds" EnableCaching="false" runat="server" XPath="/*/*"></asp:XmlDataSource>
