<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuoteList.ascx.cs" Inherits="Administration_Controls_SalesDir_Quotes" %>
<asp:GridView ID="gvQuotes" runat="server" AutoGenerateColumns="False" Width="100%"
    OnPageIndexChanging="gvQuotes_PageIndexChanging" AllowPaging="true" RowStyle-Height="30"
    PageSize="15">
    <Columns>
        <asp:BoundField ReadOnly="true" DataField="Quoteid" HeaderText="ID" Visible="false" />
        <asp:BoundField ReadOnly="true" DataField="Text" HeaderText="Cytat" ItemStyle-Width="300" />
        <asp:BoundField ReadOnly="true" DataField="Author" HeaderText="Autor" ItemStyle-Width="50" />
        <asp:BoundField ReadOnly="true" DataField="Active" HeaderText="Active" ItemStyle-Width="50" />
       <asp:TemplateField HeaderText="Edycja" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a href='<%#ResolveUrl("~/Administration/SalesDirector/QuoteDetails.aspx")%>?QuoteID=<%#Eval("Quoteid")%>' title="Edycja cytatu">
                    Edycja </a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


