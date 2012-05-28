using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;


public partial class Administration_Controls_Account_EmployeeAdditional : System.Web.UI.UserControl
{
    public Employee Employee;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            BindData();
    }

    private void BindData()
    {
        if (Employee != null)
        {
            lblCreationDate.Text = Employee.CreationDate.HasValue? Employee.CreationDate.Value.ToString("dddd, dd MMMM yyyy HH:mm:ss"):string.Empty;
            lblLastActivityDate.Text = Employee.LastActivityDate.HasValue? Employee.LastActivityDate.Value.ToString("dddd, dd MMMM yyyy HH:mm:ss"):string.Empty;
            lblLastLoginDate.Text = Employee.LastLoginDate.HasValue? Employee.LastLoginDate.Value.ToString("dddd, dd MMMM yyyy HH:mm:ss"):string.Empty;
        }
    }
}
