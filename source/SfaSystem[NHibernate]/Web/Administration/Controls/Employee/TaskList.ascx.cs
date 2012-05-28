using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Employee_EmployeeTaskList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvTasks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTasks.PageIndex = e.NewPageIndex;
        //BindList();
    }

    protected void gvTasks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Task task = (Task)e.Row.DataItem;
            //Label lblAssignedTo = e.Row.FindControl("lblAssignedTo") as Label;
            //Label lblGivenBy = e.Row.FindControl("lblGivenBy") as Label;
            //Label lblCreatedBy = e.Row.FindControl("lblCreatedBy") as Label;
            Label lblStatus = e.Row.FindControl("lblStatus") as Label;
            lblStatus.Text = task.TaskStatus.Value;
        }
    }


    public void BindList()
    {
        gvTasks.DataSource = BasicService<Task, Guid>.GetAll();
        gvTasks.DataBind();
    }

    public void BindList(Employee assignedTo, Employee givenBy, Employee createdBy, Dictionary taskStatus,
        bool showOnlyApproved, DateTime? dateCreatedFrom, DateTime? dateCreatedTo)
    {
        gvTasks.DataSource = EmployeeService.GetTasks(assignedTo, givenBy,
            createdBy, taskStatus, showOnlyApproved, dateCreatedFrom, dateCreatedTo);
        gvTasks.DataBind();
    }

    //public void BindList(Guid customerID, string facName, Guid territoryID)
    //{
    //    Customer cust = null;
    //    Territory terr = null;
    //    if (customerID != Guid.Empty)
    //    {
    //        cust = BasicService<Customer, Guid>.GetByID(customerID);
    //    }
    //    if (territoryID != Guid.Empty)
    //    {
    //        terr = BasicService<Territory, Guid>.GetByID(territoryID);
    //    }
    //    gvFacilities.DataSource = CustomerService.GetFacilities(string.Empty, cust, terr);
    //    gvFacilities.DataBind();
    //}
}
