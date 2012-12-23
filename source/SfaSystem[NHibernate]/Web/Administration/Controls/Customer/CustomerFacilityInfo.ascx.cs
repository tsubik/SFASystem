using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Controls_Customer_CustomerFacilityInfo : System.Web.UI.UserControl
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
            txtEmail.Enabled = true;
            txtKodPocztowy.Enabled = true;
            txtMiasto.Enabled = true;
            txtNazwa.Enabled = true;
            txtNrDomu.Enabled = true;
            txtNrMieszkania.Enabled = true;
            txtPhone.Enabled = true;
            txtUlica.Enabled = true;
            ctrlSelectCountry.Enabled = true;
            ctrlSelectCustomer.Enabled = true;
            ctrlSelectTerritory.Enabled = true;

        }
        else
        {
            txtEmail.Enabled = false;
            txtKodPocztowy.Enabled = false;
            txtMiasto.Enabled = false;
            txtNazwa.Enabled = false;
            txtNrDomu.Enabled = false;
            txtNrMieszkania.Enabled = false;
            txtPhone.Enabled = false;
            txtUlica.Enabled = false;
            ctrlSelectCountry.Enabled = false;
            ctrlSelectCustomer.Enabled = false;
            ctrlSelectTerritory.Enabled = false;
        }
    }

    private void BindData()
    {
        CustomerFacility customerFacility = BasicService<CustomerFacility, Guid>.GetByID(this.CustomerFacilityID);

        if (customerFacility != null)
        {
            if (customerFacility.Address != null)
            {
                txtUlica.Text = customerFacility.Address.Street;
                txtNrDomu.Text = customerFacility.Address.HouseNr;
                txtNrMieszkania.Text = customerFacility.Address.ApartmentNr;
                txtKodPocztowy.Text = customerFacility.Address.ZipCode;
                txtMiasto.Text = customerFacility.Address.City.Name;
                ctrlSelectCountry.SelectedCountryId = customerFacility.Address.Country.CountryID;
            }
            txtNazwa.Text = customerFacility.Name;
            txtPhone.Text = customerFacility.Phone;
            txtEmail.Text = customerFacility.Email;
            ctrlSelectTerritory.SelectedTerritoryId = customerFacility.Territory.TerritoryID;
            ctrlSelectCustomer.SelectedCustomerId = customerFacility.Customer.CustomerID;
            btnCustomerDetails.Visible = true;
        }
        else
        {
            btnCustomerDetails.Visible = false;
            if (this.CustomerID != Guid.Empty)
            {
                ctrlSelectCustomer.SelectedCustomerId = this.CustomerID;
            }
            //ParentCategory.SelectedProductGroupId = this.ParentProductGroupID;
            //ParentCategory.BindData();
        }
        ctrlSelectCountry.BindData();
        ctrlSelectTerritory.BindData();
        ctrlSelectCustomer.BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    public CustomerFacility SaveInfo()
    {
        if (!Page.IsValid)
            return null;
        if (ctrlSelectCountry.SelectedCountryId == Guid.Empty)
            return null;
        if (ctrlSelectTerritory.SelectedTerritoryId == Guid.Empty)
            return null;
        if (ctrlSelectCustomer.SelectedCustomerId == Guid.Empty)
            return null;

        CustomerFacility customerFacility = BasicService<CustomerFacility, Guid>.GetByID(this.CustomerFacilityID);

        if (customerFacility == null)
        {
            customerFacility = new CustomerFacility();
        }
       
        Address address = null;
        if (customerFacility.Address == null)
            address = new Address();
        else
            address = customerFacility.Address;
        address.Street = txtUlica.Text;
        address.HouseNr = txtNrDomu.Text;
        address.ApartmentNr = txtNrMieszkania.Text;
        address.ZipCode = txtKodPocztowy.Text;
        address.City = CityService.GetCityOrCreateNew(txtMiasto.Text);
        address.Country = BasicService<Country, Guid>.GetByID(ctrlSelectCountry.SelectedCountryId);

        customerFacility.Name = txtNazwa.Text;
        customerFacility.Address = address;
        customerFacility.Email = txtEmail.Text;
        customerFacility.Phone = txtPhone.Text;
        customerFacility.Customer = BasicService<Customer, Guid>.GetByID(ctrlSelectCustomer.SelectedCustomerId);
        customerFacility.Territory = BasicService<Territory, Guid>.GetByID(ctrlSelectTerritory.SelectedTerritoryId);

        BasicService<CustomerFacility, Guid>.SaveOrUpdate(customerFacility);
        return customerFacility;
    }

    public Guid CustomerFacilityID
    {
        get
        {
            return CommonHelper.QueryStringGUID("CustomerFacilityID");
        }
    }

    public Guid CustomerID
    {
        get
        {
            return CommonHelper.QueryStringGUID("CustomerID");
        }
    }
    protected void btnCustomerDetails_Click(object sender, EventArgs e)
    {
        if (ctrlSelectCustomer.SelectedCustomerId != Guid.Empty)
        {
            Response.Redirect("~/Administration/Customers/CustomerDetails.aspx?CustomerID=" + ctrlSelectCustomer.SelectedCustomerId);
        }
    }
}
