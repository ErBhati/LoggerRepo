using LoggerLibrary.Enum;

namespace LoggerLibrary.Services.Impl
{
    public class FileSink : ILogger, IDisposable
    {
        private readonly string _filePath;
        private readonly object _lock = new object();

        public FileSink(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(LogLevelEnum level, string message)
        {
            lock (_lock)
            {
                using (var writer = System.IO.File.AppendText(_filePath))
                {
                    writer.WriteLine($"[{level}] {message}");
                }
            }
        }

        public void Dispose()
        {
            // Dispose resources if needed
        }
    }
}
