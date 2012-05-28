using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_CountryList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    public void BindData()
    {
        gvCountries.DataSource = BasicService<Country, Guid>.GetAll();
        gvCountries.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Control c = (Control)sender;
        GridViewRow row = (GridViewRow)c.Parent.Parent;

        Guid countryID = (Guid) Convert.ChangeType(row.Cells[0].Text, typeof(Guid));
        Country country = BasicService<Country, Guid>.GetByID(countryID);
        TextBox txtCountryName = row.FindControl("txtCountryName") as TextBox;
        country.Name = txtCountryName.Text;
        BasicService<Country, Guid>.SaveOrUpdate(country);
    }
}
