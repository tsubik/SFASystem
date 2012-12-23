using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Employee_SelectRoleStatus : System.Web.UI.UserControl
{
    private Guid selectedRoleID;

    public void BindData()
    {
        ddlRoles.Items.Clear();
        if (this.EmptyItemText != "[ --- ]")
            ddlRoles.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindList();
        ddlRoles.SelectedValue = selectedRoleID.ToString();
    }

    public void BindList()
    {
        IList<Role> roles = BasicService<Role, Guid>.GetAll();
        if (roles != null)
        {
            foreach (Role role in roles)
            {
                ListItem item = new ListItem(role.Name, role.RoleID.ToString());
                this.ddlRoles.Items.Add(item);
            }

            this.ddlRoles.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public bool Enabled
    {
        get
        {
            return ddlRoles.Enabled;
        }
        set
        {
            ddlRoles.Enabled = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ddlRoles.CssClass;
        }
        set
        {
            ddlRoles.CssClass = value;
        }
    }

    public Guid SelectedRoleID
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlRoles.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedRoleID = value;
            ddlRoles.SelectedValue = selectedRoleID.ToString();
        }
    }
    public Unit Width
    {
        get
        {
            return ddlRoles.Width;
        }
        set
        {
            ddlRoles.Width = value;
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
