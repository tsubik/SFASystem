using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Employee_SelectEmployeeControl : System.Web.UI.UserControl
{
    private Guid selectedEmployeeId;

    public void BindData()
    {
        IList<Employee> employees = BasicService<Employee, Guid>.GetAll();
        BindData(employees);
    }

    public void BindData(IList<Employee> employees)
    {
        ddlEmployees.Items.Clear();
        ddlEmployees.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        if (employees != null)
        {
            foreach (Employee Employee in employees)
            {
                ListItem item = new ListItem(Employee.FriendlyName, Employee.Employeeid.ToString());
                this.ddlEmployees.Items.Add(item);
            }

            this.ddlEmployees.DataBind();
        }
        ddlEmployees.SelectedValue = selectedEmployeeId.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (rfvValue.ErrorMessage != string.Empty)
            rfvValue.InitialValue = Guid.Empty.ToString();
    }

    public string ErrorMessage
    {
        get
        {
            return rfvValue.ErrorMessage;
        }
        set
        {
            rfvValue.ErrorMessage = value;
        }
    }

    public string ValidationGroup
    {
        get
        {
            return rfvValue.ValidationGroup;
        }
        set
        {
            ddlEmployees.ValidationGroup = value;
            rfvValue.ValidationGroup = value;
        }
    }
    public bool Enabled
    {
        get
        {
            return ddlEmployees.Enabled;
        }
        set
        {
            ddlEmployees.Enabled = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ddlEmployees.CssClass;
        }
        set
        {
            ddlEmployees.CssClass = value;
        }
    }

    public Guid SelectedEmployeeID
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlEmployees.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedEmployeeId = value;
            ddlEmployees.SelectedValue = selectedEmployeeId.ToString();
        }
    }

    public Unit Width
    {
        get
        {
            return ddlEmployees.Width;
        }
        set
        {
            ddlEmployees.Width = value;
        }
    }

    public string EmptyItemText
    {
        get
        {
            if (ViewState["EmptyItemText"] == null)
                return "[ --- ]";
            else
                return (string)ViewState["EmptyItemText"];
        }
        set { ViewState["EmptyItemText"] = value; }
    }
}
