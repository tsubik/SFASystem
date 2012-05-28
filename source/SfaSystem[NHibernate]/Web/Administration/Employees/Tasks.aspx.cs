using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Employees_EmployeeTasks : System.Web.UI.Page
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
        ctrlSelectAssignedTo.BindData();
        ctrlSelectCreatedBy.BindData();
        ctrlSelectGivenBy.BindData();
        ctrlTaskStatus.BindData();
        BindList();
    }

    private void BindList()
    {
        Employee assignedTo = BasicService<Employee, Guid>.GetByID(ctrlSelectAssignedTo.SelectedEmployeeID);
        Employee givenBy = BasicService<Employee, Guid>.GetByID(ctrlSelectGivenBy.SelectedEmployeeID);
        Employee createdBy = BasicService<Employee, Guid>.GetByID(ctrlSelectCreatedBy.SelectedEmployeeID);
        Dictionary taskStatus = BasicService<Dictionary, Guid>.GetByID(ctrlTaskStatus.SelectedStatusID);

        DateTime outer;
        DateTime? startDate = null;
        DateTime? endDate = null;
        if (DateTime.TryParse(txtStartDate.Text, out outer))
            startDate = outer;
        if (DateTime.TryParse(txtEndDate.Text, out outer))
            endDate = outer;

        ctrlTaskList.BindList(assignedTo, givenBy, createdBy,
            taskStatus, chxApproved.Checked, startDate, endDate);
    }

    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Employees/TaskAdd.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                BindList();
            }
            catch (Exception exc)
            {
                // ProcessException(exc);
            }
        }
    }
    protected void btnRemoveFilter_Click(object sender, EventArgs e)
    {
        txtEndDate.Text = string.Empty;
        txtStartDate.Text = string.Empty;
        chxApproved.Checked = false;
        ctrlSelectAssignedTo.SelectedEmployeeID = Guid.Empty;
        ctrlSelectCreatedBy.SelectedEmployeeID = Guid.Empty;
        ctrlSelectGivenBy.SelectedEmployeeID = Guid.Empty;
        ctrlTaskStatus.SelectedStatusID = Guid.Empty;
        BindList();
    }
}
