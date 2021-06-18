using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReportingComparator.Common.ConfigManager;

namespace WeatherReportingComparator.API
{
    public class GetWeatherService
    {
        protected ConfigManager configManager;

        public GetWeatherService(TestContext testContext)
        {
            configManager = new ConfigManager(testContext);
        }

        public (float tempInCelsius, int humidity) GetCityTemperatureAndHumidityDetailsFromAPI(string city)
        {
            try
            {
                //Create object of RestClient class
                IRestClient restClient = new RestClient(configManager.TestBaseAPIUrl);

                //Create object of RestRequest class for request
                var restRequest = new RestRequest("data/2.5/weather", Method.GET);
                restRequest.AddQueryParameter("q", city);
                restRequest.AddQueryParameter("appid", configManager.APIKey);
                restRequest.AddQueryParameter("units", "metric");

                //Execute Request
                var response =  restClient.Execute<Rootobject>(restRequest);
                float tempInCelsius = response.Data.main.temp;
                int humidity = response.Data.main.humidity;
                return (tempInCelsius, humidity);
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
    }
}
