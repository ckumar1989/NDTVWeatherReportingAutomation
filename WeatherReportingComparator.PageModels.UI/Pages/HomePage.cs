using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReportingComparator.BaseComponents;
using WeatherReportingComparator.Selenium.Selenium.Extensions;

namespace WeatherReportingComparator.PageModels.UI.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver)
           : base(webDriver)
        {

        }

        #region Properties
        
        private IWebElement NoThanksLinkOnPopUpAlert => driver.FindElement(By.XPath("//div[@class = 'noti_wrap']//a[text() = 'No Thanks']"));

        private IWebElement subMenuThreeDotsElement => driver.FindElement(By.Id("h_sub_menu"));

        private IWebElement WeatherLinkElement => driver.FindElement(By.LinkText("WEATHER"));

        #endregion

        #region Methods

        public void ClicksubMenuThreeDotsElement()
        {
            try
            {
                subMenuThreeDotsElement.Click();
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void ClickWeatherLinkElement()
        {
            try
            {
                WeatherLinkElement.Click();
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public bool IsNoThanksLinkOnPopUpAlertExists()
        {
            try
            {
                if (NoThanksLinkOnPopUpAlert.Exists())
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClickNoThanksLinkOnPopUpAlert()
        {
            try
            {
                NoThanksLinkOnPopUpAlert.Click();
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        #endregion
    }
}
