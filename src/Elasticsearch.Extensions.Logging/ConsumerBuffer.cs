using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Elasticsearch.Extensions.Logging
{
	/// <summary>
	/// Information about the consumers local buffer, available to users in <see cref="DrainThrottles.ElasticsearchResponseCallback" />
	/// </summary>
	public interface IConsumerBuffer
	{
		int Count { get; }
		TimeSpan? DurationSinceFirstRead { get; }
	}

	/// <summary>
	/// Acts as a wrapper around the consumers buffer of messages. We want the buffer to flush
	/// every N messages OR in the case messages do no flow fast enough or stop before N messages were received every
	/// M timespan.
	/// </summary>
	internal class ConsumerBuffer : IConsumerBuffer, IDisposable
	{
		private readonly int _maxBufferSize;

		public TimeSpan ForceFlushAfter { get; }
		public List<LogEvent> Buffer { get; }
		private DateTimeOffset? TimeOfFirstRead { get; set; }

		public int Count => Buffer.Count;
		public TimeSpan? DurationSinceFirstRead => DateTimeOffset.UtcNow - TimeOfFirstRead;
		public bool NoThresholdsHit => Count == 0 || (Count < _maxBufferSize && DurationSinceFirstRead <= ForceFlushAfter);

		public ConsumerBuffer(int maxBufferSize, TimeSpan forceFlushAfter)
		{
			_maxBufferSize = maxBufferSize;
			ForceFlushAfter = forceFlushAfter;
			Buffer = new List<LogEvent>(maxBufferSize);
			TimeOfFirstRead = null;
		}

		public void Add(LogEvent item)
		{
			TimeOfFirstRead ??= DateTimeOffset.UtcNow;
			Buffer.Add(item);
		}

		public void Reset()
		{
			Buffer.Clear();
			TimeOfFirstRead = null;
		}

		private TimeSpan Wait
		{
			get
			{
				if (!DurationSinceFirstRead.HasValue) return ForceFlushAfter;
				var d = DurationSinceFirstRead.Value;
				return d < ForceFlushAfter ? ForceFlushAfter - d : ForceFlushAfter;
			}
		}

		private CancellationTokenSource _breaker = new CancellationTokenSource();


		/// <summary>
		/// Call <see cref="ChannelReader{T}.WaitToReadAsync"/> with a timeout to force a flush to happen every
		/// <see cref="ForceFlushAfter"/>. This tries to avoid allocation too many <see cref="CancellationTokenSource"/>'s
		/// needlessly and reuses them if possible. If we know the buffer is empty we can wait indefinitely as well.
		/// </summary>
		public async Task<bool> WaitToReadAsync(ChannelReader<LogEvent> reader)
		{
			//if we have nothing in the buffer wait indefinitely for messages
			if (_breaker.IsCancellationRequested)
			{
				_breaker.Dispose();
				_breaker = new CancellationTokenSource();
			}

			try
			{
				//if we have nothing in the buffer wait indefinitely for messages
				var w = Count == 0 ? TimeSpan.FromMilliseconds(-1) : Wait;
				_breaker.CancelAfter(w);
				var _ = await reader.WaitToReadAsync(_breaker.Token).ConfigureAwait(false);
				_breaker.CancelAfter(ForceFlushAfter);
				return true;
			}
			catch (Exception) when (_breaker.IsCancellationRequested)
			{
				_breaker.Dispose();
				_breaker = new CancellationTokenSource();
				return true;
			}
			catch (Exception)
			{
				_breaker.CancelAfter(ForceFlushAfter);
				return true;
			}
		}

		public void Dispose() => _breaker.Dispose();
	}
}
