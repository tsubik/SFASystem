using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Employees_EmployeeTaskDetails : System.Web.UI.Page
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
                StateItems.Message = new Message(MessageType.Success, "Zmiany wprowadzono");
                Response.Redirect(string.Format("TaskDetails.aspx?TaskID={0}", task.Taskid));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            BasicService<ProductGroup, Guid>.Delete(this.ProductID);
            //CategoryManager.MarkCategoryAsDeleted(this.CategoryID);
            StateItems.Message = new Message(MessageType.Success, "Usunieto zadanie");
            Response.Redirect("~/Administration/Employees/Tasks.aspx");
        }
        catch (Exception exc)
        {
            throw;
            //ProcessException(exc);
        }
    }

    public Guid ProductID
    {
        get
        {
            return CommonHelper.QueryStringGUID("ProductID");
        }
    }
}
