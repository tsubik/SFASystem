using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.WebUtils;
using SFASystem.WebUtils.Security;

public partial class Administration_Products_ProductDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditProductGroups(Context.User))
            {
                ctrlProductInfo.Mode = ControlMode.ShowMode;
                ctrlProductPictures.Mode = ControlMode.ShowMode;
                SaveButton.Visible = false;
                //DeleteButton.Visible = false;
                litTitle.Text = "Szczegóły produktu";
            }
            else
                litTitle.Text = "Edycja produktu";
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Product product = ctrlProductInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Zmiany wprowadzono");
                Response.Redirect(string.Format("ProductDetails.aspx?ProductID={0}", product.ProductID));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
