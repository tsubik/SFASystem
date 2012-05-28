<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="TaskAdd.aspx.cs" Inherits="Administration_Employees_EmployeeTaskAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
        Dane zadania <a href="<%=ResolveUrl("~/Administration/Employees/Tasks.aspx") %>" title="Back to employees list">(powrót do listy zadań)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz" OnClick="SaveButton_Click"
            ToolTip="Zapisz zadanie" />
            
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="TaskTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlTaskInfo" HeaderText="Informacje">
        <ContentTemplate>
            <sfasystem:TaskInfo runat="server" ID="ctrlTaskInfo" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

