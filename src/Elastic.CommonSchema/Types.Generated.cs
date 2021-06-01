// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

/*
IMPORTANT NOTE
==============
This file has been generated. 
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace Elastic.CommonSchema
{
	/// <summary>
	/// Elastic Common Schema version 1.6.0
	/// <para/>
	/// The Elastic Common Schema (ECS) defines a common set of fields for ingesting data into Elasticsearch.
	/// A common schema helps you correlate data from sources like logs and metrics or IT operations analytics
	/// and security analytics.
	/// <para/>
	/// ECS Repostory: https://github.com/elastic/ecs
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-base.html
	/// </summary>
	public partial class Base
	{
		/// <summary>
		/// Elastic Common Schema version 1.6.0
		/// </summary>
		public static string Version => "1.6.0";

		/// <summary>
		/// Container for additional metadata against this event.
		/// </summary>
		[DataMember(Name = "metadata")]
		public IDictionary<string, object> Metadata { get; set; }

		/// <summary>
		/// The agent fields contain the data about the software entity, if any, that collects, detects, or observes events on a host, or takes measurements on a host.<para/><para/>Examples include Beats. Agents may also run on observers. ECS agent.* fields shall be populated with details of the agent running on the host or observer where the event happened or the measurement was taken.
		/// </summary>
		[DataMember(Name = "agent")]
		public Agent Agent { get; set; }

		/// <summary>
		/// A client is defined as the initiator of a network connection for events regarding sessions, connections, or bidirectional flow records.<para/><para/>For TCP events, the client is the initiator of the TCP connection that sends the SYN packet(s). For other protocols, the client is generally the initiator or requestor in the network transaction. Some systems use the term "originator" to refer the client in TCP connections. The client fields describe details about the system acting as the client in the network event. Client fields are usually populated in conjunction with server fields. Client fields are generally not populated for packet-level events.<para/><para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
		/// </summary>
		[DataMember(Name = "client")]
		public Client Client { get; set; }

		/// <summary>
		/// Fields related to the cloud or infrastructure the events are coming from.
		/// </summary>
		[DataMember(Name = "cloud")]
		public Cloud Cloud { get; set; }

		/// <summary>
		/// Container fields are used for meta information about the specific container that is the source of information.<para/><para/>These fields help correlate data based containers from any runtime.
		/// </summary>
		[DataMember(Name = "container")]
		public Container Container { get; set; }

		/// <summary>
		/// Destination fields describe details about the destination of a packet/event.<para/><para/>Destination fields are usually populated in conjunction with source fields.
		/// </summary>
		[DataMember(Name = "destination")]
		public Destination Destination { get; set; }

		/// <summary>
		/// These fields contain information about code libraries dynamically loaded into processes.<para/><para/>Many operating systems refer to "shared code libraries" with different names, but this field set refers to all of the following:<para/><para/>* Dynamic-link library (`.dll`) commonly used on Windows<para/><para/>* Shared Object (`.so`) commonly used on Unix-like operating systems<para/><para/>* Dynamic library (`.dylib`) commonly used on macOS
		/// </summary>
		[DataMember(Name = "dll")]
		public Dll Dll { get; set; }

		/// <summary>
		/// Fields describing DNS queries and answers.<para/><para/>DNS events should either represent a single DNS query prior to getting answers (`dns.type:query`) or they should represent a full exchange and contain the query details as well as all of the answers that were provided for this query (`dns.type:answer`).
		/// </summary>
		[DataMember(Name = "dns")]
		public Dns Dns { get; set; }

		/// <summary>
		/// Meta-information specific to ECS.
		/// </summary>
		[DataMember(Name = "ecs")]
		public Ecs Ecs { get; set; }

		/// <summary>
		/// These fields can represent errors of any kind.<para/><para/>Use them for errors that happen while fetching events or in cases where the event itself contains an error.
		/// </summary>
		[DataMember(Name = "error")]
		public Error Error { get; set; }

		/// <summary>
		/// The event fields are used for context information about the log or metric event itself.<para/><para/>A log is defined as an event containing details of something that happened. Log events must include the time at which the thing happened. Examples of log events include a process starting on a host, a network packet being sent from a source to a destination, or a network connection between a client and a server being initiated or closed. A metric is defined as an event containing one or more numerical measurements and the time at which the measurement was taken. Examples of metric events include memory pressure measured on a host and device temperature. See the `event.kind` definition in this section for additional details about metric and state events.
		/// </summary>
		[DataMember(Name = "event")]
		public Event Event { get; set; }

		/// <summary>
		/// A file is defined as a set of information that has been created on, or has existed on a filesystem.<para/><para/>File objects can be associated with host events, network events, and/or file events (e.g., those produced by File Integrity Monitoring [FIM] products or services). File fields provide details about the affected file associated with the event or metric.
		/// </summary>
		[DataMember(Name = "file")]
		public File File { get; set; }

		/// <summary>
		/// The group fields are meant to represent groups that are relevant to the event.
		/// </summary>
		[DataMember(Name = "group")]
		public Group Group { get; set; }

		/// <summary>
		/// A host is defined as a general computing instance.<para/><para/>ECS host.* fields should be populated with details about the host on which the event happened, or from which the measurement was taken. Host types include hardware, virtual machines, Docker containers, and Kubernetes nodes.
		/// </summary>
		[DataMember(Name = "host")]
		public Host Host { get; set; }

		/// <summary>
		/// Fields related to HTTP activity. Use the `url` field set to store the url of the request.
		/// </summary>
		[DataMember(Name = "http")]
		public Http Http { get; set; }

		/// <summary>
		/// Details about the event's logging mechanism or logging transport.<para/><para/>The log.* fields are typically populated with details about the logging mechanism used to create and/or transport the event. For example, syslog details belong under `log.syslog.*`.<para/><para/>The details specific to your event source are typically not logged under `log.*`, but rather in `event.*` or in other ECS fields.
		/// </summary>
		[DataMember(Name = "log")]
		public Log Log { get; set; }

		/// <summary>
		/// The network is defined as the communication path over which a host or network event happens.<para/><para/>The network.* fields should be populated with details about the network activity associated with an event.
		/// </summary>
		[DataMember(Name = "network")]
		public Network Network { get; set; }

		/// <summary>
		/// An observer is defined as a special network, security, or application device used to detect, observe, or create network, security, or application-related events and metrics.<para/><para/>This could be a custom hardware appliance or a server that has been configured to run special network, security, or application software. Examples include firewalls, web proxies, intrusion detection/prevention systems, network monitoring sensors, web application firewalls, data loss prevention systems, and APM servers. The observer.* fields shall be populated with details of the system, if any, that detects, observes and/or creates a network, security, or application event or metric. Message queues and ETL components used in processing events or metrics are not considered observers in ECS.
		/// </summary>
		[DataMember(Name = "observer")]
		public Observer Observer { get; set; }

		/// <summary>
		/// The organization fields enrich data with information about the company or entity the data is associated with.<para/><para/>These fields help you arrange or filter data stored in an index by one or multiple organizations.
		/// </summary>
		[DataMember(Name = "organization")]
		public Organization Organization { get; set; }

		/// <summary>
		/// These fields contain information about an installed software package. It contains general information about a package, such as name, version or size. It also contains installation details, such as time or location.
		/// </summary>
		[DataMember(Name = "package")]
		public Package Package { get; set; }

		/// <summary>
		/// These fields contain information about a process.<para/><para/>These fields can help you correlate metrics information with a process id/name from a log message.  The `process.pid` often stays in the metric itself and is copied to the global field for correlation.
		/// </summary>
		[DataMember(Name = "process")]
		public Process Process { get; set; }

		/// <summary>
		/// Fields related to Windows Registry operations.
		/// </summary>
		[DataMember(Name = "registry")]
		public Registry Registry { get; set; }

		/// <summary>
		/// This field set is meant to facilitate pivoting around a piece of data.<para/><para/>Some pieces of information can be seen in many places in an ECS event. To facilitate searching for them, store an array of all seen values to their corresponding field in `related.`.<para/><para/>A concrete example is IP addresses, which can be under host, observer, source, destination, client, server, and network.forwarded_ip. If you append all IPs to `related.ip`, you can then search for a given IP trivially, no matter where it appeared, by querying `related.ip:192.0.2.15`.
		/// </summary>
		[DataMember(Name = "related")]
		public Related Related { get; set; }

		/// <summary>
		/// Rule fields are used to capture the specifics of any observer or agent rules that generate alerts or other notable events.<para/><para/>Examples of data sources that would populate the rule fields include: network admission control platforms, network or host IDS/IPS, network firewalls, web application firewalls, url filters, endpoint detection and response (EDR) systems, etc.
		/// </summary>
		[DataMember(Name = "rule")]
		public Rule Rule { get; set; }

		/// <summary>
		/// A Server is defined as the responder in a network connection for events regarding sessions, connections, or bidirectional flow records.<para/><para/>For TCP events, the server is the receiver of the initial SYN packet(s) of the TCP connection. For other protocols, the server is generally the responder in the network transaction. Some systems actually use the term "responder" to refer the server in TCP connections. The server fields describe details about the system acting as the server in the network event. Server fields are usually populated in conjunction with client fields. Server fields are generally not populated for packet-level events.<para/><para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
		/// </summary>
		[DataMember(Name = "server")]
		public Server Server { get; set; }

		/// <summary>
		/// The service fields describe the service for or from which the data was collected.<para/><para/>These fields help you find and correlate logs for a specific service and version.
		/// </summary>
		[DataMember(Name = "service")]
		public Service Service { get; set; }

		/// <summary>
		/// Source fields describe details about the source of a packet/event.<para/><para/>Source fields are usually populated in conjunction with destination fields.
		/// </summary>
		[DataMember(Name = "source")]
		public Source Source { get; set; }

		/// <summary>
		/// Fields to classify events and alerts according to a threat taxonomy such as the MITRE ATT&CK® framework.<para/><para/>These fields are for users to classify alerts from all of their sources (e.g. IDS, NGFW, etc.) within a common taxonomy. The threat.tactic.* are meant to capture the high level category of the threat (e.g. "impact"). The threat.technique.* fields are meant to capture which kind of approach is used by this detected threat, to accomplish the goal (e.g. "endpoint denial of service").
		/// </summary>
		[DataMember(Name = "threat")]
		public Threat Threat { get; set; }

		/// <summary>
		/// Fields related to a TLS connection. These fields focus on the TLS protocol itself and intentionally avoids in-depth analysis of the related x.509 certificate files.
		/// </summary>
		[DataMember(Name = "tls")]
		public Tls Tls { get; set; }

		/// <summary>
		/// URL fields provide support for complete or partial URLs, and supports the breaking down into scheme, domain, path, and so on.
		/// </summary>
		[DataMember(Name = "url")]
		public Url Url { get; set; }

		/// <summary>
		/// The user fields describe information about the user that is relevant to the event.<para/><para/>Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// The user_agent fields normally come from a browser request.<para/><para/>They often show up in web service logs coming from the parsed user agent string.
		/// </summary>
		[DataMember(Name = "user_agent")]
		public UserAgent UserAgent { get; set; }

		/// <summary>
		/// The vulnerability fields describe information about a vulnerability that is relevant to an event.
		/// </summary>
		[DataMember(Name = "vulnerability")]
		public Vulnerability Vulnerability { get; set; }

		/// <summary>
		/// Date/time when the event originated.<para/><para/>This is the date/time extracted from the event, typically representing when the event was generated by the source.<para/><para/>If the event source has no original timestamp, this value is typically populated by the first time the event was received by the pipeline.<para/><para/>Required field for all events.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>2016-05-23T08:05:34.853Z</example>
		[DataMember(Name = "@timestamp")]
		public DateTimeOffset? Timestamp { get; set; }

		/// <summary>
		/// Custom key/value pairs.<para/><para/>Can be used to add meta information to events. Should not contain nested objects. All values are stored as keyword.<para/><para/>Example: `docker` and `k8s` labels.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>{\"application\": \"foo-bar\", \"env\": \"production\"}</example>
		[DataMember(Name = "labels")]
		public IDictionary<string, string> Labels { get; set; }

		/// <summary>
		/// For log events the message field contains the log message, optimized for viewing in a log viewer.<para/><para/>For structured logs without an original message field, other fields can be concatenated to form a human-readable summary of the event.<para/><para/>If multiple messages exist, they can be combined into one message.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>Hello World</example>
		[DataMember(Name = "message")]
		public string Message { get; set; }

		/// <summary>
		/// List of keywords used to tag each event.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>["production","env2"]</example>
		[DataMember(Name = "tags")]
		public string[] Tags { get; set; }

		/// <summary>
		/// Span property.
		/// </summary>
		[DataMember(Name = "span")]
		public Span Span { get; set; }

		/// <summary>
		/// Distributed tracing makes it possible to analyze performance throughout a microservice architecture all in one view. This is accomplished by tracing all of the requests - from the initial web request in the front-end service - to queries made through multiple back-end services.<para/>Trace property.
		/// </summary>
		[DataMember(Name = "trace")]
		public Trace Trace { get; set; }

		/// <summary>
		/// Distributed tracing makes it possible to analyze performance throughout a microservice architecture all in one view. This is accomplished by tracing all of the requests - from the initial web request in the front-end service - to queries made through multiple back-end services.<para/>Transaction property.
		/// </summary>
		[DataMember(Name = "transaction")]
		public Transaction Transaction { get; set; }

    }

	/// <summary>
	/// Span, property of <see cref="Base" />
	/// </summary>
	public class Span
	{
		/// <summary>
		/// Unique identifier of the span within the scope of its trace.<para/><para/>A span represents an operation within a transaction, such as a request to another service, or a database query.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>3ff9a8981b7ccd5a</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

	}

	/// <summary>
	/// Trace, property of <see cref="Base" />
	/// </summary>
	public class Trace
	{
		/// <summary>
		/// Unique identifier of the trace.<para/><para/>A trace groups multiple events like transactions that belong together. For example, a user request handled by multiple inter-connected services.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>4bf92f3577b34da6a3ce929d0e0e4736</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

	}

	/// <summary>
	/// Transaction, property of <see cref="Base" />
	/// </summary>
	public class Transaction
	{
		/// <summary>
		/// Unique identifier of the transaction within the scope of its trace.<para/><para/>A transaction is the highest level of work measured within a service, such as a request to a server.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>00f067aa0ba902b7</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

	}


	/// <summary>
	/// Build, property of <see cref="Agent" />
	/// </summary>
	public class AgentBuild
	{
		/// <summary>
		/// Extended build information for the agent.<para/><para/>This field is intended to contain any build information that a data source may provide, no specific formatting is required.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>metricbeat version 7.6.0 (amd64), libbeat 7.6.0 [6a23e8f8f30f5001ba344e4e54d8d9cb82cb107c built 2020-02-05 23:10:10 +0000 UTC]</example>
		[DataMember(Name = "original")]
		public string Original { get; set; }

	}
	/// <summary>
	/// The agent fields contain the data about the software entity, if any, that collects, detects, or observes events on a host, or takes measurements on a host.<para/><para/>Examples include Beats. Agents may also run on observers. ECS agent.* fields shall be populated with details of the agent running on the host or observer where the event happened or the measurement was taken.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-agent.html
	/// </summary>
	/// <remarks>
	/// Examples: In the case of Beats for logs, the agent.name is filebeat. For APM, it is the agent running in the app/service. The agent information does not change if data is sent through queuing systems like Kafka, Redis, or processing systems such as Logstash or APM Server.
	/// </remarks>
	public class Agent 
	{
		/// <summary>
		/// Build property.
		/// </summary>
		[DataMember(Name = "build")]
		public AgentBuild Build { get; set; }

		/// <summary>
		/// Ephemeral identifier of this agent (if one exists).<para/><para/>This id normally changes across restarts, but `agent.id` does not.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>8a4f500f</example>
		[DataMember(Name = "ephemeral_id")]
		public string EphemeralId { get; set; }

		/// <summary>
		/// Unique identifier of this agent (if one exists).<para/><para/>Example: For Beats this would be beat.id.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>8a4f500d</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Custom name of the agent.<para/><para/>This is a name that can be given to an agent. This can be helpful if for example two Filebeat instances are running on the same host but a human readable separation is needed on which Filebeat instance data is coming from.<para/><para/>If no name is given, the name is often left empty.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>foo</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Type of the agent.<para/><para/>The agent type always stays the same and should be given by the agent used. In case of Filebeat the agent would always be Filebeat also if two Filebeat instances are run on the same machine.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>filebeat</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Version of the agent.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>6.0.0-rc2</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// Organization, property of <see cref="As" />
	/// </summary>
	public class AsOrganization
	{
		/// <summary>
		/// Organization name.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Google LLC</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}
	/// <summary>
	/// An autonomous system (AS) is a collection of connected Internet Protocol (IP) routing prefixes under the control of one or more network operators on behalf of a single administrative entity or domain that presents a common, clearly defined routing policy to the internet.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-as.html
	/// </summary>
	public class As 
	{
		/// <summary>
		/// Organization property.
		/// </summary>
		[DataMember(Name = "organization")]
		public AsOrganization Organization { get; set; }

		/// <summary>
		/// Unique number allocated to the autonomous system. The autonomous system number (ASN) uniquely identifies each network on the Internet.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>15169</example>
		[DataMember(Name = "number")]
		public long? Number { get; set; }

	}

	/// <summary>
	/// Nat, property of <see cref="Client" />
	/// </summary>
	public class ClientNat
	{
		/// <summary>
		/// Translated IP of source based NAT sessions (e.g. internal client to internet).<para/><para/>Typically connections traversing load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Translated port of source based NAT sessions (e.g. internal client to internet).<para/><para/>Typically connections traversing load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

	}
	/// <summary>
	/// A client is defined as the initiator of a network connection for events regarding sessions, connections, or bidirectional flow records.<para/><para/>For TCP events, the client is the initiator of the TCP connection that sends the SYN packet(s). For other protocols, the client is generally the initiator or requestor in the network transaction. Some systems use the term "originator" to refer the client in TCP connections. The client fields describe details about the system acting as the client in the network event. Client fields are usually populated in conjunction with server fields. Client fields are generally not populated for packet-level events.<para/><para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-client.html
	/// </summary>
	public class Client 
	{
		/// <summary>
		/// Fields describing an Autonomous System (Internet routing prefix).
		/// </summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		/// <summary>
		/// Fields describing a location.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Nat property.
		/// </summary>
		[DataMember(Name = "nat")]
		public ClientNat Nat { get; set; }

		/// <summary>
		/// Fields to describe the user relevant to the event.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Some event client addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/><para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		/// <summary>
		/// Bytes sent from the client to the server.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>184</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Client domain.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// IP address of the client (IPv4 or IPv6).
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// MAC address of the client.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// Packets sent from the client to the server.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>12</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		/// <summary>
		/// Port of the client.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// The highest registered client domain, stripped of the subdomain.<para/><para/>For example, the registered domain for "foo.example.com" is "example.com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>example.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for example.com is "com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

	}

	/// <summary>
	/// Account, property of <see cref="Cloud" />
	/// </summary>
	public class CloudAccount
	{
		/// <summary>
		/// The cloud account or organization id used to identify different entities in a multi-tenant environment.<para/><para/>Examples: AWS account id, Google Cloud ORG Id, or other unique identifier.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>666777888999</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// The cloud account name or alias used to identify different entities in a multi-tenant environment.<para/><para/>Examples: AWS account name, Google Cloud ORG display name.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>elastic-dev</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}
	/// <summary>
	/// Instance, property of <see cref="Cloud" />
	/// </summary>
	public class CloudInstance
	{
		/// <summary>
		/// Instance ID of the host machine.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>i-1234567890abcdef0</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Instance name of the host machine.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}
	/// <summary>
	/// Machine, property of <see cref="Cloud" />
	/// </summary>
	public class CloudMachine
	{
		/// <summary>
		/// Machine type of the host machine.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>t2.medium</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}
	/// <summary>
	/// Project, property of <see cref="Cloud" />
	/// </summary>
	public class CloudProject
	{
		/// <summary>
		/// The cloud project identifier.<para/><para/>Examples: Google Cloud Project id, Azure Project id.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>my-project</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// The cloud project name.<para/><para/>Examples: Google Cloud Project name, Azure Project name.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>my project</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}
	/// <summary>
	/// Fields related to the cloud or infrastructure the events are coming from.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-cloud.html
	/// </summary>
	/// <remarks>
	/// Examples: If Metricbeat is running on an EC2 host and fetches data from its host, the cloud info contains the data about this machine. If Metricbeat runs on a remote machine outside the cloud and fetches data from a service running in the cloud, the field contains cloud data from the machine the service is running on.
	/// </remarks>
	public class Cloud 
	{
		/// <summary>
		/// Account property.
		/// </summary>
		[DataMember(Name = "account")]
		public CloudAccount Account { get; set; }

		/// <summary>
		/// Instance property.
		/// </summary>
		[DataMember(Name = "instance")]
		public CloudInstance Instance { get; set; }

		/// <summary>
		/// Machine property.
		/// </summary>
		[DataMember(Name = "machine")]
		public CloudMachine Machine { get; set; }

		/// <summary>
		/// Project property.
		/// </summary>
		[DataMember(Name = "project")]
		public CloudProject Project { get; set; }

		/// <summary>
		/// Availability zone in which this host is running.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>us-east-1c</example>
		[DataMember(Name = "availability_zone")]
		public string AvailabilityZone { get; set; }

		/// <summary>
		/// Name of the cloud provider. Example values are aws, azure, gcp, or digitalocean.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>aws</example>
		[DataMember(Name = "provider")]
		public string Provider { get; set; }

		/// <summary>
		/// Region in which this host is running.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>us-east-1</example>
		[DataMember(Name = "region")]
		public string Region { get; set; }

	}

	/// <summary>
	/// These fields contain information about binary code signatures.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-code_signature.html
	/// </summary>
	public class CodeSignature 
	{
		/// <summary>
		/// Boolean to capture if a signature is present.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>true</example>
		[DataMember(Name = "exists")]
		public bool? Exists { get; set; }

		/// <summary>
		/// Additional information about the certificate status.<para/><para/>This is useful for logging cryptographic errors with the certificate validity or trust status. Leave unpopulated if the validity or trust of the certificate was unchecked.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>ERROR_UNTRUSTED_ROOT</example>
		[DataMember(Name = "status")]
		public string Status { get; set; }

		/// <summary>
		/// Subject name of the code signer
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>Microsoft Corporation</example>
		[DataMember(Name = "subject_name")]
		public string SubjectName { get; set; }

		/// <summary>
		/// Stores the trust status of the certificate chain.<para/><para/>Validating the trust of the certificate chain may be complicated, and this field should only be populated by tools that actively check the status.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>true</example>
		[DataMember(Name = "trusted")]
		public bool? Trusted { get; set; }

		/// <summary>
		/// Boolean to capture if the digital signature is verified against the binary content.<para/><para/>Leave unpopulated if a certificate was unchecked.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>true</example>
		[DataMember(Name = "valid")]
		public bool? Valid { get; set; }

	}

	/// <summary>
	/// Image, property of <see cref="Container" />
	/// </summary>
	public class ContainerImage
	{
		/// <summary>
		/// Name of the image the container was built on.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Container image tags.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "tag")]
		public string[] Tag { get; set; }

	}
	/// <summary>
	/// Container fields are used for meta information about the specific container that is the source of information.<para/><para/>These fields help correlate data based containers from any runtime.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-container.html
	/// </summary>
	public class Container 
	{
		/// <summary>
		/// Image property.
		/// </summary>
		[DataMember(Name = "image")]
		public ContainerImage Image { get; set; }

		/// <summary>
		/// Unique container id.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Image labels.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "labels")]
		public IDictionary<string, string> Labels { get; set; }

		/// <summary>
		/// Container name.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Runtime managing this container.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>docker</example>
		[DataMember(Name = "runtime")]
		public string Runtime { get; set; }

	}

	/// <summary>
	/// Nat, property of <see cref="Destination" />
	/// </summary>
	public class DestinationNat
	{
		/// <summary>
		/// Translated ip of destination based NAT sessions (e.g. internet to private DMZ)<para/><para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Port the source session is translated to by NAT Device.<para/><para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

	}
	/// <summary>
	/// Destination fields describe details about the destination of a packet/event.<para/><para/>Destination fields are usually populated in conjunction with source fields.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-destination.html
	/// </summary>
	public class Destination 
	{
		/// <summary>
		/// Fields describing an Autonomous System (Internet routing prefix).
		/// </summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		/// <summary>
		/// Fields describing a location.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Nat property.
		/// </summary>
		[DataMember(Name = "nat")]
		public DestinationNat Nat { get; set; }

		/// <summary>
		/// Fields to describe the user relevant to the event.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Some event destination addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/><para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		/// <summary>
		/// Bytes sent from the destination to the source.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>184</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Destination domain.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// IP address of the destination (IPv4 or IPv6).
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// MAC address of the destination.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// Packets sent from the destination to the source.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>12</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		/// <summary>
		/// Port of the destination.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// The highest registered destination domain, stripped of the subdomain.<para/><para/>For example, the registered domain for "foo.example.com" is "example.com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>example.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for example.com is "com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

	}

	/// <summary>
	/// These fields contain information about code libraries dynamically loaded into processes.<para/><para/>Many operating systems refer to "shared code libraries" with different names, but this field set refers to all of the following:<para/><para/>* Dynamic-link library (`.dll`) commonly used on Windows<para/><para/>* Shared Object (`.so`) commonly used on Unix-like operating systems<para/><para/>* Dynamic library (`.dylib`) commonly used on macOS
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-dll.html
	/// </summary>
	public class Dll 
	{
		/// <summary>
		/// These fields contain information about binary code signatures.
		/// </summary>
		[DataMember(Name = "codesignature")]
		public CodeSignature CodeSignature { get; set; }

		/// <summary>
		/// Hashes, usually file hashes.
		/// </summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		/// <summary>
		/// These fields contain Windows Portable Executable (PE) metadata.
		/// </summary>
		[DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		/// <summary>
		/// Name of the library.<para/><para/>This generally maps to the name of the file on disk.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>kernel32.dll</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Full file path of the library.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>C:\\Windows\\System32\\kernel32.dll</example>
		[DataMember(Name = "path")]
		public string Path { get; set; }

	}

	/// <summary>
	/// Answers, property of <see cref="Dns" />
	/// </summary>
	public class DnsAnswers
	{
		/// <summary>
		/// The class of DNS data contained in this resource record.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>IN</example>
		[DataMember(Name = "class")]
		public string Class { get; set; }

		/// <summary>
		/// The data describing the resource.<para/><para/>The meaning of this data depends on the type and class of the resource record.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>10.10.10.10</example>
		[DataMember(Name = "data")]
		public string Data { get; set; }

		/// <summary>
		/// The domain name to which this resource record pertains.<para/><para/>If a chain of CNAME is being resolved, each answer's `name` should be the one that corresponds with the answer's `data`. It should not simply be the original `question.name` repeated.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>www.example.com</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The time interval in seconds that this resource record may be cached before it should be discarded. Zero values mean that the data should not be cached.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>180</example>
		[DataMember(Name = "ttl")]
		public long? Ttl { get; set; }

		/// <summary>
		/// The type of data contained in this resource record.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>CNAME</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}
	/// <summary>
	/// Question, property of <see cref="Dns" />
	/// </summary>
	public class DnsQuestion
	{
		/// <summary>
		/// The class of records being queried.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>IN</example>
		[DataMember(Name = "class")]
		public string Class { get; set; }

		/// <summary>
		/// The name being queried.<para/><para/>If the name field contains non-printable characters (below 32 or above 126), those characters should be represented as escaped base 10 integers (\DDD). Back slashes and quotes should be escaped. Tabs, carriage returns, and line feeds should be converted to \t, \r, and \n respectively.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>www.example.com</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The highest registered domain, stripped of the subdomain.<para/><para/>For example, the registered domain for "foo.example.com" is "example.com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>example.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The subdomain is all of the labels under the registered_domain.<para/><para/>If the domain has multiple levels of subdomain, such as "sub2.sub1.example.com", the subdomain field should contain "sub2.sub1", with no trailing period.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>www</example>
		[DataMember(Name = "subdomain")]
		public string Subdomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for example.com is "com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

		/// <summary>
		/// The type of record being queried.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>AAAA</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}
	/// <summary>
	/// Fields describing DNS queries and answers.<para/><para/>DNS events should either represent a single DNS query prior to getting answers (`dns.type:query`) or they should represent a full exchange and contain the query details as well as all of the answers that were provided for this query (`dns.type:answer`).
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-dns.html
	/// </summary>
	public class Dns 
	{
		/// <summary>
		/// An array containing an object for each answer section returned by the server.<para/><para/>The main keys that should be present in these objects are defined by ECS. Records that have more information may contain more keys than what ECS defines.<para/><para/>Not all DNS data sources give all details about DNS answers. At minimum, answer objects must contain the `data` key. If more information is available, map as much of it to ECS as possible, and add any additional fields to the answer objects as custom fields.
		/// </summary>
		[DataMember(Name = "answers")]
		public DnsAnswers[] Answers { get; set; }

		/// <summary>
		/// Question property.
		/// </summary>
		[DataMember(Name = "question")]
		public DnsQuestion Question { get; set; }

		/// <summary>
		/// Array of 2 letter DNS header flags.<para/><para/>Expected values are: AA, TC, RD, RA, AD, CD, DO.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["RD","RA"]</example>
		[DataMember(Name = "header_flags")]
		public string[] HeaderFlags { get; set; }

		/// <summary>
		/// The DNS packet identifier assigned by the program that generated the query. The identifier is copied to the response.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>62111</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// The DNS operation code that specifies the kind of query in the message. This value is set by the originator of a query and copied into the response.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>QUERY</example>
		[DataMember(Name = "op_code")]
		public string OpCode { get; set; }

		/// <summary>
		/// Array containing all IPs seen in `answers.data`.<para/><para/>The `answers` array can be difficult to use, because of the variety of data formats it can contain. Extracting all IP addresses seen in there to `dns.resolved_ip` makes it possible to index them as IP addresses, and makes them easier to visualize and query for.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["10.10.10.10","10.10.10.11"]</example>
		[DataMember(Name = "resolved_ip")]
		public string[] ResolvedIp { get; set; }

		/// <summary>
		/// The DNS response code.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>NOERROR</example>
		[DataMember(Name = "response_code")]
		public string ResponseCode { get; set; }

		/// <summary>
		/// The type of DNS event captured, query or answer.<para/><para/>If your source of DNS events only gives you DNS queries, you should only create dns events of type `dns.type:query`.<para/><para/>If your source of DNS events gives you answers as well, you should create one event per query (optionally as soon as the query is seen). And a second event containing all query details as well as an array of answers.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>answer</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}

	/// <summary>
	/// Meta-information specific to ECS.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-ecs.html
	/// </summary>
	public class Ecs 
	{
		/// <summary>
		/// ECS version this event conforms to. `ecs.version` is a required field and must exist in all events.<para/><para/>When querying across multiple indices -- which may conform to slightly different ECS versions -- this field lets integrations adjust to the schema version of the events.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>1.0.0</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// These fields can represent errors of any kind.<para/><para/>Use them for errors that happen while fetching events or in cases where the event itself contains an error.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-error.html
	/// </summary>
	public class Error 
	{
		/// <summary>
		/// Error code describing the error.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "code")]
		public string Code { get; set; }

		/// <summary>
		/// Unique identifier for the error.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Error message.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "message")]
		public string Message { get; set; }

		/// <summary>
		/// The stack trace of this error in plain text.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "stack_trace")]
		public string StackTrace { get; set; }

		/// <summary>
		/// The type of the error, for example the class name of the exception.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>java.lang.NullPointerException</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}

	/// <summary>
	/// This is one of four ECS Categorization Fields, and indicates the second level in the ECS category hierarchy.<para/><para/>`event.category` represents the "big buckets" of ECS categories. For example, filtering on `event.category:process` yields all events relating to process activity. This field is closely related to `event.type`, which is used as a subcategory.<para/><para/>This field is an array. This will allow proper categorization of some events that fall in multiple categories.
    /// </summary>
	public class EventCategory
	{
        /// <summary>
        /// Events in this category are related to the challenge and response process in which credentials are supplied and verified to allow the creation of a session. Common sources for these logs are Windows event logs and ssh logs. Visualize and analyze events in this category to look for failed logins, and other authentication-related activity.
		/// </summary>
		public const string Authentication = "authentication";

        /// <summary>
        /// The database category denotes events and metrics relating to a data storage and retrieval system. Note that use of this category is not limited to relational database systems. Examples include event logs from MS SQL, MySQL, Elasticsearch, MongoDB, etc. Use this category to visualize and analyze database activity such as accesses and changes.
		/// </summary>
		public const string Database = "database";

        /// <summary>
        /// Events in the driver category have to do with operating system device drivers and similar software entities such as Windows drivers, kernel extensions, kernel modules, etc.<para/><para/>Use events and metrics in this category to visualize and analyze driver-related activity and status on hosts.
		/// </summary>
		public const string Driver = "driver";

        /// <summary>
        /// Relating to a set of information that has been created on, or has existed on a filesystem. Use this category of events to visualize and analyze the creation, access, and deletions of files. Events in this category can come from both host-based and network-based sources. An example source of a network-based detection of a file transfer would be the Zeek file.log.
		/// </summary>
		public const string File = "file";

        /// <summary>
        /// Use this category to visualize and analyze information such as host inventory or host lifecycle events.<para/><para/>Most of the events in this category can usually be observed from the outside, such as from a hypervisor or a control plane's point of view. Some can also be seen from within, such as "start" or "end".<para/><para/>Note that this category is for information about hosts themselves; it is not meant to capture activity "happening on a host".
		/// </summary>
		public const string Host = "host";

        /// <summary>
        /// Identity and access management (IAM) events relating to users, groups, and administration. Use this category to visualize and analyze IAM-related logs and data from active directory, LDAP, Okta, Duo, and other IAM systems.
		/// </summary>
		public const string Iam = "iam";

        /// <summary>
        /// Relating to intrusion detections from IDS/IPS systems and functions, both network and host-based. Use this category to visualize and analyze intrusion detection alerts from systems such as Snort, Suricata, and Palo Alto threat detections.
		/// </summary>
		public const string IntrusionDetection = "intrusion_detection";

        /// <summary>
        /// Malware detection events and alerts. Use this category to visualize and analyze malware detections from EDR/EPP systems such as Elastic Endpoint Security, Symantec Endpoint Protection, Crowdstrike, and network IDS/IPS systems such as Suricata, or other sources of malware-related events such as Palo Alto Networks threat logs and Wildfire logs.
		/// </summary>
		public const string Malware = "malware";

        /// <summary>
        /// Relating to all network activity, including network connection lifecycle, network traffic, and essentially any event that includes an IP address. Many events containing decoded network protocol transactions fit into this category. Use events in this category to visualize or analyze counts of network ports, protocols, addresses, geolocation information, etc.
		/// </summary>
		public const string Network = "network";

        /// <summary>
        /// Relating to software packages installed on hosts. Use this category to visualize and analyze inventory of software installed on various hosts, or to determine host vulnerability in the absence of vulnerability scan data.
		/// </summary>
		public const string Package = "package";

        /// <summary>
        /// Use this category of events to visualize and analyze process-specific information such as lifecycle events or process ancestry.
		/// </summary>
		public const string Process = "process";

        /// <summary>
        /// Relating to web server access. Use this category to create a dashboard of web server/proxy activity from apache, IIS, nginx web servers, etc. Note: events from network observers such as Zeek http log may also be included in this category.
		/// </summary>
		public const string Web = "web";

	}

	/// <summary>
	/// This is one of four ECS Categorization Fields, and indicates the highest level in the ECS category hierarchy.<para/><para/>`event.kind` gives high-level information about what type of information the event contains, without being specific to the contents of the event. For example, values of this field distinguish alert events from metric events.<para/><para/>The value of this field can be used to inform how these kinds of events should be handled. They may warrant different retention, different access control, it may also help understand whether the data coming in at a regular interval or not.
    /// </summary>
	public class EventKind
	{
        /// <summary>
        /// This value indicates an event that describes an alert or notable event, triggered by a detection rule.<para/><para/>`event.kind:alert` is often populated for events coming from firewalls, intrusion detection systems, endpoint detection and response systems, and so on.
		/// </summary>
		public const string Alert = "alert";

        /// <summary>
        /// This value is the most general and most common value for this field. It is used to represent events that indicate that something happened.
		/// </summary>
		public const string Event = "event";

        /// <summary>
        /// This value is used to indicate that this event describes a numeric measurement taken at given point in time.<para/><para/>Examples include CPU utilization, memory usage, or device temperature.<para/><para/>Metric events are often collected on a predictable frequency, such as once every few seconds, or once a minute, but can also be used to describe ad-hoc numeric metric queries.
		/// </summary>
		public const string Metric = "metric";

        /// <summary>
        /// The state value is similar to metric, indicating that this event describes a measurement taken at given point in time, except that the measurement does not result in a numeric value, but rather one of a fixed set of categorical values that represent conditions or states.<para/><para/>Examples include periodic events reporting Elasticsearch cluster state (green/yellow/red), the state of a TCP connection (open, closed, fin_wait, etc.), the state of a host with respect to a software vulnerability (vulnerable, not vulnerable), and the state of a system regarding compliance with a regulatory standard (compliant, not compliant).<para/><para/>Note that an event that describes a change of state would not use `event.kind:state`, but instead would use 'event.kind:event' since a state change fits the more general event definition of something that happened.<para/><para/>State events are often collected on a predictable frequency, such as once every few seconds, once a minute, once an hour, or once a day, but can also be used to describe ad-hoc state queries.
		/// </summary>
		public const string State = "state";

        /// <summary>
        /// This value indicates that an error occurred during the ingestion of this event, and that event data may be missing, inconsistent, or incorrect. `event.kind:pipeline_error` is often associated with parsing errors.
		/// </summary>
		public const string PipelineError = "pipeline_error";

        /// <summary>
        /// This value is used by the Elastic SIEM app to denote an Elasticsearch document that was created by a SIEM detection engine rule.<para/><para/>A signal will typically trigger a notification that something meaningful happened and should be investigated.<para/><para/>Usage of this value is reserved, and pipelines should not populate `event.kind` with the value "signal".
		/// </summary>
		public const string Signal = "signal";

	}

	/// <summary>
	/// This is one of four ECS Categorization Fields, and indicates the lowest level in the ECS category hierarchy.<para/><para/>`event.outcome` simply denotes whether the event represents a success or a failure from the perspective of the entity that produced the event.<para/><para/>Note that when a single transaction is described in multiple events, each event may populate different values of `event.outcome`, according to their perspective.<para/><para/>Also note that in the case of a compound event (a single event that contains multiple logical events), this field should be populated with the value that best captures the overall success or failure from the perspective of the event producer.<para/><para/>Further note that not all events will have an associated outcome. For example, this field is generally not populated for metric events, events with `event.type:info`, or any events for which an outcome does not make logical sense.
    /// </summary>
	public class EventOutcome
	{
        /// <summary>
        /// Indicates that this event describes a failed result. A common example is `event.category:file AND event.type:access AND event.outcome:failure` to indicate that a file access was attempted, but was not successful.
		/// </summary>
		public const string Failure = "failure";

        /// <summary>
        /// Indicates that this event describes a successful result. A common example is `event.category:file AND event.type:create AND event.outcome:success` to indicate that a file was successfully created.
		/// </summary>
		public const string Success = "success";

        /// <summary>
        /// Indicates that this event describes only an attempt for which the result is unknown from the perspective of the event producer. For example, if the event contains information only about the request side of a transaction that results in a response, populating `event.outcome:unknown` in the request event is appropriate. The unknown value should not be used when an outcome doesn't make logical sense for the event. In such cases `event.outcome` should not be populated.
		/// </summary>
		public const string Unknown = "unknown";

	}

	/// <summary>
	/// This is one of four ECS Categorization Fields, and indicates the third level in the ECS category hierarchy.<para/><para/>`event.type` represents a categorization "sub-bucket" that, when used along with the `event.category` field values, enables filtering events down to a level appropriate for single visualization.<para/><para/>This field is an array. This will allow proper categorization of some events that fall in multiple event types.
    /// </summary>
	public class EventType
	{
        /// <summary>
        /// The access event type is used for the subset of events within a category that indicate that something was accessed. Common examples include `event.category:database AND event.type:access`, or `event.category:file AND event.type:access`. Note for file access, both directory listings and file opens should be included in this subcategory. You can further distinguish access operations using the ECS `event.action` field.
		/// </summary>
		public const string Access = "access";

        /// <summary>
        /// The admin event type is used for the subset of events within a category that are related to admin objects. For example, administrative changes within an IAM framework that do not specifically affect a user or group (e.g., adding new applications to a federation solution or connecting discrete forests in Active Directory) would fall into this subcategory. Common example: `event.category:iam AND event.type:change AND event.type:admin`. You can further distinguish admin operations using the ECS `event.action` field.
		/// </summary>
		public const string Admin = "admin";

        /// <summary>
        /// The allowed event type is used for the subset of events within a category that indicate that something was allowed. Common examples include `event.category:network AND event.type:connection AND event.type:allowed` (to indicate a network firewall event for which the firewall disposition was to allow the connection to complete) and `event.category:intrusion_detection AND event.type:allowed` (to indicate a network intrusion prevention system event for which the IPS disposition was to allow the connection to complete). You can further distinguish allowed operations using the ECS `event.action` field, populating with values of your choosing, such as "allow", "detect", or "pass".
		/// </summary>
		public const string Allowed = "allowed";

        /// <summary>
        /// The change event type is used for the subset of events within a category that indicate that something has changed. If semantics best describe an event as modified, then include them in this subcategory. Common examples include `event.category:process AND event.type:change`, and `event.category:file AND event.type:change`. You can further distinguish change operations using the ECS `event.action` field.
		/// </summary>
		public const string Change = "change";

        /// <summary>
        /// Used primarily with `event.category:network` this value is used for the subset of network traffic that includes sufficient information for the event to be included in flow or connection analysis. Events in this subcategory will contain at least source and destination IP addresses, source and destination TCP/UDP ports, and will usually contain counts of bytes and/or packets transferred. Events in this subcategory may contain unidirectional or bidirectional information, including summary information. Use this subcategory to visualize and analyze network connections. Flow analysis, including Netflow, IPFIX, and other flow-related events fit in this subcategory. Note that firewall events from many Next-Generation Firewall (NGFW) devices will also fit into this subcategory.  A common filter for flow/connection information would be `event.category:network AND event.type:connection AND event.type:end` (to view or analyze all completed network connections, ignoring mid-flow reports). You can further distinguish connection events using the ECS `event.action` field, populating with values of your choosing, such as "timeout", or "reset".
		/// </summary>
		public const string Connection = "connection";

        /// <summary>
        /// The "creation" event type is used for the subset of events within a category that indicate that something was created. A common example is `event.category:file AND event.type:creation`.
		/// </summary>
		public const string Creation = "creation";

        /// <summary>
        /// The deletion event type is used for the subset of events within a category that indicate that something was deleted. A common example is `event.category:file AND event.type:deletion` to indicate that a file has been deleted.
		/// </summary>
		public const string Deletion = "deletion";

        /// <summary>
        /// The denied event type is used for the subset of events within a category that indicate that something was denied. Common examples include `event.category:network AND event.type:denied` (to indicate a network firewall event for which the firewall disposition was to deny the connection) and `event.category:intrusion_detection AND event.type:denied` (to indicate a network intrusion prevention system event for which the IPS disposition was to deny the connection to complete). You can further distinguish denied operations using the ECS `event.action` field, populating with values of your choosing, such as "blocked", "dropped", or "quarantined".
		/// </summary>
		public const string Denied = "denied";

        /// <summary>
        /// The end event type is used for the subset of events within a category that indicate something has ended. A common example is `event.category:process AND event.type:end`.
		/// </summary>
		public const string End = "end";

        /// <summary>
        /// The error event type is used for the subset of events within a category that indicate or describe an error. A common example is `event.category:database AND event.type:error`. Note that pipeline errors that occur during the event ingestion process should not use this `event.type` value. Instead, they should use `event.kind:pipeline_error`.
		/// </summary>
		public const string Error = "error";

        /// <summary>
        /// The group event type is used for the subset of events within a category that are related to group objects. Common example: `event.category:iam AND event.type:creation AND event.type:group`. You can further distinguish group operations using the ECS `event.action` field.
		/// </summary>
		public const string Group = "group";

        /// <summary>
        /// The info event type is used for the subset of events within a category that indicate that they are purely informational, and don't report a state change, or any type of action. For example, an initial run of a file integrity monitoring system (FIM), where an agent reports all files under management, would fall into the "info" subcategory. Similarly, an event containing a dump of all currently running processes (as opposed to reporting that a process started/ended) would fall into the "info" subcategory. An additional common examples is `event.category:intrusion_detection AND event.type:info`.
		/// </summary>
		public const string Info = "info";

        /// <summary>
        /// The installation event type is used for the subset of events within a category that indicate that something was installed. A common example is `event.category:package` AND `event.type:installation`.
		/// </summary>
		public const string Installation = "installation";

        /// <summary>
        /// The protocol event type is used for the subset of events within a category that indicate that they contain protocol details or analysis, beyond simply identifying the protocol. Generally, network events that contain specific protocol details will fall into this subcategory. A common example is `event.category:network AND event.type:protocol AND event.type:connection AND event.type:end` (to indicate that the event is a network connection event sent at the end of a connection that also includes a protocol detail breakdown). Note that events that only indicate the name or id of the protocol should not use the protocol value. Further note that when the protocol subcategory is used, the identified protocol is populated in the ECS `network.protocol` field.
		/// </summary>
		public const string Protocol = "protocol";

        /// <summary>
        /// The start event type is used for the subset of events within a category that indicate something has started. A common example is `event.category:process AND event.type:start`.
		/// </summary>
		public const string Start = "start";

        /// <summary>
        /// The user event type is used for the subset of events within a category that are related to user objects. Common example: `event.category:iam AND event.type:deletion AND event.type:user`. You can further distinguish user operations using the ECS `event.action` field.
		/// </summary>
		public const string User = "user";

	}

	/// <summary>
	/// The event fields are used for context information about the log or metric event itself.<para/><para/>A log is defined as an event containing details of something that happened. Log events must include the time at which the thing happened. Examples of log events include a process starting on a host, a network packet being sent from a source to a destination, or a network connection between a client and a server being initiated or closed. A metric is defined as an event containing one or more numerical measurements and the time at which the measurement was taken. Examples of metric events include memory pressure measured on a host and device temperature. See the `event.kind` definition in this section for additional details about metric and state events.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-event.html
	/// </summary>
	public class Event 
	{
		/// <summary>
		/// The action captured by the event.<para/><para/>This describes the information in the event. It is more specific than `event.category`. Examples are `group-add`, `process-started`, `file-created`. The value is normally defined by the implementer.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>user-password-change</example>
		[DataMember(Name = "action")]
		public string Action { get; set; }

		/// <summary>
		/// This is one of four ECS Categorization Fields, and indicates the second level in the ECS category hierarchy.<para/><para/>`event.category` represents the "big buckets" of ECS categories. For example, filtering on `event.category:process` yields all events relating to process activity. This field is closely related to `event.type`, which is used as a subcategory.<para/><para/>This field is an array. This will allow proper categorization of some events that fall in multiple categories.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>authentication</example>
		[DataMember(Name = "category")]
		public string[] Category { get; set; }

		/// <summary>
		/// Identification code for this event, if one exists.<para/><para/>Some event sources use event codes to identify messages unambiguously, regardless of message language or wording adjustments over time. An example of this is the Windows Event ID.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>4648</example>
		[DataMember(Name = "code")]
		public string Code { get; set; }

		/// <summary>
		/// event.created contains the date/time when the event was first read by an agent, or by your pipeline.<para/><para/>This field is distinct from @timestamp in that @timestamp typically contain the time extracted from the original event.<para/><para/>In most situations, these two timestamps will be slightly different. The difference can be used to calculate the delay between your source generating an event, and the time when your agent first processed it. This can be used to monitor your agent's or pipeline's ability to keep up with your event source.<para/><para/>In case the two timestamps are identical, @timestamp should be used.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>2016-05-23T08:05:34.857Z</example>
		[DataMember(Name = "created")]
		public DateTimeOffset? Created { get; set; }

		/// <summary>
		/// Name of the dataset.<para/><para/>If an event source publishes more than one type of log or events (e.g. access log, error log), the dataset is used to specify which one the event comes from.<para/><para/>It's recommended but not required to start the dataset name with the module name, followed by a dot, then the dataset name.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>apache.access</example>
		[DataMember(Name = "dataset")]
		public string Dataset { get; set; }

		/// <summary>
		/// Duration of the event in nanoseconds.<para/><para/>If event.start and event.end are known this value should be the difference between the end and start time.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "duration")]
		public long? Duration { get; set; }

		/// <summary>
		/// event.end contains the date when the event ended or when the activity was last observed.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "end")]
		public DateTimeOffset? End { get; set; }

		/// <summary>
		/// Hash (perhaps logstash fingerprint) of raw field to be able to demonstrate log integrity.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>123456789012345678901234567890ABCD</example>
		[DataMember(Name = "hash")]
		public string Hash { get; set; }

		/// <summary>
		/// Unique ID to describe the event.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>8a4f500d</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Timestamp when an event arrived in the central data store.<para/><para/>This is different from `@timestamp`, which is when the event originally occurred.  It's also different from `event.created`, which is meant to capture the first time an agent saw the event.<para/><para/>In normal conditions, assuming no tampering, the timestamps should chronologically look like this: `@timestamp` < `event.created` < `event.ingested`.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>2016-05-23T08:05:35.101Z</example>
		[DataMember(Name = "ingested")]
		public DateTimeOffset? Ingested { get; set; }

		/// <summary>
		/// This is one of four ECS Categorization Fields, and indicates the highest level in the ECS category hierarchy.<para/><para/>`event.kind` gives high-level information about what type of information the event contains, without being specific to the contents of the event. For example, values of this field distinguish alert events from metric events.<para/><para/>The value of this field can be used to inform how these kinds of events should be handled. They may warrant different retention, different access control, it may also help understand whether the data coming in at a regular interval or not.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>alert</example>
		[DataMember(Name = "kind")]
		public string Kind { get; set; }

		/// <summary>
		/// Name of the module this data is coming from.<para/><para/>If your monitoring agent supports the concept of modules or plugins to process events of a given source (e.g. Apache logs), `event.module` should contain the name of this module.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>apache</example>
		[DataMember(Name = "module")]
		public string Module { get; set; }

		/// <summary>
		/// Raw text message of entire event. Used to demonstrate log integrity.<para/><para/>This field is not indexed and doc_values are disabled. It cannot be searched, but it can be retrieved from `_source`.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>Sep 19 08:26:10 host CEF:0&#124;Security&#124; threatmanager&#124;1.0&#124;100&#124; worm successfully stopped&#124;10&#124;src=10.0.0.1 dst=2.1.2.2spt=1232</example>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		/// <summary>
		/// This is one of four ECS Categorization Fields, and indicates the lowest level in the ECS category hierarchy.<para/><para/>`event.outcome` simply denotes whether the event represents a success or a failure from the perspective of the entity that produced the event.<para/><para/>Note that when a single transaction is described in multiple events, each event may populate different values of `event.outcome`, according to their perspective.<para/><para/>Also note that in the case of a compound event (a single event that contains multiple logical events), this field should be populated with the value that best captures the overall success or failure from the perspective of the event producer.<para/><para/>Further note that not all events will have an associated outcome. For example, this field is generally not populated for metric events, events with `event.type:info`, or any events for which an outcome does not make logical sense.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>success</example>
		[DataMember(Name = "outcome")]
		public string Outcome { get; set; }

		/// <summary>
		/// Source of the event.<para/><para/>Event transports such as Syslog or the Windows Event Log typically mention the source of an event. It can be the name of the software that generated the event (e.g. Sysmon, httpd), or of a subsystem of the operating system (kernel, Microsoft-Windows-Security-Auditing).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>kernel</example>
		[DataMember(Name = "provider")]
		public string Provider { get; set; }

		/// <summary>
		/// Reason why this event happened, according to the source.<para/><para/>This describes the why of a particular action or outcome captured in the event. Where `event.action` captures the action from the event, `event.reason` describes why that action was taken. For example, a web proxy with an `event.action` which denied the request may also populate `event.reason` with the reason why (e.g. `blocked site`).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Terminated an unexpected process</example>
		[DataMember(Name = "reason")]
		public string Reason { get; set; }

		/// <summary>
		/// Reference URL linking to additional information about this event.<para/><para/>This URL links to a static definition of the this event. Alert events, indicated by `event.kind:alert`, are a common use case for this field.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://system.example.com/event/#0001234</example>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		/// <summary>
		/// Risk score or priority of the event (e.g. security solutions). Use your system's original value here.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "risk_score")]
		public float? RiskScore { get; set; }

		/// <summary>
		/// Normalized risk score or priority of the event, on a scale of 0 to 100.<para/><para/>This is mainly useful if you use more than one system that assigns risk scores, and you want to see a normalized value across all systems.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "risk_score_norm")]
		public float? RiskScoreNorm { get; set; }

		/// <summary>
		/// Sequence number of the event.<para/><para/>The sequence number is a value published by some event sources, to make the exact ordering of events unambiguous, regardless of the timestamp precision.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "sequence")]
		public long? Sequence { get; set; }

		/// <summary>
		/// The numeric severity of the event according to your event source.<para/><para/>What the different severity values mean can be different between sources and use cases. It's up to the implementer to make sure severities are consistent across events from the same source.<para/><para/>The Syslog severity belongs in `log.syslog.severity.code`. `event.severity` is meant to represent the severity according to the event source (e.g. firewall, IDS). If the event source does not publish its own severity, you may optionally copy the `log.syslog.severity.code` to `event.severity`.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>7</example>
		[DataMember(Name = "severity")]
		public long? Severity { get; set; }

		/// <summary>
		/// event.start contains the date when the event started or when the activity was first observed.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "start")]
		public DateTimeOffset? Start { get; set; }

		/// <summary>
		/// This field should be populated when the event's timestamp does not include timezone information already (e.g. default Syslog timestamps). It's optional otherwise.<para/><para/>Acceptable timezone formats are: a canonical ID (e.g. "Europe/Amsterdam"), abbreviated (e.g. "EST") or an HH:mm differential (e.g. "-05:00").
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "timezone")]
		public string Timezone { get; set; }

		/// <summary>
		/// This is one of four ECS Categorization Fields, and indicates the third level in the ECS category hierarchy.<para/><para/>`event.type` represents a categorization "sub-bucket" that, when used along with the `event.category` field values, enables filtering events down to a level appropriate for single visualization.<para/><para/>This field is an array. This will allow proper categorization of some events that fall in multiple event types.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "type")]
		public string[] Type { get; set; }

		/// <summary>
		/// URL linking to an external system to continue investigation of this event.<para/><para/>This URL links to another system where in-depth investigation of the specific occurrence of this event can take place. Alert events, indicated by `event.kind:alert`, are a common use case for this field.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://mysystem.example.com/alert/5271dedb-f5b0-4218-87f0-4ac4870a38fe</example>
		[DataMember(Name = "url")]
		public string Url { get; set; }

	}

	/// <summary>
	/// A file is defined as a set of information that has been created on, or has existed on a filesystem.<para/><para/>File objects can be associated with host events, network events, and/or file events (e.g., those produced by File Integrity Monitoring [FIM] products or services). File fields provide details about the affected file associated with the event or metric.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-file.html
	/// </summary>
	public class File 
	{
		/// <summary>
		/// These fields contain information about binary code signatures.
		/// </summary>
		[DataMember(Name = "codesignature")]
		public CodeSignature CodeSignature { get; set; }

		/// <summary>
		/// Hashes, usually file hashes.
		/// </summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		/// <summary>
		/// These fields contain Windows Portable Executable (PE) metadata.
		/// </summary>
		[DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		/// <summary>
		/// These fields contain x509 certificate metadata.
		/// </summary>
		[DataMember(Name = "x509")]
		public X509 X509 { get; set; }

		/// <summary>
		/// Last time the file was accessed.<para/><para/>Note that not all filesystems keep track of access time.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "accessed")]
		public DateTimeOffset? Accessed { get; set; }

		/// <summary>
		/// Array of file attributes.<para/><para/>Attributes names will vary by platform. Here's a non-exhaustive list of values that are expected in this field: archive, compressed, directory, encrypted, execute, hidden, read, readonly, system, write.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["readonly","system"]</example>
		[DataMember(Name = "attributes")]
		public string[] Attributes { get; set; }

		/// <summary>
		/// File creation time.<para/><para/>Note that not all filesystems store the creation time.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "created")]
		public DateTimeOffset? Created { get; set; }

		/// <summary>
		/// Last time the file attributes or metadata changed.<para/><para/>Note that changes to the file content will update `mtime`. This implies `ctime` will be adjusted at the same time, since `mtime` is an attribute of the file.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "ctime")]
		public DateTimeOffset? Ctime { get; set; }

		/// <summary>
		/// Device that is the source of the file.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>sda</example>
		[DataMember(Name = "device")]
		public string Device { get; set; }

		/// <summary>
		/// Directory where the file is located. It should include the drive letter, when appropriate.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>/home/alice</example>
		[DataMember(Name = "directory")]
		public string Directory { get; set; }

		/// <summary>
		/// Drive letter where the file is located. This field is only relevant on Windows.<para/><para/>The value should be uppercase, and not include the colon.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>C</example>
		[DataMember(Name = "drive_letter")]
		public string DriveLetter { get; set; }

		/// <summary>
		/// File extension, excluding the leading dot.<para/><para/>Note that when the file name has multiple extensions (example.tar.gz), only the last one should be captured ("gz", not "tar.gz").
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>png</example>
		[DataMember(Name = "extension")]
		public string Extension { get; set; }

		/// <summary>
		/// Primary group ID (GID) of the file.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1001</example>
		[DataMember(Name = "gid")]
		public string Gid { get; set; }

		/// <summary>
		/// Primary group name of the file.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>alice</example>
		[DataMember(Name = "group")]
		public string Group { get; set; }

		/// <summary>
		/// Inode representing the file in the filesystem.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>256383</example>
		[DataMember(Name = "inode")]
		public string Inode { get; set; }

		/// <summary>
		/// MIME type should identify the format of the file or stream of bytes using https://www.iana.org/assignments/media-types/media-types.xhtml[IANA official types], where possible. When more than one type is applicable, the most specific type should be used.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "mime_type")]
		public string MimeType { get; set; }

		/// <summary>
		/// Mode of the file in octal representation.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>0640</example>
		[DataMember(Name = "mode")]
		public string Mode { get; set; }

		/// <summary>
		/// Last time the file content was modified.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "mtime")]
		public DateTimeOffset? Mtime { get; set; }

		/// <summary>
		/// Name of the file including the extension, without the directory.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>example.png</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// File owner's username.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>alice</example>
		[DataMember(Name = "owner")]
		public string Owner { get; set; }

		/// <summary>
		/// Full path to the file, including the file name. It should include the drive letter, when appropriate.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>/home/alice/example.png</example>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		/// <summary>
		/// File size in bytes.<para/><para/>Only relevant when `file.type` is "file".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>16384</example>
		[DataMember(Name = "size")]
		public long? Size { get; set; }

		/// <summary>
		/// Target path for symlinks.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "target_path")]
		public string TargetPath { get; set; }

		/// <summary>
		/// File type (file, dir, or symlink).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>file</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// The user ID (UID) or security identifier (SID) of the file owner.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1001</example>
		[DataMember(Name = "uid")]
		public string Uid { get; set; }

	}

	/// <summary>
	/// Geo fields can carry data about a specific location related to an event.<para/><para/>This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-geo.html
	/// </summary>
	public class Geo 
	{
		/// <summary>
		/// City name.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>Montreal</example>
		[DataMember(Name = "city_name")]
		public string CityName { get; set; }

		/// <summary>
		/// Name of the continent.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>North America</example>
		[DataMember(Name = "continent_name")]
		public string ContinentName { get; set; }

		/// <summary>
		/// Country ISO code.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>CA</example>
		[DataMember(Name = "country_iso_code")]
		public string CountryIsoCode { get; set; }

		/// <summary>
		/// Country name.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>Canada</example>
		[DataMember(Name = "country_name")]
		public string CountryName { get; set; }

		/// <summary>
		/// Longitude and latitude.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>{ "lon": -73.614830, "lat": 45.505918 }</example>
		[DataMember(Name = "location")]
		public Location Location { get; set; }

		/// <summary>
		/// User-defined description of a location, at the level of granularity they care about.<para/><para/>Could be the name of their data centers, the floor number, if this describes a local physical entity, city names.<para/><para/>Not typically used in automated geolocation.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>boston-dc</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Region ISO code.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>CA-QC</example>
		[DataMember(Name = "region_iso_code")]
		public string RegionIsoCode { get; set; }

		/// <summary>
		/// Region name.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>Quebec</example>
		[DataMember(Name = "region_name")]
		public string RegionName { get; set; }

	}

	/// <summary>
	/// The group fields are meant to represent groups that are relevant to the event.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-group.html
	/// </summary>
	public class Group 
	{
		/// <summary>
		/// Name of the directory the group is a member of.<para/><para/>For example, an LDAP or Active Directory domain name.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// Unique identifier for the group on the system/platform.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Name of the group.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// The hash fields represent different hash algorithms and their values.<para/><para/>Field names for common hashes (e.g. MD5, SHA1) are predefined. Add fields for other hashes by lowercasing the hash algorithm name and using underscore separators as appropriate (snake case, e.g. sha3_512).
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-hash.html
	/// </summary>
	public class Hash 
	{
		/// <summary>
		/// MD5 hash.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "md5")]
		public string Md5 { get; set; }

		/// <summary>
		/// SHA1 hash.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "sha1")]
		public string Sha1 { get; set; }

		/// <summary>
		/// SHA256 hash.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "sha256")]
		public string Sha256 { get; set; }

		/// <summary>
		/// SHA512 hash.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "sha512")]
		public string Sha512 { get; set; }

	}

	/// <summary>
	/// A host is defined as a general computing instance.<para/><para/>ECS host.* fields should be populated with details about the host on which the event happened, or from which the measurement was taken. Host types include hardware, virtual machines, Docker containers, and Kubernetes nodes.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-host.html
	/// </summary>
	public class Host 
	{
		/// <summary>
		/// Fields describing a location.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// OS fields contain information about the operating system.
		/// </summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }

		/// <summary>
		/// Fields to describe the user relevant to the event.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Operating system architecture.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>x86_64</example>
		[DataMember(Name = "architecture")]
		public string Architecture { get; set; }

		/// <summary>
		/// Name of the domain of which the host is a member.<para/><para/>For example, on Windows this could be the host's Active Directory domain or NetBIOS domain name. For Linux this could be the domain of the host's LDAP provider.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>CONTOSO</example>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// Hostname of the host.<para/><para/>It normally contains what the `hostname` command returns on the host machine.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "hostname")]
		public string Hostname { get; set; }

		/// <summary>
		/// Unique host id.<para/><para/>As hostname is not always unique, use values that are meaningful in your environment.<para/><para/>Example: The current usage of `beat.name`.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Host ip addresses.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "ip")]
		public string[] Ip { get; set; }

		/// <summary>
		/// Host mac addresses.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "mac")]
		public string[] Mac { get; set; }

		/// <summary>
		/// Name of the host.<para/><para/>It can contain what `hostname` returns on Unix systems, the fully qualified domain name, or a name specified by the user. The sender decides which value to use.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Type of host.<para/><para/>For Cloud providers this can be the machine type like `t2.medium`. If vm, this could be the container, for example, or other information meaningful in your environment.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Seconds the host has been up.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1325</example>
		[DataMember(Name = "uptime")]
		public long? Uptime { get; set; }

	}

	/// <summary>
	/// RequestBody, property of <see cref="HttpRequest" />
	/// </summary>
	public class RequestBody
	{
		/// <summary>
		/// Request Size in bytes of the request body.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>887</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Request The full HTTP request body.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Hello world</example>
		[DataMember(Name = "content")]
		public string Content { get; set; }

	}

	/// <summary>
	/// Request, property of <see cref="Http" />
	/// </summary>
	public class HttpRequest
	{
		/// <summary>
		/// Body property.
		/// </summary>		   
		[DataMember(Name = "body")]
		public RequestBody Body { get; set; }

		/// <summary>
		/// Total size in bytes of the request (body and headers).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1437</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// HTTP request method.<para/><para/>Prior to ECS 1.6.0 the following guidance was provided:<para/><para/>"The field value must be normalized to lowercase for querying."<para/><para/>As of ECS 1.6.0, the guidance is deprecated because the original case of the method may be useful in anomaly detection.  Original case will be mandated in ECS 2.0.0
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>GET, POST, PUT, PoST</example>
		[DataMember(Name = "method")]
		public string Method { get; set; }

		/// <summary>
		/// Referrer for this HTTP request.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://blog.example.com/</example>
		[DataMember(Name = "referrer")]
		public string Referrer { get; set; }

	}
	/// <summary>
	/// ResponseBody, property of <see cref="HttpResponse" />
	/// </summary>
	public class ResponseBody
	{
		/// <summary>
		/// Response Size in bytes of the response body.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>887</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Response The full HTTP response body.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Hello world</example>
		[DataMember(Name = "content")]
		public string Content { get; set; }

	}

	/// <summary>
	/// Response, property of <see cref="Http" />
	/// </summary>
	public class HttpResponse
	{
		/// <summary>
		/// Body property.
		/// </summary>		   
		[DataMember(Name = "body")]
		public ResponseBody Body { get; set; }

		/// <summary>
		/// Total size in bytes of the response (body and headers).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1437</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// HTTP response status code.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>404</example>
		[DataMember(Name = "status_code")]
		public long? StatusCode { get; set; }

	}
	/// <summary>
	/// Fields related to HTTP activity. Use the `url` field set to store the url of the request.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-http.html
	/// </summary>
	public class Http 
	{
		/// <summary>
		/// Request property.
		/// </summary>
		[DataMember(Name = "request")]
		public HttpRequest Request { get; set; }

		/// <summary>
		/// Response property.
		/// </summary>
		[DataMember(Name = "response")]
		public HttpResponse Response { get; set; }

		/// <summary>
		/// HTTP version.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1.1</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// The interface fields are used to record ingress and egress interface information when reported by an observer (e.g. firewall, router, load balancer) in the context of the observer handling a network connection.  In the case of a single observer interface (e.g. network sensor on a span port) only the observer.ingress information should be populated.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-interface.html
	/// </summary>
	public class Interface 
	{
		/// <summary>
		/// Interface alias as reported by the system, typically used in firewall implementations for e.g. inside, outside, or dmz logical interface naming.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>outside</example>
		[DataMember(Name = "alias")]
		public string Alias { get; set; }

		/// <summary>
		/// Interface ID as reported by an observer (typically SNMP interface ID).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>10</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Interface name as reported by the system.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>eth0</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// File, property of <see cref="Log" />
	/// </summary>
	public class LogFile
	{
		/// <summary>
		/// Full path to the log file this event came from, including the file name. It should include the drive letter, when appropriate.<para/><para/>If the event wasn't read from a log file, do not populate this field.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>/var/log/fun-times.log</example>
		[DataMember(Name = "path")]
		public string Path { get; set; }

	}
	/// <summary>
	/// OriginFile, property of <see cref="LogOrigin" />
	/// </summary>
	public class OriginFile
	{
		/// <summary>
		/// Origin The line number of the file containing the source code which originated the log event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>42</example>
		[DataMember(Name = "line")]
		public int? Line { get; set; }

		/// <summary>
		/// Origin The name of the file containing the source code which originated the log event.<para/><para/>Note that this field is not meant to capture the log file. The correct field to capture the log file is `log.file.path`.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Bootstrap.java</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// Origin, property of <see cref="Log" />
	/// </summary>
	public class LogOrigin
	{
		/// <summary>
		/// File property.
		/// </summary>		   
		[DataMember(Name = "file")]
		public OriginFile File { get; set; }

		/// <summary>
		/// The name of the function or method which originated the log event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>init</example>
		[DataMember(Name = "function")]
		public string Function { get; set; }

	}
	/// <summary>
	/// SyslogFacility, property of <see cref="LogSyslog" />
	/// </summary>
	public class SyslogFacility
	{
		/// <summary>
		/// Syslog The Syslog numeric facility of the log event, if available.<para/><para/>According to RFCs 5424 and 3164, this value should be an integer between 0 and 23.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>23</example>
		[DataMember(Name = "code")]
		public long? Code { get; set; }

		/// <summary>
		/// Syslog The Syslog text-based facility of the log event, if available.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>local7</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// SyslogSeverity, property of <see cref="LogSyslog" />
	/// </summary>
	public class SyslogSeverity
	{
		/// <summary>
		/// Syslog The Syslog numeric severity of the log event, if available.<para/><para/>If the event source publishing via Syslog provides a different numeric severity value (e.g. firewall, IDS), your source's numeric severity should go to `event.severity`. If the event source does not specify a distinct severity, you can optionally copy the Syslog severity to `event.severity`.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>3</example>
		[DataMember(Name = "code")]
		public long? Code { get; set; }

		/// <summary>
		/// Syslog The Syslog numeric severity of the log event, if available.<para/><para/>If the event source publishing via Syslog provides a different severity value (e.g. firewall, IDS), your source's text severity should go to `log.level`. If the event source does not specify a distinct severity, you can optionally copy the Syslog severity to `log.level`.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Error</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// Syslog, property of <see cref="Log" />
	/// </summary>
	public class LogSyslog
	{
		/// <summary>
		/// Facility property.
		/// </summary>		   
		[DataMember(Name = "facility")]
		public SyslogFacility Facility { get; set; }

		/// <summary>
		/// Severity property.
		/// </summary>		   
		[DataMember(Name = "severity")]
		public SyslogSeverity Severity { get; set; }

		/// <summary>
		/// Syslog numeric priority of the event, if available.<para/><para/>According to RFCs 5424 and 3164, the priority is 8 * facility + severity. This number is therefore expected to contain a value between 0 and 191.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>135</example>
		[DataMember(Name = "priority")]
		public long? Priority { get; set; }

	}
	/// <summary>
	/// Details about the event's logging mechanism or logging transport.<para/><para/>The log.* fields are typically populated with details about the logging mechanism used to create and/or transport the event. For example, syslog details belong under `log.syslog.*`.<para/><para/>The details specific to your event source are typically not logged under `log.*`, but rather in `event.*` or in other ECS fields.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-log.html
	/// </summary>
	public partial class Log 
	{
		/// <summary>
		/// File property.
		/// </summary>
		[DataMember(Name = "file")]
		public LogFile File { get; set; }

		/// <summary>
		/// Origin property.
		/// </summary>
		[DataMember(Name = "origin")]
		public LogOrigin Origin { get; set; }

		/// <summary>
		/// The Syslog metadata of the event, if the event was transmitted via Syslog. Please see RFCs 5424 or 3164.
		/// </summary>
		[DataMember(Name = "syslog")]
		public LogSyslog Syslog { get; set; }

		/// <summary>
		/// Original log level of the log event.<para/><para/>If the source of the event provides a log level or textual severity, this is the one that goes in `log.level`. If your source doesn't specify one, you may put your event transport's severity here (e.g. Syslog severity).<para/><para/>Some examples are `warn`, `err`, `i`, `informational`.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>error</example>
		[DataMember(Name = "level")]
		public string Level { get; set; }

		/// <summary>
		/// The name of the logger inside an application. This is usually the name of the class which initialized the logger, or can be a custom name.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>org.elasticsearch.bootstrap.Bootstrap</example>
		[DataMember(Name = "logger")]
		public string Logger { get; set; }

		/// <summary>
		/// This is the original log message and contains the full log message before splitting it up in multiple parts.<para/><para/>In contrast to the `message` field which can contain an extracted part of the log message, this field contains the original, full log message. It can have already some modifications applied like encoding or new lines removed to clean up the log message.<para/><para/>This field is not indexed and doc_values are disabled so it can't be queried but the value can be retrieved from `_source`.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>Sep 19 08:26:10 localhost My log</example>
		[DataMember(Name = "original")]
		public string Original { get; set; }

	}

	/// <summary>
	/// Inner, property of <see cref="Network" />
	/// </summary>
	public class NetworkInner
	{
		/// <summary>
		/// Fields to describe observed VLAN information.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }

	}
	/// <summary>
	/// The network is defined as the communication path over which a host or network event happens.<para/><para/>The network.* fields should be populated with details about the network activity associated with an event.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-network.html
	/// </summary>
	public class Network 
	{
		/// <summary>
		/// Network.inner fields are added in addition to network.vlan fields to describe  the innermost VLAN when q-in-q VLAN tagging is present. Allowed fields include  vlan.id and vlan.name. Inner vlan fields are typically used when sending traffic with multiple 802.1q encapsulations to a network sensor (e.g. Zeek, Wireshark.)
		/// </summary>
		[DataMember(Name = "inner")]
		public NetworkInner Inner { get; set; }

		/// <summary>
		/// Fields to describe observed VLAN information.
		/// </summary>
		[DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }

		/// <summary>
		/// A name given to an application level protocol. This can be arbitrarily assigned for things like microservices, but also apply to things like skype, icq, facebook, twitter. This would be used in situations where the vendor or service can be decoded such as from the source/dest IP owners, ports, or wire format.<para/><para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>aim</example>
		[DataMember(Name = "application")]
		public string Application { get; set; }

		/// <summary>
		/// Total bytes transferred in both directions.<para/><para/>If `source.bytes` and `destination.bytes` are known, `network.bytes` is their sum.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>368</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// A hash of source and destination IPs and ports, as well as the protocol used in a communication. This is a tool-agnostic standard to identify flows.<para/><para/>Learn more at https://github.com/corelight/community-id-spec.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1:hO+sN4H+MG5MY/8hIrXPqc4ZQz0=</example>
		[DataMember(Name = "community_id")]
		public string CommunityId { get; set; }

		/// <summary>
		/// Direction of the network traffic.<para/><para/>Recommended values are:<para/><para/>  * inbound<para/><para/>  * outbound<para/><para/>  * internal<para/><para/>  * external<para/><para/>  * unknown<para/><para/>When mapping events from a host-based monitoring context, populate this field from the host's point of view.<para/><para/>When mapping events from a network or perimeter-based monitoring context, populate this field from the point of view of your network perimeter.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>inbound</example>
		[DataMember(Name = "direction")]
		public string Direction { get; set; }

		/// <summary>
		/// Host IP address when the source IP address is the proxy.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>192.1.1.2</example>
		[DataMember(Name = "forwarded_ip")]
		public string ForwardedIp { get; set; }

		/// <summary>
		/// IANA Protocol Number (https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xhtml). Standardized list of protocols. This aligns well with NetFlow and sFlow related logs which use the IANA Protocol Number.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>6</example>
		[DataMember(Name = "iana_number")]
		public string IanaNumber { get; set; }

		/// <summary>
		/// Name given by operators to sections of their network.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Guest Wifi</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Total packets transferred in both directions.<para/><para/>If `source.packets` and `destination.packets` are known, `network.packets` is their sum.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>24</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		/// <summary>
		/// L7 Network protocol name. ex. http, lumberjack, transport protocol.<para/><para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>http</example>
		[DataMember(Name = "protocol")]
		public string Protocol { get; set; }

		/// <summary>
		/// Same as network.iana_number, but instead using the Keyword name of the transport layer (udp, tcp, ipv6-icmp, etc.)<para/><para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>tcp</example>
		[DataMember(Name = "transport")]
		public string Transport { get; set; }

		/// <summary>
		/// In the OSI Model this would be the Network Layer. ipv4, ipv6, ipsec, pim, etc<para/><para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>ipv4</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}

	/// <summary>
	/// Egress, property of <see cref="Observer" />
	/// </summary>
	public class ObserverEgress
	{
		/// <summary>
		/// Fields to describe observer interface information.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "interface")]
		public Interface Interface { get; set; }

		/// <summary>
		/// Fields to describe observed VLAN information.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }

		/// <summary>
		/// Network zone of outbound traffic as reported by the observer to categorize the destination area of egress  traffic, e.g. Internal, External, DMZ, HR, Legal, etc.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Public_Internet</example>
		[DataMember(Name = "zone")]
		public string Zone { get; set; }

	}
	/// <summary>
	/// Ingress, property of <see cref="Observer" />
	/// </summary>
	public class ObserverIngress
	{
		/// <summary>
		/// Fields to describe observer interface information.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "interface")]
		public Interface Interface { get; set; }

		/// <summary>
		/// Fields to describe observed VLAN information.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }

		/// <summary>
		/// Network zone of incoming traffic as reported by the observer to categorize the source area of ingress  traffic. e.g. internal, External, DMZ, HR, Legal, etc.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>DMZ</example>
		[DataMember(Name = "zone")]
		public string Zone { get; set; }

	}
	/// <summary>
	/// An observer is defined as a special network, security, or application device used to detect, observe, or create network, security, or application-related events and metrics.<para/><para/>This could be a custom hardware appliance or a server that has been configured to run special network, security, or application software. Examples include firewalls, web proxies, intrusion detection/prevention systems, network monitoring sensors, web application firewalls, data loss prevention systems, and APM servers. The observer.* fields shall be populated with details of the system, if any, that detects, observes and/or creates a network, security, or application event or metric. Message queues and ETL components used in processing events or metrics are not considered observers in ECS.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-observer.html
	/// </summary>
	public class Observer 
	{
		/// <summary>
		/// Observer.egress holds information like interface number and name, vlan, and zone information to  classify egress traffic.  Single armed monitoring such as a network sensor on a span port should  only use observer.ingress to categorize traffic.
		/// </summary>
		[DataMember(Name = "egress")]
		public ObserverEgress Egress { get; set; }

		/// <summary>
		/// Fields describing a location.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Observer.ingress holds information like interface number and name, vlan, and zone information to  classify ingress traffic.  Single armed monitoring such as a network sensor on a span port should  only use observer.ingress to categorize traffic.
		/// </summary>
		[DataMember(Name = "ingress")]
		public ObserverIngress Ingress { get; set; }

		/// <summary>
		/// OS fields contain information about the operating system.
		/// </summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }

		/// <summary>
		/// Hostname of the observer.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "hostname")]
		public string Hostname { get; set; }

		/// <summary>
		/// IP addresses of the observer.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "ip")]
		public string[] Ip { get; set; }

		/// <summary>
		/// MAC addresses of the observer
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "mac")]
		public string[] Mac { get; set; }

		/// <summary>
		/// Custom name of the observer.<para/><para/>This is a name that can be given to an observer. This can be helpful for example if multiple firewalls of the same model are used in an organization.<para/><para/>If no custom name is needed, the field can be left empty.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1_proxySG</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The product name of the observer.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>s200</example>
		[DataMember(Name = "product")]
		public string Product { get; set; }

		/// <summary>
		/// Observer serial number.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "serial_number")]
		public string SerialNumber { get; set; }

		/// <summary>
		/// The type of the observer the data is coming from.<para/><para/>There is no predefined list of observer types. Some examples are `forwarder`, `firewall`, `ids`, `ips`, `proxy`, `poller`, `sensor`, `APM server`.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>firewall</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Vendor name of the observer.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>Symantec</example>
		[DataMember(Name = "vendor")]
		public string Vendor { get; set; }

		/// <summary>
		/// Observer version.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// The organization fields enrich data with information about the company or entity the data is associated with.<para/><para/>These fields help you arrange or filter data stored in an index by one or multiple organizations.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-organization.html
	/// </summary>
	public class Organization 
	{
		/// <summary>
		/// Unique identifier for the organization.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Organization name.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// The OS fields contain information about the operating system.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-os.html
	/// </summary>
	public class Os 
	{
		/// <summary>
		/// OS family (such as redhat, debian, freebsd, windows).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>debian</example>
		[DataMember(Name = "family")]
		public string Family { get; set; }

		/// <summary>
		/// Operating system name, including the version or code name.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Mac OS Mojave</example>
		[DataMember(Name = "full")]
		public string Full { get; set; }

		/// <summary>
		/// Operating system kernel version as a raw string.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>4.4.0-112-generic</example>
		[DataMember(Name = "kernel")]
		public string Kernel { get; set; }

		/// <summary>
		/// Operating system name, without the version.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Mac OS X</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Operating system platform (such centos, ubuntu, windows).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>darwin</example>
		[DataMember(Name = "platform")]
		public string Platform { get; set; }

		/// <summary>
		/// Operating system version as a raw string.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>10.14.1</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// These fields contain information about an installed software package. It contains general information about a package, such as name, version or size. It also contains installation details, such as time or location.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-package.html
	/// </summary>
	public class Package 
	{
		/// <summary>
		/// Package architecture.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>x86_64</example>
		[DataMember(Name = "architecture")]
		public string Architecture { get; set; }

		/// <summary>
		/// Additional information about the build version of the installed package.<para/><para/>For example use the commit SHA of a non-released package.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>36f4f7e89dd61b0988b12ee000b98966867710cd</example>
		[DataMember(Name = "build_version")]
		public string BuildVersion { get; set; }

		/// <summary>
		/// Checksum of the installed package for verification.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>68b329da9893e34099c7d8ad5cb9c940</example>
		[DataMember(Name = "checksum")]
		public string Checksum { get; set; }

		/// <summary>
		/// Description of the package.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Open source programming language to build simple/reliable/efficient software.</example>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// Indicating how the package was installed, e.g. user-local, global.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>global</example>
		[DataMember(Name = "install_scope")]
		public string InstallScope { get; set; }

		/// <summary>
		/// Time when package was installed.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "installed")]
		public DateTimeOffset? Installed { get; set; }

		/// <summary>
		/// License under which the package was released.<para/><para/>Use a short name, e.g. the license identifier from SPDX License List where possible (https://spdx.org/licenses/).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Apache License 2.0</example>
		[DataMember(Name = "license")]
		public string License { get; set; }

		/// <summary>
		/// Package name
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>go</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Path where the package is installed.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>/usr/local/Cellar/go/1.12.9/</example>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		/// <summary>
		/// Home page or reference URL of the software in this package, if available.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://golang.org</example>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		/// <summary>
		/// Package size in bytes.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>62231</example>
		[DataMember(Name = "size")]
		public long? Size { get; set; }

		/// <summary>
		/// Type of package.<para/><para/>This should contain the package file type, rather than the package manager name. Examples: rpm, dpkg, brew, npm, gem, nupkg, jar.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>rpm</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Package version
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1.12.9</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// These fields contain Windows Portable Executable (PE) metadata.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-pe.html
	/// </summary>
	public class Pe 
	{
		/// <summary>
		/// CPU architecture target for the file.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>x64</example>
		[DataMember(Name = "architecture")]
		public string Architecture { get; set; }

		/// <summary>
		/// Internal company name of the file, provided at compile-time.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Microsoft Corporation</example>
		[DataMember(Name = "company")]
		public string Company { get; set; }

		/// <summary>
		/// Internal description of the file, provided at compile-time.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Paint</example>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// Internal version of the file, provided at compile-time.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>6.3.9600.17415</example>
		[DataMember(Name = "file_version")]
		public string FileVersion { get; set; }

		/// <summary>
		/// A hash of the imports in a PE file. An imphash -- or import hash -- can be used to fingerprint binaries even after recompilation or other code-level transformations have occurred, which would change more traditional hash values.<para/><para/>Learn more at https://www.fireeye.com/blog/threat-research/2014/01/tracking-malware-import-hashing.html.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>0c6803c4e922103c4dca5963aad36ddf</example>
		[DataMember(Name = "imphash")]
		public string Imphash { get; set; }

		/// <summary>
		/// Internal name of the file, provided at compile-time.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>MSPAINT.EXE</example>
		[DataMember(Name = "original_file_name")]
		public string OriginalFileName { get; set; }

		/// <summary>
		/// Internal product name of the file, provided at compile-time.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Microsoft® Windows® Operating System</example>
		[DataMember(Name = "product")]
		public string Product { get; set; }

	}

	/// <summary>
	/// Thread, property of <see cref="Process" />
	/// </summary>
	public class ProcessThread
	{
		/// <summary>
		/// Thread ID.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>4242</example>
		[DataMember(Name = "id")]
		public long? Id { get; set; }

		/// <summary>
		/// Thread name.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>thread-0</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}
	/// <summary>
	/// These fields contain information about a process.<para/><para/>These fields can help you correlate metrics information with a process id/name from a log message.  The `process.pid` often stays in the metric itself and is copied to the global field for correlation.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-process.html
	/// </summary>
	public class Process 
	{
		/// <summary>
		/// These fields contain information about binary code signatures.
		/// </summary>
		[DataMember(Name = "codesignature")]
		public CodeSignature CodeSignature { get; set; }

		/// <summary>
		/// Hashes, usually file hashes.
		/// </summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		/// <summary>
		/// These fields contain information about a process.
		/// </summary>
		[DataMember(Name = "parent")]
		public Process Parent { get; set; }

		/// <summary>
		/// These fields contain Windows Portable Executable (PE) metadata.
		/// </summary>
		[DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		/// <summary>
		/// Thread property.
		/// </summary>
		[DataMember(Name = "thread")]
		public ProcessThread Thread { get; set; }

		/// <summary>
		/// Array of process arguments, starting with the absolute path to the executable.<para/><para/>May be filtered to protect sensitive information.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["/usr/bin/ssh","-l","user","10.0.0.16"]</example>
		[DataMember(Name = "args")]
		public string[] Args { get; set; }

		/// <summary>
		/// Length of the process.args array.<para/><para/>This field can be useful for querying or performing bucket analysis on how many arguments were provided to start a process. More arguments may be an indication of suspicious activity.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>4</example>
		[DataMember(Name = "args_count")]
		public long? ArgsCount { get; set; }

		/// <summary>
		/// Full command line that started the process, including the absolute path to the executable, and all arguments.<para/><para/>Some arguments may be filtered to protect sensitive information.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>/usr/bin/ssh -l user 10.0.0.16</example>
		[DataMember(Name = "command_line")]
		public string CommandLine { get; set; }

		/// <summary>
		/// Unique identifier for the process.<para/><para/>The implementation of this is specified by the data source, but some examples of what could be used here are a process-generated UUID, Sysmon Process GUIDs, or a hash of some uniquely identifying components of a process.<para/><para/>Constructing a globally unique identifier is a common practice to mitigate PID reuse as well as to identify a specific process over time, across multiple monitored hosts.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>c2c455d9f99375d</example>
		[DataMember(Name = "entity_id")]
		public string EntityId { get; set; }

		/// <summary>
		/// Absolute path to the process executable.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>/usr/bin/ssh</example>
		[DataMember(Name = "executable")]
		public string Executable { get; set; }

		/// <summary>
		/// The exit code of the process, if this is a termination event.<para/><para/>The field should be absent if there is no exit code for the event (e.g. process start).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>137</example>
		[DataMember(Name = "exit_code")]
		public long? ExitCode { get; set; }

		/// <summary>
		/// Process name.<para/><para/>Sometimes called program name or similar.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>ssh</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Identifier of the group of processes the process belongs to.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "pgid")]
		public long? Pgid { get; set; }

		/// <summary>
		/// Process id.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>4242</example>
		[DataMember(Name = "pid")]
		public long? Pid { get; set; }

		/// <summary>
		/// Parent process' pid.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>4241</example>
		[DataMember(Name = "ppid")]
		public long? Ppid { get; set; }

		/// <summary>
		/// The time the process started.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>2016-05-23T08:05:34.853Z</example>
		[DataMember(Name = "start")]
		public DateTimeOffset? Start { get; set; }

		/// <summary>
		/// Process title.<para/><para/>The proctitle, some times the same as process name. Can also be different: for example a browser setting its title to the web page currently opened.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "title")]
		public string Title { get; set; }

		/// <summary>
		/// Seconds the process has been up.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1325</example>
		[DataMember(Name = "uptime")]
		public long? Uptime { get; set; }

		/// <summary>
		/// The working directory of the process.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>/home/alice</example>
		[DataMember(Name = "working_directory")]
		public string WorkingDirectory { get; set; }

	}

	/// <summary>
	/// Data, property of <see cref="Registry" />
	/// </summary>
	public class RegistryData
	{
		/// <summary>
		/// Original bytes written with base64 encoding.<para/><para/>For Windows registry operations, such as SetValueEx and RegQueryValueEx, this corresponds to the data pointed by `lp_data`. This is optional but provides better recoverability and should be populated for REG_BINARY encoded values.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>ZQBuAC0AVQBTAAAAZQBuAAAAAAA=</example>
		[DataMember(Name = "bytes")]
		public string Bytes { get; set; }

		/// <summary>
		/// Content when writing string types.<para/><para/>Populated as an array when writing string data to the registry. For single string registry types (REG_SZ, REG_EXPAND_SZ), this should be an array with one string. For sequences of string with REG_MULTI_SZ, this array will be variable length. For numeric data, such as REG_DWORD and REG_QWORD, this should be populated with the decimal representation (e.g `"1"`).
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>["C:\rta\red_ttp\bin\myapp.exe"]</example>
		[DataMember(Name = "strings")]
		public string[] Strings { get; set; }

		/// <summary>
		/// Standard registry type for encoding contents
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>REG_SZ</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}
	/// <summary>
	/// Fields related to Windows Registry operations.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-registry.html
	/// </summary>
	public class Registry 
	{
		/// <summary>
		/// Data property.
		/// </summary>
		[DataMember(Name = "data")]
		public RegistryData Data { get; set; }

		/// <summary>
		/// Abbreviated name for the hive.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>HKLM</example>
		[DataMember(Name = "hive")]
		public string Hive { get; set; }

		/// <summary>
		/// Hive-relative path of keys.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\winword.exe</example>
		[DataMember(Name = "key")]
		public string Key { get; set; }

		/// <summary>
		/// Full path, including hive, key and value
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\winword.exe\\Debugger</example>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		/// <summary>
		/// Name of the value written.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>Debugger</example>
		[DataMember(Name = "value")]
		public string Value { get; set; }

	}

	/// <summary>
	/// This field set is meant to facilitate pivoting around a piece of data.<para/><para/>Some pieces of information can be seen in many places in an ECS event. To facilitate searching for them, store an array of all seen values to their corresponding field in `related.`.<para/><para/>A concrete example is IP addresses, which can be under host, observer, source, destination, client, server, and network.forwarded_ip. If you append all IPs to `related.ip`, you can then search for a given IP trivially, no matter where it appeared, by querying `related.ip:192.0.2.15`.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-related.html
	/// </summary>
	public class Related 
	{
		/// <summary>
		/// All the hashes seen on your event. Populating this field, then using it to search for hashes can help in situations where you're unsure what the hash algorithm is (and therefore which key name to search).
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "hash")]
		public string[] Hash { get; set; }

		/// <summary>
		/// All hostnames or other host identifiers seen on your event. Example identifiers include FQDNs, domain names, workstation names, or aliases.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "hosts")]
		public string[] Hosts { get; set; }

		/// <summary>
		/// All of the IPs seen on your event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "ip")]
		public string[] Ip { get; set; }

		/// <summary>
		/// All the user names seen on your event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "user")]
		public string[] User { get; set; }

	}

	/// <summary>
	/// Rule fields are used to capture the specifics of any observer or agent rules that generate alerts or other notable events.<para/><para/>Examples of data sources that would populate the rule fields include: network admission control platforms, network or host IDS/IPS, network firewalls, web application firewalls, url filters, endpoint detection and response (EDR) systems, etc.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-rule.html
	/// </summary>
	public class Rule 
	{
		/// <summary>
		/// Name, organization, or pseudonym of the author or authors who created the rule used to generate this event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["Star-Lord"]</example>
		[DataMember(Name = "author")]
		public string[] Author { get; set; }

		/// <summary>
		/// A categorization value keyword used by the entity using the rule for detection of this event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Attempted Information Leak</example>
		[DataMember(Name = "category")]
		public string Category { get; set; }

		/// <summary>
		/// The description of the rule generating the event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Block requests to public DNS over HTTPS / TLS protocols</example>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// A rule ID that is unique within the scope of an agent, observer, or other entity using the rule for detection of this event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>101</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Name of the license under which the rule used to generate this event is made available.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Apache 2.0</example>
		[DataMember(Name = "license")]
		public string License { get; set; }

		/// <summary>
		/// The name of the rule or signature generating the event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>BLOCK_DNS_over_TLS</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Reference URL to additional information about the rule used to generate this event.<para/><para/>The URL can point to the vendor's documentation about the rule. If that's not available, it can also be a link to a more general page describing this type of alert.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://en.wikipedia.org/wiki/DNS_over_TLS</example>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		/// <summary>
		/// Name of the ruleset, policy, group, or parent category in which the rule used to generate this event is a member.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Standard_Protocol_Filters</example>
		[DataMember(Name = "ruleset")]
		public string Ruleset { get; set; }

		/// <summary>
		/// A rule ID that is unique within the scope of a set or group of agents, observers, or other entities using the rule for detection of this event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1100110011</example>
		[DataMember(Name = "uuid")]
		public string Uuid { get; set; }

		/// <summary>
		/// The version / revision of the rule being used for analysis.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1.1</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// Nat, property of <see cref="Server" />
	/// </summary>
	public class ServerNat
	{
		/// <summary>
		/// Translated ip of destination based NAT sessions (e.g. internet to private DMZ)<para/><para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Translated port of destination based NAT sessions (e.g. internet to private DMZ)<para/><para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

	}
	/// <summary>
	/// A Server is defined as the responder in a network connection for events regarding sessions, connections, or bidirectional flow records.<para/><para/>For TCP events, the server is the receiver of the initial SYN packet(s) of the TCP connection. For other protocols, the server is generally the responder in the network transaction. Some systems actually use the term "responder" to refer the server in TCP connections. The server fields describe details about the system acting as the server in the network event. Server fields are usually populated in conjunction with client fields. Server fields are generally not populated for packet-level events.<para/><para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-server.html
	/// </summary>
	public class Server 
	{
		/// <summary>
		/// Fields describing an Autonomous System (Internet routing prefix).
		/// </summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		/// <summary>
		/// Fields describing a location.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Nat property.
		/// </summary>
		[DataMember(Name = "nat")]
		public ServerNat Nat { get; set; }

		/// <summary>
		/// Fields to describe the user relevant to the event.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Some event server addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/><para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		/// <summary>
		/// Bytes sent from the server to the client.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>184</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Server domain.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// IP address of the server (IPv4 or IPv6).
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// MAC address of the server.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// Packets sent from the server to the client.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>12</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		/// <summary>
		/// Port of the server.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// The highest registered server domain, stripped of the subdomain.<para/><para/>For example, the registered domain for "foo.example.com" is "example.com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>example.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for example.com is "com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

	}

	/// <summary>
	/// Node, property of <see cref="Service" />
	/// </summary>
	public class ServiceNode
	{
		/// <summary>
		/// Name of a service node.<para/><para/>This allows for two nodes of the same service running on the same host to be differentiated. Therefore, `service.node.name` should typically be unique across nodes of a given service.<para/><para/>In the case of Elasticsearch, the `service.node.name` could contain the unique node name within the Elasticsearch cluster. In cases where the service doesn't have the concept of a node name, the host name or container name can be used to distinguish running instances that make up this service. If those do not provide uniqueness (e.g. multiple instances of the service running on the same host) - the node name can be manually set.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>instance-0000000016</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}
	/// <summary>
	/// The service fields describe the service for or from which the data was collected.<para/><para/>These fields help you find and correlate logs for a specific service and version.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-service.html
	/// </summary>
	public class Service 
	{
		/// <summary>
		/// Node property.
		/// </summary>
		[DataMember(Name = "node")]
		public ServiceNode Node { get; set; }

		/// <summary>
		/// Ephemeral identifier of this service (if one exists).<para/><para/>This id normally changes across restarts, but `service.id` does not.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>8a4f500f</example>
		[DataMember(Name = "ephemeral_id")]
		public string EphemeralId { get; set; }

		/// <summary>
		/// Unique identifier of the running service. If the service is comprised of many nodes, the `service.id` should be the same for all nodes.<para/><para/>This id should uniquely identify the service. This makes it possible to correlate logs and metrics for one specific service, no matter which particular node emitted the event.<para/><para/>Note that if you need to see the events from one specific host of the service, you should filter on that `host.name` or `host.id` instead.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>d37e5ebfe0ae6c4972dbe9f0174a1637bb8247f6</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Name of the service data is collected from.<para/><para/>The name of the service is normally user given. This allows for distributed services that run on multiple hosts to correlate the related instances based on the name.<para/><para/>In the case of Elasticsearch the `service.name` could contain the cluster name. For Beats the `service.name` is by default a copy of the `service.type` field if no name is specified.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>elasticsearch-metrics</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Current state of the service.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "state")]
		public string State { get; set; }

		/// <summary>
		/// The type of the service data is collected from.<para/><para/>The type can be used to group and correlate logs and metrics from one service type.<para/><para/>Example: If logs or metrics are collected from Elasticsearch, `service.type` would be `elasticsearch`.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>elasticsearch</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Version of the service the data was collected from.<para/><para/>This allows to look at a data set only for a specific version of a service.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>3.2.4</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// Nat, property of <see cref="Source" />
	/// </summary>
	public class SourceNat
	{
		/// <summary>
		/// Translated ip of source based NAT sessions (e.g. internal client to internet)<para/><para/>Typically connections traversing load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Translated port of source based NAT sessions. (e.g. internal client to internet)<para/><para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

	}
	/// <summary>
	/// Source fields describe details about the source of a packet/event.<para/><para/>Source fields are usually populated in conjunction with destination fields.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-source.html
	/// </summary>
	public class Source 
	{
		/// <summary>
		/// Fields describing an Autonomous System (Internet routing prefix).
		/// </summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		/// <summary>
		/// Fields describing a location.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Nat property.
		/// </summary>
		[DataMember(Name = "nat")]
		public SourceNat Nat { get; set; }

		/// <summary>
		/// Fields to describe the user relevant to the event.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Some event source addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/><para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		/// <summary>
		/// Bytes sent from the source to the destination.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>184</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Source domain.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// IP address of the source (IPv4 or IPv6).
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// MAC address of the source.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// Packets sent from the source to the destination.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>12</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		/// <summary>
		/// Port of the source.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// The highest registered source domain, stripped of the subdomain.<para/><para/>For example, the registered domain for "foo.example.com" is "example.com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>example.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for example.com is "com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

	}

	/// <summary>
	/// Tactic, property of <see cref="Threat" />
	/// </summary>
	public class ThreatTactic
	{
		/// <summary>
		/// The id of tactic used by this threat. You can use a MITRE ATT&CK® tactic, for example. (ex. https://attack.mitre.org/tactics/TA0040/ )
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>TA0040</example>
		[DataMember(Name = "id")]
		public string[] Id { get; set; }

		/// <summary>
		/// Name of the type of tactic used by this threat. You can use a MITRE ATT&CK® tactic, for example. (ex. https://attack.mitre.org/tactics/TA0040/)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>impact</example>
		[DataMember(Name = "name")]
		public string[] Name { get; set; }

		/// <summary>
		/// The reference url of tactic used by this threat. You can use a MITRE ATT&CK® tactic, for example. (ex. https://attack.mitre.org/tactics/TA0040/ )
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://attack.mitre.org/tactics/TA0040/</example>
		[DataMember(Name = "reference")]
		public string[] Reference { get; set; }

	}
	/// <summary>
	/// Technique, property of <see cref="Threat" />
	/// </summary>
	public class ThreatTechnique
	{
		/// <summary>
		/// The id of technique used by this threat. You can use a MITRE ATT&CK® technique, for example. (ex. https://attack.mitre.org/techniques/T1499/)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>T1499</example>
		[DataMember(Name = "id")]
		public string[] Id { get; set; }

		/// <summary>
		/// The name of technique used by this threat. You can use a MITRE ATT&CK® technique, for example. (ex. https://attack.mitre.org/techniques/T1499/)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Endpoint Denial of Service</example>
		[DataMember(Name = "name")]
		public string[] Name { get; set; }

		/// <summary>
		/// The reference url of technique used by this threat. You can use a MITRE ATT&CK® technique, for example. (ex. https://attack.mitre.org/techniques/T1499/ )
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://attack.mitre.org/techniques/T1499/</example>
		[DataMember(Name = "reference")]
		public string[] Reference { get; set; }

	}
	/// <summary>
	/// Fields to classify events and alerts according to a threat taxonomy such as the MITRE ATT&CK® framework.<para/><para/>These fields are for users to classify alerts from all of their sources (e.g. IDS, NGFW, etc.) within a common taxonomy. The threat.tactic.* are meant to capture the high level category of the threat (e.g. "impact"). The threat.technique.* fields are meant to capture which kind of approach is used by this detected threat, to accomplish the goal (e.g. "endpoint denial of service").
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-threat.html
	/// </summary>
	public class Threat 
	{
		/// <summary>
		/// Tactic property.
		/// </summary>
		[DataMember(Name = "tactic")]
		public ThreatTactic Tactic { get; set; }

		/// <summary>
		/// Technique property.
		/// </summary>
		[DataMember(Name = "technique")]
		public ThreatTechnique Technique { get; set; }

		/// <summary>
		/// Name of the threat framework used to further categorize and classify the tactic and technique of the reported threat. Framework classification can be provided by detecting systems, evaluated at ingest time, or retrospectively tagged to events.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>MITRE ATT&CK</example>
		[DataMember(Name = "framework")]
		public string Framework { get; set; }

	}

	/// <summary>
	/// Client, property of <see cref="Tls" />
	/// </summary>
	public class TlsClient
	{
		/// <summary>
		/// PEM-encoded stand-alone certificate offered by the client. This is usually mutually-exclusive of `client.certificate_chain` since this value also exists in that list.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>MII...</example>
		[DataMember(Name = "certificate")]
		public string Certificate { get; set; }

		/// <summary>
		/// Array of PEM-encoded certificates that make up the certificate chain offered by the client. This is usually mutually-exclusive of `client.certificate` since that value should be the first certificate in the chain.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["MII...","MII..."]</example>
		[DataMember(Name = "certificate_chain")]
		public string[] CertificateChain { get; set; }

		/// <summary>
		/// Distinguished name of subject of the issuer of the x.509 certificate presented by the client.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>CN=Example Root CA, OU=Infrastructure Team, DC=example, DC=com</example>
		[DataMember(Name = "issuer")]
		public string Issuer { get; set; }

		/// <summary>
		/// A hash that identifies clients based on how they perform an SSL/TLS handshake.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>d4e5b18d6b55c71272893221c96ba240</example>
		[DataMember(Name = "ja3")]
		public string Ja3 { get; set; }

		/// <summary>
		/// Date/Time indicating when client certificate is no longer considered valid.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>2021-01-01T00:00:00Z</example>
		[DataMember(Name = "not_after")]
		public DateTimeOffset? NotAfter { get; set; }

		/// <summary>
		/// Date/Time indicating when client certificate is first considered valid.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1970-01-01T00:00:00Z</example>
		[DataMember(Name = "not_before")]
		public DateTimeOffset? NotBefore { get; set; }

		/// <summary>
		/// Also called an SNI, this tells the server which hostname to which the client is attempting to connect to. When this value is available, it should get copied to `destination.domain`.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>www.elastic.co</example>
		[DataMember(Name = "server_name")]
		public string ServerName { get; set; }

		/// <summary>
		/// Distinguished name of subject of the x.509 certificate presented by the client.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>CN=myclient, OU=Documentation Team, DC=example, DC=com</example>
		[DataMember(Name = "subject")]
		public string Subject { get; set; }

		/// <summary>
		/// Array of ciphers offered by the client during the client hello.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384","TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384","..."]</example>
		[DataMember(Name = "supported_ciphers")]
		public string[] SupportedCiphers { get; set; }

		/// <summary>
		/// These fields contain x509 certificate metadata.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "x509")]
		public X509 X509 { get; set; }

	}
	/// <summary>
	/// Server, property of <see cref="Tls" />
	/// </summary>
	public class TlsServer
	{
		/// <summary>
		/// PEM-encoded stand-alone certificate offered by the server. This is usually mutually-exclusive of `server.certificate_chain` since this value also exists in that list.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>MII...</example>
		[DataMember(Name = "certificate")]
		public string Certificate { get; set; }

		/// <summary>
		/// Array of PEM-encoded certificates that make up the certificate chain offered by the server. This is usually mutually-exclusive of `server.certificate` since that value should be the first certificate in the chain.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["MII...","MII..."]</example>
		[DataMember(Name = "certificate_chain")]
		public string[] CertificateChain { get; set; }

		/// <summary>
		/// Subject of the issuer of the x.509 certificate presented by the server.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>CN=Example Root CA, OU=Infrastructure Team, DC=example, DC=com</example>
		[DataMember(Name = "issuer")]
		public string Issuer { get; set; }

		/// <summary>
		/// A hash that identifies servers based on how they perform an SSL/TLS handshake.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>394441ab65754e2207b1e1b457b3641d</example>
		[DataMember(Name = "ja3s")]
		public string Ja3s { get; set; }

		/// <summary>
		/// Timestamp indicating when server certificate is no longer considered valid.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>2021-01-01T00:00:00Z</example>
		[DataMember(Name = "not_after")]
		public DateTimeOffset? NotAfter { get; set; }

		/// <summary>
		/// Timestamp indicating when server certificate is first considered valid.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1970-01-01T00:00:00Z</example>
		[DataMember(Name = "not_before")]
		public DateTimeOffset? NotBefore { get; set; }

		/// <summary>
		/// Subject of the x.509 certificate presented by the server.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>CN=www.example.com, OU=Infrastructure Team, DC=example, DC=com</example>
		[DataMember(Name = "subject")]
		public string Subject { get; set; }

		/// <summary>
		/// These fields contain x509 certificate metadata.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "x509")]
		public X509 X509 { get; set; }

	}
	/// <summary>
	/// Fields related to a TLS connection. These fields focus on the TLS protocol itself and intentionally avoids in-depth analysis of the related x.509 certificate files.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-tls.html
	/// </summary>
	public class Tls 
	{
		/// <summary>
		/// Client property.
		/// </summary>
		[DataMember(Name = "client")]
		public TlsClient Client { get; set; }

		/// <summary>
		/// Server property.
		/// </summary>
		[DataMember(Name = "server")]
		public TlsServer Server { get; set; }

		/// <summary>
		/// String indicating the cipher used during the current connection.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256</example>
		[DataMember(Name = "cipher")]
		public string Cipher { get; set; }

		/// <summary>
		/// String indicating the curve used for the given cipher, when applicable.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>secp256r1</example>
		[DataMember(Name = "curve")]
		public string Curve { get; set; }

		/// <summary>
		/// Boolean flag indicating if the TLS negotiation was successful and transitioned to an encrypted tunnel.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "established")]
		public bool? Established { get; set; }

		/// <summary>
		/// String indicating the protocol being tunneled. Per the values in the IANA registry (https://www.iana.org/assignments/tls-extensiontype-values/tls-extensiontype-values.xhtml#alpn-protocol-ids), this string should be lower case.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>http/1.1</example>
		[DataMember(Name = "next_protocol")]
		public string NextProtocol { get; set; }

		/// <summary>
		/// Boolean flag indicating if this TLS connection was resumed from an existing TLS negotiation.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "resumed")]
		public bool? Resumed { get; set; }

		/// <summary>
		/// Numeric part of the version parsed from the original string.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>1.2</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		/// <summary>
		/// Normalized lowercase protocol name parsed from original string.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>tls</example>
		[DataMember(Name = "version_protocol")]
		public string VersionProtocol { get; set; }

	}

	/// <summary>
	/// URL fields provide support for complete or partial URLs, and supports the breaking down into scheme, domain, path, and so on.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-url.html
	/// </summary>
	public class Url 
	{
		/// <summary>
		/// Domain of the url, such as "www.elastic.co".<para/><para/>In some cases a URL may refer to an IP and/or port directly, without a domain name. In this case, the IP address would go to the `domain` field.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>www.elastic.co</example>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// The field contains the file extension from the original request url.<para/><para/>The file extension is only set if it exists, as not every url has a file extension.<para/><para/>The leading period must not be included. For example, the value must be "png", not ".png".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>png</example>
		[DataMember(Name = "extension")]
		public string Extension { get; set; }

		/// <summary>
		/// Portion of the url after the `#`, such as "top".<para/><para/>The `#` is not part of the fragment.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "fragment")]
		public string Fragment { get; set; }

		/// <summary>
		/// If full URLs are important to your use case, they should be stored in `url.full`, whether this field is reconstructed or present in the event source.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://www.elastic.co:443/search?q=elasticsearch#top</example>
		[DataMember(Name = "full")]
		public string Full { get; set; }

		/// <summary>
		/// Unmodified original url as seen in the event source.<para/><para/>Note that in network monitoring, the observed URL may be a full URL, whereas in access logs, the URL is often just represented as a path.<para/><para/>This field is meant to represent the URL as it was observed, complete or not.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://www.elastic.co:443/search?q=elasticsearch#top or /search?q=elasticsearch</example>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		/// <summary>
		/// Password of the request.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "password")]
		public string Password { get; set; }

		/// <summary>
		/// Path of the request, such as "/search".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		/// <summary>
		/// Port of the request, such as 443.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>443</example>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// The query field describes the query string of the request, such as "q=elasticsearch".<para/><para/>The `?` is excluded from the query string. If a URL contains no `?`, there is no query field. If there is a `?` but no query, the query field exists with an empty string. The `exists` query can be used to differentiate between the two cases.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "query")]
		public string Query { get; set; }

		/// <summary>
		/// The highest registered url domain, stripped of the subdomain.<para/><para/>For example, the registered domain for "foo.example.com" is "example.com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>example.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// Scheme of the request, such as "https".<para/><para/>Note: The `:` is not part of the scheme.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https</example>
		[DataMember(Name = "scheme")]
		public string Scheme { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for example.com is "com".<para/><para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

		/// <summary>
		/// Username of the request.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "username")]
		public string Username { get; set; }

	}

	/// <summary>
	/// The user fields describe information about the user that is relevant to the event.<para/><para/>Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-user.html
	/// </summary>
	public class User 
	{
		/// <summary>
		/// User's group relevant to the event.
		/// </summary>
		[DataMember(Name = "group")]
		public Group Group { get; set; }

		/// <summary>
		/// Name of the directory the user is a member of.<para/><para/>For example, an LDAP or Active Directory domain name.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// User email address.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "email")]
		public string Email { get; set; }

		/// <summary>
		/// User's full name, if available.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Albert Einstein</example>
		[DataMember(Name = "full_name")]
		public string FullName { get; set; }

		/// <summary>
		/// Unique user hash to correlate information for a user in anonymized form.<para/><para/>Useful if `user.id` or `user.name` contain confidential information and cannot be used.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "hash")]
		public string Hash { get; set; }

		/// <summary>
		/// Unique identifier of the user.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Short name or login of the user.
		/// </summary>
		/// <remarks>(ECS Core)</remarks>
		/// <example>albert</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Array of user roles at the time of the event.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["kibana_admin","reporting_user"]</example>
		[DataMember(Name = "roles")]
		public string[] Roles { get; set; }

	}

	/// <summary>
	/// Device, property of <see cref="UserAgent" />
	/// </summary>
	public class UserAgentDevice
	{
		/// <summary>
		/// Name of the device.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>iPhone</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}
	/// <summary>
	/// The user_agent fields normally come from a browser request.<para/><para/>They often show up in web service logs coming from the parsed user agent string.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-user_agent.html
	/// </summary>
	public class UserAgent 
	{
		/// <summary>
		/// Device property.
		/// </summary>
		[DataMember(Name = "device")]
		public UserAgentDevice Device { get; set; }

		/// <summary>
		/// OS fields contain information about the operating system.
		/// </summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }

		/// <summary>
		/// Name of the user agent.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Safari</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Unparsed user_agent string.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Mozilla/5.0 (iPhone; CPU iPhone OS 12_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/12.0 Mobile/15E148 Safari/604.1</example>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		/// <summary>
		/// Version of the user agent.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>12.0</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// The VLAN fields are used to identify 802.1q tag(s) of a packet, as well as ingress and egress VLAN associations of an observer in relation to a specific packet or connection.<para/><para/>Network.vlan fields are used to record a single VLAN tag, or the outer tag in the case of q-in-q encapsulations, for a packet or connection as observed, typically provided by a network sensor (e.g. Zeek, Wireshark) passively reporting on traffic.<para/><para/>Network.inner VLAN fields are used to report inner q-in-q 802.1q tags (multiple 802.1q encapsulations) as observed, typically provided by a network sensor  (e.g. Zeek, Wireshark) passively reporting on traffic. Network.inner VLAN fields should only be used in addition to network.vlan fields to indicate q-in-q tagging.<para/><para/>Observer.ingress and observer.egress VLAN values are used to record observer specific information when observer events contain discrete ingress and egress VLAN information, typically provided by firewalls, routers, or load balancers.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-vlan.html
	/// </summary>
	public class Vlan 
	{
		/// <summary>
		/// VLAN ID as reported by the observer.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>10</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Optional VLAN name as reported by the observer.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>outside</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// Scanner, property of <see cref="Vulnerability" />
	/// </summary>
	public class VulnerabilityScanner
	{
		/// <summary>
		/// The name of the vulnerability scanner vendor.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Tenable</example>
		[DataMember(Name = "vendor")]
		public string Vendor { get; set; }

	}
	/// <summary>
	/// Score, property of <see cref="Vulnerability" />
	/// </summary>
	public class VulnerabilityScore
	{
		/// <summary>
		/// Scores can range from 0.0 to 10.0, with 10.0 being the most severe.<para/><para/>Base scores cover an assessment for exploitability metrics (attack vector, complexity, privileges, and user interaction), impact metrics (confidentiality, integrity, and availability), and scope. For example (https://www.first.org/cvss/specification-document)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>5.5</example>
		[DataMember(Name = "base")]
		public float? Base { get; set; }

		/// <summary>
		/// Scores can range from 0.0 to 10.0, with 10.0 being the most severe.<para/><para/>Environmental scores cover an assessment for any modified Base metrics, confidentiality, integrity, and availability requirements. For example (https://www.first.org/cvss/specification-document)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>5.5</example>
		[DataMember(Name = "environmental")]
		public float? Environmental { get; set; }

		/// <summary>
		/// Scores can range from 0.0 to 10.0, with 10.0 being the most severe.<para/><para/>Temporal scores cover an assessment for code maturity, remediation level, and confidence. For example (https://www.first.org/cvss/specification-document)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "temporal")]
		public float? Temporal { get; set; }

		/// <summary>
		/// The National Vulnerability Database (NVD) provides qualitative severity rankings of "Low", "Medium", and "High" for CVSS v2.0 base score ranges in addition to the severity ratings for CVSS v3.0 as they are defined in the CVSS v3.0 specification.<para/><para/>CVSS is owned and managed by FIRST.Org, Inc. (FIRST), a US-based non-profit organization, whose mission is to help computer security incident response teams across the world. For example (https://nvd.nist.gov/vuln-metrics/cvss)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>2.0</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}
	/// <summary>
	/// The vulnerability fields describe information about a vulnerability that is relevant to an event.
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-vulnerability.html
	/// </summary>
	public class Vulnerability 
	{
		/// <summary>
		/// Scanner property.
		/// </summary>
		[DataMember(Name = "scanner")]
		public VulnerabilityScanner Scanner { get; set; }

		/// <summary>
		/// Score property.
		/// </summary>
		[DataMember(Name = "score")]
		public VulnerabilityScore Score { get; set; }

		/// <summary>
		/// The type of system or architecture that the vulnerability affects. These may be platform-specific (for example, Debian or SUSE) or general (for example, Database or Firewall). For example (https://qualysguard.qualys.com/qwebhelp/fo_portal/knowledgebase/vulnerability_categories.htm[Qualys vulnerability categories])<para/><para/>This field must be an array.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>["Firewall"]</example>
		[DataMember(Name = "category")]
		public string[] Category { get; set; }

		/// <summary>
		/// The classification of the vulnerability scoring system. For example (https://www.first.org/cvss/)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>CVSS</example>
		[DataMember(Name = "classification")]
		public string Classification { get; set; }

		/// <summary>
		/// The description of the vulnerability that provides additional context of the vulnerability. For example (https://cve.mitre.org/about/faqs.html#cve_entry_descriptions_created[Common Vulnerabilities and Exposure CVE description])
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>In macOS before 2.12.6, there is a vulnerability in the RPC...</example>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// The type of identifier used for this vulnerability. For example (https://cve.mitre.org/about/)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>CVE</example>
		[DataMember(Name = "enumeration")]
		public string Enumeration { get; set; }

		/// <summary>
		/// The identification (ID) is the number portion of a vulnerability entry. It includes a unique identification number for the vulnerability. For example (https://cve.mitre.org/about/faqs.html#what_is_cve_id)[Common Vulnerabilities and Exposure CVE ID]
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>CVE-2019-00001</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// A resource that provides additional information, context, and mitigations for the identified vulnerability.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>https://cve.mitre.org/cgi-bin/cvename.cgi?name=CVE-2019-6111</example>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		/// <summary>
		/// The report or scan identification number.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>20191018.0001</example>
		[DataMember(Name = "report_id")]
		public string ReportId { get; set; }

		/// <summary>
		/// The severity of the vulnerability can help with metrics and internal prioritization regarding remediation. For example (https://nvd.nist.gov/vuln-metrics/cvss)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Critical</example>
		[DataMember(Name = "severity")]
		public string Severity { get; set; }

	}

	/// <summary>
	/// Issuer, property of <see cref="X509" />
	/// </summary>
	public class X509Issuer
	{
		/// <summary>
		/// List of common name (CN) of issuing certificate authority.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Example SHA2 High Assurance Server CA</example>
		[DataMember(Name = "common_name")]
		public string[] CommonName { get; set; }

		/// <summary>
		/// List of country (C) codes
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>US</example>
		[DataMember(Name = "country")]
		public string[] Country { get; set; }

		/// <summary>
		/// Distinguished name (DN) of issuing certificate authority.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>C=US, O=Example Inc, OU=www.example.com, CN=Example SHA2 High Assurance Server CA</example>
		[DataMember(Name = "distinguished_name")]
		public string DistinguishedName { get; set; }

		/// <summary>
		/// List of locality names (L)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Mountain View</example>
		[DataMember(Name = "locality")]
		public string[] Locality { get; set; }

		/// <summary>
		/// List of organizations (O) of issuing certificate authority.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Example Inc</example>
		[DataMember(Name = "organization")]
		public string[] Organization { get; set; }

		/// <summary>
		/// List of organizational units (OU) of issuing certificate authority.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>www.example.com</example>
		[DataMember(Name = "organizational_unit")]
		public string[] OrganizationalUnit { get; set; }

		/// <summary>
		/// List of state or province names (ST, S, or P)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>California</example>
		[DataMember(Name = "state_or_province")]
		public string[] StateOrProvince { get; set; }

	}
	/// <summary>
	/// Subject, property of <see cref="X509" />
	/// </summary>
	public class X509Subject
	{
		/// <summary>
		/// List of common names (CN) of subject.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>shared.global.example.net</example>
		[DataMember(Name = "common_name")]
		public string[] CommonName { get; set; }

		/// <summary>
		/// List of country (C) code
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>US</example>
		[DataMember(Name = "country")]
		public string[] Country { get; set; }

		/// <summary>
		/// Distinguished name (DN) of the certificate subject entity.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>C=US, ST=California, L=San Francisco, O=Example, Inc., CN=shared.global.example.net</example>
		[DataMember(Name = "distinguished_name")]
		public string DistinguishedName { get; set; }

		/// <summary>
		/// List of locality names (L)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>San Francisco</example>
		[DataMember(Name = "locality")]
		public string[] Locality { get; set; }

		/// <summary>
		/// List of organizations (O) of subject.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>Example, Inc.</example>
		[DataMember(Name = "organization")]
		public string[] Organization { get; set; }

		/// <summary>
		/// List of organizational units (OU) of subject.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		[DataMember(Name = "organizational_unit")]
		public string[] OrganizationalUnit { get; set; }

		/// <summary>
		/// List of state or province names (ST, S, or P)
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>California</example>
		[DataMember(Name = "state_or_province")]
		public string[] StateOrProvince { get; set; }

	}
	/// <summary>
	/// This implements the common core fields for x509 certificates. This information is likely logged with TLS sessions, digital signatures found in executable binaries, S/MIME information in email bodies, or analysis of files on disk. When only a single certificate is logged in an event, it should be nested under `file`. When hashes of the DER-encoded certificate are available, the `hash` data set should be populated as well (e.g. `file.hash.sha256`). For events that contain certificate information for both sides of the connection, the x509 object could be nested under the respective side of the connection information (e.g. `tls.server.x509`).
	/// <para/>
	/// ECS field reference: https://www.elastic.co/guide/en/ecs/1.6/ecs-x509.html
	/// </summary>
	public class X509 
	{
		/// <summary>
		/// Issuer property.
		/// </summary>
		[DataMember(Name = "issuer")]
		public X509Issuer Issuer { get; set; }

		/// <summary>
		/// Subject property.
		/// </summary>
		[DataMember(Name = "subject")]
		public X509Subject Subject { get; set; }

		/// <summary>
		/// List of subject alternative names (SAN). Name types vary by certificate authority and certificate type but commonly contain IP addresses, DNS names (and wildcards), and email addresses.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>*.elastic.co</example>
		[DataMember(Name = "alternative_names")]
		public string[] AlternativeNames { get; set; }

		/// <summary>
		/// Time at which the certificate is no longer considered valid.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>2020-07-16 03:15:39+00:00</example>
		[DataMember(Name = "not_after")]
		public DateTimeOffset? NotAfter { get; set; }

		/// <summary>
		/// Time at which the certificate is first considered valid.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>2019-08-16 01:40:25+00:00</example>
		[DataMember(Name = "not_before")]
		public DateTimeOffset? NotBefore { get; set; }

		/// <summary>
		/// Algorithm used to generate the public key.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>RSA</example>
		[DataMember(Name = "public_key_algorithm")]
		public string PublicKeyAlgorithm { get; set; }

		/// <summary>
		/// The curve used by the elliptic curve public key algorithm. This is algorithm specific.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>nistp521</example>
		[DataMember(Name = "public_key_curve")]
		public string PublicKeyCurve { get; set; }

		/// <summary>
		/// Exponent used to derive the public key. This is algorithm specific.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>65537</example>
		[DataMember(Name = "public_key_exponent")]
		public long? PublicKeyExponent { get; set; }

		/// <summary>
		/// The size of the public key space in bits.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>2048</example>
		[DataMember(Name = "public_key_size")]
		public long? PublicKeySize { get; set; }

		/// <summary>
		/// Unique serial number issued by the certificate authority. For consistency, if this value is alphanumeric, it should be formatted without colons and uppercase characters.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>55FBB9C7DEBF09809D12CCAA</example>
		[DataMember(Name = "serial_number")]
		public string SerialNumber { get; set; }

		/// <summary>
		/// Identifier for certificate signature algorithm. We recommend using names found in Go Lang Crypto library. See https://github.com/golang/go/blob/go1.14/src/crypto/x509/x509.go#L337-L353.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>SHA256-RSA</example>
		[DataMember(Name = "signature_algorithm")]
		public string SignatureAlgorithm { get; set; }

		/// <summary>
		/// Version of x509 format.
		/// </summary>
		/// <remarks>(ECS Extended)</remarks>
		/// <example>3</example>
		[DataMember(Name = "version_number")]
		public string VersionNumber { get; set; }

	}

}

namespace Elastic.CommonSchema.Elasticsearch
{
	/// <summary>
	/// Elastic Common Schema version 1.6.0 index templates to be used with Elasticsearch.
	/// </summary>
	public static class IndexTemplates
	{
		/// <summary>
		/// Elastic Common Schema version 1.6.0 index template for Elasticsearch version 6
		/// See the Put Index Template API documentation: https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string GetIndexTemplateForElasticsearch6(string indexPattern = "ecs-*") { return "{  \"index_patterns\": [    \"" + indexPattern + "\"  ],  \"mappings\": {    \"_doc\": {      \"_meta\": {        \"version\": \"1.6.0\"      },      \"date_detection\": false,      \"dynamic_templates\": [        {          \"strings_as_keyword\": {            \"mapping\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"match_mapping_type\": \"string\"          }        }      ],      \"properties\": {        \"@timestamp\": {          \"type\": \"date\"        },        \"agent\": {          \"properties\": {            \"build\": {              \"properties\": {                \"original\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"ephemeral_id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"client\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"as\": {              \"properties\": {                \"number\": {                  \"type\": \"long\"                },                \"organization\": {                  \"properties\": {                    \"name\": {                      \"fields\": {                        \"text\": {                          \"norms\": false,                          \"type\": \"text\"                        }                      },                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                }              }            },            \"bytes\": {              \"type\": \"long\"            },            \"domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"continent_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"location\": {                  \"type\": \"geo_point\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"ip\": {              \"type\": \"ip\"            },            \"mac\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"nat\": {              \"properties\": {                \"ip\": {                  \"type\": \"ip\"                },                \"port\": {                  \"type\": \"long\"                }              }            },            \"packets\": {              \"type\": \"long\"            },            \"port\": {              \"type\": \"long\"            },            \"registered_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"top_level_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"email\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"full_name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"hash\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"roles\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            }          }        },        \"cloud\": {          \"properties\": {            \"account\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"availability_zone\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"instance\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"machine\": {              \"properties\": {                \"type\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"project\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"provider\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"region\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"container\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"image\": {              \"properties\": {                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"tag\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"labels\": {              \"type\": \"object\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"runtime\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"destination\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"as\": {              \"properties\": {                \"number\": {                  \"type\": \"long\"                },                \"organization\": {                  \"properties\": {                    \"name\": {                      \"fields\": {                        \"text\": {                          \"norms\": false,                          \"type\": \"text\"                        }                      },                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                }              }            },            \"bytes\": {              \"type\": \"long\"            },            \"domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"continent_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"location\": {                  \"type\": \"geo_point\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"ip\": {              \"type\": \"ip\"            },            \"mac\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"nat\": {              \"properties\": {                \"ip\": {                  \"type\": \"ip\"                },                \"port\": {                  \"type\": \"long\"                }              }            },            \"packets\": {              \"type\": \"long\"            },            \"port\": {              \"type\": \"long\"            },            \"registered_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"top_level_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"email\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"full_name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"hash\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"roles\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            }          }        },        \"dll\": {          \"properties\": {            \"code_signature\": {              \"properties\": {                \"exists\": {                  \"type\": \"boolean\"                },                \"status\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"subject_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"trusted\": {                  \"type\": \"boolean\"                },                \"valid\": {                  \"type\": \"boolean\"                }              }            },            \"hash\": {              \"properties\": {                \"md5\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"sha1\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"sha256\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"sha512\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"path\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"pe\": {              \"properties\": {                \"architecture\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"company\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"description\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"file_version\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"imphash\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"original_file_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"product\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            }          }        },        \"dns\": {          \"properties\": {            \"answers\": {              \"properties\": {                \"class\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"data\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"ttl\": {                  \"type\": \"long\"                },                \"type\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              },              \"type\": \"object\"            },            \"header_flags\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"op_code\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"question\": {              \"properties\": {                \"class\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"registered_domain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"subdomain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"top_level_domain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"type\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"resolved_ip\": {              \"type\": \"ip\"            },            \"response_code\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"ecs\": {          \"properties\": {            \"version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"error\": {          \"properties\": {            \"code\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"message\": {              \"norms\": false,              \"type\": \"text\"            },            \"stack_trace\": {              \"doc_values\": false,              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"index\": false,              \"type\": \"keyword\"            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"event\": {          \"properties\": {            \"action\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"category\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"code\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"created\": {              \"type\": \"date\"            },            \"dataset\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"duration\": {              \"type\": \"long\"            },            \"end\": {              \"type\": \"date\"            },            \"hash\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"ingested\": {              \"type\": \"date\"            },            \"kind\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"module\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"original\": {              \"doc_values\": false,              \"ignore_above\": 1024,              \"index\": false,              \"type\": \"keyword\"            },            \"outcome\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"provider\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"reason\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"reference\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"risk_score\": {              \"type\": \"float\"            },            \"risk_score_norm\": {              \"type\": \"float\"            },            \"sequence\": {              \"type\": \"long\"            },            \"severity\": {              \"type\": \"long\"            },            \"start\": {              \"type\": \"date\"            },            \"timezone\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"url\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"file\": {          \"properties\": {            \"accessed\": {              \"type\": \"date\"            },            \"attributes\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"code_signature\": {              \"properties\": {                \"exists\": {                  \"type\": \"boolean\"                },                \"status\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"subject_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"trusted\": {                  \"type\": \"boolean\"                },                \"valid\": {                  \"type\": \"boolean\"                }              }            },            \"created\": {              \"type\": \"date\"            },            \"ctime\": {              \"type\": \"date\"            },            \"device\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"directory\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"drive_letter\": {              \"ignore_above\": 1,              \"type\": \"keyword\"            },            \"extension\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"gid\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"group\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"hash\": {              \"properties\": {                \"md5\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"sha1\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"sha256\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"sha512\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"inode\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"mime_type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"mode\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"mtime\": {              \"type\": \"date\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"owner\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"path\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"pe\": {              \"properties\": {                \"architecture\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"company\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"description\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"file_version\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"imphash\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"original_file_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"product\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"size\": {              \"type\": \"long\"            },            \"target_path\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"uid\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"x509\": {              \"properties\": {                \"alternative_names\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"issuer\": {                  \"properties\": {                    \"common_name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"country\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"distinguished_name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"locality\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"organization\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"organizational_unit\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"state_or_province\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"not_after\": {                  \"type\": \"date\"                },                \"not_before\": {                  \"type\": \"date\"                },                \"public_key_algorithm\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"public_key_curve\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"public_key_exponent\": {                  \"doc_values\": false,                  \"index\": false,                  \"type\": \"long\"                },                \"public_key_size\": {                  \"type\": \"long\"                },                \"serial_number\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"signature_algorithm\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"subject\": {                  \"properties\": {                    \"common_name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"country\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"distinguished_name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"locality\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"organization\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"organizational_unit\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"state_or_province\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"version_number\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            }          }        },        \"group\": {          \"properties\": {            \"domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"host\": {          \"properties\": {            \"architecture\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"continent_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"location\": {                  \"type\": \"geo_point\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"hostname\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"ip\": {              \"type\": \"ip\"            },            \"mac\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"os\": {              \"properties\": {                \"family\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"full\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"kernel\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"platform\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"version\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"uptime\": {              \"type\": \"long\"            },            \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"email\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"full_name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"hash\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"roles\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            }          }        },        \"http\": {          \"properties\": {            \"request\": {              \"properties\": {                \"body\": {                  \"properties\": {                    \"bytes\": {                      \"type\": \"long\"                    },                    \"content\": {                      \"fields\": {                        \"text\": {                          \"norms\": false,                          \"type\": \"text\"                        }                      },                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"bytes\": {                  \"type\": \"long\"                },                \"method\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"referrer\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"response\": {              \"properties\": {                \"body\": {                  \"properties\": {                    \"bytes\": {                      \"type\": \"long\"                    },                    \"content\": {                      \"fields\": {                        \"text\": {                          \"norms\": false,                          \"type\": \"text\"                        }                      },                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"bytes\": {                  \"type\": \"long\"                },                \"status_code\": {                  \"type\": \"long\"                }              }            },            \"version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"labels\": {          \"type\": \"object\"        },        \"log\": {          \"properties\": {            \"file\": {              \"properties\": {                \"path\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"level\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"logger\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"origin\": {              \"properties\": {                \"file\": {                  \"properties\": {                    \"line\": {                      \"type\": \"integer\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"function\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"original\": {              \"doc_values\": false,              \"ignore_above\": 1024,              \"index\": false,              \"type\": \"keyword\"            },            \"syslog\": {              \"properties\": {                \"facility\": {                  \"properties\": {                    \"code\": {                      \"type\": \"long\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"priority\": {                  \"type\": \"long\"                },                \"severity\": {                  \"properties\": {                    \"code\": {                      \"type\": \"long\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                }              },              \"type\": \"object\"            }          }        },        \"message\": {          \"norms\": false,          \"type\": \"text\"        },        \"network\": {          \"properties\": {            \"application\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"bytes\": {              \"type\": \"long\"            },            \"community_id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"direction\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"forwarded_ip\": {              \"type\": \"ip\"            },            \"iana_number\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"inner\": {              \"properties\": {                \"vlan\": {                  \"properties\": {                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                }              },              \"type\": \"object\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"packets\": {              \"type\": \"long\"            },            \"protocol\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"transport\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"vlan\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            }          }        },        \"observer\": {          \"properties\": {            \"egress\": {              \"properties\": {                \"interface\": {                  \"properties\": {                    \"alias\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"vlan\": {                  \"properties\": {                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"zone\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              },              \"type\": \"object\"            },            \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"continent_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"location\": {                  \"type\": \"geo_point\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"hostname\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"ingress\": {              \"properties\": {                \"interface\": {                  \"properties\": {                    \"alias\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"vlan\": {                  \"properties\": {                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"zone\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              },              \"type\": \"object\"            },            \"ip\": {              \"type\": \"ip\"            },            \"mac\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"os\": {              \"properties\": {                \"family\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"full\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"kernel\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"platform\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"version\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"product\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"serial_number\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"vendor\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"organization\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"name\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"package\": {          \"properties\": {            \"architecture\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"build_version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"checksum\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"description\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"install_scope\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"installed\": {              \"type\": \"date\"            },            \"license\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"path\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"reference\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"size\": {              \"type\": \"long\"            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"process\": {          \"properties\": {            \"args\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"args_count\": {              \"type\": \"long\"            },            \"code_signature\": {              \"properties\": {                \"exists\": {                  \"type\": \"boolean\"                },                \"status\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"subject_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"trusted\": {                  \"type\": \"boolean\"                },                \"valid\": {                  \"type\": \"boolean\"                }              }            },            \"command_line\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"entity_id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"executable\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"exit_code\": {              \"type\": \"long\"            },            \"hash\": {              \"properties\": {                \"md5\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"sha1\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"sha256\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"sha512\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"name\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"parent\": {              \"properties\": {                \"args\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"args_count\": {                  \"type\": \"long\"                },                \"code_signature\": {                  \"properties\": {                    \"exists\": {                      \"type\": \"boolean\"                    },                    \"status\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"subject_name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"trusted\": {                      \"type\": \"boolean\"                    },                    \"valid\": {                      \"type\": \"boolean\"                    }                  }                },                \"command_line\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"entity_id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"executable\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"exit_code\": {                  \"type\": \"long\"                },                \"hash\": {                  \"properties\": {                    \"md5\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"sha1\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"sha256\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"sha512\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"pe\": {                  \"properties\": {                    \"architecture\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"company\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"description\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"file_version\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"imphash\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"original_file_name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"product\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"pgid\": {                  \"type\": \"long\"                },                \"pid\": {                  \"type\": \"long\"                },                \"ppid\": {                  \"type\": \"long\"                },                \"start\": {                  \"type\": \"date\"                },                \"thread\": {                  \"properties\": {                    \"id\": {                      \"type\": \"long\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"title\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"uptime\": {                  \"type\": \"long\"                },                \"working_directory\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"pe\": {              \"properties\": {                \"architecture\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"company\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"description\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"file_version\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"imphash\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"original_file_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"product\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"pgid\": {              \"type\": \"long\"            },            \"pid\": {              \"type\": \"long\"            },            \"ppid\": {              \"type\": \"long\"            },            \"start\": {              \"type\": \"date\"            },            \"thread\": {              \"properties\": {                \"id\": {                  \"type\": \"long\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"title\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"uptime\": {              \"type\": \"long\"            },            \"working_directory\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"registry\": {          \"properties\": {            \"data\": {              \"properties\": {                \"bytes\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"strings\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"type\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"hive\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"key\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"path\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"value\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"related\": {          \"properties\": {            \"hash\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"hosts\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"ip\": {              \"type\": \"ip\"            },            \"user\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"rule\": {          \"properties\": {            \"author\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"category\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"description\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"license\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"reference\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"ruleset\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"uuid\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"server\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"as\": {              \"properties\": {                \"number\": {                  \"type\": \"long\"                },                \"organization\": {                  \"properties\": {                    \"name\": {                      \"fields\": {                        \"text\": {                          \"norms\": false,                          \"type\": \"text\"                        }                      },                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                }              }            },            \"bytes\": {              \"type\": \"long\"            },            \"domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"continent_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"location\": {                  \"type\": \"geo_point\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"ip\": {              \"type\": \"ip\"            },            \"mac\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"nat\": {              \"properties\": {                \"ip\": {                  \"type\": \"ip\"                },                \"port\": {                  \"type\": \"long\"                }              }            },            \"packets\": {              \"type\": \"long\"            },            \"port\": {              \"type\": \"long\"            },            \"registered_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"top_level_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"email\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"full_name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"hash\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"roles\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            }          }        },        \"service\": {          \"properties\": {            \"ephemeral_id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"node\": {              \"properties\": {                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"state\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"type\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"source\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"as\": {              \"properties\": {                \"number\": {                  \"type\": \"long\"                },                \"organization\": {                  \"properties\": {                    \"name\": {                      \"fields\": {                        \"text\": {                          \"norms\": false,                          \"type\": \"text\"                        }                      },                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                }              }            },            \"bytes\": {              \"type\": \"long\"            },            \"domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"continent_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"country_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"location\": {                  \"type\": \"geo_point\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_iso_code\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"region_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"ip\": {              \"type\": \"ip\"            },            \"mac\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"nat\": {              \"properties\": {                \"ip\": {                  \"type\": \"ip\"                },                \"port\": {                  \"type\": \"long\"                }              }            },            \"packets\": {              \"type\": \"long\"            },            \"port\": {              \"type\": \"long\"            },            \"registered_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"top_level_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"email\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"full_name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"id\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"name\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"hash\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"roles\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            }          }        },        \"span\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"tags\": {          \"ignore_above\": 1024,          \"type\": \"keyword\"        },        \"threat\": {          \"properties\": {            \"framework\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"tactic\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"reference\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"technique\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"reference\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            }          }        },        \"tls\": {          \"properties\": {            \"cipher\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"client\": {              \"properties\": {                \"certificate\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"certificate_chain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"hash\": {                  \"properties\": {                    \"md5\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"sha1\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"sha256\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"issuer\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"ja3\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"not_after\": {                  \"type\": \"date\"                },                \"not_before\": {                  \"type\": \"date\"                },                \"server_name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"subject\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"supported_ciphers\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"x509\": {                  \"properties\": {                    \"alternative_names\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"issuer\": {                      \"properties\": {                        \"common_name\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"country\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"distinguished_name\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"locality\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"organization\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"organizational_unit\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"state_or_province\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        }                      }                    },                    \"not_after\": {                      \"type\": \"date\"                    },                    \"not_before\": {                      \"type\": \"date\"                    },                    \"public_key_algorithm\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"public_key_curve\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"public_key_exponent\": {                      \"doc_values\": false,                      \"index\": false,                      \"type\": \"long\"                    },                    \"public_key_size\": {                      \"type\": \"long\"                    },                    \"serial_number\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"signature_algorithm\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"subject\": {                      \"properties\": {                        \"common_name\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"country\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"distinguished_name\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"locality\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"organization\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"organizational_unit\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"state_or_province\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        }                      }                    },                    \"version_number\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                }              }            },            \"curve\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"established\": {              \"type\": \"boolean\"            },            \"next_protocol\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"resumed\": {              \"type\": \"boolean\"            },            \"server\": {              \"properties\": {                \"certificate\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"certificate_chain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"hash\": {                  \"properties\": {                    \"md5\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"sha1\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"sha256\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                },                \"issuer\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"ja3s\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"not_after\": {                  \"type\": \"date\"                },                \"not_before\": {                  \"type\": \"date\"                },                \"subject\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"x509\": {                  \"properties\": {                    \"alternative_names\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"issuer\": {                      \"properties\": {                        \"common_name\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"country\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"distinguished_name\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"locality\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"organization\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"organizational_unit\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"state_or_province\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        }                      }                    },                    \"not_after\": {                      \"type\": \"date\"                    },                    \"not_before\": {                      \"type\": \"date\"                    },                    \"public_key_algorithm\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"public_key_curve\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"public_key_exponent\": {                      \"doc_values\": false,                      \"index\": false,                      \"type\": \"long\"                    },                    \"public_key_size\": {                      \"type\": \"long\"                    },                    \"serial_number\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"signature_algorithm\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    },                    \"subject\": {                      \"properties\": {                        \"common_name\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"country\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"distinguished_name\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"locality\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"organization\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"organizational_unit\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        },                        \"state_or_province\": {                          \"ignore_above\": 1024,                          \"type\": \"keyword\"                        }                      }                    },                    \"version_number\": {                      \"ignore_above\": 1024,                      \"type\": \"keyword\"                    }                  }                }              }            },            \"version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"version_protocol\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"trace\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"transaction\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"url\": {          \"properties\": {            \"domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"extension\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"fragment\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"full\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"original\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"password\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"path\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"port\": {              \"type\": \"long\"            },            \"query\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"registered_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"scheme\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"top_level_domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"username\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"user\": {          \"properties\": {            \"domain\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"email\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"full_name\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"group\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"id\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"hash\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"name\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"roles\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"user_agent\": {          \"properties\": {            \"device\": {              \"properties\": {                \"name\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"name\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"original\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"os\": {              \"properties\": {                \"family\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"full\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"kernel\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"name\": {                  \"fields\": {                    \"text\": {                      \"norms\": false,                      \"type\": \"text\"                    }                  },                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"platform\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                },                \"version\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"version\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        },        \"vulnerability\": {          \"properties\": {            \"category\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"classification\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"description\": {              \"fields\": {                \"text\": {                  \"norms\": false,                  \"type\": \"text\"                }              },              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"enumeration\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"reference\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"report_id\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            },            \"scanner\": {              \"properties\": {                \"vendor\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"score\": {              \"properties\": {                \"base\": {                  \"type\": \"float\"                },                \"environmental\": {                  \"type\": \"float\"                },                \"temporal\": {                  \"type\": \"float\"                },                \"version\": {                  \"ignore_above\": 1024,                  \"type\": \"keyword\"                }              }            },            \"severity\": {              \"ignore_above\": 1024,              \"type\": \"keyword\"            }          }        }      }    }  },  \"order\": 1,  \"settings\": {    \"index\": {      \"mapping\": {        \"total_fields\": {          \"limit\": 10000        }      },      \"refresh_interval\": \"5s\"    }  }}"; }

		/// <summary>
		/// Elastic Common Schema version 1.6.0 index template for Elasticsearch version 7
		/// See the Put Index Template API documentation: https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string GetIndexTemplateForElasticsearch7(string indexPattern = "ecs-*") { return "{  \"index_patterns\": [    \"" + indexPattern + "\"  ],  \"mappings\": {    \"_meta\": {      \"version\": \"1.6.0\"    },    \"date_detection\": false,    \"dynamic_templates\": [      {        \"strings_as_keyword\": {          \"mapping\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"match_mapping_type\": \"string\"        }      }    ],    \"properties\": {      \"@timestamp\": {        \"type\": \"date\"      },      \"agent\": {        \"properties\": {          \"build\": {            \"properties\": {              \"original\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"ephemeral_id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"client\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"as\": {            \"properties\": {              \"number\": {                \"type\": \"long\"              },              \"organization\": {                \"properties\": {                  \"name\": {                    \"fields\": {                      \"text\": {                        \"norms\": false,                        \"type\": \"text\"                      }                    },                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              }            }          },          \"bytes\": {            \"type\": \"long\"          },          \"domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"continent_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"location\": {                \"type\": \"geo_point\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"ip\": {            \"type\": \"ip\"          },          \"mac\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"nat\": {            \"properties\": {              \"ip\": {                \"type\": \"ip\"              },              \"port\": {                \"type\": \"long\"              }            }          },          \"packets\": {            \"type\": \"long\"          },          \"port\": {            \"type\": \"long\"          },          \"registered_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"top_level_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"email\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"full_name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"hash\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"roles\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          }        }      },      \"cloud\": {        \"properties\": {          \"account\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"availability_zone\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"instance\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"machine\": {            \"properties\": {              \"type\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"project\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"provider\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"region\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"container\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"image\": {            \"properties\": {              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"tag\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"labels\": {            \"type\": \"object\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"runtime\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"destination\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"as\": {            \"properties\": {              \"number\": {                \"type\": \"long\"              },              \"organization\": {                \"properties\": {                  \"name\": {                    \"fields\": {                      \"text\": {                        \"norms\": false,                        \"type\": \"text\"                      }                    },                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              }            }          },          \"bytes\": {            \"type\": \"long\"          },          \"domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"continent_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"location\": {                \"type\": \"geo_point\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"ip\": {            \"type\": \"ip\"          },          \"mac\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"nat\": {            \"properties\": {              \"ip\": {                \"type\": \"ip\"              },              \"port\": {                \"type\": \"long\"              }            }          },          \"packets\": {            \"type\": \"long\"          },          \"port\": {            \"type\": \"long\"          },          \"registered_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"top_level_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"email\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"full_name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"hash\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"roles\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          }        }      },      \"dll\": {        \"properties\": {          \"code_signature\": {            \"properties\": {              \"exists\": {                \"type\": \"boolean\"              },              \"status\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"subject_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"trusted\": {                \"type\": \"boolean\"              },              \"valid\": {                \"type\": \"boolean\"              }            }          },          \"hash\": {            \"properties\": {              \"md5\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"sha1\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"sha256\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"sha512\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"path\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"pe\": {            \"properties\": {              \"architecture\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"company\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"description\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"file_version\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"imphash\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"original_file_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"product\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          }        }      },      \"dns\": {        \"properties\": {          \"answers\": {            \"properties\": {              \"class\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"data\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"ttl\": {                \"type\": \"long\"              },              \"type\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            },            \"type\": \"object\"          },          \"header_flags\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"op_code\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"question\": {            \"properties\": {              \"class\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"registered_domain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"subdomain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"top_level_domain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"type\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"resolved_ip\": {            \"type\": \"ip\"          },          \"response_code\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"ecs\": {        \"properties\": {          \"version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"error\": {        \"properties\": {          \"code\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"message\": {            \"norms\": false,            \"type\": \"text\"          },          \"stack_trace\": {            \"doc_values\": false,            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"index\": false,            \"type\": \"keyword\"          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"event\": {        \"properties\": {          \"action\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"category\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"code\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"created\": {            \"type\": \"date\"          },          \"dataset\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"duration\": {            \"type\": \"long\"          },          \"end\": {            \"type\": \"date\"          },          \"hash\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"ingested\": {            \"type\": \"date\"          },          \"kind\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"module\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"original\": {            \"doc_values\": false,            \"ignore_above\": 1024,            \"index\": false,            \"type\": \"keyword\"          },          \"outcome\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"provider\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"reason\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"reference\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"risk_score\": {            \"type\": \"float\"          },          \"risk_score_norm\": {            \"type\": \"float\"          },          \"sequence\": {            \"type\": \"long\"          },          \"severity\": {            \"type\": \"long\"          },          \"start\": {            \"type\": \"date\"          },          \"timezone\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"url\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"file\": {        \"properties\": {          \"accessed\": {            \"type\": \"date\"          },          \"attributes\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"code_signature\": {            \"properties\": {              \"exists\": {                \"type\": \"boolean\"              },              \"status\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"subject_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"trusted\": {                \"type\": \"boolean\"              },              \"valid\": {                \"type\": \"boolean\"              }            }          },          \"created\": {            \"type\": \"date\"          },          \"ctime\": {            \"type\": \"date\"          },          \"device\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"directory\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"drive_letter\": {            \"ignore_above\": 1,            \"type\": \"keyword\"          },          \"extension\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"gid\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"group\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"hash\": {            \"properties\": {              \"md5\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"sha1\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"sha256\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"sha512\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"inode\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"mime_type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"mode\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"mtime\": {            \"type\": \"date\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"owner\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"path\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"pe\": {            \"properties\": {              \"architecture\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"company\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"description\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"file_version\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"imphash\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"original_file_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"product\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"size\": {            \"type\": \"long\"          },          \"target_path\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"uid\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"x509\": {            \"properties\": {              \"alternative_names\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"issuer\": {                \"properties\": {                  \"common_name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"country\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"distinguished_name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"locality\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"organization\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"organizational_unit\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"state_or_province\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"not_after\": {                \"type\": \"date\"              },              \"not_before\": {                \"type\": \"date\"              },              \"public_key_algorithm\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"public_key_curve\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"public_key_exponent\": {                \"doc_values\": false,                \"index\": false,                \"type\": \"long\"              },              \"public_key_size\": {                \"type\": \"long\"              },              \"serial_number\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"signature_algorithm\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"subject\": {                \"properties\": {                  \"common_name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"country\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"distinguished_name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"locality\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"organization\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"organizational_unit\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"state_or_province\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"version_number\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          }        }      },      \"group\": {        \"properties\": {          \"domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"host\": {        \"properties\": {          \"architecture\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"continent_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"location\": {                \"type\": \"geo_point\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"hostname\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"ip\": {            \"type\": \"ip\"          },          \"mac\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"os\": {            \"properties\": {              \"family\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"full\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"kernel\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"platform\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"version\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"uptime\": {            \"type\": \"long\"          },          \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"email\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"full_name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"hash\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"roles\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          }        }      },      \"http\": {        \"properties\": {          \"request\": {            \"properties\": {              \"body\": {                \"properties\": {                  \"bytes\": {                    \"type\": \"long\"                  },                  \"content\": {                    \"fields\": {                      \"text\": {                        \"norms\": false,                        \"type\": \"text\"                      }                    },                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"bytes\": {                \"type\": \"long\"              },              \"method\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"referrer\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"response\": {            \"properties\": {              \"body\": {                \"properties\": {                  \"bytes\": {                    \"type\": \"long\"                  },                  \"content\": {                    \"fields\": {                      \"text\": {                        \"norms\": false,                        \"type\": \"text\"                      }                    },                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"bytes\": {                \"type\": \"long\"              },              \"status_code\": {                \"type\": \"long\"              }            }          },          \"version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"labels\": {        \"type\": \"object\"      },      \"log\": {        \"properties\": {          \"file\": {            \"properties\": {              \"path\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"level\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"logger\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"origin\": {            \"properties\": {              \"file\": {                \"properties\": {                  \"line\": {                    \"type\": \"integer\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"function\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"original\": {            \"doc_values\": false,            \"ignore_above\": 1024,            \"index\": false,            \"type\": \"keyword\"          },          \"syslog\": {            \"properties\": {              \"facility\": {                \"properties\": {                  \"code\": {                    \"type\": \"long\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"priority\": {                \"type\": \"long\"              },              \"severity\": {                \"properties\": {                  \"code\": {                    \"type\": \"long\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              }            },            \"type\": \"object\"          }        }      },      \"message\": {        \"norms\": false,        \"type\": \"text\"      },      \"network\": {        \"properties\": {          \"application\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"bytes\": {            \"type\": \"long\"          },          \"community_id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"direction\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"forwarded_ip\": {            \"type\": \"ip\"          },          \"iana_number\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"inner\": {            \"properties\": {              \"vlan\": {                \"properties\": {                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              }            },            \"type\": \"object\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"packets\": {            \"type\": \"long\"          },          \"protocol\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"transport\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"vlan\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          }        }      },      \"observer\": {        \"properties\": {          \"egress\": {            \"properties\": {              \"interface\": {                \"properties\": {                  \"alias\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"vlan\": {                \"properties\": {                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"zone\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            },            \"type\": \"object\"          },          \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"continent_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"location\": {                \"type\": \"geo_point\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"hostname\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"ingress\": {            \"properties\": {              \"interface\": {                \"properties\": {                  \"alias\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"vlan\": {                \"properties\": {                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"zone\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            },            \"type\": \"object\"          },          \"ip\": {            \"type\": \"ip\"          },          \"mac\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"os\": {            \"properties\": {              \"family\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"full\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"kernel\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"platform\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"version\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"product\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"serial_number\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"vendor\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"organization\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"name\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"package\": {        \"properties\": {          \"architecture\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"build_version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"checksum\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"description\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"install_scope\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"installed\": {            \"type\": \"date\"          },          \"license\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"path\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"reference\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"size\": {            \"type\": \"long\"          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"process\": {        \"properties\": {          \"args\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"args_count\": {            \"type\": \"long\"          },          \"code_signature\": {            \"properties\": {              \"exists\": {                \"type\": \"boolean\"              },              \"status\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"subject_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"trusted\": {                \"type\": \"boolean\"              },              \"valid\": {                \"type\": \"boolean\"              }            }          },          \"command_line\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"entity_id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"executable\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"exit_code\": {            \"type\": \"long\"          },          \"hash\": {            \"properties\": {              \"md5\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"sha1\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"sha256\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"sha512\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"name\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"parent\": {            \"properties\": {              \"args\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"args_count\": {                \"type\": \"long\"              },              \"code_signature\": {                \"properties\": {                  \"exists\": {                    \"type\": \"boolean\"                  },                  \"status\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"subject_name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"trusted\": {                    \"type\": \"boolean\"                  },                  \"valid\": {                    \"type\": \"boolean\"                  }                }              },              \"command_line\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"entity_id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"executable\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"exit_code\": {                \"type\": \"long\"              },              \"hash\": {                \"properties\": {                  \"md5\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"sha1\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"sha256\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"sha512\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"pe\": {                \"properties\": {                  \"architecture\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"company\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"description\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"file_version\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"imphash\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"original_file_name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"product\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"pgid\": {                \"type\": \"long\"              },              \"pid\": {                \"type\": \"long\"              },              \"ppid\": {                \"type\": \"long\"              },              \"start\": {                \"type\": \"date\"              },              \"thread\": {                \"properties\": {                  \"id\": {                    \"type\": \"long\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"title\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"uptime\": {                \"type\": \"long\"              },              \"working_directory\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"pe\": {            \"properties\": {              \"architecture\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"company\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"description\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"file_version\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"imphash\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"original_file_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"product\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"pgid\": {            \"type\": \"long\"          },          \"pid\": {            \"type\": \"long\"          },          \"ppid\": {            \"type\": \"long\"          },          \"start\": {            \"type\": \"date\"          },          \"thread\": {            \"properties\": {              \"id\": {                \"type\": \"long\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"title\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"uptime\": {            \"type\": \"long\"          },          \"working_directory\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"registry\": {        \"properties\": {          \"data\": {            \"properties\": {              \"bytes\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"strings\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"type\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"hive\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"key\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"path\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"value\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"related\": {        \"properties\": {          \"hash\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"hosts\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"ip\": {            \"type\": \"ip\"          },          \"user\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"rule\": {        \"properties\": {          \"author\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"category\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"description\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"license\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"reference\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"ruleset\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"uuid\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"server\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"as\": {            \"properties\": {              \"number\": {                \"type\": \"long\"              },              \"organization\": {                \"properties\": {                  \"name\": {                    \"fields\": {                      \"text\": {                        \"norms\": false,                        \"type\": \"text\"                      }                    },                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              }            }          },          \"bytes\": {            \"type\": \"long\"          },          \"domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"continent_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"location\": {                \"type\": \"geo_point\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"ip\": {            \"type\": \"ip\"          },          \"mac\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"nat\": {            \"properties\": {              \"ip\": {                \"type\": \"ip\"              },              \"port\": {                \"type\": \"long\"              }            }          },          \"packets\": {            \"type\": \"long\"          },          \"port\": {            \"type\": \"long\"          },          \"registered_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"top_level_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"email\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"full_name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"hash\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"roles\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          }        }      },      \"service\": {        \"properties\": {          \"ephemeral_id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"node\": {            \"properties\": {              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"state\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"type\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"source\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"as\": {            \"properties\": {              \"number\": {                \"type\": \"long\"              },              \"organization\": {                \"properties\": {                  \"name\": {                    \"fields\": {                      \"text\": {                        \"norms\": false,                        \"type\": \"text\"                      }                    },                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              }            }          },          \"bytes\": {            \"type\": \"long\"          },          \"domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"continent_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"country_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"location\": {                \"type\": \"geo_point\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_iso_code\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"region_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"ip\": {            \"type\": \"ip\"          },          \"mac\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"nat\": {            \"properties\": {              \"ip\": {                \"type\": \"ip\"              },              \"port\": {                \"type\": \"long\"              }            }          },          \"packets\": {            \"type\": \"long\"          },          \"port\": {            \"type\": \"long\"          },          \"registered_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"top_level_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"email\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"full_name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"id\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"name\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"hash\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"roles\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          }        }      },      \"span\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"tags\": {        \"ignore_above\": 1024,        \"type\": \"keyword\"      },      \"threat\": {        \"properties\": {          \"framework\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"tactic\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"reference\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"technique\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"reference\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          }        }      },      \"tls\": {        \"properties\": {          \"cipher\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"client\": {            \"properties\": {              \"certificate\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"certificate_chain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"hash\": {                \"properties\": {                  \"md5\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"sha1\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"sha256\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"issuer\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"ja3\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"not_after\": {                \"type\": \"date\"              },              \"not_before\": {                \"type\": \"date\"              },              \"server_name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"subject\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"supported_ciphers\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"x509\": {                \"properties\": {                  \"alternative_names\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"issuer\": {                    \"properties\": {                      \"common_name\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"country\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"distinguished_name\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"locality\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"organization\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"organizational_unit\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"state_or_province\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      }                    }                  },                  \"not_after\": {                    \"type\": \"date\"                  },                  \"not_before\": {                    \"type\": \"date\"                  },                  \"public_key_algorithm\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"public_key_curve\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"public_key_exponent\": {                    \"doc_values\": false,                    \"index\": false,                    \"type\": \"long\"                  },                  \"public_key_size\": {                    \"type\": \"long\"                  },                  \"serial_number\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"signature_algorithm\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"subject\": {                    \"properties\": {                      \"common_name\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"country\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"distinguished_name\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"locality\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"organization\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"organizational_unit\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"state_or_province\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      }                    }                  },                  \"version_number\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              }            }          },          \"curve\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"established\": {            \"type\": \"boolean\"          },          \"next_protocol\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"resumed\": {            \"type\": \"boolean\"          },          \"server\": {            \"properties\": {              \"certificate\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"certificate_chain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"hash\": {                \"properties\": {                  \"md5\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"sha1\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"sha256\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              },              \"issuer\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"ja3s\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"not_after\": {                \"type\": \"date\"              },              \"not_before\": {                \"type\": \"date\"              },              \"subject\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"x509\": {                \"properties\": {                  \"alternative_names\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"issuer\": {                    \"properties\": {                      \"common_name\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"country\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"distinguished_name\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"locality\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"organization\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"organizational_unit\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"state_or_province\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      }                    }                  },                  \"not_after\": {                    \"type\": \"date\"                  },                  \"not_before\": {                    \"type\": \"date\"                  },                  \"public_key_algorithm\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"public_key_curve\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"public_key_exponent\": {                    \"doc_values\": false,                    \"index\": false,                    \"type\": \"long\"                  },                  \"public_key_size\": {                    \"type\": \"long\"                  },                  \"serial_number\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"signature_algorithm\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  },                  \"subject\": {                    \"properties\": {                      \"common_name\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"country\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"distinguished_name\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"locality\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"organization\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"organizational_unit\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      },                      \"state_or_province\": {                        \"ignore_above\": 1024,                        \"type\": \"keyword\"                      }                    }                  },                  \"version_number\": {                    \"ignore_above\": 1024,                    \"type\": \"keyword\"                  }                }              }            }          },          \"version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"version_protocol\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"trace\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"transaction\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"url\": {        \"properties\": {          \"domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"extension\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"fragment\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"full\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"original\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"password\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"path\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"port\": {            \"type\": \"long\"          },          \"query\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"registered_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"scheme\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"top_level_domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"username\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"user\": {        \"properties\": {          \"domain\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"email\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"full_name\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"group\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"id\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"hash\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"name\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"roles\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"user_agent\": {        \"properties\": {          \"device\": {            \"properties\": {              \"name\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"name\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"original\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"os\": {            \"properties\": {              \"family\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"full\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"kernel\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"name\": {                \"fields\": {                  \"text\": {                    \"norms\": false,                    \"type\": \"text\"                  }                },                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"platform\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              },              \"version\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"version\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      },      \"vulnerability\": {        \"properties\": {          \"category\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"classification\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"description\": {            \"fields\": {              \"text\": {                \"norms\": false,                \"type\": \"text\"              }            },            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"enumeration\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"reference\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"report_id\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          },          \"scanner\": {            \"properties\": {              \"vendor\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"score\": {            \"properties\": {              \"base\": {                \"type\": \"float\"              },              \"environmental\": {                \"type\": \"float\"              },              \"temporal\": {                \"type\": \"float\"              },              \"version\": {                \"ignore_above\": 1024,                \"type\": \"keyword\"              }            }          },          \"severity\": {            \"ignore_above\": 1024,            \"type\": \"keyword\"          }        }      }    }  },  \"order\": 1,  \"settings\": {    \"index\": {      \"mapping\": {        \"total_fields\": {          \"limit\": 10000        }      },      \"refresh_interval\": \"5s\"    }  }}"; }

	}
}