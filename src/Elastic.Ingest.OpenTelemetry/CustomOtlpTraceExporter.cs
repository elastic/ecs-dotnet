using System.Collections.Generic;
using System.Reflection;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;

namespace Elastic.Ingest.OpenTelemetry
{
	public class CustomOtlpTraceExporter : OtlpTraceExporter
	{
		public CustomOtlpTraceExporter(OtlpExporterOptions options) : base(options)
		{
			var type = GetType();
			var attrbutes = new[] { new KeyValuePair<string, object>("telemetry.sdk.language", "dotnet") };
			var resource = ResourceBuilder.CreateDefault().AddService("hello-world").AddAttributes(attrbutes).Build();

			// hack but there is no other way to set a resource without spinning up the world
			// through SDK.
			// internal void SetResource(Resource resource)
			var prop = type.BaseType?.GetMethod("SetResource", BindingFlags.Instance | BindingFlags.NonPublic);
			prop?.Invoke(this, new object?[]{ resource });
		}
	}
}
