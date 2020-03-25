using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class Ecs
    {
        // ecs.version
        [DataMember(Name = "version")]
        public string Version { get; set;  } = "1.5";
    }
}
