// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Channels;

namespace Elastic.Extensions.Logging
{
	/// <summary>
	/// Instantiates and manages <see cref="IBufferedChannel{TEvent}"/>
	/// </summary>
	internal interface IChannelProvider
	{
		/// <summary>
		/// Provides <see cref="IBufferedChannel{TEvent}"/> instance managed by provider
		/// </summary>
		/// <returns></returns>
		IBufferedChannel<LogEvent> GetChannel();
	}
}
