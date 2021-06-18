using OpenQA.Selenium;

namespace WeatherReportingComparator.BaseComponents
{
    public class BasePage
    {
        //driver instance variable which would be set here and accessed on each page class
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Property for getting Page title
        public string PageTitle { get; }

        //Property for Window Handle
        protected string WindowHandle { get; }

    }
}
