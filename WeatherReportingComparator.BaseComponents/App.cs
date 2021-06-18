using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;
using WeatherReportingComparator.Common.ConfigManager;
using WeatherReportingComparator.Selenium.Browser_Factory;

namespace WeatherReportingComparator.BaseComponents
{
    public class App
    {
        //driver instance 
        protected IWebDriver Driver;

        protected ConfigManager configManager;

        public App(TestContext textContext)
        {
            configManager = new ConfigManager(textContext);
        }

        public bool IsAppLaunched { get; protected set; }

        public void Launch()
        {
            try
            {
                Driver = BrowserFactory.StartBrowser(configManager.BrowserType, configManager.BaseUrlUi);
                if (Driver != null)
                    IsAppLaunched = true;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void CloseBroswer()
        {
            try
            {
                Driver.Close();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public virtual void Quit()
        {
            try
            {
                IsAppLaunched = false;
                Dispose();

            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing && Driver.Title != null)
                {
                    Driver.Close();
                    Driver.Quit();
                }
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is WebDriverException)
                {
                    // ignore as Quit() has already been called
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
