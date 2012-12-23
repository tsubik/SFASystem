using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Product_SelectTaxControl : System.Web.UI.UserControl
{
    private Guid selectedTaxID;

    public void BindData()
    {
        ddlTaxes.Items.Clear();
        if (this.EmptyItemText != "[ --- ]")
            ddlTaxes.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindList();
        ddlTaxes.SelectedValue = selectedTaxID.ToString();
    }

    public void BindList()
    {
        IList<Dictionary> taxes = BasicService<Dictionary, Guid>.GetAll()
            .Where(dict => dict.DictionaryType.Name == DictionaryTypeNames.Tax).ToList();
        if (taxes != null)
        {
            foreach (Dictionary tax in taxes)
            {
                ListItem item = new ListItem(tax.Value, tax.DictionaryID.ToString());
                this.ddlTaxes.Items.Add(item);
            }

            this.ddlTaxes.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public bool Enabled
    {
        get
        {
            return ddlTaxes.Enabled;
        }
        set
        {
            ddlTaxes.Enabled = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ddlTaxes.CssClass;
        }
        set
        {
            ddlTaxes.CssClass = value;
        }
    }

    public Guid SelectedStatusID
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlTaxes.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedTaxID = value;
            ddlTaxes.SelectedValue = selectedTaxID.ToString();
        }
    }
    public Unit Width
    {
        get
        {
            return ddlTaxes.Width;
        }
        set
        {
            ddlTaxes.Width = value;
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
