using Elastic.CommonSchema.Serialization;
using Utf8Json;
using Utf8Json.Resolvers;

namespace Elastic.CommonSchema
{
    [JsonFormatter(typeof(BaseJsonFormatter))]
    public partial class Base
    {
        public byte[] Serialize()
        {
            return Utf8Json.JsonSerializer.Serialize(this, StandardResolver.ExcludeNull);
        }
    }
}