using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SFASystem.DataAccess.SqlServerNH;
using SFASystem.Services;
using SFASystem.Domain;

namespace SFASystem.Web.Administration.Controls
{
    public partial class EmployeesListControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                selectRoleControl.BindData();
                BindGrid();
            }
        }

        private void BindGrid()
        {
            
            //gvEmployees.DataSource = EmployeeManager.GetEmployees(false);
            gvEmployees.DataSource = EmployeeService.GetEmployees(selectRoleControl.SelectedRoleID);
            gvEmployees.DataBind();
        }

        protected void gvEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblImie = e.Row.FindControl("lblImie") as Label;
                Label lblNazwisko = e.Row.FindControl("lblNazwisko") as Label;
                Label lblStanowisko = e.Row.FindControl("lblStanowisko") as Label;

                SFASystem.Domain.Employee employee = e.Row.DataItem as SFASystem.Domain.Employee;
                //Employee employee = e.Row.DataItem as Employee;
                if (employee.Contact != null)
                {
                    lblImie.Text = employee.Contact.FirstName;
                    lblNazwisko.Text = employee.Contact.LastName;
                }
                else
                {
                    lblImie.Text = "not filled";
                    lblNazwisko.Text = "not filled";
                }
                IList<Role> roles = employee.Roles;
                foreach (Role role in roles)
                    lblStanowisko.Text += role.Name + ", ";
                int idx = lblStanowisko.Text.LastIndexOf(',');
                if(idx!=-1)
                    lblStanowisko.Text = lblStanowisko.Text.Remove(idx, 2);
            }
        }

        protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployees.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/Employees/EmployeeAdd.aspx");
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
            selectRoleControl.SelectedRoleID = Guid.Empty;
            BindGrid();
        }
}
}