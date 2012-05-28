<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectCustomerFacility.ascx.cs" Inherits="Administration_Controls_Customer_SelectCustomerFacility" %>
<asp:DropDownList runat="server" ID="ddlCustomersFacility">
</asp:DropDownList>

<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="ddlCustomersFacility" Font-Name="verdana"
    Font-Size="9pt" runat="server" Display="None"></asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />