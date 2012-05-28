using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SFASystem.Domain;
using SFASystem.Services;



/// <summary>
/// Summary description for AutoCompleteCityService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AutoCompleteCityService : System.Web.Services.WebService
{

    public AutoCompleteCityService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetCitiesList(string prefixText, int count)
    {
        IList<City> cities = CityService.GetCitiesLikeName(prefixText, count);
        List<string> result = new List<string>();
        foreach (City city in cities)
            result.Add(city.Name);
        
        return result.ToArray();
    }

    

}

