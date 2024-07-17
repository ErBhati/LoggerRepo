namespace LoggerLibrary.LoggerProviders
{
    public interface ILoggerProviderService
    {
        public void LogDebug(string message);
        public void LogInformation(string logFilePath, string message);
        public void LogWarning(string logFilePath, string message);      
    }
}
