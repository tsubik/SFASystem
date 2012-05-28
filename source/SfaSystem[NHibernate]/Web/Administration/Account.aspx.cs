using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;


public partial class Administration_Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SFAContext.Current.Employee == null)
            Response.Redirect("~/Login.aspx");

        if (!Page.IsPostBack)
        {
            BindData();
        }
    }
    private void BindData()
    {
        Employee employee = SFAContext.Current.Employee;
        employeeInfo.EmployeeID = employee.Employeeid;
        employeeAdditional.Employee = employee;
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Employee employee = employeeInfo.SaveInfo();
                MessageBoxControl messageBox = (MessageBoxControl) Page.Master.FindControl("messageBox");
                messageBox.ShowSuccess("Zmiany wprowadzono");
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
