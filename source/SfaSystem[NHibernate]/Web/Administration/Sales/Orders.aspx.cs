using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Sales_Orders : System.Web.UI.Page
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
        if (StateItems.IsInOrderMode)
            btnOrder.Text = "Przejdź do zamówienia";
        else
            btnOrder.Text = "Dodaj zamówienie";
        ctrlSelectCustomer.BindData();
        ctrlSelectEmployee.BindData();
        ctrlSelectTerritory.BindData();
        ctrlOrderStatus.BindData();
        BindList();

    }

    private void BindList()
    {
        Customer customer = BasicService<Customer, Guid>.GetByID(ctrlSelectCustomer.SelectedCustomerId);
        Employee employee = BasicService<Employee, Guid>.GetByID(ctrlSelectEmployee.SelectedEmployeeID);
        Territory territory = BasicService<Territory, Guid>.GetByID(ctrlSelectTerritory.SelectedTerritoryId);
        Dictionary orderStatus = BasicService<Dictionary, Guid>.GetByID(ctrlOrderStatus.SelectedStatusID);

        DateTime outer;
        DateTime? startDate = null;
        DateTime? endDate = null;
        if (DateTime.TryParse(txtStartDate.Text, out outer))
            startDate = outer;
        if (DateTime.TryParse(txtEndDate.Text, out outer))
            endDate = outer;
        ctrlOrderList.BindList(customer, employee, territory, startDate, endDate,
            orderStatus);
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Sales/OrderAdd.aspx");
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
        txtEndDate.Text = string.Empty;
        txtStartDate.Text = string.Empty;
        ctrlOrderStatus.SelectedStatusID = Guid.Empty;
        ctrlSelectCustomer.SelectedCustomerId = Guid.Empty;
        ctrlSelectEmployee.SelectedEmployeeID = Guid.Empty;
        ctrlSelectTerritory.SelectedTerritoryId = Guid.Empty;

        BindList();
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        if (!StateItems.IsInOrderMode)
        {
            StateItems.IsInOrderMode = true;
            StateItems.CurrentOrder = new Order();
        }
        Response.Redirect("~/Administration/Sales/CreateOrder.aspx");
    }
}
