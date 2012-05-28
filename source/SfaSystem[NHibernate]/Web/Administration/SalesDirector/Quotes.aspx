<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Quotes.aspx.cs" Inherits="Administration_SalesDirector_Quotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-products.png")%>" alt="Products" />
            Lista cytatów
        </div>
        <div class="options">
            <asp:Button ID="btnAddNew" runat="server" Text="Dodaj nowy cytat" CssClass="adminButtonBlue"
                ToolTip="Dodaj nowe zadania" OnClick="btnAddNew_Click" />
        </div>
    </div>
    <p>
    </p>
    <sfasystem:QuoteList ID="ctrlQuote" runat="server" />
</asp:Content>

