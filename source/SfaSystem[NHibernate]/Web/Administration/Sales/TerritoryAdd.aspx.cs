using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils.Security;
using SFASystem.Domain;
using SFASystem.WebUtils;

public partial class Administration_Sales_TerritoryAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.CanAddEditTerritories(Context.User))
            Response.Redirect("~/Administration/Default.aspx");
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Territory territory = ctrlTerritoryInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Dodano nowy region sprzedaży");
                Response.Redirect(string.Format("~/Administration/Sales/TerritoryDetails.aspx?TerritoryID={0}", territory.Territoryid));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
        }
    }
}
