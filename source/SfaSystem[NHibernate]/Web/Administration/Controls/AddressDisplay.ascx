<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddressDisplay.ascx.cs"
    Inherits="SFASystem.Web.Administration.Controls.AddressDisplayControl" %>
<%@ Register TagPrefix="sfasystem" TagName="TextBox" Src="~/Administration/Controls/TextBoxControl.ascx" %>
<%@ Register TagPrefix="sfasystem" TagName="SelectCountryControl" Src="~/Administration/Controls/SelectCountryControl.ascx" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>

<asp:Panel ID="pnlShow" runat="server">
    <div class="EmployeeInfoBox">
        <div class="SectionBody">
            <table class="TableContainer">
                <tbody>
                    <tr class="Row">
                        <td class="ItemName">
                            Ulica:
                        </td>
                        <td class="ItemValue">
                            <asp:Literal ID="lblStreet" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Nr. dom/Nr mieszk.:
                        </td>
                        <td class="ItemValue">
                            <asp:Literal ID="lblHouseApartment" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Kod pocztowy:
                        </td>
                        <td class="ItemValue">
                            <asp:Literal ID="lblZipCode" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Miasto:
                        </td>
                        <td class="ItemValue">
                            <asp:Literal ID="lblCity" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Kraj:
                        </td>
                        <td class="ItemValue">
                            <asp:Literal ID="lblCountry" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            <asp:Button ID="btnEdit" runat="server" CssClass="adminButton" Text="Edytuj" 
                                onclick="btnEdit_Click" />
                        </td>
                        <td class="ItemValue">
                            
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="pnlEdit" runat="server" Visible="false">
    <div class="EmployeeInfoBox">
        <div class="SectionBody">
            <table class="TableContainer">
                <tbody>
                    <tr class="Row">
                        <td class="ItemName">
                            Ulica:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:TextBox ID="txtStreet" runat="server" ErrorMessage="Ulica jest obowiązkowa" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Nr. dom/Nr mieszk.:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:TextBox ID="txtHouseNr" runat="server" ErrorMessage="Numer domu" Width="20" />
                            /
                            <asp:TextBox ID="txtApartmentNr" runat="server" Width="20" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Kod pocztowy:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:TextBox ID="txtZipCode" runat="server" ErrorMessage="Kod pocztowy jest obowiązkowy"
                                Width="100" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Miasto:
                        </td>
                        <td class="ItemValue">
                            <asp:TextBox ID="txtCity" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                                    ErrorMessage="Miasto jest obowiązkowe." ToolTip="Miasto jest obowiązkowe." ValidationGroup="EmployeeInfo">*</asp:RequiredFieldValidator>
                            <ajaxToolkit:AutoCompleteExtender ID="autoCompleteExt" TargetControlID="txtCity"
                                runat="server" ServicePath="~/Administration/WebServices/AutoCompleteCityService.asmx"
                                CompletionInterval="100" ServiceMethod="GetCitiesList" MinimumPrefixLength="2"
                                CompletionSetCount="10" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Kraj:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:SelectCountryControl ID="ctrlSelectCountry" runat="server" />
                        </td>
                    </tr>
                     <tr class="Row">
                        <td class="ItemName">
                            <asp:Button ID="btnAddressSave" runat="server" Text="Zapisz" 
                                CssClass="adminButton" onclick="btnAddressSave_Click" />
                        </td>
                        <td class="ItemValue">
                            <asp:Button ID="btnCancel" runat="server" Text="Anuluj" CssClass="adminButton" 
                                onclick="btnCancel_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Panel>
