using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Services;
using SFASystem.WebUtils;
using SFASystem.Domain;

public partial class Administration_SalesDirector_QuoteDetails : System.Web.UI.Page
{
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                 
                Quote quote = ctrlQuoteInfo.SaveInfo();
                MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
                messageBox.ShowSuccess("Zmiany wprowadzono");
                //Response.Redirect(string.Format("ProductDetails.aspx?ProductID={0}", product.Productid));
            }
            catch (Exception exc)
            {
               
                throw;
                //ProcessException(exc);
            }
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            BasicService<Quote, Guid>.Delete(this.QuoteID);
            StateItems.Message = new Message(MessageType.Success, "Usunięto cytat");
            //CategoryManager.MarkCategoryAsDeleted(this.CategoryID);
            Response.Redirect("~/Administration/SalesDirector/Quotes.aspx");
        }
        catch (Exception exc)
        {
            throw;
            //ProcessException(exc);
        }
    }

    public Guid QuoteID
    {
        get
        {
            return CommonHelper.QueryStringGUID("QuoteID");
        }
    }
}
