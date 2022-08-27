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
	/// Custom key/value pairs.&#xA;Can be used to add meta information to events. Should not contain nested objects. All values are stored as keyword.&#xA;Example: `docker` and `k8s` labels.
	///</summary>
	public class Labels : Dictionary<string, string> {
	}

	///<summary>
	/// Image labels.
	///</summary>
	public class ContainerLabels : Dictionary<string, string> {
	}

	///<summary>
	/// An array containing an object for each answer section returned by the server.&#xA;The main keys that should be present in these objects are defined by ECS. Records that have more information may contain more keys than what ECS defines.&#xA;Not all DNS data sources give all details about DNS answers. At minimum, answer objects must contain the `data` key. If more information is available, map as much of it to ECS as possible, and add any additional fields to the answer objects as custom fields.
	///</summary>
	public class DnsAnswers {

		///<summary>dns.answers.class</summary>
		[DataMember(Name = "class")]
		public string Class { get; set; }

		///<summary>dns.answers.data</summary>
		[DataMember(Name = "data")]
		public string Data { get; set; }

		///<summary>dns.answers.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>dns.answers.ttl</summary>
		[DataMember(Name = "ttl")]
		public long? Ttl { get; set; }

		///<summary>dns.answers.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }
	}

	///<summary>
	/// An array containing an object for each section of the ELF file.&#xA;The keys that should be present in these objects are defined by sub-fields underneath `elf.sections.*`.
	///</summary>
	public class ElfSections {

		///<summary>elf.sections.chi2</summary>
		[DataMember(Name = "chi2")]
		public long? Chi2 { get; set; }

		///<summary>elf.sections.entropy</summary>
		[DataMember(Name = "entropy")]
		public long? Entropy { get; set; }

		///<summary>elf.sections.flags</summary>
		[DataMember(Name = "flags")]
		public string Flags { get; set; }

		///<summary>elf.sections.name</summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		///<summary>elf.sections.physical_offset</summary>
		[DataMember(Name = "physical_offset")]
		public string PhysicalOffset { get; set; }

		///<summary>elf.sections.physical_size</summary>
		[DataMember(Name = "physical_size")]
		public long? PhysicalSize { get; set; }

		///<summary>elf.sections.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		///<summary>elf.sections.virtual_address</summary>
		[DataMember(Name = "virtual_address")]
		public long? VirtualAddress { get; set; }

		///<summary>elf.sections.virtual_size</summary>
		[DataMember(Name = "virtual_size")]
		public long? VirtualSize { get; set; }
	}

	///<summary>
	/// An array containing an object for each segment of the ELF file.&#xA;The keys that should be present in these objects are defined by sub-fields underneath `elf.segments.*`.
	///</summary>
	public class ElfSegments {

		///<summary>elf.segments.sections</summary>
		[DataMember(Name = "sections")]
		public string Sections { get; set; }

		///<summary>elf.segments.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }
	}

	///<summary>
	/// A list of objects describing the attachment files sent along with an email message.
	///</summary>
	public class EmailAttachments {

		///<summary>email.attachments.file.extension</summary>
		[DataMember(Name = "file.extension")]
		public string FileExtension { get; set; }

		///<summary>email.attachments.file.mime_type</summary>
		[DataMember(Name = "file.mime_type")]
		public string FileMimeType { get; set; }

		///<summary>email.attachments.file.name</summary>
		[DataMember(Name = "file.name")]
		public string FileName { get; set; }

		///<summary>email.attachments.file.size</summary>
		[DataMember(Name = "file.size")]
		public long? FileSize { get; set; }

		///<summary>email.attachments.file.hash</summary>
		[DataMember(Name = "file.hash")]
		public Hash FileHash { get; set; }
	}

	///<summary>
	/// Details about the function trigger.
	///</summary>
	public class FaasTrigger {

		///<summary>faas.trigger.request_id</summary>
		[DataMember(Name = "request_id")]
		public string RequestId { get; set; }

		///<summary>faas.trigger.type</summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }
	}

	///<summary>
	/// The Syslog metadata of the event, if the event was transmitted via Syslog. Please see RFCs 5424 or 3164.
	///</summary>
	public class LogSyslog {

		///<summary>log.syslog.appname</summary>
		[DataMember(Name = "appname")]
		public string Appname { get; set; }

		///<summary>log.syslog.facility.code</summary>
		[DataMember(Name = "facility.code")]
		public long? FacilityCode { get; set; }

		///<summary>log.syslog.facility.name</summary>
		[DataMember(Name = "facility.name")]
		public string FacilityName { get; set; }

		///<summary>log.syslog.hostname</summary>
		[DataMember(Name = "hostname")]
		public string Hostname { get; set; }

		///<summary>log.syslog.msgid</summary>
		[DataMember(Name = "msgid")]
		public string Msgid { get; set; }

		///<summary>log.syslog.priority</summary>
		[DataMember(Name = "priority")]
		public long? Priority { get; set; }

		///<summary>log.syslog.procid</summary>
		[DataMember(Name = "procid")]
		public string Procid { get; set; }

		///<summary>log.syslog.severity.code</summary>
		[DataMember(Name = "severity.code")]
		public long? SeverityCode { get; set; }

		///<summary>log.syslog.severity.name</summary>
		[DataMember(Name = "severity.name")]
		public string SeverityName { get; set; }

		///<summary>log.syslog.structured_data</summary>
		[DataMember(Name = "structured_data")]
		public string StructuredData { get; set; }

		///<summary>log.syslog.version</summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}

	///<summary>
	/// Network.inner fields are added in addition to network.vlan fields to describe the innermost VLAN when q-in-q VLAN tagging is present. Allowed fields include vlan.id and vlan.name. Inner vlan fields are typically used when sending traffic with multiple 802.1q encapsulations to a network sensor (e.g. Zeek, Wireshark.)
	///</summary>
	public class NetworkInner {

		///<summary>network.inner.vlan</summary>
		[DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }
	}

	///<summary>
	/// Observer.egress holds information like interface number and name, vlan, and zone information to classify egress traffic.  Single armed monitoring such as a network sensor on a span port should only use observer.ingress to categorize traffic.
	///</summary>
	public class ObserverEgress {

		///<summary>observer.egress.zone</summary>
		[DataMember(Name = "zone")]
		public string Zone { get; set; }

		///<summary>observer.egress.interface</summary>
		[DataMember(Name = "interface")]
		public Interface Interface { get; set; }

		///<summary>observer.egress.vlan</summary>
		[DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }
	}

	///<summary>
	/// Observer.ingress holds information like interface number and name, vlan, and zone information to classify ingress traffic.  Single armed monitoring such as a network sensor on a span port should only use observer.ingress to categorize traffic.
	///</summary>
	public class ObserverIngress {

		///<summary>observer.ingress.zone</summary>
		[DataMember(Name = "zone")]
		public string Zone { get; set; }

		///<summary>observer.ingress.interface</summary>
		[DataMember(Name = "interface")]
		public Interface Interface { get; set; }

		///<summary>observer.ingress.vlan</summary>
		[DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }
	}

	///<summary>
	/// Environment variables (`env_vars`) set at the time of the event. May be filtered to protect sensitive information.&#xA;The field should not contain nested objects. All values should use `keyword`.
	///</summary>
	public class ProcessEnvVars : Dictionary<string, string> {
	}

	///<summary>
	/// Information about the controlling TTY device. If set, the process belongs to an interactive session.
	///</summary>
	public class ProcessTty {

		///<summary>process.tty.char_device.major</summary>
		[DataMember(Name = "char_device.major")]
		public long? CharDeviceMajor { get; set; }

		///<summary>process.tty.char_device.minor</summary>
		[DataMember(Name = "char_device.minor")]
		public long? CharDeviceMinor { get; set; }
	}

	///<summary>
	/// A list of associated indicators objects enriching the event, and the context of that association/enrichment.
	///</summary>
	public class ThreatEnrichments {

		///<summary>threat.enrichments.indicator</summary>
		[DataMember(Name = "indicator")]
		public object Indicator { get; set; }

		///<summary>threat.enrichments.indicator.confidence</summary>
		[DataMember(Name = "indicator.confidence")]
		public string IndicatorConfidence { get; set; }

		///<summary>threat.enrichments.indicator.description</summary>
		[DataMember(Name = "indicator.description")]
		public string IndicatorDescription { get; set; }

		///<summary>threat.enrichments.indicator.email.address</summary>
		[DataMember(Name = "indicator.email.address")]
		public string IndicatorEmailAddress { get; set; }

		///<summary>threat.enrichments.indicator.first_seen</summary>
		[DataMember(Name = "indicator.first_seen")]
		public DateTimeOffset? IndicatorFirstSeen { get; set; }

		///<summary>threat.enrichments.indicator.ip</summary>
		[DataMember(Name = "indicator.ip")]
		public string IndicatorIp { get; set; }

		///<summary>threat.enrichments.indicator.last_seen</summary>
		[DataMember(Name = "indicator.last_seen")]
		public DateTimeOffset? IndicatorLastSeen { get; set; }

		///<summary>threat.enrichments.indicator.marking.tlp</summary>
		[DataMember(Name = "indicator.marking.tlp")]
		public string IndicatorMarkingTlp { get; set; }

		///<summary>threat.enrichments.indicator.modified_at</summary>
		[DataMember(Name = "indicator.modified_at")]
		public DateTimeOffset? IndicatorModifiedAt { get; set; }

		///<summary>threat.enrichments.indicator.port</summary>
		[DataMember(Name = "indicator.port")]
		public long? IndicatorPort { get; set; }

		///<summary>threat.enrichments.indicator.provider</summary>
		[DataMember(Name = "indicator.provider")]
		public string IndicatorProvider { get; set; }

		///<summary>threat.enrichments.indicator.reference</summary>
		[DataMember(Name = "indicator.reference")]
		public string IndicatorReference { get; set; }

		///<summary>threat.enrichments.indicator.scanner_stats</summary>
		[DataMember(Name = "indicator.scanner_stats")]
		public long? IndicatorScannerStats { get; set; }

		///<summary>threat.enrichments.indicator.sightings</summary>
		[DataMember(Name = "indicator.sightings")]
		public long? IndicatorSightings { get; set; }

		///<summary>threat.enrichments.indicator.type</summary>
		[DataMember(Name = "indicator.type")]
		public string IndicatorType { get; set; }

		///<summary>threat.enrichments.matched.atomic</summary>
		[DataMember(Name = "matched.atomic")]
		public string MatchedAtomic { get; set; }

		///<summary>threat.enrichments.matched.field</summary>
		[DataMember(Name = "matched.field")]
		public string MatchedField { get; set; }

		///<summary>threat.enrichments.matched.id</summary>
		[DataMember(Name = "matched.id")]
		public string MatchedId { get; set; }

		///<summary>threat.enrichments.matched.index</summary>
		[DataMember(Name = "matched.index")]
		public string MatchedIndex { get; set; }

		///<summary>threat.enrichments.matched.occurred</summary>
		[DataMember(Name = "matched.occurred")]
		public DateTimeOffset? MatchedOccurred { get; set; }

		///<summary>threat.enrichments.matched.type</summary>
		[DataMember(Name = "matched.type")]
		public string MatchedType { get; set; }

		///<summary>threat.enrichments.indicator.x509</summary>
		[DataMember(Name = "indicator.x509")]
		public X509 IndicatorX509 { get; set; }

		///<summary>threat.enrichments.indicator.as</summary>
		[DataMember(Name = "indicator.as")]
		public As IndicatorAs { get; set; }

		///<summary>threat.enrichments.indicator.file</summary>
		[DataMember(Name = "indicator.file")]
		public File IndicatorFile { get; set; }

		///<summary>threat.enrichments.indicator.geo</summary>
		[DataMember(Name = "indicator.geo")]
		public Geo IndicatorGeo { get; set; }

		///<summary>threat.enrichments.indicator.registry</summary>
		[DataMember(Name = "indicator.registry")]
		public Registry IndicatorRegistry { get; set; }

		///<summary>threat.enrichments.indicator.url</summary>
		[DataMember(Name = "indicator.url")]
		public Url IndicatorUrl { get; set; }
	}
}
