using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.WebUtils;
using SFASystem.Services;

public partial class Administration_Controls_MyTask : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        Employee employee = SFAContext.Current.Employee;
        if (employee != null)
        {
            lstTasks.DataSource = EmployeeService.GetNewestTaskForEmployee(employee, 5);
            lstTasks.DataBind();
        }
    }
    protected void lstTasks_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem item = (ListViewDataItem) e.Item;
        Task task = item.DataItem as Task;

        if (task != null)
        {
            Label lblDateTime = (Label)item.FindControl("lblDateTime");
            int daysDelta = (DateTime.Now - task.DateCreated).Days;
            if (daysDelta == 0)
                lblDateTime.Text = "Dzisiaj";
            if (daysDelta == 1)
                lblDateTime.Text = "Wczoraj";
            if (daysDelta > 1)
                lblDateTime.Text = daysDelta + " dni temu";
        }

    }
}
