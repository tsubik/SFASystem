using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Administration_Reports_CustomerReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //rvCustomers.LocalReport.ReportPath = "CustomerReport.rdlc";
            //rvCustomers.LocalReport.ReportEmbeddedResource = "ReportViewer.CustomerReport.rdlc";
            //rvCustomers.LocalReport.DataSources.Clear();
            //rvCustomers.LocalReport.EnableExternalImages = true;
            //List<ReportParameter> param1 = new List<ReportParameter>();
            //string imagePath = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath,"")+ "/Web/App_Themes/administration/images/logo.png";
            //param1.Add( new ReportParameter("Path", imagePath));
            //rvCustomers.LocalReport.SetParameters(param1);

        }
    }
}
