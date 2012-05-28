using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;
using System.Web.UI.HtmlControls;

public partial class Administration_Controls_Customer_CustomerFacilityList : System.Web.UI.UserControl
{
    public Guid CustomerID
    {
        get
        {
            Guid result = (Guid)ViewState["FacCustomerID"];
            if (result == null)
                result = Guid.Empty;
            return result;
        }
        set
        {
            ViewState["FacCustomerID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvFacilities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFacilities.PageIndex = e.NewPageIndex;
        //BindList();
    }

    public void BindList(Contact contact)
    {
        gvFacilities.Columns[6].Visible = StateItems.IsInOrderMode;

        gvFacilities.DataSource = CustomerService.GetFacilitiesForContact(contact);
        gvFacilities.DataBind();
        gvFacilities.Columns[0].Visible = false;
        
    }
    protected void btnAddToOrder_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).Parent.Parent;
        Guid facilityID = new Guid(row.Cells[0].Text);
        CustomerFacility facility = BasicService<CustomerFacility, Guid>.GetByID(facilityID);
        OrderManager.SetOrderToFacility(facility);
        MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
        messageBox.ShowSuccess("Zmiana placówki zamówienia na "+facility.Name+" firmy "+facility.Customer.Name);
    }

    public void BindList(Guid customerID, string facName, Guid territoryID)
    {
        gvFacilities.Columns[6].Visible = StateItems.IsInOrderMode;
        Customer cust = null;
        Territory terr = null;
        if (customerID != Guid.Empty)
        {
            cust = BasicService<Customer, Guid>.GetByID(customerID);
        }
        if (territoryID != Guid.Empty)
        {
            terr = BasicService<Territory, Guid>.GetByID(territoryID);
        }
        gvFacilities.DataSource = CustomerService.GetFacilities(string.Empty, cust, terr);
        gvFacilities.DataBind();
        gvFacilities.Columns[0].Visible = false;
    }
    protected void gvFacilities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;

            HtmlAnchor lnkDetails = (HtmlAnchor)e.Row.FindControl("lnkDetails");
            if (!(Context.User.IsInRole("Administrator") || Context.User.IsInRole("SalesDirector")))
            {
                lnkDetails.InnerText = "Szczegóły";
                lnkDetails.Title = "Przejdź do szczegółów";
            }
        }
    }
}
