// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.IO;
using System.Text;
using Serilog.Events;
using Serilog.Formatting;

namespace Elastic.CommonSchema.Serilog
{
	/// <summary>
	/// A serilog formatter that writes log events using the Elasticsearch Common Schema format
	/// </summary>
	public class EcsTextFormatter<TEcsDocument> : ITextFormatter
		where TEcsDocument : EcsDocument, new()
	{

		protected EcsTextFormatterConfiguration<TEcsDocument> Configuration { get; }

		public EcsTextFormatter() : this(new EcsTextFormatterConfiguration<TEcsDocument>()) { }

		public EcsTextFormatter(EcsTextFormatterConfiguration<TEcsDocument> configuration) =>
			Configuration = configuration ?? new EcsTextFormatterConfiguration<TEcsDocument>();

		public virtual void Format(LogEvent logEvent, TextWriter output)
		{
			var ecsEvent = LogEventConverter.ConvertToEcs<TEcsDocument>(logEvent, Configuration);
			output.WriteLine(ecsEvent.Serialize());
		}
	}

	public class EcsTextFormatter : EcsTextFormatter<EcsDocument>
	{
		public EcsTextFormatter() : base() {}
		public EcsTextFormatter(EcsTextFormatterConfiguration<EcsDocument> configuration) : base(configuration) {}
		public EcsTextFormatter(EcsTextFormatterConfiguration configuration) : base(configuration) {}
	}
}
