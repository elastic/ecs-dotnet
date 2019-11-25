using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Serilog.Events;
using Serilog.Formatting;
using Utf8Json.Resolvers;

namespace Elastic.CommonSchema.Serilog
{
#if DOTNETCORE
#endif
    
    public interface IECSJsonFormatterDescriptor
    {
        bool MapHttpContext { get; set; }
        bool MapExceptions { get; set; }
        bool MapCurrentThread { get; set; }
        bool MapCurrentUser { get; set; }
    }

    public class ECSJsonFormatterDescriptor : IECSJsonFormatterDescriptor
    {
        bool IECSJsonFormatterDescriptor.MapHttpContext { get; set; } = true;
        bool IECSJsonFormatterDescriptor.MapExceptions { get; set; } = true;
        bool IECSJsonFormatterDescriptor.MapCurrentThread { get; set; } = true;
        bool IECSJsonFormatterDescriptor.MapCurrentUser { get; set; } = true;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ECSJsonFormatterDescriptor Assign<TValue>(
            ECSJsonFormatterDescriptor self, TValue value, Action<IECSJsonFormatterDescriptor, TValue> assign)
        {
            assign(self, value);
            return self;
        }

        public ECSJsonFormatterDescriptor MapHttpContext(bool value) => Assign(this, value, (o, v) => o.MapHttpContext = v);
        public ECSJsonFormatterDescriptor MapExceptions(bool value) => Assign(this, value, (o, v) => o.MapExceptions = v);
        public ECSJsonFormatterDescriptor MapCurrentThread(bool value) => Assign(this, value, (o, v) => o.MapCurrentThread = v);
        public ECSJsonFormatterDescriptor MapCurrentUser(bool value) => Assign(this, value, (o, v) => o.MapCurrentUser = v);
    }
    
    /// <summary>
    /// Writes the log event using Elasticsearch Common Schema JSON format
    /// </summary>
    public class ECSJsonFormatter : ITextFormatter
    {
        private readonly ECSJsonFormatterDescriptor _descriptor;

        public ECSJsonFormatter()
        {
            _descriptor = new ECSJsonFormatterDescriptor();
        }

        public ECSJsonFormatter(ECSJsonFormatterDescriptor descriptor)
        {
            _descriptor = descriptor ?? new ECSJsonFormatterDescriptor();
        }
        
        public void Format(LogEvent logEvent, TextWriter output)
        {
            var ecsEvent = LogEventConverter.ConvertToEcs(logEvent, _descriptor);
            var bytes = Utf8Json.JsonSerializer.Serialize(ecsEvent, StandardResolver.ExcludeNull);
            var format = Encoding.UTF8.GetString(bytes);
            output.Write(format);
        }
    }
}