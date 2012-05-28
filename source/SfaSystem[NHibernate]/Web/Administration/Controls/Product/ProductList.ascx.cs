using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SFASystem.Domain;
using SFASystem.DataAccess.SqlServerNH;
using SFASystem.Services;
using SFASystem.WebUtils;
using SFASystem.WebUtils.Security;

public partial class Administration_Controls_ProductList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDowns();
            BindGrid();

            if (!SecurityHelper.CanAddEditProducts(Context.User))
                btnAddNew.Visible = false;
        }
    }

    private void FillDropDowns()
    {
        ctrlSelectedProductGroup.EmptyItemText = "Wszystkie";
        ctrlSelectedProductGroup.BindData();
        ctrlSelectManufacturer.BindData();
    }

    private void BindGrid()
    {
        string productName = txtProductName.Text;
        string productCode = txtProductCode.Text;
        ProductGroup prodGroup = BasicService<ProductGroup, Guid>.GetByID(ctrlSelectedProductGroup.SelectedProductGroupId);
        Manufacturer manufacturer = BasicService<Manufacturer, Guid>.GetByID(ctrlSelectManufacturer.SelectedManufacturerID);
        //gvEmployees.DataSource = EmployeeManager.GetEmployees(false);

        gvProducts.Columns[0].Visible = true;
        gvProducts.Columns[10].Visible = StateItems.IsInOrderMode;
        gvProducts.DataSource = CatalogService.GetProducts(productCode,productName ,prodGroup, manufacturer);
        gvProducts.DataBind();
        gvProducts.Columns[0].Visible = false;
    }

    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNettoPrice = (Label)e.Row.FindControl("lblNettoPrice");
            Product product = (Product) e.Row.DataItem;
            int tax = Int32.Parse(product.Tax.Value);
            float nettoPrice = (float)product.Price / (1 + (tax/100.0f));

            if (!SecurityHelper.CanAddEditProducts(Context.User)) 
            {
                HtmlAnchor lnk = (HtmlAnchor)e.Row.FindControl("lnkDetails");
                lnk.InnerText = "Szczegóły";
                lnk.Title = "Szczegóły produktu";
            }

            lblNettoPrice.Text = String.Format("{0:0.00} zł", nettoPrice);
            e.Row.Cells[0].Visible = false;
        }
    }

    protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProducts.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void btnAddToOrder_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).Parent.Parent;
        Guid productID = new Guid(row.Cells[0].Text);
        Product product = BasicService<Product, Guid>.GetByID(productID);
        OrderManager.InsertProductToOrder(product);
        MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
        messageBox.ShowSuccess("Produkt " + product.Name + " dodany do zamówienia.");
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Products/ProductAdd.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                BindGrid();
            }
            catch (Exception exc)
            {
               // ProcessException(exc);
            }
        }
    }
    protected void btnRemoveFilter_Click(object sender, EventArgs e)
    {
        txtProductCode.Text = string.Empty;
        txtProductName.Text = string.Empty;
        ctrlSelectedProductGroup.SelectedProductGroupId = Guid.Empty;
        BindGrid();
    }
}
