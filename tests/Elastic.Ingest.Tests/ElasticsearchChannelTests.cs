using System;
using Elastic.Transport.VirtualizedCluster.Rules;
using FluentAssertions;
using Xunit;

namespace Elastic.Ingest.Tests
{
	public class ElasticsearchChannelTests
	{
		[Fact]
		public void RejectionsAreReportedAndNotRetried()
		{
			var client = TestSetup.CreateClient(v => v
				.ClientCalls(c => c.BulkResponse(400, 400))
				.ClientCalls(c => c.BulkResponse(200, 200))
			);
			using var session = TestSetup.CreateTestSession(client);
			session.WriteAndWait(events: 2);

			session.Rejections.Should().Be(1);
			session.TotalBulkRequests.Should().Be(1);
			session.TotalRetries.Should().Be(0);

			session.WriteAndWait(events: 2);

			session.Rejections.Should().Be(1);
			session.TotalBulkRequests.Should().Be(2);
			session.TotalRetries.Should().Be(0);

		}

		[Fact]
		public void BackoffRetries()
		{
			var client = TestSetup.CreateClient(v => v
					// first two events keep bouncing
				.ClientCalls(c => c.BulkResponse(429, 429))
				.ClientCalls(c => c.BulkResponse(429, 429)) //retry 1
				.ClientCalls(c => c.BulkResponse(429, 429)) //retry 2
					// finally succeeds
				.ClientCalls(c => c.BulkResponse(200, 200)) //retry 3
					// next two succeed straight away
				.ClientCalls(c => c.BulkResponse(200, 200)) //next batch
			);
			using var session = TestSetup.CreateTestSession(client);
			session.WriteAndWait(events: 2);

			session.Rejections.Should().Be(0);
			session.TotalBulkRequests.Should().Be(4);
			session.TotalRetries.Should().Be(3);

			session.WriteAndWait(events: 2);

			session.TotalBulkRequests.Should().Be(5);
			session.TotalRetries.Should().Be(3);
			session.Rejections.Should().Be(0);

		}

		[Fact]
		public void BackoffTooMuchEndsUpOnDLQ()
		{
			var client = TestSetup.CreateClient(v => v
					// first two events keep bouncing
				.ClientCalls(c => c.BulkResponse(429, 429))
				.ClientCalls(c => c.BulkResponse(429, 429)) //retry 1
				.ClientCalls(c => c.BulkResponse(429, 429)) //retry 2
				.ClientCalls(c => c.BulkResponse(429, 429)) //retry 3
					// next two succeed straight away
				.ClientCalls(c => c.BulkResponse(200, 200)) //next batch
			);
			using var session = TestSetup.CreateTestSession(client);
			session.WriteAndWait(events: 2);

			session.TotalBulkRequests.Should().Be(4);
			session.TotalRetries.Should().Be(3);
			session.MaxRetriesExceeded.Should().Be(1);
			session.Rejections.Should().Be(0);

			session.WriteAndWait(events: 2);

			session.TotalBulkRequests.Should().Be(5);
			session.TotalRetries.Should().Be(3);
			session.Rejections.Should().Be(0);

		}

		[Fact]
		public void ExceptionDoesNotHaltProcessingAndIsReported()
		{
			var client = TestSetup.CreateClient(v => v
					// first two events throws an exception in the client call
				.ClientCalls(c => c.Fails(TimesHelper.Once, new Exception("boom!")))
					// next two succeed straight away
				.ClientCalls(c => c.BulkResponse(200, 200)) //next batch
			);
			using var session = TestSetup.CreateTestSession(client);
			session.WriteAndWait(events: 2);

			session.TotalBulkRequests.Should().Be(1);
			session.TotalBulkResponses.Should().Be(0);
			session.TotalRetries.Should().Be(0);
			session.MaxRetriesExceeded.Should().Be(0);
			session.Rejections.Should().Be(0);
			session.LastException.Should().NotBeNull();
			session.LastException.Message.Should().Be("boom!");

			session.WriteAndWait(events: 2);

			session.TotalBulkRequests.Should().Be(2);
			session.TotalBulkResponses.Should().Be(1);
			session.TotalRetries.Should().Be(0);
			session.Rejections.Should().Be(0);

		}
	}
}
