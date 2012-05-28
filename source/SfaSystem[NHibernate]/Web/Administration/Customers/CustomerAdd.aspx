<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerAdd.aspx.cs" Inherits="Administration_Customers_CustomerAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
   <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
        Dane kontrahenta <a href="<%=ResolveUrl("~/Administration/Customers/Customers.aspx") %>" title="Powrót do listy klientów">(powrót do listy klientów)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
            ToolTip="Zapisz zmiany" OnClick="SaveButton_Click" />    
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="EmployeeTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeInfo" HeaderText="Informacje">
        <ContentTemplate>
            <sfasystem:CustomerInfo runat="server" ID="ctrlCustomerInfo" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

