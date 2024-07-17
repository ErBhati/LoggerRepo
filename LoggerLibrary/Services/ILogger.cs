using LoggerLibrary.Enum;

namespace LoggerLibrary.Services
{
    public interface ILogger
    {
        void Log(LogLevelEnum level, string message);
    }
}
