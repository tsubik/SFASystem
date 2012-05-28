<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeAdd.aspx.cs" Inherits="Administration_Employees_EmployeeAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
        Dane pracownika <a href="<%=ResolveUrl("~/Administration/Employees/Employees.aspx") %>" title="Back to employees list">(powrót do listy pracowników)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
            ToolTip="Zapisz zmiany" />
        <asp:Button ID="DeleteButton" runat="server" CssClass="adminButtonBlue" Text="Usuń"
            CausesValidation="false" ToolTip="Usuń pracownika" />
            
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="EmployeeTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeInfo" HeaderText="Informacje">
        <ContentTemplate>
            <sfasystem:EmployeeInfo runat="server" ID="ctrlEmployeeInfo" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

