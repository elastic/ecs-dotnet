using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.Ingest.Tests
{
	public class BehaviorTests : IDisposable
	{
		public BehaviorTests(ITestOutputHelper testOutput) => XunitContext.Register(testOutput);
		void IDisposable.Dispose() => XunitContext.Flush();

		[Fact] public async Task RespectsPagination()
		{
			int totalEvents = 500_000, maxInFlight = totalEvents / 5, bufferSize = maxInFlight / 10;
			var expectedPages = totalEvents / bufferSize;
			var channelOptions = new NoopChannelOptions
			{
				BufferOptions = new NoopEventBufferOptions
				{
					WaitHandle = new CountdownEvent(expectedPages),
					MaxInFlightMessages = maxInFlight,
					MaxConsumerBufferSize = bufferSize,
				}
			};

			var channel = new NoopIngestChannel(channelOptions);

			var written = 0;
			for (var i = 0; i < totalEvents; i++)
			{
				if (await channel.WaitToWriteAsync(new NoopEvent()))
					written++;
			}
			channelOptions.BufferOptions.WaitHandle.Wait(TimeSpan.FromSeconds(5));
			written.Should().Be(totalEvents);
			channel.SeenPages.Should().Be(expectedPages);
		}

		/// <summary>
		/// If we are feeding data slowly e.g smaller than <see cref="BufferOptions{TEvent}.MaxConsumerBufferSize"/>
		/// we don't want this data equally distributed over multiple calls to export the data.
		/// Instead we want the smaller buffer to go out over a single export to the external system
		/// </summary>
		[Fact] public async Task MessagesAreSequentiallyDistributedOverWorkers()
		{
			int totalEvents = 500_000, maxInFlight = totalEvents / 5, bufferSize = maxInFlight / 10;
			var channelOptions = new NoopChannelOptions
			{
				BufferOptions = new NoopEventBufferOptions
				{
					WaitHandle = new CountdownEvent(1),
					MaxInFlightMessages = maxInFlight,
					MaxConsumerBufferSize = bufferSize,
					MaxConsumerBufferLifetime = TimeSpan.FromMilliseconds(500)
				}
			};

			var channel = new NoopIngestChannel(channelOptions);
			var written = 0;
			for (var i = 0; i < 100; i++)
			{
				if (await channel.WaitToWriteAsync(new NoopEvent()))
					written++;
			}
			channelOptions.BufferOptions.WaitHandle.Wait(TimeSpan.FromSeconds(1));
			written.Should().Be(100);
			channel.SeenPages.Should().Be(1);
		}

		[Fact] public async Task ConcurrencyIsApplied()
		{
			int totalEvents = 5_000, maxInFlight = 5_000, bufferSize = 500;
			var expectedPages = totalEvents / bufferSize;
			var channelOptions = new NoopChannelOptions
			{
				BufferOptions = new NoopEventBufferOptions
				{
					WaitHandle = new CountdownEvent(expectedPages),
					MaxInFlightMessages = maxInFlight,
					MaxConsumerBufferSize = bufferSize,
					ConcurrentConsumers = 4
				}
			};

			var channel = new DelayedNoopIngestChannel(channelOptions);

			var written = 0;
			for (var i = 0; i < totalEvents; i++)
			{
				if (await channel.WaitToWriteAsync(new NoopEvent()))
					written++;
			}
			channelOptions.BufferOptions.WaitHandle.Wait(TimeSpan.FromSeconds(5));
			written.Should().Be(totalEvents);
			channel.SeenPages.Should().Be(expectedPages);
			channel.MaxConcurrency.Should().Be(4);
		}

	}

	public class NoopEvent { }
	public class NoopResponse { }

	public class NoopEventBufferOptions : BufferOptions<NoopEvent> { }
	public class NoopChannelOptions : ChannelOptionsBase<NoopEvent, NoopEventBufferOptions, NoopResponse> {}

	public class NoopIngestChannel : ChannelBase<NoopChannelOptions, NoopEventBufferOptions, NoopEvent, NoopResponse>
	{
		public NoopIngestChannel(NoopChannelOptions options) : base(options) { }

		private long _seenPages = 0;
		public long SeenPages => _seenPages;

		protected override Task<NoopResponse> Send(IReadOnlyCollection<NoopEvent> page)
		{
			Interlocked.Increment(ref _seenPages);
			return Task.FromResult(new NoopResponse());
		}
	}

	public class DelayedNoopIngestChannel : NoopIngestChannel
	{
		public DelayedNoopIngestChannel(NoopChannelOptions options) : base(options) { }

		private int _currentMax = 0;
		public int MaxConcurrency { get; set; }

		protected override async Task<NoopResponse> Send(IReadOnlyCollection<NoopEvent> page)
		{
			var max = Interlocked.Increment(ref _currentMax);
			await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
			Interlocked.Decrement(ref _currentMax);
			if (max > MaxConcurrency) MaxConcurrency = max;
			return await base.Send(page);
		}
	}
}

