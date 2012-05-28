using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils.Security;
using SFASystem.Domain;
using SFASystem.WebUtils;
using SFASystem.Services;

public partial class Administration_Customers_CustomerFacilityDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
            if (!SecurityHelper.CanAddEditCustomerFacilities(Context.User))
            {
                ctrlFacilityInfo.Mode = ControlMode.ShowMode;
                litTitle.Text = "Szczegóły placówki";
            }
            else
            {
                litTitle.Text = "Edycja placówki";
            }
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                CustomerFacility facility = ctrlFacilityInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Zmiany wprowadzono");
                Response.Redirect(string.Format("CustomerFacilityDetails.aspx?CustomerFacilityID={0}", facility.CustomerFacilityid));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
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

    private void SetControlMode()
    {
        if (this.Mode == ControlMode.EditMode)
        {
            SaveButton.Visible = true;
        }
        else
        {
            SaveButton.Visible = false;
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            BasicService<CustomerFacility, Guid>.Delete(this.CustomerFacilityID);
            //CategoryManager.MarkCategoryAsDeleted(this.CategoryID);
            StateItems.Message = new Message(MessageType.Success, "Usunięto placówkę");
            Response.Redirect("~/Administration/Customers/CustomerFacilities.aspx");
        }
        catch (Exception exc)
        {
            throw;
            //ProcessException(exc);
        }
    }

    private void BindData()
    {
        CustomerFacility facility = BasicService<CustomerFacility, Guid>.GetByID(this.CustomerFacilityID);
        IList<Contact> contacts = CustomerService.GetContacts(facility);
        ctrlContactList.BindList(contacts);
        OrderList.BindList(facility);
    }

    protected void btnContactSave_Click(object sender, EventArgs e)
    {
        Contact contact = ctrlContactInfo.SaveInfo();
        CustomerFacility customerFacility = BasicService<CustomerFacility, Guid>.GetByID(this.CustomerFacilityID);
        customerFacility.Contact.Add(contact);

        BasicService<CustomerFacility, Guid>.SaveOrUpdate(customerFacility);
        BindData();
    }

    public Guid CustomerFacilityID
    {
        get
        {
            return CommonHelper.QueryStringGUID("CustomerFacilityID");
        }
    }
}
