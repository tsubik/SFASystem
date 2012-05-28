using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils.Security;
using SFASystem.Domain;
using SFASystem.WebUtils;

public partial class Administration_Products_ProductAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditProducts(Context.User))
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
                Product product = ctrlProductInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Dodano nowy produkt");
                Response.Redirect(string.Format("~/Administration/Products/ProductDetails.aspx?ProductID={0}", product.Productid));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
