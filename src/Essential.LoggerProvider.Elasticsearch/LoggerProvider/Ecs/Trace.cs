using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class Trace
    {
        public Trace(string id)
        {
            Id = id;
        }

        [DataMember(Name = "id")] public string Id { get; }

        // Should add correlation at some point... maybe stick activity id here for now
        // trace.id = A trace groups multiple events like transactions that belong together. For example, a user request handled by multiple inter-connected services.
        // transaction.id = A transaction is the highest level of work measured within a service, such as a request to a server.
    }
}
