<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeInfo.ascx.cs"
    Inherits="SFASystem.Web.Administration.Controls.EmployeeInfoControl" %>
<%@ Register TagName="TextBox" TagPrefix="sfasystem" Src="~/Administration/Controls/TextBoxControl.ascx" %>
<%@ Register TagPrefix="sfasystem" TagName="ControlSelectCountry" Src="~/Administration/Controls/SelectCountryControl.ascx" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>

<div class="EmployeeInfoBox">
    <div class="SectionTitle">
        Dane personalne
    </div>
    <div class="clear">
    </div>
    <div class="SectionBody">
        <table class="TableContainer">
            <tbody>
                <tr class="Row">
                    <td class="ItemName">
                        Imię:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="Imię jest obowiązkowe." ToolTip="Imie jest obowiązkowe" ValidationGroup="EmployeeInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemName">
                        Nazwisko:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                            ErrorMessage="Nazwisko jest obowiązkowe." ToolTip="Nazwisko jest obowiązkowe."
                            ValidationGroup="EmployeeInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemName">
                        Login w systemie:
                    </td>
                    <td class="ItemValue">
                        <asp:Label ID="lblLogin" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="clear">
    </div>
    <asp:Panel ID="panelNewEmployee" runat="server" Visible="false">
        <div class="SectionTitle">
            Dane systemowe
        </div>
        <div class="clear">
        </div>
        <div class="SectionBody">
            <table class="TableContainer">
                <tbody>
                    <tr class="Row">
                        <td class="ItemName">
                            Login:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:TextBox ID="txtLogin" runat="server" ErrorMessage="Login jest obowiązkowy" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Hasło:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:TextBox ID="txtPassword" runat="server" ErrorMessage="Hasło jest obowiązkowe"
                                TextMode="Password" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Potwierdź:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:TextBox ID="txtConfirmPassword" runat="server" ErrorMessage="Potwierdzenie hasła jest obowiązkowe"
                                TextMode="Password" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Menadżer:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:SelectEmployeeControl ID="ctrlSelectEmployee" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="clear">
        </div>
    </asp:Panel>
    <div class="SectionTitle">
        Adres zamieszkania
    </div>
    <div class="clear">
    </div>
    <div class="SectionBody">
        <table class="TableContainer">
            <tbody>
                <tr class="Row">
                    <td class="ItemName">
                        Ulica:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtStreetAddress" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvStreetAddress" runat="server" ControlToValidate="txtStreetAddress"
                            ErrorMessage="Ulica jest obowiązkowa." ToolTip="Ulica jest obowiązkowa." ValidationGroup="EmployeeInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemName">
                        Nr domu/mieszkania:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtHouse" runat="server" Width="30"></asp:TextBox>/<asp:TextBox
                            ID="txtApartment" runat="server" Width="30" />
                        <asp:RequiredFieldValidator ID="rfvHouse" runat="server" ControlToValidate="txtHouse"
                            ErrorMessage="Numer domu jest obowiązkowy." ToolTip="Numer domu jest obowiązkowy."
                            ValidationGroup="EmployeeInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemName">
                        Kod pocztowy:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtZipPostalCode" runat="server" Width="60"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvZipPostalCode" runat="server" ControlToValidate="txtZipPostalCode"
                            ErrorMessage="Kod pocztowy jest obowiązkowy." ToolTip="Kod pocztowy jest obowiązkowy."
                            ValidationGroup="EmployeeInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <asp:UpdatePanel ID="updateCity" runat="server">
                    <ContentTemplate>
                        <tr class="Row">
                            <td class="ItemName">
                                Miasto:
                            </td>
                            <td class="ItemValue">
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                                    ErrorMessage="Miasto jest obowiązkowe." ToolTip="Miasto jest obowiązkowe." ValidationGroup="EmployeeInfo">*</asp:RequiredFieldValidator>
                                <ajaxToolkit:AutoCompleteExtender ID="autoCompleteExt" TargetControlID="txtCity"
                                    runat="server" ServicePath="~/Administration/WebServices/AutoCompleteCityService.asmx"
                                    CompletionInterval="100" ServiceMethod="GetCitiesList" MinimumPrefixLength="2"
                                    CompletionSetCount="10" />
                            </td>
                        </tr>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <tr class="Row">
                    <td class="ItemName">
                        Kraj:
                    </td>
                    <td class="ItemValue">
                        <sfasystem:ControlSelectCountry ID="ctrlSelectCountry" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="clear">
    </div>
    <div class="SectionTitle">
        Informacje kontaktowe
    </div>
    <div class="clear">
    </div>
    <div class="SectionBody">
        <table class="TableContainer">
            <tbody>
                <tr class="Row">
                    <td class="ItemName">
                        Numer telefonu:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                            ErrorMessage="Numer telefonu jest obowiązkowy." ToolTip="Numer telefonu jest obowiązkowy."
                            ValidationGroup="EmployeeInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemName">
                        Adres email:
                    </td>
                    <td class="ItemValue">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Email jest obowiązkowy." ToolTip="Email jest obowiązkowy." ValidationGroup="EmployeeInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="clear">
    </div>
    
</div>
