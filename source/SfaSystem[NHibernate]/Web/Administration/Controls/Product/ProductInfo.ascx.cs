using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;
using SFASystem.DataAccess.SqlServerNH;
using SFASystem.Services;

public partial class Administration_Controls_Product_ProductInfo : System.Web.UI.UserControl
{
    //public Guid ProductID
    //{
    //    get { return (Guid)ViewState["productID"]; }
    //    set { ViewState["productID"] = value; }
    //}

    public Guid ProductID
    {
        get { return CommonHelper.QueryStringGUID("ProductID"); }
    }

    public Product Product
    {
        get
        {
            return  CatalogService.GetProductByID(this.ProductID);
        }
    }

    public ControlMode Mode
    {
        get { 
            object obj = ViewState["ControlMode"];
            if(obj == null)
                return ControlMode.EditMode;
            return (ControlMode)obj;
        }
        set { ViewState["ControlMode"] = value;
                SetControlMode();
        }
    }

    private void SetControlMode()
    {
        if (this.Mode == ControlMode.EditMode)
        {
            txtCode.Enabled = true;
            txtDescription.Enabled = true;
            txtName.Enabled = true;
            txtPrice.Enabled = true;
            txtShortDescription.Enabled = true;
            ctrlSelectProductGroup.Enabled = true;
            ctrlSelectManufacturer.Enabled = true;
            ctrlSelectTax.Enabled = true;
        }
        else if (this.Mode == ControlMode.ShowMode)
        {
            txtCode.Enabled = false;
            txtDescription.Enabled = false;
            txtName.Enabled = false;
            txtPrice.Enabled = false;
            txtShortDescription.Enabled = false;
            ctrlSelectProductGroup.Enabled = false;
            ctrlSelectManufacturer.Enabled = false;
            ctrlSelectTax.Enabled = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
            SetControlMode();
        }
    }

    private void BindData()
    {
        Product product = this.Product;
        if (product != null)
        {
            txtCode.Text = product.Code;
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString("0.00##");
            lblProductID.Text = product.Productid.ToString();
            txtDescription.Text = product.FullDescription;
            txtShortDescription.Text = product.ShortDescription;
            if(product.Manufacturer != null)
                ctrlSelectManufacturer.SelectedManufacturerID = product.Manufacturer.ManufacturerID;
            ctrlSelectProductGroup.SelectedProductGroupId = product.ProductGroup.ProductGroupid;
            ctrlSelectTax.SelectedStatusID = product.Tax.Dictionaryid;
        }
        ctrlSelectProductGroup.BindData();
        ctrlSelectTax.BindData();
        ctrlSelectManufacturer.BindData();
    }

    public Product SaveInfo()
    {
        Product product = null;
        if (Page.IsValid)
        {
            product = this.Product;
            if (product == null)
                product = new Product();
            ProductGroup prodGroup = BasicService<ProductGroup, Guid>.GetByID(ctrlSelectProductGroup.SelectedProductGroupId);
            if (prodGroup == null)
                return null;
            Manufacturer manufacturer = BasicService<Manufacturer, Guid>.GetByID(ctrlSelectManufacturer.SelectedManufacturerID);
            product.Manufacturer = manufacturer;
            product.ProductGroup = prodGroup;
            product.Name = txtName.Text;
            try{
                product.Price = Decimal.Parse(txtPrice.Text);
            }catch{
                return null;
            }
            product.Code = txtCode.Text;
            product.Tax = BasicService<Dictionary, Guid>.GetByID(ctrlSelectTax.SelectedStatusID);
            product.ShortDescription = txtShortDescription.Text;
            product.FullDescription = txtDescription.Text;
            BasicService<Product, Guid>.SaveOrUpdate(product);
        }
        return product;
    }
}
