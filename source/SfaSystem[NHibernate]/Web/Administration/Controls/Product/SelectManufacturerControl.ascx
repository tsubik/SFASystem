<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectManufacturerControl.ascx.cs" Inherits="Administration_Controls_Product_SelectManufacturerControl" %>
<asp:DropDownList ID="ddlManufacturers" runat="server" />

<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="ddlManufacturers" Font-Name="verdana"
    Font-Size="9pt" runat="server" Display="None"></asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />