using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class Error
    {
        public Error(string type, string message, string stackTrace)
        {
            Type = type;
            Message = message;
            StackTrace = stackTrace;
        }

        [DataMember(Name = "message")] public string Message { get; }

        [DataMember(Name = "stack_trace")] public string StackTrace { get; }
        
        [DataMember(Name = "type")] public string Type { get; }

        // If there is an exception
        // error.code, error.id, error.message, error.stack_trace, error.type
    }
}
