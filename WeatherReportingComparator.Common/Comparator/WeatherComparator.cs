using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportingComparator.Common.Comparator
{
    public static class WeatherComparator
    {
        public static bool CompareTemperaturesWithSpecifiedVariance(float temp1, float temp2, int variance)
        {
            try
            {
                float diff = Math.Abs(temp1 - temp2);
                if (diff < variance)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }

        public static bool CompareHumidityWithSpecifiedVariance(float humidity1, float humidity2, int variance)
        {
            try
            {
                float diff = Math.Abs(humidity1 - humidity2);
                if (diff < variance)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.GetType().ToString() + " : " + ex.Message;
                throw new Exception("Error occured in method " + System.Reflection.MethodBase.GetCurrentMethod().Name + ". Exception is: " + exceptionMessage);
            }
        }
    }
}
