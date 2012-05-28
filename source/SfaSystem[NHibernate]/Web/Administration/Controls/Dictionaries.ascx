<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Dictionaries.ascx.cs"
    Inherits="Administration_Controls_Dictionaries" %>
<div class="section-header">
    <div class="title">
        <img src="Common/ico-catalog.png" alt="Category" />
        Edycja słowników
    </div>
</div>
<p>
</p>
<asp:UpdatePanel ID="pnlUpdate" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <div style="position: relative; float: left;">
            Nazwa słownika:
            <br />
            <asp:ListBox ID="lbDictionaryType" runat="server" DataTextField="Name" DataValueField="DictionaryTypeid"
                Rows="10" AutoPostBack="true" OnSelectedIndexChanged="lbDictionaryType_SelectedIndexChanged"
                Width="250px" />
        </div>
        <div style="position: relative; float: left; left: 20px;">
            Zawartość słownika:
            <br />
            <asp:ListBox ID="lbDictionary" runat="server" DataTextField="Value" DataValueField="Dictionaryid"
                Rows="10" OnSelectedIndexChanged="lbDictionary_SelectedIndexChanged" AutoPostBack="true"
                Width="200px" />
            <asp:Button ID="btnDelete" runat="server" Text="Usuń" OnClick="btnDelete_Click" CssClass="adminButtonBlue" />
            <br />
            <asp:TextBox ID="txtName" runat="server" Width="200px" />
            <asp:Button ID="btnSave" runat="server" Text="Zapisz" OnClick="btnSave_Click" CssClass="adminButtonBlue" />
            <br />
            <asp:TextBox ID="tbAdd" runat="server" Width="200px" />
            <asp:Button ID="btnAdd" runat="server" Text="Dodaj" OnClick="btnAdd_Click" CssClass="adminButtonBlue"   />
        </div>
        <div style="color: Red;">
            <asp:Literal ID="litError" runat="server" Text="Nie można usunąć wybranej pozycji, gdyż jest powiązana z innymi elementami bazy danych."
                Visible="false" EnableViewState="false"></asp:Literal>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
