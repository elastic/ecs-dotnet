using System;
using Elastic.Ingest.Apm.Model;
using Elastic.Transport;

namespace Elastic.Ingest.Apm
{
	public class ApmChannelOptions : ChannelOptionsBase<IIntakeObject, EventIntakeResponse, IntakeErrorItem, ApmBufferOptions>
	{
		public ApmChannelOptions() : base() {}

		public ApmChannelOptions(ITransport<ITransportConfiguration> transport) : base(transport) { }
	}


	public class ApmBufferOptions : BufferOptions<IIntakeObject, EventIntakeResponse, IntakeErrorItem>
	{
	}
}
