using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Services;
using SFASystem.WebUtils;
using SFASystem.Domain;

public partial class Administration_Controls_ContactInfo : System.Web.UI.UserControl
{
    private void BindData()
    {
        Contact contact = BasicService<Contact, Guid>.GetByID(this.ContactID);

        if (contact != null)
        {
            txtFirstName.Text = contact.FirstName;
            txtLastName.Text = contact.LastName;
            txtEmail.Text = contact.Email;
            txtPhone.Text = contact.Phone;
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

    public Contact SaveInfo()
    {
        if (!Page.IsValid)
            return null;
        
        Contact contact = BasicService<Contact, Guid>.GetByID(this.ContactID);

        if (contact == null)
        {
            contact = new Contact();
        }
        contact.FirstName = txtFirstName.Text;
        contact.LastName = txtLastName.Text;
        contact.Phone = txtPhone.Text;
        contact.Email = txtEmail.Text;

        BasicService<Contact, Guid>.SaveOrUpdate(contact);
        return contact;
    }

    public string ValidationGroup
    {
        set
        {
            txtEmail.ValidationGroup = value;
            txtFirstName.ValidationGroup = value;
            txtLastName.ValidationGroup = value;
            txtPhone.ValidationGroup = value;
        }
    }

    public Guid ContactID
    {
        get
        {
            return CommonHelper.QueryStringGUID("ContactID");
        }
    }
}
