using Elastic.CommonSchema.Serialization;
using Utf8Json;
using Utf8Json.Resolvers;

namespace Elastic.CommonSchema
{
    [JsonFormatter(typeof(LogJsonFormatter))]
    public partial class Log
    {
        public byte[] Serialize()
        {
            return Utf8Json.JsonSerializer.Serialize(this, StandardResolver.ExcludeNull);
        }
    }
}