<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeesList.ascx.cs"
    Inherits="SFASystem.Web.Administration.Controls.EmployeesListControl" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectRoleControl" Src="~/Administration/Controls/Employee/SelectRoleControl.ascx" %>
<div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
        Lista pracowników
    </div>
    <div class="options">
        <asp:Button ID="btnSearch" runat="server" Text="Filtruj" CssClass="adminButtonBlue"
            OnClick="btnSearch_Click" ToolTip="Wyszukaj pracowników według podanych kryteriów" />
        <asp:Button ID="btnRemoveFilter" runat="server" Text="Usuń filtr" CssClass="adminButtonBlue"
            OnClick="btnRemoveFilter_Click" ToolTip="Usuń wybrane filtry" />
        <asp:Button ID="btnAddNew" runat="server" CssClass="adminButtonBlue" Text="Dodaj pracownika"
            OnClick="btnAddNew_Click" />
    </div>
</div>
<table>
    <tr>
        <td>
            <sfasystem:ToolTipLabel runat="server" ID="lblProductName" Text="Stanowisko:" ToolTip="Stanowisko"
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td>
            <sfasystem:SelectRoleControl ID="selectRoleControl" runat="server" Width="150px"
                EmptyItemText="Wybierz..." />
        </td>
    </tr>
</table>
<p>
</p>
<asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" Width="100%"
    OnPageIndexChanging="gvEmployees_PageIndexChanging" AllowPaging="true" PageSize="15"
    OnRowDataBound="gvEmployees_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="Imię">
            <ItemTemplate>
                <asp:Label ID="lblImie" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nazwisko">
            <ItemTemplate>
                <asp:Label ID="lblNazwisko" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="true" DataField="Login" HeaderText="Login" />
        <asp:TemplateField HeaderText="Stanowisko">
            <ItemTemplate>
                <asp:Label ID="lblStanowisko" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="true" DataField="CreationDate" HeaderText="Utworzenie konta" />
        <asp:BoundField ReadOnly="true" DataField="LastActivityDate" HeaderText="Ostatnia aktywność" />
        <asp:TemplateField HeaderText="Edycja" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a href="EmployeeDetails.aspx?EmployeeID=<%#Eval("EmployeeID")%>" title="Edit employee details">
                    Edycja </a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
