using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherReportingComparator.Common.Logging;
using WeatherReportingComparator.PageModels.UI;

namespace WeatherReportingComparator.Tests.UI
{
    [TestClass]
    public class TestBase
    {
        #region Field Declaration

        protected string exceptionMsg = string.Empty;

        protected string stackTraceMessage = string.Empty;

        #endregion

        public TestBase()
        {
          
        }

        public TestContext TestContext { get; set; }

        public TestApp TestApp;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {

          
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            
        }

        [TestInitialize]
        public void TestInitialize()
        {
            
            LaunchNewTestApp();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestApp.IsAppLaunched)
                TestApp.Quit();
        }

        public void LaunchNewTestApp()
        {
            TestApp = new TestApp(TestContext);
        }
    }
}