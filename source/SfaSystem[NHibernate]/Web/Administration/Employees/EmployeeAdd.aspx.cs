using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.WebUtils;
using SFASystem.WebUtils.Security;

public partial class Administration_Employees_EmployeeAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditEmployees(Context.User))
            {
                Response.Redirect("~/Administration/Default.aspx");
            }
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Employee employee = ctrlEmployeeInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Dodano nowego pracownika");
                Response.Redirect(string.Format("~/Administration/Employees/EmployeeDetails.aspx?EmployeeID={0}", employee.EmployeeID));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
