using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class Agent
    {
        // agent.type = "Essential.LoggerProvider.Elasticsearch", agent.version
        [DataMember(Name = "type")] 
        public string Type { get; set; } = "Essential.LoggerProvider.Elasticsearch";
        
        [DataMember(Name = "version")]
        public string Version { get; set; }
    }
}
