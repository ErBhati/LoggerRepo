using LoggerLibrary.Enum;

namespace LoggerLibrary.Services.Impl
{
    public class ConsoleSink : ILogger
    {
        public void Log(LogLevelEnum level, string message)
        {
            Console.WriteLine($"[{level}] {message}");
        }
    }
}
