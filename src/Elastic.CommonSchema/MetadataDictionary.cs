using System.Collections.Generic;
using System.Text.Json.Serialization;
using Elastic.CommonSchema.Serialization;

namespace Elastic.CommonSchema;

[JsonConverter(typeof(MetadataDictionaryConverter))]
public class MetadataDictionary : Dictionary<string, object>
{
	public static readonly MetadataDictionary Default = new();

}
