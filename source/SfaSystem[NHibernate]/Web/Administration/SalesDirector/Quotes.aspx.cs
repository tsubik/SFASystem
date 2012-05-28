using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_SalesDirector_Quotes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }


    private void BindData()
    {
        BindList();
    }

    private void BindList()
    {
        ctrlQuote.BindList();
    }


    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/SalesDirector/QuoteAdd.aspx");
    }
  
}
