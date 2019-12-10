using Serilog.Core;
using Serilog.Events;

namespace Elastic.Apm.SerilogEnricher
{
	/// <summary>
	/// This enricher adds trace id and the transaction id for every log that is created during a transaction in case
	/// the Elastic APM Agent is active in your application.
	/// </summary>
	public sealed class ElasticApmEnricher : ILogEventEnricher
	{
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			if (!Agent.IsConfigured) return;
			if (Agent.Tracer.CurrentTransaction == null) return;

			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
				"ElasticApmTransactionId", Agent.Tracer.CurrentTransaction.Id));
			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
				"ElasticApmTraceId", Agent.Tracer.CurrentTransaction.TraceId));
		}
	}
}
