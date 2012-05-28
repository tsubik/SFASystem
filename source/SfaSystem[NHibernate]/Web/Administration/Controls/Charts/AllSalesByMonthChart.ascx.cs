using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;


public partial class Administration_Controls_Charts_AllSalesByMonth : System.Web.UI.UserControl
{

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ReportParameter[] reportParameters = new ReportParameter[1];

        reportParameters[0] = new ReportParameter("ReportYear", DateTime.Now.Year.ToString());
        rvSales.ServerReport.SetParameters(reportParameters);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
