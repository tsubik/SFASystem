<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeRoles.ascx.cs"
    Inherits="Administration_Controls_EmployeeRoles" %>
<asp:UpdatePanel ID="panelUpdate" runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <asp:ListBox ID="lstEmployeeRoles" runat="server" Height="200px" Width="150px"></asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btnAddRole" runat="server" Text="<<" CssClass="adminButtonBlue" OnClick="btnAddRole_Click" />
                    <asp:Button ID="btnDeleteRole" runat="server" Text=">>" CssClass="adminButtonBlue"
                        OnClick="btnDeleteRole_Click" />
                </td>
                <td>
                    <asp:ListBox ID="lstRoles" runat="server" Height="200px" Width="150px" ></asp:ListBox>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
