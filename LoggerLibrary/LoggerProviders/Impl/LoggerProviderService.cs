using LoggerLibrary.Enum;
using LoggerLibrary.Services.Impl;

namespace LoggerLibrary.LoggerProviders.Impl
{
    public class LoggerProviderService : ILoggerProviderService
    {
        public void LogDebug(string message)
        {
            var consoleLogger = new ConsoleSink();
            consoleLogger.Log(LogLevel.DEBUG, message);
        }
        public void LogInformation(string logFilePath, string message)
        {
            var fileLogger = new FileSink(logFilePath);
            fileLogger.Log(LogLevel.INFO, message);
        }
        public void LogWarning(string logFilePath, string message)
        {
            var fileLogger = new FileSink(logFilePath);
            fileLogger.Log(LogLevel.WARN, message);
        }
    }
}
