using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Employee_SelectTaskStatus : System.Web.UI.UserControl
{
    private Guid selectedTaskStatusID;

    public void BindData()
    {
        ddlTaskStatus.Items.Clear();
        if(this.EmptyItemText!="[ --- ]")
            ddlTaskStatus.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindList();
        ddlTaskStatus.SelectedValue = selectedTaskStatusID.ToString();
    }

    public void BindList()
    {
        IList<Dictionary> statuses = BasicService<Dictionary, Guid>.GetAll()
            .Where( dict => dict.DictionaryType.Name=="Status zadania").ToList();
        if (statuses != null)
        {
            foreach (Dictionary status in statuses)
            {
                ListItem item = new ListItem(status.Value, status.Dictionaryid.ToString());
                this.ddlTaskStatus.Items.Add(item);
            }

            this.ddlTaskStatus.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public bool Enabled
    {
        get
        {
            return ddlTaskStatus.Enabled;
        }
        set
        {
            ddlTaskStatus.Enabled = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ddlTaskStatus.CssClass;
        }
        set
        {
            ddlTaskStatus.CssClass = value;
        }
    }

    public Guid SelectedStatusID
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlTaskStatus.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedTaskStatusID = value;
            ddlTaskStatus.SelectedValue = selectedTaskStatusID.ToString();
        }
    }
    public Unit Width
    {
        get
        {
            return ddlTaskStatus.Width;
        }
        set
        {
            ddlTaskStatus.Width = value;
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
