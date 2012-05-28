using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Customers_CustomerFacilities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDowns();
            BindData();
        }
    }

    private void FillDropDowns()
    {
        ctrlSelectCustomer.EmptyItemText = "Wszyscy klienci";
        ctrlSelectCustomer.BindData();
        ctrlSelectTerritory.BindData();
    }

    private void BindData()
    {
        string facName = txtName.Text;
        ctrlFacilityList.BindList(ctrlSelectCustomer.SelectedCustomerId, facName, ctrlSelectTerritory.SelectedTerritoryId);
    }

    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Customers/CustomerFacilityAdd.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                BindData();
            }
            catch (Exception exc)
            {
                // ProcessException(exc);
            }
        }
    }
    protected void btnRemoveFilter_Click(object sender, EventArgs e)
    {
        txtName.Text = string.Empty;
        ctrlSelectCustomer.SelectedCustomerId = Guid.Empty;
        ctrlSelectTerritory.SelectedTerritoryId = Guid.Empty;
        BindData();
    }
}
