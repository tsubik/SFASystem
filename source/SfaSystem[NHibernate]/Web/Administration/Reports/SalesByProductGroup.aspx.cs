using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Administration_Reports_SalesByProductGroup : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ScriptManager.GetCurrent(this).SupportsPartialRendering = false;
        ScriptManager.GetCurrent(this).EnablePartialRendering = false;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    private void SetReportData()
    {
        DateTime outer;
        DateTime? startDate = null;
        DateTime? endDate = null;
        if (DateTime.TryParse(txtStartDate.Text, out outer))
            startDate = outer;
        if (DateTime.TryParse(txtEndDate.Text, out outer))
            endDate = outer;
        MessageBoxControl msgBox = (MessageBoxControl)Page.Master.FindControl("messageBox");
        if (startDate == null || endDate == null)
        { 
            msgBox.ShowValidateError("Zły format daty. Prawidłowy format daty to MM-dd-yyyy.");
            return;
        }
        if (startDate > endDate)
        {
            msgBox.ShowValidateError("Data od nie może być poźniejsza niż data do.");
            return;
        }

        ReportParameter[] reportParameters = new ReportParameter[2];
       
        reportParameters[0] = new ReportParameter("startdate", startDate.Value.ToString());
        reportParameters[1] = new ReportParameter("enddate", endDate.Value.ToString());

        rvSales.ServerReport.SetParameters(reportParameters);
        rvSales.ServerReport.Refresh();
    }

    private void BindData()
    {
        txtStartDate.Text = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0, 0)).ToString("MM/dd/yyyy");
        txtEndDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

        SetReportData();
    }

    protected void btnExecute_Click(object sender, EventArgs e)
    {
        SetReportData();
    }
}
