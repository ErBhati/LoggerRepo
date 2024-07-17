using LoggerLibrary.Enum;
using LoggerLibrary.Services.Impl;

namespace LoggerLibrary.LoggerProviders.Impl
{
    public class DbLogger : IDbLogger
    {
        public void LogFatal(string connectionString, string message)
        {
            var dbLogger = new DbSink(connectionString);
            dbLogger.Log(LogLevelEnum.FATAL, message);
        }
        public void LogError(string connectionString, string message)
        {
            var dbLogger = new DbSink(connectionString);
            dbLogger.Log(LogLevelEnum.ERROR, message);
        }
    }
}
