<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Employees.aspx.cs" Inherits="Administration_Employees" %>
<%@ Register TagPrefix="sfasystem" TagName="EmployeeList" Src="~/Administration/Controls/Employee/EmployeesList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <sfasystem:EmployeeList ID="employeeList" runat="server" />
</asp:Content>

