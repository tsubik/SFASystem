<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaskToApproveBox.ascx.cs" Inherits="Administration_Controls_TaskToApproveBox" %>
<div class="dashboard_box task_to_approve_box">
    <div class="title">
        Zadania do zatwierdzenia
    </div>
    <div class="content">
        <asp:ListView ID="lstTasks" runat="server">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
            <li runat="server">
                <a href='<%=ResolveUrl("~/Adminstration/Employees/TaskDetails.aspx") %>?TaskID=<%#Eval("Taskid")%>'><%#Eval("Name")%></a> Wykonane przez <%#Eval("AssignedTo")%> <%#Eval("DateExecuted") %>
            </li>
            </ItemTemplate>
            <EmptyDataTemplate>
                Brak zadań do zatwierdzenia.
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
</div>