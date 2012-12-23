using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using SFASystem.WebUtils;

public partial class Administration_Controls_Sale_TerritoryInfo : System.Web.UI.UserControl
{
    private void BindData()
    {
        Territory territory = BasicService<Territory, Guid>.GetByID(this.TerritoryID);

        if (territory != null)
        {
            this.txtName.Text = territory.Name;
            this.txtDescription.Text = territory.FullDescription;
            if (territory.ParentTerritory != null)
                ctrlParentTerritory.SelectedTerritoryId = territory.ParentTerritory.TerritoryID;
            this.ctrlParentTerritory.BindData();

        }
        else
        {
            ctrlParentTerritory.SelectedTerritoryId = this.ParentTerritoryID;
            ctrlParentTerritory.BindData();
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

    private void SetControlMode()
    {
        if (this.Mode == ControlMode.EditMode)
        {     
            txtDescription.Enabled = true;
            txtName.Enabled = true;
            ctrlParentTerritory.Enabled = true;
        }
        else if (this.Mode == ControlMode.ShowMode)
        {    
            txtDescription.Enabled = false;
            txtName.Enabled = false;
            ctrlParentTerritory.Enabled = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    public Territory SaveInfo()
    {
        Territory territory = BasicService<Territory, Guid>.GetByID(this.TerritoryID);

        if (territory == null)
        {
            territory = new Territory();
        }
        territory.Name = txtName.Text;
        territory.FullDescription = txtDescription.Text;
        territory.ParentTerritory = BasicService<Territory, Guid>.GetByID(ctrlParentTerritory.SelectedTerritoryId);
        BasicService<Territory, Guid>.SaveOrUpdate(territory);
        return territory;
    }

    protected void btnRemoveCategoryImage_Click(object sender, EventArgs e)
    {
        try
        {
            Territory territory = BasicService<Territory, Guid>.GetByID(this.TerritoryID);
            if (territory != null)
            {
                BasicService<Territory, Guid>.Delete(territory);
                //PictureManager.DeletePicture(category.PictureID);
                //CategoryManager.RemoveCategoryPicture(category.TerritoryID);
                BindData();
            }
        }
        catch (Exception exc)
        {
            throw;
            //ProcessException(exc);
        }
    }

    public Guid ParentTerritoryID
    {
        get
        {
            return CommonHelper.QueryStringGUID("ParentTerritoryID");
        }
    }

    public Guid TerritoryID
    {
        get
        {
            return CommonHelper.QueryStringGUID("TerritoryID");
        }
    }
}
