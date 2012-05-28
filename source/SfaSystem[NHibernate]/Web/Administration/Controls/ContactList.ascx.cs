using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using System.Text;

public partial class Administration_Controls_ContactList : System.Web.UI.UserControl
{
    public Guid CustomerID
    {
        get
        {
            Guid result = (Guid)ViewState["FacCustomerID"];
            if (result == null)
                result = Guid.Empty;
            return result;
        }
        set
        {
            ViewState["FacCustomerID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvContacts.PageIndex = e.NewPageIndex;
        //BindList();
    }

    public void BindList()
    {
        gvContacts.DataSource = BasicService<Contact, Guid>.GetAll().ToList<Contact>();
        gvContacts.DataBind();
    }

    public void BindList(IList<Contact> contacts)
    {
        gvContacts.DataSource = SafeList.Create<Contact>(contacts);
       
        gvContacts.DataBind();
    }

    protected void gvContacts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Contact contact = (Contact)e.Row.DataItem;
            Label lblCustomers = (Label)e.Row.FindControl("lblCustomers");
            Label lblCustomerFacilities = (Label)e.Row.FindControl("lblCustomerFacilities");

            IList<CustomerFacility> custFac = CustomerService.GetCustomerFacilitiesForContact(contact);
            IList<Customer> customers = CustomerService.GetCustomersForContactID(contact);

            StringBuilder builderCus = new StringBuilder();
            StringBuilder builderFac = new StringBuilder();

            bool mainContact = false;
            foreach (Customer cust in customers)
            {
                if (cust.Contact == contact)
                    mainContact = true;
                builderCus.Append(cust.Name + "<br />");
            }
            if (customers.Count > 0)
                builderCus.Remove(builderCus.Length - 6, 6);

            foreach (CustomerFacility fac in custFac)
            {
                builderFac.Append(fac.Name + "<br />");
            }
            if (custFac.Count > 0)
                builderFac.Remove(builderFac.Length - 6, 6);

            lblCustomers.Text = builderCus.ToString();
            lblCustomerFacilities.Text = builderFac.ToString();

            if (mainContact)
            {
                e.Row.ControlStyle.CssClass = "mainContact";
                //e.Row.Attributes["class"] = "mainContact";
            }
        }
    }
}
