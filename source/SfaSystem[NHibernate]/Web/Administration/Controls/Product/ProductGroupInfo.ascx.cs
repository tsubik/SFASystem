using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Controls_Product_ProductGroupInfo : System.Web.UI.UserControl
{
    private void BindData()
    {
        ProductGroup productGroup = BasicService<ProductGroup, Guid>.GetByID(this.ProductGroupID);

        if (productGroup != null)
        {
            this.txtName.Text = productGroup.Name;
            this.txtDescription.Text = productGroup.Description;
            if (productGroup.ProductGroupParent != null)
                ctrlParentGroup.SelectedProductGroupId = productGroup.ProductGroupParent.ProductGroupID;
            this.ctrlParentGroup.BindData();

        }
        else
        {
            ctrlParentGroup.SelectedProductGroupId = this.ParentProductGroupID;
            ctrlParentGroup.BindData();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
            SetControlMode();
        }
    }

    public ProductGroup SaveInfo()
    {
        ProductGroup productGroup = BasicService<ProductGroup, Guid>.GetByID(this.ProductGroupID);

        if (productGroup == null)
        {
            productGroup = new ProductGroup();
        }
        productGroup.Name = txtName.Text;
        productGroup.Description = txtDescription.Text;
        productGroup.ProductGroupParent = BasicService<ProductGroup, Guid>.GetByID(ctrlParentGroup.SelectedProductGroupId);
        BasicService<ProductGroup, Guid>.SaveOrUpdate(productGroup);
        return productGroup;
    }

    public ControlMode Mode
    {
        get
        {
            object obj = ViewState["ControlMode"];
            if (obj == null)
                return ControlMode.EditMode;
            return (ControlMode)obj;
        }
        set
        {
            ViewState["ControlMode"] = value;
            SetControlMode();
        }
    }

    private void SetControlMode()
    {
        if (this.Mode == ControlMode.EditMode)
        {
            
           
            txtName.Enabled = true;
            txtDescription.Enabled = true;
            ctrlParentGroup.Enabled = true;
        }
        else if (this.Mode == ControlMode.ShowMode)
        {
 
            txtDescription.Enabled = false;
            txtName.Enabled = false;
            ctrlParentGroup.Enabled = false;
        }
    }

    public Guid ParentProductGroupID
    {
        get
        {
            return CommonHelper.QueryStringGUID("ParentProductGroupID");
        }
    }

    public Guid ProductGroupID
    {
        get
        {
            return CommonHelper.QueryStringGUID("ProductGroupID");
        }
    }
}
