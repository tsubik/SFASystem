using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Reports_ProductReport : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ScriptManager.GetCurrent(this).SupportsPartialRendering = false;
        ScriptManager.GetCurrent(this).EnablePartialRendering = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
