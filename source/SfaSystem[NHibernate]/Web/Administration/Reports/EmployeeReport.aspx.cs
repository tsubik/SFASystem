using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Reports_EmployeeReport : System.Web.UI.Page
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

    private void BindData()
    {
        if (Context.User.IsInRole("SalesDirector"))
            ctrlSelectEmployee.BindData();
        else
        {
            IList<Employee> employees = BasicService<Employee, Guid>.GetAll().Where(e => e.Manager == SFAContext.Current.Employee).ToList();
            ctrlSelectEmployee.BindData(employees);
        }
    }
    protected void btnExecute_Click(object sender, EventArgs e)
    {
        rvSales.Enabled = true;
        rvSales.Visible = true;

        ReportParameter[] reportParameters = new ReportParameter[2];
        reportParameters[0] = new ReportParameter("EmpID", ctrlSelectEmployee.SelectedEmployeeID.ToString());
        reportParameters[1] = new ReportParameter("ReportYear", lstYear.SelectedValue);
        rvSales.ServerReport.SetParameters(reportParameters);
        rvSales.ServerReport.Refresh();
    }
}
