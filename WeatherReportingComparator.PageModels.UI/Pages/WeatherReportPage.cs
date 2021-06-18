using OpenQA.Selenium;
using System;
using WeatherReportingComparator.BaseComponents;
using WeatherReportingComparator.Selenium.Selenium.Extensions;

namespace WeatherReportingComparator.PageModels.UI.Pages
{
    public class WeatherReportPage : BasePage
    {
        private string city = string.Empty;

        public WeatherReportPage(IWebDriver webDriver)
           : base(webDriver)
        {

        }

        #region Properties

        private IWebElement SearchBoxElement => driver.FindElement(By.Id("searchBox"));

        private IWebElement CheckBoxForPuneLabel => driver.FindElement(By.XPath($"//input[@id = '{city}']"));

        private IWebElement CityOnMapElement => driver.FindElement(By.XPath($"//div[@class = 'outerContainer']//div[text() = '{city}']"));

        private IWebElement WeatherDetailsContainerElement => driver.FindElement(By.XPath("//div[@class = 'leaflet-popup-content-wrapper']"));

        private IWebElement temperatureSpanOnMapElement => driver.FindElement(By.XPath($"//div[text() = '{city}']/parent::div//div/span[@class = 'tempRedText']"));

        private IWebElement DegreesCelsiusTempSpanInTempDetailsContainer => driver.FindElement(By.XPath("//div[@class = 'leaflet-popup-content']//span[4]"));

        private IWebElement FahrenheitTempSpanInTempDetailsContainer => driver.FindElement(By.XPath("//div[@class = 'leaflet-popup-content']//span[5]"));

        private IWebElement HumiditySpanInTempDetailsContainer => driver.FindElement(By.XPath("//div[@class = 'leaflet-popup-content']//span[3]"));

        private IWebElement LoadingText => driver.FindElement(By.XPath("//div[text() = 'Loading...']"));


        #endregion

        #region Methods

        public void SetSearchBoxElementValue(string value)
        {
            try
            {
                this.city = value;
                SearchBoxElement.Clear();
                SearchBoxElement.SendKeys(value);
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
            finally
            {
                this.city = string.Empty;
            }
        }

        public void SelectCheckBoxForCity(string cityName)
        {
            try
            {
                this.city = cityName;
                CheckBoxForPuneLabel.Click();
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public bool IsCityAvailableOnMap(string cityName)
        {
            try
            {
                this.city = cityName;

                if (CityOnMapElement.Exists())
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsCityTempDetailsAvailableOnMap(string cityName)
        {
            try
            {
                this.city = cityName;

                if (temperatureSpanOnMapElement.Exists())
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SelectCityOnMap(string cityName)
        {
            try
            {
                this.city = cityName;
                CityOnMapElement.Click();
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public bool IsWeatherDetailsContainerExists()
        {
            try
            {
                if (WeatherDetailsContainerElement.Exists())
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public float GetCityTemperatureInCelsius()
        {
            try
            {
                string temp = DegreesCelsiusTempSpanInTempDetailsContainer.Text.Split(':')[1].Trim();
                float tempInDegreesCelsius = (float)Convert.ToInt32(temp);
                return tempInDegreesCelsius;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public float GetCityTemperatureInFahrenheit()
        {
            try
            {
                string temp = FahrenheitTempSpanInTempDetailsContainer.Text.Split(':')[1].Trim();
                float tempInFahrenheit = (float)Convert.ToInt32(temp);
                return tempInFahrenheit;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public int GetCityHumidity()
        {
            try
            {
                string Humidity = HumiditySpanInTempDetailsContainer.Text.Split(':')[1].Trim().Replace("%", "");
                int HumidityInInteger = Convert.ToInt32(Humidity);
                return HumidityInInteger;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        #endregion

        #region Aggregate Methods

        public void PinSpecifiedCity(string cityName)
        {
            try
            {
                SetSearchBoxElementValue(cityName);
                SelectCheckBoxForCity(cityName);
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public void WaitForLoadingTextDisappear()
        {
            try
            {
                SeleniumWaits.WaitUntilElementNotPresent(driver, By.XPath("//div[text() = 'Loading...']"), 60);
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
