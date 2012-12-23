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

public partial class Administration_Controls_TerritoryList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        string menu = GetCategories(Guid.Empty);
        string territoryAddURL = "~/Administration/Sales/TerritoryAdd.aspx";
        if(this.Mode == ControlMode.EditMode)
            menu = "<siteMapNode title=\"Regiony sprzedaży\" url=\"" + string.Empty + "\">" + menu + "<siteMapNode  title=\"Dodaj nowy region: \" url=\"" + territoryAddURL + "\"></siteMapNode></siteMapNode>";
        else
            menu = "<siteMapNode title=\"Regiony sprzedaży\" url=\"" + string.Empty + "\">" + menu + "</siteMapNode>";
        ds.Data = menu;
        TerritoryTreeView.DataBind();
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

    protected string GetCategories(Guid ForParentEntityID)
    {
        StringBuilder tmpS = new StringBuilder(4096);

        IList<Territory> territoryList = SalesService.GetSubTerritories(BasicService<Territory, Guid>.GetByID(ForParentEntityID));
        if (territoryList != null)
        {
            for (int i = 0; i < territoryList.Count; i++)
            {
                Territory territory = territoryList[i];
                string prodgroupDetailsURL = "~/Administration/Sales/TerritoryDetails.aspx?TerritoryID=" + territory.TerritoryID.ToString();
                tmpS.Append("<siteMapNode  title=\"" + XmlHelper.XmlEncodeAttribute(territory.Name)
                    + "\" url=\"" + prodgroupDetailsURL + "\">");
                if (SalesService.GetSubTerritories(territory).Count > 0)
                    tmpS.Append(GetCategories(territory.TerritoryID));

                string territoryAddURL = "~/Administration/Sales/TerritoryAdd.aspx?ParentTerritoryID=" + territory.TerritoryID.ToString();
                if(this.Mode == ControlMode.EditMode)
                    tmpS.Append("<siteMapNode  title=\"Dodaj nowy region:\" url=\"" + territoryAddURL + "\"></siteMapNode>");

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
}
