<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectProductGroupControl.ascx.cs" Inherits="Administration_Controls_SelectProductGroupControl" %>
<asp:DropDownList runat="server" ID="ddlProductGroups">
</asp:DropDownList>

<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="ddlProductGroups" Font-Name="verdana"
    Font-Size="9pt" runat="server" Display="None"></asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />