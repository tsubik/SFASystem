<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomersList.ascx.cs" Inherits="SFASystem.Web.Administration.Controls.CustomersListControl" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem" TagName="ToolTipLabel" %>

<div class="section-header">
    <div class="title">
        <img src="<%=ResolveUrl("~/Administration/Common/ico-customers.png") %>" alt="" />
        Lista klientów
    </div>
    <div class="options">
    <asp:Button ID="SearchButton" runat="server" Text="Filtruj" CssClass="adminButtonBlue"
             ToolTip="Search for customers based on the criteria below" 
            onclick="SearchButton_Click" />
            <asp:Button ID="btnRemoveFilter" runat="server" Text="Usuń filtr" CssClass="adminButtonBlue"
             ToolTip="Usuń filtry" 
            onclick="btnRemoveFilter_Click" />
        <asp:Button ID="btnAddNew" runat="server" CssClass="adminButtonBlue" 
            Text="Dodaj nowego klienta" onclick="btnAddNew_Click" />
        
        
<%--        <asp:Button runat="server" Text="Export to XML" CssClass="adminButtonBlue" ID="btnExportXML"
             ValidationGroup="ExportXML" ToolTip="Export customers list to a xml file" />--%>
    </div>
</div>
<table>
     <tr>
        <td>
            <sfasystem:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="Nazwa klienta:"
                ToolTip="Nazwa klienta" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td>
            <asp:TextBox ID="txtName" CssClass="adminInput" runat="server" Width="150px"></asp:TextBox>
        </td>
    
        <td>
            <sfasystem:ToolTipLabel runat="server" ID="lblProductName" Text="NIP:"
                ToolTip="NIP" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td>
            <asp:TextBox ID="txtNIP" CssClass="adminInput" runat="server" Width="150px"></asp:TextBox>
        </td>
   
        <td>
            <sfasystem:ToolTipLabel runat="server" ID="lblRegon" Text="REGON:"
                ToolTip="REGON" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td>
            <asp:TextBox ID="txtREGON" CssClass="adminInput" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>

   
</table>
<p>
</p>
<asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" Width="100%"
    OnPageIndexChanging="gvCustomers_PageIndexChanging" AllowPaging="true" RowStyle-Height="30"
    PageSize="15" onrowdatabound="gvCustomers_RowDataBound">
    <Columns>
        <asp:BoundField ReadOnly="true" DataField="Customerid" HeaderText="ID" Visible="false" />
        <asp:BoundField ReadOnly="true" DataField="Code" HeaderText="Kod" ItemStyle-Width="50" />
        <asp:BoundField ReadOnly="true" DataField="Name" HeaderText="Nazwa" />
        <asp:BoundField ReadOnly="true" DataField="NIP" HeaderText="NIP" ItemStyle-Width="80" />
        <asp:BoundField ReadOnly="true" DataField="REGON" HeaderText="REGON" ItemStyle-Width="80" />
        <asp:BoundField ReadOnly="true" DataField="KRS" HeaderText="KRS" ItemStyle-Width="80" />
       <%-- <asp:CheckBoxField DataField="IsDeleted" HeaderText="Usunięty?" ItemStyle-Width="40"/>--%>
        <asp:TemplateField HeaderText="Edycja" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a id="lnkDetails" runat="server" href='<%#ResolveUrl("~/Administration/Customers/CustomerDetails.aspx")+"?CustomerID="+Eval("Customerid")%>' title="Edycja klienta">
                    Edycja </a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>