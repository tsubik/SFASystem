using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;

public partial class Administration_Employees_EmployeeTaskAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Task task = ctrlTaskInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Dodano nowe zadanie");
                Response.Redirect(string.Format("~/Administration/Employees/TaskDetails.aspx?TaskID={0}", task.Taskid));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
