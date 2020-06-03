using System.Collections.Generic;
using Elastic.CommonSchema;

namespace Essential.LoggerProvider
{
    public class LogEvent : Base
    {
        // Custom field; use capitalisation as per ECS 
        public string? MessageTemplate { get; set; }

        // Custom field; use capitalisation as per ECS 
        public IList<string>? Scopes { get; set; }
    }
}
