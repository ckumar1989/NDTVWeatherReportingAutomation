using System;
using System.IO;

namespace WeatherReportingComparator.Common.Logging
{
    public class Log
    {
        private string currentLogFile;

        public string CurrentLogFile
        {
            get { return currentLogFile; }
            set { currentLogFile = value; }
        }

        public void CreateLog()
        {
            string logDir = @"C:\WeatherComparator_Automation_Logs";
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            string logFile = string.Format($"{logDir}\\{Convert.ToString(DateTime.Now.ToString("Logs_yy-MM-dd_hhmmss"))}.Log");

            using (var fc = File.Create(logFile))
            {
                fc.Close();
            }
            if (String.IsNullOrEmpty(CurrentLogFile))
                CurrentLogFile = logFile;
        }

        public void WriteLine(string LogData, LogType logType)
        {
            if (String.IsNullOrEmpty(CurrentLogFile))
                CreateLog();

            using (StreamWriter log = new StreamWriter(CurrentLogFile, true))
            {
                log.WriteLine("{0} - {1}: {2}", DateTime.Now.ToString(), logType, LogData);
                log.WriteLine("");
            }
        }

        public void Write(string LogData, LogType logType)
        {
            if (String.IsNullOrEmpty(CurrentLogFile))
                CreateLog();

            using (StreamWriter log = new StreamWriter(CurrentLogFile, true))
            {
                log.Write("{0} - {1}: {2}", DateTime.Now.ToString(), logType, LogData);
            }
        }
    }

    public enum LogType
    {
        INFO,
        ERROR,
        PASS,
        FAIL
    }
}
