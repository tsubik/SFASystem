<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CountryList.ascx.cs" Inherits="Administration_Controls_CountryList" %>


<asp:GridView ID="gvCountries" runat="server" AutoGenerateColumns="false" 
    Width="200px">
    <Columns>
        <asp:BoundField ReadOnly="true" DataField="CountryID" HeaderText="Country ID"  />
        <asp:TemplateField HeaderText="Nazwa kraju">
            <EditItemTemplate>
                <asp:TextBox ID="txtCountryName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblCountryName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Opcje">
            <EditItemTemplate>
                <asp:Button ID="btnUpdate" runat="server" CommandName="Cancel" CssClass="adminButtonBlue"
                    Text="Akceptuj" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" CssClass="adminButtonBlue"
                    Text="Anuluj" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CssClass="adminButtonBlue" Text="Edytuj" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

</asp:GridView>