using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Sales_OrderDetails : System.Web.UI.Page
{
    private void BindData()
    {
        Order order = BasicService<Order, Guid>.GetByID(this.OrderID);
        if (order != null)
        {
            this.lblOrderStatus.Text = order.OrderStatus.Value;
            //TODO czy można anulować zamówienie

            this.lblOrderID.Text = order.OrderID.ToString();
            this.lblIdentyfikator.Text = order.Identifier;    //TODO - uzupełnić

            this.lblKlient.Text = order.CustomerFacility.Customer.Name;
            this.lblPlacowka.Text = order.CustomerFacility.Name;
            this.lblOrderDate.Text = order.OrderDate.ToString();    //TODO - Wspólny format dat dla całej aplikacji zrobić Helpera

            this.lblWartNetto.Text = order.SubTotal.ToString("0.00 zł");
            this.lblPodatek.Text = order.TaxAmount.ToString("0.00 zł");
            this.lblWartBrutto.Text = order.Total.ToString("0.00 zł");

            this.lblPracownik.Text = order.Employee.FriendlyName;

            this.lblRegion.Text = order.Territory.Name;

            //Dane do wysyłki
            if (order.CustomerFacility != null)
            {
                lblShipFacility.Text = order.CustomerFacility.Name + "(" + order.CustomerFacility.Customer.Name + ")";
                lblShipStreet.Text = order.CustomerFacility.Address.Street;
                lblShipCity.Text = order.CustomerFacility.Address.City.Name;
                lblShipCountry.Text = order.CustomerFacility.Address.Country.Name;
                lblShipHouseNr.Text = order.CustomerFacility.Address.HouseNr + "/" + order.CustomerFacility.Address.ApartmentNr;
                lblShipZipCode.Text = order.CustomerFacility.Address.ZipCode;
            }
            if (order.OrderStatus.DictionaryNumber == (int)OrderStatusEnum.Nowe)
            {
                btnApproveOrder.Visible = true;

                btnSetOrderShipped.Visible = false;
            }
            if (order.OrderStatus.DictionaryNumber == (int)OrderStatusEnum.WRealizacji)
            {
                btnApproveOrder.Visible = false;
                btnSetOrderShipped.Visible = true;

            }
            if (order.OrderStatus.DictionaryNumber == (int)OrderStatusEnum.Wyslano)
            {
                btnCancelOrder.Visible = false;
                btnSetOrderShipped.Visible = false;
            }
            if (order.OrderStatus.DictionaryNumber == (int)OrderStatusEnum.Anulowane)
            {
                btnSetOrderShipped.Visible = false;
                btnCreateInvoice.Visible = false;
                btnCancelOrder.Visible = false;
                btnCreateInvoice.Visible = false;
            }
            if (SalesService.HasOrderInvoice(order))
            {
                btnCreateInvoice.Visible = false;
                btnPrintInvoice.Visible = true;
                Invoice invoice = BasicService<Invoice, Guid>.GetAll().Where(i => i.Order == order).SingleOrDefault();
                if (invoice != null)
                    btnPrintInvoice.OnClientClick = string.Format(btnPrintInvoice.OnClientClick, ResolveUrl("~/Administration/Sales/InvoicePrint.aspx") + "?InvoiceID=" + invoice.InvoiceID.ToString());
            }
            else
            {
                if (order.OrderStatus.DictionaryNumber != (int)OrderStatusEnum.Nowe
                    && order.OrderStatus.DictionaryNumber != (int)OrderStatusEnum.Anulowane)
                {
                    btnCreateInvoice.Visible = true;
                }
                btnPrintInvoice.Visible = false;
            }

            gvOrderLines.DataSource = order.OrderLines;
            gvOrderLines.DataBind();
        }
        else
            Response.Redirect("Orders.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    protected void btnApproveOrder_Click(object sender, EventArgs e)
    {
        Order order = BasicService<Order, Guid>.GetByID(this.OrderID);
        SalesService.ApproveOrder(order);
        MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
        messageBox.ShowSuccess("Zmieniono status zamówienia na \"W realizacji\"");
        //MailHelper.SendApprovedOrderEmail("tsubik@gmail.com", order);
        BindData();
    }

    protected void btnSetOrderShipped_Click(object sender, EventArgs e)
    {
        Order order = BasicService<Order, Guid>.GetByID(this.OrderID);
        MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
        messageBox.ShowSuccess("Zmieniono status zamówienia na \"Wysłane\"");
        SalesService.SetOrderAsShipped(order);
        //MailHelper.SendShippedOrderEmail("tsubik@gmail.com", order);
        BindData();
    }
    protected void btnCreateInvoice_Click(object sender, EventArgs e)
    {
        Order order = BasicService<Order, Guid>.GetByID(this.OrderID);
        SalesService.CreateInvoice(order);
        MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
        messageBox.ShowSuccess("Utworzono fakturę");
        BindData();
    }

    public Guid OrderID
    {
        get
        {
            return CommonHelper.QueryStringGUID("OrderID");
        }
    }

    protected void gvOrderLines_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrderLines.PageIndex = e.NewPageIndex;
        //BindList();
    }

    protected void gvOrderLines_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblLp = e.Row.FindControl("lblLp") as Label;
            lblLp.Text = (e.Row.RowIndex + 1).ToString();

        }
    }

    protected void btnCancelOrder_Click(object sender, EventArgs e)
    {
        Order order = BasicService<Order, Guid>.GetByID(this.OrderID);
        SalesService.CancelOrder(order);
        MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
        messageBox.ShowSuccess("Zmieniono status zamówienia na \"Anulowane\"");
        BindData();
    }
}
