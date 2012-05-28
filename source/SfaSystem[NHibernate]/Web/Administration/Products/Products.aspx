<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Administration_Products_Products" %>
<%@ Register TagPrefix="sfasystem" TagName="ProductList" Src="~/Administration/Controls/Product/ProductList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <sfasystem:ProductList ID="ctrlProductList" runat="server" />
</asp:Content>

