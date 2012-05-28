using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Controls_TaskToApproveBox : System.Web.UI.UserControl
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
            lstTasks.DataSource = EmployeeService.GetTaskToApprove(employee, 5);
            lstTasks.DataBind();
        }
    }
}
