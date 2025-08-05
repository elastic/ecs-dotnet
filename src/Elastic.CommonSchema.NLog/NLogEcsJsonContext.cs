using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.NLog;

/// <summary>
///
/// </summary>
[JsonSerializable(typeof(EcsLayout.NLogEcsDocument))]
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class NLogEcsJsonContext : JsonSerializerContext { }
