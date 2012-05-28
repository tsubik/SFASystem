<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderList.ascx.cs" Inherits="Administration_Controls_Sale_OrderList" %>
<asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" Width="100%"
    OnPageIndexChanging="gvOrders_PageIndexChanging" OnRowDataBound="gvOrders_RowDataBound"
    AllowPaging="true" RowStyle-Height="30" PageSize="15">
    <Columns>
        <asp:BoundField ReadOnly="true" DataField="Orderid" HeaderText="ID" Visible="false" />
        <asp:BoundField ReadOnly="true" DataField="Identifier" HeaderText="Identyfikator" ItemStyle-Width="80" />
        <asp:BoundField ReadOnly="true" DataField="OrderDate" HeaderText="Data" ItemStyle-Width="80" />
        <asp:TemplateField HeaderText="Klient" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblCustomer" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="true" DataField="CustomerFacility" HeaderText="Placówka" ItemStyle-Width="50" />
        <asp:BoundField ReadOnly="true" DataField="Employee" HeaderText="Handlowiec" ItemStyle-Width="80" />
        <asp:BoundField ReadOnly="true" DataField="Territory" HeaderText="Region" ItemStyle-Width="80" />
        <asp:BoundField ReadOnly="true" DataField="SubTotal" HeaderText="Wart. netto" ItemStyle-Width="50" DataFormatString="{0:0.00 zł}" />
        <asp:BoundField ReadOnly="true" DataField="TaxAmount" HeaderText="podatek VAT" ItemStyle-Width="50" DataFormatString="{0:0.00 zł}" />
        <asp:BoundField ReadOnly="true" DataField="Total" HeaderText="Wart. brutto" ItemStyle-Width="50" DataFormatString="{0:0.00 zł}" />
        <asp:TemplateField HeaderText="Status zamówienia" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <%# ((Order)Container.DataItem).OrderStatus.Value %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Szczegóły" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a href='<%#ResolveUrl("~/Administration/Sales/OrderDetails.aspx")%>?OrderID=<%#Eval("Orderid")%>'
                    title="Edycja zadania">Szczegóły </a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
