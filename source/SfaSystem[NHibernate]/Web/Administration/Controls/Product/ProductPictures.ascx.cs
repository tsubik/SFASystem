using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Controls_Product_ProductPictures : System.Web.UI.UserControl
{
    private void BindData()
    {
        Product product = CatalogService.GetProductByID(this.ProductID);
        if (product != null)
        {
            IList<SFASystem.Domain.Image> productImages = product.Images;
            if (productImages.Count > 0)
            {
                gvwImages.Visible = true;
                gvwImages.DataSource = productImages;
                gvwImages.DataBind();
            }
            else
                gvwImages.Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnUploadProductPicture);

        if (!Page.IsPostBack)
        {
            this.BindData();
            SetControlMode();
        }
    }

    private void SetControlMode()
    {
        if (Mode == ControlMode.ShowMode)
        {
            gvwImages.Columns[1].Visible = false;
            pnlAddPicture.Visible = false;
        }
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


    protected void btnUploadProductPicture_Click(object sender, EventArgs e)
    {
        try
        {
            Product product = CatalogService.GetProductByID(this.ProductID);
            if (product != null)
            {
                SFASystem.Domain.Image picture = null;
                HttpPostedFile productPictureFile = fuProductPicture.PostedFile;
                if ((productPictureFile != null) && (!String.IsNullOrEmpty(productPictureFile.FileName)))
                {
                    byte[] productPictureBinary = ImageHelper.GetPictureBits(productPictureFile.InputStream, productPictureFile.ContentLength);
                    picture = new SFASystem.Domain.Image();
                    picture.ImageFile = productPictureBinary;
                    BasicService<SFASystem.Domain.Image, Guid>.SaveOrUpdate(picture);
                }
                if (picture != null)
                {
                    product.Images.Add(picture);
                    BasicService<Product, Guid>.SaveOrUpdate(product);
                }
                MessageBoxControl messageBox = (MessageBoxControl)Page.Master.FindControl("messageBox");
                messageBox.ShowSuccess("Dodano zdjęcie");
                BindData();
            }
        }
        catch (Exception exc)
        {
            //ProcessException(exc);
        }
    }

    //protected void gvwImages_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "UpdateProductPicture")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = gvwImages.Rows[index];
    //        HiddenField hfProductPictureID = row.FindControl("hfProductPictureID") as HiddenField;

           
    //        Guid productPictureID = new Guid(hfProductPictureID.Value);
    //        SFASystem.Domain.Image productPicture = BasicService<SFASystem.Domain.Image>.GetByID(productPictureID);

    //        if (productPicture != null)
    //            ProductManager.UpdateProductPicture(productPicture.ProductPictureID,
    //               productPicture.ProductID, productPicture.PictureID, displayOrder);

    //        BindData();
    //    }
    //}

    protected void gvwImages_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SFASystem.Domain.Image productPicture = (SFASystem.Domain.Image)e.Row.DataItem;
            System.Web.UI.WebControls.Image iProductPicture = e.Row.FindControl("iProductPicture") as System.Web.UI.WebControls.Image;
            if (iProductPicture != null)
                iProductPicture.ImageUrl = new ImageService().GetImageUrl(productPicture.ImageID);

            Button btnUpdate = e.Row.FindControl("btnUpdate") as Button;
            if (btnUpdate != null)
                btnUpdate.CommandArgument = e.Row.RowIndex.ToString();
        }
    }

    protected void gvwImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Guid productPictureID = (Guid) gvwImages.DataKeys[e.RowIndex]["Imageid"];
        SFASystem.Domain.Image productPicture = BasicService<SFASystem.Domain.Image, Guid>.GetByID(productPictureID);
        if (productPicture != null)
        {
            BasicService<SFASystem.Domain.Image, Guid>.Delete(productPicture);
            MessageBoxControl messageBox = (MessageBoxControl)Page.Master.FindControl("messageBox");
            messageBox.ShowSuccess("Usunięto zdjęcie");
            BindData();
        }
    }

    public Guid ProductID
    {
        get
        {
            return CommonHelper.QueryStringGUID("ProductID");
        }
    }
}
