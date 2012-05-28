<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="QuoteAdd.aspx.cs" Inherits="Administration_SalesDirector_QuoteAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
            Dodawanie cytatu <a href="<%=ResolveUrl("~/Administration/SalesDirector/Quotes.aspx") %>"
                title="Back to employees list">(powrót do listy cytatów)</a>
        </div>
        <div class="options">
            <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
                OnClick="SaveButton_Click" ToolTip="Zapisz zadanie" />
        </div>
    </div>
    <ajaxToolkit:TabContainer runat="server" ID="TaskTabs" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" ID="pnlTaskInfo" HeaderText="Informacje">
            <ContentTemplate>
                <sfasystem:QuoteInfo runat="server" ID="ctrlQuoteInfo" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
