using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;

public partial class Install_Rozne_TestEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        Order order = SalesService.GetOrders().FirstOrDefault();
        if (order != null)
            MailHelper.SendApprovedOrderEmail(emailAddress.Text, order);
    }
}
