using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Controls_Customer_CustomerInfo : System.Web.UI.UserControl
{
    public ControlMode Mode
    {
        get
        {
            object obj = ViewState["ControlMode"];
            if (obj == null)
                return ControlMode.EditMode;
            return (ControlMode)obj;
        }
        set
        {
            ViewState["ControlMode"] = value;
            SetControlMode();
        }
    }

    private void SetControlMode()
    {
        if (this.Mode == ControlMode.EditMode)
        {
            txtCode.Enabled = true;
            txtCustomerSince.Enabled = true;
            txtCustomerTo.Enabled = true;
            txtDescription.Enabled = true;
            txtEmail.Enabled = true;
            txtKRS.Enabled = true;
            txtName.Enabled = true;
            txtNIP.Enabled = true;
            txtPhone.Enabled = true;
            txtREGON.Enabled = true;
            
        }
        else
        {
            txtCode.Enabled = false;
            txtCustomerSince.Enabled = false;
            txtCustomerTo.Enabled = false;
            txtDescription.Enabled = false;
            txtEmail.Enabled = false;
            txtKRS.Enabled = false;
            txtName.Enabled = false;
            txtNIP.Enabled = false;
            txtPhone.Enabled = false;
            txtREGON.Enabled = false;
        }
    }

    private void BindData()
    {
        Customer customer = BasicService<Customer, Guid>.GetByID(this.CustomerID);

        if (customer != null)
        {
            this.txtCode.Text = customer.Code;
            this.txtName.Text = customer.Name;
            this.txtDescription.Text = customer.FullDescription;
            this.txtKRS.Text = customer.KRS;
            this.txtNIP.Text = customer.NIP.ToString();
            this.txtREGON.Text = customer.REGON.ToString();
            this.txtEmail.Text = customer.Email;
            this.txtPhone.Text = customer.Phone;
            this.calExtCustomerSince.SelectedDate = customer.CustomerSince;
            this.calExtCustomerTo.SelectedDate = customer.CustomerTo;
        }
        else
        {
            //ParentCategory.SelectedProductGroupId = this.ParentProductGroupID;
            //ParentCategory.BindData();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    public Customer SaveInfo()
    {
        Customer customer = BasicService<Customer, Guid>.GetByID(this.CustomerID);

        if (customer == null)
        {
            customer = new Customer();
        }
        try
        {
            customer.NIP = txtNIP.Text;
            customer.REGON = txtREGON.Text;
        }
        catch
        {
            return null;
        }
        customer.KRS = txtKRS.Text;
        customer.Name = txtName.Text;
        customer.Code = txtCode.Text;
        customer.Email = txtEmail.Text;
        customer.Phone = txtPhone.Text;
        customer.CustomerSince = calExtCustomerSince.SelectedDate;
        customer.CustomerTo = calExtCustomerTo.SelectedDate;
        
        customer.FullDescription = txtDescription.Text;
        BasicService<Customer, Guid>.SaveOrUpdate(customer);
        return customer;
    }

    public Guid CustomerID
    {
        get
        {
            return CommonHelper.QueryStringGUID("CustomerID");
        }
    }
}
