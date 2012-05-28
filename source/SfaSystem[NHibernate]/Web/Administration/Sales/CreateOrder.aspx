<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="CreateOrder.aspx.cs" Inherits="Administration_Sales_CreateOrder" %>

<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-invoice.png")%>" alt="Zamówienie" />
            Tworzenie zamówienia
        </div>
        <div class="options">
            <asp:Button ID="btnDodajPozycje" runat="server" CssClass="adminButton" Text="Dodaj pozycję"
                OnClick="btnDodajPozycje_Click" />
            <asp:Button ID="btnAcceptOrder" runat="server" CssClass="adminButtonGreen" Text="Złóż zamówienie"
                OnClick="btnAcceptOrder_Click" />
            <asp:Button ID="btnCancelOrder" runat="server" Text="Kasuj zamówienie" CssClass="adminButtonRed"
                ToolTip="Dodaj nowe zadania" OnClick="btnCancelOrder_Click" />
        </div>
    </div>
    <div>
        <table>
            <tr valign="top">
                <td>
                    Zamówienie dla:
                </td>
                <td>
                    <asp:Label ID="lblZamowienieDla" runat="server" Text="..................." />
                    <asp:Button ID="btnWybierzPlacowka" runat="server" CssClass="adminButton" Text="Wybierz..."
                        OnClick="btnWybierzPlacowka_Click" />
                </td>
            </tr>
            <tr valign="top">
                <td style="vertical-align: top; ">
                    Komentarz:
                </td>
                <td>
                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="300px" Height="50px" />
                    <br />
                    <asp:Button ID="btnSaveComment" runat="server" CssClass="adminButton" Text="Zapisz komentarz"
                        OnClick="btnSaveComment_Click" />
                </td>
            </tr>
        </table>
        <h3>
            Pozycje zamówienia</h3>
        <asp:GridView ID="gvOrderLines" runat="server" AutoGenerateColumns="False" Width="100%"
            OnPageIndexChanging="gvOrderLines_PageIndexChanging" OnRowDataBound="gvOrderLines_RowDataBound"
            AllowPaging="false" RowStyle-Height="30" PageSize="15">
            <Columns>
                <asp:TemplateField HeaderText="Lp." ItemStyle-Width="20">
                    <ItemTemplate>
                        <asp:Label ID="lblLp" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Produkt">
                    <ItemTemplate>
                        <a href="<%#ResolveUrl("~/Administration/Products/ProductDetails.aspx?ProductID="+((OrderLine)Container.DataItem).Product.Productid.ToString())%>">
                            <%# ((OrderLine)Container.DataItem).Product.Name %>
                        </a>
                        <asp:HiddenField ID="hiddenID" runat="server" Value='<%# ((OrderLine)Container.DataItem).Product.Productid%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Ilość" ItemStyle-Width="60">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity")%>' Width="50px" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cena netto" ItemStyle-Width="60">
                    <ItemTemplate>
                        <%# String.Format("{0:0.00 zł}", CenaNetto((decimal)Eval("ItemPrice"),Int32.Parse(((OrderLine)Container.DataItem).Product.Tax.Value))) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Wartość netto" ItemStyle-Width="60">
                    <ItemTemplate>
                        <%# String.Format("{0:0.00 zł}", CenaNetto((decimal)Eval("ItemPrice"),Int32.Parse(((OrderLine)Container.DataItem).Product.Tax.Value))*(int)Eval("Quantity")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VAT [%]" ItemStyle-Width="60">
                    <ItemTemplate>
                        <%# String.Format("{0} %", ((OrderLine)Container.DataItem).Product.Tax.Value) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField ReadOnly="true" HeaderText="Kwota VAT" DataField="Tax" DataFormatString="{0:0.00 zł}" ItemStyle-Width="50"/>
                <asp:BoundField ReadOnly="true" HeaderText="Wartość brutto" DataField="Total" DataFormatString="{0:0.00 zł}"
                    ItemStyle-Width="60" />
                <asp:TemplateField HeaderText="Opcje" ItemStyle-Width="60">
                    <ItemTemplate>
                        <asp:Button ID="btnRemoveProduct" runat="server" Text="Usuń" CssClass="adminButtonRed"
                            OnClick="btnRemoveProduct_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table style="float: right; margin-right: 20px; margin-top: 20px; text-align: right;"
            cellpadding="3" runat="server" id="summary">
            <tr>
                <td>
                    Wartość netto:
                </td>
                <td>
                    <asp:Label ID="lblNetto" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Wartość podatku:
                </td>
                <td>
                    <asp:Label ID="lblTax" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Wartość brutto:
                </td>
                <td>
                    <asp:Label ID="lblBrutto" runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="Aktualizuj pozycje"
            OnClick="btnUpdate_Click" />
    </div>
</asp:Content>
