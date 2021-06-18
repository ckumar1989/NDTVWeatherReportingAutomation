using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReportingComparator.Selenium.Selenium.Extensions;

namespace WeatherReportingComparator.Selenium.Browser_Factory
{
    public static class BrowserFactory
    {
        private static IWebDriver driver;

        /// <summary>
        /// Start the browser after getting the driver instance and launch the url mentioned in the appsettings.json file
        /// </summary>
        /// <param name="browserName"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IWebDriver StartBrowser(string browserName, string url)
        {
            try
            {
                GetDriver(browserName);

                //Set the url
                driver.Navigate().GoToUrl(url);
                SeleniumWaits.WaitForPageLoad(driver, 60);

                //Maximize the browser window
                driver.Manage().Window.Maximize();
                
                return driver;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }


        /// <summary>
        /// Get the driver instance bassed on the browser name mentioned in the appsettings.json file
        /// </summary>
        /// <param name="browserName"></param>
        public static void GetDriver(string browserName)
        {
            try
            {
                switch (browserName.ToLower())
                {
                    case "internetexplorer":

                        var ieoptions = new InternetExplorerOptions
                        {
                            EnsureCleanSession = true,
                            InitialBrowserUrl = "http://www.bing.com",
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                            EnableNativeEvents = false,
                            IgnoreZoomLevel = true,
                            EnablePersistentHover = true,
                        };
                        driver = new InternetExplorerDriver(ieoptions);

                        break;
                    case "firefox":

                        FirefoxProfile profile = new FirefoxProfile()
                        {
                            DeleteAfterUse = true

                        };
                        profile.SetPreference("browser.download.folderList", 2);
                        var systemLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        profile.SetPreference("browser.download.dir", systemLocation);
                        profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "text/plain,text/css,text/html");

                        FirefoxOptions foptions = new FirefoxOptions()
                        {
                            Profile = profile
                        };
                        driver = new FirefoxDriver(foptions);

                        break;
                    case "chrome":

                        var cOptions = new ChromeOptions();
                        cOptions.AddArguments("chrome.switches", "--disable-extensions");
                        cOptions.AddUserProfilePreference("download.default_directory", Environment.CurrentDirectory);
                        driver = new ChromeDriver(cOptions);

                        break;
                    case "edge":

                        var eoptions = new EdgeOptions
                        {
                            PageLoadStrategy = PageLoadStrategy.Normal
                        };
                        driver = new EdgeDriver(eoptions);

                        break;
                }
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
    }
}
