// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.IO;
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

		/// <inheritdoc cref="EcsTextFormatterConfiguration{TEcsDocument}"/>
		protected EcsTextFormatterConfiguration<TEcsDocument> Configuration { get; }

		/// <inheritdoc cref="EcsTextFormatter{TEcsDocument}"/>
		public EcsTextFormatter() : this(new EcsTextFormatterConfiguration<TEcsDocument>()) { }

		/// <inheritdoc cref="EcsTextFormatter{TEcsDocument}"/>
		public EcsTextFormatter(EcsTextFormatterConfiguration<TEcsDocument> configuration) =>
			Configuration = configuration ?? new EcsTextFormatterConfiguration<TEcsDocument>();

		/// <inheritdoc cref="ITextFormatter.Format"/>
		public virtual void Format(LogEvent logEvent, TextWriter output)
		{
			var ecsEvent = LogEventConverter.ConvertToEcs(logEvent, Configuration);
			output.WriteLine(ecsEvent.Serialize());
		}
	}

	// ReSharper disable once UnusedType.Global
	/// <inheritdoc cref="EcsTextFormatter{TEcsDocument}"/>
	public class EcsTextFormatter : EcsTextFormatter<EcsDocument>
	{
		/// <inheritdoc cref="EcsTextFormatter{TEcsDocument}"/>
		public EcsTextFormatter() {}
		/// <inheritdoc cref="EcsTextFormatter{TEcsDocument}"/>
		public EcsTextFormatter(EcsTextFormatterConfiguration<EcsDocument> configuration) : base(configuration) {}
		/// <inheritdoc cref="EcsTextFormatter{TEcsDocument}"/>
		public EcsTextFormatter(EcsTextFormatterConfiguration configuration) : base(configuration) {}
	}
}
