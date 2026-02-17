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
	public class MockConfiguration(
		string serviceName,
		string serviceNodeName,
		string serviceVersion,
		bool enabled = true,
		IReadOnlyDictionary<string, string> globalLabels = null
	)
		: IConfigurationReader
	{
		public bool Enabled { get; } = enabled;

		public string Description => nameof(MockConfiguration);
		public IReadOnlyList<WildcardMatcher> BaggageToAttach { get; } = Array.Empty<WildcardMatcher>();

		public IReadOnlyDictionary<string, string> GlobalLabels { get; } = globalLabels;
		public string ServiceName { get; } = serviceName;
		public string ServiceNodeName { get; } = serviceNodeName;
		public string ServiceVersion { get; } = serviceVersion;

		public IReadOnlyList<WildcardMatcher> SanitizeFieldNames { get; } = Array.Empty<WildcardMatcher>();
		public IReadOnlyList<Uri> ServerUrls { get; } = Array.Empty<Uri>();
		public IReadOnlyList<WildcardMatcher> DisableMetrics { get; } = Array.Empty<WildcardMatcher>();
		public List<string> CaptureBodyContentTypes { get; } = new();
		public LogLevel LogLevel { get; } = LogLevel.Information;

		// ReSharper disable UnassignedGetOnlyAutoProperty
		public IReadOnlyList<WildcardMatcher> IgnoreMessageQueues { get; } = Array.Empty<WildcardMatcher>();
		public bool Recording { get; } = true;
		public string HostName { get; }
		public string ServerCert { get; }
		public Uri ServerUrl { get; }
		public string CloudProvider { get; }
		public IReadOnlyCollection<string> ApplicationNamespaces { get; } = Array.Empty<string>();
		public string CaptureBody { get; }
		public bool CaptureHeaders { get; }
		public bool CentralConfig { get; }
		public string Environment { get; }
		public IReadOnlyCollection<string> ExcludedNamespaces { get; } = Array.Empty<string>();
		public double ExitSpanMinDuration { get; }
		public TimeSpan FlushInterval { get; }
		public int MaxBatchEventCount { get; }
		public int MaxQueueEventCount { get; }
		public double MetricsIntervalInMilliseconds { get; }
		public string SecretToken { get; }
		public string ApiKey { get; }
		public double SpanFramesMinDurationInMilliseconds { get; }
		public int StackTraceLimit { get; }
		public bool TraceContextIgnoreSampledFalse { get; }
		public string TraceContinuationStrategy { get; }
		public IReadOnlyList<WildcardMatcher> TransactionIgnoreUrls { get; } = Array.Empty<WildcardMatcher>();

		/// <inheritdoc />
		public IReadOnlyCollection<WildcardMatcher> TransactionNameGroups { get; } = Array.Empty<WildcardMatcher>();
		public int TransactionMaxSpans { get; }
		public double TransactionSampleRate { get; } = 1.0;
		public bool UseElasticTraceparentHeader { get; }

		/// <inheritdoc />
		public bool UsePathAsTransactionName { get; }
		public bool VerifyServerCert { get; }

		/// <inheritdoc />
		public Uri ProxyUrl { get; }

		/// <inheritdoc />
		public string ProxyUserName { get; }

		/// <inheritdoc />
		public string ProxyPassword { get; }
		public bool OpenTelemetryBridgeEnabled { get; }
		public bool UseWindowsCredentials { get; }
		public bool SpanCompressionEnabled { get; }
		public double SpanCompressionExactMatchMaxDuration { get; }
		public double SpanCompressionSameKindMaxDuration { get; }
		public double SpanStackTraceMinDurationInMilliseconds { get; }
		// ReSharper restore UnassignedGetOnlyAutoProperty

		/// <inheritdoc />
		public ConfigurationKeyValue Lookup(ConfigurationOption option) => null;
	}
}
