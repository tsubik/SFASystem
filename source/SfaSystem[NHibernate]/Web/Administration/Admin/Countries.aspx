<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Countries.aspx.cs" Inherits="Administration_Countries" %>
<%@ Register TagPrefix="sfasystem" TagName="CountryList" Src="~/Administration/Controls/CountryList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Common/ico-configuration.png" alt="Countries" />
            Lista krajów
        </div>
    </div>
    <sfasystem:CountryList ID="CountryList" runat="server" />
</asp:Content>
