using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Services;
using SFASystem.Domain;
using SFASystem.WebUtils.Security;

public partial class Administration_EmployeeDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
            if (!SecurityHelper.CanAddEditEmployees(Context.User))
            {
                chxEmployeeIsActive.Enabled = false;
                AddressDisplay.ShowEditButton = false;
                ContactDisplay.ShowEditButton = false;
                ctrlSelectEmployee.Enabled = false;
            }

            
        }
    }

    private void BindData()
    {
        Employee employee = EmployeeService.GetEmployeeById(this.EmployeeID);
        if (employee != null)
        {
            AddressDisplay.BindData(employee.Address);
            ContactDisplay.BindData(employee.Contact);
            lblEmployeeID.Text = employee.EmployeeID.ToString();
            lblEmployeeCreationDate.Text = employee.CreationDate.ToString();
            if (employee.Contact != null)
                lblEmployeeFullName.Text = employee.Contact.FirstName + " " + employee.Contact.LastName;
            else
                lblEmployeeFullName.Text = "not filled";
            lblEmployeeLastActivityDate.Text = employee.LastActivityDate.ToString();
            lblEmployeeLastLoginDate.Text = employee.LastLoginDate.ToString();
            lblEmployeeLogin.Text = employee.Login;
            employeeRoles.EmployeeID = EmployeeID;

            if (employee.Manager != null)
            {
                ctrlSelectEmployee.SelectedEmployeeID = employee.Manager.EmployeeID;
            }
            ctrlSelectEmployee.BindData(EmployeeService.GetManagerEmployees());
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            BasicService<Employee, Guid>.Delete(this.EmployeeID);
            //CategoryManager.MarkCategoryAsDeleted(this.CategoryID);
            StateItems.Message = new Message(MessageType.Success, "Usunięto pracownika");
            Response.Redirect("~/Administration/Employees/Employees.aspx");
        }
        catch (Exception exc)
        {
            throw;
            //ProcessException(exc);
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Employee employee = BasicService<Employee, Guid>.GetByID(this.EmployeeID);
                employee.Manager = BasicService<Employee, Guid>.GetByID(ctrlSelectEmployee.SelectedEmployeeID);

                BasicService<Employee, Guid>.SaveOrUpdate(employee);
                MessageBoxControl msgBox = (MessageBoxControl)Page.Master.FindControl("messageBox");
                msgBox.ShowSuccess("Zmiany wprowadzono");
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }

    public Guid EmployeeID
    {
        get
        {
            return CommonHelper.QueryStringGUID("EmployeeID");
        }
    }
}
