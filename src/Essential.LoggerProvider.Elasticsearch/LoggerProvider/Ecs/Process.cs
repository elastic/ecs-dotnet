using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class Process
    {
        // Some of these
        // process.args Array of process arguments, starting with the absolute path to the executable. example: ['/usr/bin/ssh', '-l', 'user', '10.0.0.16']
        // process.name Sometimes called program name or similar.
        // process.pid process id
        // process.thread.id
        // process.thread.name
        // process.title

        public Process(string name, long processId, Thread thread)
        {
            Name = name;
            ProcessId = processId;
            Thread = thread;
        }

        [DataMember(Name = "name")] public string Name { get; }

        [DataMember(Name = "pid")] public long ProcessId { get; }

        [DataMember(Name = "thread")] public Thread Thread { get; }
    }
}
