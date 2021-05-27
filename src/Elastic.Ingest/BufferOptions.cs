// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Threading;
using Elastic.Ingest.Serialization;

namespace Elastic.Ingest
{
	/// <summary>
	/// Controls how instances of <see cref="TEvent"/>'s are batched and send to Elasticsearch. These can not be dynamically updated.
	/// </summary>
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

		//TODO these should be events since it's unknown if there will be typically one listener or multiple

		/// <summary>
		/// If <see cref="MaxInFlightMessages"/> is reached, <see cref="TEvent"/>'s will fail to be published to the channel. You can be notified of dropped
		/// events with this callback
		/// </summary>
		public Action<TEvent>? PublishRejectionCallback { get; set; }

		/// <summary> Subscribe to be notified of events that can not be stored in Elasticsearch</summary>
		public Action<List<(TEvent, BulkResponseItem)>>? ServerRejectionCallback { get; set; }

		/// <summary> Subscribe to be notified of events that are retryable but did not store correctly withing the boundaries of <see cref="MaxRetries"/></summary>
		public Action<List<TEvent>>? MaxRetriesExceededCallback { get; set; }

		/// <summary> Subscribe to be notified of events that are retryable but did not store correctly within the number of configured <see cref="MaxRetries"/></summary>
		public Action<List<TEvent>>? RetryCallBack { get; set; }

		/// <summary> A generic hook to be notified of any bulk request being initiated by <see cref="ElasticsearchChannel{TEvent}"/> </summary>
		public Action<BulkResponse, IChannelBuffer> ElasticsearchResponseCallback { get; set; } = (r, b) => { };

		public Action<Exception>? ExceptionCallback { get; set; }

		public Action<int, int>? BulkAttemptCallback { get; set; }

		/// <summary>
		/// A function to calculate the backoff period, gets passed the number of retries attempted starting at 0.
		/// By default backs off in increments of 2 seconds.
		/// </summary>
		public Func<int, TimeSpan> BackoffPeriod { get; set; } = (i) => TimeSpan.FromSeconds(2 * (i + 1));


		/// <summary>
		/// Allows you to inject a wait handle that will be signalled everytime a consumer sends data.
		/// NOTE: this option is ignored if <see cref="ConcurrentConsumers"/> is greater then 1.
		/// NOTE: This is solely meant to be able to test <see cref="ElasticsearchChannel{TEvent}"/> without complicating its thread safety.
		/// </summary>
		public ManualResetEventSlim? WaitHandle { get; set; }
	}

}
