<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaskList.ascx.cs" Inherits="Administration_Controls_Employee_EmployeeTaskList" %>

<asp:GridView ID="gvTasks" runat="server" AutoGenerateColumns="False" Width="100%"
    OnPageIndexChanging="gvTasks_PageIndexChanging" OnRowDataBound="gvTasks_RowDataBound" 
    AllowPaging="true" RowStyle-Height="30"
    PageSize="15">
    <Columns>
        <asp:BoundField ReadOnly="true" DataField="Taskid" HeaderText="ID" Visible="false" />
        <asp:BoundField ReadOnly="true" DataField="Name" HeaderText="Nazwa" ItemStyle-Width="200" />
        <asp:BoundField ReadOnly="true" DataField="AssignedTo" HeaderText="Przydzielono do" ItemStyle-Width="50" />
        <asp:BoundField ReadOnly="true" DataField="DateToEndTask" HeaderText="Data zakończenia" ItemStyle-Width="80" /> 
        <asp:BoundField ReadOnly="true" DataField="GivenBy" HeaderText="Przydzielił" ItemStyle-Width="50" />
        <asp:BoundField ReadOnly="true" DataField="CreatedBy" HeaderText="Utworzono przez" ItemStyle-Width="50" />
        <asp:BoundField ReadOnly="true" DataField="DateCreated" HeaderText="Utworzono" ItemStyle-Width="80" />
        <asp:BoundField ReadOnly="true" DataField="DateExecuted" HeaderText="Wykonano" ItemStyle-Width="80" />
        <asp:BoundField ReadOnly="true" DataField="IsApproved" HeaderText="Czy zatwierdzono" ItemStyle-Width="50" />
        <asp:BoundField ReadOnly="true" DataField="ApprovedBy" HeaderText="Zatwierdził" ItemStyle-Width="50" />
        <asp:TemplateField HeaderText="Status zadania" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblStatus" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Edycja" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a href='<%#ResolveUrl("~/Administration/Employees/TaskDetails.aspx")%>?TaskID=<%#Eval("Taskid")%>' title="Edycja zadania">
                    Edycja </a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>