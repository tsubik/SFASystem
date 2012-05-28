using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Administration_Controls_Dictionaries : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        litError.Visible = false;
        if (!IsPostBack)
        {
            lbDictionaryType.DataSource = BasicService<DictionaryType, Guid>.GetAll();
            lbDictionaryType.DataBind();
        }
    }

    protected void lbDictionary_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtName.Text = BasicService<Dictionary, Guid>.GetByID(new Guid(lbDictionary.SelectedValue)).Value;
    }

    private void BindDictionaryList()
    {
        DictionaryType dctType = BasicService<DictionaryType, Guid>.GetByID(new Guid(lbDictionaryType.SelectedValue));
        if (dctType != null)
        {
            lbDictionary.DataSource = dctType.Dictionaries;
            lbDictionary.DataBind();
        }
    }

    protected void lbDictionaryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDictionaryList();
        txtName.Text = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Guid dictionaryId = new Guid(lbDictionary.SelectedValue);
        if (dictionaryId!=Guid.Empty)
        {
            Dictionary dct = BasicService<Dictionary, Guid>.GetByID(dictionaryId);
            dct.Value = txtName.Text;
            BasicService<Dictionary, Guid>.SaveOrUpdate(dct);
            BasicService<Dictionary, Guid>.Evict();
            BindDictionaryList();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        DictionaryType dctType = BasicService<DictionaryType, Guid>.GetByID(new Guid(lbDictionaryType.SelectedValue));
        if (dctType != null && tbAdd.Text != String.Empty)
        {
            Dictionary dictionary = new Dictionary();
            dictionary.DictionaryType = dctType;
            dictionary.Value = tbAdd.Text;

            BasicService<Dictionary, Guid>.SaveOrUpdate(dictionary);
            BasicService<Dictionary, Guid>.Evict();
            tbAdd.Text = string.Empty;
            BindDictionaryList();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Guid dictionaryId = new Guid(lbDictionary.SelectedValue);
        if (dictionaryId != Guid.Empty)
        {
            Dictionary dct = BasicService<Dictionary, Guid>.GetByID(dictionaryId);
            try
            {
                BasicService<Dictionary, Guid>.Delete(dct);
                BasicService<Dictionary, Guid>.Evict();
            }
            catch
            {
                litError.Visible = true;
            }
            txtName.Text = string.Empty;
            BindDictionaryList();
        }
    }
}
