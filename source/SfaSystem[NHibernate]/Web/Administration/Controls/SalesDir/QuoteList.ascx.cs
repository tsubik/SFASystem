using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Services;
using SFASystem.Domain;

public partial class Administration_Controls_SalesDir_Quotes : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvQuotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuotes.PageIndex = e.NewPageIndex;
        //BindList();
    }

    public void BindList()
    {
        gvQuotes.DataSource = BasicService<Quote, Guid>.GetAll();
        gvQuotes.DataBind();
    }


}
