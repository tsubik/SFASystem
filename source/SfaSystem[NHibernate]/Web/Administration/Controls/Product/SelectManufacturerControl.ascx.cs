using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Product_SelectManufacturerControl : System.Web.UI.UserControl
{
    private Guid selectedTaxID;

    public void BindData()
    {
        ddlManufacturers.Items.Clear();
        if (this.EmptyItemText != "[ --- ]")
            ddlManufacturers.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindList();
        ddlManufacturers.SelectedValue = selectedTaxID.ToString();
    }

    public void BindList()
    {
        IList<Manufacturer> mans = BasicService<Manufacturer, Guid>.GetAll();
            
        if (mans != null)
        {
            foreach (Manufacturer man in mans)
            {
                ListItem item = new ListItem(man.Name, man.ManufacturerID.ToString());
                this.ddlManufacturers.Items.Add(item);
            }

            this.ddlManufacturers.DataBind();
        }
    }


    public bool Enabled
    {
        get
        {
            return ddlManufacturers.Enabled;
        }
        set
        {
            ddlManufacturers.Enabled = value;
        }
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
            ddlManufacturers.ValidationGroup = value;
            rfvValue.ValidationGroup = value;
        }
    }


    public string CssClass
    {
        get
        {
            return ddlManufacturers.CssClass;
        }
        set
        {
            ddlManufacturers.CssClass = value;
        }
    }

    public Guid SelectedManufacturerID
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlManufacturers.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedTaxID = value;
            ddlManufacturers.SelectedValue = selectedTaxID.ToString();
        }
    }
    public Unit Width
    {
        get
        {
            return ddlManufacturers.Width;
        }
        set
        {
            ddlManufacturers.Width = value;
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
