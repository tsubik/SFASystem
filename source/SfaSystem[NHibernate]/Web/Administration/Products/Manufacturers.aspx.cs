using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils.Security;
using System.Web.UI.HtmlControls;

public partial class Administration_Products_Manufacturers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
            if (!SecurityHelper.CanAddEditManufacturers(Context.User))
                btnAddNew.Visible = false;
        }
    }

    private void BindGrid()
    {
        //gvEmployees.DataSource = EmployeeManager.GetEmployees(false);
        gvManufacturers.DataSource = BasicService<Manufacturer, Guid>.GetAll();
        gvManufacturers.DataBind();
    }

    protected void gvManufacturers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!SecurityHelper.CanAddEditManufacturers(Context.User))
            {
                HtmlAnchor lnk = (HtmlAnchor)e.Row.FindControl("lnkDetails");
                lnk.InnerText = "Szczegóły";
                lnk.Title = "Szczegóły procudenta";
            }
        }
    }

    protected void gvManufacturers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvManufacturers.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Products/ManufacturerAdd.aspx");
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    if (Page.IsValid)
    //    {
    //        try
    //        {
    //            BindGrid();
    //        }
    //        catch (Exception exc)
    //        {
    //            // ProcessException(exc);
    //        }
    //    }
    //}
    //protected void btnRemoveFilter_Click(object sender, EventArgs e)
    //{
    //    selectRoleControl.SelectedRoleID = Guid.Empty;
    //    BindGrid();
    //}
}
