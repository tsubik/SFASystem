using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;
using SFASystem.WebUtils.Security;

public partial class Administration_Sales_TerritoryDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditProductGroups(Context.User))
            {
                ctrlTerritoryInfo.Mode = ControlMode.ShowMode;
                SaveButton.Visible = false;
                DeleteButton.Visible = false;
                litTitle.Text = "Szczegóły regionu sprzedaży";
            }
            else
                litTitle.Text = "Edycja regionu sprzedaży";
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Territory territory = ctrlTerritoryInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Zmiany wprowadzono");
                Response.Redirect(string.Format("TerritoryDetails.aspx?TerritoryID={0}", territory.TerritoryID));
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
            BasicService<Territory, Guid>.Delete(this.TerritoryID);
            //CategoryManager.MarkCategoryAsDeleted(this.CategoryID);
            Response.Redirect("~/Administration/Sales/Territories.aspx");
        }
        catch (Exception exc)
        {
            throw;
            //ProcessException(exc);
        }
    }

    public Guid TerritoryID
    {
        get
        {
            return CommonHelper.QueryStringGUID("TerritoryID");
        }
    }
}
