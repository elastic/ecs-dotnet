using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class LogEvent
    {
        // ecs.version
        [DataMember(Name = "ecs")]
        public Ecs Ecs { get; set;  } = new Ecs();
        
        [DataMember(Name = "@timestamp")]
        public DateTimeOffset Timestamp { get; set; }
        
        [DataMember(Name = "message")]
        public string Message { get; set; } = string.Empty;

        [DataMember(Name = "tags")]
        public IList<string> Tags { get; set; } = new List<string>();
        
        // labels = Custom key/value pairs. Can be used to add meta information to events. Should not contain nested objects.
        // example: {'application': 'foo-bar', 'env': 'production'}
        [DataMember(Name = "labels")]
        public IDictionary<string, string> Labels { get; set; } = new Dictionary<string, string>();

        // agent.type = "Essential.LoggerProvider.Elasticsearch", agent.version
        [DataMember(Name = "agent")] 
        public Agent Agent { get; set; } = default!;

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

        // event.action, = example: user-password-change   ** EventId.Name **
        // event.category, = database, network, process ### don't know for now
        // event.code, = example of this is the Windows Event ID. ** EventId.Id **
        // event.kind = alert, event ### probably best not to use for now; otherwise map from LogLevel.. but then redundant
        // xxx event.module = Name of the module, e.g. apache
        // xxx event.provider = source of the event, e.g. kernel, Microsoft-Windows-Security-Auditing 
        // event.severity = numeric => from LogLevel
        // event.type = error, info ### probably best not to use for now; otherwise map from LogLevel.. but then redundant

        // Syslog severity belongs in log.syslog.severity.code. event.severity

        // At least hostname
        // host.architecture, host.domain, host.hostname, host.ip, 

        // log.level = Some examples are warn, err, i, informational ** LogLevel **
        // log.logger = example: org.elasticsearch.bootstrap.Bootstrap ** CategoryName **
        // log.syslog = The Syslog metadata of the event
        // log.syslog.facility.code
        // log.syslog.priority
        // log.syslog.severity.code => from LogLevel
        // log.syslog.severity.name
        
        [DataMember(Name = "log")] 
        public Log Log { get; set; } = default!;

        // Some of these
        // os.family OS family (such as redhat, debian, freebsd, windows).
        // os.full, os.kernel, os.name, os.platform, os.version

        // Some of these
        // process.args Array of process arguments, starting with the absolute path to the executable. example: ['/usr/bin/ssh', '-l', 'user', '10.0.0.16']
        // process.name Sometimes called program name or similar.
        // process.pid process id
        // process.thread.id
        // process.thread.name
        // process.title

        // maybe inject from config?
        // service.name
        // service.type
        // service.version

        // Should add correlation at some point... maybe stick activity id here for now
        // trace.id = A trace groups multiple events like transactions that belong together. For example, a user request handled by multiple inter-connected services.
        // transaction.id = A transaction is the highest level of work measured within a service, such as a request to a server.

        // System info
        // user.domain
        // user.name

        // extract out url.*, http.* fields (instead of labels)

        // also, a standard way to pass in things like event.category, event.type, event.outcome ... maybe look for scope fields or param values with matching names.

    }
}


