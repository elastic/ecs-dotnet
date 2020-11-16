// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Elastic.Ingest;

namespace Elasticsearch.Extensions.Logging
{
	internal class InternalChannelSetup : IChannelSetup
	{
		private readonly Action<ElasticsearchChannelOptions<LogEvent>> _configureChannel;

		public InternalChannelSetup(Action<ElasticsearchChannelOptions<LogEvent>> configureChannel) => _configureChannel = configureChannel;

		public void ConfigureChannel(ElasticsearchChannelOptions<LogEvent> channelConfiguration) => _configureChannel(channelConfiguration);
	}
}
