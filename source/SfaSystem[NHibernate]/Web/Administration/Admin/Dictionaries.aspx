<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Dictionaries.aspx.cs" Inherits="Administration_Admin_Dictionaries" %>

<%@ Register TagPrefix="sfasystem" TagName="DictionaryControl" Src="~/Administration/Controls/Dictionaries.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <sfasystem:DictionaryControl ID="ctrlDictionary" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
