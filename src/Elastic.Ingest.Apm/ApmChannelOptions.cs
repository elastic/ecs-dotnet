using System;
using Elastic.Ingest.Apm.Model;
using Elastic.Transport;

namespace Elastic.Ingest.Apm
{
	public class ApmChannelOptions : ChannelOptionsBase<IIntakeObject, EventIntakeResponse, IntakeErrorItem, ApmBufferOptions>
	{
		public ApmChannelOptions() : base() {}

		public ApmChannelOptions(ITransport<ITransportConfigurationValues> transport) : base(transport) { }

		//TODO index patters are more complex then this, ILM, write alias, buffer tier, datastreams
		/// <summary>
		/// Gets or sets the format string for the Elastic search index. The current <c>DateTimeOffset</c> is passed as parameter
		/// 0.
		/// </summary>
		public string Index { get; set; } = "dotnet-{0:yyyy.MM.dd}";

		/// <summary>
		/// Gets or sets the offset to use for the index <c>DateTimeOffset</c>. Default value is null, which uses the system local
		/// offset. Use "00:00" for UTC.
		/// </summary>
		public TimeSpan? IndexOffset { get; set; }

		public Func<IIntakeObject, DateTimeOffset?> TimestampLookup { get; set; } = null!;

	}


	public class ApmBufferOptions : BufferOptions<IIntakeObject, EventIntakeResponse, IntakeErrorItem> { }
}
