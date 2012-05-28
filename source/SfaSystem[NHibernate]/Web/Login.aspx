<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SFASystem Web Administration</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="master-wrapper-page">
        <div class="master-wrapper-content">
            <div class="header">
                <div class="logo">
                </div>
                <div class="version">
                    <asp:Label runat="server" ID="lblHeader" />
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="content">
                <div class="cph">
                    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="LoginForm$LoginButton" CssClass="LoginBlock">
                        <asp:Login ID="LoginForm" TitleText="Logowanie do systemu" runat="server" DestinationPageUrl="~/Administration/Default.aspx"
                        FailureText="Błędny użytkownik lub hasło." FailureTextStyle-CssClass="loginFailure" >
                            <LayoutTemplate>
                                <table class="LoginTableContainer" cellspacing="0">
                                    <tbody>
                                        <tr class="RowHeaderStyle">
                                            <th colspan="2">
                                                Logowanie do systemu
                                            </th>
                                        </tr>
                                        <tr class="Row">
                                            <td class="ItemName">
                                                <asp:Literal runat="server" ID="lEMailAddress" Text="Użytkownik" />:
                                            </td>
                                            <td class="ItemValue">
                                                <asp:TextBox ID="UserName" runat="server" Width="150"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl00$LoginForm">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr class="Row">
                                            <td class="ItemName">
                                                <asp:Literal runat="server" ID="lPassword" Text="Hasło" />:
                                            </td>
                                            <td class="ItemValue">
                                                <asp:TextBox ID="Password" TextMode="Password" runat="server" MaxLength="50" Width="150"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl00$LoginForm">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr class="Row">
                                            <td class="messageError" colspan="2">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr class="Row">
                                            <td colspan="2">
                                                <div class="LoginButton">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Zaloguj" ValidationGroup="ctl00$LoginForm"
                                                        SkinID="LoginButton"/>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                        </asp:Login>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
