using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Domain;

public partial class Administration_SalesDirector_QuoteAdd : System.Web.UI.Page
{
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Quote quote = ctrlQuoteInfo.SaveInfo();
                StateItems.Message = new Message(MessageType.Success, "Dodano nowy cytat ");
                Response.Redirect(string.Format("QuoteDetails.aspx?QuoteID={0}", quote.Quoteid));
            }
            catch (Exception exc)
            {
                throw;
                //ProcessException(exc);
            }
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
