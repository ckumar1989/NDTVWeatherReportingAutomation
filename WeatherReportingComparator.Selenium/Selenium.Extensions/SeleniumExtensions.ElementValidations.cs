using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportingComparator.Selenium.Selenium.Extensions
{
    public static class SeleniumElementValidation
    {
        public static bool Exists(this IWebElement element)
        {
            try
            {
                if (element != null)
                    return true;
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
