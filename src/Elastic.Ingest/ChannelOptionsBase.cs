using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Elastic.Ingest
{
	public abstract class ChannelOptionsBase<TEvent, TBuffer>
		where TBuffer : BufferOptions<TEvent>, new()
	{
		public Func<Stream, CancellationToken, TEvent, Task> WriteEvent { get; set; } = null!;

		public TBuffer BufferOptions { get; set; } = new TBuffer();

	}
	public abstract class ChannelOptionsBase<TEvent, TResponse, TResponseItem, TBuffer>
		: ChannelOptionsBase<TEvent, TBuffer>
		where TBuffer : BufferOptions<TEvent, TResponse, TResponseItem>, new()
	{

	}
}
