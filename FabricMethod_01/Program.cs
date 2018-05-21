using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    enum LoggingProviders
    {
        Log4Net,
        Enterprise
    }

    interface ILogger
    {
        void LogMessage(string message);
        void LogError(string message);
        void LogVerboseInformation(string message);
    }
    class Log4NetLogger : ILogger
    {
        public void LogError(string errorMessage)
        {
            Console.WriteLine($"{"Log4Net Error occured :"}: {errorMessage}");
        }

        public void LogMessage(string message)
        {
            Console.WriteLine($"{"Log4Net message"}: {message}");
        }

        public void LogVerboseInformation(string message)
        {
            Console.WriteLine($"{"Log4Net Detailed info :"}: {message}");
        }
    }

    class EnterpriseLogger : ILogger
    {
        public void LogError(string errorMessage)
        {
            Console.WriteLine($"{"EnterpriseLogger Error occured :"}: {errorMessage}");
        }

        public void LogMessage(string message)
        {
            Console.WriteLine($"{"EnterpriseLogger message"}: {message}");
        }

        public void LogVerboseInformation(string message)
        {
            Console.WriteLine($"{"EnterpriseLogger Detailed info :"}: {message}");
        }
    }

    class LoggerProviderFactory
    {
        public static ILogger GetLoggingProvider(LoggingProviders logProviders)
        {
            switch (logProviders)
            {
                case LoggingProviders.Enterprise:
                    return new EnterpriseLogger();
                case LoggingProviders.Log4Net:
                    return new Log4NetLogger();
                default: return new EnterpriseLogger();
            }
        }
    }


    class Program
    {
        private static LoggingProviders GetTypeOfLoggingProviderFromConfigFile()
        {          
            return LoggingProviders.Enterprise;
        }
        static void Main(string[] args)
        {

            var providerType = GetTypeOfLoggingProviderFromConfigFile();
            ILogger logger = LoggerProviderFactory.GetLoggingProvider(providerType);
            logger.LogMessage("Hello Factory Method Design Pattern.");
            Console.WriteLine(logger.GetType().Name);
        }
    }
}
