<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="QuoteDetails.aspx.cs" Inherits="Administration_SalesDirector_QuoteDetails" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
            Dane cytatu <a href="<%=ResolveUrl("~/Administration/SalesDirector/Quotes.aspx") %>"
                title="Back to employees list">(powrót do listy cytatów)</a>
        </div>
        <div class="options">
            <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Zapisz"
                OnClick="SaveButton_Click" ToolTip="Zapisz zadanie" />
            <asp:Button ID="DeleteButton" runat="server" CssClass="adminButtonBlue" Text="Usuń"
                CausesValidation="false" ToolTip="Usuń cytat" OnClick="DeleteButton_Click" />
        </div>
    </div>
  
    <ajaxToolkit:TabContainer runat="server" ID="TaskTabs" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" ID="pnlTaskInfo" HeaderText="Informacje">
            <ContentTemplate>
                <sfasystem:QuoteInfo runat="server" ID="ctrlQuoteInfo" />
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
        Czy na pewno usunąć cytat?
        <br />
        <br />
        <asp:Button ID="deleteButtonOk" runat="server" Text="OK" CssClass="adminButton" CausesValidation="false" />
        <asp:Button ID="deleteButtonCancel" runat="server" Text="Cancel" CssClass="adminButton"
            CausesValidation="false" />
    </div>
</asp:Panel>
</asp:Content>