using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.DataAccess.SqlServerNH;
using System.Web;

namespace SFASystem.WebUtils.HttpModules
{

    public class NHibernateSessionModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += new System.EventHandler(context_EndRequest);
        }

        void context_EndRequest(object sender, System.EventArgs e)
        {
            HBManager.Instance.CloseSession();
        }
        public void Dispose()
        {
            
        }
    }

}
