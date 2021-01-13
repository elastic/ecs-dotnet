// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Elastic.Ingest.Elasticsearch;

namespace Elasticsearch.Extensions.Logging
{
	public class ChannelSetup : IChannelSetup
	{
		private readonly Action<ElasticsearchChannelOptions<LogEvent>> _configureChannel;

		public ChannelSetup(Action<ElasticsearchChannelOptions<LogEvent>> configureChannel) => _configureChannel = configureChannel;

		public void ConfigureChannel(ElasticsearchChannelOptions<LogEvent> channelConfiguration) => _configureChannel(channelConfiguration);
	}
}
