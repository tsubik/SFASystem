using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;


namespace SFASystem.Web.Administration.Controls
{

    public partial class AddressDisplayControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool ShowEditButton
        {
            set
            {
                btnEdit.Visible = value;
            }
        }

        public ControlMode Mode
        {
            get
            {
                object obj = ViewState["ControlMode"];
                if (obj == null)
                    return ControlMode.ShowMode;
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
                pnlEdit.Visible = true;
                pnlShow.Visible = false;
            }
            else
            {
                pnlEdit.Visible = false;
                pnlShow.Visible = true;
            }
            BindData(BasicService<Address, Guid>.GetByID(this.AddressID));
        }

        public Guid AddressID
        {
            get
            {
                Object obj = ViewState["AddressID"];
                Guid result;
                if (obj == null)
                    return Guid.Empty;
                result = (Guid)obj;
                return result;
            }
            set
            {
                ViewState["AddressID"] = value;
            }
        }

        public void BindData(Address address)
        {
            this.AddressID = address.Addressid;
            txtStreet.Text = address.Street;
            txtHouseNr.Text = address.HouseNr;
            txtApartmentNr.Text = address.ApartmentNr;
            txtCity.Text = address.City.Name;
            txtZipCode.Text = address.ZipCode;
            ctrlSelectCountry.SelectedCountryId = address.Country.Countryid;
            ctrlSelectCountry.BindData();

            lblCity.Text = address.City.Name;
            lblCountry.Text = address.Country.Name;
            lblStreet.Text = address.Street;
            lblHouseApartment.Text = address.HouseNr + "/" + address.ApartmentNr;
            lblZipCode.Text = address.ZipCode;
        }

        public Address Address
        {
            get
            {
                return BasicService<Address, Guid>.GetByID(this.AddressID);
            }
        }
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Address address = this.Address;
                address.Street = txtStreet.Text;
                address.Country = BasicService<Country, Guid>.GetByID(ctrlSelectCountry.SelectedCountryId);
                address.HouseNr = txtHouseNr.Text;
                address.City = CityService.GetCityOrCreateNew(txtCity.Text);
                address.ApartmentNr = txtApartmentNr.Text;
                address.ZipCode = txtZipCode.Text;

                BasicService<Address, Guid>.SaveOrUpdate(address);
                MessageBoxControl msgBox = (MessageBoxControl)Page.Master.FindControl("messageBox");
                msgBox.ShowSuccess("Zmiany adresu wprowadzono.");
                this.Mode = ControlMode.ShowMode;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.Mode = ControlMode.ShowMode;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.Mode = ControlMode.EditMode;
        }
    }
}
