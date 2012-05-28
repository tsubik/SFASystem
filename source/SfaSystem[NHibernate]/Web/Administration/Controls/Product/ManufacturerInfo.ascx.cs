using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Services;
using SFASystem.Domain;
using SFASystem.WebUtils;

public partial class Administration_Controls_Product_ManufacturerInfo : System.Web.UI.UserControl
{
    private void BindData()
    {
        Manufacturer manufacturer = BasicService<Manufacturer, Guid>.GetByID(this.ManufacturerID);

        if (manufacturer != null)
        {
            if (manufacturer.Address != null)
            {
                txtUlica.Text = manufacturer.Address.Street;
                txtNrDomu.Text = manufacturer.Address.HouseNr;
                txtNrMieszkania.Text = manufacturer.Address.ApartmentNr;
                txtKodPocztowy.Text = manufacturer.Address.ZipCode;
                txtMiasto.Text = manufacturer.Address.City.Name;
                ctrlSelectCountry.SelectedCountryId = manufacturer.Address.Country.Countryid;
            }
            txtName.Text = manufacturer.Name;
            txtDescription.Text = manufacturer.Description;
            txtEmail.Text = manufacturer.Email;
            txtPhone.Text = manufacturer.Phone;
        }
        else
        {
           
        }
        ctrlSelectCountry.BindData();  
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
            SetControlMode();
        }
    }

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

    public void SetControlMode()
    {
        if (this.Mode == ControlMode.EditMode)
        {
            txtDescription.Enabled = true;
            txtEmail.Enabled = true;
            txtKodPocztowy.Enabled = true;
            txtMiasto.Enabled = true;
            txtName.Enabled = true;
            txtNrDomu.Enabled = true;
            txtNrMieszkania.Enabled = true;
            txtPhone.Enabled = true;
            txtUlica.Enabled = true;
            ctrlSelectCountry.Enabled = true;
        }
        else
        {
            txtDescription.Enabled = false;
            txtEmail.Enabled = false;
            txtKodPocztowy.Enabled = false;
            txtMiasto.Enabled = false;
            txtName.Enabled = false;
            txtNrDomu.Enabled = false;
            txtNrMieszkania.Enabled = false;
            txtPhone.Enabled = false;
            txtUlica.Enabled = false;
            ctrlSelectCountry.Enabled = false;
        }

    }

    public Manufacturer SaveInfo()
    {
        if (!Page.IsValid)
            return null;
        if (ctrlSelectCountry.SelectedCountryId == Guid.Empty)
            return null;

        Manufacturer manufacturer = BasicService<Manufacturer, Guid>.GetByID(this.ManufacturerID);

        if (manufacturer == null)
        {
            manufacturer = new Manufacturer();
        }

        Address address = null;
        if (manufacturer.Address == null)
            address = new Address();
        else
            address = manufacturer.Address;
        address.Street = txtUlica.Text;
        address.HouseNr = txtNrDomu.Text;
        address.ApartmentNr = txtNrMieszkania.Text;
        address.ZipCode = txtKodPocztowy.Text;
        address.City = CityService.GetCityOrCreateNew(txtMiasto.Text);
        address.Country = BasicService<Country, Guid>.GetByID(ctrlSelectCountry.SelectedCountryId);

        manufacturer.Name = txtName.Text;
        manufacturer.Description = txtDescription.Text;
        manufacturer.Email = txtEmail.Text;
        manufacturer.Phone = txtPhone.Text;
        manufacturer.Address = address;

        BasicService<Manufacturer, Guid>.SaveOrUpdate(manufacturer);
        return manufacturer;
    }

    public Guid ManufacturerID
    {
        get
        {
            return CommonHelper.QueryStringGUID("ManufacturerID");
        }
    }
}
