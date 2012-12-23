using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;

public partial class Administration_Customers_CustomerFacilityAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                CustomerFacility customerFac = ctrlFacilityInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Zmiany wprowadzono");
                Response.Redirect(string.Format("~/Administration/Customers/CustomerFacilityDetails.aspx?CustomerFacilityID={0}", customerFac.CustomerFacilityID));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
