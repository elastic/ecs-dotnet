using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Elastic.Ingest.Apm.Model
{
	public interface IIntakeObject { }

	/// <summary>
	/// An event corresponding to an incoming request or similar task occurring in a monitored
	/// service
	/// </summary>
	public class Transaction : IIntakeObject
	{
		public Transaction(string type, string id, string traceId, SpanCount spanCount, double duration, long timestamp)
		{
			Type = type;
			Id = id;
			TraceId = traceId;
			SpanCount = spanCount;
			Duration = duration;
			Timestamp = timestamp;
		}

		/// <summary>
		/// Recorded time of the event, UTC based and formatted as microseconds since Unix epoch
		/// </summary>
		[JsonPropertyName("timestamp")]
		public long Timestamp { get; set; }

		/// <summary>
		/// How long the transaction took to complete, in ms with 3 decimal points
		/// </summary>
		[JsonPropertyName("duration")]
		public double? Duration { get; set; }

		/// <summary>
		/// Hex encoded 64 random bits ID of the transaction.
		/// </summary>
		[JsonPropertyName("id")]
		public string Id { get; set; }

		/// <summary>
		/// A mark captures the timing of a significant event during the lifetime of a transaction.
		/// Marks are organized into groups and can be set by the user or the agent.
		/// </summary>
		//public Marks? Marks { get; set; }

		/// <summary>
		/// Generic designation of a transaction in the scope of a single service (eg: 'GET
		/// /users/:id')
		/// </summary>
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		/// <summary>
		/// Hex encoded 64 random bits ID of the parent transaction or span. Only root transactions
		/// of a trace do not have a parent_id, otherwise it needs to be set.
		/// </summary>
		[JsonPropertyName("parent_id")]
		public string? ParentId { get; set; }

		/// <summary>
		/// The result of the transaction. For HTTP-related transactions, this should be the status
		/// code formatted like 'HTTP 2xx'.
		/// </summary>
		[JsonPropertyName("result")]
		public string? Result { get; set; }

		/// <summary>
		/// Sampling rate
		/// </summary>
		[JsonPropertyName("sample_rate")]
		public double? SampleRate { get; set; }

		/// <summary>
		/// Transactions that are 'sampled' will include all available information. Transactions that
		/// are not sampled will not have 'spans' or 'context'. Defaults to true.
		/// </summary>
		[JsonPropertyName("sampled")]
		public bool? Sampled { get; set; }

		[JsonPropertyName("span_count")]
		public SpanCount SpanCount { get; set; }

		/// <summary>
		/// Hex encoded 128 random bits ID of the correlated trace.
		/// </summary>
		[JsonPropertyName("trace_id")]
		public string TraceId { get; set; }

		/// <summary>
		/// Keyword of specific relevance in the service's domain (eg: 'request', 'backgroundjob',
		/// etc)
		/// </summary>
		[JsonPropertyName("type")]
		public string Type { get; set; }
	}

	public class Marks { }

	public class SpanCount
	{
		/// <summary>
		/// Number of spans that have been dropped by the agent recording the transaction.
		/// </summary>
		[JsonPropertyName("dropped")]
		public long? Dropped { get; set; }

		/// <summary>
		/// Number of correlated spans that are recorded.
		/// </summary>
		[JsonPropertyName("started")]
		public long Started { get; set; }
	}

    public class Span : IIntakeObject
	{
		public Span(string type, string name, string id, string traceId, string parentId, long timestamp)
		{
			Type = type;
			Name = name;
			Id = id;
			TraceId = traceId;
			ParentId = parentId;
			Timestamp = timestamp;
		}

		/// <summary>
		/// Recorded time of the event, UTC based and formatted as microseconds since Unix epoch
		/// </summary>
		public long Timestamp { get; set; }

        /// <summary>
        /// The specific kind of event within the sub-type represented by the span (e.g. query,
        /// connect)
        /// </summary>
        public string? Action { get; set; }

		/// <summary>
        /// List of successor transactions and/or spans.
        /// </summary>
        public List<string>? ChildIds { get; set; }

		/// <summary>
        /// Any other arbitrary data captured by the agent, optionally provided by the user
        /// </summary>
        public Context? Context { get; set; }

		/// <summary>
        /// Duration of the span in milliseconds
        /// </summary>
        public double? Duration { get; set; }

        /// <summary>
        /// Hex encoded 64 random bits ID of the span.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Generic designation of a span in the scope of a transaction
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Hex encoded 64 random bits ID of the parent transaction or span.
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Sampling rate
        /// </summary>
        public double? SampleRate { get; set; }

        /// <summary>
        /// List of stack frames with variable attributes (eg: lineno, filename, etc)
        /// </summary>
        public List<object>? Stacktrace { get; set; }

		/// <summary>
        /// Offset relative to the transaction's timestamp identifying the start of the span, in
        /// milliseconds
        /// </summary>
        public double? Start { get; set; }

        /// <summary>
        /// A further sub-division of the type (e.g. postgresql, elasticsearch)
        /// </summary>
        public string? Subtype { get; set; }

		/// <summary>
        /// Indicates whether the span was executed synchronously or asynchronously.
        /// </summary>
        public bool? Sync { get; set; }

        /// <summary>
        /// Hex encoded 128 random bits ID of the correlated trace.
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// Hex encoded 64 random bits ID of the correlated transaction.
        /// </summary>
        public string? TransactionId { get; set; }

		/// <summary>
        /// Keyword of specific relevance in the service's domain (eg: 'db', 'template', etc)
        /// </summary>
        public string Type { get; set; }
    }

    public class Context
    {
        /// <summary>
        /// An object containing contextual data for database spans
        /// </summary>
        public Db? Db { get; set; }

        /// <summary>
        /// An object containing contextual data about the destination for spans
        /// </summary>
        public Destination? Destination { get; set; }

        /// <summary>
        /// An object containing contextual data of the related http request.
        /// </summary>
        public Http? Http { get; set; }

        /// <summary>
        /// Service related information can be sent per event. Provided information will override the
        /// more generic information from metadata, non provided fields will be set according to the
        /// metadata information.
        /// </summary>
        public ContextService? Service { get; set; }
    }

    public class Db
    {
        /// <summary>
        /// Database instance name
        /// </summary>
        public string? Instance { get; set; }

        /// <summary>
        /// Database link
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// Number of rows affected by the SQL statement (if applicable)
        /// </summary>
        public long? RowsAffected { get; set; }

        /// <summary>
        /// A database statement (e.g. query) for the given database type
        /// </summary>
        public string? Statement { get; set; }

        /// <summary>
        /// Database type. For any SQL database, "sql". For others, the lower-case database category,
        /// e.g. "cassandra", "hbase", or "redis"
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Username for accessing database
        /// </summary>
        public string? User { get; set; }
    }

    public class Destination
    {
        /// <summary>
        /// Destination network address: hostname (e.g. 'localhost'), FQDN (e.g. 'elastic.co'), IPv4
        /// (e.g. '127.0.0.1') or IPv6 (e.g. '::1')
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Destination network port (e.g. 443)
        /// </summary>
        public long? Port { get; set; }

        /// <summary>
        /// Destination service context
        /// </summary>
        public DestinationService? Service { get; set; }
    }

    public class DestinationService
    {
        /// <summary>
        /// Identifier for the destination service (e.g. 'http://elastic.co', 'elasticsearch',
        /// 'rabbitmq')
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Identifier for the destination service resource being operated on (e.g.
        /// 'http://elastic.co:80', 'elasticsearch', 'rabbitmq/queue_name')
        /// </summary>
        public string? Resource { get; set; }

        /// <summary>
        /// Type of the destination service (e.g. 'db', 'elasticsearch'). Should typically be the
        /// same as span.type.
        /// </summary>
        public string? Type { get; set; }
    }

    public class Http
    {
        /// <summary>
        /// The method of the http request.
        /// </summary>
        public string? Method { get; set; }

        /// <summary>
        /// Deprecated: Use span.context.http.response.status_code instead.
        /// </summary>
        public long? StatusCode { get; set; }

        /// <summary>
        /// The raw url of the correlating http request.
        /// </summary>
        public string? Url { get; set; }
    }

    public class ContextService
    {
        /// <summary>
        /// Name and version of the Elastic APM agent
        /// </summary>
        public Agent? Agent { get; set; }

        /// <summary>
        /// Immutable name of the service emitting this event
        /// </summary>
        public string? Name { get; set; }
    }

    public class Agent
    {
        /// <summary>
        /// Free format ID used for metrics correlation by some agents
        /// </summary>
        public string? EphemeralId { get; set; }

        /// <summary>
        /// Name of the Elastic APM agent, e.g. "Python"
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Version of the Elastic APM agent, e.g."1.0.0"
        /// </summary>
        public string? Version { get; set; }
    }
}
