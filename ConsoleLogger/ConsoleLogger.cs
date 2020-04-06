///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Basic class to log messages to the console
///-----------------------------------------------------------------

using System;

namespace METEC
{
    public class ConsoleLogger
    {
        public LogPriority Priority { get; private set; }

        public ConsoleLogger(LogPriority priority) { Priority = priority; }

        public void Debug(string process, string message)
        {
            if (Priority >= LogPriority.Debug)
                Log("DEBUG", process, message);
        }
        public void Info(string process, string message)
        {
            if (Priority >= LogPriority.Info)
                Log("INFO", process, message);
        }
        public void Warn(string process, string message)
        {
            if (Priority >= LogPriority.Warn)
                Log("WARN", process, message);
        }
        public void Error(string process, string message)
        {
            if (Priority >= LogPriority.Error)
                Log("ERROR", process, message);
        }
        public void Fatal(string process, string message)
        {
            if (Priority >= LogPriority.Fatal)
                Log("FATAL", process, message);
        }

        private void Log(string priority, string process, string message)
        {
            var datestring = DateTime.Now.ToString("yyyy-dd-MM hh:mm:ss.fff");
            Console.WriteLine(String.Format("{0} [{1}] {2} - {3}", datestring, priority, process, message));
        }
    }

    public enum LogPriority
    {
        Fatal = 0,
        Error = 1,
        Warn = 2,
        Info = 3,
        Debug = 4
    }
}
