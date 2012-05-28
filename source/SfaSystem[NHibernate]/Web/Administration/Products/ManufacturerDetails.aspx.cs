using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.WebUtils;
using SFASystem.WebUtils.Security;

public partial class Administration_Products_ManufacturerDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditManufacturers(Context.User))
            {
                ctrlManufacturerInfo.Mode = ControlMode.ShowMode;
                SaveButton.Visible = false;
                litTitle.Text = "Szczegóły producenta";
            }
            else
                litTitle.Text = "Edycja producenta";
        }
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Manufacturer manufacturer = ctrlManufacturerInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Zapisano zmiany");
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
