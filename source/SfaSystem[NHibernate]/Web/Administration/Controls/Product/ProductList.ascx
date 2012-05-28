<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductList.ascx.cs" Inherits="Administration_Controls_ProductList" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem"
    TagName="ToolTipLabel" %>
<%@ Register Src="~/Administration/Controls/Product/SelectProductGroupControl.ascx"
    TagPrefix="sfasystem" TagName="SelectProductGroupControl" %>
    <%@ Register Src="~/Administration/Controls/Product/SelectManufacturerControl.ascx"
    TagPrefix="sfasystem" TagName="SelectManufacturer" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>
<div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-products.png") %>" alt="" />
        Lista produktów
    </div>
    <div class="options">
        <asp:Button ID="btnSearch" runat="server" Text="Filtruj" CssClass="adminButtonBlue"
            ToolTip="Filtruj produkty" OnClick="btnSearch_Click" />
        <asp:Button ID="btnRemoveFilter" runat="server" Text="Usuń filtr" CssClass="adminButtonBlue"
            ToolTip="Usuń włączone filtry" OnClick="btnRemoveFilter_Click" />
        <asp:Button ID="btnAddNew" runat="server" Text="Dodaj nowy produkt" CssClass="adminButtonBlue"
            ToolTip="Dodaj nowy produkt" OnClick="btnAddNew_Click" />
    </div>
</div>
<table>
    <tr>
        <td>
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Kod produktu:" ToolTip="Kod produktu"
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td>
            <asp:TextBox ID="txtProductCode" CssClass="adminInput" runat="server" Width="150px"></asp:TextBox>
        </td>
        <td>
            <sfasystem:ToolTipLabel runat="server" ID="lblProductName" Text="Nazwa produktu:"
                ToolTip="Nazwa produktu" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td>
            <asp:TextBox ID="txtProductName" CssClass="adminInput" runat="server" Width="150px"></asp:TextBox>
        </td>
        <td>
            <sfasystem:ToolTipLabel runat="server" ID="lblProductGroup" Text="Grupa produktów:"
                ToolTip="Search by a specific category." ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td>
            <sfasystem:SelectProductGroupControl ID="ctrlSelectedProductGroup" CssClass="adminInput"
                runat="server" Width="200px"></sfasystem:SelectProductGroupControl>
        </td>
         <td>
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel2" Text="Producent:"
                ToolTip="Szukaj według producenta." ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td>
            <sfasystem:SelectManufacturer ID="ctrlSelectManufacturer" CssClass="adminInput" EmptyItemText="Wszyscy"
                runat="server" Width="150px"></sfasystem:SelectManufacturer>
        </td>
    </tr>
</table>
<p>
</p>
<asp:UpdatePanel ID="panelUpdate" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width="100%"
            OnPageIndexChanging="gvProducts_PageIndexChanging" AllowPaging="true" PageSize="10"
            OnRowDataBound="gvProducts_RowDataBound" RowStyle-Height="40">
            <Columns>
               <%-- <asp:TemplateField HeaderText="ID Produktu" Visible="False">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenID" runat="server" Value='<%=Eval("Productid") %>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField ReadOnly="true" DataField="Productid" HeaderText="ID" />
                <asp:BoundField ReadOnly="true" DataField="Code" HeaderText="Kod Produktu" Visible="true" ItemStyle-Width="100">
                </asp:BoundField>
                <asp:BoundField ReadOnly="true" DataField="Name" HeaderText="Nazwa" />
                <asp:TemplateField HeaderText="Grupa" ItemStyle-Width="150">
                    <ItemTemplate>
                        <%# ((Product)Container.DataItem).ProductGroup.Name  %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Producent" ItemStyle-Width="100">
                    <ItemTemplate>
                        <%# (((Product)Container.DataItem).Manufacturer!=null)?((Product)Container.DataItem).Manufacturer.Name:"---"  %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField ReadOnly="true" DataField="ShortDescription" HeaderText="Opis" />
                <asp:TemplateField HeaderText="Cena netto" ItemStyle-Width="80">
                    <ItemTemplate>
                        <asp:Label ID="lblNettoPrice" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VAT" ItemStyle-Width="40">
                    <ItemTemplate>
                        <%# ((Product)Container.DataItem).Tax.Value %>%
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField ReadOnly="true" DataField="Price" HeaderText="Cena brutto" DataFormatString="{0:0.00 zł}"
                    ItemStyle-Width="80" />
                <asp:TemplateField HeaderText="Opcje" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <a href='<%#ResolveUrl("~/Administration/Products/ProductDetails.aspx")+"?ProductID="+Eval("ProductID")%>'
                            id='lnkDetails' runat='server' title='Edit product details'>Edycja </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Zamówienie" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnAddToOrder" runat="server" CssClass="adminButton" Text="Dodaj do zamówienia"
                            OnClick="btnAddToOrder_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
