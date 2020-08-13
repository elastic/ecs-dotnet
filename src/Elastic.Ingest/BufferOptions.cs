// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Elasticsearch.Net;

namespace Elastic.Ingest
{
	/// <summary>
	/// Controls how <see cref="LogEvent"/>'s are batched and send to Elasticsearch. These can not be dynamically updated.
	/// </summary>
	public class BufferOptions<TEvent>
	{
		/// <summary>
		/// The maximum number of <see cref="LogEvent"/> that can be queued in memory. If this threshold is reached, events will be dropped
		/// </summary>
		public int MaxInFlightMessages { get; set; } = 100_000;

		/// <summary>
		/// The number of events a local buffer should reach before sending the events in a single call to Elasticsearch.
		/// </summary>
		public int MaxConsumerBufferSize { get; set; } = 1_000;

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
		/// If <see cref="MaxInFlightMessages"/> is reached, <see cref="LogEvent"/>'s will fail to be published to the channel. You can be notified of dropped
		/// events with this callback
		/// </summary>
		public Action<TEvent> PublishRejectionCallback { get; set; } = e => { };

		public Action<IElasticsearchResponse, IChannelBuffer> ElasticsearchResponseCallback { get; set; } = (r, b) => { };

	}

}
