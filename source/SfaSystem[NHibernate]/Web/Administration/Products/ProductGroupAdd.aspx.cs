using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils.Security;
using SFASystem.Domain;
using SFASystem.WebUtils;

public partial class Administration_Products_ProductGroupAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditProductGroups(Context.User))
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
                ProductGroup productGroup = ctrlProductGroupInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Zmiany wprowadzono");
                Response.Redirect(string.Format("ProductGroupDetails.aspx?ProductGroupID={0}", productGroup.ProductGroupid));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
