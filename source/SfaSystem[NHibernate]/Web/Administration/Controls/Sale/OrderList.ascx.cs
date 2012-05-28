using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Sale_OrderList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrders.PageIndex = e.NewPageIndex;
        BindList();
    }

    protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Order order = (Order)e.Row.DataItem;
            //Label lblAssignedTo = e.Row.FindControl("lblAssignedTo") as Label;
            //Label lblGivenBy = e.Row.FindControl("lblGivenBy") as Label;
            //Label lblCreatedBy = e.Row.FindControl("lblCreatedBy") as Label;
            Label lblCustomer = e.Row.FindControl("lblCustomer") as Label;
            Label lblStatus = e.Row.FindControl("lblStatus") as Label;
            lblCustomer.Text = order.CustomerFacility.Customer.Name;

        }
    }


    public void BindList()
    {
        gvOrders.DataSource = SalesService.GetOrders();
        gvOrders.DataBind();
    }

    public void BindList(CustomerFacility fac)
    {
        gvOrders.DataSource = SalesService.GetOrders(fac).OrderByDescending(o => o.OrderDate).ToList();
        gvOrders.DataBind();
    }

    public void BindList(Customer customer, Employee emp, Territory terr,
            DateTime? startDate, DateTime? endDate, Dictionary orderStatus)
    {
        gvOrders.DataSource = SalesService.GetOrders(customer, emp, terr,
            startDate,endDate, orderStatus).OrderByDescending( o => o.OrderDate ).ToList();
        gvOrders.DataBind();
    }

}
