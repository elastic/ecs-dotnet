using System;

namespace Essential.LoggerProvider.Ecs
{
    public class LogEvent
    {
        public DateTimeOffset Timestamp { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
