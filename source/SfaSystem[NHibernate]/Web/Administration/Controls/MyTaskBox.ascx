<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyTaskBox.ascx.cs" Inherits="Administration_Controls_MyTask" %>
<div class="dashboard_box task_box">
    <div class="title">
        Sprawy do załatwienia
    </div>
    <div class="content">
        <asp:ListView ID="lstTasks" runat="server" OnItemDataBound="lstTasks_ItemDataBound">
            <LayoutTemplate>
                <ul>
                   <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
            <li>
                <a href='<%=ResolveUrl("~/Administration/Employees/TaskDetails.aspx") %>?TaskID=<%#Eval("Taskid")%>'>
                    <%#Eval("Name")%>  </a> zlecił <%#Eval("GivenBy")%> <asp:Label ID="lblDateTime" runat="server" />
                </li>
            </ItemTemplate>
            <EmptyDataTemplate>
                Brak zleceń
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
    <div style="float: right;">
        <a href="<%=ResolveUrl("~/Administration/Employees/Tasks.aspx") %>">więcej...</a>
    </div>
</div>
