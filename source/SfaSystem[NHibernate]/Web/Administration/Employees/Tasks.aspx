<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Tasks.aspx.cs" Inherits="Administration_Employees_EmployeeTasks" %>

<%@ Register TagPrefix="sfasystem" TagName="TaskList" Src="~/Administration/Controls/Employee/TaskList.ascx" %>
<%@ Register Src="~/Administration/Controls/Employee/SelectEmployeeControl.ascx"
    TagPrefix="sfasystem" TagName="SelectEmployeeControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-tasks.png")%>" alt="Products" />
            Lista zadań
        </div>
        <div class="options">
            <asp:Button ID="btnSearch" runat="server" Text="Filtruj" CssClass="adminButtonBlue"
                ToolTip="Filtruj" OnClick="btnSearch_Click" />
            <asp:Button ID="btnRemoveFilter" runat="server" Text="Usuń filtr" CssClass="adminButtonBlue"
                ToolTip="Usuń filtry" OnClick="btnRemoveFilter_Click" />
            <asp:Button ID="btnAddNew" runat="server" Text="Dodaj nowe zadanie" CssClass="adminButtonBlue"
                ToolTip="Dodaj nowe zadania" OnClick="btnAddNew_Click" />
        </div>
    </div>
    <table>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="lblAssignedTo" Text="Przydzielono do:"
                    ToolTip="Przydzielono do" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectEmployeeControl ID="ctrlSelectAssignedTo" runat="server" EmptyItemText="Wybierz..." Width="120px" />
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Przydzielono przez:"
                    ToolTip="Przydzielono przez" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectEmployeeControl ID="ctrlSelectGivenBy" runat="server" EmptyItemText="Wybierz..." Width="120px" />
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel2" Text="Utworzono przez:"
                    ToolTip="Utworzono przez" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectEmployeeControl ID="ctrlSelectCreatedBy" runat="server" EmptyItemText="Wybierz..." Width="120px" />
            </td>
        </tr>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel3" Text="Status:" ToolTip="Status"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectTaskStatus runat="server" ID="ctrlTaskStatus" EmptyItemText="Wszystkie" Width="120px" />
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel4" Text="Pokaz tylko zatwierdzone:"
                    ToolTip="Pokazuje tylko zatwierdzone zadania" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:CheckBox ID="chxApproved" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel5" Text="Data utworzenia od:"
                    ToolTip="Pokaz tylko od tej daty" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtStartDate" Width="100px" />
                <asp:ImageButton runat="Server" ID="iStartDate" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <ajaxToolkit:CalendarExtender ID="cStartDateButtonExtender" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="iStartDate" />
            </td>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel6" Text="Data utworzenia do:"
                    ToolTip="Pokaz tylko do tej daty" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEndDate" Width="100px" />
                <asp:ImageButton runat="Server" ID="iEndDate" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <ajaxToolkit:CalendarExtender ID="cEndDateButtonExtender" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="iEndDate" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <sfasystem:TaskList ID="ctrlTaskList" runat="server" />
</asp:Content>
