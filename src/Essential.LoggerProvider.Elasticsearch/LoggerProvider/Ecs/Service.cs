using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class Service
    {
        public Service(string type, string version)
        {
            Type = type;
            Version = version;
        }

        // service.type
        [DataMember(Name = "type")] public string Type { get; }

        // service.version
        [DataMember(Name = "version")] public string Version { get; }
        
        // maybe inject from config?
        // service.name
    }
}
