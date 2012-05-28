using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;

public partial class Error : System.Web.UI.Page
{
    protected Label errorInfo
    {
        get
        {
            Label lab = (Label)infoMsg.TemplateControl.Controls[2].Controls[0].FindControl("errorInfo");
            lab.Text = "Wystąpił nieoczekiwany błąd serwisu.";
            return lab;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int error = 0;
        string errorID = Request.Params["errorID"];
        if (errorID != null)
        {
            try
            {
                error = int.Parse(errorID);
            }
            catch (FormatException) { }
        }

        infoMsg.Text = "Błąd";

        switch ((ErrorPageCodeTypes)error)
        {
            case ErrorPageCodeTypes.PageNotExist:
                Response.StatusCode = 404;
                infoMsg.Text = "Przykro nam, ale żądana strona nie istnieje.";
                break;
            case ErrorPageCodeTypes.AuthorizationError:
                infoMsg.Text = "Masz zbyt niskie uprawnienia, aby obejrzeć tę stronę.";
                break;
            case ErrorPageCodeTypes.ServerError:
                infoMsg.Text = "Wystąpił nieoczekiwany błąd serwisu.";
                break;
            default:
                infoMsg.Text = "Wystąpił nieoczekiwany błąd serwisu.";
                break;
        }
    }
}
