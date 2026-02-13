using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace WelcomeExtended.Loggers
{
    internal class LoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new HashLogger(categoryName);
        }

        public ILogger CreateFileLogger(string categoryName)
        {
            return new FileLogger();
        }

        public void Dispose()
        {
            return;
        }
    }
}
