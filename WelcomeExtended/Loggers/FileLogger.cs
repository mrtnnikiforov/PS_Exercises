using Microsoft.Extensions.Logging;
using System.IO;

namespace WelcomeExtended.Loggers
{
    internal class FileLogger : ILogger
    {
        private readonly string _filePath = "log.txt";

        public IDisposable BeginScope<TState>(TState state) => null;
        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = $"[{logLevel}] {formatter(state, exception)}";
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}