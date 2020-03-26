using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class ElasticsearchData
    {
        // agent.type = "Essential.LoggerProvider.Elasticsearch", agent.version
        [DataMember(Name = "agent")] public Agent? Agent { get; set; } = default;

        // ecs.version
        [DataMember(Name = "ecs")] public Ecs Ecs { get; set; } = new Ecs();

        [DataMember(Name = "event")] public Event? Event { get; set; }

        [DataMember(Name = "host")] public Host? Host { get; set; }

        // labels = Custom key/value pairs. Can be used to add meta information to events. Should not contain nested objects.
        // example: {'application': 'foo-bar', 'env': 'production'}
        [DataMember(Name = "labels")] public IDictionary<string, string>? Labels { get; set; }

        [DataMember(Name = "log")] public Log? Log { get; set; }

        [DataMember(Name = "message")] public string Message { get; set; } = string.Empty;

        [DataMember(Name = "process")] public Process? Process { get; set; }

        [DataMember(Name = "service")] public Service? Service { get; set; }

        //[DataMember(Name = "tags")] public IList<string>? Tags { get; set; }

        [DataMember(Name = "@timestamp")] public DateTimeOffset Timestamp { get; set; }

        [DataMember(Name = "trace")] public Trace? Trace { get; set; }

        [DataMember(Name = "user")] public User? User { get; set; }

        // If there is an exception
        // error.code, error.id, error.message, error.stack_trace, error.type

        // Example in ECS custom fields seems to indicate event is a sub-object in the JSON
        // { "labels": { "foo_id": "beef42", "env": "production" },
        //   "message": "...",
        //   "event": { ... }
        // }
        // Another example, which the nested JSON matches the "." path in HTTP fields
        // { "http": { "request": { "method": "get", ... },
        //         "response": { "status_code": 200, ... } },
        //     "url": { "original": "/favicon.ico", ... },
        //     "haproxy": { "frontend_name": "myfrontend", "backend_name": "mybackend_prod",
        //         "backend_queue": 0, ... }
        // }

        // transaction.id = A transaction is the highest level of work measured within a service, such as a request to a server.

        // extract out url.*, http.* fields (instead of labels)

        // also, a standard way to pass in things like event.category, event.type, event.outcome ... maybe look for scope fields or param values with matching names.
    }
}
