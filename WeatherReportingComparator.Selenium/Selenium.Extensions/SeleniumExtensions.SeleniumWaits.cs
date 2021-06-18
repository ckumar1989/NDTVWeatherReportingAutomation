using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherReportingComparator.Selenium.Selenium.Extensions
{
    public static class SeleniumWaits
    {
        public static TimeSpan LongWaitTime { get { return TimeSpan.FromSeconds(90); } }
        public static TimeSpan SmallWaitTime { get { return TimeSpan.FromSeconds(30); } }

        public static bool WaitForElement(this IWebDriver driver, By by, int waitTimeInSec = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSec));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            catch
            {
                Thread.Sleep(3000);
                return false;
            }
        }

        public static void WaitForPageLoad(this IWebDriver driver, int maxTimeoutInSec)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxTimeoutInSec));
                wait.PollingInterval = TimeSpan.FromMilliseconds(10);
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (WebDriverTimeoutException)
            {
            }
        }

        public static bool WaitUntilElementNotPresent(this IWebDriver driver, By by, int timeoutInSeconds = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException), typeof(InvalidOperationException));
                bool isSuccess = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
                return isSuccess;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
