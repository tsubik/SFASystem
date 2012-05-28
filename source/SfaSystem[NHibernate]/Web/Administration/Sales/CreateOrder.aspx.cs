using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Sales_CreateOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        if (StateItems.IsInOrderMode)
        {
            Order order = StateItems.CurrentOrder;
            if (order.CustomerFacility != null)
                lblZamowienieDla.Text = order.CustomerFacility.Name + " - firma " + order.CustomerFacility.Customer.Name;
            gvOrderLines.DataSource = order.OrderLines;
            gvOrderLines.DataBind();
            txtComment.Text = order.Comment;
            UpdateSummary(order);
        }
    }

    private void UpdateSummary(Order order)
    {
        if (order.OrderLines == null || order.OrderLines.Count == 0)
            summary.Visible = false;
        else
        {
            summary.Visible = true;
            lblNetto.Text = order.SubTotal.ToString("0.00 zł");
            lblTax.Text = order.TaxAmount.ToString("0.00 zł");
            lblBrutto.Text = order.Total.ToString("0.00 zł");
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
    public float CenaNetto(decimal brutto, int tax)
    {
        float nettoPrice = (float)brutto / (1 + (tax / 100.0f));
        return nettoPrice;
    }
    protected void btnRemoveProduct_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).Parent.Parent;
        HiddenField hidden = row.Cells[1].FindControl("hiddenID") as HiddenField;
        Guid productID  = new Guid(hidden.Value);
        Product product = BasicService<Product, Guid>.GetByID(productID);
        OrderManager.RemoveProductFromOrder(product);
        BindData();
        MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
        messageBox.ShowSuccess("Produkt " + product.Name + " zastał usunięty z zamówienia.");
    }

    protected void btnWybierzPlacowka_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Customers/CustomerFacilities.aspx");
    }
    protected void btnDodajPozycje_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Products/Products.aspx");
    }

    protected void btnCancelOrder_Click(object sender, EventArgs e)
    {
        OrderManager.CancelOrder();
        Response.Redirect("~/Administration/Sales/Orders.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
        foreach (GridViewRow row in gvOrderLines.Rows)
        {
            
            int quantity = 1;
            TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;
            if (!Int32.TryParse(txtQuantity.Text, out quantity))
            {
                messageBox.ShowError("Błąd walidacji liczby : "+txtQuantity.Text +" nie jest liczbą");
                return;
            }
            HiddenField hidden = row.FindControl("hiddenID") as HiddenField;
            Guid productID = new Guid(hidden.Value);
            OrderManager.UpdateQuantity(productID, quantity);
            BindData();
        }
        messageBox.ShowSuccess("Pozycje zamówienia zostały zauktualizowane.");
    }
    protected void btnAcceptOrder_Click(object sender, EventArgs e)
    {
        Order order = StateItems.CurrentOrder;
        if (order != null)
        {
            MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
            if (order.CustomerFacility == null)
            {
                messageBox.ShowValidateError("Wybierz klienta oraz placówkę dla której składane jest zamówienie.");
                return;
            }
            if (order.OrderLines == null || order.OrderLines.Count == 0)
            {
                messageBox.ShowValidateError("Nie można złożyć pustego zamówienia.");
                return;
            }

            order.Employee = SFAContext.Current.Employee;
            SalesService.InsertOrder(order);
            StateItems.CurrentOrder = null;
            StateItems.IsInOrderMode = false;
            StateItems.Message = new Message(MessageType.Success, "Zamówienie zostało poprawnie złożone");
            Response.Redirect("~/Administration/Sales/Orders.aspx");
        }
    }

    protected void btnSaveComment_Click(object sender, EventArgs e)
    {
        Order order = StateItems.CurrentOrder;
        if (order != null)
            order.Comment = txtComment.Text;
    }
}
