using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Reports_ReportsHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Context.User.IsInRole("SalesDirector")&&Context.User.IsInRole("SalesManager"))
        {
            lnkBC.Visible = false;
            lnkBPT.Visible = false;
            lnkBSR.Visible = false;
            lnkSPG.Visible = false;
            lnkST.Visible = false;
        }
    }
}
