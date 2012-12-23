<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InvoiceList.ascx.cs" Inherits="Administration_Controls_Sale_InvoiceList" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>

<asp:GridView ID="gvInvoices" runat="server" AutoGenerateColumns="False" Width="100%"
    OnPageIndexChanging="gvInvoices_PageIndexChanging" OnRowDataBound="gvInvoices_RowDataBound"
    AllowPaging="true" RowStyle-Height="30" PageSize="15">
    <Columns>    
        <asp:BoundField ReadOnly="true" DataField="InvoiceID" HeaderText="ID" />
        <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60" Visible="false"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Invoiceid") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="true" DataField="Number" HeaderText="Numer" ItemStyle-Width="80" />
        <asp:BoundField ReadOnly="true" DataField="Date" HeaderText="Data wystawienia" ItemStyle-Width="80" />
        <asp:TemplateField HeaderText="Klient" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblCustomer" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Zamówienie" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblOrderNumber" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="true" DataField="DatePayment" HeaderText="Data zapłaty" ItemStyle-Width="50" />
        <asp:BoundField ReadOnly="true" DataField="IsPaid" HeaderText="Czy opłacona" ItemStyle-Width="50" />
        <asp:TemplateField HeaderText="Opcje" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Button ID="btnMarkAsPaid" runat="server" CssClass="adminButton" Text="Zapłacono" OnClick="btnMarkAsPaid_Click" />
                <asp:Button ID="btnPrint" runat="server" CssClass="adminButton" Text="Wydruk" OnClientClick="window.open('{0}', 'faktura', 'menubar=no, toolbar=no, location=no, scrollbars=yes, resizable=yes, status=no'); " />
                <ajaxToolkit:ConfirmButtonExtender ID="ConfirmDeleteButtonExtender" runat="server"
        TargetControlID="btnMarkAsPaid" DisplayModalPopupID="ModalPopupExtenderDelete" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDelete" runat="server" TargetControlID="btnMarkAsPaid"
        PopupControlID="pnlDeletePopup" OkControlID="ButtonOk" CancelControlID="ButtonCancel"
        BackgroundCssClass="modalBackground" />
    <asp:Panel ID="pnlDeletePopup" runat="server" Style="display: none; width: 250px;
        background-color: White; border-width: 2px; border-color: Black; border-style: solid;
        padding: 20px;">
        <div style="text-align: center;">
            Faktura zostanie oznaczona jako zapłacona?
            <br />
            <br />
            <asp:Button ID="ButtonOk" runat="server" Text="OK" CssClass="adminButton" CausesValidation="false" />
            <asp:Button ID="ButtonCancel" runat="server" Text="Anuluj" CssClass="adminButton"
                CausesValidation="false" />
        </div>
    </asp:Panel>
            
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Szczegóły" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a href='<%#ResolveUrl("~/Administration/Sales/OrderDetails.aspx")%>?OrderID=<%#((Invoice)Container.DataItem).Order.OrderID%>'
                    title="Edycja zadania">Szczegóły zamówienia</a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

