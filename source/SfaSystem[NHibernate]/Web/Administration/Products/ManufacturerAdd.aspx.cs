using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;
using SFASystem.WebUtils.Security;


public partial class Administration_Products_ManufacturerAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditManufacturers(Context.User))
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
                Manufacturer manufacturer = ctrlManufacturerInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Dodano nowego producenta");
                Response.Redirect(string.Format("~/Administration/Products/ManufacturerDetails.aspx?ManufacturerID={0}", manufacturer.ManufacturerID));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
