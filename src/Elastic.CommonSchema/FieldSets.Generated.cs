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

	///<summary>
	/// The agent fields contain the data about the software entity, if any, that collects, detects, or observes events on a host, or takes measurements on a host.&#xA;Examples include Beats. Agents may also run on observers. ECS agent.* fields shall be populated with details of the agent running on the host or observer where the event happened or the measurement was taken.
	///</summary>
	public abstract class AgentFieldSet {

		///<summary>agent.build.original</summary>
		[DataMember(Name = "build.original")]
		public string BuildOriginal { get; set; }

		///<summary>agent.ephemeral_id</summary>
		[DataMember(Name = "ephemeral_id")]
		public string EphemeralId { get; set; }

		///<summary>agent.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>agent.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>agent.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>agent.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}

	///<summary>
	/// An autonomous system (AS) is a collection of connected Internet Protocol (IP) routing prefixes under the control of one or more network operators on behalf of a single administrative entity or domain that presents a common, clearly defined routing policy to the internet.
	///</summary>
	public abstract class AsFieldSet {

		///<summary>as.number</summary>
		[DataMember(Name = "number")]
		public long? Number { get; set; }

		///<summary>as.organization.name</summary>
		[DataMember(Name = "organization.name")]
		public string OrganizationName { get; set; }
	}

	///<summary>
	/// The `base` field set contains all fields which are at the root of the events. These fields are common across all types of events.
	///</summary>
	public abstract class BaseFieldSet {

		///<summary>@timestamp</summary>
		[DataMember(Name = "@timestamp")]
		public DateTimeOffset? @Timestamp { get; set; }

		///<summary>message</summary>
		[DataMember(Name = "message")]
		public string Message { get; set; }

		///<summary>tags</summary>
		[DataMember(Name = "tags")]
		public string[] Tags { get; set; }

		///<summary>span.id</summary>
		[DataMember(Name = "span.id")]
		public string SpanId { get; set; }

		///<summary>trace.id</summary>
		[DataMember(Name = "trace.id")]
		public string TraceId { get; set; }

		///<summary>transaction.id</summary>
		[DataMember(Name = "transaction.id")]
		public string TransactionId { get; set; }

		///<summary>labels</summary>
		[DataMember(Name = "labels")]
		public Labels Labels { get; set; }
	}

	///<summary>
	/// A client is defined as the initiator of a network connection for events regarding sessions, connections, or bidirectional flow records.&#xA;For TCP events, the client is the initiator of the TCP connection that sends the SYN packet(s). For other protocols, the client is generally the initiator or requestor in the network transaction. Some systems use the term &quot;originator&quot; to refer the client in TCP connections. The client fields describe details about the system acting as the client in the network event. Client fields are usually populated in conjunction with server fields. Client fields are generally not populated for packet-level events.&#xA;Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
	///</summary>
	public abstract class ClientFieldSet {

		///<summary>client.address</summary>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		///<summary>client.bytes</summary>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		///<summary>client.domain</summary>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		///<summary>client.ip</summary>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		///<summary>client.mac</summary>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		///<summary>client.nat.ip</summary>
		[DataMember(Name = "nat.ip")]
		public string NatIp { get; set; }

		///<summary>client.nat.port</summary>
		[DataMember(Name = "nat.port")]
		public long? NatPort { get; set; }

		///<summary>client.packets</summary>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		///<summary>client.port</summary>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		///<summary>client.registered_domain</summary>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		///<summary>client.subdomain</summary>
		[DataMember(Name = "subdomain")]
		public string Subdomain { get; set; }

		///<summary>client.top_level_domain</summary>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }
	}

	///<summary>
	/// Fields related to the cloud or infrastructure the events are coming from.
	///</summary>
	public abstract class CloudFieldSet {

		///<summary>cloud.account.id</summary>
		[DataMember(Name = "account.id")]
		public string AccountId { get; set; }

		///<summary>cloud.account.name</summary>
		[DataMember(Name = "account.name")]
		public string AccountName { get; set; }

		///<summary>cloud.availability_zone</summary>
		[DataMember(Name = "availability_zone")]
		public string AvailabilityZone { get; set; }

		///<summary>cloud.instance.id</summary>
		[DataMember(Name = "instance.id")]
		public string InstanceId { get; set; }

		///<summary>cloud.instance.name</summary>
		[DataMember(Name = "instance.name")]
		public string InstanceName { get; set; }

		///<summary>cloud.machine.type</summary>
		[DataMember(Name = "machine.type")]
		public string MachineType { get; set; }

		///<summary>cloud.project.id</summary>
		[DataMember(Name = "project.id")]
		public string ProjectId { get; set; }

		///<summary>cloud.project.name</summary>
		[DataMember(Name = "project.name")]
		public string ProjectName { get; set; }

		///<summary>cloud.provider</summary>
		[DataMember(Name = "provider")]
		public string Provider { get; set; }

		///<summary>cloud.region</summary>
		[DataMember(Name = "region")]
		public string Region { get; set; }

		///<summary>cloud.service.name</summary>
		[DataMember(Name = "service.name")]
		public string ServiceName { get; set; }
	}

	///<summary>
	/// These fields contain information about binary code signatures.
	///</summary>
	public abstract class CodeSignatureFieldSet {

		///<summary>code_signature.digest_algorithm</summary>
		[DataMember(Name = "digest_algorithm")]
		public string DigestAlgorithm { get; set; }

		///<summary>code_signature.exists</summary>
		[DataMember(Name = "exists")]
		public bool? Exists { get; set; }

		///<summary>code_signature.signing_id</summary>
		[DataMember(Name = "signing_id")]
		public string SigningId { get; set; }

		///<summary>code_signature.status</summary>
		[DataMember(Name = "status")]
		public string Status { get; set; }

		///<summary>code_signature.subject_name</summary>
		[DataMember(Name = "subject_name")]
		public string SubjectName { get; set; }

		///<summary>code_signature.team_id</summary>
		[DataMember(Name = "team_id")]
		public string TeamId { get; set; }

		///<summary>code_signature.timestamp</summary>
		[DataMember(Name = "timestamp")]
		public DateTimeOffset? Timestamp { get; set; }

		///<summary>code_signature.trusted</summary>
		[DataMember(Name = "trusted")]
		public bool? Trusted { get; set; }

		///<summary>code_signature.valid</summary>
		[DataMember(Name = "valid")]
		public bool? Valid { get; set; }
	}

	///<summary>
	/// Container fields are used for meta information about the specific container that is the source of information.&#xA;These fields help correlate data based containers from any runtime.
	///</summary>
	public abstract class ContainerFieldSet {

		///<summary>container.cpu.usage</summary>
		[DataMember(Name = "cpu.usage")]
		public float? CpuUsage { get; set; }

		///<summary>container.disk.read.bytes</summary>
		[DataMember(Name = "disk.read.bytes")]
		public long? DiskReadBytes { get; set; }

		///<summary>container.disk.write.bytes</summary>
		[DataMember(Name = "disk.write.bytes")]
		public long? DiskWriteBytes { get; set; }

		///<summary>container.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>container.image.hash.all</summary>
		[DataMember(Name = "image.hash.all")]
		public string[] ImageHashAll { get; set; }

		///<summary>container.image.name</summary>
		[DataMember(Name = "image.name")]
		public string ImageName { get; set; }

		///<summary>container.image.tag</summary>
		[DataMember(Name = "image.tag")]
		public string[] ImageTag { get; set; }

		///<summary>container.memory.usage</summary>
		[DataMember(Name = "memory.usage")]
		public float? MemoryUsage { get; set; }

		///<summary>container.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>container.network.egress.bytes</summary>
		[DataMember(Name = "network.egress.bytes")]
		public long? NetworkEgressBytes { get; set; }

		///<summary>container.network.ingress.bytes</summary>
		[DataMember(Name = "network.ingress.bytes")]
		public long? NetworkIngressBytes { get; set; }

		///<summary>container.runtime</summary>
		[DataMember(Name = "runtime")]
		public string Runtime { get; set; }

		///<summary>container.labels</summary>
		[DataMember(Name = "labels")]
		public ContainerLabels Labels { get; set; }
	}

	///<summary>
	/// The data_stream fields take part in defining the new data stream naming scheme.&#xA;In the new data stream naming scheme the value of the data stream fields combine to the name of the actual data stream in the following manner: `{data_stream.type}-{data_stream.dataset}-{data_stream.namespace}`. This means the fields can only contain characters that are valid as part of names of data streams. More details about this can be found in this https://www.elastic.co/blog/an-introduction-to-the-elastic-data-stream-naming-scheme[blog post].&#xA;An Elasticsearch data stream consists of one or more backing indices, and a data stream name forms part of the backing indices names. Due to this convention, data streams must also follow index naming restrictions. For example, data stream names cannot include `\`, `/`, `*`, `?`, `&quot;`, `&lt;`, `&gt;`, `|`, ` ` (space character), `,`, or `#`. Please see the Elasticsearch reference for additional https://www.elastic.co/guide/en/elasticsearch/reference/current/indices-create-index.html#indices-create-api-path-params[restrictions].
	///</summary>
	public abstract class DataStreamFieldSet {

		///<summary>data_stream.dataset</summary>
		[DataMember(Name = "dataset")]
		public string Dataset { get; set; }

		///<summary>data_stream.namespace</summary>
		[DataMember(Name = "namespace")]
		public string Namespace { get; set; }

		///<summary>data_stream.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }
	}

	///<summary>
	/// Destination fields capture details about the receiver of a network exchange/packet. These fields are populated from a network event, packet, or other event containing details of a network transaction.&#xA;Destination fields are usually populated in conjunction with source fields. The source and destination fields are considered the baseline and should always be filled if an event contains source and destination details from a network transaction. If the event also contains identification of the client and server roles, then the client and server fields should also be populated.
	///</summary>
	public abstract class DestinationFieldSet {

		///<summary>destination.address</summary>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		///<summary>destination.bytes</summary>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		///<summary>destination.domain</summary>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		///<summary>destination.ip</summary>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		///<summary>destination.mac</summary>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		///<summary>destination.nat.ip</summary>
		[DataMember(Name = "nat.ip")]
		public string NatIp { get; set; }

		///<summary>destination.nat.port</summary>
		[DataMember(Name = "nat.port")]
		public long? NatPort { get; set; }

		///<summary>destination.packets</summary>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		///<summary>destination.port</summary>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		///<summary>destination.registered_domain</summary>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		///<summary>destination.subdomain</summary>
		[DataMember(Name = "subdomain")]
		public string Subdomain { get; set; }

		///<summary>destination.top_level_domain</summary>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }
	}

	///<summary>
	/// These fields contain information about code libraries dynamically loaded into processes.&#xA;&#xA;Many operating systems refer to &quot;shared code libraries&quot; with different names, but this field set refers to all of the following:&#xA;* Dynamic-link library (`.dll`) commonly used on Windows&#xA;* Shared Object (`.so`) commonly used on Unix-like operating systems&#xA;* Dynamic library (`.dylib`) commonly used on macOS
	///</summary>
	public abstract class DllFieldSet {

		///<summary>dll.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>dll.path</summary>
		[DataMember(Name = "path")]
		public string Path { get; set; }
	}

	///<summary>
	/// Fields describing DNS queries and answers.&#xA;DNS events should either represent a single DNS query prior to getting answers (`dns.type:query`) or they should represent a full exchange and contain the query details as well as all of the answers that were provided for this query (`dns.type:answer`).
	///</summary>
	public abstract class DnsFieldSet {

		///<summary>dns.header_flags</summary>
		[DataMember(Name = "header_flags")]
		public string[] HeaderFlags { get; set; }

		///<summary>dns.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>dns.op_code</summary>
		[DataMember(Name = "op_code")]
		public string OpCode { get; set; }

		///<summary>dns.question.class</summary>
		[DataMember(Name = "question.class")]
		public string QuestionClass { get; set; }

		///<summary>dns.question.name</summary>
		[DataMember(Name = "question.name")]
		public string QuestionName { get; set; }

		///<summary>dns.question.registered_domain</summary>
		[DataMember(Name = "question.registered_domain")]
		public string QuestionRegisteredDomain { get; set; }

		///<summary>dns.question.subdomain</summary>
		[DataMember(Name = "question.subdomain")]
		public string QuestionSubdomain { get; set; }

		///<summary>dns.question.top_level_domain</summary>
		[DataMember(Name = "question.top_level_domain")]
		public string QuestionTopLevelDomain { get; set; }

		///<summary>dns.question.type</summary>
		[DataMember(Name = "question.type")]
		public string QuestionType { get; set; }

		///<summary>dns.resolved_ip</summary>
		[DataMember(Name = "resolved_ip")]
		public string[] ResolvedIp { get; set; }

		///<summary>dns.response_code</summary>
		[DataMember(Name = "response_code")]
		public string ResponseCode { get; set; }

		///<summary>dns.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>dns.answers</summary>
		[DataMember(Name = "answers")]
		public DnsAnswers Answers { get; set; }
	}

	///<summary>
	/// Meta-information specific to ECS.
	///</summary>
	public abstract class EcsFieldSet {

		///<summary>ecs.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}

	///<summary>
	/// These fields contain Linux Executable Linkable Format (ELF) metadata.
	///</summary>
	public abstract class ElfFieldSet {

		///<summary>elf.architecture</summary>
		[DataMember(Name = "architecture")]
		public string Architecture { get; set; }

		///<summary>elf.byte_order</summary>
		[DataMember(Name = "byte_order")]
		public string ByteOrder { get; set; }

		///<summary>elf.cpu_type</summary>
		[DataMember(Name = "cpu_type")]
		public string CpuType { get; set; }

		///<summary>elf.creation_date</summary>
		[DataMember(Name = "creation_date")]
		public DateTimeOffset? CreationDate { get; set; }

		///<summary>elf.exports</summary>
		[DataMember(Name = "exports")]
		public string[] Exports { get; set; }

		///<summary>elf.header.abi_version</summary>
		[DataMember(Name = "header.abi_version")]
		public string HeaderAbiVersion { get; set; }

		///<summary>elf.header.class</summary>
		[DataMember(Name = "header.class")]
		public string HeaderClass { get; set; }

		///<summary>elf.header.data</summary>
		[DataMember(Name = "header.data")]
		public string HeaderData { get; set; }

		///<summary>elf.header.entrypoint</summary>
		[DataMember(Name = "header.entrypoint")]
		public long? HeaderEntrypoint { get; set; }

		///<summary>elf.header.object_version</summary>
		[DataMember(Name = "header.object_version")]
		public string HeaderObjectVersion { get; set; }

		///<summary>elf.header.os_abi</summary>
		[DataMember(Name = "header.os_abi")]
		public string HeaderOsAbi { get; set; }

		///<summary>elf.header.type</summary>
		[DataMember(Name = "header.type")]
		public string HeaderType { get; set; }

		///<summary>elf.header.version</summary>
		[DataMember(Name = "header.version")]
		public string HeaderVersion { get; set; }

		///<summary>elf.imports</summary>
		[DataMember(Name = "imports")]
		public string[] Imports { get; set; }

		///<summary>elf.shared_libraries</summary>
		[DataMember(Name = "shared_libraries")]
		public string[] SharedLibraries { get; set; }

		///<summary>elf.telfhash</summary>
		[DataMember(Name = "telfhash")]
		public string Telfhash { get; set; }

		///<summary>elf.sections</summary>
		[DataMember(Name = "sections")]
		public ElfSections Sections { get; set; }

		///<summary>elf.segments</summary>
		[DataMember(Name = "segments")]
		public ElfSegments Segments { get; set; }
	}

	///<summary>
	/// Event details relating to an email transaction.&#xA;This field set focuses on the email message header, body, and attachments. Network protocols that send and receive email messages such as SMTP are outside the scope of the `email.*` fields.
	///</summary>
	public abstract class EmailFieldSet {

		///<summary>email.bcc.address</summary>
		[DataMember(Name = "bcc.address")]
		public string[] BccAddress { get; set; }

		///<summary>email.cc.address</summary>
		[DataMember(Name = "cc.address")]
		public string[] CcAddress { get; set; }

		///<summary>email.content_type</summary>
		[DataMember(Name = "content_type")]
		public string ContentType { get; set; }

		///<summary>email.delivery_timestamp</summary>
		[DataMember(Name = "delivery_timestamp")]
		public DateTimeOffset? DeliveryTimestamp { get; set; }

		///<summary>email.direction</summary>
		[DataMember(Name = "direction")]
		public string Direction { get; set; }

		///<summary>email.from.address</summary>
		[DataMember(Name = "from.address")]
		public string[] FromAddress { get; set; }

		///<summary>email.local_id</summary>
		[DataMember(Name = "local_id")]
		public string LocalId { get; set; }

		///<summary>email.message_id</summary>
		[DataMember(Name = "message_id")]
		public string MessageId { get; set; }

		///<summary>email.origination_timestamp</summary>
		[DataMember(Name = "origination_timestamp")]
		public DateTimeOffset? OriginationTimestamp { get; set; }

		///<summary>email.reply_to.address</summary>
		[DataMember(Name = "reply_to.address")]
		public string[] ReplyToAddress { get; set; }

		///<summary>email.sender.address</summary>
		[DataMember(Name = "sender.address")]
		public string SenderAddress { get; set; }

		///<summary>email.subject</summary>
		[DataMember(Name = "subject")]
		public string Subject { get; set; }

		///<summary>email.to.address</summary>
		[DataMember(Name = "to.address")]
		public string[] ToAddress { get; set; }

		///<summary>email.x_mailer</summary>
		[DataMember(Name = "x_mailer")]
		public string XMailer { get; set; }

		///<summary>email.attachments</summary>
		[DataMember(Name = "attachments")]
		public EmailAttachments Attachments { get; set; }
	}

	///<summary>
	/// These fields can represent errors of any kind.&#xA;Use them for errors that happen while fetching events or in cases where the event itself contains an error.
	///</summary>
	public abstract class ErrorFieldSet {

		///<summary>error.code</summary>
		[DataMember(Name = "code")]
		public string Code { get; set; }

		///<summary>error.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>error.message</summary>
		[DataMember(Name = "message")]
		public string Message { get; set; }

		///<summary>error.stack_trace</summary>
		[DataMember(Name = "stack_trace")]
		public string StackTrace { get; set; }

		///<summary>error.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }
	}

	///<summary>
	/// The event fields are used for context information about the log or metric event itself.&#xA;A log is defined as an event containing details of something that happened. Log events must include the time at which the thing happened. Examples of log events include a process starting on a host, a network packet being sent from a source to a destination, or a network connection between a client and a server being initiated or closed. A metric is defined as an event containing one or more numerical measurements and the time at which the measurement was taken. Examples of metric events include memory pressure measured on a host and device temperature. See the `event.kind` definition in this section for additional details about metric and state events.
	///</summary>
	public abstract class EventFieldSet {

		///<summary>event.action</summary>
		[DataMember(Name = "action")]
		public string Action { get; set; }

		///<summary>event.agent_id_status</summary>
		[DataMember(Name = "agent_id_status")]
		public string AgentIdStatus { get; set; }

		///<summary>event.category</summary>
		[DataMember(Name = "category")]
		public string[] Category { get; set; }

		///<summary>event.code</summary>
		[DataMember(Name = "code")]
		public string Code { get; set; }

		///<summary>event.created</summary>
		[DataMember(Name = "created")]
		public DateTimeOffset? Created { get; set; }

		///<summary>event.dataset</summary>
		[DataMember(Name = "dataset")]
		public string Dataset { get; set; }

		///<summary>event.duration</summary>
		[DataMember(Name = "duration")]
		public long? Duration { get; set; }

		///<summary>event.end</summary>
		[DataMember(Name = "end")]
		public DateTimeOffset? End { get; set; }

		///<summary>event.hash</summary>
		[DataMember(Name = "hash")]
		public string Hash { get; set; }

		///<summary>event.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>event.ingested</summary>
		[DataMember(Name = "ingested")]
		public DateTimeOffset? Ingested { get; set; }

		///<summary>event.kind</summary>
		[DataMember(Name = "kind")]
		public string Kind { get; set; }

		///<summary>event.module</summary>
		[DataMember(Name = "module")]
		public string Module { get; set; }

		///<summary>event.original</summary>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		///<summary>event.outcome</summary>
		[DataMember(Name = "outcome")]
		public string Outcome { get; set; }

		///<summary>event.provider</summary>
		[DataMember(Name = "provider")]
		public string Provider { get; set; }

		///<summary>event.reason</summary>
		[DataMember(Name = "reason")]
		public string Reason { get; set; }

		///<summary>event.reference</summary>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		///<summary>event.risk_score</summary>
		[DataMember(Name = "risk_score")]
		public float? RiskScore { get; set; }

		///<summary>event.risk_score_norm</summary>
		[DataMember(Name = "risk_score_norm")]
		public float? RiskScoreNorm { get; set; }

		///<summary>event.sequence</summary>
		[DataMember(Name = "sequence")]
		public long? Sequence { get; set; }

		///<summary>event.severity</summary>
		[DataMember(Name = "severity")]
		public long? Severity { get; set; }

		///<summary>event.start</summary>
		[DataMember(Name = "start")]
		public DateTimeOffset? Start { get; set; }

		///<summary>event.timezone</summary>
		[DataMember(Name = "timezone")]
		public string Timezone { get; set; }

		///<summary>event.type</summary>
		[DataMember(Name = "type")]
		public string[] Type { get; set; }

		///<summary>event.url</summary>
		[DataMember(Name = "url")]
		public string Url { get; set; }
	}

	///<summary>
	/// The user fields describe information about the function as a service (FaaS) that is relevant to the event.
	///</summary>
	public abstract class FaasFieldSet {

		///<summary>faas.coldstart</summary>
		[DataMember(Name = "coldstart")]
		public bool? Coldstart { get; set; }

		///<summary>faas.execution</summary>
		[DataMember(Name = "execution")]
		public string Execution { get; set; }

		///<summary>faas.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>faas.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>faas.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		///<summary>faas.trigger</summary>
		[DataMember(Name = "trigger")]
		public FaasTrigger Trigger { get; set; }
	}

	///<summary>
	/// A file is defined as a set of information that has been created on, or has existed on a filesystem.&#xA;File objects can be associated with host events, network events, and/or file events (e.g., those produced by File Integrity Monitoring [FIM] products or services). File fields provide details about the affected file associated with the event or metric.
	///</summary>
	public abstract class FileFieldSet {

		///<summary>file.accessed</summary>
		[DataMember(Name = "accessed")]
		public DateTimeOffset? Accessed { get; set; }

		///<summary>file.attributes</summary>
		[DataMember(Name = "attributes")]
		public string[] Attributes { get; set; }

		///<summary>file.created</summary>
		[DataMember(Name = "created")]
		public DateTimeOffset? Created { get; set; }

		///<summary>file.ctime</summary>
		[DataMember(Name = "ctime")]
		public DateTimeOffset? Ctime { get; set; }

		///<summary>file.device</summary>
		[DataMember(Name = "device")]
		public string Device { get; set; }

		///<summary>file.directory</summary>
		[DataMember(Name = "directory")]
		public string Directory { get; set; }

		///<summary>file.drive_letter</summary>
		[DataMember(Name = "drive_letter")]
		public string DriveLetter { get; set; }

		///<summary>file.extension</summary>
		[DataMember(Name = "extension")]
		public string Extension { get; set; }

		///<summary>file.fork_name</summary>
		[DataMember(Name = "fork_name")]
		public string ForkName { get; set; }

		///<summary>file.gid</summary>
		[DataMember(Name = "gid")]
		public string Gid { get; set; }

		///<summary>file.group</summary>
		[DataMember(Name = "group")]
		public string Group { get; set; }

		///<summary>file.inode</summary>
		[DataMember(Name = "inode")]
		public string Inode { get; set; }

		///<summary>file.mime_type</summary>
		[DataMember(Name = "mime_type")]
		public string MimeType { get; set; }

		///<summary>file.mode</summary>
		[DataMember(Name = "mode")]
		public string Mode { get; set; }

		///<summary>file.mtime</summary>
		[DataMember(Name = "mtime")]
		public DateTimeOffset? Mtime { get; set; }

		///<summary>file.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>file.owner</summary>
		[DataMember(Name = "owner")]
		public string Owner { get; set; }

		///<summary>file.path</summary>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		///<summary>file.size</summary>
		[DataMember(Name = "size")]
		public long? Size { get; set; }

		///<summary>file.target_path</summary>
		[DataMember(Name = "target_path")]
		public string TargetPath { get; set; }

		///<summary>file.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>file.uid</summary>
		[DataMember(Name = "uid")]
		public string Uid { get; set; }
	}

	///<summary>
	/// Geo fields can carry data about a specific location related to an event.&#xA;This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
	///</summary>
	public abstract class GeoFieldSet {

		///<summary>geo.city_name</summary>
		[DataMember(Name = "city_name")]
		public string CityName { get; set; }

		///<summary>geo.continent_code</summary>
		[DataMember(Name = "continent_code")]
		public string ContinentCode { get; set; }

		///<summary>geo.continent_name</summary>
		[DataMember(Name = "continent_name")]
		public string ContinentName { get; set; }

		///<summary>geo.country_iso_code</summary>
		[DataMember(Name = "country_iso_code")]
		public string CountryIsoCode { get; set; }

		///<summary>geo.country_name</summary>
		[DataMember(Name = "country_name")]
		public string CountryName { get; set; }

		///<summary>geo.location</summary>
		[DataMember(Name = "location")]
		public Location Location { get; set; }

		///<summary>geo.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>geo.postal_code</summary>
		[DataMember(Name = "postal_code")]
		public string PostalCode { get; set; }

		///<summary>geo.region_iso_code</summary>
		[DataMember(Name = "region_iso_code")]
		public string RegionIsoCode { get; set; }

		///<summary>geo.region_name</summary>
		[DataMember(Name = "region_name")]
		public string RegionName { get; set; }

		///<summary>geo.timezone</summary>
		[DataMember(Name = "timezone")]
		public string Timezone { get; set; }
	}

	///<summary>
	/// The group fields are meant to represent groups that are relevant to the event.
	///</summary>
	public abstract class GroupFieldSet {

		///<summary>group.domain</summary>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		///<summary>group.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>group.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}

	///<summary>
	/// The hash fields represent different bitwise hash algorithms and their values.&#xA;Field names for common hashes (e.g. MD5, SHA1) are predefined. Add fields for other hashes by lowercasing the hash algorithm name and using underscore separators as appropriate (snake case, e.g. sha3_512).&#xA;Note that this fieldset is used for common hashes that may be computed over a range of generic bytes. Entity-specific hashes such as ja3 or imphash are placed in the fieldsets to which they relate (tls and pe, respectively).
	///</summary>
	public abstract class HashFieldSet {

		///<summary>hash.md5</summary>
		[DataMember(Name = "md5")]
		public string Md5 { get; set; }

		///<summary>hash.sha1</summary>
		[DataMember(Name = "sha1")]
		public string Sha1 { get; set; }

		///<summary>hash.sha256</summary>
		[DataMember(Name = "sha256")]
		public string Sha256 { get; set; }

		///<summary>hash.sha384</summary>
		[DataMember(Name = "sha384")]
		public string Sha384 { get; set; }

		///<summary>hash.sha512</summary>
		[DataMember(Name = "sha512")]
		public string Sha512 { get; set; }

		///<summary>hash.ssdeep</summary>
		[DataMember(Name = "ssdeep")]
		public string Ssdeep { get; set; }

		///<summary>hash.tlsh</summary>
		[DataMember(Name = "tlsh")]
		public string Tlsh { get; set; }
	}

	///<summary>
	/// A host is defined as a general computing instance.&#xA;ECS host.* fields should be populated with details about the host on which the event happened, or from which the measurement was taken. Host types include hardware, virtual machines, Docker containers, and Kubernetes nodes.
	///</summary>
	public abstract class HostFieldSet {

		///<summary>host.architecture</summary>
		[DataMember(Name = "architecture")]
		public string Architecture { get; set; }

		///<summary>host.boot.id</summary>
		[DataMember(Name = "boot.id")]
		public string BootId { get; set; }

		///<summary>host.cpu.usage</summary>
		[DataMember(Name = "cpu.usage")]
		public float? CpuUsage { get; set; }

		///<summary>host.disk.read.bytes</summary>
		[DataMember(Name = "disk.read.bytes")]
		public long? DiskReadBytes { get; set; }

		///<summary>host.disk.write.bytes</summary>
		[DataMember(Name = "disk.write.bytes")]
		public long? DiskWriteBytes { get; set; }

		///<summary>host.domain</summary>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		///<summary>host.hostname</summary>
		[DataMember(Name = "hostname")]
		public string Hostname { get; set; }

		///<summary>host.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>host.ip</summary>
		[DataMember(Name = "ip")]
		public string[] Ip { get; set; }

		///<summary>host.mac</summary>
		[DataMember(Name = "mac")]
		public string[] Mac { get; set; }

		///<summary>host.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>host.network.egress.bytes</summary>
		[DataMember(Name = "network.egress.bytes")]
		public long? NetworkEgressBytes { get; set; }

		///<summary>host.network.egress.packets</summary>
		[DataMember(Name = "network.egress.packets")]
		public long? NetworkEgressPackets { get; set; }

		///<summary>host.network.ingress.bytes</summary>
		[DataMember(Name = "network.ingress.bytes")]
		public long? NetworkIngressBytes { get; set; }

		///<summary>host.network.ingress.packets</summary>
		[DataMember(Name = "network.ingress.packets")]
		public long? NetworkIngressPackets { get; set; }

		///<summary>host.pid_ns_ino</summary>
		[DataMember(Name = "pid_ns_ino")]
		public string PidNsIno { get; set; }

		///<summary>host.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>host.uptime</summary>
		[DataMember(Name = "uptime")]
		public long? Uptime { get; set; }
	}

	///<summary>
	/// Fields related to HTTP activity. Use the `url` field set to store the url of the request.
	///</summary>
	public abstract class HttpFieldSet {

		///<summary>http.request.body.bytes</summary>
		[DataMember(Name = "request.body.bytes")]
		public long? RequestBodyBytes { get; set; }

		///<summary>http.request.body.content</summary>
		[DataMember(Name = "request.body.content")]
		public string RequestBodyContent { get; set; }

		///<summary>http.request.bytes</summary>
		[DataMember(Name = "request.bytes")]
		public long? RequestBytes { get; set; }

		///<summary>http.request.id</summary>
		[DataMember(Name = "request.id")]
		public string RequestId { get; set; }

		///<summary>http.request.method</summary>
		[DataMember(Name = "request.method")]
		public string RequestMethod { get; set; }

		///<summary>http.request.mime_type</summary>
		[DataMember(Name = "request.mime_type")]
		public string RequestMimeType { get; set; }

		///<summary>http.request.referrer</summary>
		[DataMember(Name = "request.referrer")]
		public string RequestReferrer { get; set; }

		///<summary>http.response.body.bytes</summary>
		[DataMember(Name = "response.body.bytes")]
		public long? ResponseBodyBytes { get; set; }

		///<summary>http.response.body.content</summary>
		[DataMember(Name = "response.body.content")]
		public string ResponseBodyContent { get; set; }

		///<summary>http.response.bytes</summary>
		[DataMember(Name = "response.bytes")]
		public long? ResponseBytes { get; set; }

		///<summary>http.response.mime_type</summary>
		[DataMember(Name = "response.mime_type")]
		public string ResponseMimeType { get; set; }

		///<summary>http.response.status_code</summary>
		[DataMember(Name = "response.status_code")]
		public long? ResponseStatusCode { get; set; }

		///<summary>http.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}

	///<summary>
	/// The interface fields are used to record ingress and egress interface information when reported by an observer (e.g. firewall, router, load balancer) in the context of the observer handling a network connection.  In the case of a single observer interface (e.g. network sensor on a span port) only the observer.ingress information should be populated.
	///</summary>
	public abstract class InterfaceFieldSet {

		///<summary>interface.alias</summary>
		[DataMember(Name = "alias")]
		public string Alias { get; set; }

		///<summary>interface.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>interface.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}

	///<summary>
	/// Details about the event&#x27;s logging mechanism or logging transport.&#xA;The log.* fields are typically populated with details about the logging mechanism used to create and/or transport the event. For example, syslog details belong under `log.syslog.*`.&#xA;The details specific to your event source are typically not logged under `log.*`, but rather in `event.*` or in other ECS fields.
	///</summary>
	public abstract class LogFieldSet {

		///<summary>log.file.path</summary>
		[DataMember(Name = "file.path")]
		public string FilePath { get; set; }

		///<summary>log.level</summary>
		[DataMember(Name = "level")]
		public string Level { get; set; }

		///<summary>log.logger</summary>
		[DataMember(Name = "logger")]
		public string Logger { get; set; }

		///<summary>log.origin.file.line</summary>
		[DataMember(Name = "origin.file.line")]
		public long? OriginFileLine { get; set; }

		///<summary>log.origin.file.name</summary>
		[DataMember(Name = "origin.file.name")]
		public string OriginFileName { get; set; }

		///<summary>log.origin.function</summary>
		[DataMember(Name = "origin.function")]
		public string OriginFunction { get; set; }

		///<summary>log.syslog</summary>
		[DataMember(Name = "syslog")]
		public LogSyslog Syslog { get; set; }
	}

	///<summary>
	/// The network is defined as the communication path over which a host or network event happens.&#xA;The network.* fields should be populated with details about the network activity associated with an event.
	///</summary>
	public abstract class NetworkFieldSet {

		///<summary>network.application</summary>
		[DataMember(Name = "application")]
		public string Application { get; set; }

		///<summary>network.bytes</summary>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		///<summary>network.community_id</summary>
		[DataMember(Name = "community_id")]
		public string CommunityId { get; set; }

		///<summary>network.direction</summary>
		[DataMember(Name = "direction")]
		public string Direction { get; set; }

		///<summary>network.forwarded_ip</summary>
		[DataMember(Name = "forwarded_ip")]
		public string ForwardedIp { get; set; }

		///<summary>network.iana_number</summary>
		[DataMember(Name = "iana_number")]
		public string IanaNumber { get; set; }

		///<summary>network.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>network.packets</summary>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		///<summary>network.protocol</summary>
		[DataMember(Name = "protocol")]
		public string Protocol { get; set; }

		///<summary>network.transport</summary>
		[DataMember(Name = "transport")]
		public string Transport { get; set; }

		///<summary>network.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>network.inner</summary>
		[DataMember(Name = "inner")]
		public NetworkInner Inner { get; set; }
	}

	///<summary>
	/// An observer is defined as a special network, security, or application device used to detect, observe, or create network, security, or application-related events and metrics.&#xA;This could be a custom hardware appliance or a server that has been configured to run special network, security, or application software. Examples include firewalls, web proxies, intrusion detection/prevention systems, network monitoring sensors, web application firewalls, data loss prevention systems, and APM servers. The observer.* fields shall be populated with details of the system, if any, that detects, observes and/or creates a network, security, or application event or metric. Message queues and ETL components used in processing events or metrics are not considered observers in ECS.
	///</summary>
	public abstract class ObserverFieldSet {

		///<summary>observer.hostname</summary>
		[DataMember(Name = "hostname")]
		public string Hostname { get; set; }

		///<summary>observer.ip</summary>
		[DataMember(Name = "ip")]
		public string[] Ip { get; set; }

		///<summary>observer.mac</summary>
		[DataMember(Name = "mac")]
		public string[] Mac { get; set; }

		///<summary>observer.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>observer.product</summary>
		[DataMember(Name = "product")]
		public string Product { get; set; }

		///<summary>observer.serial_number</summary>
		[DataMember(Name = "serial_number")]
		public string SerialNumber { get; set; }

		///<summary>observer.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>observer.vendor</summary>
		[DataMember(Name = "vendor")]
		public string Vendor { get; set; }

		///<summary>observer.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		///<summary>observer.egress</summary>
		[DataMember(Name = "egress")]
		public ObserverEgress Egress { get; set; }

		///<summary>observer.ingress</summary>
		[DataMember(Name = "ingress")]
		public ObserverIngress Ingress { get; set; }
	}

	///<summary>
	/// Fields that describe the resources which container orchestrators manage or act upon.
	///</summary>
	public abstract class OrchestratorFieldSet {

		///<summary>orchestrator.api_version</summary>
		[DataMember(Name = "api_version")]
		public string ApiVersion { get; set; }

		///<summary>orchestrator.cluster.id</summary>
		[DataMember(Name = "cluster.id")]
		public string ClusterId { get; set; }

		///<summary>orchestrator.cluster.name</summary>
		[DataMember(Name = "cluster.name")]
		public string ClusterName { get; set; }

		///<summary>orchestrator.cluster.url</summary>
		[DataMember(Name = "cluster.url")]
		public string ClusterUrl { get; set; }

		///<summary>orchestrator.cluster.version</summary>
		[DataMember(Name = "cluster.version")]
		public string ClusterVersion { get; set; }

		///<summary>orchestrator.namespace</summary>
		[DataMember(Name = "namespace")]
		public string Namespace { get; set; }

		///<summary>orchestrator.organization</summary>
		[DataMember(Name = "organization")]
		public string Organization { get; set; }

		///<summary>orchestrator.resource.id</summary>
		[DataMember(Name = "resource.id")]
		public string ResourceId { get; set; }

		///<summary>orchestrator.resource.ip</summary>
		[DataMember(Name = "resource.ip")]
		public string[] ResourceIp { get; set; }

		///<summary>orchestrator.resource.name</summary>
		[DataMember(Name = "resource.name")]
		public string ResourceName { get; set; }

		///<summary>orchestrator.resource.parent.type</summary>
		[DataMember(Name = "resource.parent.type")]
		public string ResourceParentType { get; set; }

		///<summary>orchestrator.resource.type</summary>
		[DataMember(Name = "resource.type")]
		public string ResourceType { get; set; }

		///<summary>orchestrator.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }
	}

	///<summary>
	/// The organization fields enrich data with information about the company or entity the data is associated with.&#xA;These fields help you arrange or filter data stored in an index by one or multiple organizations.
	///</summary>
	public abstract class OrganizationFieldSet {

		///<summary>organization.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>organization.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}

	///<summary>
	/// The OS fields contain information about the operating system.
	///</summary>
	public abstract class OsFieldSet {

		///<summary>os.family</summary>
		[DataMember(Name = "family")]
		public string Family { get; set; }

		///<summary>os.full</summary>
		[DataMember(Name = "full")]
		public string Full { get; set; }

		///<summary>os.kernel</summary>
		[DataMember(Name = "kernel")]
		public string Kernel { get; set; }

		///<summary>os.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>os.platform</summary>
		[DataMember(Name = "platform")]
		public string Platform { get; set; }

		///<summary>os.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>os.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}

	///<summary>
	/// These fields contain information about an installed software package. It contains general information about a package, such as name, version or size. It also contains installation details, such as time or location.
	///</summary>
	public abstract class PackageFieldSet {

		///<summary>package.architecture</summary>
		[DataMember(Name = "architecture")]
		public string Architecture { get; set; }

		///<summary>package.build_version</summary>
		[DataMember(Name = "build_version")]
		public string BuildVersion { get; set; }

		///<summary>package.checksum</summary>
		[DataMember(Name = "checksum")]
		public string Checksum { get; set; }

		///<summary>package.description</summary>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		///<summary>package.install_scope</summary>
		[DataMember(Name = "install_scope")]
		public string InstallScope { get; set; }

		///<summary>package.installed</summary>
		[DataMember(Name = "installed")]
		public DateTimeOffset? Installed { get; set; }

		///<summary>package.license</summary>
		[DataMember(Name = "license")]
		public string License { get; set; }

		///<summary>package.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>package.path</summary>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		///<summary>package.reference</summary>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		///<summary>package.size</summary>
		[DataMember(Name = "size")]
		public long? Size { get; set; }

		///<summary>package.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>package.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}

	///<summary>
	/// These fields contain Windows Portable Executable (PE) metadata.
	///</summary>
	public abstract class PeFieldSet {

		///<summary>pe.architecture</summary>
		[DataMember(Name = "architecture")]
		public string Architecture { get; set; }

		///<summary>pe.company</summary>
		[DataMember(Name = "company")]
		public string Company { get; set; }

		///<summary>pe.description</summary>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		///<summary>pe.file_version</summary>
		[DataMember(Name = "file_version")]
		public string FileVersion { get; set; }

		///<summary>pe.imphash</summary>
		[DataMember(Name = "imphash")]
		public string Imphash { get; set; }

		///<summary>pe.original_file_name</summary>
		[DataMember(Name = "original_file_name")]
		public string OriginalFileName { get; set; }

		///<summary>pe.pehash</summary>
		[DataMember(Name = "pehash")]
		public string Pehash { get; set; }

		///<summary>pe.product</summary>
		[DataMember(Name = "product")]
		public string Product { get; set; }
	}

	///<summary>
	/// These fields contain information about a process.&#xA;These fields can help you correlate metrics information with a process id/name from a log message.  The `process.pid` often stays in the metric itself and is copied to the global field for correlation.
	///</summary>
	public abstract class ProcessFieldSet {

		///<summary>process.args</summary>
		[DataMember(Name = "args")]
		public string[] Args { get; set; }

		///<summary>process.args_count</summary>
		[DataMember(Name = "args_count")]
		public long? ArgsCount { get; set; }

		///<summary>process.command_line</summary>
		[DataMember(Name = "command_line")]
		public string CommandLine { get; set; }

		///<summary>process.end</summary>
		[DataMember(Name = "end")]
		public DateTimeOffset? End { get; set; }

		///<summary>process.entity_id</summary>
		[DataMember(Name = "entity_id")]
		public string EntityId { get; set; }

		///<summary>process.executable</summary>
		[DataMember(Name = "executable")]
		public string Executable { get; set; }

		///<summary>process.exit_code</summary>
		[DataMember(Name = "exit_code")]
		public long? ExitCode { get; set; }

		///<summary>process.interactive</summary>
		[DataMember(Name = "interactive")]
		public bool? Interactive { get; set; }

		///<summary>process.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>process.pgid</summary>
		[DataMember(Name = "pgid")]
		public long? Pgid { get; set; }

		///<summary>process.pid</summary>
		[DataMember(Name = "pid")]
		public long? Pid { get; set; }

		///<summary>process.start</summary>
		[DataMember(Name = "start")]
		public DateTimeOffset? Start { get; set; }

		///<summary>process.thread.id</summary>
		[DataMember(Name = "thread.id")]
		public long? ThreadId { get; set; }

		///<summary>process.thread.name</summary>
		[DataMember(Name = "thread.name")]
		public string ThreadName { get; set; }

		///<summary>process.title</summary>
		[DataMember(Name = "title")]
		public string Title { get; set; }

		///<summary>process.uptime</summary>
		[DataMember(Name = "uptime")]
		public long? Uptime { get; set; }

		///<summary>process.working_directory</summary>
		[DataMember(Name = "working_directory")]
		public string WorkingDirectory { get; set; }

		///<summary>process.env_vars</summary>
		[DataMember(Name = "env_vars")]
		public ProcessEnvVars EnvVars { get; set; }

		///<summary>process.tty</summary>
		[DataMember(Name = "tty")]
		public ProcessTty Tty { get; set; }
	}

	///<summary>
	/// Fields related to Windows Registry operations.
	///</summary>
	public abstract class RegistryFieldSet {

		///<summary>registry.data.bytes</summary>
		[DataMember(Name = "data.bytes")]
		public string DataBytes { get; set; }

		///<summary>registry.data.strings</summary>
		[DataMember(Name = "data.strings")]
		public string[] DataStrings { get; set; }

		///<summary>registry.data.type</summary>
		[DataMember(Name = "data.type")]
		public string DataType { get; set; }

		///<summary>registry.hive</summary>
		[DataMember(Name = "hive")]
		public string Hive { get; set; }

		///<summary>registry.key</summary>
		[DataMember(Name = "key")]
		public string Key { get; set; }

		///<summary>registry.path</summary>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		///<summary>registry.value</summary>
		[DataMember(Name = "value")]
		public string Value { get; set; }
	}

	///<summary>
	/// This field set is meant to facilitate pivoting around a piece of data.&#xA;Some pieces of information can be seen in many places in an ECS event. To facilitate searching for them, store an array of all seen values to their corresponding field in `related.`.&#xA;A concrete example is IP addresses, which can be under host, observer, source, destination, client, server, and network.forwarded_ip. If you append all IPs to `related.ip`, you can then search for a given IP trivially, no matter where it appeared, by querying `related.ip:192.0.2.15`.
	///</summary>
	public abstract class RelatedFieldSet {

		///<summary>related.hash</summary>
		[DataMember(Name = "hash")]
		public string[] Hash { get; set; }

		///<summary>related.hosts</summary>
		[DataMember(Name = "hosts")]
		public string[] Hosts { get; set; }

		///<summary>related.ip</summary>
		[DataMember(Name = "ip")]
		public string[] Ip { get; set; }

		///<summary>related.user</summary>
		[DataMember(Name = "user")]
		public string[] User { get; set; }
	}

	///<summary>
	/// Rule fields are used to capture the specifics of any observer or agent rules that generate alerts or other notable events.&#xA;Examples of data sources that would populate the rule fields include: network admission control platforms, network or host IDS/IPS, network firewalls, web application firewalls, url filters, endpoint detection and response (EDR) systems, etc.
	///</summary>
	public abstract class RuleFieldSet {

		///<summary>rule.author</summary>
		[DataMember(Name = "author")]
		public string[] Author { get; set; }

		///<summary>rule.category</summary>
		[DataMember(Name = "category")]
		public string Category { get; set; }

		///<summary>rule.description</summary>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		///<summary>rule.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>rule.license</summary>
		[DataMember(Name = "license")]
		public string License { get; set; }

		///<summary>rule.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>rule.reference</summary>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		///<summary>rule.ruleset</summary>
		[DataMember(Name = "ruleset")]
		public string Ruleset { get; set; }

		///<summary>rule.uuid</summary>
		[DataMember(Name = "uuid")]
		public string Uuid { get; set; }

		///<summary>rule.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}

	///<summary>
	/// A Server is defined as the responder in a network connection for events regarding sessions, connections, or bidirectional flow records.&#xA;For TCP events, the server is the receiver of the initial SYN packet(s) of the TCP connection. For other protocols, the server is generally the responder in the network transaction. Some systems actually use the term &quot;responder&quot; to refer the server in TCP connections. The server fields describe details about the system acting as the server in the network event. Server fields are usually populated in conjunction with client fields. Server fields are generally not populated for packet-level events.&#xA;Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
	///</summary>
	public abstract class ServerFieldSet {

		///<summary>server.address</summary>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		///<summary>server.bytes</summary>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		///<summary>server.domain</summary>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		///<summary>server.ip</summary>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		///<summary>server.mac</summary>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		///<summary>server.nat.ip</summary>
		[DataMember(Name = "nat.ip")]
		public string NatIp { get; set; }

		///<summary>server.nat.port</summary>
		[DataMember(Name = "nat.port")]
		public long? NatPort { get; set; }

		///<summary>server.packets</summary>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		///<summary>server.port</summary>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		///<summary>server.registered_domain</summary>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		///<summary>server.subdomain</summary>
		[DataMember(Name = "subdomain")]
		public string Subdomain { get; set; }

		///<summary>server.top_level_domain</summary>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }
	}

	///<summary>
	/// The service fields describe the service for or from which the data was collected.&#xA;These fields help you find and correlate logs for a specific service and version.
	///</summary>
	public abstract class ServiceFieldSet {

		///<summary>service.address</summary>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		///<summary>service.environment</summary>
		[DataMember(Name = "environment")]
		public string Environment { get; set; }

		///<summary>service.ephemeral_id</summary>
		[DataMember(Name = "ephemeral_id")]
		public string EphemeralId { get; set; }

		///<summary>service.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>service.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>service.node.name</summary>
		[DataMember(Name = "node.name")]
		public string NodeName { get; set; }

		///<summary>service.node.role</summary>
		[DataMember(Name = "node.role")]
		public string NodeRole { get; set; }

		///<summary>service.state</summary>
		[DataMember(Name = "state")]
		public string State { get; set; }

		///<summary>service.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>service.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}

	///<summary>
	/// Source fields capture details about the sender of a network exchange/packet. These fields are populated from a network event, packet, or other event containing details of a network transaction.&#xA;Source fields are usually populated in conjunction with destination fields. The source and destination fields are considered the baseline and should always be filled if an event contains source and destination details from a network transaction. If the event also contains identification of the client and server roles, then the client and server fields should also be populated.
	///</summary>
	public abstract class SourceFieldSet {

		///<summary>source.address</summary>
		[DataMember(Name = "address")]
		public string Address { get; set; }

		///<summary>source.bytes</summary>
		[DataMember(Name = "bytes")]
		public long? Bytes { get; set; }

		///<summary>source.domain</summary>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		///<summary>source.ip</summary>
		[DataMember(Name = "ip")]
		public string Ip { get; set; }

		///<summary>source.mac</summary>
		[DataMember(Name = "mac")]
		public string Mac { get; set; }

		///<summary>source.nat.ip</summary>
		[DataMember(Name = "nat.ip")]
		public string NatIp { get; set; }

		///<summary>source.nat.port</summary>
		[DataMember(Name = "nat.port")]
		public long? NatPort { get; set; }

		///<summary>source.packets</summary>
		[DataMember(Name = "packets")]
		public long? Packets { get; set; }

		///<summary>source.port</summary>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		///<summary>source.registered_domain</summary>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		///<summary>source.subdomain</summary>
		[DataMember(Name = "subdomain")]
		public string Subdomain { get; set; }

		///<summary>source.top_level_domain</summary>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }
	}

	///<summary>
	/// Fields to classify events and alerts according to a threat taxonomy such as the MITRE ATT&amp;CK&#xAE; framework.&#xA;These fields are for users to classify alerts from all of their sources (e.g. IDS, NGFW, etc.) within a common taxonomy. The threat.tactic.* fields are meant to capture the high level category of the threat (e.g. &quot;impact&quot;). The threat.technique.* fields are meant to capture which kind of approach is used by this detected threat, to accomplish the goal (e.g. &quot;endpoint denial of service&quot;).
	///</summary>
	public abstract class ThreatFieldSet {

		///<summary>threat.feed.dashboard_id</summary>
		[DataMember(Name = "feed.dashboard_id")]
		public string FeedDashboardId { get; set; }

		///<summary>threat.feed.description</summary>
		[DataMember(Name = "feed.description")]
		public string FeedDescription { get; set; }

		///<summary>threat.feed.name</summary>
		[DataMember(Name = "feed.name")]
		public string FeedName { get; set; }

		///<summary>threat.feed.reference</summary>
		[DataMember(Name = "feed.reference")]
		public string FeedReference { get; set; }

		///<summary>threat.framework</summary>
		[DataMember(Name = "framework")]
		public string Framework { get; set; }

		///<summary>threat.group.alias</summary>
		[DataMember(Name = "group.alias")]
		public string[] GroupAlias { get; set; }

		///<summary>threat.group.id</summary>
		[DataMember(Name = "group.id")]
		public string GroupId { get; set; }

		///<summary>threat.group.name</summary>
		[DataMember(Name = "group.name")]
		public string GroupName { get; set; }

		///<summary>threat.group.reference</summary>
		[DataMember(Name = "group.reference")]
		public string GroupReference { get; set; }

		///<summary>threat.indicator.confidence</summary>
		[DataMember(Name = "indicator.confidence")]
		public string IndicatorConfidence { get; set; }

		///<summary>threat.indicator.description</summary>
		[DataMember(Name = "indicator.description")]
		public string IndicatorDescription { get; set; }

		///<summary>threat.indicator.email.address</summary>
		[DataMember(Name = "indicator.email.address")]
		public string IndicatorEmailAddress { get; set; }

		///<summary>threat.indicator.first_seen</summary>
		[DataMember(Name = "indicator.first_seen")]
		public DateTimeOffset? IndicatorFirstSeen { get; set; }

		///<summary>threat.indicator.ip</summary>
		[DataMember(Name = "indicator.ip")]
		public string IndicatorIp { get; set; }

		///<summary>threat.indicator.last_seen</summary>
		[DataMember(Name = "indicator.last_seen")]
		public DateTimeOffset? IndicatorLastSeen { get; set; }

		///<summary>threat.indicator.marking.tlp</summary>
		[DataMember(Name = "indicator.marking.tlp")]
		public string IndicatorMarkingTlp { get; set; }

		///<summary>threat.indicator.modified_at</summary>
		[DataMember(Name = "indicator.modified_at")]
		public DateTimeOffset? IndicatorModifiedAt { get; set; }

		///<summary>threat.indicator.port</summary>
		[DataMember(Name = "indicator.port")]
		public long? IndicatorPort { get; set; }

		///<summary>threat.indicator.provider</summary>
		[DataMember(Name = "indicator.provider")]
		public string IndicatorProvider { get; set; }

		///<summary>threat.indicator.reference</summary>
		[DataMember(Name = "indicator.reference")]
		public string IndicatorReference { get; set; }

		///<summary>threat.indicator.scanner_stats</summary>
		[DataMember(Name = "indicator.scanner_stats")]
		public long? IndicatorScannerStats { get; set; }

		///<summary>threat.indicator.sightings</summary>
		[DataMember(Name = "indicator.sightings")]
		public long? IndicatorSightings { get; set; }

		///<summary>threat.indicator.type</summary>
		[DataMember(Name = "indicator.type")]
		public string IndicatorType { get; set; }

		///<summary>threat.software.alias</summary>
		[DataMember(Name = "software.alias")]
		public string[] SoftwareAlias { get; set; }

		///<summary>threat.software.id</summary>
		[DataMember(Name = "software.id")]
		public string SoftwareId { get; set; }

		///<summary>threat.software.name</summary>
		[DataMember(Name = "software.name")]
		public string SoftwareName { get; set; }

		///<summary>threat.software.platforms</summary>
		[DataMember(Name = "software.platforms")]
		public string[] SoftwarePlatforms { get; set; }

		///<summary>threat.software.reference</summary>
		[DataMember(Name = "software.reference")]
		public string SoftwareReference { get; set; }

		///<summary>threat.software.type</summary>
		[DataMember(Name = "software.type")]
		public string SoftwareType { get; set; }

		///<summary>threat.tactic.id</summary>
		[DataMember(Name = "tactic.id")]
		public string[] TacticId { get; set; }

		///<summary>threat.tactic.name</summary>
		[DataMember(Name = "tactic.name")]
		public string[] TacticName { get; set; }

		///<summary>threat.tactic.reference</summary>
		[DataMember(Name = "tactic.reference")]
		public string[] TacticReference { get; set; }

		///<summary>threat.technique.id</summary>
		[DataMember(Name = "technique.id")]
		public string[] TechniqueId { get; set; }

		///<summary>threat.technique.name</summary>
		[DataMember(Name = "technique.name")]
		public string[] TechniqueName { get; set; }

		///<summary>threat.technique.reference</summary>
		[DataMember(Name = "technique.reference")]
		public string[] TechniqueReference { get; set; }

		///<summary>threat.technique.subtechnique.id</summary>
		[DataMember(Name = "technique.subtechnique.id")]
		public string[] TechniqueSubtechniqueId { get; set; }

		///<summary>threat.technique.subtechnique.name</summary>
		[DataMember(Name = "technique.subtechnique.name")]
		public string[] TechniqueSubtechniqueName { get; set; }

		///<summary>threat.technique.subtechnique.reference</summary>
		[DataMember(Name = "technique.subtechnique.reference")]
		public string[] TechniqueSubtechniqueReference { get; set; }

		///<summary>threat.enrichments</summary>
		[DataMember(Name = "enrichments")]
		public ThreatEnrichments Enrichments { get; set; }
	}

	///<summary>
	/// Fields related to a TLS connection. These fields focus on the TLS protocol itself and intentionally avoids in-depth analysis of the related x.509 certificate files.
	///</summary>
	public abstract class TlsFieldSet {

		///<summary>tls.cipher</summary>
		[DataMember(Name = "cipher")]
		public string Cipher { get; set; }

		///<summary>tls.client.certificate</summary>
		[DataMember(Name = "client.certificate")]
		public string ClientCertificate { get; set; }

		///<summary>tls.client.certificate_chain</summary>
		[DataMember(Name = "client.certificate_chain")]
		public string[] ClientCertificateChain { get; set; }

		///<summary>tls.client.hash.md5</summary>
		[DataMember(Name = "client.hash.md5")]
		public string ClientHashMd5 { get; set; }

		///<summary>tls.client.hash.sha1</summary>
		[DataMember(Name = "client.hash.sha1")]
		public string ClientHashSha1 { get; set; }

		///<summary>tls.client.hash.sha256</summary>
		[DataMember(Name = "client.hash.sha256")]
		public string ClientHashSha256 { get; set; }

		///<summary>tls.client.issuer</summary>
		[DataMember(Name = "client.issuer")]
		public string ClientIssuer { get; set; }

		///<summary>tls.client.ja3</summary>
		[DataMember(Name = "client.ja3")]
		public string ClientJa3 { get; set; }

		///<summary>tls.client.not_after</summary>
		[DataMember(Name = "client.not_after")]
		public DateTimeOffset? ClientNotAfter { get; set; }

		///<summary>tls.client.not_before</summary>
		[DataMember(Name = "client.not_before")]
		public DateTimeOffset? ClientNotBefore { get; set; }

		///<summary>tls.client.server_name</summary>
		[DataMember(Name = "client.server_name")]
		public string ClientServerName { get; set; }

		///<summary>tls.client.subject</summary>
		[DataMember(Name = "client.subject")]
		public string ClientSubject { get; set; }

		///<summary>tls.client.supported_ciphers</summary>
		[DataMember(Name = "client.supported_ciphers")]
		public string[] ClientSupportedCiphers { get; set; }

		///<summary>tls.curve</summary>
		[DataMember(Name = "curve")]
		public string Curve { get; set; }

		///<summary>tls.established</summary>
		[DataMember(Name = "established")]
		public bool? Established { get; set; }

		///<summary>tls.next_protocol</summary>
		[DataMember(Name = "next_protocol")]
		public string NextProtocol { get; set; }

		///<summary>tls.resumed</summary>
		[DataMember(Name = "resumed")]
		public bool? Resumed { get; set; }

		///<summary>tls.server.certificate</summary>
		[DataMember(Name = "server.certificate")]
		public string ServerCertificate { get; set; }

		///<summary>tls.server.certificate_chain</summary>
		[DataMember(Name = "server.certificate_chain")]
		public string[] ServerCertificateChain { get; set; }

		///<summary>tls.server.hash.md5</summary>
		[DataMember(Name = "server.hash.md5")]
		public string ServerHashMd5 { get; set; }

		///<summary>tls.server.hash.sha1</summary>
		[DataMember(Name = "server.hash.sha1")]
		public string ServerHashSha1 { get; set; }

		///<summary>tls.server.hash.sha256</summary>
		[DataMember(Name = "server.hash.sha256")]
		public string ServerHashSha256 { get; set; }

		///<summary>tls.server.issuer</summary>
		[DataMember(Name = "server.issuer")]
		public string ServerIssuer { get; set; }

		///<summary>tls.server.ja3s</summary>
		[DataMember(Name = "server.ja3s")]
		public string ServerJa3s { get; set; }

		///<summary>tls.server.not_after</summary>
		[DataMember(Name = "server.not_after")]
		public DateTimeOffset? ServerNotAfter { get; set; }

		///<summary>tls.server.not_before</summary>
		[DataMember(Name = "server.not_before")]
		public DateTimeOffset? ServerNotBefore { get; set; }

		///<summary>tls.server.subject</summary>
		[DataMember(Name = "server.subject")]
		public string ServerSubject { get; set; }

		///<summary>tls.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }

		///<summary>tls.version_protocol</summary>
		[DataMember(Name = "version_protocol")]
		public string VersionProtocol { get; set; }
	}

	///<summary>
	/// URL fields provide support for complete or partial URLs, and supports the breaking down into scheme, domain, path, and so on.
	///</summary>
	public abstract class UrlFieldSet {

		///<summary>url.domain</summary>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		///<summary>url.extension</summary>
		[DataMember(Name = "extension")]
		public string Extension { get; set; }

		///<summary>url.fragment</summary>
		[DataMember(Name = "fragment")]
		public string Fragment { get; set; }

		///<summary>url.full</summary>
		[DataMember(Name = "full")]
		public string Full { get; set; }

		///<summary>url.original</summary>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		///<summary>url.password</summary>
		[DataMember(Name = "password")]
		public string Password { get; set; }

		///<summary>url.path</summary>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		///<summary>url.port</summary>
		[DataMember(Name = "port")]
		public long? Port { get; set; }

		///<summary>url.query</summary>
		[DataMember(Name = "query")]
		public string Query { get; set; }

		///<summary>url.registered_domain</summary>
		[DataMember(Name = "registered_domain")]
		public string RegisteredDomain { get; set; }

		///<summary>url.scheme</summary>
		[DataMember(Name = "scheme")]
		public string Scheme { get; set; }

		///<summary>url.subdomain</summary>
		[DataMember(Name = "subdomain")]
		public string Subdomain { get; set; }

		///<summary>url.top_level_domain</summary>
		[DataMember(Name = "top_level_domain")]
		public string TopLevelDomain { get; set; }

		///<summary>url.username</summary>
		[DataMember(Name = "username")]
		public string Username { get; set; }
	}

	///<summary>
	/// The user fields describe information about the user that is relevant to the event.&#xA;Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
	///</summary>
	public abstract class UserFieldSet {

		///<summary>user.domain</summary>
		[DataMember(Name = "domain")]
		public string Domain { get; set; }

		///<summary>user.email</summary>
		[DataMember(Name = "email")]
		public string Email { get; set; }

		///<summary>user.full_name</summary>
		[DataMember(Name = "full_name")]
		public string FullName { get; set; }

		///<summary>user.hash</summary>
		[DataMember(Name = "hash")]
		public string Hash { get; set; }

		///<summary>user.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>user.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>user.roles</summary>
		[DataMember(Name = "roles")]
		public string[] Roles { get; set; }
	}

	///<summary>
	/// The user_agent fields normally come from a browser request.&#xA;They often show up in web service logs coming from the parsed user agent string.
	///</summary>
	public abstract class UserAgentFieldSet {

		///<summary>user_agent.device.name</summary>
		[DataMember(Name = "device.name")]
		public string DeviceName { get; set; }

		///<summary>user_agent.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>user_agent.original</summary>
		[DataMember(Name = "original")]
		public string Original { get; set; }

		///<summary>user_agent.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}

	///<summary>
	/// The VLAN fields are used to identify 802.1q tag(s) of a packet, as well as ingress and egress VLAN associations of an observer in relation to a specific packet or connection.&#xA;Network.vlan fields are used to record a single VLAN tag, or the outer tag in the case of q-in-q encapsulations, for a packet or connection as observed, typically provided by a network sensor (e.g. Zeek, Wireshark) passively reporting on traffic.&#xA;Network.inner VLAN fields are used to report inner q-in-q 802.1q tags (multiple 802.1q encapsulations) as observed, typically provided by a network sensor  (e.g. Zeek, Wireshark) passively reporting on traffic. Network.inner VLAN fields should only be used in addition to network.vlan fields to indicate q-in-q tagging.&#xA;Observer.ingress and observer.egress VLAN values are used to record observer specific information when observer events contain discrete ingress and egress VLAN information, typically provided by firewalls, routers, or load balancers.
	///</summary>
	public abstract class VlanFieldSet {

		///<summary>vlan.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>vlan.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}

	///<summary>
	/// The vulnerability fields describe information about a vulnerability that is relevant to an event.
	///</summary>
	public abstract class VulnerabilityFieldSet {

		///<summary>vulnerability.category</summary>
		[DataMember(Name = "category")]
		public string[] Category { get; set; }

		///<summary>vulnerability.classification</summary>
		[DataMember(Name = "classification")]
		public string Classification { get; set; }

		///<summary>vulnerability.description</summary>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		///<summary>vulnerability.enumeration</summary>
		[DataMember(Name = "enumeration")]
		public string Enumeration { get; set; }

		///<summary>vulnerability.id</summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		///<summary>vulnerability.reference</summary>
		[DataMember(Name = "reference")]
		public string Reference { get; set; }

		///<summary>vulnerability.report_id</summary>
		[DataMember(Name = "report_id")]
		public string ReportId { get; set; }

		///<summary>vulnerability.scanner.vendor</summary>
		[DataMember(Name = "scanner.vendor")]
		public string ScannerVendor { get; set; }

		///<summary>vulnerability.score.base</summary>
		[DataMember(Name = "score.base")]
		public float? ScoreBase { get; set; }

		///<summary>vulnerability.score.environmental</summary>
		[DataMember(Name = "score.environmental")]
		public float? ScoreEnvironmental { get; set; }

		///<summary>vulnerability.score.temporal</summary>
		[DataMember(Name = "score.temporal")]
		public float? ScoreTemporal { get; set; }

		///<summary>vulnerability.score.version</summary>
		[DataMember(Name = "score.version")]
		public string ScoreVersion { get; set; }

		///<summary>vulnerability.severity</summary>
		[DataMember(Name = "severity")]
		public string Severity { get; set; }
	}

	///<summary>
	/// This implements the common core fields for x509 certificates. This information is likely logged with TLS sessions, digital signatures found in executable binaries, S/MIME information in email bodies, or analysis of files on disk.&#xA;When the certificate relates to a file, use the fields at `file.x509`. When hashes of the DER-encoded certificate are available, the `hash` data set should be populated as well (e.g. `file.hash.sha256`).&#xA;Events that contain certificate information about network connections, should use the x509 fields under the relevant TLS fields: `tls.server.x509` and/or `tls.client.x509`.
	///</summary>
	public abstract class X509FieldSet {

		///<summary>x509.alternative_names</summary>
		[DataMember(Name = "alternative_names")]
		public string[] AlternativeNames { get; set; }

		///<summary>x509.issuer.common_name</summary>
		[DataMember(Name = "issuer.common_name")]
		public string[] IssuerCommonName { get; set; }

		///<summary>x509.issuer.country</summary>
		[DataMember(Name = "issuer.country")]
		public string[] IssuerCountry { get; set; }

		///<summary>x509.issuer.distinguished_name</summary>
		[DataMember(Name = "issuer.distinguished_name")]
		public string IssuerDistinguishedName { get; set; }

		///<summary>x509.issuer.locality</summary>
		[DataMember(Name = "issuer.locality")]
		public string[] IssuerLocality { get; set; }

		///<summary>x509.issuer.organization</summary>
		[DataMember(Name = "issuer.organization")]
		public string[] IssuerOrganization { get; set; }

		///<summary>x509.issuer.organizational_unit</summary>
		[DataMember(Name = "issuer.organizational_unit")]
		public string[] IssuerOrganizationalUnit { get; set; }

		///<summary>x509.issuer.state_or_province</summary>
		[DataMember(Name = "issuer.state_or_province")]
		public string[] IssuerStateOrProvince { get; set; }

		///<summary>x509.not_after</summary>
		[DataMember(Name = "not_after")]
		public DateTimeOffset? NotAfter { get; set; }

		///<summary>x509.not_before</summary>
		[DataMember(Name = "not_before")]
		public DateTimeOffset? NotBefore { get; set; }

		///<summary>x509.public_key_algorithm</summary>
		[DataMember(Name = "public_key_algorithm")]
		public string PublicKeyAlgorithm { get; set; }

		///<summary>x509.public_key_curve</summary>
		[DataMember(Name = "public_key_curve")]
		public string PublicKeyCurve { get; set; }

		///<summary>x509.public_key_exponent</summary>
		[DataMember(Name = "public_key_exponent")]
		public long? PublicKeyExponent { get; set; }

		///<summary>x509.public_key_size</summary>
		[DataMember(Name = "public_key_size")]
		public long? PublicKeySize { get; set; }

		///<summary>x509.serial_number</summary>
		[DataMember(Name = "serial_number")]
		public string SerialNumber { get; set; }

		///<summary>x509.signature_algorithm</summary>
		[DataMember(Name = "signature_algorithm")]
		public string SignatureAlgorithm { get; set; }

		///<summary>x509.subject.common_name</summary>
		[DataMember(Name = "subject.common_name")]
		public string[] SubjectCommonName { get; set; }

		///<summary>x509.subject.country</summary>
		[DataMember(Name = "subject.country")]
		public string[] SubjectCountry { get; set; }

		///<summary>x509.subject.distinguished_name</summary>
		[DataMember(Name = "subject.distinguished_name")]
		public string SubjectDistinguishedName { get; set; }

		///<summary>x509.subject.locality</summary>
		[DataMember(Name = "subject.locality")]
		public string[] SubjectLocality { get; set; }

		///<summary>x509.subject.organization</summary>
		[DataMember(Name = "subject.organization")]
		public string[] SubjectOrganization { get; set; }

		///<summary>x509.subject.organizational_unit</summary>
		[DataMember(Name = "subject.organizational_unit")]
		public string[] SubjectOrganizationalUnit { get; set; }

		///<summary>x509.subject.state_or_province</summary>
		[DataMember(Name = "subject.state_or_province")]
		public string[] SubjectStateOrProvince { get; set; }

		///<summary>x509.version_number</summary>
		[DataMember(Name = "version_number")]
		public string VersionNumber { get; set; }
	}
}
