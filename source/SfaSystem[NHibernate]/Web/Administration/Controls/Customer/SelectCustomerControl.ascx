<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectCustomerControl.ascx.cs" Inherits="Administration_Controls_Customer_SelectCustomerControl" %>
<asp:DropDownList runat="server" ID="ddlCustomers">
</asp:DropDownList>

<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="ddlCustomers" Font-Name="verdana"
    Font-Size="9pt" runat="server" Display="None"></asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />