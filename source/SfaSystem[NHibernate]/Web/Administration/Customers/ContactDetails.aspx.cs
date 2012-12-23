using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Services;
using SFASystem.Domain;
using SFASystem.WebUtils;

public partial class Administration_Customers_ContactDetails : System.Web.UI.Page
{
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Contact contact = ctrlContactInfo.SaveInfo();
                Response.Redirect(string.Format("ContactDetails.aspx?ContactID={0}", contact.ContactID));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            //BasicService<CustomerFacility, Guid>.Delete(this.CustomerFacilityID);
            ////CategoryManager.MarkCategoryAsDeleted(this.CategoryID);
            //Response.Redirect("~/Administration/Customers/CustomerFacilities.aspx");
        }
        catch (Exception exc)
        {
            throw;
            //ProcessException(exc);
        }
    }

    public Guid ContactID
    {
        get
        {
            return CommonHelper.QueryStringGUID("ContactID");
        }
    }
    /// <summary>
    /// Dodanie nowej placówki
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        if (ctrlSelectFacility.SelectedFacilityId != Guid.Empty)
        {
            Contact contact = BasicService<Contact, Guid>.GetByID(this.ContactID);
            CustomerFacility facility = BasicService<CustomerFacility, Guid>.GetByID(ctrlSelectFacility.SelectedFacilityId);
            if (!facility.Contacts.Contains(contact))
            {
                facility.Contacts.Add(contact);
                BasicService<CustomerFacility, Guid>.SaveOrUpdate(facility);
                BindFacilityList();
            }
        }
    }

    private void BindData()
    {
        ctrlSelectCustomer.BindData();
        BindFacilityList();
    }

    private void BindFacilityList()
    {
        Contact contact = BasicService<Contact, Guid>.GetByID(this.ContactID);
        ctrlFacilityList.BindList(contact);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ctrlSelectCustomer.SelectedIndexChanged += new EventHandler(ctrlSelectCustomer_SelectedIndexChanged);
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    void ctrlSelectCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ctrlSelectCustomer.SelectedCustomerId != Guid.Empty)
        {
            Customer customer = BasicService<Customer, Guid>.GetByID(ctrlSelectCustomer.SelectedCustomerId);
            this.ctrlSelectFacility.BindData(customer);
            this.panelPlacowki.Visible = true;
        }
        else
        {
            this.panelPlacowki.Visible = false;
        }
    }
}
