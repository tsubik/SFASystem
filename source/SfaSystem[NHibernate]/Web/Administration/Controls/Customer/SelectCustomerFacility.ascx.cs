using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Services;
using SFASystem.Domain;

public partial class Administration_Controls_Customer_SelectCustomerFacility : System.Web.UI.UserControl
{
    private Guid selectedFacilityId;

    public void BindData(Customer cust)
    {
        ddlCustomersFacility.Items.Clear();
        ddlCustomersFacility.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindList(cust);
        try
        {
            ddlCustomersFacility.SelectedValue = selectedFacilityId.ToString();
        }
        catch
        {
        }
    }

    private void BindList(Customer cust)
    {
        IList<CustomerFacility> facilityList = CustomerService.GetFacilitiesForCustomer(cust);
        if (facilityList != null)
        {
            foreach (CustomerFacility facility in facilityList)
            {
                ListItem item = new ListItem(facility.Name, facility.CustomerFacilityID.ToString());
                this.ddlCustomersFacility.Items.Add(item);
            }

            this.ddlCustomersFacility.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (rfvValue.ErrorMessage != string.Empty)
            rfvValue.InitialValue = Guid.Empty.ToString();
    }

    public string ErrorMessage
    {
        get
        {
            return rfvValue.ErrorMessage;
        }
        set
        {
            rfvValue.ErrorMessage = value;
        }
    }

    public string ValidationGroup
    {
        get
        {
            return rfvValue.ValidationGroup;
        }
        set
        {
            ddlCustomersFacility.ValidationGroup = value;
            rfvValue.ValidationGroup = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ddlCustomersFacility.CssClass;
        }
        set
        {
            ddlCustomersFacility.CssClass = value;
        }
    }

    public Guid SelectedFacilityId
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlCustomersFacility.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedFacilityId = value;
            ddlCustomersFacility.SelectedValue = selectedFacilityId.ToString();
        }
    }

    public Unit Width
    {
        get
        {
            return ddlCustomersFacility.Width;
        }
        set
        {
            ddlCustomersFacility.Width = value;
        }
    }

    public string EmptyItemText
    {
        get
        {
            if (ViewState["EmptyItemText"] == null)
                return "[ --- ]";
            else
                return (string)ViewState["EmptyItemText"];
        }
        set { ViewState["EmptyItemText"] = value; }
    }
}
