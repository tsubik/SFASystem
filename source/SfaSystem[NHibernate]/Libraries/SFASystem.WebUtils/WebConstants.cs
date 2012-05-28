using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.WebUtils
{


    public class WebConstants
    {
        public static string ImageHandlerUrl = "~/Administration/Images/GetImage.aspx";
    }

    /// <summary>
    /// kody bledow przesylane na strone bledu
    /// </summary>
    public enum ErrorPageCodeTypes
    {
        PageNotExist = 404,
        AuthorizationError = 403,
        OrderError = 113,
        ServerError = 500,
    }
}
