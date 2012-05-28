using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SFASystem.Pocket.Utils
{
    public class Settings
    {
        public static string ConfigurationFilePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\config.xml";
        public static string DatabaseFile = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\SFASystemDB.sdf";
        public static string DatabaseConnectionString = "DataSource=" + DatabaseFile + ";Password=\"sfasystem\";Encrypt=true";

        //public static string DatabaseConnectionString
        //{
        //    get
        //    {
        //        return ConfigurationHelper.GetConfigurationStringValue(ConfigurationFilePath, "connectionstring");
        //    }
        //    set
        //    {
        //        ConfigurationHelper.SetConfigurationStringValue(ConfigurationFilePath, "connectionstring", value);
        //    }
        //}
    }
}
