using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class Host
    {
        public Host(string hostname, string architecture, OperatingSystem operatingSystem)
        {
            Hostname = hostname;
            Architecture = architecture;
            OperatingSystem = operatingSystem;
        }

        // host.architecture 
        [DataMember(Name = "architecture")] public string Architecture { get; private set; }

        // host.hostname 
        [DataMember(Name = "hostname")] public string Hostname { get; }

        // The os fields are expected to be nested at: host.os, observer.os, user_agent.os.
        // Note also that the os fields are not expected to be used directly at the top level.
        [DataMember(Name = "os")] public OperatingSystem OperatingSystem { get; }

        // host.domain, host.ip, 
    }
}
