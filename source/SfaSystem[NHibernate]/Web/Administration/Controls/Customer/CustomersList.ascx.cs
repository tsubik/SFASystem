using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SFASystem.DataAccess.SqlServerNH;
using SFASystem.Services;
using SFASystem.Domain;
using System.Web.UI.HtmlControls;

namespace SFASystem.Web.Administration.Controls
{
    public partial class CustomersListControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            gvCustomers.DataSource = CustomerService.GetCustomers(txtName.Text, txtNIP.Text, txtREGON.Text);
            gvCustomers.DataBind();
        }

        protected void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCustomers.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/Customers/CustomerAdd.aspx");
        }
        protected void SearchButton_Click(object sender, EventArgs e)
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
            txtName.Text = string.Empty;
            txtNIP.Text = string.Empty;
            txtREGON.Text = string.Empty;
            BindGrid();
        }
        protected void gvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HtmlAnchor lnkDetails = (HtmlAnchor)e.Row.FindControl("lnkDetails");
                if (!(Context.User.IsInRole("Administrator") || Context.User.IsInRole("SalesDirector")))
                {
                    lnkDetails.InnerText = "Szczegóły";
                    lnkDetails.Title = "Przejdź do szczegółów";
                }
            }
        }
}
}