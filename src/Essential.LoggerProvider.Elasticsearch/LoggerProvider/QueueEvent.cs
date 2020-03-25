using System;
using Microsoft.Extensions.Logging;

namespace Essential.LoggerProvider
{
    public class QueueEvent
    {
        public string CategoryName { get; }
        public LogLevel LogLevel { get; }
        public EventId? EventId { get; }
        public string Message { get; }
        public Exception? Exception { get; }
        public object[]? Scopes { get; }

        public QueueEvent(string categoryName, LogLevel logLevel, EventId? eventId, string message,
            Exception? exception, object[]? scopes)
        {
            CategoryName = categoryName;
            LogLevel = logLevel;
            EventId = eventId;
            Message = message;
            Exception = exception;
            Scopes = scopes;
            
            // TODO: Need to render values at time event is created
            // e.g. scope values could be mutable.
        }
    }
}
