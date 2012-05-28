<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="ProductGroups.aspx.cs" Inherits="Administration_Products_ProductGroups" %>

<%@ Register Src="~/Administration/Controls/Product/ProductGroupTree.ascx" TagPrefix="sfasystem"
    TagName="ProductGroupTree" %>
<%@ Register TagPrefix="sfasystem" TagName="NewProductGroupTree" Src="~/Administration/Controls/Product/NewProductGroupTree.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <sfasystem:ProductGroupTree ID="ProductGroupTree" runat="server" />
    <%--    <sfasystem:ProductGroupAdd ID="ctrlProductGroupAdd" runat="server" Visible="false" />
    <sfasystem:ProductGroupDetails ID="ctrl{
    <%--<sfasystem:ProductGroupTree ID="ProductGroupTree" runat="server" />--%>
</asp:Content>
