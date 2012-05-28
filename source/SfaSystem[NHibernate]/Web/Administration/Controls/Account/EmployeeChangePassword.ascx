<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeChangePassword.ascx.cs" Inherits="SFASystem.Web.Administration.Controls.EmployeeChangePasswordControl" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>

<div class="CustomerPassRecovery">
    <asp:Panel runat="server" ID="pnlChangePasswordError" CssClass="ErrorBlock">
        <div class="messageError">
            <asp:Literal ID="lChangePasswordErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
        </div>
    </asp:Panel>
    <div class="clear">
    </div>
    <div class="SectionBody">
        <table class="TableContainer">
            <tbody>
                <tr class="Row">
                    <td class="ItemName">
                        Stare hasło:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtOldPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword"
                            ErrorMessage="Stare hasło jest obowiązkowe." ToolTip="Stare hasło jest obowiązkowe."
                            ValidationGroup="ChangePassword" />
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemName">
                        Nowe hasło:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword"
                            ErrorMessage="Nowe hasło jest obowiązkowe." ToolTip="Nowe hasło jest obowiązkowe."
                            ValidationGroup="ChangePassword" />
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemName">
                        Powtórz nowe hasło:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                            ErrorMessage="Potwierdzenie nowego hasła jest obowiązkowe." ToolTip="Potwierdzenie nowego hasła jest obowiązkowe."
                            ValidationGroup="ChangePassword" />
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemValue" colspan="2">
                        <asp:CompareValidator ID="cvPasswordCompare" runat="server" ControlToCompare="txtNewPassword"
                            ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Wprowadzone hasło oraz potwierdzenie nie pasują do siebie"
                            ValidationGroup="ChangePassword" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="clear">
    </div>
    <div class="Button">
        <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" CssClass="adminButtonBlue"
            Text="Change password" ValidationGroup="ChangePassword" SkinID="ChangePasswordButton"/><br style="line-height: 1px;" />
    </div>
</div>
