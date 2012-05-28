<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Manufacturers.aspx.cs" Inherits="Administration_Products_Manufacturers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">

<div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-manufacturer.png") %>" alt="" />
        Lista producentów
    </div>
    <div class="options">
        <%--<asp:Button ID="btnSearch" runat="server" Text="Filtruj" CssClass="adminButtonBlue"
            OnClick="btnSearch_Click" ToolTip="Wyszukaj pracowników według podanych kryteriów" />
        <asp:Button ID="btnRemoveFilter" runat="server" Text="Usuń filtr" CssClass="adminButtonBlue"
            OnClick="btnRemoveFilter_Click" ToolTip="Usuń wybrane filtry" />--%>
        <asp:Button ID="btnAddNew" runat="server" CssClass="adminButtonBlue" Text="Dodaj producenta"
            OnClick="btnAddNew_Click" />
    </div>
</div>
<table>
   <%-- <tr>
        <td>
            <sfasystem:ToolTipLabel runat="server" ID="lblNazwa" Text="Nazwa:" ToolTip="Nazwa"
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td>
            <asp
        </td>
    </tr>--%>
</table>
<p>
</p>
<asp:GridView ID="gvManufacturers" runat="server" AutoGenerateColumns="False" Width="100%"
    OnPageIndexChanging="gvManufacturers_PageIndexChanging" AllowPaging="true" PageSize="15"
    OnRowDataBound="gvManufacturers_RowDataBound">
    <Columns>
        <asp:BoundField ReadOnly="true" DataField="Name" HeaderText="Nazwa" />
        <asp:BoundField ReadOnly="true" DataField="Email" HeaderText="Email" />
        <asp:BoundField ReadOnly="true" DataField="Phone" HeaderText="Phone" />

        <asp:TemplateField HeaderText="Opcje" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>       
                    <a href='<%#ResolveUrl("~/Administration/Products/ManufacturerDetails.aspx")+"?ManufacturerID="+Eval("ManufacturerID")%>'
                            id='lnkDetails' runat='server' title='Edytuj dane producenta'>Edycja </a>
       
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


</asp:Content>

