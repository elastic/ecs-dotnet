using System.Runtime.Serialization;

namespace Essential.LoggerProvider.Ecs
{
    public class Thread
    {
        public Thread(string name, int id)
        {
            Name = name;
            Id = id;
        }

        // process.thread.id
        [DataMember(Name = "id")] public int Id { get; }

        // process.thread.name
        [DataMember(Name = "name")] public string Name { get; }
    }
}
