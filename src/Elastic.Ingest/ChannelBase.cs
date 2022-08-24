// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Elastic.Ingest
{
	public interface IIngestChannel<in TEvent> : IDisposable
	{
		bool TryWrite(TEvent item);

		Task<bool> WaitToWriteAsync(TEvent item, CancellationToken ctx = default);

		async Task<bool> WaitToWriteManyAsync(IEnumerable<TEvent> events, CancellationToken ctx = default)
		{
			var allWritten = true;
			foreach (var e in events)
			{
				var written = await WaitToWriteAsync(e, ctx).ConfigureAwait(false);
				if (!written) allWritten = written;
			}
			return allWritten;
		}
	}

	public static class IngestChannelExtensions
	{
		public static bool TryWriteMany<TEvent>(this IIngestChannel<TEvent> channel, IEnumerable<TEvent> events) =>
			events.Select(e => channel.TryWrite(e)).All(b => b);

	}


	public abstract class ChannelBase<TChannelOptions, TBuffer, TEvent, TResponse>
		: IIngestChannel<TEvent>
		where TChannelOptions : ChannelOptionsBase<TEvent, TBuffer, TResponse>
		where TBuffer : BufferOptions<TEvent>, new()
		where TResponse : class, new()
	{
		private readonly Task _inThread;
		private readonly Task _outThread;
		private readonly SemaphoreSlim _throttleTasks;

		protected ChannelBase(TChannelOptions options)
		{
			Options = options;
			var maxConsumers = Math.Max(1, BufferOptions.ConcurrentConsumers);
			_throttleTasks = new SemaphoreSlim(maxConsumers, maxConsumers);
			InChannel = Channel.CreateBounded<TEvent>(new BoundedChannelOptions(BufferOptions.MaxInFlightMessages)
			{
				SingleReader = false,
				// Stephen Toub comment: https://github.com/dotnet/runtime/issues/26338#issuecomment-393720727
				// AFAICT this is fine since we run in a dedicated long running task.
				AllowSynchronousContinuations = true,
				// wait does not block it simply signals that Writer.TryWrite should return false and be retried
				// DropWrite will make `TryWrite` always return true, which is not what we want.
				FullMode = BoundedChannelFullMode.Wait
			});
			OutChannel = Channel.CreateBounded<ConsumedBuffer<TEvent>>(new BoundedChannelOptions(BufferOptions.MaxInFlightMessages / BufferOptions.MaxConsumerBufferSize)
			{
				SingleReader = false,
				SingleWriter = true,
				// Stephen Toub comment: https://github.com/dotnet/runtime/issues/26338#issuecomment-393720727
				// AFAICT this is fine since we run in a dedicated long running task.
				AllowSynchronousContinuations = true,
				// wait does not block it simply signals that Writer.TryWrite should return false and be retried
				// DropWrite will make `TryWrite` always return true, which is not what we want.
				FullMode = BoundedChannelFullMode.Wait
			});

			var waitHandle = BufferOptions.WaitHandle;
			_inThread = Task.Factory.StartNew(async () =>
					await ConsumeInboundEvents(BufferOptions.MaxConsumerBufferSize, BufferOptions.MaxConsumerBufferLifetime)
						.ConfigureAwait(false)
				, TaskCreationOptions.LongRunning
			);

			_outThread = Task.Factory.StartNew(async () =>
					await ConsumeOutboundEvents(waitHandle)
						.ConfigureAwait(false)
				, TaskCreationOptions.LongRunning
			);
		}

		public TChannelOptions Options { get; }
		protected Channel<ConsumedBuffer<TEvent>> OutChannel { get; }
		protected Channel<TEvent> InChannel { get; }
		protected TBuffer BufferOptions => Options.BufferOptions;

		public virtual bool TryWrite(TEvent item)
		{
			if (InChannel.Writer.TryWrite(item)) return true;

			Options.PublishRejectionCallback?.Invoke(item);
			return false;
		}

		public virtual async Task<bool> WaitToWriteAsync(TEvent item, CancellationToken ctx = default)
		{
			if ((await InChannel.Writer.WaitToWriteAsync(ctx).ConfigureAwait(false)) &&
				InChannel.Writer.TryWrite(item)) return true;

			Options.PublishRejectionCallback?.Invoke(item);
			return false;
		}

		protected abstract Task<TResponse> Send(IReadOnlyCollection<TEvent> page);

		private static IReadOnlyCollection<TEvent> _defaultRetryBuffer = new TEvent[] { };
		protected virtual IReadOnlyCollection<TEvent> RetryBuffer(TResponse response, IReadOnlyCollection<TEvent> currentBuffer,
			IConsumedBufferStatistics statistics
		) => _defaultRetryBuffer;

		private async Task ConsumeOutboundEvents(CountdownEvent? countdown)
		{
			var maxConsumers = Options.BufferOptions.ConcurrentConsumers;
			var taskList = new List<Task>(maxConsumers);

			while (await OutChannel.Reader.WaitToReadAsync().ConfigureAwait(false))
			{
				while (OutChannel.Reader.TryRead(out var buffer))
				{
					var items = buffer.Items;
					await _throttleTasks.WaitAsync().ConfigureAwait(false);
					var t = ExportBuffer(countdown, items, buffer);
					taskList.Add(t);

					if (taskList.Count >= maxConsumers)
					{
						var completedTask = await Task.WhenAny(taskList).ConfigureAwait(false);
						taskList.Remove(completedTask);
					}
					_throttleTasks.Release();
				}
			}
			await Task.WhenAll(taskList).ConfigureAwait(false);
		}

		private async Task ExportBuffer(CountdownEvent? countdown, IReadOnlyCollection<TEvent> items, IConsumedBufferStatistics buffer)
		{
			var maxRetries = Options.BufferOptions.MaxRetries;
			for (var i = 0; i <= maxRetries && items.Count > 0; i++)
			{
				Options.BulkAttemptCallback?.Invoke(i, items.Count);
				TResponse response = null!;
				try
				{
					response = await Send(items).ConfigureAwait(false);
					Options.ResponseCallback(response, buffer);
				}
				catch (Exception e)
				{
					Options.ExceptionCallback?.Invoke(e);
					break;
				}

				items = RetryBuffer(response, items, buffer);

				// delay if we still have items and we are not at the end of the max retry cycle
				var atEndOfRetries = i == maxRetries;
				if (items.Count > 0 && !atEndOfRetries)
				{
					await Task.Delay(Options.BufferOptions.BackoffPeriod(i)).ConfigureAwait(false);
					Options.RetryCallBack?.Invoke(items);
				}
				// otherwise if retryable items still exist and the user wants to be notified notify the user
				else if (items.Count > 0 && atEndOfRetries)
					Options.MaxRetriesExceededCallback?.Invoke(items);
			}
			Options.BufferOptions.BufferFlushCallback?.Invoke();
			countdown?.Signal();
		}

		private async Task ConsumeInboundEvents(int maxQueuedMessages, TimeSpan maxInterval)
		{
			using var buffer = new ChannelBuffer<TEvent>(maxQueuedMessages, maxInterval);

			while (await buffer.WaitToReadAsync(InChannel.Reader).ConfigureAwait(false))
			{
				while (buffer.Count < maxQueuedMessages && InChannel.Reader.TryRead(out var item))
				{
					if (buffer.DurationSinceFirstRead > maxInterval) break;

					buffer.Add(item);
				}

				if (buffer.NoThresholdsHit) continue;

				var localBuffer = new ConsumedBuffer<TEvent>(buffer);
				if (OutChannel.Writer.TryWrite(localBuffer))
					continue;

				foreach (var e in buffer.Buffer)
					Options.PublishRejectionCallback?.Invoke(e);
			}
		}

		public virtual void Dispose()
		{
			try
			{
				_inThread.Dispose();
			}
			catch { }
			try
			{
				_outThread.Dispose();
			}
			catch { }
		}
	}

	public abstract class ChannelBase<TChannelOptions, TBuffer, TEvent, TResponse, TBulkResponseItem>
		: ChannelBase<TChannelOptions, TBuffer, TEvent, TResponse>
		where TChannelOptions : ChannelOptionsBase<TEvent, TBuffer, TResponse, TBulkResponseItem>
		where TBuffer : BufferOptions<TEvent>, new()
		where TResponse : class, new()
	{
		protected ChannelBase(TChannelOptions options) : base(options) { }

		protected abstract bool Retry(TResponse response);

		protected abstract bool RetryAllItems(TResponse response);

		protected abstract List<(TEvent, TBulkResponseItem)> Zip(TResponse response, IReadOnlyCollection<TEvent> page);

		protected abstract bool RetryEvent((TEvent, TBulkResponseItem) @event);

		protected abstract bool RejectEvent((TEvent, TBulkResponseItem) @event);

		protected override IReadOnlyCollection<TEvent> RetryBuffer(TResponse response, IReadOnlyCollection<TEvent> events,
			IConsumedBufferStatistics consumedBufferStatistics
		)
		{
			if (!Retry(response)) return Enumerable.Empty<TEvent>().ToList();

			var backOffWholeRequest = RetryAllItems(response);
			// if we are not retrying the whole request find out if individual items need retrying
			if (!backOffWholeRequest)
			{
				var zipped = Zip(response, events);
				events = zipped
					.Where(t => RetryEvent(t))
					.Select(t => t.Item1)
					.ToList();

				// report any events that are going to be dropped
				if (Options.ServerRejectionCallback != null)
				{
					var rejected = zipped
						.Where(t => RejectEvent(t) && !RetryEvent(t))
						.ToList();
					if (rejected.Count > 0) Options.ServerRejectionCallback(rejected);
				}
			}
			return events;
		}
	}
}
