using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Services;
using SFASystem.Domain;

public partial class Administration_Controls_Sale_SelectOrderStatus : System.Web.UI.UserControl
{
    private Guid selectedOrderStatusID;

    public void BindData()
    {
        ddlOrderStatus.Items.Clear();
        if (this.EmptyItemText != "[ --- ]")
            ddlOrderStatus.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindList();
        ddlOrderStatus.SelectedValue = selectedOrderStatusID.ToString();
    }

    public void BindList()
    {
        IList<Dictionary> statuses = BasicService<Dictionary, Guid>.GetAll()
            .Where(dict => dict.DictionaryType.Name == "Status zamówienia").ToList();
        if (statuses != null)
        {
            foreach (Dictionary status in statuses)
            {
                ListItem item = new ListItem(status.Value, status.Dictionaryid.ToString());
                this.ddlOrderStatus.Items.Add(item);
            }

            this.ddlOrderStatus.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public bool Enabled
    {
        get
        {
            return ddlOrderStatus.Enabled;
        }
        set
        {
            ddlOrderStatus.Enabled = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ddlOrderStatus.CssClass;
        }
        set
        {
            ddlOrderStatus.CssClass = value;
        }
    }

    public Guid SelectedStatusID
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlOrderStatus.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedOrderStatusID = value;
            ddlOrderStatus.SelectedValue = selectedOrderStatusID.ToString();
        }
    }
    public Unit Width
    {
        get
        {
            return ddlOrderStatus.Width;
        }
        set
        {
            ddlOrderStatus.Width = value;
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
