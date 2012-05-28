using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using System.Web.Security;



public partial class Administration_Controls_EmployeeRoles : System.Web.UI.UserControl
{
    public Guid EmployeeID
    {
        set
        {
            ViewState["employeeID"] = value;
        }
        get
        {
            object obj = ViewState["employeeID"];
            if (obj != null)
            {
                return (Guid)obj;
            }
            else
                return Guid.Empty;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            BindData();
    }

    private void BindData()
    {
        if(EmployeeID!=Guid.Empty)
        {
            Employee employee = EmployeeService.GetEmployeeById(EmployeeID);
            IList<Role> employeeRoles = employee.Roles;
            IList<Role> roles = BasicService<Role, Guid>.GetAll();
            lstEmployeeRoles.Items.Clear();
            lstRoles.Items.Clear();
            foreach (Role role in employeeRoles)
                lstEmployeeRoles.Items.Add(new ListItem(role.Name, role.Roleid.ToString()));
            foreach (Role role in roles)
                if (!employeeRoles.Contains(role))
                    lstRoles.Items.Add(new ListItem(role.Name, role.Roleid.ToString()));
            
        }
    }

    protected void btnAddRole_Click(object sender, EventArgs e)
    {
        if (lstRoles.SelectedItem != null)
        {
            Guid roleID = new Guid(lstRoles.SelectedValue);
            if (roleID != Guid.Empty && EmployeeID != Guid.Empty)
            {
                EmployeeService.AddEmployeeToRole(EmployeeID, roleID);
                BasicService<Employee, Guid>.CloseSession();
                BindData();
            }
        }
    }
    protected void btnDeleteRole_Click(object sender, EventArgs e)
    {
        if (lstEmployeeRoles.SelectedItem != null)
        {
            Guid roleID = new Guid(lstEmployeeRoles.SelectedValue);
            if (roleID != Guid.Empty && EmployeeID != Guid.Empty)
            {
                EmployeeService.RemoveEmployeeFromRole(EmployeeID, roleID);
                BasicService<Employee, Guid>.CloseSession();
                BindData();
            }
        }
    }
}
