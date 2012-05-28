<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Customers.aspx.cs" Inherits="Administration_Customers" %>
<%@ Register TagPrefix="sfasystem" TagName="CustomerList" Src="~/Administration/Controls/Customer/CustomersList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <sfasystem:CustomerList ID="ctrlCustomerList" runat="server" />
</asp:Content>

