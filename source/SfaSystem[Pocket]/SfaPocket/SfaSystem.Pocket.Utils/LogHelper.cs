using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace SFASystem.Pocket.Utils
{
    public class LogHelper
    {
        private static ILog logger = LogManager.GetLogger("Application");

        static LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void Info(string message)
        {
            logger.Info(message);
        }
        public static void Debug(string message)
        {
            logger.Debug(message);
        }
        public static void Error(string message)
        {
            logger.Error(message);
        }
        public static void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
