<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Administration_Account" %>

<%@ Register TagPrefix="sfasystem" TagName="EmployeeInfo" Src="~/Administration/Controls/Account/EmployeeInfo.ascx" %>
<%@ Register TagPrefix="sfasystem" TagName="EmployeeAdditional" Src="~/Administration/Controls/Account/EmployeeAdditional.ascx" %>
<%@ Register TagPrefix="sfasystem" TagName="EmployeeChangePassword" Src="~/Administration/Controls/Account/EmployeeChangePassword.ascx" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-account.png") %>" alt="" />
            Edycja konta osobistego
        </div>
        <div class="options">
            <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
                ToolTip="Zapisz zmiany" />
        </div>
    </div>
    <ajaxToolkit:TabContainer runat="server" ID="AccountTabs" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeInfo" HeaderText="Informacje podstawowe">
            <ContentTemplate>
                <sfasystem:EmployeeInfo ID="employeeInfo" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeAdditionalInfo" HeaderText="Informacje dodatkowe">
            <ContentTemplate>
                <sfasystem:EmployeeAdditional ID="employeeAdditional" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeChangePassword" HeaderText="Zmiana hasła">
            <ContentTemplate>
                <sfasystem:EmployeeChangePassword ID="employeeChangePassword" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
