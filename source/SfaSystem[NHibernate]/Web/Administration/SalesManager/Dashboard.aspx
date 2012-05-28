<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Administration_SalesManager_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="homepage">
        <div class="lefsidewrapper">
            <div class="leftside">
                <sfasystem:MyTasksBox ID="ctrlMyTaskBox" runat="server" />
                <sfasystem:TaskToApproveBox ID="ctrlTaskToApproveBox" runat="server" />
            </div>
        </div>
        <div class="rightside">
            <sfasystem:BestSalesRepByManChart ID="chartBestSalesRepByManChart" runat="server" />
            <sfasystem:MySalesManSalesChart ID="chartMySalesManSalesChart" runat="server" />
        </div>
    </div>
</asp:Content>
