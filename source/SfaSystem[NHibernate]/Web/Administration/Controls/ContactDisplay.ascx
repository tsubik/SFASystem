<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactDisplay.ascx.cs"
    Inherits="SFASystem.Web.Administration.Controls.ContactDisplayControl" %>
  <%@ Register TagPrefix="sfasystem" TagName="TextBox" Src="~/Administration/Controls/TextBoxControl.ascx" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>
  
    
<asp:Panel ID="pnlShow" runat="server">
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
                            Imie, Nazwisko:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:TextBox ID="txtImie" runat="server" ErrorMessage="Imię jest obowiązkowe" />,<sfasystem:TextBox ID="txtNazwisko" runat="server" ErrorMessage="Nazwisko jest obowiązkowe" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Email:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:TextBox ID="txtEmail" runat="server" ErrorMessage="Email jest obowiązkowy" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            Telefon:
                        </td>
                        <td class="ItemValue">
                            <sfasystem:TextBox ID="txtTelefon" runat="server" ErrorMessage="Telefon jest obowiązkowy" />
                        </td>
                    </tr>
                    <tr class="Row">
                        <td class="ItemName">
                            <asp:Button ID="btnContactSave" runat="server" Text="Zapisz" 
                                CssClass="adminButton" onclick="btnContactSave_Click" />
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
