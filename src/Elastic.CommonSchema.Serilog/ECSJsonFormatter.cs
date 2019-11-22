using System.IO;
using System.Text;
using Serilog.Events;
using Serilog.Formatting;
using Utf8Json.Resolvers;

namespace Elastic.CommonSchema.Serilog
{
    /// <summary>
    /// Writes the log event using Elasticsearch Common Schema JSON format
    /// </summary>
    public class ECSJsonFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            var ecsEvent = LogEventConverter.ConvertToEcs(logEvent);
            var bytes = Utf8Json.JsonSerializer.Serialize(ecsEvent, StandardResolver.ExcludeNull);
            var format = Encoding.UTF8.GetString(bytes);
            output.Write(format);
        }
    }
}