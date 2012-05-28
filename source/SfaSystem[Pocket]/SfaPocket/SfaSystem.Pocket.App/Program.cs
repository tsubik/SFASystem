using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SFASystem.Pocket.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new LogonForm());
        }
    }
}