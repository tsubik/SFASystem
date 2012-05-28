<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
        log4net.Config.XmlConfigurator.Configure();
        CreateDefaultRoles();
        CreateDefaultUserIfNotExists();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        log4net.LogManager.Shutdown();
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        try
        {
            //stare logi
            //log4net.LogManager.GetLogger("Application").Error("", Context.Error);

            log4net.ILog log = log4net.LogManager.GetLogger("Application");
            StringBuilder errorBuilder = new StringBuilder();

            errorBuilder.AppendLine("");

            //errorBuilder.AppendLine("SessionID:"+Context.Session.SessionID);
            if (Context.User != null && Context.User.Identity != null)
            {
                errorBuilder.AppendLine("User:" + Context.User.Identity.Name);
            }
            if (Context.Request != null)
            {
                errorBuilder.AppendLine("Request:");
                if (Context.Request.Cookies["ASP.NET_SessionID"] != null)
                    errorBuilder.AppendLine("SessionID: " + Context.Request.Cookies["ASP.NET_SessionID"].Value);
                errorBuilder.AppendLine("Url: " + Context.Request.Url);
                errorBuilder.AppendLine("UserIP: " + Context.Request.UserHostAddress);
                errorBuilder.AppendLine("UserHost: " + Context.Request.UserHostName);
            }
            errorBuilder.AppendLine("Exception:");
            errorBuilder.AppendLine(Context.Error.ToString());


            if (Context.Error.InnerException != null)
            {
                errorBuilder.AppendLine("--------------------------------------------------------");
                errorBuilder.AppendLine("Inner Exception:");
                errorBuilder.AppendLine(Context.Error.InnerException.ToString());
            }
            errorBuilder.AppendLine("#########################################################");
            log.Error(errorBuilder.ToString());

            //if (Request != null && Request.PhysicalPath == Request.MapPath(PageUrlString.Url_Error))
                //Context.ClearError();
        }
        catch (Exception ex)
        {
            //try
            //{
            //    log4net.ILog log = log4net.LogManager.GetLogger("Application");
            //    StringBuilder builder2 = new StringBuilder();
            //    builder2.AppendLine("ERROR WHILE BUILDING ERROR LOG");
            //    builder2.AppendLine(ex.Message);
            //    log.Error(builder2.ToString());

            //}
            //catch { }
        }

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    private static void CreateDefaultRoles()
    {
        if (Roles.Enabled)
        {
            //if (!Roles.RoleExists("Administrator"))
            //    Roles.CreateRole("Administrator");
            if (!Roles.RoleExists("SalesRep"))
                Roles.CreateRole("SalesRep");
            if (!Roles.RoleExists("SalesManager"))
                Roles.CreateRole("SalesManager");
            if (!Roles.RoleExists("SalesDirector"))
                Roles.CreateRole("SalesDirector");
        }
    }

    private static void CreateDefaultUserIfNotExists()
    {
        //const string AdminUser = "admin";
        //const string AdminPassword = "admin";

        const string SalesRepUser = "salesrep";
        const string SalesRepPassword = "salesrep";

        const string SalesManagerUser = "salesmanager";
        const string SalesManagerPassword = "salesmanager";

        const string SalesDirectorUser = "salesdirector";
        const string SalesDirectorPassword = "salesdirector";

        //if (Membership.GetUser(AdminUser) == null)
        //{
        //    Membership.CreateUser(AdminUser, AdminPassword, string.Empty);
        //    Roles.AddUsersToRole(new string[] { AdminUser }, "Administrators");
        //}
        
        if (Membership.GetUser(SalesRepUser) == null)
        {
            Membership.CreateUser(SalesRepUser, SalesRepPassword, string.Empty);
            Roles.AddUsersToRole(new string[] { SalesRepUser }, "SalesRep");
        }
        
        if (Membership.GetUser(SalesManagerUser) == null)
        {
            Membership.CreateUser(SalesManagerUser, SalesManagerPassword, string.Empty);
            Roles.AddUsersToRole(new string[] { SalesManagerUser }, "SalesManager");
        }
        
        if (Membership.GetUser(SalesDirectorUser) == null)
        {
            Membership.CreateUser(SalesDirectorUser, SalesDirectorPassword, string.Empty);
            Roles.AddUsersToRole(new string[] { SalesDirectorUser }, "SalesDirector");
        }
    }
       
</script>
