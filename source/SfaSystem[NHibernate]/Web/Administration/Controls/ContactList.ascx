<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactList.ascx.cs" Inherits="Administration_Controls_ContactList" %>

 <script type="text/javascript">
        function EmailClick(mail) {
            window.open("mailto:" + mail);
        }
    </script>

<asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="false" Width="100%"
    OnPageIndexChanging="gvContacts_PageIndexChanging" AllowPaging="true" RowStyle-Height="30"
    PageSize="15" onrowdatabound="gvContacts_RowDataBound">
    <Columns>
        <asp:BoundField ReadOnly="true" DataField="Contactid" HeaderText="ID" Visible="false" />  
        <asp:TemplateField HeaderText="Imię, Nazwisko" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <%# ((Contact)Container.DataItem).FirstName + ", " + ((Contact)Container.DataItem).LastName%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="true" DataField="Phone" HeaderText="Telefon" ItemStyle-Width="100" />
        <asp:BoundField ReadOnly="true" DataField="Email" HeaderText="Email" ItemStyle-Width="100" />
        <asp:TemplateField HeaderText="Firma" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblCustomers" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Placówka" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblCustomerFacilities" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Edycja" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a href='<%#ResolveUrl("~/Administration/Customers/ContactDetails.aspx")%>?ContactID=<%#Eval("Contactid")%>' title="Edycja kontaktu">
                    Edycja </a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Edycja" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Button ID="btnSendMail" runat="server" Text="Wyślij email" CssClass="adminButton"
                        OnClientClick='<%# "javascript:EmailClick(" + "\""+Eval("Email")+"\")" %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>