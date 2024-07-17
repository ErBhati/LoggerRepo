namespace LoggerLibrary.LoggerProviders
{
    public interface IDbLogger
    {
        public void LogFatal(string connectionString, string message);
        public void LogError(string connectionString, string message);
    }
}
