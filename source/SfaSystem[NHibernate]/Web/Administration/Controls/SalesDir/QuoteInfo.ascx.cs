using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Services;
using SFASystem.WebUtils;
using SFASystem.Domain;

public partial class Administration_Controls_SalesDir_QuoteInfo : System.Web.UI.UserControl
{
    private void BindData()
    {
        Quote quote = BasicService<Quote, Guid>.GetByID(this.QuoteID);

        if (quote != null)
        {
            txtText.Text = quote.Text;
            chxActive.Checked = quote.Active;
            txtAuthor.Text = quote.Text;
        }
        else
        {
           
        }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    public Quote SaveInfo()
    {
        if (!Page.IsValid)
            return null;

        Quote quote = BasicService<Quote, Guid>.GetByID(this.QuoteID);
        
        if (quote == null)
        {
            quote = new Quote();
        }
        quote.Active = chxActive.Checked;
        quote.Author = txtAuthor.Text;
        quote.Text = txtText.Text;

        BasicService<Quote, Guid>.SaveOrUpdate(quote);
        return quote;
    }

    public Guid QuoteID
    {
        get
        {
            return CommonHelper.QueryStringGUID("QuoteID");
        }
    }
}
