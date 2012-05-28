<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Administration_SalesRepresentative_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="homepage">
        <div class="lefsidewrapper">
        <div class="leftside">
            <sfasystem:MyTasksBox ID="ctrlMyTaskBox" runat="server" />
            <sfasystem:TaskToApproveBox ID="ctrlTaskToApproveBox" runat="server" />
        </div>
        </div>
        <div class="rightside">
            <sfasystem:SalesRepSalesChart ID="chartSalesRepSales" runat="server" />
            <sfasystem:SalesRepBestCustomersChart ID="chartSalesRepBestCustomersChart" runat="server" />
        </div>
    </div>
</asp:Content>
