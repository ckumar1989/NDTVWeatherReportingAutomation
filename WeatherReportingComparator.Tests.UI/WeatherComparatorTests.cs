using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherReportingComparator.API;
using WeatherReportingComparator.Common.Comparator;
using WeatherReportingComparator.Common.JSON_Helper;

namespace WeatherReportingComparator.Tests.UI
{
    [TestClass]
    public class SmokeTest : TestBase
    {
        [TestMethod, TestCategory("Regression"), Owner("Chitresh")]
        public void CompareWeatherReportingForSpecifiedCity()
        {
            try
            {
                #region Initializaing Variables by reading test data from Json file

                string testDataFile = Environment.CurrentDirectory + "\\TestData\\WeatherTestData.json";
                TestDataForWeather ObjTestDataForWeather = JSonDeserializeHelper.ReadJSONFile(testDataFile);

                string cityName = ObjTestDataForWeather.City;
                int varianceForComparision = ObjTestDataForWeather.Variance;

                #endregion

                if (TestApp.HomePage.IsNoThanksLinkOnPopUpAlertExists())
                {
                    TestApp.HomePage.ClickNoThanksLinkOnPopUpAlert();
                }

                //Click sub menu three dots
                TestApp.HomePage.ClicksubMenuThreeDotsElement();

                //Click on Weather link
                TestApp.HomePage.ClickWeatherLinkElement();

                //Wait for Loading... text to be disappear and load the page
                TestApp.WeatherReportPage.WaitForLoadingTextDisappear();

                //Pin the specified city
                TestApp.WeatherReportPage.PinSpecifiedCity(cityName);

                //Validate that corresponding city is available on the map with temp
                Assert.IsTrue(TestApp.WeatherReportPage.IsCityAvailableOnMap(cityName) && TestApp.WeatherReportPage.IsCityTempDetailsAvailableOnMap(cityName),
                    $"[Assert]: The city {cityName} is not available on the map.");

                //Select the city on the map
                TestApp.WeatherReportPage.SelectCityOnMap(cityName);

                //Get temp in deegree celsius from weather container displayed on map
                float temperatureInCelsiusFromUI = TestApp.WeatherReportPage.GetCityTemperatureInCelsius();

                //Get Humidity from weather container displayed on map
                int HumidityFromUI = TestApp.WeatherReportPage.GetCityHumidity();

                //Validate selecting any city on the map reveals the weather details
                Assert.IsTrue(TestApp.WeatherReportPage.IsWeatherDetailsContainerExists(), $"[Assert]: The temperature details is not displayed after selecting the city {cityName}.");

                GetWeatherService getTemperatureService = new GetWeatherService(TestContext);
                var WeatherDetailsFromAPI = getTemperatureService.GetCityTemperatureAndHumidityDetailsFromAPI(cityName);

                bool IsTempDiffInGivenRange = WeatherComparator.CompareTemperaturesWithSpecifiedVariance(temperatureInCelsiusFromUI, WeatherDetailsFromAPI.tempInCelsius, varianceForComparision);
                Assert.IsTrue(IsTempDiffInGivenRange, "[Assert]: difference between both the temperatures from UI and API is more than the given variance.");

                bool IsHumidityDiffInGivenRange = WeatherComparator.CompareTemperaturesWithSpecifiedVariance(HumidityFromUI, WeatherDetailsFromAPI.humidity, varianceForComparision);
                Assert.IsTrue(IsHumidityDiffInGivenRange, "[Assert]: difference between both the humidities from UI and API is more than the given variance.");
            }
            catch (Exception ex)
            {
                exceptionMsg = ex.GetType().ToString() + " : " + ex.Message;
                stackTraceMessage = ex.StackTrace;
                Assert.Fail(ex.ToString());
            }
            finally
            {
                TestApp.CloseBroswer();
            }
        }

    }
}
