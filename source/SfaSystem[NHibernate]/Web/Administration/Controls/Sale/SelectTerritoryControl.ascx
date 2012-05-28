<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectTerritoryControl.ascx.cs" Inherits="Administration_Controls_Sale_SelectTerritoryControl" %>

<asp:DropDownList runat="server" ID="ddlTerritories">
</asp:DropDownList>

<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="ddlTerritories" Font-Name="verdana"
    Font-Size="9pt" runat="server" Display="None"></asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />