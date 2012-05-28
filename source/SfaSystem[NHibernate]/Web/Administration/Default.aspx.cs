using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.IsInRole("SalesRep"))
            Response.Redirect("~/Administration/SalesRepresentative/Dashboard.aspx");
        else if (User.IsInRole("SalesManager"))
            Response.Redirect("~/Administration/SalesManager/Dashboard.aspx");
        else if (User.IsInRole("SalesDirector"))
            Response.Redirect("~/Administration/SalesDirector/Dashboard.aspx");
    }
}
