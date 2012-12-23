using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Sale_SelectInvoiceStatus : System.Web.UI.UserControl
{
    private Guid selectedInvoiceStatusID;

    public void BindData()
    {
        ddlInvoiceStatus.Items.Clear();
        if (this.EmptyItemText != "[ --- ]")
            ddlInvoiceStatus.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindList();
        ddlInvoiceStatus.SelectedValue = selectedInvoiceStatusID.ToString();
    }

    public void BindList()
    {
        IList<Dictionary> statuses = BasicService<Dictionary, Guid>.GetAll()
            .Where(dict => dict.DictionaryType.Name == DictionaryTypeNames.Invoice).ToList();
        if (statuses != null)
        {
            foreach (Dictionary status in statuses)
            {
                ListItem item = new ListItem(status.Value, status.DictionaryID.ToString());
                this.ddlInvoiceStatus.Items.Add(item);
            }

            this.ddlInvoiceStatus.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public bool Enabled
    {
        get
        {
            return ddlInvoiceStatus.Enabled;
        }
        set
        {
            ddlInvoiceStatus.Enabled = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ddlInvoiceStatus.CssClass;
        }
        set
        {
            ddlInvoiceStatus.CssClass = value;
        }
    }

    public Guid SelectedStatusID
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlInvoiceStatus.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedInvoiceStatusID = value;
            ddlInvoiceStatus.SelectedValue = selectedInvoiceStatusID.ToString();
        }
    }
    public Unit Width
    {
        get
        {
            return ddlInvoiceStatus.Width;
        }
        set
        {
            ddlInvoiceStatus.Width = value;
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
