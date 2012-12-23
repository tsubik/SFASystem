using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Customer_SelectCustomerControl : System.Web.UI.UserControl
{
    private Guid selectedCustomerId;
    public event EventHandler SelectedIndexChanged;

    public void BindData()
    {
        ddlCustomers.Items.Clear();
        ddlCustomers.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindData(Guid.Empty);
        ddlCustomers.SelectedValue = selectedCustomerId.ToString();
    }

    public void BindData(Guid ForParentEntityID)
    {
        IList<Customer> customerList = BasicService<Customer, Guid>.GetAll();
        if (customerList != null)
        {
            foreach (Customer customer in customerList)
            {
                ListItem item = new ListItem(customer.Code+" - "+customer.Name, customer.CustomerID.ToString());
                this.ddlCustomers.Items.Add(item);
            }
            this.ddlCustomers.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ddlCustomers.SelectedIndexChanged += new EventHandler(ddlCustomers_SelectedIndexChanged);
        if (rfvValue.ErrorMessage != string.Empty)
            rfvValue.InitialValue = Guid.Empty.ToString();
    }

    void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.SelectedIndexChanged != null)
            this.SelectedIndexChanged(null, null);
    }

    public bool Enabled
    {
        get
        {
            return ddlCustomers.Enabled;
        }
        set
        {
            ddlCustomers.Enabled = value;
            rfvValue.Enabled = value;
        }
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
            ddlCustomers.ValidationGroup = value;
            rfvValue.ValidationGroup = value;
        }
    }
    public string CssClass
    {
        get
        {
            return ddlCustomers.CssClass;
        }
        set
        {
            ddlCustomers.CssClass = value;
        }
    }

    public bool AutoPostBack
    {
        get
        {
            return ddlCustomers.AutoPostBack;
        }
        set
        {
            ddlCustomers.AutoPostBack = value;
        }
    }

    public Guid SelectedCustomerId
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlCustomers.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedCustomerId = value;
            ddlCustomers.SelectedValue = selectedCustomerId.ToString();
        }
    }
    public Unit Width
    {
        get
        {
            return ddlCustomers.Width;
        }
        set
        {
            ddlCustomers.Width = value;
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
