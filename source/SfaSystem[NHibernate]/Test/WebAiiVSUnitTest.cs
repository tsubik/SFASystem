using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.TestTemplates;
using ArtOfTest.WebAii.TestAttributes;
using ArtOfTest.WebAii.Win32.Dialogs;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ArtOfTest.WebAii.BrowserSpecialized.AspNetHost;

namespace SFASystem.Test
{
    /// <summary>
    /// Summary description for WebAiiVSUnitTest
    /// </summary>
    [TestClass]
    public class WebAiiVSUnitTest : BaseTest
    {

        #region [Setup / TearDown]

        private TestContext testContextInstance = null;
        /// <summary>
        ///Gets or sets the VS test context which provides
        ///information about and functionality for the 
        ///current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }


        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            #region WebAii Initialization

            Settings settings = GetSettings();
            settings.LocalWebServer = LocalWebServerType.AspNetDevelopmentServer;
            settings.WebAppPhysicalPath = @"D:\Tommy\Studia\Magisterka\Solucja\SfaSystem[NHibernate]\Web";
            settings.LogLocation = TestContext.TestLogsDir;

            Initialize(settings, new TestContextWriteLine(this.TestContext.WriteLine));

            
            SetTestMethod(this, (string)TestContext.Properties["TestName"]);

            #endregion
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {

            //
            // Place any additional cleanup here
            //

            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            ShutDown();
        }

        #endregion
       
        [TestMethod]
        [Description("Test logowania przedstawiciela handlowego.")]
        [DeploymentItem(@"", "AspNetApp")]
        public void CheckSalesRepLogIn()
        {
            // Inicjalizacja aplikacji ASP .NET
            Manager.LaunchNewBrowser();
            //Nawigacja do strony logowania
            ActiveBrowser.NavigateTo("~/Login.aspx");
            if (ActiveBrowser.BrowserType == BrowserType.AspNetHost)
            {
                AspNetHostBrowser hostBrowser = (AspNetHostBrowser)ActiveBrowser;
                Assert.IsTrue(hostBrowser.Status == 200);
            }

            HtmlInputText txtLogin = Manager.ActiveBrowser.Find.ById<HtmlInputText>("~UserName");
            HtmlInputPassword txtPassword = Manager.ActiveBrowser.Find.ById<HtmlInputPassword>("~Password");

            txtLogin.Text = "salesrep";
            txtPassword.Text = "sr";

            HtmlInputSubmit button = Manager.ActiveBrowser.Find.ById<HtmlInputSubmit>("~LoginButton");
            button.Click();
            
            Assert.IsTrue(ActiveBrowser.Url.Contains("SalesRepresentative/Dashboard.aspx"));
        }

    }
}
