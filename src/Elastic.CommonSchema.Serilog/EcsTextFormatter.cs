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
	public class EcsTextFormatter : ITextFormatter
	{
		private readonly EcsTextFormatterConfiguration _configuration;

		public EcsTextFormatter() : this(new EcsTextFormatterConfiguration()) { }

		public EcsTextFormatter(EcsTextFormatterConfiguration configuration) =>
			_configuration = configuration ?? new EcsTextFormatterConfiguration();

		public virtual void Format(LogEvent logEvent, TextWriter output)
		{
			var ecsEvent = LogEventConverter.ConvertToEcs(logEvent, _configuration);
			if (output is StreamWriter sw)
				ecsEvent.Serialize(sw.BaseStream);
			else
			{
				var bytes = ecsEvent.SerializeToUtf8Bytes();
				output.Write(Encoding.UTF8.GetString(bytes));
			}
		}
	}

}
