using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Controls_ProductGroupList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    public event EventHandler<EventArgs<Guid>> ProductGroupSelected;
    protected virtual void OnProductGroupSelected(EventArgs<Guid> e)
    {
        if (ProductGroupSelected != null)
            ProductGroupSelected(this, e);
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
        BindData();
    }

    private void BindData()
    {
        string menu = GetCategories(Guid.Empty);
        string prodgroupAddURL = "~/Administration/Products/ProductGroupAdd.aspx";
        if(this.Mode == ControlMode.EditMode)
            menu = "<siteMapNode title=\"Grupy produktów\" url=\"" + string.Empty + "\">" + menu + "<siteMapNode  title=\"Dodaj nową grupę: \" url=\"" + prodgroupAddURL + "\"></siteMapNode></siteMapNode>";
        else
            menu = "<siteMapNode title=\"Grupy produktów\" url=\"" + string.Empty + "\">" + menu + "</siteMapNode>";
        ds.Data = menu;
        ProductGroupTreeView.DataBind();
    }

    protected string GetCategories(Guid ForParentEntityID)
    {
        StringBuilder tmpS = new StringBuilder(4096);

        IList<ProductGroup> productsGroups = CatalogService.GetSubProductsGroups(BasicService<ProductGroup, Guid>.GetByID(ForParentEntityID));
        if (productsGroups != null)
        {
            for (int i = 0; i < productsGroups.Count; i++)
            {
                ProductGroup productGroup = productsGroups[i];
                string prodgroupDetailsURL = "~/Administration/Products/ProductGroupDetails.aspx?ProductGroupID=" + productGroup.ProductGroupID.ToString();
                tmpS.Append("<siteMapNode  title=\"" + XmlHelper.XmlEncodeAttribute(productGroup.Name)
                    + "\" url=\"" + prodgroupDetailsURL + "\">");
                if (CatalogService.GetSubProductsGroups(productGroup).Count > 0)
                    tmpS.Append(GetCategories(productGroup.ProductGroupID));

                string prodgroupAddURL = "~/Administration/Products/ProductGroupAdd.aspx?ParentproductGroupID=" + productGroup.ProductGroupID.ToString();
                if(this.Mode == ControlMode.EditMode)
                    tmpS.Append("<siteMapNode  title=\"Dodaj nową grupę:\" url=\"" + prodgroupAddURL + "\"></siteMapNode>");

                //tmpS.Append("<siteMapNode  title=\"Products:\" url=\"" + string.Empty + "\">");
                //string productAddURL = CommonHelper.GetStoreAdminLocation(false) + "ProductAdd.aspx?productGroupID=" + productGroup.productGroupID.ToString();
                //tmpS.Append("<siteMapNode  title=\"Add new product:\" url=\"" + productAddURL + "\"></siteMapNode>");

                //int totalRecords = 0;
                //ProductCollection products = ProductManager.GetAllProducts(productGroup.productGroupID, 0, null, int.MaxValue, 0, out totalRecords);
                //foreach (Product product in products)
                //{
                //    string productDetailsURL = CommonHelper.GetStoreAdminLocation(false) + "ProductDetails.aspx?ProductID=" + product.ProductID.ToString();
                //    tmpS.Append("<siteMapNode  title=\"" + XmlHelper.XmlEncodeAttribute(product.Name) + "\" url=\"" + productDetailsURL + "\">");
                //    tmpS.Append("</siteMapNode>");
                //}
                //tmpS.Append("</siteMapNode>");


                tmpS.Append("</siteMapNode>");
            }
        }
        return tmpS.ToString();
    }

    protected void ProductGroupTreeView_SelectedNodeChanged(object sender, EventArgs e)
    {
        
    }
}
