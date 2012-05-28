<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="Administration_EmployeeDetails" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
        Dane pracownika <a href="<%=ResolveUrl("~/Administration/Employees/Employees.aspx") %>" title="Back to employees list">(powrót do listy pracowników)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
            ToolTip="Save employee changes" OnClick="SaveButton_Click" />
        <asp:Button ID="DeleteButton" runat="server" CssClass="adminButtonBlue" Text="Usuń"
            CausesValidation="false" ToolTip="Delete employee" OnClick="DeleteButton_Click" />
            
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="EmployeeTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeInfo" HeaderText="Informacje">
        <ContentTemplate>
            <table class="adminContent">
                <tr>
                    <td class="adminTitle">
                        <sfasystem:ToolTipLabel runat="server" ID="lblEmployeeIDTitle" Text="ID Pracownika:"
                            ToolTip="Internal employee ID." ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:Label ID="lblEmployeeID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <sfasystem:ToolTipLabel runat="server" ID="lblEmployeeLoginTitle" Text="Login:"
                            ToolTip="The employee's login name." ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:Label ID="lblEmployeeLogin" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <sfasystem:ToolTipLabel runat="server" ID="lblEmployeeFullNameTitle" Text="Imie Nazwisko:"
                            ToolTip="The employee's full name." ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:Label runat="server" ID="lblEmployeeFullName" Width="100px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Menadżer:"
                            ToolTip="Menadżer pracownika" ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <sfasystem:SelectEmployeeControl ID="ctrlSelectEmployee" runat="server" EmptyItemText="Wybierz..." />
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <sfasystem:ToolTipLabel runat="server" ID="lblEmployeeIsActiveTitle" Text="Czy aktywny:"
                            ToolTip="Determines whether the account of employee is active." ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:CheckBox ID="chxEmployeeIsActive" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <sfasystem:ToolTipLabel runat="server" ID="lblCreationDateTitle" Text="Utworzenie konta:"
                            ToolTip="The date the employee created." ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:Label ID="lblEmployeeCreationDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <sfasystem:ToolTipLabel runat="server" ID="lblLastLoginDateTitle" Text="Ostatnie logowanie:"
                            ToolTip="The date the employee last log in." ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:Label ID="lblEmployeeLastLoginDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <sfasystem:ToolTipLabel runat="server" ID="lblLastActivityDateTitle" Text="Ostatnia aktywność:"
                            ToolTip="The date the employee last actived." ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:Label ID="lblEmployeeLastActivityDate" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeContactInfo" HeaderText="Informacje kontaktowe">
        <ContentTemplate>
            <table class="adminContent">
                <tr>
                    <td>
                        <sfasystem:ContactDisplay ID="ContactDisplay" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<a href="AddressDetails.aspx?AddressID=<%#Eval("AddressID")%>">Edit </a>--%>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>  
    <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeAddress" HeaderText="Adres zamieszkania">
        <ContentTemplate>
            <table class="adminContent">
                <tr>
                    <td>
                        <sfasystem:AddressDisplay id="AddressDisplay" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                       <%-- <a href="AddressDetails.aspx?AddressID=<%#Eval("AddressID")%>">Edit </a>--%>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
     <ajaxToolkit:TabPanel runat="server" ID="pnlEmployeeRoles" HeaderText="Role">
        <ContentTemplate>
            <table class="adminContent">
                <tr>
                    <td>
                        <sfasystem:EmployeeRoles id="employeeRoles" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                       <%-- <a href="AddressDetails.aspx?AddressID=<%#Eval("AddressID")%>">Edit </a>--%>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>

    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmDeleteButtonExtender" runat="server"
        TargetControlID="DeleteButton" DisplayModalPopupID="ModalPopupExtenderDelete" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDelete" runat="server" TargetControlID="DeleteButton"
        PopupControlID="pnlDeletePopup" OkControlID="deleteButtonOk" CancelControlID="deleteButtonCancel"
        BackgroundCssClass="modalBackground" />
    <asp:Panel ID="pnlDeletePopup" runat="server" Style="display: none; width: 250px;
        background-color: White; border-width: 2px; border-color: Black; border-style: solid;
        padding: 20px;">
        <div style="text-align: center;">
            Are you sure?
            <br />
            <br />
            <asp:Button ID="deleteButtonOk" runat="server" Text="OK" CssClass="adminButton" CausesValidation="false" />
            <asp:Button ID="deleteButtonCancel" runat="server" Text="Cancel" CssClass="adminButton"
                CausesValidation="false" />
        </div>
    </asp:Panel>
</asp:Content>

