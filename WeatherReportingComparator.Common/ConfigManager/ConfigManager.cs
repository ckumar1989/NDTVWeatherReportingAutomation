using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WeatherReportingComparator.Common.ConfigManager
{
    public class ConfigManager
    {
        #region Private Strings

        private string baseUrlUi;
        private string testBaseAPIUrl;
        private string browserType;
        private string apiKey;
        private readonly TestContext _testContext;

        #endregion

        public ConfigManager(TestContext testContext)
        {
            if (testContext == null)
            {
                throw new ArgumentNullException(nameof(testContext));
            }

            _testContext = testContext;
        }

        #region Public Strings

        public string BaseUrlUi
        {
            get
            {
                if (_testContext.Properties["UIBaseUrl"] != null)
                {
                    baseUrlUi = _testContext.Properties["UIBaseUrl"].ToString();
                }
                else
                {
                    throw new NullReferenceException("UIBaseUrl is not available in test settings file.");
                }
                return baseUrlUi;
            }
            set => baseUrlUi = value;
        }

        public string TestBaseAPIUrl
        {
            get
            {
                if (_testContext.Properties["TestBaseAPIUrl"] != null)
                {
                    testBaseAPIUrl = _testContext.Properties["TestBaseAPIUrl"].ToString();
                }
                else
                {
                    throw new NullReferenceException("TestBaseAPIUrl is not available in test settings file.");
                }
                return testBaseAPIUrl;
            }
            set => testBaseAPIUrl = value;
        }

        public string BrowserType
        {
            get
            {
                if (_testContext.Properties["BrowserType"] != null)
                {
                    browserType = _testContext.Properties["BrowserType"].ToString();
                }
                else
                {
                    throw new NullReferenceException("BrowserType is not available in test settings file.");
                }
                return browserType;
            }
            set => browserType = value;
        }

        public string APIKey
        {
            get
            {
                if (_testContext.Properties["APIKey"] != null)
                {
                    apiKey = _testContext.Properties["APIKey"].ToString();
                }
                else
                {
                    throw new NullReferenceException("APIKey is not available in test settings file.");
                }
                return apiKey;
            }
            set => apiKey = value;
        }

        #endregion

        
    }
}
