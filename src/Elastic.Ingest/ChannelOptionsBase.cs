using System;
using System.Collections.Generic;
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

		/// <summary>
		/// If <see cref="MaxInFlightMessages"/> is reached, <see cref="TEvent"/>'s will fail to be published to the channel. You can be notified of dropped
		/// events with this callback
		/// </summary>
		public Action<TEvent>? PublishRejectionCallback { get; set; }

		public Action<Exception>? ExceptionCallback { get; set; }

		public Action<int, int>? BulkAttemptCallback { get; set; }

		/// <summary> Subscribe to be notified of events that are retryable but did not store correctly withing the boundaries of <see cref="MaxRetries"/></summary>
		public Action<IReadOnlyCollection<TEvent>>? MaxRetriesExceededCallback { get; set; }

		/// <summary> Subscribe to be notified of events that are retryable but did not store correctly within the number of configured <see cref="MaxRetries"/></summary>
		public Action<IReadOnlyCollection<TEvent>>? RetryCallBack { get; set; }


	}

	public abstract class ChannelOptionsBase<TEvent, TBuffer, TResponse>
		: ChannelOptionsBase<TEvent, TBuffer>
		where TBuffer : BufferOptions<TEvent>, new()
	{

		/// <summary> A generic hook to be notified of any bulk request being initiated by <see cref="ChannelBuffer{TEvent}"/> </summary>
		public Action<TResponse, IConsumedBufferStatistics> ResponseCallback { get; set; } = (r, b) => { };
	}

	public abstract class ChannelOptionsBase<TEvent, TBuffer, TResponse, TBulkResponseItem>
		: ChannelOptionsBase<TEvent, TBuffer, TResponse>
		where TBuffer : BufferOptions<TEvent>, new()
	{
		/// <summary> Subscribe to be notified of events that can not be stored in Elasticsearch</summary>
		public Action<List<(TEvent, TBulkResponseItem)>>? ServerRejectionCallback { get; set; }
	}
}
