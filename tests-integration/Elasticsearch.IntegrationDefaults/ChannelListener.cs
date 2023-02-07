// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Threading.Channels;
using Elastic.Channels;
using Elastic.Elasticsearch.Xunit;
using Elastic.Ingest.Elasticsearch.Serialization;
using Elastic.Transport;
using Xunit;
using Xunit.Abstractions;

namespace Elasticsearch.IntegrationDefaults;

public class ChannelListener<TEvent>
{
	private int _bufferFlushCallback;
	private Exception? _exception;

	public Exception? ObservedException => _exception;
	public bool PublishSuccess => _exception == null && _bufferFlushCallback > 0 && _maxRetriesExceeded == 0 && _items > 0 && string.IsNullOrEmpty(_firstItemError);

	private int _responses;
	private int _rejections;
	private int _retries;
	private int _items;
	private int _maxRetriesExceeded;
	private int _rejectedItems;
	private string? _firstItemError;

	public ChannelListener() {}
	public ChannelListener<TEvent> Register(ResponseItemsChannelOptionsBase<TEvent, BulkResponse, BulkResponseItem> options)
	{
		options.BufferOptions.BufferFlushCallback = () => Interlocked.Increment(ref _bufferFlushCallback);
		options.ResponseCallback = (r, b) => Interlocked.Increment(ref _responses);
		options.PublishRejectionCallback = (r) => Interlocked.Increment(ref _rejections);
		options.RetryCallBack = (r) => Interlocked.Increment(ref _retries);
		options.ServerRejectionCallback = (r) =>
		{
			Interlocked.Add(ref _rejectedItems, r.Count);
			if (r.Count > 0)
			{
				var error = r.Select(e => e.Item2).FirstOrDefault(i=>i.Error != null);
				if (error != null)
					_firstItemError ??= error?.Error?.ToString();
			}
			Interlocked.Increment(ref _retries);
		};
		options.BulkAttemptCallback = (retries, count) =>
		{
			if (retries == 0) Interlocked.Add(ref _items, count);
		};
		options.MaxRetriesExceededCallback = (c) => Interlocked.Increment(ref _maxRetriesExceeded);

		if (options.ExceptionCallback == null) options.ExceptionCallback = (e) => _exception ??= e;
		else options.ExceptionCallback += (e) => _exception ??= e;
		return this;
	}


	public override string ToString() => $@"{(!PublishSuccess ? "Failed" : "Successful")} publish over channel.
Item Error: {_firstItemError}
Seen Flushes: {_bufferFlushCallback}
Seen Responses: {_responses}
Seen Rejections: {_rejections}
Seen Rejected Items: {_firstItemError}
Seen Retries: {_retries}
Seen Retry Exhausts: {_maxRetriesExceeded}
Seen Publish Items : {_items}
Exception: {_exception}
First Item Rejection: {_firstItemError}
";
}
