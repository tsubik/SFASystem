using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Customers_CustomerContacts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDowns();
            BindData();
        }
    }

    private void FillDropDowns()
    {
        ctrlSelectCustomer.EmptyItemText = "Wszyscy klienci";
        ctrlSelectCustomer.BindData();
    }

    private void BindData()
    {
        string facName = txtName.Text;
        IList<Contact> contacts = CustomerService.GetContactsOnlyCust(txtImieNazwisko.Text, txtEmail.Text, txtTelefon.Text);
        ctrlContactList.BindList(contacts);
    }

    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/Customers/ContactAdd.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                BindData();
            }
            catch (Exception exc)
            {
                // ProcessException(exc);
            }
        }
    }
    protected void btnRemoveFilter_Click(object sender, EventArgs e)
    {
        txtEmail.Text = string.Empty;
        txtImieNazwisko.Text = string.Empty;
        txtName.Text = string.Empty;
        txtTelefon.Text = string.Empty;
        ctrlSelectCustomer.SelectedCustomerId = Guid.Empty;
        BindData();
    }
}
