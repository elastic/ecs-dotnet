using System.IO;
using System.Text;
using Serilog.Events;
using Serilog.Formatting;

namespace Elastic.CommonSchema.Serilog
{
    /// <summary>
    /// A serilog formatter that writes log events using the Elasticsearch Common Schema format
    /// </summary>
    public class EcsTextFormatter : ITextFormatter
    {
        private readonly ECSJsonFormatterConfiguration _configuration;

        public EcsTextFormatter() : this(new ECSJsonFormatterConfiguration()) { }

        public EcsTextFormatter(ECSJsonFormatterConfiguration configuration)
        {
            _configuration = configuration ?? new ECSJsonFormatterConfiguration();
        }
        
        public void Format(LogEvent logEvent, TextWriter output)
        {
            var ecsEvent = LogEventConverter.ConvertToEcs(logEvent, _configuration);
            var bytes = ecsEvent.Serialize();
            output.Write(Encoding.UTF8.GetString(bytes));
        }
    }
}
