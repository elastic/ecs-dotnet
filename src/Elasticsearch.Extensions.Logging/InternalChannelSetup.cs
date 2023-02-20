// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Elastic.Ingest.Elasticsearch;

namespace Elasticsearch.Extensions.Logging
{
	/// <inheritdoc cref="IChannelSetup"/>
	public class ChannelSetup : IChannelSetup
	{
		private readonly Action<ElasticsearchChannelOptionsBase<LogEvent>> _configureChannel;

		/// <inheritdoc cref="IChannelSetup"/>
		public ChannelSetup(Action<ElasticsearchChannelOptionsBase<LogEvent>> configureChannel) => _configureChannel = configureChannel;

		/// <inheritdoc cref="IChannelSetup"/>
		public void ConfigureChannel(ElasticsearchChannelOptionsBase<LogEvent> channelOptions) =>
			_configureChannel(channelOptions);
	}
}
