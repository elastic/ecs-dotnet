using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class Event
    {
        public Event(string action, string code, long severity)
        {
            Action = action;
            Code = code;
            Severity = severity;
        }

        // event.action, = example: user-password-change   ** EventId.Name **
        [DataMember(Name = "name")] public string Action { get; }

        // event.code, = example of this is the Windows Event ID. ** EventId.Id **
        [DataMember(Name = "code")] public string Code { get; }

        // event.severity = numeric => from LogLevel
        [DataMember(Name = "severity")] public long Severity { get; }

        // event.category, = database, network, process ### don't know for now
        // event.kind = alert, event ### probably best not to use for now; otherwise map from LogLevel.. but then redundant
        // xxx event.module = Name of the module, e.g. apache
        // xxx event.provider = source of the event, e.g. kernel, Microsoft-Windows-Security-Auditing 
        // event.type = error, info ### probably best not to use for now; otherwise map from LogLevel.. but then redundant
    }
}
