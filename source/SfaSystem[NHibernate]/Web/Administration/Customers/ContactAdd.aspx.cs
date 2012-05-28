using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;

public partial class Administration_Customers_ContactAdd : System.Web.UI.Page
{
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Contact contact = ctrlContactInfo.SaveInfo();
                Response.Redirect(string.Format("ContactDetails.aspx?ContactID={0}", contact.Contactid));
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
}
