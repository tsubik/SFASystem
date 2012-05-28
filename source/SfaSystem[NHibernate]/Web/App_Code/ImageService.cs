using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SFASystem.WebUtils;

/// <summary>
/// Summary description for ImageService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ImageService : System.Web.Services.WebService
{

    public ImageService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

  


    [WebMethod]
    public string GetImageUrl(Guid imageId)
    {
        string url = WebConstants.ImageHandlerUrl + "?id=" + imageId.ToString();
        return url;
    }

    

}

