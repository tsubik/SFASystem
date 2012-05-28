<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoicePrint.aspx.cs" Inherits="Administration_Sales_InvoicePrint" %>

<%@ Import Namespace="SFASystem.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SFASystem - Wydruk faktury</title>
    <style type="text/css" media="print">
        .printbutton
        {
            visibility: hidden;
            display: none;
        }
    </style>
    <style type="text/css" media="print">
        .printbutton
        {
            visibility: hidden;
            display: none;
        }
    </style>
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {

        }
        .style4
        {
            width: 800px;
            height: 113px;
        }
        .style5
        {
            height: 44px;
        }
        .style6
        {
            height: 19px;
        }
        .style7
        {
            height: 38px;
        }
        .style8
        {
            height: 38px;
        }
        .style9
        {
            height: 52px;
        }
        .style10
        {
            height: 45px;
        }
        .style13
        {
            width: 20px;
        }
        .style14
        {
            width: 350px;
        }
        .style16
        {
            width: 23px;
        }
        .style19
        {
            width: 61px;
        }
        .style21
        {
            width: 20px;
        }
        .style22
        {
            width: 82px;
        }
        .tabela td, th, tr
        {
            border: 1px solid black;
        }
        .tabela th
        {
            background-color: #C0C0C0;
        }
        .style23
        {
            width: 30px;
        }
        .style24
        {
            height: 60px;
        }
        .style25
        {
            height: 37px;
        }
        .style26
        {
            height: 9px;
        }
        .style27
        {
            height: 97px;
        }
        .style28
        {
            height: 97px;
            width: 406px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <%-- <asp:Panel ID="mainContent" runat="server">
                <div id="container">
                    
                    <!-- koniec  top -->
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 50%;" class="style2">
                                &nbsp;</td>
                            <td class="style2" style="width: 50%;">
                                &nbsp;</td>
                            <td style="width: 50%;" align="left">
                                <div class="currentDate" style="margin-left: 150px;">
                                    <p>
                                        Data zamówienia:
                                        <%# Order.tCreateDate.ToShortDateString() %>
                                    </p>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <div class="naglowkiTytul">
                                    Faktura VAT&nbsp;
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                ORYGINAŁ/KOPIA</td>
                        </tr>
                        <tr class="identyfikatorZamowienia">
                            <td class="style2">
                                Numer zamówienia: <b>
                                    <%# Order.strIdentifier %>
                                </b>
                            </td>
                            <td class="style2">
                                &nbsp;</td>
                            <td align="left">
                                <div style="margin-left: 150px;">
                                    Forma płatności: <b>
                                        <%# Order.diPaymentTypeDctId.strName %>
                                    </b>
                                    <br />
                                    Sposób transportu: <b>
                                        <% if (Order!=null&&Order.diTransportTypeDctId.nNumber == TransportType.Przesylka)
                                           { %>
                                        Kurier
                                        <%}
                                           else
                                           { %>
                                        <%# Order.diTransportTypeDctId.strName %>
                                        <%} %>
                                    </b>
                                </div>
                            </td>
                        </tr>
                        <tr align="left">
                            <td valign="top" class="style2" style="padding-top: 40px;">
                                <div class="naglowkiNabywca" style="margin-left: 80px;">
                                    <h6>
                                        Sprzedawca:</h6>
                                    <p>
                                        „Firma do uzupełnienia”<br />
                                        ul. Tymczasowa 2<br />
                                        00-840 Warszawa<br />
                                        Tel. (xxx) xxx-xx-xx<br />
                                        Fax. (xxx) xxx-xx-xx<br />
                                        <br />
                                        NIP xxx-xxx-xx-xx<br />
                                        REGON xxxxxxxxx<br />
                                </div>
                            </td>
                            <td class="style2" style="padding-top: 40px;" valign="top">
                                &nbsp;</td>
                            <td valign="top" style="padding-top: 40px;">
                                <div class="naglowkiNabywca" style="margin-left: 150px;">
                                    <h6>
                                        Nabywca:
                                    </h6>
                                    <!-- koniec class naglowkiLeft -->
                                    <p>
                                        <%# Order.uUsrId.strEmail %>
                                        <br />
                                        <%# Order.uUsrId.strFirstname %>
                                        <%# Order.uUsrId.strLastname %>
                                        <br />
                                        tel. kom.
                                        <%# Order.uUsrId.strPhone %>
                                        <br />
                                        <%# Order.strAdrStreet %>
                                        <%# Order.strAdrHouseNo %>
                                        <%# string.IsNullOrEmpty(Order.strAdrFlatNo) ? string.Empty : "/" + Order.strAdrFlatNo %>
                                        <br />
                                        <%# Order.strAdrZipCode %>
                                        <%# Order.strAdrCity %>
                                        <br />
                                        tel. stacj.
                                        <%# Order.strAdrPhone %>
                                        <br />
                                        <br />
                                        <%# Order.bContactIfLackProduct ? "Klient wymaga kontaktu telefonicznego w razie braku jakiegokolwiek produktu." : string.Empty %>
                                    </p>
                                    <!-- koniec class naglowkiRight -->
                                </div>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="3" align="center">
                                <!-- koniec class naglowkitytul -->
                                <!-- koniec class identyfikatorZamowienia -->
                                
                                <!-- koniec class dataDostawy -->
                                <!-- koniec class naglowkiNabywca -->
                                <br />
                                <table width="800px" cellpadding="3" cellspacing="1" class="tabela" border="0">
                                    <tr>
                                        <th style="width: 165px; white-space: nowrap;">
                                            Lp.
                                        </th>
                                        <th style="width: 165px; white-space: nowrap;">
                                            Numer produktu
                                        </th>
                                        <th style="width: 124px; white-space: nowrap;">
                                            Nazwa produktu
                                        </th>
                                        <th style="width: 83px; white-space: nowrap;">
                                            Rozmiar
                                        </th>
                                        <th style="width: 124px; white-space: nowrap;">
                                            J.M.
                                        </th>
                                        <th style="width: 83px; white-space: nowrap;">
                                            Cena jedn. Netto
                                        </th>
                                        <th style="width: 84px; white-space: nowrap;">
                                            Ilość
                                        </th>
                                        <th style="width: 90px;">
                                            Wartość Netto
                                        </th>
                                        <th style="width: 83px; white-space: nowrap;">
                                            Stawka VAT
                                        </th>
                                        <th style="width: 83px; white-space: nowrap;">
                                            Wartość VAT
                                        </th>
                                        <th style="width: 83px; white-space: nowrap;">
                                            Wartość Brutto
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="rp_OrderItems" runat="server" DataSource='<%# ((PantryPrint)Container).Order.lOrderItem %>'>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="height: 21px; white-space: nowrap;">
                                                    <%#  ++i %>
                                                  
                                                </td>
                                                <td style="height: 21px;">
                                                    <%# Eval("strProductIdentifier")%>
                                                  
                                                </td>
                                                <td style="height: 21px; white-space: nowrap; text-align: right;">
                                                    <%# Eval("strProName")%>
                                                  
                                                </td>
                                                <td style="height: 21px; white-space: nowrap; text-align: right;">
                                                    <%# (string)GetWarehouseElementValue((OrderItem)Container.DataItem, "WrhSizeValue") %>
                                                </td>
                                                <td style="height: 21px; white-space: nowrap; text-align: right;">
                                                    <%#  GetWarehouseElementValue((OrderItem)Container.DataItem, "ProUnitDctIdStringValue")%>
                                                </td>
                                                <td style="height: 21px; white-space: nowrap; text-align: right;">
                                                   
                                                    <%# ((decimal)GetWarehouseElementValue((OrderItem)Container.DataItem, "WrhNettoRegularPriceValue")).ToString("c")%>
                                                </td>
                                                <td style="height: 21px; text-align: right;">
                                                    <%# (decimal)Eval("dCriQuantity") %>
                                                </td>
                                                <td style="height: 21px; white-space: nowrap; text-align: right;">
                                                    <%# ((decimal)GetNettoValue((OrderItem)Container.DataItem)).ToString("c")%>
                                                </td>
                                                <td style="height: 21px; white-space: nowrap; text-align: right;">
                                                    <%# GetWarehouseElementValue((OrderItem)Container.DataItem, "WrhVatStringValue")%>
                                                    %
                                                </td>
                                                <td style="height: 21px; white-space: nowrap; text-align: right;">
                                                    <%# GetVatValue((OrderItem)Container.DataItem).ToString("c")%>
                                                </td>
                                                <td style="height: 21px; white-space: nowrap; text-align: right;">
                                                    <%# ((decimal)Eval("dCriQuantity") * (decimal)Eval("nWrhPrice")).ToString("c")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr align="center">
                                        <td style="border: none;" colspan="5">
                                        </td>
                                        <td style="height: 31px; white-space: nowrap; text-align: right;">
                                            Suma:
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            <%# SumQuantityValue %>
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            <%# SumNettoValue.ToString("c")%>
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            22 %
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            <%# SumVatValue.ToString("c") %>
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            <%# ((decimal)((PantryPrint)Container).Order.nPriceSum).ToString("c") %>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td style="border: none;" colspan="6">
                                        </td>
                                        <td style="height: 31px; border-right: black 1px solid; border-left: black 1px solid;
                                            border-bottom: black 1px solid; white-space: nowrap; text-align: right;">
                                            Transport:
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            <%# 
                                                    //((PantryPrint)Container).Order.nDeliveryPrice == 0 ? "0 zł" : ((decimal)((PantryPrint)Container).Order.nDeliveryPrice - 0.22M * (decimal)((PantryPrint)Container).Order.nDeliveryPrice).ToString("c")
                                                    ((PantryPrint)Container).Order.nDeliveryPrice == 0 ? "0 zł" : ((decimal)((PantryPrint)Container).Order.nDeliveryPrice/1.22M).ToString("c")
	                                
                                            %>
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            22 %
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            <%# 
                                                    //((PantryPrint)Container).Order.nDeliveryPrice == 0 ? "0 zł" : ((decimal)((PantryPrint)Container).Order.nDeliveryPrice*0.22M).ToString("c")
                                                    ((PantryPrint)Container).Order.nDeliveryPrice == 0 ? "0 zł" : ((decimal)((PantryPrint)Container).Order.nDeliveryPrice - ((decimal)((PantryPrint)Container).Order.nDeliveryPrice/1.22M)).ToString("c")
	                                
                                            %>
                                        </td>
                                        <td style="height: 33px; border-bottom: black 1px solid; white-space: nowrap; text-align: right;">
                                            <%# 
                                                    ((PantryPrint)Container).Order.nDeliveryPrice == 0 ? "0 zł" : ((decimal)((PantryPrint)Container).Order.nDeliveryPrice).ToString("c")
	                                
                                            %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: none;" colspan="6">
                                        </td>
                                        <td style="height: 31px; border-right: black 1px solid; border-left: black 1px solid;
                                            border-bottom: black 1px solid; white-space: nowrap; text-align: right;">
                                            Razem:
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            <%# //((decimal) (  SumNettoValue + ((PantryPrint)Container).Order.nDeliveryPrice - (0.22M * ((PantryPrint)Container).Order.nDeliveryPrice)  ) ).ToString("c")
                                                    ((decimal) (  SumNettoValue + ((PantryPrint)Container).Order.nDeliveryPrice/1.22M)).ToString("c")%>
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            22 %
                                        </td>
                                        <td style="height: 33px; white-space: nowrap; text-align: right;">
                                            <%# //((decimal)(SumVatValue + 0.22M * ((PantryPrint)Container).Order.nDeliveryPrice)).ToString("c")
                                                    ((decimal)(SumVatValue + (decimal)((PantryPrint)Container).Order.nDeliveryPrice - ((decimal)((PantryPrint)Container).Order.nDeliveryPrice/1.22M))).ToString("c") %>
                                        </td>
                                        <td style="height: 33px; border-bottom: black 1px solid; white-space: nowrap; text-align: right;">
                                            <%# ((decimal)((PantryPrint)Container).Order.nPriceSum + ((PantryPrint)Container).Order.nDeliveryPrice ).ToString("c") %>
                                        </td>
                                    </tr>
                                   
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <div class="Wpisywanie">
                                    <div class="header">
                                        Uwagi kupującego
                                    </div>
                                    <div class="wlasneNotatki" style="text-align: left;">
                                        <asp:Label ID="lbl_Notes" runat="server" Text='<%# Order.strDescription %>' Style="margin: 10px 10px 10px 10px;
                                            font-size: small;"></asp:Label>
                                        
                                    </div>
                                    <!-- koniec class wlasneNotatki -->
                                </div>
                            </td>
                        </tr>
                        <tr align="left">
                            <td style="padding-top: 10px;" colspan="3">
                                <div class="Wpisywanie" style="margin-left: 40px;">
                                    <!-- koniec class komentarze -->
                                    <div class="podpisOdbiorcy">
                                        ..............................................<br />
                                        Data i podpis Sprzedającego</div>
                                    <!-- koniec class podpisOdbiorcy -->
                                </div>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="3">
                                <div style="margin-left: 40px; padding-top: 40px;">
                                    <h4>
                                        Uwaga</h4>
                                    Niniejszy dokument wypełniony i podpisany przez Sprzedającego jest dowodem zakupu
                                    oraz podstawą do składania reklamacji przez Kupującego
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 60px;" colspan="3">
                                <div>
                                    <asp:Button ID="btnPrint" CssClass="printbutton" runat="server" Text="Drukuj" OnClientClick="window.print(); return false;" />
                                    <asp:Button ID="btnClose" CssClass="printbutton" runat="server" Text="Zamknij" OnClientClick="window.close();" />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <!-- koniec class danePotrawy -->
                    <!-- koniec class Wpisywanie -->
                    <!-- koniec class Wpisywanie -->
                </div>
                <!-- koniec container -->
            </asp:Panel>
            <asp:Panel ID="noOrderPanel" runat="server" Visible="false">
                <div>
                    Niestety podane zamówienie nie istnieje</div>
            </asp:Panel>--%>
            <table class="style4">
                <tr>
                    <td class="style2" rowspan="3" style="border-width: 1px; border-style: solid; font-size: 7px">
                        pieczęć firmy
                    </td>
                    <td class="style5" colspan="2" rowspan="2" style="border-style: solid; border-width: 1px;
                        background-color: #C0C0C0; font-weight: bold;">
                        Faktura VAT
                    </td>
                    <td class="style1" style="border-style: solid; border-width: 1px">
                        <%#  ((Administration_Sales_InvoicePrint)Container).Invoice.Number %>
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="font-weight: bold">
                        ORYGINAŁ/KOPIA
                    </td>
                </tr>
                <tr>
                    <td class="style7" colspan="2" style="border-width: 1px; border-style: solid; font-size: 12px">
                        <%#((Administration_Sales_InvoicePrint)Container).Invoice.Date.ToString("yyyy-MM-dd") %><br />
                        data wystawienia
                    </td>
                    <td class="style8" style="border-width: 1px; border-style: solid; font-size: 12px">
                        <%#((Administration_Sales_InvoicePrint)Container).Invoice.Date.ToString("yyyy-MM-dd") %><br />
                        data sprzedaży
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style9" colspan="2" style="border-width: 1px; border-style: solid;
                        font-size: 10px">
                        Sprzedawca: Test Sp. z.o.o<br />
                        Adres: ul. Testowa 100, 02-222 Testowa<br />
                        NIP: 734-111-11-11
                    </td>
                    <td align="left" class="style9" colspan="2" style="border-width: 1px; border-style: solid;
                        font-size: 10px">
                        Nabywca: <%#((Administration_Sales_InvoicePrint)Container).Invoice.Order.CustomerFacility.Customer.Name %><br />
                        Adres: <%# TworzAdres(((Administration_Sales_InvoicePrint)Container).Invoice.Order.CustomerFacility) %><br />
                        NIP: <%#((Administration_Sales_InvoicePrint)Container).Invoice.Order.CustomerFacility.Customer.NIP %>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style10" colspan="4" style="border-width: 1px; border-style: solid;
                        font-size: 12px">
                        Forma płatności: Przelew Termin płatności: <%#((Administration_Sales_InvoicePrint)Container).Invoice.Date.AddDays(14).ToString("yyyy-MM-dd") %><br />
                        Bank: Konto: 11 1111 1111 1111 1111 1111 1111
                    </td>
                </tr>
            </table>
            <table cellpadding="3" cellspacing="1" border="0" style="width: 800px" class="tabela">
                <tr>
                    <th style="white-space: nowrap;" class="style13">
                        Lp.
                    </th>
                    <th style="white-space: nowrap;" class="style14">
                        Nazwa produktu
                    </th>
                    <th style="white-space: nowrap;" class="style23">
                        Ilość
                    </th>
                    <th style="white-space: nowrap;" class="style16">
                        J.M.
                    </th>
                    <th style="width: 84px; white-space: nowrap;">
                        Cena netto
                    </th>
                    <th class="style22">
                        Wartość Netto
                    </th>
                    <th style="white-space: nowrap;" class="style21">
                        VAT [%]
                    </th>
                    <th style="width: 83px; white-space: nowrap;">
                        Kwota VAT
                    </th>
                    <th style="white-space: nowrap;" class="style19">
                        Wartość Brutto
                    </th>
                </tr>
                <asp:Repeater ID="rp_OrderItems" runat="server" DataSource='<%# ((Administration_Sales_InvoicePrint)Container).Invoice.Order.OrderLines %>'>
                    <ItemTemplate>
                        <tr>
                            <td style="height: 21px; white-space: nowrap;">
                                <%#  ++i %>
                            </td>
                            <td style="height: 21px;">
                                <%# ((OrderLine)Container.DataItem).Product.Name%>
                            </td>
                            <td style="height: 21px; white-space: nowrap; text-align: right;">
                                <%#Eval("Quantity")%>
                            </td>
                            <td style="height: 21px; white-space: nowrap; text-align: right;">
                                szt
                            </td>
                            <td style="height: 21px; white-space: nowrap; text-align: right;">
                                <%# String.Format("{0:0.00 zł}",CenaNetto(((OrderLine)Container.DataItem).Product.Price,Int32.Parse(((OrderLine)Container.DataItem).Product.Tax.Value))) %>
                            </td>
                            <td style="height: 21px; white-space: nowrap; text-align: right;">
                                <%# String.Format("{0:0.00 zł}", CenaNetto(((OrderLine)Container.DataItem).Product.Price,Int32.Parse(((OrderLine)Container.DataItem).Product.Tax.Value)) * 
                                    ((OrderLine)Container.DataItem).Quantity)%>
                            </td>
                            <td style="height: 21px; text-align: right;">
                                <%#  ((OrderLine)Container.DataItem).Product.Tax.Value %>%
                            </td>
                            <td style="height: 21px; text-align: right;">
                                <%# Eval("Tax", "{0:0.00 zł}")%>
                                <%--<%# String.Format("{0:0.00 zł}",KwotaVAT(((OrderLine)Container.DataItem).Product.Price,
                                    CenaNetto(((OrderLine)Container.DataItem).Product.Price,Int32.Parse(((OrderLine)Container.DataItem).Product.Tax.Value)),    
                                    ((OrderLine)Container.DataItem).Quantity))%>--%>
                            </td>
                            <td style="height: 21px; text-align: right;">
                                <%#Eval("Total", "{0:0.00 zł}")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="4" style="border-style: none">
                    </td>
                    <td style="font-weight: bold; background-color: #C0C0C0;">
                        Razem
                    </td>
                    <td style="text-align: right;">
                        <%# String.Format("{0:0.00 zł}",((Administration_Sales_InvoicePrint)Container).Invoice.Order.SubTotal) %>
                    </td>
                    <td style="text-align: right;">
                        X
                    </td>
                    <td style="text-align: right;">
                        <%# String.Format("{0:0.00 zł}",((Administration_Sales_InvoicePrint)Container).Invoice.Order.TaxAmount) %>
                    </td>
                    <td style="text-align: right;">
                        <%# String.Format("{0:0.00 zł}",((Administration_Sales_InvoicePrint)Container).Invoice.Order.Total) %>
                    </td>
                </tr>
                <tr>
                    <td colspan="9" style="border-style: none; text-align: right;" class="style24">
                    </td>
                </tr>
                <tr>
                    <td colspan="9" style="border-width: 1px; border-style: solid; font-size: 12px;"
                        align="left" class="style25">
                        Razem do zapłaty:
                        <%# String.Format("{0:0.00 zł}",((Administration_Sales_InvoicePrint)Container).Invoice.Order.Total) %>
                    </td>
                </tr>
                <tr>
                    <td colspan="9" style="border-width: 1px; border-style: solid; font-size: 12px;"
                        align="left" class="style25">
                        Kwota słownie:
                        <%# KwotaSlownie(String.Format("{0:0.00}",((Administration_Sales_InvoicePrint)Container).Invoice.Order.Total)) %>
                    </td>
                </tr>
                <tr>
                    <td colspan="9" style="border-width: 1px; border-style: none; font-size: 12px;" align="left"
                        class="style26">
                    </td>
                </tr>
            </table>
            <table cellpadding="3" cellspacing="1" border="0" style="width: 800px" class="tabela">
                <tr>
                    <td class="style28" style="font-size: 8px; vertical-align: bottom;" width="50%">
                        imię, nazwisko i podpis osoby upoważnionej do odebrania dokumentu
                    </td>
                    <td class="style27" style="font-size: 8px; vertical-align: bottom;" width="50%">
                        imię, nazwisko i podpis osoby upoważnionej do wystawienia dokumentu
                    </td>
                </tr>
            </table>
            <div style="width: 800px; text-align: center; ">
                <asp:Button ID="btnPrint" CssClass="printbutton" runat="server" Text="Drukuj" OnClientClick="window.print(); return false;" />
                <asp:Button ID="btnClose" CssClass="printbutton" runat="server" Text="Zamknij" OnClientClick="window.close();" />
            </div>
        </center>
    </div>
    </form>
</body>
</html>
