<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductPictures.ascx.cs" Inherits="Administration_Controls_Product_ProductPictures" %>
<%@ Register Src="~/Administration/Controls/ToolTipLabel.ascx" TagPrefix="sfasystem" TagName="ToolTipLabel" %>
<%@ Reference Control="~/Administration/Controls/MessageBox.ascx" %>

<asp:GridView ID="gvwImages" runat="server" AutoGenerateColumns="false" DataKeyNames="Imageid"
    OnRowDeleting="gvwImages_RowDeleting" OnRowDataBound="gvwImages_RowDataBound"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="Zdjęcie" ItemStyle-Width="50%">
            <ItemTemplate>
                <asp:Image ID="iProductPicture" runat="server" />
                <asp:HiddenField ID="hfProductPictureID" runat="server" Value='<%# Eval("Imageid") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Usuń" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%"
            ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Button ID="btnDeletePicture" runat="server" CssClass="adminButton" Text="Usuń"
                    CausesValidation="false" CommandName="Delete" ToolTip="Usuń zdjęcie" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<asp:Panel ID="pnlAddPicture" runat="server" >
<p>
    <strong>Dodaj nowe zdjęcie </strong>
</p>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            <sfasystem:ToolTipLabel runat="server" ID="lblSelectPicture" Text="Wybierz zdjęcie:"
                ToolTip="Choose a picture to upload. If the picture size exceeds your stores max image size setting, it will be automatically resized. You can manage resizing from Configuration : Global Settings"
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:FileUpload class="text" ID="fuProductPicture" CssClass="adminInput" runat="server"
                ToolTip="Wybierz zdjęcie do załadowania"  />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="left">
            <asp:Button runat="server" ID="btnUploadProductPicture" CssClass="adminButton" Text="Upload"
                ValidationGroup="UploadNewProductPicture" OnClick="btnUploadProductPicture_Click"
                ToolTip="Upload the picture" />
        </td>
    </tr>
</table>
</asp:Panel>