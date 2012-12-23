using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_SelectCountryControl : System.Web.UI.UserControl
{
    private Guid selectedCountryId;

    public bool Enabled
    {
        get { return ddlCountry.Enabled; }
        set { ddlCountry.Enabled = value; }
    }

    public void BindData()
    {
        ddlCountry.Items.Clear();
        ddlCountry.Items.Add(new ListItem(this.EmptyItemText, "0"));
        BindDropDown();
    }

    public void BindDropDown()
    {
        IList<Country> countryList = BasicService<Country, Guid>.GetAll().OrderBy(c => c.Name).ToList();
        if (countryList != null)
        {
            foreach (Country country in countryList)
            {
                ListItem ddlCountryItem = new ListItem(country.Name, country.CountryID.ToString());
                ddlCountry.Items.Add(ddlCountryItem);
            }

            this.ddlCountry.DataBind();
        }
        ddlCountry.SelectedValue = this.selectedCountryId.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string CssClass
    {
        get
        {
            return ddlCountry.CssClass;
        }
        set
        {
            ddlCountry.CssClass = value;
        }
    }

    public Guid SelectedCountryId
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlCountry.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedCountryId = value;
            ddlCountry.SelectedValue = value.ToString();
        }
    }
    public Unit Width
    {
        get
        {
            return ddlCountry.Width;
        }
        set
        {
            ddlCountry.Width = value;
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
