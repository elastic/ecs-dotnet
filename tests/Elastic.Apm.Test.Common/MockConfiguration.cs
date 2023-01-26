// Licensed to Elasticsearch B.V under
// one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using Elastic.Apm.Config;
using Elastic.Apm.Helpers;
using Elastic.Apm.Logging;

namespace Elastic.Apm.Test.Common
{
	public class MockConfiguration : IConfigurationReader
	{
		public MockConfiguration(
			string serviceName,
			string serviceNodeName,
			string serviceVersion,
			bool enabled = true,
			IReadOnlyDictionary<string, string> globalLabels = null
		)
		{
			GlobalLabels = globalLabels;
			ServiceName = serviceName;
			ServiceNodeName = serviceNodeName;
			ServiceVersion = serviceVersion;
			Enabled = enabled;
			Recording = true;
		}

		public bool Enabled { get; }

		public IReadOnlyDictionary<string, string> GlobalLabels { get; }
		public string ServiceName { get; }
		public string ServiceNodeName { get; }
		public string ServiceVersion { get; }

		public IReadOnlyList<WildcardMatcher> SanitizeFieldNames { get; } = Array.Empty<WildcardMatcher>();
		public IReadOnlyList<Uri> ServerUrls { get; } = Array.Empty<Uri>();
		public IReadOnlyList<WildcardMatcher> DisableMetrics { get; } = Array.Empty<WildcardMatcher>();
		public List<string> CaptureBodyContentTypes { get; } = new();
		public LogLevel LogLevel { get; } = LogLevel.Information;

		// ReSharper disable UnassignedGetOnlyAutoProperty
		public bool Recording { get; }
		public string HostName { get; }
		public Uri ServerUrl { get; }
		public string CloudProvider { get; }
		public IReadOnlyCollection<string> ApplicationNamespaces { get; }
		public string CaptureBody { get; }
		public bool CaptureHeaders { get; }
		public bool CentralConfig { get; }
		public string Environment { get; }
		public IReadOnlyCollection<string> ExcludedNamespaces { get; }
		public TimeSpan FlushInterval { get; }
		public int MaxBatchEventCount { get; }
		public int MaxQueueEventCount { get; }
		public double MetricsIntervalInMilliseconds { get; }
		public string SecretToken { get; }
		public string ApiKey { get; }
		public double SpanFramesMinDurationInMilliseconds { get; }
		public int StackTraceLimit { get; }
		public IReadOnlyList<WildcardMatcher> TransactionIgnoreUrls { get; }
		public int TransactionMaxSpans { get; }
		public double TransactionSampleRate { get; }
		public bool UseElasticTraceparentHeader { get; }
		public bool VerifyServerCert { get; }
		// ReSharper restore UnassignedGetOnlyAutoProperty
	}
}
