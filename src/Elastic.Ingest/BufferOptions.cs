// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Threading;

namespace Elastic.Ingest
{
	public class BufferOptions<TEvent>
	{
		/// <summary>
		/// The maximum number of <see cref="TEvent"/> instances that can be queued in memory. If this threshold is reached, events will be dropped
		/// </summary>
		public int MaxInFlightMessages { get; set; } = 100_000;

		/// <summary>
		/// The number of events a local buffer should reach before sending the events in a single call to Elasticsearch.
		/// </summary>
		public int MaxConsumerBufferSize { get; set; } = 1_000;

		/// <summary>
		/// The maximum number of times that an item that returns with a retryable status code is retried to be stored in Elasticsearch.
		/// <see cref="BackoffPeriod"/> to implement a backoff period of your choosing. MaxRetries default to 3.
		/// </summary>
		public int MaxRetries { get; set; } = 3;

		/// <summary>
		/// A consumer builds up a local buffer until <see cref="MaxConsumerBufferSize"/> is reached. If events come in too slow, these
		/// events could end up taking forever to be sent to Elasticsearch. This controls how long a buffer may exist before a flush is triggered.
		/// </summary>
		public TimeSpan MaxConsumerBufferLifetime { get; set; } = TimeSpan.FromSeconds(5);

		/// <summary>
		/// The maximum number of consumers allowed to poll for new events on the channel. Defaults to 1, increase to introduce concurrency.
		/// </summary>
		public int ConcurrentConsumers { get; set; } = 1;


		/// <summary>
		/// A function to calculate the backoff period, gets passed the number of retries attempted starting at 0.
		/// By default backs off in increments of 2 seconds.
		/// </summary>
		public Func<int, TimeSpan> BackoffPeriod { get; set; } = (i) => TimeSpan.FromSeconds(2 * (i + 1));

		/// <summary>
		/// Called once after a buffer has been flushed, if the buffer is retried this callback is only called once
		/// all retries have been exhausted
		/// </summary>
		public Action? BufferFlushCallback { get; set; }

		/// <summary>
		/// Allows you to inject a <see cref="CountdownEvent"/> to wait for N number of buffers to flush.
		/// </summary>
		public CountdownEvent? WaitHandle { get; set; }
	}
}
