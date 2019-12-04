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
	/// Elastic Common Schema version 1.3.0
	/// <para/>
	/// The Elastic Common Schema (ECS) defines a common set of fields for ingesting data into Elasticsearch.
	/// A common schema helps you correlate data from sources like logs and metrics or IT operations analytics
	/// and security analytics.
	/// <para/>
	/// See: https://github.com/elastic/ecs
	/// </summary>
	public partial class Base
	{
		/// <summary>
		/// Elastic Common Schema version
		/// </summary>
		public static string Version => "1.3.0";

		/// <summary>
		/// Container for additional metadata against this event.
		/// </summary>
		[DataMember(Name = "_metadata")]
		public IDictionary<string, object> Metadata { get; set; }

		/// <summary>
		/// The agent fields contain the data about the software entity, if any, that collects, detects, or observes events on a host, or takes measurements on a host.<para/>Examples include Beats. Agents may also run on observers. ECS agent.* fields shall be populated with details of the agent running on the host or observer where the event happened or the measurement was taken.
		/// </summary>
		[DataMember(Name = "agent")]
		public Agent Agent { get; set; }

		/// <summary>
		/// An autonomous system (AS) is a collection of connected Internet Protocol (IP) routing prefixes under the control of one or more network operators on behalf of a single administrative entity or domain that presents a common, clearly defined routing policy to the internet.
		/// </summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		/// <summary>
		/// A client is defined as the initiator of a network connection for events regarding sessions, connections, or bidirectional flow records.<para/>For TCP events, the client is the initiator of the TCP connection that sends the SYN packet(s). For other protocols, the client is generally the initiator or requestor in the network transaction. Some systems use the term "originator" to refer the client in TCP connections. The client fields describe details about the system acting as the client in the network event. Client fields are usually populated in conjunction with server fields. Client fields are generally not populated for packet-level events.<para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
		/// </summary>
		[DataMember(Name = "client")]
		public Client Client { get; set; }

		/// <summary>
		/// Fields related to the cloud or infrastructure the events are coming from.
		/// </summary>
		[DataMember(Name = "cloud")]
		public Cloud Cloud { get; set; }

		/// <summary>
		/// Container fields are used for meta information about the specific container that is the source of information.<para/>These fields help correlate data based containers from any runtime.
		/// </summary>
		[DataMember(Name = "container")]
		public Container Container { get; set; }

		/// <summary>
		/// Destination fields describe details about the destination of a packet/event.<para/>Destination fields are usually populated in conjunction with source fields.
		/// </summary>
		[DataMember(Name = "destination")]
		public Destination Destination { get; set; }

		/// <summary>
		/// Fields describing DNS queries and answers.<para/>DNS events should either represent a single DNS query prior to getting answers (`dns.type:query`) or they should represent a full exchange and contain the query details as well as all of the answers that were provided for this query (`dns.type:answer`).
		/// </summary>
		[DataMember(Name = "dns")]
		public Dns Dns { get; set; }

		/// <summary>
		/// Meta-information specific to ECS.
		/// </summary>
		[DataMember(Name = "ecs")]
		public Ecs Ecs { get; set; }

		/// <summary>
		/// These fields can represent errors of any kind.<para/>Use them for errors that happen while fetching events or in cases where the event itself contains an error.
		/// </summary>
		[DataMember(Name = "error")]
		public Error Error { get; set; }

		/// <summary>
		/// The event fields are used for context information about the log or metric event itself.<para/>A log is defined as an event containing details of something that happened. Log events must include the time at which the thing happened. Examples of log events include a process starting on a host, a network packet being sent from a source to a destination, or a network connection between a client and a server being initiated or closed. A metric is defined as an event containing one or more numerical or categorical measurements and the time at which the measurement was taken. Examples of metric events include memory pressure measured on a host, or vulnerabilities measured on a scanned host.
		/// </summary>
		[DataMember(Name = "event")]
		public Event Event { get; set; }

		/// <summary>
		/// A file is defined as a set of information that has been created on, or has existed on a filesystem.<para/>File objects can be associated with host events, network events, and/or file events (e.g., those produced by File Integrity Monitoring [FIM] products or services). File fields provide details about the affected file associated with the event or metric.
		/// </summary>
		[DataMember(Name = "file")]
		public File File { get; set; }

		/// <summary>
		/// Geo fields can carry data about a specific location related to an event.<para/>This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// The group fields are meant to represent groups that are relevant to the event.
		/// </summary>
		[DataMember(Name = "group")]
		public Group Group { get; set; }

		/// <summary>
		/// The hash fields represent different hash algorithms and their values.<para/>Field names for common hashes (e.g. MD5, SHA1) are predefined. Add fields for other hashes by lowercasing the hash algorithm name and using underscore separators as appropriate (snake case, e.g. sha3_512).
		/// </summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		/// <summary>
		/// A host is defined as a general computing instance.<para/>ECS host.* fields should be populated with details about the host on which the event happened, or from which the measurement was taken. Host types include hardware, virtual machines, Docker containers, and Kubernetes nodes.
		/// </summary>
		[DataMember(Name = "host")]
		public Host Host { get; set; }

		/// <summary>
		/// Fields related to HTTP activity. Use the `url` field set to store the url of the request.
		/// </summary>
		[DataMember(Name = "http")]
		public Http Http { get; set; }

		/// <summary>
		/// Details about the event's logging mechanism or logging transport.<para/>The log.* fields are typically populated with details about the logging mechanism used to create and/or transport the event. For example, syslog details belong under `log.syslog.*`.<para/>The details specific to your event source are typically not logged under `log.*`, but rather in `event.*` or in other ECS fields.
		/// </summary>
		[DataMember(Name = "log")]
		public Log Log { get; set; }

		/// <summary>
		/// The network is defined as the communication path over which a host or network event happens.<para/>The network.* fields should be populated with details about the network activity associated with an event.
		/// </summary>
		[DataMember(Name = "network")]
		public Network Network { get; set; }

		/// <summary>
		/// An observer is defined as a special network, security, or application device used to detect, observe, or create network, security, or application-related events and metrics.<para/>This could be a custom hardware appliance or a server that has been configured to run special network, security, or application software. Examples include firewalls, web proxies, intrusion detection/prevention systems, network monitoring sensors, web application firewalls, data loss prevention systems, and APM servers. The observer.* fields shall be populated with details of the system, if any, that detects, observes and/or creates a network, security, or application event or metric. Message queues and ETL components used in processing events or metrics are not considered observers in ECS.
		/// </summary>
		[DataMember(Name = "observer")]
		public Observer Observer { get; set; }

		/// <summary>
		/// The organization fields enrich data with information about the company or entity the data is associated with.<para/>These fields help you arrange or filter data stored in an index by one or multiple organizations.
		/// </summary>
		[DataMember(Name = "organization")]
		public Organization Organization { get; set; }

		/// <summary>
		/// The OS fields contain information about the operating system.
		/// </summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }

		/// <summary>
		/// These fields contain information about an installed software package. It contains general information about a package, such as name, version or size. It also contains installation details, such as time or location.
		/// </summary>
		[DataMember(Name = "package")]
		public Package Package { get; set; }

		/// <summary>
		/// These fields contain information about a process.<para/>These fields can help you correlate metrics information with a process id/name from a log message.  The `process.pid` often stays in the metric itself and is copied to the global field for correlation.
		/// </summary>
		[DataMember(Name = "process")]
		public Process Process { get; set; }

		/// <summary>
		/// This field set is meant to facilitate pivoting around a piece of data.<para/>Some pieces of information can be seen in many places in an ECS event. To facilitate searching for them, store an array of all seen values to their corresponding field in `related.`.<para/>A concrete example is IP addresses, which can be under host, observer, source, destination, client, server, and network.forwarded_ip. If you append all IPs to `related.ip`, you can then search for a given IP trivially, no matter where it appeared, by querying `related.ip:a.b.c.d`.
		/// </summary>
		[DataMember(Name = "related")]
		public Related Related { get; set; }

		/// <summary>
		/// A Server is defined as the responder in a network connection for events regarding sessions, connections, or bidirectional flow records.<para/>For TCP events, the server is the receiver of the initial SYN packet(s) of the TCP connection. For other protocols, the server is generally the responder in the network transaction. Some systems actually use the term "responder" to refer the server in TCP connections. The server fields describe details about the system acting as the server in the network event. Server fields are usually populated in conjunction with client fields. Server fields are generally not populated for packet-level events.<para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
		/// </summary>
		[DataMember(Name = "server")]
		public Server Server { get; set; }

		/// <summary>
		/// The service fields describe the service for or from which the data was collected.<para/>These fields help you find and correlate logs for a specific service and version.
		/// </summary>
		[DataMember(Name = "service")]
		public Service Service { get; set; }

		/// <summary>
		/// Source fields describe details about the source of a packet/event.<para/>Source fields are usually populated in conjunction with destination fields.
		/// </summary>
		[DataMember(Name = "source")]
		public Source Source { get; set; }

		/// <summary>
		/// Fields to classify events and alerts according to a threat taxonomy such as the Mitre ATT&CK framework.<para/>These fields are for users to classify alerts from all of their sources (e.g. IDS, NGFW, etc.) within a  common taxonomy. The threat.tactic.* are meant to capture the high level category of the threat  (e.g. "impact"). The threat.technique.* fields are meant to capture which kind of approach is used by  this detected threat, to accomplish the goal (e.g. "endpoint denial of service").
		/// </summary>
		[DataMember(Name = "threat")]
		public Threat Threat { get; set; }

		/// <summary>
		/// Fields related to a TLS connection. These fields focus on the TLS protocol itself and intentionally avoids in-depth analysis of the related x.509 certificate files.
		/// </summary>
		[DataMember(Name = "tls")]
		public Tls Tls { get; set; }

		/// <summary>
		/// Distributed tracing makes it possible to analyze performance throughout a microservice architecture all in one view. This is accomplished by tracing all of the requests - from the initial web request in the front-end service - to queries made through multiple back-end services.
		/// </summary>
		[DataMember(Name = "tracing")]
		public Tracing Tracing { get; set; }

		/// <summary>
		/// URL fields provide support for complete or partial URLs, and supports the breaking down into scheme, domain, path, and so on.
		/// </summary>
		[DataMember(Name = "url")]
		public Url Url { get; set; }

		/// <summary>
		/// The user fields describe information about the user that is relevant to the event.<para/>Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// The user_agent fields normally come from a browser request.<para/>They often show up in web service logs coming from the parsed user agent string.
		/// </summary>
		[DataMember(Name = "user_agent")]
		public UserAgent UserAgent { get; set; }

		/// <summary>
		/// The vulnerability fields describe information about a vulnerability that is relevant to an event.
		/// </summary>
		[DataMember(Name = "vulnerability")]
		public Vulnerability Vulnerability { get; set; }

		/// <summary>
		/// Date/time when the event originated.<para/>This is the date/time extracted from the event, typically representing when the event was generated by the source.<para/>If the event source has no original timestamp, this value is typically populated by the first time the event was received by the pipeline.<para/>Required field for all events.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>2016-05-23T08:05:34.853Z</example>
		[DataMember(Name = "@timestamp")]
		public DateTimeOffset? Timestamp { get; set; }

		/// <summary>
		/// List of keywords used to tag each event.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>[\"production\", \"env2\"]</example>
		[DataMember(Name = "tags")]
		public string[] Tags { get; set; }

		/// <summary>
		/// Custom key/value pairs.<para/>Can be used to add meta information to events. Should not contain nested objects. All values are stored as keyword.<para/>Example: `docker` and `k8s` labels.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>{"application":"foo-bar","env":"production"}</example>
		[DataMember(Name = "labels")]
		public IDictionary<string, object> Labels { get; set; }

		/// <summary>
		/// For log events the message field contains the log message, optimized for viewing in a log viewer.<para/>For structured logs without an original message field, other fields can be concatenated to form a human-readable summary of the event.<para/>If multiple messages exist, they can be combined into one message.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>Hello World</example>
		[DataMember(Name = "message")]
		public string Message { get; set; }

	}

	/// <summary>
	/// The agent fields contain the data about the software entity, if any, that collects, detects, or observes events on a host, or takes measurements on a host.<para/>Examples include Beats. Agents may also run on observers. ECS agent.* fields shall be populated with details of the agent running on the host or observer where the event happened or the measurement was taken.
	/// </summary>
	/// <remarks>
	/// Examples: In the case of Beats for logs, the agent.name is filebeat. For APM, it is the agent running in the app/service. The agent information does not change if data is sent through queuing systems like Kafka, Redis, or processing systems such as Logstash or APM Server.
	/// </remarks>
	public class Agent 
	{
		/// <summary>
		/// Version of the agent.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>6.0.0-rc2</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		/// <summary>
		/// Custom name of the agent.<para/>This is a name that can be given to an agent. This can be helpful if for example two Filebeat instances are running on the same host but a human readable separation is needed on which Filebeat instance data is coming from.<para/>If no name is given, the name is often left empty.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>foo</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Type of the agent.<para/>The agent type stays always the same and should be given by the agent used. In case of Filebeat the agent would always be Filebeat also if two Filebeat instances are run on the same machine.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>filebeat</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Unique identifier of this agent (if one exists).<para/>Example: For Beats this would be beat.id.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>8a4f500d</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Ephemeral identifier of this agent (if one exists).<para/>This id normally changes across restarts, but `agent.id` does not.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>8a4f500f</example>
		[DataMember(Name = "ephemeral_id")]
		public string EphemeralId { get; set; }

	}

	/// <summary>
	/// Organization, property of <see cref="As" />
	/// </summary>
	public class AsOrganization
	{
		/// <summary>
		/// Organization name.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Google LLC</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// An autonomous system (AS) is a collection of connected Internet Protocol (IP) routing prefixes under the control of one or more network operators on behalf of a single administrative entity or domain that presents a common, clearly defined routing policy to the internet.
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
		/// <remarks>Extended</remarks>
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
		/// Translated IP of source based NAT sessions (e.g. internal client to internet).<para/>Typically connections traversing load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Translated port of source based NAT sessions (e.g. internal client to internet).<para/>Typically connections traversing load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

	}

	/// <summary>
	/// A client is defined as the initiator of a network connection for events regarding sessions, connections, or bidirectional flow records.<para/>For TCP events, the client is the initiator of the TCP connection that sends the SYN packet(s). For other protocols, the client is generally the initiator or requestor in the network transaction. Some systems use the term "originator" to refer the client in TCP connections. The client fields describe details about the system acting as the client in the network event. Client fields are usually populated in conjunction with server fields. Client fields are generally not populated for packet-level events.<para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
	/// </summary>
	public class Client 
	{
		/// <summary>
		/// Geo nested field.
		/// <para/>
		/// Geo fields can carry data about a specific location related to an event.&lt;para/&gt;This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// As nested field.
		/// <para/>
		/// An autonomous system (AS) is a collection of connected Internet Protocol (IP) routing prefixes under the control of one or more network operators on behalf of a single administrative entity or domain that presents a common, clearly defined routing policy to the internet.
		/// </summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		/// <summary>
		/// User nested field.
		/// <para/>
		/// The user fields describe information about the user that is relevant to the event.&lt;para/&gt;Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Nat property.
		/// </summary>
		[DataMember(Name = "nat")]
		public ClientNat Nat { get; set; }

		/// <summary>
		/// Some event client addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		/// <summary>
		/// IP address of the client.<para/>Can be one or multiple IPv4 or IPv6 addresses.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Port of the client.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// MAC address of the client.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// Client domain.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// The highest registered client domain, stripped of the subdomain.<para/>For example, the registered domain for "foo.google.com" is "google.com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>google.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for google.com is "com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

		/// <summary>
		/// Bytes sent from the client to the server.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>184</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Packets sent from the client to the server.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>12</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

	}

	/// <summary>
	/// Instance, property of <see cref="Cloud" />
	/// </summary>
	public class CloudInstance
	{
		/// <summary>
		/// Instance ID of the host machine.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>i-1234567890abcdef0</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Instance name of the host machine.
		/// </summary>
		/// <remarks>Extended</remarks>
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
		/// <remarks>Extended</remarks>
		/// <example>t2.medium</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}

	/// <summary>
	/// Account, property of <see cref="Cloud" />
	/// </summary>
	public class CloudAccount
	{
		/// <summary>
		/// The cloud account or organization id used to identify different entities in a multi-tenant environment.<para/>Examples: AWS account id, Google Cloud ORG Id, or other unique identifier.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>666777888999</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

	}

	/// <summary>
	/// Fields related to the cloud or infrastructure the events are coming from.
	/// </summary>
	/// <remarks>
	/// Examples: If Metricbeat is running on an EC2 host and fetches data from its host, the cloud info contains the data about this machine. If Metricbeat runs on a remote machine outside the cloud and fetches data from a service running in the cloud, the field contains cloud data from the machine the service is running on.
	/// </remarks>
	public class Cloud 
	{
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
		/// Account property.
		/// </summary>
		[DataMember(Name = "account")]
		public CloudAccount Account { get; set; }

		/// <summary>
		/// Name of the cloud provider. Example values are aws, azure, gcp, or digitalocean.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>aws</example>
		[DataMember(Name = "provider")]
		public string Provider { get; set; }

		/// <summary>
		/// Availability zone in which this host is running.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>us-east-1c</example>
		[DataMember(Name = "availability_zone")]
		public string AvailabilityZone { get; set; }

		/// <summary>
		/// Region in which this host is running.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>us-east-1</example>
		[DataMember(Name = "region")]
		public string Region { get; set; }

	}

	/// <summary>
	/// Image, property of <see cref="Container" />
	/// </summary>
	public class ContainerImage
	{
		/// <summary>
		/// Name of the image the container was built on.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Container image tag.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "tag")]
		public string Tag { get; set; }

	}

	/// <summary>
	/// Container fields are used for meta information about the specific container that is the source of information.<para/>These fields help correlate data based containers from any runtime.
	/// </summary>
	public class Container 
	{
		/// <summary>
		/// Image property.
		/// </summary>
		[DataMember(Name = "image")]
		public ContainerImage Image { get; set; }

		/// <summary>
		/// Runtime managing this container.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>docker</example>
		[DataMember(Name = "runtime")]
		public string Runtime { get; set; }

		/// <summary>
		/// Unique container id.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Container name.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Image labels.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "labels")]
		public object Labels { get; set; }

	}

	/// <summary>
	/// Nat, property of <see cref="Destination" />
	/// </summary>
	public class DestinationNat
	{
		/// <summary>
		/// Translated ip of destination based NAT sessions (e.g. internet to private DMZ)<para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Port the source session is translated to by NAT Device.<para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

	}

	/// <summary>
	/// Destination fields describe details about the destination of a packet/event.<para/>Destination fields are usually populated in conjunction with source fields.
	/// </summary>
	public class Destination 
	{
		/// <summary>
		/// Geo nested field.
		/// <para/>
		/// Geo fields can carry data about a specific location related to an event.&lt;para/&gt;This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// As nested field.
		/// <para/>
		/// An autonomous system (AS) is a collection of connected Internet Protocol (IP) routing prefixes under the control of one or more network operators on behalf of a single administrative entity or domain that presents a common, clearly defined routing policy to the internet.
		/// </summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		/// <summary>
		/// User nested field.
		/// <para/>
		/// The user fields describe information about the user that is relevant to the event.&lt;para/&gt;Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Nat property.
		/// </summary>
		[DataMember(Name = "nat")]
		public DestinationNat Nat { get; set; }

		/// <summary>
		/// Some event destination addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		/// <summary>
		/// IP address of the destination.<para/>Can be one or multiple IPv4 or IPv6 addresses.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Port of the destination.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// MAC address of the destination.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// Destination domain.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// The highest registered destination domain, stripped of the subdomain.<para/>For example, the registered domain for "foo.google.com" is "google.com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>google.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for google.com is "com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

		/// <summary>
		/// Bytes sent from the destination to the source.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>184</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Packets sent from the destination to the source.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>12</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

	}

	/// <summary>
	/// Question, property of <see cref="Dns" />
	/// </summary>
	public class DnsQuestion
	{
		/// <summary>
		/// The name being queried.<para/>If the name field contains non-printable characters (below 32 or above 126), those characters should be represented as escaped base 10 integers (\DDD). Back slashes and quotes should be escaped. Tabs, carriage returns, and line feeds should be converted to \t, \r, and \n respectively.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>www.google.com</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The type of record being queried.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>AAAA</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// The class of of records being queried.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>IN</example>
		[DataMember(Name = "class")]
		public string Class { get; set; }

		/// <summary>
		/// The highest registered domain, stripped of the subdomain.<para/>For example, the registered domain for "foo.google.com" is "google.com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>google.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for google.com is "com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

		/// <summary>
		/// The subdomain is all of the labels under the registered_domain.<para/>If the domain has multiple levels of subdomain, such as "sub2.sub1.example.com", the subdomain field should contain "sub2.sub1", with no trailing period.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>www</example>
		[DataMember(Name = "subdomain")]
		public string Subdomain { get; set; }

	}

	/// <summary>
	/// Answers, property of <see cref="Dns" />
	/// </summary>
	public class DnsAnswers
	{
		/// <summary>
		/// The domain name to which this resource record pertains.<para/>If a chain of CNAME is being resolved, each answer's `name` should be the one that corresponds with the answer's `data`. It should not simply be the original `question.name` repeated.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>www.google.com</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The type of data contained in this resource record.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>CNAME</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// The class of DNS data contained in this resource record.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>IN</example>
		[DataMember(Name = "class")]
		public string Class { get; set; }

		/// <summary>
		/// The time interval in seconds that this resource record may be cached before it should be discarded. Zero values mean that the data should not be cached.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>180</example>
		[DataMember(Name = "ttl")]
		public long? Ttl { get; set; }

		/// <summary>
		/// The data describing the resource.<para/>The meaning of this data depends on the type and class of the resource record.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>10.10.10.10</example>
		[DataMember(Name = "data")]
		public string Data { get; set; }

	}

	/// <summary>
	/// Fields describing DNS queries and answers.<para/>DNS events should either represent a single DNS query prior to getting answers (`dns.type:query`) or they should represent a full exchange and contain the query details as well as all of the answers that were provided for this query (`dns.type:answer`).
	/// </summary>
	public class Dns 
	{
		/// <summary>
		/// Question property.
		/// </summary>
		[DataMember(Name = "question")]
		public DnsQuestion Question { get; set; }

		/// <summary>
		/// An array containing an object for each answer section returned by the server.<para/>The main keys that should be present in these objects are defined by ECS. Records that have more information may contain more keys than what ECS defines.<para/>Not all DNS data sources give all details about DNS answers. At minimum, answer objects must contain the `data` key. If more information is available, map as much of it to ECS as possible, and add any additional fields to the answer objects as custom fields.
		/// </summary>
		[DataMember(Name = "answers")]
		public DnsAnswers[] Answers { get; set; }

		/// <summary>
		/// The type of DNS event captured, query or answer.<para/>If your source of DNS events only gives you DNS queries, you should only create dns events of type `dns.type:query`.<para/>If your source of DNS events gives you answers as well, you should create one event per query (optionally as soon as the query is seen). And a second event containing all query details as well as an array of answers.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>answer</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// The DNS packet identifier assigned by the program that generated the query. The identifier is copied to the response.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>62111</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// The DNS operation code that specifies the kind of query in the message. This value is set by the originator of a query and copied into the response.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>QUERY</example>
		[DataMember(Name = "op_code")]
		public string OpCode { get; set; }

		/// <summary>
		/// Array of 2 letter DNS header flags.<para/>Expected values are: AA, TC, RD, RA, AD, CD, DO.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>["RD","RA"]</example>
		[DataMember(Name = "header_flags")]
		public string[] HeaderFlags { get; set; }

		/// <summary>
		/// The DNS response code.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>NOERROR</example>
		[DataMember(Name = "response_code")]
		public string ResponseCode { get; set; }

		/// <summary>
		/// Array containing all IPs seen in `answers.data`.<para/>The `answers` array can be difficult to use, because of the variety of data formats it can contain. Extracting all IP addresses seen in there to `dns.resolved_ip` makes it possible to index them as IP addresses, and makes them easier to visualize and query for.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>["10.10.10.10","10.10.10.11"]</example>
		[DataMember(Name = "resolved_ip")]
		public string[] ResolvedIp { get; set; }

	}

	/// <summary>
	/// Meta-information specific to ECS.
	/// </summary>
	public class Ecs 
	{
		/// <summary>
		/// ECS version this event conforms to. `ecs.version` is a required field and must exist in all events.<para/>When querying across multiple indices -- which may conform to slightly different ECS versions -- this field lets integrations adjust to the schema version of the events.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>1.0.0</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// These fields can represent errors of any kind.<para/>Use them for errors that happen while fetching events or in cases where the event itself contains an error.
	/// </summary>
	public class Error 
	{
		/// <summary>
		/// Unique identifier for the error.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Error message.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "message")]
		public string Message { get; set; }

		/// <summary>
		/// Error code describing the error.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "code")]
		public string Code { get; set; }

		/// <summary>
		/// The type of the error, for example the class name of the exception.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>java.lang.NullPointerException</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// The stack trace of this error in plain text.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "stack_trace")]
		public string StackTrace { get; set; }

	}

	/// <summary>
	/// The event fields are used for context information about the log or metric event itself.<para/>A log is defined as an event containing details of something that happened. Log events must include the time at which the thing happened. Examples of log events include a process starting on a host, a network packet being sent from a source to a destination, or a network connection between a client and a server being initiated or closed. A metric is defined as an event containing one or more numerical or categorical measurements and the time at which the measurement was taken. Examples of metric events include memory pressure measured on a host, or vulnerabilities measured on a scanned host.
	/// </summary>
	public class Event 
	{
		/// <summary>
		/// Unique ID to describe the event.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>8a4f500d</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Identification code for this event, if one exists.<para/>Some event sources use event codes to identify messages unambiguously, regardless of message language or wording adjustments over time. An example of this is the Windows Event ID.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>4648</example>
		[DataMember(Name = "code")]
		public string Code { get; set; }

		/// <summary>
		/// The kind of the event.<para/>This gives information about what type of information the event contains, without being specific to the contents of the event.  Examples are `event`, `state`, `alarm`. Warning: In future versions of ECS, we plan to provide a list of acceptable values for this field, please use with caution.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>state</example>
		[DataMember(Name = "kind")]
		public string Kind { get; set; }

		/// <summary>
		/// Event category.<para/>This contains high-level information about the contents of the event. It is more generic than `event.action`, in the sense that typically a category contains multiple actions. Warning: In future versions of ECS, we plan to provide a list of acceptable values for this field, please use with caution.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>user-management</example>
		[DataMember(Name = "category")]
		public string Category { get; set; }

		/// <summary>
		/// The action captured by the event.<para/>This describes the information in the event. It is more specific than `event.category`. Examples are `group-add`, `process-started`, `file-created`. The value is normally defined by the implementer.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>user-password-change</example>
		[DataMember(Name = "action")]
		public string Action { get; set; }

		/// <summary>
		/// The outcome of the event.<para/>If the event describes an action, this fields contains the outcome of that action. Examples outcomes are `success` and `failure`. Warning: In future versions of ECS, we plan to provide a list of acceptable values for this field, please use with caution.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>success</example>
		[DataMember(Name = "outcome")]
		public string Outcome { get; set; }

		/// <summary>
		/// Reserved for future usage.<para/>Please avoid using this field for user data.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Name of the module this data is coming from.<para/>If your monitoring agent supports the concept of modules or plugins to process events of a given source (e.g. Apache logs), `event.module` should contain the name of this module.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>apache</example>
		[DataMember(Name = "module")]
		public string Module { get; set; }

		/// <summary>
		/// Name of the dataset.<para/>If an event source publishes more than one type of log or events (e.g. access log, error log), the dataset is used to specify which one the event comes from.<para/>It's recommended but not required to start the dataset name with the module name, followed by a dot, then the dataset name.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>apache.access</example>
		[DataMember(Name = "dataset")]
		public string Dataset { get; set; }

		/// <summary>
		/// Source of the event.<para/>Event transports such as Syslog or the Windows Event Log typically mention the source of an event. It can be the name of the software that generated the event (e.g. Sysmon, httpd), or of a subsystem of the operating system (kernel, Microsoft-Windows-Security-Auditing).
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>kernel</example>
		[DataMember(Name = "provider")]
		public string Provider { get; set; }

		/// <summary>
		/// The numeric severity of the event according to your event source.<para/>What the different severity values mean can be different between sources and use cases. It's up to the implementer to make sure severities are consistent across events from the same source.<para/>The Syslog severity belongs in `log.syslog.severity.code`. `event.severity` is meant to represent the severity according to the event source (e.g. firewall, IDS). If the event source does not publish its own severity, you may optionally copy the `log.syslog.severity.code` to `event.severity`.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>7</example>
		[DataMember(Name = "severity")]
		public long? Severity { get; set; }

		/// <summary>
		/// Raw text message of entire event. Used to demonstrate log integrity.<para/>This field is not indexed and doc_values are disabled. It cannot be searched, but it can be retrieved from `_source`.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>Sep 19 08:26:10 host CEF:0&#124;Security&#124; threatmanager&#124;1.0&#124;100&#124; worm successfully stopped&#124;10&#124;src=10.0.0.1 dst=2.1.2.2spt=1232</example>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		/// <summary>
		/// Hash (perhaps logstash fingerprint) of raw field to be able to demonstrate log integrity.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>123456789012345678901234567890ABCD</example>
		[DataMember(Name = "hash")]
		public string Hash { get; set; }

		/// <summary>
		/// Duration of the event in nanoseconds.<para/>If event.start and event.end are known this value should be the difference between the end and start time.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "duration")]
		public long? Duration { get; set; }

		/// <summary>
		/// Sequence number of the event.<para/>The sequence number is a value published by some event sources, to make the exact ordering of events unambiguous, regarless of the timestamp precision.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "sequence")]
		public long? Sequence { get; set; }

		/// <summary>
		/// This field should be populated when the event's timestamp does not include timezone information already (e.g. default Syslog timestamps). It's optional otherwise.<para/>Acceptable timezone formats are: a canonical ID (e.g. "Europe/Amsterdam"), abbreviated (e.g. "EST") or an HH:mm differential (e.g. "-05:00").
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "timezone")]
		public string Timezone { get; set; }

		/// <summary>
		/// event.created contains the date/time when the event was first read by an agent, or by your pipeline.<para/>This field is distinct from @timestamp in that @timestamp typically contain the time extracted from the original event.<para/>In most situations, these two timestamps will be slightly different. The difference can be used to calculate the delay between your source generating an event, and the time when your agent first processed it. This can be used to monitor your agent's or pipeline's ability to keep up with your event source.<para/>In case the two timestamps are identical, @timestamp should be used.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>2016-05-23 08:05:34.857000</example>
		[DataMember(Name = "created")]
		public DateTimeOffset? Created { get; set; }

		/// <summary>
		/// event.start contains the date when the event started or when the activity was first observed.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "start")]
		public DateTimeOffset? Start { get; set; }

		/// <summary>
		/// event.end contains the date when the event ended or when the activity was last observed.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "end")]
		public DateTimeOffset? End { get; set; }

		/// <summary>
		/// Risk score or priority of the event (e.g. security solutions). Use your system's original value here.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "risk_score")]
		public float? RiskScore { get; set; }

		/// <summary>
		/// Normalized risk score or priority of the event, on a scale of 0 to 100.<para/>This is mainly useful if you use more than one system that assigns risk scores, and you want to see a normalized value across all systems.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "risk_score_norm")]
		public float? RiskScoreNorm { get; set; }

		/// <summary>
		/// Timestamp when an event arrived in the central data store.<para/>This is different from `@timestamp`, which is when the event originally occurred.  It's also different from `event.created`, which is meant to capture the first time an agent saw the event.<para/>In normal conditions, assuming no tampering, the timestamps should chronologically look like this: `@timestamp` < `event.created` < `event.ingested`.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>2016-05-23 08:05:35.101000</example>
		[DataMember(Name = "ingested")]
		public DateTimeOffset? Ingested { get; set; }

	}

	/// <summary>
	/// A file is defined as a set of information that has been created on, or has existed on a filesystem.<para/>File objects can be associated with host events, network events, and/or file events (e.g., those produced by File Integrity Monitoring [FIM] products or services). File fields provide details about the affected file associated with the event or metric.
	/// </summary>
	public class File 
	{
		/// <summary>
		/// Hash nested field.
		/// <para/>
		/// The hash fields represent different hash algorithms and their values.&lt;para/&gt;Field names for common hashes (e.g. MD5, SHA1) are predefined. Add fields for other hashes by lowercasing the hash algorithm name and using underscore separators as appropriate (snake case, e.g. sha3_512).
		/// </summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		/// <summary>
		/// Name of the file including the extension, without the directory.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>example.png</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Directory where the file is located.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>/home/alice</example>
		[DataMember(Name = "directory")]
		public string Directory { get; set; }

		/// <summary>
		/// Full path to the file.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>/home/alice/example.png</example>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		/// <summary>
		/// Target path for symlinks.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "target_path")]
		public string TargetPath { get; set; }

		/// <summary>
		/// File extension.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>png</example>
		[DataMember(Name = "extension")]
		public string Extension { get; set; }

		/// <summary>
		/// File type (file, dir, or symlink).
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>file</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Device that is the source of the file.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>sda</example>
		[DataMember(Name = "device")]
		public string Device { get; set; }

		/// <summary>
		/// Inode representing the file in the filesystem.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>256383</example>
		[DataMember(Name = "inode")]
		public string Inode { get; set; }

		/// <summary>
		/// The user ID (UID) or security identifier (SID) of the file owner.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1001</example>
		[DataMember(Name = "uid")]
		public string Uid { get; set; }

		/// <summary>
		/// File owner's username.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>alice</example>
		[DataMember(Name = "owner")]
		public string Owner { get; set; }

		/// <summary>
		/// Primary group ID (GID) of the file.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1001</example>
		[DataMember(Name = "gid")]
		public string Gid { get; set; }

		/// <summary>
		/// Primary group name of the file.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>alice</example>
		[DataMember(Name = "group")]
		public string Group { get; set; }

		/// <summary>
		/// Mode of the file in octal representation.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>0640</example>
		[DataMember(Name = "mode")]
		public string Mode { get; set; }

		/// <summary>
		/// File size in bytes.<para/>Only relevant when `file.type` is "file".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>16384</example>
		[DataMember(Name = "size")]
		public long? Size { get; set; }

		/// <summary>
		/// Last time the file content was modified.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "mtime")]
		public DateTimeOffset? Mtime { get; set; }

		/// <summary>
		/// Last time the file attributes or metadata changed.<para/>Note that changes to the file content will update `mtime`. This implies `ctime` will be adjusted at the same time, since `mtime` is an attribute of the file.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "ctime")]
		public DateTimeOffset? Ctime { get; set; }

		/// <summary>
		/// File creation time.<para/>Note that not all filesystems store the creation time.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "created")]
		public DateTimeOffset? Created { get; set; }

		/// <summary>
		/// Last time the file was accessed.<para/>Note that not all filesystems keep track of access time.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "accessed")]
		public DateTimeOffset? Accessed { get; set; }

	}

	/// <summary>
	/// Geo fields can carry data about a specific location related to an event.<para/>This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
	/// </summary>
	public class Geo 
	{
		/// <summary>
		/// Longitude and latitude.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
		[DataMember(Name = "location")]
		public Location Location { get; set; }

		/// <summary>
		/// Name of the continent.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>North America</example>
		[DataMember(Name = "continent_name")]
		public string ContinentName { get; set; }

		/// <summary>
		/// Country name.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>Canada</example>
		[DataMember(Name = "country_name")]
		public string CountryName { get; set; }

		/// <summary>
		/// Region name.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>Quebec</example>
		[DataMember(Name = "region_name")]
		public string RegionName { get; set; }

		/// <summary>
		/// City name.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>Montreal</example>
		[DataMember(Name = "city_name")]
		public string CityName { get; set; }

		/// <summary>
		/// Country ISO code.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>CA</example>
		[DataMember(Name = "country_iso_code")]
		public string CountryIsoCode { get; set; }

		/// <summary>
		/// Region ISO code.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>CA-QC</example>
		[DataMember(Name = "region_iso_code")]
		public string RegionIsoCode { get; set; }

		/// <summary>
		/// User-defined description of a location, at the level of granularity they care about.<para/>Could be the name of their data centers, the floor number, if this describes a local physical entity, city names.<para/>Not typically used in automated geolocation.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>boston-dc</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// The group fields are meant to represent groups that are relevant to the event.
	/// </summary>
	public class Group 
	{
		/// <summary>
		/// Unique identifier for the group on the system/platform.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Name of the group.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Name of the directory the group is a member of.<para/>For example, an LDAP or Active Directory domain name.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

	}

	/// <summary>
	/// The hash fields represent different hash algorithms and their values.<para/>Field names for common hashes (e.g. MD5, SHA1) are predefined. Add fields for other hashes by lowercasing the hash algorithm name and using underscore separators as appropriate (snake case, e.g. sha3_512).
	/// </summary>
	public class Hash 
	{
		/// <summary>
		/// MD5 hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "md5")]
		public string Md5 { get; set; }

		/// <summary>
		/// SHA1 hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "sha1")]
		public string Sha1 { get; set; }

		/// <summary>
		/// SHA256 hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "sha256")]
		public string Sha256 { get; set; }

		/// <summary>
		/// SHA512 hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "sha512")]
		public string Sha512 { get; set; }

	}

	/// <summary>
	/// A host is defined as a general computing instance.<para/>ECS host.* fields should be populated with details about the host on which the event happened, or from which the measurement was taken. Host types include hardware, virtual machines, Docker containers, and Kubernetes nodes.
	/// </summary>
	public class Host 
	{
		/// <summary>
		/// Geo nested field.
		/// <para/>
		/// Geo fields can carry data about a specific location related to an event.&lt;para/&gt;This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Os nested field.
		/// <para/>
		/// The OS fields contain information about the operating system.
		/// </summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }

		/// <summary>
		/// User nested field.
		/// <para/>
		/// The user fields describe information about the user that is relevant to the event.&lt;para/&gt;Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Hostname of the host.<para/>It normally contains what the `hostname` command returns on the host machine.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "hostname")]
		public string Hostname { get; set; }

		/// <summary>
		/// Name of the host.<para/>It can contain what `hostname` returns on Unix systems, the fully qualified domain name, or a name specified by the user. The sender decides which value to use.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Unique host id.<para/>As hostname is not always unique, use values that are meaningful in your environment.<para/>Example: The current usage of `beat.name`.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Host ip address.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Host mac address.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// Type of host.<para/>For Cloud providers this can be the machine type like `t2.medium`. If vm, this could be the container, for example, or other information meaningful in your environment.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Seconds the host has been up.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1325</example>
		[DataMember(Name = "uptime")]
		public long? Uptime { get; set; }

		/// <summary>
		/// Operating system architecture.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>x86_64</example>
		[DataMember(Name = "architecture")]
		public string Architecture { get; set; }

		/// <summary>
		/// Name of the domain of which the host is a member. <para/>For example, on Windows this could be the host's Active Directory domain or NetBIOS domain name.  For Linux this could be the domain of the host's LDAP provider.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>CONTOSO</example>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

	}

	/// <summary>
	/// RequestBody, property of <see cref="HttpRequest" />
	/// </summary>
	public class RequestBody
	{
		/// <summary>
		/// Request The full HTTP request body.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Hello world</example>
		[DataMember(Name = "content")]
		public string Content { get; set; }

		/// <summary>
		/// Request Size in bytes of the request body.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>887</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

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
		/// HTTP request method.<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>get, post, put</example>
		[DataMember(Name = "method")]
		public string Method { get; set; }

		/// <summary>
		/// Referrer for this HTTP request.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>https://blog.example.com/</example>
		[DataMember(Name = "referrer")]
		public string Referrer { get; set; }

		/// <summary>
		/// Total size in bytes of the request (body and headers).
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1437</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

	}

	/// <summary>
	/// ResponseBody, property of <see cref="HttpResponse" />
	/// </summary>
	public class ResponseBody
	{
		/// <summary>
		/// Response The full HTTP response body.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Hello world</example>
		[DataMember(Name = "content")]
		public string Content { get; set; }

		/// <summary>
		/// Response Size in bytes of the response body.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>887</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

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
		/// HTTP response status code.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>404</example>
		[DataMember(Name = "status_code")]
		public long? StatusCode { get; set; }

		/// <summary>
		/// Total size in bytes of the response (body and headers).
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1437</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

	}

	/// <summary>
	/// Fields related to HTTP activity. Use the `url` field set to store the url of the request.
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
		/// <remarks>Extended</remarks>
		/// <example>1.1</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// OriginFile, property of <see cref="LogOrigin" />
	/// </summary>
	public class OriginFile
	{
		/// <summary>
		/// Origin The name of the file containing the source code which originated the log event. Note that this is not the name of the log file.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Bootstrap.java</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Origin The line number of the file containing the source code which originated the log event.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>42</example>
		[DataMember(Name = "line")]
		public int? Line { get; set; }

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
		/// <remarks>Extended</remarks>
		/// <example>init</example>
		[DataMember(Name = "function")]
		public string Function { get; set; }

	}

	/// <summary>
	/// SyslogSeverity, property of <see cref="LogSyslog" />
	/// </summary>
	public class SyslogSeverity
	{
		/// <summary>
		/// Syslog The Syslog numeric severity of the log event, if available.<para/>If the event source publishing via Syslog provides a different numeric severity value (e.g. firewall, IDS), your source's numeric severity should go to `event.severity`. If the event source does not specify a distinct severity, you can optionally copy the Syslog severity to `event.severity`.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>3</example>
		[DataMember(Name = "code")]
		public long? Code { get; set; }

		/// <summary>
		/// Syslog The Syslog numeric severity of the log event, if available.<para/>If the event source publishing via Syslog provides a different severity value (e.g. firewall, IDS), your source's text severity should go to `log.level`. If the event source does not specify a distinct severity, you can optionally copy the Syslog severity to `log.level`.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Error</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// SyslogFacility, property of <see cref="LogSyslog" />
	/// </summary>
	public class SyslogFacility
	{
		/// <summary>
		/// Syslog The Syslog numeric facility of the log event, if available.<para/>According to RFCs 5424 and 3164, this value should be an integer between 0 and 23.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>23</example>
		[DataMember(Name = "code")]
		public long? Code { get; set; }

		/// <summary>
		/// Syslog The Syslog text-based facility of the log event, if available.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>local7</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// Syslog, property of <see cref="Log" />
	/// </summary>
	public class LogSyslog
	{
		/// <summary>
		/// Severity property.
		/// </summary>		   
		[DataMember(Name = "severity")]
		public SyslogSeverity Severity { get; set; }

		/// <summary>
		/// Facility property.
		/// </summary>		   
		[DataMember(Name = "facility")]
		public SyslogFacility Facility { get; set; }

		/// <summary>
		/// Syslog numeric priority of the event, if available.<para/>According to RFCs 5424 and 3164, the priority is 8 * facility + severity. This number is therefore expected to contain a value between 0 and 191.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>135</example>
		[DataMember(Name = "priority")]
		public long? Priority { get; set; }

	}

	/// <summary>
	/// Details about the event's logging mechanism or logging transport.<para/>The log.* fields are typically populated with details about the logging mechanism used to create and/or transport the event. For example, syslog details belong under `log.syslog.*`.<para/>The details specific to your event source are typically not logged under `log.*`, but rather in `event.*` or in other ECS fields.
	/// </summary>
	public partial class Log 
	{
		/// <summary>
		/// Origin property.
		/// </summary>
		[DataMember(Name = "origin")]
		public LogOrigin Origin { get; set; }

		/// <summary>
		/// The Syslog metadata of the event, if the event was transmitted via Syslog. Please see RFCs 5424 or 3164.
		/// </summary>
		[DataMember(Name = "syslog")]
		public LogSyslog[] Syslog { get; set; }

		/// <summary>
		/// Original log level of the log event.<para/>If the source of the event provides a log level or textual severity, this is the one that goes in `log.level`. If your source doesn't specify one, you may put your event transport's severity here (e.g. Syslog severity).<para/>Some examples are `warn`, `err`, `i`, `informational`.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>error</example>
		[DataMember(Name = "level")]
		public string Level { get; set; }

		/// <summary>
		/// This is the original log message and contains the full log message before splitting it up in multiple parts.<para/>In contrast to the `message` field which can contain an extracted part of the log message, this field contains the original, full log message. It can have already some modifications applied like encoding or new lines removed to clean up the log message.<para/>This field is not indexed and doc_values are disabled so it can't be queried but the value can be retrieved from `_source`.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>Sep 19 08:26:10 localhost My log</example>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		/// <summary>
		/// The name of the logger inside an application. This is usually the name of the class which initialized the logger, or can be a custom name.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>org.elasticsearch.bootstrap.Bootstrap</example>
		[DataMember(Name = "logger")]
		public string Logger { get; set; }

	}

	/// <summary>
	/// The network is defined as the communication path over which a host or network event happens.<para/>The network.* fields should be populated with details about the network activity associated with an event.
	/// </summary>
	public class Network 
	{
		/// <summary>
		/// Name given by operators to sections of their network.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Guest Wifi</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// In the OSI Model this would be the Network Layer. ipv4, ipv6, ipsec, pim, etc<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>ipv4</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// IANA Protocol Number (https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xhtml). Standardized list of protocols. This aligns well with NetFlow and sFlow related logs which use the IANA Protocol Number.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>6</example>
		[DataMember(Name = "iana_number")]
		public string IanaNumber { get; set; }

		/// <summary>
		/// Same as network.iana_number, but instead using the Keyword name of the transport layer (udp, tcp, ipv6-icmp, etc.)<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>tcp</example>
		[DataMember(Name = "transport")]
		public string Transport { get; set; }

		/// <summary>
		/// A name given to an application level protocol. This can be arbitrarily assigned for things like microservices, but also apply to things like skype, icq, facebook, twitter. This would be used in situations where the vendor or service can be decoded such as from the source/dest IP owners, ports, or wire format.<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>aim</example>
		[DataMember(Name = "application")]
		public string Application { get; set; }

		/// <summary>
		/// L7 Network protocol name. ex. http, lumberjack, transport protocol.<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>http</example>
		[DataMember(Name = "protocol")]
		public string Protocol { get; set; }

		/// <summary>
		/// Direction of the network traffic.<para/>Recommended values are:<para/>  * inbound<para/>  * outbound<para/>  * internal<para/>  * external<para/>  * unknown<para/><para/>When mapping events from a host-based monitoring context, populate this field from the host's point of view.<para/>When mapping events from a network or perimeter-based monitoring context, populate this field from the point of view of your network perimeter.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>inbound</example>
		[DataMember(Name = "direction")]
		public string Direction { get; set; }

		/// <summary>
		/// Host IP address when the source IP address is the proxy.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>192.1.1.2</example>
		[DataMember(Name = "forwarded_ip")]
		public string ForwardedIp { get; set; }

		/// <summary>
		/// A hash of source and destination IPs and ports, as well as the protocol used in a communication. This is a tool-agnostic standard to identify flows.<para/>Learn more at https://github.com/corelight/community-id-spec.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1:hO+sN4H+MG5MY/8hIrXPqc4ZQz0=</example>
		[DataMember(Name = "community_id")]
		public string CommunityId { get; set; }

		/// <summary>
		/// Total bytes transferred in both directions.<para/>If `source.bytes` and `destination.bytes` are known, `network.bytes` is their sum.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>368</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Total packets transferred in both directions.<para/>If `source.packets` and `destination.packets` are known, `network.packets` is their sum.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>24</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

	}

	/// <summary>
	/// An observer is defined as a special network, security, or application device used to detect, observe, or create network, security, or application-related events and metrics.<para/>This could be a custom hardware appliance or a server that has been configured to run special network, security, or application software. Examples include firewalls, web proxies, intrusion detection/prevention systems, network monitoring sensors, web application firewalls, data loss prevention systems, and APM servers. The observer.* fields shall be populated with details of the system, if any, that detects, observes and/or creates a network, security, or application event or metric. Message queues and ETL components used in processing events or metrics are not considered observers in ECS.
	/// </summary>
	public class Observer 
	{
		/// <summary>
		/// Geo nested field.
		/// <para/>
		/// Geo fields can carry data about a specific location related to an event.&lt;para/&gt;This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Os nested field.
		/// <para/>
		/// The OS fields contain information about the operating system.
		/// </summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }

		/// <summary>
		/// MAC address of the observer
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// IP address of the observer.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Hostname of the observer.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "hostname")]
		public string Hostname { get; set; }

		/// <summary>
		/// Custom name of the observer.<para/>This is a name that can be given to an observer. This can be helpful for example if multiple firewalls of the same model are used in an organization.<para/>If no custom name is needed, the field can be left empty.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1_proxySG</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The product name of the observer.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>s200</example>
		[DataMember(Name = "product")]
		public string Product { get; set; }

		/// <summary>
		/// Vendor name of the observer.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>Symantec</example>
		[DataMember(Name = "vendor")]
		public string Vendor { get; set; }

		/// <summary>
		/// Observer version.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		/// <summary>
		/// Observer serial number.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "serial_number")]
		public string SerialNumber { get; set; }

		/// <summary>
		/// The type of the observer the data is coming from.<para/>There is no predefined list of observer types. Some examples are `forwarder`, `firewall`, `ids`, `ips`, `proxy`, `poller`, `sensor`, `APM server`.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>firewall</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}

	/// <summary>
	/// The organization fields enrich data with information about the company or entity the data is associated with.<para/>These fields help you arrange or filter data stored in an index by one or multiple organizations.
	/// </summary>
	public class Organization 
	{
		/// <summary>
		/// Organization name.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Unique identifier for the organization.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "id")]
		public string Id { get; set; }

	}

	/// <summary>
	/// The OS fields contain information about the operating system.
	/// </summary>
	public class Os 
	{
		/// <summary>
		/// Operating system platform (such centos, ubuntu, windows).
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>darwin</example>
		[DataMember(Name = "platform")]
		public string Platform { get; set; }

		/// <summary>
		/// Operating system name, without the version.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Mac OS X</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Operating system name, including the version or code name.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Mac OS Mojave</example>
		[DataMember(Name = "full")]
		public string Full { get; set; }

		/// <summary>
		/// OS family (such as redhat, debian, freebsd, windows).
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>debian</example>
		[DataMember(Name = "family")]
		public string Family { get; set; }

		/// <summary>
		/// Operating system version as a raw string.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>10.14.1</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		/// <summary>
		/// Operating system kernel version as a raw string.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>4.4.0-112-generic</example>
		[DataMember(Name = "kernel")]
		public string Kernel { get; set; }

	}

	/// <summary>
	/// These fields contain information about an installed software package. It contains general information about a package, such as name, version or size. It also contains installation details, such as time or location.
	/// </summary>
	public class Package 
	{
		/// <summary>
		/// Package name
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>go</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Package version
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1.12.9</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		/// <summary>
		/// Additional information about the build version of the installed package.<para/>For example use the commit SHA of a non-released package.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>36f4f7e89dd61b0988b12ee000b98966867710cd</example>
		[DataMember(Name = "build_version")]
		public string BuildVersion { get; set; }

		/// <summary>
		/// Description of the package.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Open source programming language to build simple/reliable/efficient software.</example>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// Package size in bytes.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>62231</example>
		[DataMember(Name = "size")]
		public long? Size { get; set; }

		/// <summary>
		/// Time when package was installed.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "installed")]
		public DateTimeOffset? Installed { get; set; }

		/// <summary>
		/// Path where the package is installed.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>/usr/local/Cellar/go/1.12.9/</example>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		/// <summary>
		/// Package architecture.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>x86_64</example>
		[DataMember(Name = "architecture")]
		public string Architecture { get; set; }

		/// <summary>
		/// Checksum of the installed package for verification.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>68b329da9893e34099c7d8ad5cb9c940</example>
		[DataMember(Name = "checksum")]
		public string Checksum { get; set; }

		/// <summary>
		/// Indicating how the package was installed, e.g. user-local, global.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>global</example>
		[DataMember(Name = "install_scope")]
		public string InstallScope { get; set; }

		/// <summary>
		/// License under which the package was released.<para/>Use a short name, e.g. the license identifier from SPDX License List where possible (https://spdx.org/licenses/).
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Apache License 2.0</example>
		[DataMember(Name = "license")]
		public string License { get; set; }

		/// <summary>
		/// Home page or reference URL of the software in this package, if available.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>https://golang.org</example>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		/// <summary>
		/// Type of package.<para/>This should contain the package file type, rather than the package manager name. Examples: rpm, dpkg, brew, npm, gem, nupkg, jar.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>rpm</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

	}

	/// <summary>
	/// ParentThread, property of <see cref="ProcessParent" />
	/// </summary>
	public class ParentThread
	{
		/// <summary>
		/// Parent Thread ID.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>4242</example>
		[DataMember(Name = "id")]
		public long? Id { get; set; }

		/// <summary>
		/// Parent Thread name.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>thread-0</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// Parent, property of <see cref="Process" />
	/// </summary>
	public class ProcessParent
	{
		/// <summary>
		/// Thread property.
		/// </summary>		   
		[DataMember(Name = "thread")]
		public ParentThread Thread { get; set; }

		/// <summary>
		/// Process id.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>4242</example>
		[DataMember(Name = "pid")]
		public long? Pid { get; set; }

		/// <summary>
		/// Process name.<para/>Sometimes called program name or similar.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>ssh</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Parent process' pid.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>4241</example>
		[DataMember(Name = "ppid")]
		public long? Ppid { get; set; }

		/// <summary>
		/// Identifier of the group of processes the process belongs to.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "pgid")]
		public long? Pgid { get; set; }

		/// <summary>
		/// Full command line that started the process, including the absolute path to the executable, and all arguments.<para/>Some arguments may be filtered to protect sensitive information.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>/usr/bin/ssh -l user 10.0.0.16</example>
		[DataMember(Name = "command_line")]
		public string CommandLine { get; set; }

		/// <summary>
		/// Array of process arguments.<para/>May be filtered to protect sensitive information.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>["ssh","-l","user","10.0.0.16"]</example>
		[DataMember(Name = "args")]
		public string[] Args { get; set; }

		/// <summary>
		/// Length of the process.args array.<para/>This field can be useful for querying or performing bucket analysis on how many arguments were provided to start a process. More arguments may be an indication of suspicious activity.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>4</example>
		[DataMember(Name = "args_count")]
		public long? ArgsCount { get; set; }

		/// <summary>
		/// Absolute path to the process executable.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>/usr/bin/ssh</example>
		[DataMember(Name = "executable")]
		public string Executable { get; set; }

		/// <summary>
		/// Process title.<para/>The proctitle, some times the same as process name. Can also be different: for example a browser setting its title to the web page currently opened.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "title")]
		public string Title { get; set; }

		/// <summary>
		/// The time the process started.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>2016-05-23T08:05:34.853Z</example>
		[DataMember(Name = "start")]
		public DateTimeOffset? Start { get; set; }

		/// <summary>
		/// Seconds the process has been up.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1325</example>
		[DataMember(Name = "uptime")]
		public long? Uptime { get; set; }

		/// <summary>
		/// The working directory of the process.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>/home/alice</example>
		[DataMember(Name = "working_directory")]
		public string WorkingDirectory { get; set; }

		/// <summary>
		/// The exit code of the process, if this is a termination event.<para/>The field should be absent if there is no exit code for the event (e.g. process start).
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>137</example>
		[DataMember(Name = "exit_code")]
		public long? ExitCode { get; set; }

	}

	/// <summary>
	/// Thread, property of <see cref="Process" />
	/// </summary>
	public class ProcessThread
	{
		/// <summary>
		/// Thread ID.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>4242</example>
		[DataMember(Name = "id")]
		public long? Id { get; set; }

		/// <summary>
		/// Thread name.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>thread-0</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// These fields contain information about a process.<para/>These fields can help you correlate metrics information with a process id/name from a log message.  The `process.pid` often stays in the metric itself and is copied to the global field for correlation.
	/// </summary>
	public class Process 
	{
		/// <summary>
		/// Hash nested field.
		/// <para/>
		/// The hash fields represent different hash algorithms and their values.&lt;para/&gt;Field names for common hashes (e.g. MD5, SHA1) are predefined. Add fields for other hashes by lowercasing the hash algorithm name and using underscore separators as appropriate (snake case, e.g. sha3_512).
		/// </summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		/// <summary>
		/// Parent property.
		/// </summary>
		[DataMember(Name = "parent")]
		public ProcessParent Parent { get; set; }

		/// <summary>
		/// Thread property.
		/// </summary>
		[DataMember(Name = "thread")]
		public ProcessThread Thread { get; set; }

		/// <summary>
		/// Process id.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>4242</example>
		[DataMember(Name = "pid")]
		public long? Pid { get; set; }

		/// <summary>
		/// Process name.<para/>Sometimes called program name or similar.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>ssh</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Parent process' pid.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>4241</example>
		[DataMember(Name = "ppid")]
		public long? Ppid { get; set; }

		/// <summary>
		/// Identifier of the group of processes the process belongs to.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "pgid")]
		public long? Pgid { get; set; }

		/// <summary>
		/// Full command line that started the process, including the absolute path to the executable, and all arguments.<para/>Some arguments may be filtered to protect sensitive information.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>/usr/bin/ssh -l user 10.0.0.16</example>
		[DataMember(Name = "command_line")]
		public string CommandLine { get; set; }

		/// <summary>
		/// Array of process arguments, starting with the absolute path to the executable.<para/>May be filtered to protect sensitive information.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>["/usr/bin/ssh","-l","user","10.0.0.16"]</example>
		[DataMember(Name = "args")]
		public string[] Args { get; set; }

		/// <summary>
		/// Length of the process.args array.<para/>This field can be useful for querying or performing bucket analysis on how many arguments were provided to start a process. More arguments may be an indication of suspicious activity.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>4</example>
		[DataMember(Name = "args_count")]
		public long? ArgsCount { get; set; }

		/// <summary>
		/// Absolute path to the process executable.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>/usr/bin/ssh</example>
		[DataMember(Name = "executable")]
		public string Executable { get; set; }

		/// <summary>
		/// Process title.<para/>The proctitle, some times the same as process name. Can also be different: for example a browser setting its title to the web page currently opened.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "title")]
		public string Title { get; set; }

		/// <summary>
		/// The time the process started.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>2016-05-23T08:05:34.853Z</example>
		[DataMember(Name = "start")]
		public DateTimeOffset? Start { get; set; }

		/// <summary>
		/// Seconds the process has been up.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1325</example>
		[DataMember(Name = "uptime")]
		public long? Uptime { get; set; }

		/// <summary>
		/// The working directory of the process.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>/home/alice</example>
		[DataMember(Name = "working_directory")]
		public string WorkingDirectory { get; set; }

		/// <summary>
		/// The exit code of the process, if this is a termination event.<para/>The field should be absent if there is no exit code for the event (e.g. process start).
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>137</example>
		[DataMember(Name = "exit_code")]
		public long? ExitCode { get; set; }

	}

	/// <summary>
	/// This field set is meant to facilitate pivoting around a piece of data.<para/>Some pieces of information can be seen in many places in an ECS event. To facilitate searching for them, store an array of all seen values to their corresponding field in `related.`.<para/>A concrete example is IP addresses, which can be under host, observer, source, destination, client, server, and network.forwarded_ip. If you append all IPs to `related.ip`, you can then search for a given IP trivially, no matter where it appeared, by querying `related.ip:a.b.c.d`.
	/// </summary>
	public class Related 
	{
		/// <summary>
		/// All of the IPs seen on your event.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

	}

	/// <summary>
	/// Nat, property of <see cref="Server" />
	/// </summary>
	public class ServerNat
	{
		/// <summary>
		/// Translated ip of destination based NAT sessions (e.g. internet to private DMZ)<para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Translated port of destination based NAT sessions (e.g. internet to private DMZ)<para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

	}

	/// <summary>
	/// A Server is defined as the responder in a network connection for events regarding sessions, connections, or bidirectional flow records.<para/>For TCP events, the server is the receiver of the initial SYN packet(s) of the TCP connection. For other protocols, the server is generally the responder in the network transaction. Some systems actually use the term "responder" to refer the server in TCP connections. The server fields describe details about the system acting as the server in the network event. Server fields are usually populated in conjunction with client fields. Server fields are generally not populated for packet-level events.<para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
	/// </summary>
	public class Server 
	{
		/// <summary>
		/// Geo nested field.
		/// <para/>
		/// Geo fields can carry data about a specific location related to an event.&lt;para/&gt;This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// As nested field.
		/// <para/>
		/// An autonomous system (AS) is a collection of connected Internet Protocol (IP) routing prefixes under the control of one or more network operators on behalf of a single administrative entity or domain that presents a common, clearly defined routing policy to the internet.
		/// </summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		/// <summary>
		/// User nested field.
		/// <para/>
		/// The user fields describe information about the user that is relevant to the event.&lt;para/&gt;Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Nat property.
		/// </summary>
		[DataMember(Name = "nat")]
		public ServerNat Nat { get; set; }

		/// <summary>
		/// Some event server addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		/// <summary>
		/// IP address of the server.<para/>Can be one or multiple IPv4 or IPv6 addresses.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Port of the server.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// MAC address of the server.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// Server domain.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// The highest registered server domain, stripped of the subdomain.<para/>For example, the registered domain for "foo.google.com" is "google.com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>google.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for google.com is "com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

		/// <summary>
		/// Bytes sent from the server to the client.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>184</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Packets sent from the server to the client.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>12</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

	}

	/// <summary>
	/// Node, property of <see cref="Service" />
	/// </summary>
	public class ServiceNode
	{
		/// <summary>
		/// Name of a service node.<para/>This allows for two nodes of the same service running on the same host to be differentiated. Therefore, `service.node.name` should typically be unique across nodes of a given service.<para/>In the case of Elasticsearch, the `service.node.name` could contain the unique node name within the Elasticsearch cluster. In cases where the service doesn't have the concept of a node name, the host name or container name can be used to distinguish running instances that make up this service. If those do not provide uniqueness (e.g. multiple instances of the service running on the same host) - the node name can be manually set.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>instance-0000000016</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// The service fields describe the service for or from which the data was collected.<para/>These fields help you find and correlate logs for a specific service and version.
	/// </summary>
	public class Service 
	{
		/// <summary>
		/// Node property.
		/// </summary>
		[DataMember(Name = "node")]
		public ServiceNode Node { get; set; }

		/// <summary>
		/// Unique identifier of the running service. If the service is comprised of many nodes, the `service.id` should be the same for all nodes.<para/>This id should uniquely identify the service. This makes it possible to correlate logs and metrics for one specific service, no matter which particular node emitted the event.<para/>Note that if you need to see the events from one specific host of the service, you should filter on that `host.name` or `host.id` instead.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>d37e5ebfe0ae6c4972dbe9f0174a1637bb8247f6</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Name of the service data is collected from.<para/>The name of the service is normally user given. This allows for distributed services that run on multiple hosts to correlate the related instances based on the name.<para/>In the case of Elasticsearch the `service.name` could contain the cluster name. For Beats the `service.name` is by default a copy of the `service.type` field if no name is specified.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>elasticsearch-metrics</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The type of the service data is collected from.<para/>The type can be used to group and correlate logs and metrics from one service type.<para/>Example: If logs or metrics are collected from Elasticsearch, `service.type` would be `elasticsearch`.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>elasticsearch</example>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Current state of the service.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "state")]
		public string State { get; set; }

		/// <summary>
		/// Version of the service the data was collected from.<para/>This allows to look at a data set only for a specific version of a service.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>3.2.4</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		/// <summary>
		/// Ephemeral identifier of this service (if one exists).<para/>This id normally changes across restarts, but `service.id` does not.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>8a4f500f</example>
		[DataMember(Name = "ephemeral_id")]
		public string EphemeralId { get; set; }

	}

	/// <summary>
	/// Nat, property of <see cref="Source" />
	/// </summary>
	public class SourceNat
	{
		/// <summary>
		/// Translated ip of source based NAT sessions (e.g. internal client to internet)<para/>Typically connections traversing load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Translated port of source based NAT sessions. (e.g. internal client to internet)<para/>Typically used with load balancers, firewalls, or routers.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

	}

	/// <summary>
	/// Source fields describe details about the source of a packet/event.<para/>Source fields are usually populated in conjunction with destination fields.
	/// </summary>
	public class Source 
	{
		/// <summary>
		/// Geo nested field.
		/// <para/>
		/// Geo fields can carry data about a specific location related to an event.&lt;para/&gt;This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
		/// </summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// As nested field.
		/// <para/>
		/// An autonomous system (AS) is a collection of connected Internet Protocol (IP) routing prefixes under the control of one or more network operators on behalf of a single administrative entity or domain that presents a common, clearly defined routing policy to the internet.
		/// </summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		/// <summary>
		/// User nested field.
		/// <para/>
		/// The user fields describe information about the user that is relevant to the event.&lt;para/&gt;Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
		/// </summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// Nat property.
		/// </summary>
		[DataMember(Name = "nat")]
		public SourceNat Nat { get; set; }

		/// <summary>
		/// Some event source addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		/// <summary>
		/// IP address of the source.<para/>Can be one or multiple IPv4 or IPv6 addresses.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		/// <summary>
		/// Port of the source.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// MAC address of the source.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		/// <summary>
		/// Source domain.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// The highest registered source domain, stripped of the subdomain.<para/>For example, the registered domain for "foo.google.com" is "google.com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>google.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for google.com is "com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

		/// <summary>
		/// Bytes sent from the source to the destination.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>184</example>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		/// <summary>
		/// Packets sent from the source to the destination.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>12</example>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

	}

	/// <summary>
	/// Tactic, property of <see cref="Threat" />
	/// </summary>
	public class ThreatTactic
	{
		/// <summary>
		/// Name of the type of tactic used by this threat. You can use the Mitre ATT&CK Matrix Tactic categorization, for example. (ex. https://attack.mitre.org/tactics/TA0040/ )
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>impact</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The id of tactic used by this threat. You can use the Mitre ATT&CK Matrix Tactic categorization, for example. (ex. https://attack.mitre.org/tactics/TA0040/ )
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>TA0040</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// The reference url of tactic used by this threat. You can use the Mitre ATT&CK Matrix Tactic categorization, for example. (ex. https://attack.mitre.org/tactics/TA0040/ )
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>https://attack.mitre.org/tactics/TA0040/</example>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

	}

	/// <summary>
	/// Technique, property of <see cref="Threat" />
	/// </summary>
	public class ThreatTechnique
	{
		/// <summary>
		/// The name of technique used by this tactic. You can use the Mitre ATT&CK Matrix Tactic categorization, for example. (ex. https://attack.mitre.org/techniques/T1499/ )
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>endpoint denial of service</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The id of technique used by this tactic. You can use the Mitre ATT&CK Matrix Tactic categorization, for example. (ex. https://attack.mitre.org/techniques/T1499/ )
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>T1499</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// The reference url of technique used by this tactic. You can use the Mitre ATT&CK Matrix Tactic categorization, for example. (ex. https://attack.mitre.org/techniques/T1499/ )
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>https://attack.mitre.org/techniques/T1499/</example>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

	}

	/// <summary>
	/// Fields to classify events and alerts according to a threat taxonomy such as the Mitre ATT&CK framework.<para/>These fields are for users to classify alerts from all of their sources (e.g. IDS, NGFW, etc.) within a  common taxonomy. The threat.tactic.* are meant to capture the high level category of the threat  (e.g. "impact"). The threat.technique.* fields are meant to capture which kind of approach is used by  this detected threat, to accomplish the goal (e.g. "endpoint denial of service").
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
		/// Name of the threat framework used to further categorize and classify the tactic and technique of the reported threat.   Framework classification can be provided by detecting systems, evaluated at ingest time, or retrospectively tagged to events.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>MITRE ATT&CK</example>
		[DataMember(Name = "framework")]
		public string Framework { get; set; }

	}

	/// <summary>
	/// ClientHash, property of <see cref="TlsClient" />
	/// </summary>
	public class ClientHash
	{
		/// <summary>
		/// Client Certificate fingerprint using the MD5 digest of DER-encoded version of certificate offered by the client. For consistency with other hash values, this value should be formatted as an uppercase hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>0F76C7F2C55BFD7D8E8B8F4BFBF0C9EC</example>
		[DataMember(Name = "md5")]
		public string Md5 { get; set; }

		/// <summary>
		/// Client Certificate fingerprint using the SHA1 digest of DER-encoded version of certificate offered by the client. For consistency with other hash values, this value should be formatted as an uppercase hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>9E393D93138888D288266C2D915214D1D1CCEB2A</example>
		[DataMember(Name = "sha1")]
		public string Sha1 { get; set; }

		/// <summary>
		/// Client Certificate fingerprint using the SHA256 digest of DER-encoded version of certificate offered by the client. For consistency with other hash values, this value should be formatted as an uppercase hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>0687F666A054EF17A08E2F2162EAB4CBC0D265E1D7875BE74BF3C712CA92DAF0</example>
		[DataMember(Name = "sha256")]
		public string Sha256 { get; set; }

	}

	/// <summary>
	/// Client, property of <see cref="Tls" />
	/// </summary>
	public class TlsClient
	{
		/// <summary>
		/// Hash property.
		/// </summary>		   
		[DataMember(Name = "hash")]
		public ClientHash Hash { get; set; }

		/// <summary>
		/// A hash that identifies clients based on how they perform an SSL/TLS handshake.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>d4e5b18d6b55c71272893221c96ba240</example>
		[DataMember(Name = "ja3")]
		public string Ja3 { get; set; }

		/// <summary>
		/// Also called an SNI, this tells the server which hostname to which the client is attempting to connect. When this value is available, it should get copied to `destination.domain`.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>www.elastic.co</example>
		[DataMember(Name = "server_name")]
		public string ServerName { get; set; }

		/// <summary>
		/// Array of ciphers offered by the client during the client hello.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>["TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384","TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384","..."]</example>
		[DataMember(Name = "supported_ciphers")]
		public string[] SupportedCiphers { get; set; }

		/// <summary>
		/// Distinguished name of subject of the x.509 certificate presented by the client.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>CN=myclient, OU=Documentation Team, DC=mydomain, DC=com</example>
		[DataMember(Name = "subject")]
		public string Subject { get; set; }

		/// <summary>
		/// Distinguished name of subject of the issuer of the x.509 certificate presented by the client.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>CN=MyDomain Root CA, OU=Infrastructure Team, DC=mydomain, DC=com</example>
		[DataMember(Name = "issuer")]
		public string Issuer { get; set; }

		/// <summary>
		/// Date/Time indicating when client certificate is first considered valid.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1970-01-01T00:00:00Z</example>
		[DataMember(Name = "not_before")]
		public DateTimeOffset? NotBefore { get; set; }

		/// <summary>
		/// Date/Time indicating when client certificate is no longer considered valid.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>2021-01-01T00:00:00Z</example>
		[DataMember(Name = "not_after")]
		public DateTimeOffset? NotAfter { get; set; }

		/// <summary>
		/// Array of PEM-encoded certificates that make up the certificate chain offered by the client. This is usually mutually-exclusive of `client.certificate` since that value should be the first certificate in the chain.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>["MII...","MII..."]</example>
		[DataMember(Name = "certificate_chain")]
		public string[] CertificateChain { get; set; }

		/// <summary>
		/// PEM-encoded stand-alone certificate offered by the client. This is usually mutually-exclusive of `client.certificate_chain` since this value also exists in that list.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>MII...</example>
		[DataMember(Name = "certificate")]
		public string Certificate { get; set; }

	}

	/// <summary>
	/// ServerHash, property of <see cref="TlsServer" />
	/// </summary>
	public class ServerHash
	{
		/// <summary>
		/// Server Certificate fingerprint using the MD5 digest of DER-encoded version of certificate offered by the server. For consistency with other hash values, this value should be formatted as an uppercase hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>0F76C7F2C55BFD7D8E8B8F4BFBF0C9EC</example>
		[DataMember(Name = "md5")]
		public string Md5 { get; set; }

		/// <summary>
		/// Server Certificate fingerprint using the SHA1 digest of DER-encoded version of certificate offered by the server. For consistency with other hash values, this value should be formatted as an uppercase hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>9E393D93138888D288266C2D915214D1D1CCEB2A</example>
		[DataMember(Name = "sha1")]
		public string Sha1 { get; set; }

		/// <summary>
		/// Server Certificate fingerprint using the SHA256 digest of DER-encoded version of certificate offered by the server. For consistency with other hash values, this value should be formatted as an uppercase hash.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>0687F666A054EF17A08E2F2162EAB4CBC0D265E1D7875BE74BF3C712CA92DAF0</example>
		[DataMember(Name = "sha256")]
		public string Sha256 { get; set; }

	}

	/// <summary>
	/// Server, property of <see cref="Tls" />
	/// </summary>
	public class TlsServer
	{
		/// <summary>
		/// Hash property.
		/// </summary>		   
		[DataMember(Name = "hash")]
		public ServerHash Hash { get; set; }

		/// <summary>
		/// A hash that identifies servers based on how they perform an SSL/TLS handshake.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>394441ab65754e2207b1e1b457b3641d</example>
		[DataMember(Name = "ja3s")]
		public string Ja3s { get; set; }

		/// <summary>
		/// Array of ciphers offered by the server during the server hello.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>["TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384","TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384","..."]</example>
		[DataMember(Name = "supported_ciphers")]
		public string[] SupportedCiphers { get; set; }

		/// <summary>
		/// Subject of the x.509 certificate presented by the server.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>CN=www.mydomain.com, OU=Infrastructure Team, DC=mydomain, DC=com</example>
		[DataMember(Name = "subject")]
		public string Subject { get; set; }

		/// <summary>
		/// Subject of the issuer of the x.509 certificate presented by the server.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>CN=MyDomain Root CA, OU=Infrastructure Team, DC=mydomain, DC=com</example>
		[DataMember(Name = "issuer")]
		public string Issuer { get; set; }

		/// <summary>
		/// Timestamp indicating when server certificate is first considered valid.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1970-01-01T00:00:00Z</example>
		[DataMember(Name = "not_before")]
		public DateTimeOffset? NotBefore { get; set; }

		/// <summary>
		/// Timestamp indicating when server certificate is no longer considered valid.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>2021-01-01T00:00:00Z</example>
		[DataMember(Name = "not_after")]
		public DateTimeOffset? NotAfter { get; set; }

		/// <summary>
		/// Array of PEM-encoded certificates that make up the certificate chain offered by the server. This is usually mutually-exclusive of `server.certificate` since that value should be the first certificate in the chain.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>["MII...","MII..."]</example>
		[DataMember(Name = "certificate_chain")]
		public string[] CertificateChain { get; set; }

		/// <summary>
		/// PEM-encoded stand-alone certificate offered by the server. This is usually mutually-exclusive of `server.certificate_chain` since this value also exists in that list.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>MII...</example>
		[DataMember(Name = "certificate")]
		public string Certificate { get; set; }

	}

	/// <summary>
	/// Fields related to a TLS connection. These fields focus on the TLS protocol itself and intentionally avoids in-depth analysis of the related x.509 certificate files.
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
		/// Numeric part of the version parsed from the original string.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>1.2</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		/// <summary>
		/// Normalized lowercase protocol name parsed from original string.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>tls</example>
		[DataMember(Name = "version_protocol")]
		public string VersionProtocol { get; set; }

		/// <summary>
		/// String indicating the cipher used during the current connection.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256</example>
		[DataMember(Name = "cipher")]
		public string Cipher { get; set; }

		/// <summary>
		/// String indicating the curve used for the given cipher, when applicable.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>secp256r1</example>
		[DataMember(Name = "curve")]
		public string Curve { get; set; }

		/// <summary>
		/// Boolean flag indicating if this TLS connection was resumed from an existing TLS negotiation.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "resumed")]
		public bool? Resumed { get; set; }

		/// <summary>
		/// Boolean flag indicating if the TLS negotiation was successful and transitioned to an encrypted tunnel.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "established")]
		public bool? Established { get; set; }

		/// <summary>
		/// String indicating the protocol being tunneled. Per the values in the IANA registry (https://www.iana.org/assignments/tls-extensiontype-values/tls-extensiontype-values.xhtml#alpn-protocol-ids), this string should be lower case.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>http/1.1</example>
		[DataMember(Name = "next_protocol")]
		public string NextProtocol { get; set; }

	}

	/// <summary>
	/// Trace, property of <see cref="Tracing" />
	/// </summary>
	public class TracingTrace
	{
		/// <summary>
		/// Unique identifier of the trace.<para/>A trace groups multiple events like transactions that belong together. For example, a user request handled by multiple inter-connected services.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>4bf92f3577b34da6a3ce929d0e0e4736</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

	}

	/// <summary>
	/// Transaction, property of <see cref="Tracing" />
	/// </summary>
	public class TracingTransaction
	{
		/// <summary>
		/// Unique identifier of the transaction.<para/>A transaction is the highest level of work measured within a service, such as a request to a server.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>00f067aa0ba902b7</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

	}

	/// <summary>
	/// Distributed tracing makes it possible to analyze performance throughout a microservice architecture all in one view. This is accomplished by tracing all of the requests - from the initial web request in the front-end service - to queries made through multiple back-end services.
	/// </summary>
	public class Tracing 
	{
		/// <summary>
		/// Trace property.
		/// </summary>
		[DataMember(Name = "trace")]
		public TracingTrace Trace { get; set; }

		/// <summary>
		/// Transaction property.
		/// </summary>
		[DataMember(Name = "transaction")]
		public TracingTransaction Transaction { get; set; }

	}

	/// <summary>
	/// URL fields provide support for complete or partial URLs, and supports the breaking down into scheme, domain, path, and so on.
	/// </summary>
	public class Url 
	{
		/// <summary>
		/// Unmodified original url as seen in the event source.<para/>Note that in network monitoring, the observed URL may be a full URL, whereas in access logs, the URL is often just represented as a path.<para/>This field is meant to represent the URL as it was observed, complete or not.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>https://www.elastic.co:443/search?q=elasticsearch#top or /search?q=elasticsearch</example>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		/// <summary>
		/// If full URLs are important to your use case, they should be stored in `url.full`, whether this field is reconstructed or present in the event source.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>https://www.elastic.co:443/search?q=elasticsearch#top</example>
		[DataMember(Name = "full")]
		public string Full { get; set; }

		/// <summary>
		/// Scheme of the request, such as "https".<para/>Note: The `:` is not part of the scheme.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>https</example>
		[DataMember(Name = "scheme")]
		public string Scheme { get; set; }

		/// <summary>
		/// Domain of the url, such as "www.elastic.co".<para/>In some cases a URL may refer to an IP and/or port directly, without a domain name. In this case, the IP address would go to the `domain` field.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>www.elastic.co</example>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// The highest registered url domain, stripped of the subdomain.<para/>For example, the registered domain for "foo.google.com" is "google.com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last two labels will not work well for TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>google.com</example>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		/// <summary>
		/// The effective top level domain (eTLD), also known as the domain suffix, is the last part of the domain name. For example, the top level domain for google.com is "com".<para/>This value can be determined precisely with a list like the public suffix list (http://publicsuffix.org). Trying to approximate this by simply taking the last label will not work well for effective TLDs such as "co.uk".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>co.uk</example>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

		/// <summary>
		/// Port of the request, such as 443.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>443</example>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		/// <summary>
		/// Path of the request, such as "/search".
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		/// <summary>
		/// The query field describes the query string of the request, such as "q=elasticsearch".<para/>The `?` is excluded from the query string. If a URL contains no `?`, there is no query field. If there is a `?` but no query, the query field exists with an empty string. The `exists` query can be used to differentiate between the two cases.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "query")]
		public string Query { get; set; }

		/// <summary>
		/// The field contains the file extension from the original request url.<para/>The file extension is only set if it exists, as not every url has a file extension.<para/>The leading period must not be included. For example, the value must be "png", not ".png".
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>png</example>
		[DataMember(Name = "extension")]
		public string Extension { get; set; }

		/// <summary>
		/// Portion of the url after the `#`, such as "top".<para/>The `#` is not part of the fragment.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "fragment")]
		public string Fragment { get; set; }

		/// <summary>
		/// Username of the request.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "username")]
		public string Username { get; set; }

		/// <summary>
		/// Password of the request.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "password")]
		public string Password { get; set; }

	}

	/// <summary>
	/// The user fields describe information about the user that is relevant to the event.<para/>Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
	/// </summary>
	public class User 
	{
		/// <summary>
		/// Group nested field.
		/// <para/>
		/// The group fields are meant to represent groups that are relevant to the event.
		/// </summary>
		[DataMember(Name = "group")]
		public Group Group { get; set; }

		/// <summary>
		/// One or multiple unique identifiers of the user.
		/// </summary>
		/// <remarks>Core</remarks>
		[DataMember(Name = "id")]
		public string[] Id { get; set; }

		/// <summary>
		/// Short name or login of the user.
		/// </summary>
		/// <remarks>Core</remarks>
		/// <example>albert</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// User's full name, if available.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Albert Einstein</example>
		[DataMember(Name = "full_name")]
		public string FullName { get; set; }

		/// <summary>
		/// User email address.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "email")]
		public string Email { get; set; }

		/// <summary>
		/// Unique user hash to correlate information for a user in anonymized form.<para/>Useful if `user.id` or `user.name` contain confidential information and cannot be used.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "hash")]
		public string Hash { get; set; }

		/// <summary>
		/// Name of the directory the user is a member of.<para/>For example, an LDAP or Active Directory domain name.
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

	}

	/// <summary>
	/// Device, property of <see cref="UserAgent" />
	/// </summary>
	public class UserAgentDevice
	{
		/// <summary>
		/// Name of the device.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>iPhone</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	}

	/// <summary>
	/// The user_agent fields normally come from a browser request.<para/>They often show up in web service logs coming from the parsed user agent string.
	/// </summary>
	public class UserAgent 
	{
		/// <summary>
		/// Os nested field.
		/// <para/>
		/// The OS fields contain information about the operating system.
		/// </summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }

		/// <summary>
		/// Device property.
		/// </summary>
		[DataMember(Name = "device")]
		public UserAgentDevice Device { get; set; }

		/// <summary>
		/// Unparsed version of the user_agent.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Mozilla/5.0 (iPhone; CPU iPhone OS 12_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/12.0 Mobile/15E148 Safari/604.1</example>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		/// <summary>
		/// Name of the user agent.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Safari</example>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Version of the user agent.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>12.0</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// Score, property of <see cref="Vulnerability" />
	/// </summary>
	public class VulnerabilityScore
	{
		/// <summary>
		/// Scores can range from 0.0 to 10.0, with 10.0 being the most severe.<para/>Base scores cover an assessment for exploitability metrics (attack vector, complexity, privileges, and user interaction), impact metrics (confidentialy, integrity, and availability), and scope. For example (https://www.first.org/cvss/specification-document)
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>5.5</example>
		[DataMember(Name = "base")]
		public float? Base { get; set; }

		/// <summary>
		/// Scores can range from 0.0 to 10.0, with 10.0 being the most severe.<para/>Temporal scores cover an assessment for code maturity, remediation level, and confidence. For example (https://www.first.org/cvss/specification-document)
		/// </summary>
		/// <remarks>Extended</remarks>
		[DataMember(Name = "temporal")]
		public float? Temporal { get; set; }

		/// <summary>
		/// Scores can range from 0.0 to 10.0, with 10.0 being the most severe.<para/>Environmental scores cover an assessment for any modified Base metrics, confidentiality, integrity, and availability requirements. For example (https://www.first.org/cvss/specification-document)
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>5.5</example>
		[DataMember(Name = "environmental")]
		public float? Environmental { get; set; }

		/// <summary>
		/// The National Vulnerability Database (NVD) provides qualitative severity rankings of "Low", "Medium", and "High" for CVSS v2.0 base score ranges in addition to the severity ratings for CVSS v3.0 as they are defined in the CVSS v3.0 specification.<para/>CVSS is owned and managed by FIRST.Org, Inc. (FIRST), a US-based non-profit organization, whose mission is to help computer security incident response teams across the world. For example (https://nvd.nist.gov/vuln-metrics/cvss)
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>2.0</example>
		[DataMember(Name = "version")]
		public string Version { get; set; }

	}

	/// <summary>
	/// Scanner, property of <see cref="Vulnerability" />
	/// </summary>
	public class VulnerabilityScanner
	{
		/// <summary>
		/// The name of the vulnerability scanner vendor.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Tenable</example>
		[DataMember(Name = "vendor")]
		public string Vendor { get; set; }

	}

	/// <summary>
	/// The vulnerability fields describe information about a vulnerability that is relevant to an event.
	/// </summary>
	public class Vulnerability 
	{
		/// <summary>
		/// Score property.
		/// </summary>
		[DataMember(Name = "score")]
		public VulnerabilityScore Score { get; set; }

		/// <summary>
		/// Scanner property.
		/// </summary>
		[DataMember(Name = "scanner")]
		public VulnerabilityScanner Scanner { get; set; }

		/// <summary>
		/// The classification of the vulnerability scoring system. For example (https://www.first.org/cvss/)
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>CVSS</example>
		[DataMember(Name = "classification")]
		public string Classification { get; set; }

		/// <summary>
		/// The type of identifier used for this vulnerability. For example (https://cve.mitre.org/about/)
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>CVE</example>
		[DataMember(Name = "enumeration")]
		public string Enumeration { get; set; }

		/// <summary>
		/// A resource that provides additional information, context, and mitigations for the identified vulnerability.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>https://cve.mitre.org/cgi-bin/cvename.cgi?name=CVE-2019-6111</example>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		/// <summary>
		/// The type of system or architecture that the vulnerability affects. These may be platform-specific (for example, Debian or SUSE) or general (for example, Database or Firewall). For example (https://qualysguard.qualys.com/qwebhelp/fo_portal/knowledgebase/vulnerability_categories.htm)<para/>This field must be an array.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>[\"Firewall\"]</example>
		[DataMember(Name = "category")]
		public string Category { get; set; }

		/// <summary>
		/// The description of the vulnerability that provides additional context of the vulnerability. For example (https://cve.mitre.org/about/faqs.html#cve_entry_descriptions_created)
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>In macOS before 2.12.6, there is a vulnerability in the RPC...</example>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// The identification (ID) is the number portion of a vulnerability entry. It includes a unique identification number for the vulnerability. For example (https://cve.mitre.org/about/faqs.html#what_is_cve_id)
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>CVE-2019-00001</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// The severity of the vulnerability can help with metrics and internal prioritization regarding remediation. For example (https://nvd.nist.gov/vuln-metrics/cvss)
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>Critical</example>
		[DataMember(Name = "severity")]
		public string Severity { get; set; }

		/// <summary>
		/// The report or scan identification number.
		/// </summary>
		/// <remarks>Extended</remarks>
		/// <example>20191018.0001</example>
		[DataMember(Name = "report_id")]
		public string ReportId { get; set; }

	}

}

namespace Elastic.CommonSchema.Elasticsearch
{
	/// <summary>
	/// Elastic Common Schema version 1.3.0 index templates to be used with Elasticsearch.
	/// </summary>
	public static class IndexTemplates
	{
		/// <summary>
		/// Elastic Common Schema version 1.3.0 index template for Elasticsearch version 7
		/// See the Put Index Template API documentation: https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string GetIndexTemplateForElasticsearch7(string indexPattern = "ecs-*") { return "{  \"index_patterns\": [    \"" + indexPattern + "\"  ],   \"mappings\": {    \"_meta\": {      \"version\": \"1.3.0\"    },     \"date_detection\": false,     \"dynamic_templates\": [      {        \"strings_as_keyword\": {          \"mapping\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"match_mapping_type\": \"string\"        }      }    ],     \"properties\": {      \"@timestamp\": {        \"type\": \"date\"      },       \"agent\": {        \"properties\": {          \"ephemeral_id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"as\": {        \"properties\": {          \"number\": {            \"type\": \"long\"          },           \"organization\": {            \"properties\": {              \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"client\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"as\": {            \"properties\": {              \"number\": {                \"type\": \"long\"              },               \"organization\": {                \"properties\": {                  \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              }            }          },           \"bytes\": {            \"type\": \"long\"          },           \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"nat\": {            \"properties\": {              \"ip\": {                \"type\": \"ip\"              },               \"port\": {                \"type\": \"long\"              }            }          },           \"packets\": {            \"type\": \"long\"          },           \"port\": {            \"type\": \"long\"          },           \"registered_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"top_level_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"cloud\": {        \"properties\": {          \"account\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"availability_zone\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"instance\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"machine\": {            \"properties\": {              \"type\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"provider\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"region\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"container\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"image\": {            \"properties\": {              \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"tag\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"labels\": {            \"type\": \"object\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"runtime\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"destination\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"as\": {            \"properties\": {              \"number\": {                \"type\": \"long\"              },               \"organization\": {                \"properties\": {                  \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              }            }          },           \"bytes\": {            \"type\": \"long\"          },           \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"nat\": {            \"properties\": {              \"ip\": {                \"type\": \"ip\"              },               \"port\": {                \"type\": \"long\"              }            }          },           \"packets\": {            \"type\": \"long\"          },           \"port\": {            \"type\": \"long\"          },           \"registered_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"top_level_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"dns\": {        \"properties\": {          \"answers\": {            \"properties\": {              \"class\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"data\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"ttl\": {                \"type\": \"long\"              },               \"type\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"header_flags\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"op_code\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"question\": {            \"properties\": {              \"class\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"registered_domain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"subdomain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"top_level_domain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"type\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"resolved_ip\": {            \"type\": \"ip\"          },           \"response_code\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"ecs\": {        \"properties\": {          \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"error\": {        \"properties\": {          \"code\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"message\": {            \"norms\": false,             \"type\": \"text\"          },           \"stack_trace\": {            \"doc_values\": false,             \"ignore_above\": 1024,             \"index\": false,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"event\": {        \"properties\": {          \"action\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"category\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"code\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"created\": {            \"type\": \"date\"          },           \"dataset\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"duration\": {            \"type\": \"long\"          },           \"end\": {            \"type\": \"date\"          },           \"hash\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"ingested\": {            \"type\": \"date\"          },           \"kind\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"module\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"original\": {            \"doc_values\": false,             \"ignore_above\": 1024,             \"index\": false,             \"type\": \"keyword\"          },           \"outcome\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"provider\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"risk_score\": {            \"type\": \"float\"          },           \"risk_score_norm\": {            \"type\": \"float\"          },           \"sequence\": {            \"type\": \"long\"          },           \"severity\": {            \"type\": \"long\"          },           \"start\": {            \"type\": \"date\"          },           \"timezone\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"file\": {        \"properties\": {          \"accessed\": {            \"type\": \"date\"          },           \"created\": {            \"type\": \"date\"          },           \"ctime\": {            \"type\": \"date\"          },           \"device\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"directory\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"extension\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"gid\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"group\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"hash\": {            \"properties\": {              \"md5\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"sha1\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"sha256\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"sha512\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"inode\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"mode\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"mtime\": {            \"type\": \"date\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"owner\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"path\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"size\": {            \"type\": \"long\"          },           \"target_path\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"uid\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"geo\": {        \"properties\": {          \"city_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"continent_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"country_iso_code\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"country_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"location\": {            \"type\": \"geo_point\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"region_iso_code\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"region_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"group\": {        \"properties\": {          \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"hash\": {        \"properties\": {          \"md5\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"sha1\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"sha256\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"sha512\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"host\": {        \"properties\": {          \"architecture\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"hostname\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"os\": {            \"properties\": {              \"family\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"kernel\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"platform\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"version\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"uptime\": {            \"type\": \"long\"          },           \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"http\": {        \"properties\": {          \"request\": {            \"properties\": {              \"body\": {                \"properties\": {                  \"bytes\": {                    \"type\": \"long\"                  },                   \"content\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"bytes\": {                \"type\": \"long\"              },               \"method\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"referrer\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"response\": {            \"properties\": {              \"body\": {                \"properties\": {                  \"bytes\": {                    \"type\": \"long\"                  },                   \"content\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"bytes\": {                \"type\": \"long\"              },               \"status_code\": {                \"type\": \"long\"              }            }          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"labels\": {        \"type\": \"object\"      },       \"log\": {        \"properties\": {          \"level\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"logger\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"origin\": {            \"properties\": {              \"file\": {                \"properties\": {                  \"line\": {                    \"type\": \"integer\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"function\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"original\": {            \"doc_values\": false,             \"ignore_above\": 1024,             \"index\": false,             \"type\": \"keyword\"          },           \"syslog\": {            \"properties\": {              \"facility\": {                \"properties\": {                  \"code\": {                    \"type\": \"long\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"priority\": {                \"type\": \"long\"              },               \"severity\": {                \"properties\": {                  \"code\": {                    \"type\": \"long\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              }            }          }        }      },       \"message\": {        \"norms\": false,         \"type\": \"text\"      },       \"network\": {        \"properties\": {          \"application\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"bytes\": {            \"type\": \"long\"          },           \"community_id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"direction\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"forwarded_ip\": {            \"type\": \"ip\"          },           \"iana_number\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"packets\": {            \"type\": \"long\"          },           \"protocol\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"transport\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"observer\": {        \"properties\": {          \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"hostname\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"os\": {            \"properties\": {              \"family\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"kernel\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"platform\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"version\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"product\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"serial_number\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"vendor\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"organization\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"os\": {        \"properties\": {          \"family\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"full\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"kernel\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"platform\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"package\": {        \"properties\": {          \"architecture\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"build_version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"checksum\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"description\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"install_scope\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"installed\": {            \"type\": \"date\"          },           \"license\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"path\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"reference\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"size\": {            \"type\": \"long\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"process\": {        \"properties\": {          \"args\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"args_count\": {            \"type\": \"long\"          },           \"command_line\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"executable\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"exit_code\": {            \"type\": \"long\"          },           \"hash\": {            \"properties\": {              \"md5\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"sha1\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"sha256\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"sha512\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"parent\": {            \"properties\": {              \"args\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"args_count\": {                \"type\": \"long\"              },               \"command_line\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"executable\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"exit_code\": {                \"type\": \"long\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"pgid\": {                \"type\": \"long\"              },               \"pid\": {                \"type\": \"long\"              },               \"ppid\": {                \"type\": \"long\"              },               \"start\": {                \"type\": \"date\"              },               \"thread\": {                \"properties\": {                  \"id\": {                    \"type\": \"long\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"title\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"uptime\": {                \"type\": \"long\"              },               \"working_directory\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"pgid\": {            \"type\": \"long\"          },           \"pid\": {            \"type\": \"long\"          },           \"ppid\": {            \"type\": \"long\"          },           \"start\": {            \"type\": \"date\"          },           \"thread\": {            \"properties\": {              \"id\": {                \"type\": \"long\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"title\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"uptime\": {            \"type\": \"long\"          },           \"working_directory\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"related\": {        \"properties\": {          \"ip\": {            \"type\": \"ip\"          }        }      },       \"server\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"as\": {            \"properties\": {              \"number\": {                \"type\": \"long\"              },               \"organization\": {                \"properties\": {                  \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              }            }          },           \"bytes\": {            \"type\": \"long\"          },           \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"nat\": {            \"properties\": {              \"ip\": {                \"type\": \"ip\"              },               \"port\": {                \"type\": \"long\"              }            }          },           \"packets\": {            \"type\": \"long\"          },           \"port\": {            \"type\": \"long\"          },           \"registered_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"top_level_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"service\": {        \"properties\": {          \"ephemeral_id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"node\": {            \"properties\": {              \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"state\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"source\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"as\": {            \"properties\": {              \"number\": {                \"type\": \"long\"              },               \"organization\": {                \"properties\": {                  \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              }            }          },           \"bytes\": {            \"type\": \"long\"          },           \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"nat\": {            \"properties\": {              \"ip\": {                \"type\": \"ip\"              },               \"port\": {                \"type\": \"long\"              }            }          },           \"packets\": {            \"type\": \"long\"          },           \"port\": {            \"type\": \"long\"          },           \"registered_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"top_level_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"user\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"domain\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"tags\": {        \"ignore_above\": 1024,         \"type\": \"keyword\"      },       \"threat\": {        \"properties\": {          \"framework\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"tactic\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"reference\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"technique\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"reference\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"tls\": {        \"properties\": {          \"cipher\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"client\": {            \"properties\": {              \"certificate\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"certificate_chain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"hash\": {                \"properties\": {                  \"md5\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"sha1\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"sha256\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"issuer\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"ja3\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"not_after\": {                \"type\": \"date\"              },               \"not_before\": {                \"type\": \"date\"              },               \"server_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"subject\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"supported_ciphers\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"curve\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"established\": {            \"type\": \"boolean\"          },           \"next_protocol\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"resumed\": {            \"type\": \"boolean\"          },           \"server\": {            \"properties\": {              \"certificate\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"certificate_chain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"hash\": {                \"properties\": {                  \"md5\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"sha1\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"sha256\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"issuer\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"ja3s\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"not_after\": {                \"type\": \"date\"              },               \"not_before\": {                \"type\": \"date\"              },               \"subject\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"supported_ciphers\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version_protocol\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"trace\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"transaction\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"url\": {        \"properties\": {          \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"extension\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"fragment\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"full\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"original\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"password\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"path\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"port\": {            \"type\": \"long\"          },           \"query\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"registered_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"scheme\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"top_level_domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"username\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"user\": {        \"properties\": {          \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"email\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"full_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"group\": {            \"properties\": {              \"domain\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"hash\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"user_agent\": {        \"properties\": {          \"device\": {            \"properties\": {              \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"original\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"os\": {            \"properties\": {              \"family\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"kernel\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"platform\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"version\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"vulnerability\": {        \"properties\": {          \"category\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"classification\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"description\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"enumeration\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"reference\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"report_id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"scanner\": {            \"properties\": {              \"vendor\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"score\": {            \"properties\": {              \"base\": {                \"type\": \"float\"              },               \"environmental\": {                \"type\": \"float\"              },               \"temporal\": {                \"type\": \"float\"              },               \"version\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"severity\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      }    }  },   \"order\": 1,   \"settings\": {    \"index\": {      \"mapping\": {        \"total_fields\": {          \"limit\": 10000        }      },       \"refresh_interval\": \"5s\"    }  }}"; }

		/// <summary>
		/// Elastic Common Schema version 1.3.0 index template for Elasticsearch version 6
		/// See the Put Index Template API documentation: https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string GetIndexTemplateForElasticsearch6(string indexPattern = "ecs-*") { return "{  \"index_patterns\": [    \"" + indexPattern + "\"  ],   \"mappings\": {    \"_doc\": {      \"_meta\": {        \"version\": \"1.3.0\"      },       \"date_detection\": false,       \"dynamic_templates\": [        {          \"strings_as_keyword\": {            \"mapping\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"match_mapping_type\": \"string\"          }        }      ],       \"properties\": {        \"@timestamp\": {          \"type\": \"date\"        },         \"agent\": {          \"properties\": {            \"ephemeral_id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"as\": {          \"properties\": {            \"number\": {              \"type\": \"long\"            },             \"organization\": {              \"properties\": {                \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"client\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"as\": {              \"properties\": {                \"number\": {                  \"type\": \"long\"                },                 \"organization\": {                  \"properties\": {                    \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                }              }            },             \"bytes\": {              \"type\": \"long\"            },             \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"nat\": {              \"properties\": {                \"ip\": {                  \"type\": \"ip\"                },                 \"port\": {                  \"type\": \"long\"                }              }            },             \"packets\": {              \"type\": \"long\"            },             \"port\": {              \"type\": \"long\"            },             \"registered_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"top_level_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"cloud\": {          \"properties\": {            \"account\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"availability_zone\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"instance\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"machine\": {              \"properties\": {                \"type\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"provider\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"region\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"container\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"image\": {              \"properties\": {                \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"tag\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"labels\": {              \"type\": \"object\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"runtime\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"destination\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"as\": {              \"properties\": {                \"number\": {                  \"type\": \"long\"                },                 \"organization\": {                  \"properties\": {                    \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                }              }            },             \"bytes\": {              \"type\": \"long\"            },             \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"nat\": {              \"properties\": {                \"ip\": {                  \"type\": \"ip\"                },                 \"port\": {                  \"type\": \"long\"                }              }            },             \"packets\": {              \"type\": \"long\"            },             \"port\": {              \"type\": \"long\"            },             \"registered_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"top_level_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"dns\": {          \"properties\": {            \"answers\": {              \"properties\": {                \"class\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"data\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"ttl\": {                  \"type\": \"long\"                },                 \"type\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"header_flags\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"op_code\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"question\": {              \"properties\": {                \"class\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"registered_domain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"subdomain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"top_level_domain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"type\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"resolved_ip\": {              \"type\": \"ip\"            },             \"response_code\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"ecs\": {          \"properties\": {            \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"error\": {          \"properties\": {            \"code\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"message\": {              \"norms\": false,               \"type\": \"text\"            },             \"stack_trace\": {              \"doc_values\": false,               \"ignore_above\": 1024,               \"index\": false,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"event\": {          \"properties\": {            \"action\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"category\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"code\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"created\": {              \"type\": \"date\"            },             \"dataset\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"duration\": {              \"type\": \"long\"            },             \"end\": {              \"type\": \"date\"            },             \"hash\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"ingested\": {              \"type\": \"date\"            },             \"kind\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"module\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"original\": {              \"doc_values\": false,               \"ignore_above\": 1024,               \"index\": false,               \"type\": \"keyword\"            },             \"outcome\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"provider\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"risk_score\": {              \"type\": \"float\"            },             \"risk_score_norm\": {              \"type\": \"float\"            },             \"sequence\": {              \"type\": \"long\"            },             \"severity\": {              \"type\": \"long\"            },             \"start\": {              \"type\": \"date\"            },             \"timezone\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"file\": {          \"properties\": {            \"accessed\": {              \"type\": \"date\"            },             \"created\": {              \"type\": \"date\"            },             \"ctime\": {              \"type\": \"date\"            },             \"device\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"directory\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"extension\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"gid\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"group\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"hash\": {              \"properties\": {                \"md5\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"sha1\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"sha256\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"sha512\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"inode\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"mode\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"mtime\": {              \"type\": \"date\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"owner\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"path\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"size\": {              \"type\": \"long\"            },             \"target_path\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"uid\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"geo\": {          \"properties\": {            \"city_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"continent_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"country_iso_code\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"country_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"location\": {              \"type\": \"geo_point\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"region_iso_code\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"region_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"group\": {          \"properties\": {            \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"hash\": {          \"properties\": {            \"md5\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"sha1\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"sha256\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"sha512\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"host\": {          \"properties\": {            \"architecture\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"hostname\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"os\": {              \"properties\": {                \"family\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"kernel\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"platform\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"version\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"uptime\": {              \"type\": \"long\"            },             \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"http\": {          \"properties\": {            \"request\": {              \"properties\": {                \"body\": {                  \"properties\": {                    \"bytes\": {                      \"type\": \"long\"                    },                     \"content\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"bytes\": {                  \"type\": \"long\"                },                 \"method\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"referrer\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"response\": {              \"properties\": {                \"body\": {                  \"properties\": {                    \"bytes\": {                      \"type\": \"long\"                    },                     \"content\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"bytes\": {                  \"type\": \"long\"                },                 \"status_code\": {                  \"type\": \"long\"                }              }            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"labels\": {          \"type\": \"object\"        },         \"log\": {          \"properties\": {            \"level\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"logger\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"origin\": {              \"properties\": {                \"file\": {                  \"properties\": {                    \"line\": {                      \"type\": \"integer\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"function\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"original\": {              \"doc_values\": false,               \"ignore_above\": 1024,               \"index\": false,               \"type\": \"keyword\"            },             \"syslog\": {              \"properties\": {                \"facility\": {                  \"properties\": {                    \"code\": {                      \"type\": \"long\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"priority\": {                  \"type\": \"long\"                },                 \"severity\": {                  \"properties\": {                    \"code\": {                      \"type\": \"long\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                }              }            }          }        },         \"message\": {          \"norms\": false,           \"type\": \"text\"        },         \"network\": {          \"properties\": {            \"application\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"bytes\": {              \"type\": \"long\"            },             \"community_id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"direction\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"forwarded_ip\": {              \"type\": \"ip\"            },             \"iana_number\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"packets\": {              \"type\": \"long\"            },             \"protocol\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"transport\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"observer\": {          \"properties\": {            \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"hostname\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"os\": {              \"properties\": {                \"family\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"kernel\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"platform\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"version\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"product\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"serial_number\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"vendor\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"organization\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"os\": {          \"properties\": {            \"family\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"full\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"kernel\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"platform\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"package\": {          \"properties\": {            \"architecture\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"build_version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"checksum\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"description\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"install_scope\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"installed\": {              \"type\": \"date\"            },             \"license\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"path\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"reference\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"size\": {              \"type\": \"long\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"process\": {          \"properties\": {            \"args\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"args_count\": {              \"type\": \"long\"            },             \"command_line\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"executable\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"exit_code\": {              \"type\": \"long\"            },             \"hash\": {              \"properties\": {                \"md5\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"sha1\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"sha256\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"sha512\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"parent\": {              \"properties\": {                \"args\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"args_count\": {                  \"type\": \"long\"                },                 \"command_line\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"executable\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"exit_code\": {                  \"type\": \"long\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"pgid\": {                  \"type\": \"long\"                },                 \"pid\": {                  \"type\": \"long\"                },                 \"ppid\": {                  \"type\": \"long\"                },                 \"start\": {                  \"type\": \"date\"                },                 \"thread\": {                  \"properties\": {                    \"id\": {                      \"type\": \"long\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"title\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"uptime\": {                  \"type\": \"long\"                },                 \"working_directory\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"pgid\": {              \"type\": \"long\"            },             \"pid\": {              \"type\": \"long\"            },             \"ppid\": {              \"type\": \"long\"            },             \"start\": {              \"type\": \"date\"            },             \"thread\": {              \"properties\": {                \"id\": {                  \"type\": \"long\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"title\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"uptime\": {              \"type\": \"long\"            },             \"working_directory\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"related\": {          \"properties\": {            \"ip\": {              \"type\": \"ip\"            }          }        },         \"server\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"as\": {              \"properties\": {                \"number\": {                  \"type\": \"long\"                },                 \"organization\": {                  \"properties\": {                    \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                }              }            },             \"bytes\": {              \"type\": \"long\"            },             \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"nat\": {              \"properties\": {                \"ip\": {                  \"type\": \"ip\"                },                 \"port\": {                  \"type\": \"long\"                }              }            },             \"packets\": {              \"type\": \"long\"            },             \"port\": {              \"type\": \"long\"            },             \"registered_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"top_level_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"service\": {          \"properties\": {            \"ephemeral_id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"node\": {              \"properties\": {                \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"state\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"source\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"as\": {              \"properties\": {                \"number\": {                  \"type\": \"long\"                },                 \"organization\": {                  \"properties\": {                    \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                }              }            },             \"bytes\": {              \"type\": \"long\"            },             \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"nat\": {              \"properties\": {                \"ip\": {                  \"type\": \"ip\"                },                 \"port\": {                  \"type\": \"long\"                }              }            },             \"packets\": {              \"type\": \"long\"            },             \"port\": {              \"type\": \"long\"            },             \"registered_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"top_level_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"user\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"domain\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"tags\": {          \"ignore_above\": 1024,           \"type\": \"keyword\"        },         \"threat\": {          \"properties\": {            \"framework\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"tactic\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"reference\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"technique\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"reference\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"tls\": {          \"properties\": {            \"cipher\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"client\": {              \"properties\": {                \"certificate\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"certificate_chain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"hash\": {                  \"properties\": {                    \"md5\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"sha1\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"sha256\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"issuer\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"ja3\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"not_after\": {                  \"type\": \"date\"                },                 \"not_before\": {                  \"type\": \"date\"                },                 \"server_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"subject\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"supported_ciphers\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"curve\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"established\": {              \"type\": \"boolean\"            },             \"next_protocol\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"resumed\": {              \"type\": \"boolean\"            },             \"server\": {              \"properties\": {                \"certificate\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"certificate_chain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"hash\": {                  \"properties\": {                    \"md5\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"sha1\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"sha256\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"issuer\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"ja3s\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"not_after\": {                  \"type\": \"date\"                },                 \"not_before\": {                  \"type\": \"date\"                },                 \"subject\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"supported_ciphers\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version_protocol\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"trace\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"transaction\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"url\": {          \"properties\": {            \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"extension\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"fragment\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"full\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"original\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"password\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"path\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"port\": {              \"type\": \"long\"            },             \"query\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"registered_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"scheme\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"top_level_domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"username\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"user\": {          \"properties\": {            \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"email\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"full_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"group\": {              \"properties\": {                \"domain\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"hash\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"user_agent\": {          \"properties\": {            \"device\": {              \"properties\": {                \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"original\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"os\": {              \"properties\": {                \"family\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"kernel\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"platform\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"version\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"vulnerability\": {          \"properties\": {            \"category\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"classification\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"description\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"enumeration\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"reference\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"report_id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"scanner\": {              \"properties\": {                \"vendor\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"score\": {              \"properties\": {                \"base\": {                  \"type\": \"float\"                },                 \"environmental\": {                  \"type\": \"float\"                },                 \"temporal\": {                  \"type\": \"float\"                },                 \"version\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"severity\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        }      }    }  },   \"order\": 1,   \"settings\": {    \"index\": {      \"mapping\": {        \"total_fields\": {          \"limit\": 10000        }      },       \"refresh_interval\": \"5s\"    }  }}"; }

	}
}