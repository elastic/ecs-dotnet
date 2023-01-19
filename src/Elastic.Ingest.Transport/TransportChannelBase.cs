// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Transport;

namespace Elastic.Ingest.Transport
{
	public abstract class TransportChannelBase<TChannelOptions, TBuffer, TEvent, TResponse, TBulkResponseItem> :
		ChannelBase<TChannelOptions, TBuffer, TEvent, TResponse, TBulkResponseItem>, IDisposable
		where TChannelOptions : TransportChannelOptionsBase<TEvent, TResponse, TBulkResponseItem, TBuffer>
		where TBuffer : BufferOptions<TEvent>, new()
		where TResponse : TransportResponse, new()

	{
		protected TransportChannelBase(TChannelOptions options) : base(options) { }

		/// <summary> Implement sending the current <paramref name="page"/> of the buffer to the output. </summary>
		/// <param name="transport"></param>
		/// <param name="page">Active page of the buffer that needs to be send to the output</param>
		/// <returns><see cref="TResponse"/></returns>
		protected abstract Task<TResponse> Send(HttpTransport transport, IReadOnlyCollection<TEvent> page);

		protected override Task<TResponse> Send(IReadOnlyCollection<TEvent> page) => Send(Options.Transport, page);
	}
}
