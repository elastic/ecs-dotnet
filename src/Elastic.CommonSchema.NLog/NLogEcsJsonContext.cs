using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.NLog;

/// <summary>
///
/// </summary>
[JsonSerializable(typeof(NLogEcsDocument))]
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class NLogEcsJsonContext : JsonSerializerContext;
