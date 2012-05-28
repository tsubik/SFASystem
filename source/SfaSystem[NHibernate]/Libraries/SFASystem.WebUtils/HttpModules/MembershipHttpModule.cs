using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SFASystem.Domain;
using SFASystem.Services;

namespace SFASystem.WebUtils.HttpModules
{
    /// <summary>
    /// nopCommerce membership module
    /// </summary>
    
    public class MembershipHttpModule : IHttpModule
    {
        #region Methods
        /// <summary>
        /// Handlers the AuthenticateRequest event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            
                bool authenticated = false;
                if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null)
                    authenticated = HttpContext.Current.User.Identity.IsAuthenticated;

                if (authenticated)
                {
                    Employee employee = EmployeeService.GetEmployeeByLogin(HttpContext.Current.User.Identity.Name);
                    if (employee != null)
                    {

                        if (employee.Active)
                        {
                            SFAContext.Current.Employee = employee; 
                        }
                        else
                        {
                            logout();
                        }
                    }
                    else
                    {
                        logout();
                    }
                }           
        }

        /// <summary>
        /// Logout customer
        /// </summary>
        protected void logout()
        {
            EmployeeService.LogOut();
            HttpContext.Current.Response.Redirect("~/Login.aspx");
        }

        /// <summary>
        /// Handlers the BeginRequest event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    //if (InstallerHelper.ConnectionStringIsSet())
        //    //{
        //    //    NopContext.Current.IsAdmin = CommonHelper.IsAdmin();
        //    //    Language currentLanguage = NopContext.Current.WorkingLanguage;
        //    //    if (currentLanguage != null)
        //    //    {
        //    //        NopContext.Current.SetCulture(new CultureInfo(currentLanguage.LanguageCulture));
        //    //    }
        //    //}
        //}

        /// <summary>
        /// Handlers the EndRequest event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        //protected void Application_EndRequest(object sender, EventArgs e)
        //{
        //    //if (InstallerHelper.ConnectionStringIsSet())
        //    //{
        //    //    try
        //    //    {
        //    //        bool sessionReseted = false;
        //    //        if (NopContext.Current["Nop.SessionReseted"] != null)
        //    //        {
        //    //            sessionReseted = Convert.ToBoolean(NopContext.Current["Nop.SessionReseted"]);
        //    //        }
        //    //        if (!sessionReseted)
        //    //        {
        //    //            NopContext.Current.SessionSaveToClient();
        //    //        }
        //    //    }
        //    //    catch (HttpException exc)
        //    //    {
        //    //        LogManager.InsertLog(LogTypeEnum.Unknown, exc.Message, exc);
        //    //    }
        //    //}
        //}


        /// <summary>
        /// Handlers the PostRequestHandlerExecute event of the application
        /// </summary>        
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        protected void application_PostRequestHandlerExecute(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handlers the PreSendRequestContent event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        protected void application_PreSendRequestContent(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handlers the ReleaseRequestState event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        protected void Application_ReleaseRequestState(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///  Initializes the NopCommerceFilter object
        /// </summary>
        /// <param name="application">The application</param>
        public void Init(HttpApplication application)
        {
            //application.BeginRequest += new EventHandler(this.Application_BeginRequest);
            //application.EndRequest += new EventHandler(this.Application_EndRequest);
            application.ReleaseRequestState += new EventHandler(this.Application_ReleaseRequestState);
            application.AuthenticateRequest += new EventHandler(this.Application_AuthenticateRequest);
            application.PreSendRequestContent += new EventHandler(this.application_PreSendRequestContent);
            application.PostRequestHandlerExecute += new EventHandler(this.application_PostRequestHandlerExecute);
        }

        /// <summary>
        /// Disposes the object
        /// </summary>
        public void Dispose()
        {
        }
        #endregion
    }
}
