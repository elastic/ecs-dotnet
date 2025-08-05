using System.Text.Json.Serialization;

namespace Elastic.Extensions.Logging.Common;

/// <summary>
///
/// </summary>
[JsonSerializable(typeof(LogEvent))]
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class LogEventJsonContext : JsonSerializerContext { }
