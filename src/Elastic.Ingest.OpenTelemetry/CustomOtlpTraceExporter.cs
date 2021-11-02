using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;

namespace Elastic.Ingest.OpenTelemetry
{
	public class CustomOtlpTraceExporter : OtlpTraceExporter
	{
		public CustomOtlpTraceExporter(OtlpExporterOptions options, TraceChannelOptions channelOptions) : base(options)
		{
			var type = GetType();
			var attrbutes = new[] { new KeyValuePair<string, object>("telemetry.sdk.language", "dotnet") };
			var resource = ResourceBuilder.CreateDefault();
				if (!string.IsNullOrWhiteSpace(channelOptions.ServiceName))
					resource.AddService(channelOptions.ServiceName);

			var buildResource = resource.AddAttributes(attrbutes).Build();
			// hack but there is no other way to set a resource without spinning up the world
			// through SDK.
			// internal void SetResource(Resource resource)
			var prop = type.BaseType?.GetMethod("SetResource", BindingFlags.Instance | BindingFlags.NonPublic);
			prop?.Invoke(this, new object?[]{ buildResource });
		}
	}


	public class TraceBufferOptions : BufferOptions<Activity>
	{
	}

	public class TraceChannelOptions : ChannelOptionsBase<Activity, TraceBufferOptions, TraceExportResult>
	{
		public string? ServiceName { get; set; }
		public Uri? Endpoint { get; set; }
		public string? SecretToken { get; set; }
	}

	public class TraceExportResult
	{
		public ExportResult Result { get; internal set; }
	}

	public class TraceChannel : ChannelBase<TraceChannelOptions, TraceBufferOptions, Activity, TraceExportResult>
	{
		public TraceChannel(TraceChannelOptions options) : base(options) {
			var o = new OtlpExporterOptions();
			o.Endpoint = options.Endpoint;
            o.Headers = $"Authorization=Bearer {options.SecretToken}";
            TraceExporter = new CustomOtlpTraceExporter(o, options);
            Processor = new CustomActivityProcessor(TraceExporter,
				maxExportBatchSize: options.BufferOptions.MaxConsumerBufferSize,
				maxQueueSize: options.BufferOptions.MaxInFlightMessages,
				scheduledDelayMilliseconds: (int)options.BufferOptions.MaxConsumerBufferLifetime.TotalMilliseconds,
				exporterTimeoutMilliseconds: (int)options.BufferOptions.MaxConsumerBufferLifetime.TotalMilliseconds
			);
			var bufferType = typeof(BaseExporter<>).Assembly.GetTypes().First(t=>t.Name == "CircularBuffer`1");
			var activityBuffer = bufferType.GetGenericTypeDefinition().MakeGenericType(typeof(Activity));
			var bufferTypeConstructor = activityBuffer.GetConstructors().First();
			var bufferAddMethod = bufferType.GetMethod("Add");

			var batchType = typeof(Batch<Activity>);
			var batchConstructor = batchType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).First(c=>c.GetParameters().Length == 2);

			BatchCreator = (page) =>
			{
				var buffer = bufferTypeConstructor.Invoke(new object[] {options.BufferOptions.MaxConsumerBufferSize });
				bufferAddMethod.Invoke(buffer, new[] { page });
				var batch = (Batch<Activity>)batchConstructor.Invoke(new object[] {buffer, options.BufferOptions.MaxConsumerBufferSize });
				return batch;
			};

		}

		private Func<IReadOnlyCollection<Activity>, Batch<Activity>> BatchCreator { get; }

		public CustomOtlpTraceExporter TraceExporter { get; }

		public CustomActivityProcessor Processor { get; }

		protected override Task<TraceExportResult> Send(IReadOnlyCollection<Activity> page)
		{
			var batch = BatchCreator(page);
			var result = TraceExporter.Export(batch);
			return Task.FromResult(new TraceExportResult { Result = result });
		}

		public override void Dispose()
		{
			base.Dispose();
			Processor.Dispose();
		}

	}
}
