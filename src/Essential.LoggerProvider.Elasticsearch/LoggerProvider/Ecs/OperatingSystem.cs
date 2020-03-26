using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class OperatingSystem
    {
        public OperatingSystem(string full, string platform, string version)
        {
            Full = full;
            Platform = platform;
            Version = version;
        }

        // os.full,
        [DataMember(Name = "full")] public string Full { get; }

        // os.platform,
        [DataMember(Name = "platform")] public string Platform { get; }

        // os.version
        [DataMember(Name = "version")] public string Version { get; }

        // Some of these
        // os.family OS family (such as redhat, debian, freebsd, windows).
        // os.kernel,
        // os.name,
    }
}
