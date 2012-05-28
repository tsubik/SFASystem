<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerFacilityList.ascx.cs"
    Inherits="Administration_Controls_Customer_CustomerFacilityList" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>
<asp:GridView ID="gvFacilities" runat="server" AutoGenerateColumns="False" Width="100%"
    OnPageIndexChanging="gvFacilities_PageIndexChanging" AllowPaging="true" RowStyle-Height="30"
    PageSize="15" onrowdatabound="gvFacilities_RowDataBound">
    <Columns>
        <asp:BoundField ReadOnly="true" DataField="CustomerFacilityid" HeaderText="ID" />
        <asp:BoundField ReadOnly="true" DataField="Name" HeaderText="Nazwa placówki" ItemStyle-Width="400px" />
        <asp:TemplateField HeaderText="Należy do" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <%# ((CustomerFacility) Container.DataItem).Customer.Name %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="40px"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <%# ((CustomerFacility) Container.DataItem).Territory.Name %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Miasto" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="40"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <%# ((CustomerFacility) Container.DataItem).Address.City.Name%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Opcje" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60px"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a id="lnkDetails" runat="server" href='<%#ResolveUrl("~/Administration/Customers/CustomerFacilityDetails.aspx")+"?CustomerFacilityID="+Eval("CustomerFacilityid")%>'
                    title="Edycja placówki">Edycja </a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Zamówienie" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Button ID="btnAddToOrder" runat="server" CssClass="adminButton" Text="Dodaj do zamówienia"
                    OnClick="btnAddToOrder_Click" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
