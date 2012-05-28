<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Territories.aspx.cs" Inherits="Administration_Territories" %>
<%@ Register TagPrefix="sfasystem" TagName="TerritoryTree" Src="~/Administration/Controls/Sale/TerritoryTree.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <sfasystem:TerritoryTree ID="ctrlTerritoryTree" runat="server" />
</asp:Content>

