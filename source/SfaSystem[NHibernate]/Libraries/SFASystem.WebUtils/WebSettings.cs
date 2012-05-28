using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Configuration;



namespace SFASystem.PocketUtils
{
    public class WebSettings
    {

        public static string GetConnectionString(string connectionStringName)
        {
            string connectionString = null;

            ConnectionStringSettings settings = WebConfigurationManager.ConnectionStrings[connectionStringName];
            if (settings != null)
            {
                connectionString = settings.ConnectionString;
            }

            return connectionString;
        }
    }
}
