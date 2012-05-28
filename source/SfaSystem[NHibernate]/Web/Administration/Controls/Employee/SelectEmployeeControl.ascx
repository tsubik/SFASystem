<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectEmployeeControl.ascx.cs" Inherits="Administration_Controls_Employee_SelectEmployeeControl" %>
<asp:DropDownList runat="server" ID="ddlEmployees" >
</asp:DropDownList>

<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="ddlEmployees" Font-Name="verdana"
    Font-Size="9pt" runat="server" Display="None"></asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />