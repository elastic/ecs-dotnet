using System.Text.Json.Serialization;
using Elastic.CommonSchema.NLog;

/// <summary>
///
/// </summary>
[JsonSerializable(typeof(EcsLayout.NLogEcsDocument))]
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class NLogEcsJsonContext : JsonSerializerContext { }
