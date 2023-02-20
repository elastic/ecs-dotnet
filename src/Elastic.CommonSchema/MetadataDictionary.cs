using System.Collections.Generic;
using System.Text.Json.Serialization;
using Elastic.CommonSchema.Serialization;

namespace Elastic.CommonSchema;

/// <summary>
/// A regular <see cref="Dictionary{TKey,TValue}"/> implementation that takes special care to not fail on (de)serialization
/// and preserving the failures
/// </summary>
[JsonConverter(typeof(MetadataDictionaryConverter))]
public class MetadataDictionary : Dictionary<string, object>
{

}
