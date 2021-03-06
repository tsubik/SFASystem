﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using SFASystem.WebUtils;

public partial class Administration_Controls_Charts_MySalesManSalesChart : System.Web.UI.UserControl
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ReportParameter[] reportParameters = new ReportParameter[2];

        reportParameters[0] = new ReportParameter("ReportYear", DateTime.Now.Year.ToString());
        reportParameters[1] = new ReportParameter("ManID", SFAContext.Current.Employee.EmployeeID.ToString());
        rvSales.ServerReport.SetParameters(reportParameters);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
