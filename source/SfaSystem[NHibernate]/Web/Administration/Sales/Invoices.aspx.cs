using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Sales_Invoices : System.Web.UI.Page
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
        ctrlSelectInvoiceStatus.BindData();
        BindList();
    }

    private void BindList()
    {
        Dictionary invoiceStatus = BasicService<Dictionary, Guid>.GetByID(ctrlSelectInvoiceStatus.SelectedStatusID);
        ctrlInvoiceList.BindList(invoiceStatus);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                BindList();
            }
            catch (Exception exc)
            {
                // ProcessException(exc);
            }
        }
    }
    protected void btnRemoveFilter_Click(object sender, EventArgs e)
    {
        //txtEndDate.Text = string.Empty;
        //txtStartDate.Text = string.Empty;
        //ctrlOrderStatus.SelectedStatusID = Guid.Empty;
        //ctrlSelectCustomer.SelectedCustomerId = Guid.Empty;
        //ctrlSelectEmployee.SelectedEmployeeID = Guid.Empty;
        //ctrlSelectTerritory.SelectedTerritoryId = Guid.Empty;

        //BindList();
    }
}
