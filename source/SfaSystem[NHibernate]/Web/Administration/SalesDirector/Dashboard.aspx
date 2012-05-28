<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Administration_SalesDirector_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="homepage">
        <div class="lefsidewrapper">
        <div class="leftside">
            <sfasystem:MyTasksBox ID="ctrlMyTaskBox" runat="server" />
            <sfasystem:TaskToApproveBox ID="ctrlTaskToApproveBox" runat="server" />
            <sfasystem:SalesDirTop10List ID="ctrlSalesDirTop10List" runat="server" />
        </div>
        </div>
        <div class="rightside">
            <sfasystem:ChartAllSalesByMonth ID="chartAllSalesByMonth" runat="server" />
            <sfasystem:SalesProdGroupChart ID="chartSalesProdGroup" runat="server" />
        </div>
    </div>
</asp:Content>

