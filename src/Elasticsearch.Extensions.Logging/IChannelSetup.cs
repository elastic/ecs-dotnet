// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Ingest.Elasticsearch;

namespace Elasticsearch.Extensions.Logging
{
	/// <summary>
	/// Provide callbacks to further configure <see cref="ElasticsearchChannelOptionsBase{TEvent}"/>
	/// </summary>
	public interface IChannelSetup
	{
		/// <summary>
		/// Provide callbacks to further configure <see cref="ElasticsearchChannelOptionsBase{TEvent}"/>
		/// </summary>
		void ConfigureChannel(ElasticsearchChannelOptionsBase<LogEvent> channelOptions);
	}
}
