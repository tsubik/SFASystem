using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Services;
using SFASystem.WebUtils;
using SFASystem.Domain;
using SFASystem.WebUtils.Security;

public partial class Administration_Products_ProductGroupDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditProductGroups(Context.User))
            {
                ctrlProductGroupInfo.Mode = ControlMode.ShowMode;
                SaveButton.Visible = false;
                DeleteButton.Visible = false;
                litTitle.Text = "Szczegóły grupy";
            }
            else
                litTitle.Text = "Edycja grupy";
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

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            BasicService<ProductGroup, Guid>.Delete(this.ProductGroupID);
            //CategoryManager.MarkCategoryAsDeleted(this.CategoryID);
            Response.Redirect("ProductGroups.aspx");
        }
        catch (Exception exc)
        {
            throw;
            //ProcessException(exc);
        }
    }

    public Guid ProductGroupID
    {
        get
        {
            return CommonHelper.QueryStringGUID("ProductGroupID");
        }
    }
}
