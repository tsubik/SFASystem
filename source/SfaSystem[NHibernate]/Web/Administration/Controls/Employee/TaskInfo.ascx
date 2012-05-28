<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaskInfo.ascx.cs" Inherits="Administration_Controls_Employee_EmployeeTaskInfo" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectEmployeeControl" Src="~/Administration/Controls/Employee/SelectEmployeeControl.ascx" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectTaskStatus" Src="~/Administration/Controls/Employee/SelectTaskStatus.ascx" %>
<table class="adminContent">
    <tbody>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="tipTaskName" Text="Nazwa:" ToolTip="Nazwa zadania."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtName" runat="server" ErrorMessage="Nazwa jest obowiązkowa" Width="200px" />
            </td>
        </tr>
         <tr runat="server" id="trStatus">
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel7" Text="Status zadania:"
                    ToolTip="Status zadania." ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:SelectTaskStatus ID="ctrlSelectStatus" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel2" Text="Opis:" ToolTip="Opis zadania."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:TextBox ID="txtDescription" runat="server" Width="300" Height="100" TextMode="MultiLine" />
            </td>
        </tr>
        <tr runat="server" id="trCreatedBy">
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="tipCreatedBytip" Text="Utworzono przez:"
                    ToolTip="Utworzono przez." ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:Label ID="lblCreatedBy" runat="server" />
            </td>
        </tr>
        <tr runat="server" id="trCreatedDate">
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Data utworzenia:"
                    ToolTip="Data utworzenia." ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:Label ID="lblCreatedDate" runat="server" />
            </td>
        </tr>
        <tr runat="server" id="trGivenBy">
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel3" Text="Przydzielił:" ToolTip="Przydzielił."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:Label ID="lblGivenBy" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="tipAssignedTo" Text="Przedzielono:" ToolTip="Przedzielono."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:SelectEmployeeControl ID="ctrlSelectAssignedTo" EmptyItemText="Wybierz..."
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="tipProdGroup" Text="Do ukończenia przed:"
                    ToolTip="Do ukończenia przed." ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:Panel ID="panelAddEndDate" runat="server">
                    <asp:TextBox runat="server" ID="txtEndDate" />
                    <asp:ImageButton runat="Server" ID="iEndDate" ImageUrl="~/images/Calendar_scheduleHS.png"
                        AlternateText="Click to show calendar" />
                    <ajaxToolkit:CalendarExtender ID="cEndDateButtonExtender" runat="server" TargetControlID="txtEndDate"
                        PopupButtonID="iEndDate" />
                </asp:Panel>
                <asp:Panel ID="panelViewEndDate" runat="server">
                    <asp:Label ID="lblEndDate" runat="server" />
                </asp:Panel>
            </td>
        </tr>
        <tr runat="server" id="trDateExecuted">
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel4" Text="Data ukończenia:"
                    ToolTip="Data ukończenia." ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:Label ID="lblDateExecuted" runat="server" />
            </td>
        </tr>
        <tr runat="server" id="trIsApproved">
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel5" Text="Potwierdzenie:" ToolTip="Potwierdź wykonanie zadania."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:CheckBox ID="chxApprove" runat="server" />
            </td>
        </tr>
        <tr runat="server" id="trApprovedBy">
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel6" Text="Potwierdził:" ToolTip="Potwierdzono przez."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:Label ID="lblApprovedBy" runat="server" />
            </td>
        </tr>
       
    </tbody>
</table>
