<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Invoices.aspx.cs" Inherits="Administration_Sales_Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="<%=ResolveUrl("~/Administration/Common/ico-invoice.png")%>" alt="Faktury" />
            Faktury
        </div>
        <div class="options">
            <asp:Button ID="btnSearch" runat="server" Text="Filtruj" CssClass="adminButtonBlue"
                ToolTip="Filtruj" OnClick="btnSearch_Click" />
            <asp:Button ID="btnRemoveFilter" runat="server" Text="Usuń filtr" CssClass="adminButtonBlue"
                ToolTip="Filtruj" OnClick="btnRemoveFilter_Click" />
            <%-- <asp:Button ID="btnAddNew" runat="server" Text="Dodaj nowe zamówienie" CssClass="adminButtonBlue"
                ToolTip="Dodaj nowe zadania" OnClick="btnAddNew_Click" />--%>
        </div>
    </div>
    <table>
        <tr>
            <td>
                <sfasystem:ToolTipLabel runat="server" ID="lblPaid" Text="Pokaż:" ToolTip="Pokaż faktury według statusu"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td>
                <sfasystem:SelectInvoiceStatus ID="ctrlSelectInvoiceStatus" runat="server" EmptyItemText="Wszystkie"
                    Width="200px" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <sfasystem:InvoiceList ID="ctrlInvoiceList" runat="server" />
</asp:Content>
