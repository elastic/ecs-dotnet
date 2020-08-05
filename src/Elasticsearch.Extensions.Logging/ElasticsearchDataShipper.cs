// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using Elastic.CommonSchema;
using Elasticsearch.Net;

namespace Elasticsearch.Extensions.Logging
{
	internal class ElasticsearchDataShipper : IDisposable
	{
		private const int MaxQueuedMessages = 1024;

		private readonly BlockingCollection<LogEvent> _messageQueue =
			new BlockingCollection<LogEvent>(MaxQueuedMessages);

		private readonly Thread _outputThread;

		public ElasticsearchDataShipper()
		{
			_outputThread = new Thread(ProcessLogQueue) { IsBackground = true, Name = $"{nameof(ElasticsearchLogger)}.{nameof(ProcessLogQueue)}" };
			_outputThread.Start();
		}

		private IElasticLowLevelClient _lowLevelClient = default!;

		private ElasticsearchLoggerOptions _options = default!;

		internal ElasticsearchLoggerOptions Options
		{
			get => _options;
			set
			{
				_options = value;
				UpdateClient();
			}
		}

		public void Dispose()
		{
			_messageQueue?.CompleteAdding();
			try
			{
				_outputThread.Join(1500); // with timeout in case writer is locked
			}
			catch (ThreadStateException) { }

			_messageQueue?.Dispose();
		}

		public void EnqueueMessage(LogEvent logEvent)
		{
			if (!_messageQueue.IsAddingCompleted)
			{
				try
				{
					_messageQueue.Add(logEvent);
					return;
				}
				catch (InvalidOperationException) { }
			}

			// Adding is complete, so just log the message
			try
			{
				PostEvent(logEvent);
			}
			catch (Exception) { }
		}

		private void PostEvent(LogEvent logEvent)
		{
			var indexTime = logEvent.Timestamp ?? ElasticsearchLoggerProvider.LocalDateTimeProvider();
			if (_options.IndexOffset.HasValue) indexTime = indexTime.ToOffset(_options.IndexOffset.Value);

			var index = string.Format(_options.Index, indexTime);

			var localClient = _lowLevelClient;
			var response = localClient.Index<StringResponse>(index,
				PostData.StreamHandler(logEvent,
					(@event, stream) => logEvent.Serialize(stream),
					// async variant not used yet but will when we move to channels/tpl in the future
					async (@event, stream, ctx) => await logEvent.SerializeAsync(stream, ctx).ConfigureAwait(false)
					)
				);
		}

		private void ProcessLogQueue()
		{
			try
			{
				foreach (var logEvent in _messageQueue.GetConsumingEnumerable()) PostEvent(logEvent);
			}
			catch
			{
				try
				{
					_messageQueue.CompleteAdding();
				}
				catch { }
			}
		}

		private void UpdateClient()
		{
			// TODO: Check if Uri has changed before recreating
			// TODO: Injectable factory? Or some way of testing.
			var connectionPool = _options.ShipTo.CreateConnectionPool();
			var nodes = _options.ShipTo.NodeUris.ToArray();

			ConnectionConfiguration settings;

			if (nodes.Length == 0 && _options.ShipTo.ConnectionPoolType != ConnectionPoolType.Cloud)
			{
				// This is SingleNode with "http://localhost:9200"
				settings = new ConnectionConfiguration();
			}
			else if (_options.ConnectionPoolType == ConnectionPoolType.SingleNode
				|| _options.ConnectionPoolType == ConnectionPoolType.Unknown && nodes.Length == 1)
				settings = new ConnectionConfiguration(nodes[0]);
			else
			{
				settings = new ConnectionConfiguration(connectionPool);
			}

			var lowlevelClient = new ElasticLowLevelClient(settings);

			_ = Interlocked.Exchange(ref _lowLevelClient, lowlevelClient);
		}
	}
}
