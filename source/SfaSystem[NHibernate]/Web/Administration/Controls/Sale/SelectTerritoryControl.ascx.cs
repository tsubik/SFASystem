using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Sale_SelectTerritoryControl : System.Web.UI.UserControl
{
    private Guid selectedTerritoryId;

    public void BindData()
    {
        ddlTerritories.Items.Clear();
        ddlTerritories.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindData(Guid.Empty, "--");
        this.ddlTerritories.DataBind();
    }

    public void BindData(Guid ForParentEntityID, string prefix)
    {
        IList<Territory> territoryList = SalesService.GetSubTerritories(BasicService<Territory, Guid>.GetByID(ForParentEntityID));
        if (territoryList != null)
        {
            foreach (Territory territory in territoryList)
            {
                ListItem item = new ListItem(prefix + territory.Name, territory.TerritoryID.ToString());
                this.ddlTerritories.Items.Add(item);
                if (territory.TerritoryID == this.selectedTerritoryId)
                    item.Selected = true;
                if (SalesService.GetSubTerritories(territory).Count > 0)
                    BindData(territory.TerritoryID, prefix + "--");
            }


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
            ddlTerritories.ValidationGroup = value;
            rfvValue.ValidationGroup = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ddlTerritories.CssClass;
        }
        set
        {
            ddlTerritories.CssClass = value;
        }
    }

    public Guid SelectedTerritoryId
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlTerritories.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedTerritoryId = value;
            ddlTerritories.SelectedValue = selectedTerritoryId.ToString();
        }
    }
    public bool Enabled
    {
        get
        {
            return ddlTerritories.Enabled;
        }

        set
        {
            ddlTerritories.Enabled = value;
            rfvValue.Enabled = value;
        }
    }

    public Unit Width
    {
        get
        {
            return ddlTerritories.Width;
        }
        set
        {
            ddlTerritories.Width = value;
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
