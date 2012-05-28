<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerReport.aspx.cs" Inherits="Administration_Reports_CustomerReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-reports.png")%>" alt="Sprzedaż" />
            Raport - zestawienie klientów firmy
        </div>
        <div class="options">
           
        </div>
    </div>
    <table>
       
    </table>
    <p>
    </p>


    <rsweb:ReportViewer ID="rvCustomers" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Width="100%">
        <LocalReport ReportPath="Administration\Reports\CustomerReport.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Customer" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="Customer1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetAll" 
        TypeName="SFASystem.DataAccess.SqlServerNH.CustomerRepository">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetCustomers" TypeName="SFASystem.Services.CustomerService">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="name" Type="String"></asp:Parameter>
            <asp:Parameter DefaultValue="" Name="nip" Type="String"></asp:Parameter>
            <asp:Parameter DefaultValue="" Name="regon" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

