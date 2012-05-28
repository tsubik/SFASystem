using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils.Security;
public partial class Administration_Territories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!SecurityHelper.CanAddEditProductGroups(Context.User))
            {
                ctrlTerritoryTree.Mode = ControlMode.ShowMode;
            }

        }
    }
}
