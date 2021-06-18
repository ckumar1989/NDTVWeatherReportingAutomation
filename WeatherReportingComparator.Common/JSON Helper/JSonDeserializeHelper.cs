using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportingComparator.Common.JSON_Helper
{
    public class JSonDeserializeHelper
    {
        public static TestDataForWeather ReadJSONFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string strJsonFromFile = File.ReadAllText(filePath);
                    TestDataForWeather testData = JsonConvert.DeserializeObject<TestDataForWeather>(strJsonFromFile);
                    return testData;
                }
                else
                {
                    throw new FileNotFoundException("Json file is not found.");
                }
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
    }


    public class TestDataForWeather
    {
        public string City { get; set; }
        public int Variance { get; set; }
    }

}
