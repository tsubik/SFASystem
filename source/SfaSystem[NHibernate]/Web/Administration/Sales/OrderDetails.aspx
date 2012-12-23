<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="Administration_Sales_OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
    <%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>
<div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-employees.png") %>" alt="" />
        Szczegóły zamówienia <a href="<%=ResolveUrl("~/Administration/Sales/Orders.aspx") %>"
            title="Powrót do listy zamówień">(powrót do listy zamówień)</a>
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="TaskTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlTaskInfo" HeaderText="Informacje">
        <HeaderTemplate>
            Informacje
        </HeaderTemplate>
        <ContentTemplate>
            <table class="adminContent">
                <tbody>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel9" Text="Status zamówienia:"
                                ToolTip="Status zamówienia." ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <strong>
                                <asp:Label ID="lblOrderStatus" runat="server" /></strong>&nbsp;
                            <asp:Button ID="btnCreateInvoice" runat="server" CssClass="adminButton" Visible="False"
                                Text="Wystaw fakturę" OnClick="btnCreateInvoice_Click" />
                            <asp:Button ID="btnPrintInvoice" runat="server" CssClass="adminButton" Visible="False"
                                Text="Drukuj fakturę" OnClientClick="window.open('{0}', 'faktura', 'menubar=no, toolbar=no, location=no, scrollbars=yes, resizable=yes, status=no'); " />
                            <asp:Button ID="btnApproveOrder" runat="server" CssClass="adminButtonGreen" Text="Zatwierdź zamówienie"
                                Visible="False" OnClick="btnApproveOrder_Click" />
                            <asp:Button ID="btnCancelOrder" runat="server" CssClass="adminButtonRed" Text="Anuluj zamówienie"
                                CausesValidation="False" OnClick="btnCancelOrder_Click"></asp:Button>
                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmCancelOrderButtonExtender" runat="server"
                                TargetControlID="btnCancelOrder" DisplayModalPopupID="ModalPopupExtenderCancelOrder"
                                ConfirmText="" Enabled="True" />
                            <br />
                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderCancelOrder" runat="server"
                                TargetControlID="btnCancelOrder" PopupControlID="pnlCancelOrderPopup" OkControlID="cancelOrderButtonOk"
                                CancelControlID="cancelOrderButtonCancel" BackgroundCssClass="modalBackground"
                                DynamicServicePath="" Enabled="True" />
                            <asp:Panel ID="pnlCancelOrderPopup" runat="server" Style="display: none; width: 250px;
                                background-color: White; border-width: 2px; border-color: Black; border-style: solid;">
                                <div class="modalTitle">
                                    Potwierdź operację
                                </div>
                                <div style="text-align: left; padding: 20px;">
                                    Zamówienie zostanie anulowane. Przeprowadzić operację?
                                    <br />
                                    <br />
                                    <div style="text-align: center;">
                                        <asp:Button ID="cancelOrderButtonOk" runat="server" Text="Tak" CssClass="adminButton"
                                            CausesValidation="False" />
                                        <asp:Button ID="cancelOrderButtonCancel" runat="server" Text="Nie" CssClass="adminButton"
                                            CausesValidation="False" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="tipTaskName" Text="Id zamówienia:" ToolTip="Systemowe id zamówienia."
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblOrderID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel8" Text="Identyfikator:" ToolTip="Identyfikator zamówienia."
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblIdentyfikator" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel10" Text="Data zamówienia:"
                                ToolTip="Data zamówienia." ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblOrderDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel11" Text="Region:" ToolTip="Region."
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblRegion" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel12" Text="Klient:" ToolTip="Klient."
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblKlient" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel13" Text="Placówka:" ToolTip="Placówka."
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblPlacowka" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel14" Text="Handlowiec:" ToolTip="Handlowiec."
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblPracownik" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel15" Text="Wart netto:" ToolTip="Wartość netto zamówienia."
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblWartNetto" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel16" Text="Podatek VAT:" ToolTip="Podatek VAT."
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblPodatek" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel17" Text="Wart brutto:" ToolTip="Wartość brutto zamówienia."
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label ID="lblWartBrutto" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel ID="pnlWysylka" runat="server" HeaderText="Wysyłka">
        <ContentTemplate>
            <div class="EmployeeInfoBox">
                <div class="SectionTitle">
                    Adres wysyłki -
                    <asp:Label ID="lblShipFacility" runat="server" />
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
                                    <asp:Label ID="lblShipStreet" runat="server" />
                                </td>
                            </tr>
                            <tr class="Row">
                                <td class="ItemName">
                                    Nr domu/mieszkania:
                                </td>
                                <td class="ItemValue">
                                    <asp:Label ID="lblShipHouseNr" runat="server" />
                                </td>
                            </tr>
                            <tr class="Row">
                                <td class="ItemName">
                                    Kod pocztowy:
                                </td>
                                <td class="ItemValue">
                                    <asp:Label ID="lblShipZipCode" runat="server" />
                                </td>
                            </tr>
                            <tr class="Row">
                                <td class="ItemName">
                                    Miasto:
                                </td>
                                <td class="ItemValue">
                                    <asp:Label ID="lblShipCity" runat="server" />
                                </td>
                            </tr>
                            <tr class="Row">
                                <td class="ItemName">
                                    Kraj:
                                </td>
                                <td class="ItemValue">
                                    <asp:Label ID="lblShipCountry" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
            <asp:Button ID="btnSetOrderShipped" runat="server" Text="Ustaw jako wysłane" CssClass="adminButton"
                OnClick="btnSetOrderShipped_Click" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel ID="pnlLinieZamowienia" runat="server" HeaderText="Linie zamówienia">
        <ContentTemplate>
            <asp:GridView ID="gvOrderLines" runat="server" AutoGenerateColumns="False" Width="100%"
                OnPageIndexChanging="gvOrderLines_PageIndexChanging" OnRowDataBound="gvOrderLines_RowDataBound"
                AllowPaging="true" RowStyle-Height="30" PageSize="15">
                <Columns>
                    <asp:TemplateField HeaderText="Lp." ItemStyle-Width="20">
                        <ItemTemplate>
                            <asp:Label ID="lblLp" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Produkt">
                        <ItemTemplate>
                            <a href="<%#ResolveUrl("~/Administration/Products/ProductDetails.aspx?ProductID="+((OrderLine)Container.DataItem).Product.ProductID.ToString())%>">
                                <%# ((OrderLine)Container.DataItem).Product.Name %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ReadOnly="true" HeaderText="Cena brutto" DataField="ItemPrice" DataFormatString="{0:0.00 zł}"
                        ItemStyle-Width="60" />
                    <asp:BoundField ReadOnly="true" HeaderText="Ilość" DataField="Quantity" ItemStyle-Width="20" />
                    <asp:BoundField ReadOnly="true" HeaderText="Razem" DataField="Total" DataFormatString="{0:0.00 zł}"
                        ItemStyle-Width="60" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>

