using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class User
    {
        public User(string? id, string name, string domain)
        {
            Id = id;
            Name = name;
            Domain = domain;
        }

        [DataMember(Name = "domain")] public string Domain { get; }

        [DataMember(Name = "id")] public string? Id { get; }

        [DataMember(Name = "name")] public string Name { get; }
        // System info
        // user.domain
        // user.name
    }
}
