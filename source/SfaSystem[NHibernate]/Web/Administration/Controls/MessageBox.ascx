<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MessageBox.ascx.cs" Inherits="MessageBoxControl" %>
<div class="container">
    <asp:Panel ID="MessageBox" runat="server">
        <asp:HyperLink runat="server" ID="CloseButton">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/administration/images/messageBox/close.png" AlternateText="Kliknij aby zamknąć" />
        </asp:HyperLink>
        <p>
            <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        </p>
    </asp:Panel>
</div>