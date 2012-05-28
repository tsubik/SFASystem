using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils.Security;
using SFASystem.Domain;
using SFASystem.WebUtils;

public partial class Administration_Customers_CustomerAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditCustomers(Context.User))
            {
                Response.Redirect("~/Administration/Default.aspx");
            }
        }
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Customer customer = ctrlCustomerInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Zmiany zostały wprowadzone");
                Response.Redirect(string.Format("~/Administration/Customers/CustomerDetails.aspx?CustomerID={0}", customer.Customerid));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
