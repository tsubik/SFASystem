using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_SelectProductGroupControl : System.Web.UI.UserControl
{
    private Guid selectedProductGroupId;

    public bool Enabled
    {
        get { return ddlProductGroups.Enabled; }
        set { ddlProductGroups.Enabled = value; }
    }

    public void BindData()
    {
        ddlProductGroups.Items.Clear();
        ddlProductGroups.Items.Add(new ListItem(this.EmptyItemText, Guid.Empty.ToString()));
        BindData(Guid.Empty, "--");
    }

    public void BindData(Guid ForParentEntityID, string prefix)
    {
        IList<ProductGroup> productGroupList = CatalogService.GetSubProductsGroups(BasicService<ProductGroup, Guid>.GetByID(ForParentEntityID));
        if (productGroupList != null)
        {
            foreach (ProductGroup productGroup in productGroupList)
            {
                ListItem item = new ListItem(prefix + productGroup.Name, productGroup.ProductGroupID.ToString());
                this.ddlProductGroups.Items.Add(item);
                if (productGroup.ProductGroupID == this.selectedProductGroupId)
                    item.Selected = true;
                if (CatalogService.GetSubProductsGroups(productGroup).Count > 0)
                    BindData(productGroup.ProductGroupID, prefix + "--");
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
            ddlProductGroups.ValidationGroup = value;
            rfvValue.ValidationGroup = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ddlProductGroups.CssClass;
        }
        set
        {
            ddlProductGroups.CssClass = value;
        }
    }

    public Guid SelectedProductGroupId
    {
        get
        {
            Guid result = Guid.Empty;
            try
            {
                result = new Guid(this.ddlProductGroups.SelectedItem.Value);
            }
            catch { }

            return result;
        }
        set
        {
            this.selectedProductGroupId = value;
            ddlProductGroups.SelectedValue = selectedProductGroupId.ToString();
        }
    }
    public Unit Width
    {
        get
        {
            return ddlProductGroups.Width;
        }
        set
        {
            ddlProductGroups.Width = value;
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
