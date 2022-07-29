﻿using System;
using System.Linq;
using System.Threading;
using Elastic.CommonSchema;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.Indices;
using Elastic.Transport;
using Elastic.Transport.VirtualizedCluster;
using Elastic.Transport.VirtualizedCluster.Components;
using Elastic.Transport.VirtualizedCluster.Rules;

namespace Elastic.Ingest.Tests.Elasticsearch
{
	public static class TestSetup
	{
		public static ITransport<ITransportConfiguration> CreateClient(Func<VirtualCluster, VirtualCluster> setup)
		{
			var cluster = Virtual.Elasticsearch.Bootstrap(numberOfNodes: 1).Ping(c=>c.SucceedAlways());
			var virtualSettings = setup(cluster)
				.StaticNodePool()
				.Settings(s=>s.DisablePing());

			//var audit = new Auditor(() => virtualSettings);
			//audit.VisualizeCalls(cluster.ClientCallRules.Count);

			var settings = new TransportConfiguration(virtualSettings.ConnectionPool, virtualSettings.Connection)
				.DisablePing()
				.EnableDebugMode();
			return new Transport<TransportConfiguration>(settings);
		}

		public static ClientCallRule BulkResponse(this ClientCallRule rule, params int[] statusCodes) =>
			rule.Succeeds(TimesHelper.Once).ReturnResponse(BulkResponseBuilder.CreateResponse(statusCodes));

		public class TestSession : IDisposable
		{
			private int _rejections;
			private int _requests;
			private int _responses;
			private int _retries;
			private int _maxRetriesExceeded;

			public TestSession(ITransport<ITransportConfiguration> transport)
			{
				Transport = transport;
				BufferOptions = new ElasticsearchBufferOptions<EcsDocument>()
				{
					ConcurrentConsumers = 1,
					MaxConsumerBufferSize = 2,
					MaxConsumerBufferLifetime = TimeSpan.FromSeconds(10),
					WaitHandle = WaitHandle,
					MaxRetries = 3,
					BackoffPeriod = times => TimeSpan.FromMilliseconds(1),
				};
				ChannelOptions = new IndexChannelOptions<EcsDocument>(transport)
				{
					BufferOptions = BufferOptions,
					ServerRejectionCallback = (list) => Interlocked.Increment(ref _rejections),
					BulkAttemptCallback = (c, a) => Interlocked.Increment(ref _requests),
					ResponseCallback = (r, b) => Interlocked.Increment(ref _responses),
					MaxRetriesExceededCallback = (list) => Interlocked.Increment(ref _maxRetriesExceeded),
					RetryCallBack = (list) => Interlocked.Increment(ref _retries),
					ExceptionCallback= (e) => LastException = e
				};
				Channel = new IndexChannel<EcsDocument>(ChannelOptions);
			}

			public IndexChannel<EcsDocument> Channel { get; }

			public ITransport<ITransportConfiguration> Transport { get; }

			public IndexChannelOptions<EcsDocument> ChannelOptions { get; }

			public ElasticsearchBufferOptions<EcsDocument> BufferOptions { get; }

			public CountdownEvent WaitHandle { get; } = new CountdownEvent(1);

			public int Rejections => _rejections;
			public int TotalBulkRequests => _requests;
			public int TotalBulkResponses => _responses;
			public int TotalRetries => _retries;
			public int MaxRetriesExceeded => _maxRetriesExceeded;
			public Exception LastException { get; private set; }

			public void Wait()
			{
				WaitHandle.Wait(TimeSpan.FromSeconds(10));
				WaitHandle.Reset();
			}

			public void Dispose()
			{
				Channel?.Dispose();
				WaitHandle?.Dispose();
			}
		}

		public static TestSession CreateTestSession(ITransport<ITransportConfiguration> transport) =>
			new TestSession(transport);

		public static void WriteAndWait(this TestSession session, int events = 1)
		{
			foreach (var b in Enumerable.Range(0, events))
				session.Channel.TryWrite(new EcsDocument { Timestamp = DateTimeOffset.UtcNow });
			session.Wait();
		}
	}
}
