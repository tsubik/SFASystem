using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;
using SFASystem.Services;
using System.Web.Security;



namespace SFASystem.Web.Administration.Controls
{
    public partial class EmployeeInfoControl : System.Web.UI.UserControl
    {
        public Guid EmployeeID
        {
            get
            {
                Object obj = ViewState["EmployeeID"];
                Guid result;
                if (obj == null)
                    return Guid.Empty;
                result = (Guid)obj;
                return result;
            }
            set
            {
                ViewState["EmployeeID"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            Employee employee = EmployeeService.GetEmployeeById(this.EmployeeID);
            if (employee != null)
            {
                if (employee.Manager != null)
                    ctrlSelectEmployee.SelectedEmployeeID = employee.Manager.EmployeeID;
                ctrlSelectEmployee.BindData(EmployeeService.GetManagerEmployees());
                lblLogin.Text = employee.Login;
                if (employee.Contact != null)
                {
                    this.txtFirstName.Text = employee.Contact.FirstName;
                    this.txtLastName.Text = employee.Contact.LastName;
                    this.txtPhoneNumber.Text = employee.Contact.Phone;
                    this.txtEmail.Text = employee.Contact.Email;
                }
                else
                {
                    this.txtEmail.Text = string.Empty;
                    this.txtFirstName.Text = string.Empty;
                    this.txtLastName.Text = string.Empty;
                    this.txtPhoneNumber.Text = string.Empty;
                }
                if (employee.Address != null)
                {
                    this.txtStreetAddress.Text = employee.Address.Street;
                    this.txtZipPostalCode.Text = employee.Address.ZipCode;
                    this.txtCity.Text = employee.Address.City.Name;
                    this.txtHouse.Text = employee.Address.HouseNr;
                    this.txtApartment.Text = employee.Address.ApartmentNr;
                    ctrlSelectCountry.SelectedCountryId = employee.Address.Country.CountryID;
                }
                else
                {
                    this.txtStreetAddress.Text = string.Empty;
                    this.txtZipPostalCode.Text = string.Empty;
                    this.txtCity.Text = string.Empty;
                    this.txtHouse.Text = string.Empty;
                    this.txtApartment.Text = string.Empty;
                }
            }
            else
            {
                this.panelNewEmployee.Visible = true;
            }
            ctrlSelectCountry.BindData();
        }

        public Employee SaveInfo()
        {

            Employee employee = EmployeeService.GetEmployeeById(this.EmployeeID);
            if (employee == null)
            {
                Membership.CreateUser(txtLogin.Text, txtPassword.Text);
                employee = EmployeeService.GetEmployeeByLogin(txtLogin.Text);
            }
            Contact contact = null;
            Address address = null;
            if (employee.Contact == null)
                contact = new Contact();
            else
                contact = employee.Contact;
            if (employee.Address == null)
                address = new Address();
            else
                address = employee.Address;
            contact.Email = txtEmail.Text;
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            contact.Phone = txtPhoneNumber.Text;

            address.Street = txtStreetAddress.Text;
            address.HouseNr = txtHouse.Text;
            address.ApartmentNr = txtApartment.Text;
            address.ZipCode = txtZipPostalCode.Text;

            address.City = CityService.GetCityOrCreateNew(txtCity.Text);
            address.Country = BasicService<Country, Guid>.GetByID(ctrlSelectCountry.SelectedCountryId);

            if (employee.CreationDate == DateTime.MinValue)
                employee.CreationDate = DateTime.Now;
            if (employee.LastActivityDate == DateTime.MinValue)
                employee.LastActivityDate = DateTime.Now;
            if (employee.LastLoginDate == DateTime.MinValue)
                employee.LastLoginDate = DateTime.Now;
            employee.Address = address;
            employee.Contact = contact;
            EmployeeService.SaveEmployee(employee);
            return employee;

        }
        
    }
}