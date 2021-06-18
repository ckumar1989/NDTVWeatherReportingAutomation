using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherReportingComparator.BaseComponents;
using WeatherReportingComparator.PageModels.UI.Pages;

namespace WeatherReportingComparator.PageModels.UI
{
    public class TestApp : App
    {
       
        public TestApp(TestContext TestContext) : base(TestContext)
        {
            Launch();
        }

        private HomePage _homePage;
        public HomePage HomePage => _homePage ?? (_homePage = new HomePage(Driver));

        private WeatherReportPage _weatherReportPage;
        public WeatherReportPage WeatherReportPage => _weatherReportPage ?? (_weatherReportPage = new WeatherReportPage(Driver));

    }
}
