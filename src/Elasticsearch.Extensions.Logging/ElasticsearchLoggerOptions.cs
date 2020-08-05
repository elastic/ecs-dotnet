// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Elasticsearch.Net;

namespace Elasticsearch.Extensions.Logging
{
	public class ElasticsearchLoggerOptions
	{
		/// <summary>
		/// Gets or sets the connection pool type. Default for multiple nodes is <c>Sniffing</c>; other supported values are
		/// <c>Static</c>, <c>Sticky</c>, or force to <c>SingleNode</c>.
		/// </summary>
		public ConnectionPoolType ConnectionPoolType { get; set; }

		/// <summary>
		/// Gets or sets a flag indicating whether host details should be included in the message. Defaults to <c>true</c>.
		/// </summary>
		public bool IncludeHost { get; set; } = true;

		/// <summary>
		/// Gets or sets a flag indicating whether process details should be included in the message. Defaults to <c>true</c>.
		/// </summary>
		public bool IncludeProcess { get; set; } = true;

		/// <summary>
		/// Gets or sets a flag indicating whether scopes should be included in the message. Defaults to <c>true</c>.
		/// </summary>
		public bool IncludeScopes { get; set; } = true;

		/// <summary>
		/// Gets or sets a flag indicating whether user details should be included in the message. Defaults to <c>true</c>.
		/// </summary>
		public bool IncludeUser { get; set; } = true;

		/// <summary>
		/// Gets or sets the format string for the Elastic search index. The current <c>DateTimeOffset</c> is passed as parameter
		/// 0.
		/// </summary>
		public string Index { get; set; } = "dotnet-{0:yyyy.MM.dd}";

		/// <summary>
		/// Gets or sets the offset to use for the index <c>DateTimeOffset</c>. Default value is null, which uses the system local
		/// offset. Use "00:00" for UTC.
		/// </summary>
		public TimeSpan? IndexOffset { get; set; }

		/// <summary>
		/// Gets or sets flag indicating if the logger is enabled. Default is <c>true</c>.
		/// </summary>
		public bool IsEnabled { get; set; } = true;

		/// <summary>
		/// Gets or sets the separate to use for <c>IList</c> semantic values.
		/// </summary>
		public string ListSeparator { get; set; } = ", ";

		/// <summary>
		/// Gets or sets the ShipTo property of the Elasticsearch.
		/// If not specified the default single node is being used.
		/// "http://localhost:9200" is used.
		/// </summary>
		public ShipTo ShipTo { get; set; } = new ShipTo();

		/// <summary>
		/// Gets or sets additional tags to pass in the message, for example you can tag with the environment name ('Development',
		/// 'Production', etc).
		/// </summary>
		public string[] Tags { get; set; } = new string[0];

		public BufferOptions BufferOptions { get; set; } = new BufferOptions();

	}

	/// <summary>
	/// Controls how <see cref="LogEvent"/>'s are batched and send to Elasticsearch. These can not be dynamically updated.
	/// </summary>
	public class BufferOptions
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
		public Action<LogEvent> PublishRejectionCallback { get; set; } = e => { };

		public Action<IElasticsearchResponse, IConsumerBuffer> ElasticsearchResponseCallback { get; set; } = (r, b) => { };

	}

}
