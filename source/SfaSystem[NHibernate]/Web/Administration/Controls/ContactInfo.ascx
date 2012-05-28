<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactInfo.ascx.cs" Inherits="Administration_Controls_ContactInfo" %>
<%@ Register TagPrefix="sfasystem" TagName="TextBox" Src="~/Administration/Controls/TextBoxControl.ascx" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem"
    TagName="ToolTipLabel" %>
<%--<asp:Panel ID="panelDisplay" runat="server">
    <div class="EmployeeInfoBox">
        <div class="SectionBody">
            <table class="TableContainer">
                <tbody>
                    <tr class="Row">
                        <td class="ItemName">
                            Imie Nazwisko:
                        </td>
                        <td class="ItemValue">
                            <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Email:
                        </td>
                        <td class="ItemValue">
                            <asp:Literal ID="lblEmail" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Telefon:
                        </td>
                        <td class="ItemValue">
                            <asp:Literal ID="lblPhone" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Panel>--%>
<table class="adminContent">
    <tbody>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblFirstname2" Text="Imię:" ToolTip="Imię"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtFirstName" runat="server" ErrorMessage="Imię jest obowiazkowe" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblLastName2" Text="Nazwisko:" ToolTip="Nazwisko."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtLastName" runat="server" ErrorMessage="Nazwisko jest obowiazkowe" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblEmail2" Text="Email:" ToolTip="Nazwa produktu."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtEmail" runat="server" ErrorMessage="Email jest obowiązkowy" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <sfasystem:ToolTipLabel runat="server" ID="lblPhone2" Text="Telefon:" ToolTip="Telefon."
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <sfasystem:TextBox ID="txtPhone" runat="server" ErrorMessage="telefon jest obowiązkowy" />
            </td>
        </tr>
        
        
    </tbody>
</table>
