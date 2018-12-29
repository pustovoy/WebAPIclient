using System;
using System.Globalization;
using System.IO;

namespace WebAPIclient.Services
{
    public static class ErrorLogService
    {
        public static void StoreErrorLog(string logMessage)
        {
            using (StreamWriter w = File.AppendText(@"C:\Users\Yuri.Pustovoy\Documents\Visual Studio 2017\Projects\AutoRepairShop\AutoRepairShop\bin\Debug\ErrorLog.txt"))
            {
                if (logMessage != null)
                {
                    Log(logMessage, w);
                }
                else
                {
                    Console.WriteLine($"LOG ERROR: No log message provided");
                }
            }
        }

        private static void Log(string logMessage, TextWriter w)
        {
            w.Write($"\r{DateTime.Now.ToString("MM/dd/yyyy h:mm tt", CultureInfo.CurrentUICulture)} : ");
            w.WriteLine($"{logMessage}");
        }
    }
}
