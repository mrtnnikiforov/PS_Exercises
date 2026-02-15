using DataLayer.Database;
using DataLayer.Model;
using Microsoft.Extensions.Logging;
using System;

namespace DataLayer.Loggers
{
    public class DatabaseLogger : ILogger
    {
        
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
             return null; 
        }

       
        public bool IsEnabled(LogLevel logLevel)
        {
             return true; 
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
          
            using (var context = new DatabaseContext())
            {
                context.Logs.Add(new LogEntry
                {
                    Message = formatter(state, exception),
                    Timestamp = DateTime.Now
                });

                context.SaveChanges();
            }
        }
    }
}