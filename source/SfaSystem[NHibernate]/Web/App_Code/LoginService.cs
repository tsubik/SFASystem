using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SFASystem.WebUtils.Security;
using SFASystem.Services;
using SFASystem.Domain;

/// <summary>
/// Summary description for LoginService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class LoginService : System.Web.Services.WebService
{
    public LoginService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public Guid LoginUser(string username, string password)
    {
        if (EmployeeService.Login(username, password))
        {
            Employee emp = EmployeeService.GetEmployeeByLogin(username);
            if(emp.Roles.Contains(EmployeeService.GetRoleByName("SalesRep")))
            {
                return emp.Employeeid;
            }
        }
        return Guid.Empty;
    }
}

