<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeAdditional.ascx.cs" Inherits="Administration_Controls_Account_EmployeeAdditional" %>

<div class="EmployeeInfoBox">
    <div class="SectionTitle">
        Informacje dodatkowe
    </div>
    <div class="clear">
    </div>
    <div class="SectionBody">
        <table class="TableContainer">
            <tbody>   
                <tr class="Row">
                    <td class="ItemName">
                        Data utworzenia konta: 
                    </td>
                    <td class="ItemValue">
                        <asp:Label ID="lblCreationDate" runat="server" />
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemName">
                        Data ostatniej aktywności:
                    </td>
                    <td class="ItemValue">
                        <asp:Label ID="lblLastActivityDate" runat="server" />                 
                    </td>
                </tr>
                <tr class="Row">
                    <td class="ItemName">
                        Data ostatniego logowania:
                    </td>
                    <td class="ItemValue">
                        <asp:Label ID="lblLastLoginDate" runat="server" />                 
                    </td>
                </tr>
                
            </tbody>
        </table>
    </div>
    <div class="clear">
    </div>
</div>