using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Product_ProductAttributes : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownAttributes();
        }
    }

    private Guid CurrentAttributeID
    {
        get { return (Guid)ViewState["attributeID"]; }
        set { ViewState["attributeID"] = value; }
    }


    private void FillDropDownAttributes()
    {
        ddlAttributes.Items.Clear();
        IList<ProductAttribute> attributes = BasicService<ProductAttribute, Guid>.GetAll();
        foreach (ProductAttribute attribute in attributes)
        {
            ddlAttributes.Items.Add(new ListItem(attribute.Name, attribute.ProductAttributeid.ToString()));
        }

    }

    private void BindAttribute()
    {
        ProductAttribute attribute = BasicService<ProductAttribute, Guid>.GetByID(CurrentAttributeID);
        if (attribute != null)
        {
            txtAttributeDesc.Text = attribute.FullDescription;
            txtAttributeName.Text = attribute.Name;
            
        }
        else
        {
            txtAttributeDesc.Text = string.Empty;
            txtAttributeName.Text = string.Empty;
        }
    }
    protected void btnAddNewAttribute_Click(object sender, EventArgs e)
    {
        panelEditAttribute.Visible = true;
        CurrentAttributeID = Guid.Empty;
        BindAttribute();
    }
    protected void btnSaveAttribute_Click(object sender, EventArgs e)
    {
        ProductAttribute attribute = BasicService<ProductAttribute, Guid>.GetByID(CurrentAttributeID);
        if (attribute == null)
            attribute = new ProductAttribute();
        attribute.Name = txtAttributeName.Text;
        attribute.FullDescription = txtAttributeDesc.Text;
        BasicService<ProductAttribute, Guid>.SaveOrUpdate(attribute);
    }
}
