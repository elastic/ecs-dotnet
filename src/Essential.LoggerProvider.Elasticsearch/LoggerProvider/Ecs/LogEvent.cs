using System;
using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class LogEvent
    {
        [DataMember(Name = "@timestamp")]
        public DateTimeOffset Timestamp { get; set; }
        
        [DataMember(Name = "message")]
        public string Message { get; set; } = string.Empty;
    }
}
