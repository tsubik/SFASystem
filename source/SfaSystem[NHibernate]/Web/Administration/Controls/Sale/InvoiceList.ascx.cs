using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Sale_InvoiceList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnMarkAsPaid_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).Parent.Parent;
        Guid invoiceID = new Guid(row.Cells[0].Text);

        SalesService.MarkInvoiceAsPaid(invoiceID);
        MessageBoxControl msgBox = (MessageBoxControl)Page.Master.FindControl("messageBox");
        msgBox.ShowSuccess("Faktura oznaczona jako zapłacona.");
        BindList(BasicService<Dictionary, Guid>.GetByID(this.DictID));
    }

    private Guid DictID
    {
        get
        {
            return (Guid) ViewState["DictID"];
        }
        set
        {
            ViewState["DictID"] = value;
        }
    }

    public void BindList(Dictionary status)
    {
        if (status != null)
            this.DictID = status.Dictionaryid;
        else
            this.DictID = Guid.Empty;
        gvInvoices.Columns[0].Visible = true;
        gvInvoices.DataSource = SalesService.GetInvoices(status).OrderByDescending( i=> i.Date).ToList();
        gvInvoices.DataBind();
        gvInvoices.Columns[0].Visible = false;
    }

    protected void gvInvoices_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInvoices.PageIndex = e.NewPageIndex;
        BindList(BasicService<Dictionary, Guid>.GetByID(this.DictID));
    }



    protected void gvInvoices_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Invoice invoice = (Invoice)e.Row.DataItem;

            Label lblOrderNumber = e.Row.FindControl("lblOrderNumber") as Label;
            Label lblCustomer = e.Row.FindControl("lblCustomer") as Label;
            Button btnMarkAsPaid = e.Row.FindControl("btnMarkAsPaid") as Button;
            Button btnPrint = e.Row.FindControl("btnPrint") as Button;

            lblCustomer.Text = invoice.Order.CustomerFacility.Customer.Name;
            lblOrderNumber.Text = invoice.Order.Identifier;

            if (invoice.IsPaid)
                btnMarkAsPaid.Visible = false;
            e.Row.Cells[0].Visible = false;
            btnPrint.OnClientClick = string.Format(btnPrint.OnClientClick, ResolveUrl("~/Administration/Sales/InvoicePrint.aspx") + "?InvoiceID=" + invoice.Invoiceid.ToString());
        }
    }

   
}
