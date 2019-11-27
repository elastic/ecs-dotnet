using System.IO;
using System.Text;
using Serilog.Events;
using Serilog.Formatting;
using Utf8Json.Resolvers;

namespace Elastic.CommonSchema.Serilog
{
    /// <summary>
    /// A serilog formatter that writes log events using the Elasticsearch Common Schema format
    /// </summary>
    public class ECSJsonFormatter : ITextFormatter
    {
        private readonly ECSJsonFormatterConfiguration _configuration;

        public ECSJsonFormatter()
        {
            _configuration = new ECSJsonFormatterConfiguration();
        }

        public ECSJsonFormatter(ECSJsonFormatterConfiguration configuration)
        {
            _configuration = configuration ?? new ECSJsonFormatterConfiguration();
        }
        
        public void Format(LogEvent logEvent, TextWriter output)
        {
            var ecsEvent = LogEventConverter.ConvertToEcs(logEvent, _configuration);
            var bytes = Utf8Json.JsonSerializer.Serialize(ecsEvent, StandardResolver.ExcludeNull);
            var format = Encoding.UTF8.GetString(bytes);
            output.Write(format);
        }
    }
}