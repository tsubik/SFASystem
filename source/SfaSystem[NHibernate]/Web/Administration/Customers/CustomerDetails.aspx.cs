using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Customers_CustomerDetails : System.Web.UI.Page
{
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
            try
            {
                Customer customer = ctrlCustomerInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Zmiany wprowadzono");
                Response.Redirect(string.Format("~/Administration/Customers/CustomerDetails.aspx?CustomerID={0}", customer.Customerid));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
            if (!(Context.User.IsInRole("Administrator") || Context.User.IsInRole("SalesDirector")))
            {
                ctrlCustomerInfo.Mode = ControlMode.ShowMode;
                SaveButton.Visible = false;
            }
        }
    }

    private void BindData()
    {
        Customer customer  = BasicService<Customer, Guid>.GetByID(this.CustomerID);
        IList<Contact> contacts = CustomerService.GetContacts(customer);
        ctrlContactList.BindList(contacts);
        ctrlFacilityList.BindList(this.CustomerID, string.Empty, Guid.Empty);
        ctrlSelectFacility.BindData(customer);
        OrderList.BindList(customer, null, null, null, null, null);
    }

    protected void btnAddContact_Click(object sender, EventArgs e)
    {

    }
    protected void btnContactSave_Click(object sender, EventArgs e)
    {
        Customer customer = BasicService<Customer, Guid>.GetByID(this.CustomerID);
        if (customer != null)
        {
            bool addingMainContact = false;
            if (chxContactIsMain.Checked)
            {
                if (customer.Contact != null)
                {
                    
                    //StateItems.Message = new Message(MessageType.Error, "Klient posiada już zdefiniowany główny kontakt");
                    //Response.Redirect(Request.Url.AbsoluteUri);
                    Master.ShowMessage(new Message(MessageType.Error, "Klient posiada już zdefiniowany główny kontakt"));
                }
                else
                {
                    addingMainContact = true;
                }
            }
            if (ctrlSelectFacility.SelectedFacilityId == Guid.Empty)
            {
                StateItems.Message = new Message(MessageType.Error, "Wybierz placówkę klienta");
                Response.Redirect("#");
            }
            Contact contact = ctrlContactInfo.SaveInfo();
            CustomerFacility customerFacility = BasicService<CustomerFacility, Guid>.GetByID(ctrlSelectFacility.SelectedFacilityId);
            customerFacility.Contact.Add(contact);
            
            if (contact != null)
            {
                if (addingMainContact)
                {
                    customer.Contact = contact;
                    BasicService<Customer, Guid>.SaveOrUpdate(customer);
                }
            }
            BasicService<CustomerFacility, Guid>.SaveOrUpdate(customerFacility);
            BindData();
        }
    }
    protected void btnAddFacility_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Customers/CustomerFacilityAdd.aspx?CustomerID=" + this.CustomerID);
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            BasicService<Customer, Guid>.Delete(this.CustomerID);
            //CategoryManager.MarkCategoryAsDeleted(this.CategoryID);
            StateItems.Message = new Message(MessageType.Success, "Usunięto klienta");
            Response.Redirect("~/Administration/Customers/Customers.aspx");
        }
        catch (Exception exc)
        {
            throw;
            //ProcessException(exc);
        }
    }

    public Guid CustomerID
    {
        get
        {
            return CommonHelper.QueryStringGUID("CustomerID");
        }
    }
}
