using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Elastic.Ingest
{
	/// <summary>
	/// Information about the consumers local buffer, available to users in <see cref="BufferOptions{TEvent,TResponse,TBulkResponseItem}.ResponseCallback" />
	/// </summary>
	public interface IConsumedBufferStatistics
	{
		int Count { get; }
		TimeSpan? DurationSinceFirstRead { get; }
	}

	public class ConsumedBuffer<TEVent> : IConsumedBufferStatistics
	{
		private readonly TEVent[] _buffer;
		public IReadOnlyCollection<TEVent> Items { get; }

		public ConsumedBuffer(ChannelBuffer<TEVent> buffer)
		{
			_buffer = new TEVent[buffer.Count];
			buffer.Buffer.CopyTo(_buffer);
			Count = buffer.Count;
			DurationSinceFirstRead = buffer.DurationSinceFirstRead;
			Items = new ReadOnlyCollection<TEVent>(_buffer);
			buffer.Reset();
		}

		public int Count { get; }
		public TimeSpan? DurationSinceFirstRead { get; }
	}

	/// <summary>
	/// Acts as a wrapper around the consumers buffer of messages. We want the buffer to flush
	/// every N messages OR in the case messages do no flow fast enough or stop before N messages were received every
	/// M timespan.
	/// </summary>
	public class ChannelBuffer<TEvent> : IConsumedBufferStatistics, IDisposable
	{
		private readonly int _maxBufferSize;
		private CancellationTokenSource _breaker = new CancellationTokenSource();

		public TimeSpan ForceFlushAfter { get; }
		public List<TEvent> Buffer { get; }

		/// <summary>The time that the first event is read from the channel and added to the buffer, from first read or after the buffer is reset.</summary>
		private DateTimeOffset? TimeOfFirstRead { get; set; }

		public int Count => Buffer.Count;
		public TimeSpan? DurationSinceFirstRead => DateTimeOffset.UtcNow - TimeOfFirstRead;
		public bool NoThresholdsHit => Count == 0 || (Count < _maxBufferSize && DurationSinceFirstRead <= ForceFlushAfter);

		public ChannelBuffer(int maxBufferSize, TimeSpan forceFlushAfter)
		{
			_maxBufferSize = maxBufferSize;
			ForceFlushAfter = forceFlushAfter;
			Buffer = new List<TEvent>(maxBufferSize);
			TimeOfFirstRead = null;
		}

		public void Add(TEvent item)
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

		/// <summary>
		/// Call <see cref="ChannelReader{T}.WaitToReadAsync"/> with a timeout to force a flush to happen every
		/// <see cref="ForceFlushAfter"/>. This tries to avoid allocation too many <see cref="CancellationTokenSource"/>'s
		/// needlessly and reuses them if possible. If we know the buffer is empty we can wait indefinitely as well.
		/// </summary>
		public async Task<bool> WaitToReadAsync(ChannelReader<TEvent> reader)
		{
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
