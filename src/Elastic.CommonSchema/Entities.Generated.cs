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
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema
{

	///<inheritdoc cref="CloudFieldSet"/>
	public class CloudOrigin : CloudFieldSet {
	}

	///<inheritdoc cref="CloudFieldSet"/>
	public class CloudTarget : CloudFieldSet {
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessParent : ProcessFieldSet {

		///<summary>
		/// <para><c>process.parent.group_leader</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("group_leader"), DataMember(Name = "group_leader")]
		public ProcessParentGroupLeader GroupLeader { get; set; }
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessEntryLeader : ProcessFieldSet {

		///<summary>
		/// <para><c>process.entry_leader.parent</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("parent"), DataMember(Name = "parent")]
		public ProcessEntryLeaderParent Parent { get; set; }
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessSessionLeader : ProcessFieldSet {

		///<summary>
		/// <para><c>process.session_leader.parent</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("parent"), DataMember(Name = "parent")]
		public ProcessSessionLeaderParent Parent { get; set; }
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessGroupLeader : ProcessFieldSet {
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessParentGroupLeader : ProcessFieldSet {
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessEntryLeaderParent : ProcessFieldSet {

		///<summary>
		/// <para><c>process.entry_leader.parent.session_leader</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("session_leader"), DataMember(Name = "session_leader")]
		public ProcessEntryLeaderParentSessionLeader SessionLeader { get; set; }
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessSessionLeaderParent : ProcessFieldSet {

		///<summary>
		/// <para><c>process.session_leader.parent.session_leader</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("session_leader"), DataMember(Name = "session_leader")]
		public ProcessSessionLeaderParentSessionLeader SessionLeader { get; set; }
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessEntryLeaderParentSessionLeader : ProcessFieldSet {
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessSessionLeaderParentSessionLeader : ProcessFieldSet {
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class ProcessPrevious : ProcessFieldSet {
	}

	///<inheritdoc cref="ServiceFieldSet"/>
	public class ServiceOrigin : ServiceFieldSet {
	}

	///<inheritdoc cref="ServiceFieldSet"/>
	public class ServiceTarget : ServiceFieldSet {
	}

	///<inheritdoc cref="UserFieldSet"/>
	public class UserTarget : UserFieldSet {
	}

	///<inheritdoc cref="UserFieldSet"/>
	public class UserEffective : UserFieldSet {
	}

	///<inheritdoc cref="UserFieldSet"/>
	public class UserChanges : UserFieldSet {
	}

	///<inheritdoc cref="AgentFieldSet"/>
	public class Agent : AgentFieldSet {
	}

	///<inheritdoc cref="AsFieldSet"/>
	public class As : AsFieldSet {
	}

	///<inheritdoc cref="ClientFieldSet"/>
	public class Client : ClientFieldSet {

		///<summary>
		/// <para><c>client.as</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("as"), DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>
		/// <para><c>client.geo</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("geo"), DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>
		/// <para><c>client.user</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("user"), DataMember(Name = "user")]
		public User User { get; set; }
	}

	///<inheritdoc cref="CloudFieldSet"/>
	public class Cloud : CloudFieldSet {

		///<summary>
		/// <para><c>cloud.origin</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("origin"), DataMember(Name = "origin")]
		public CloudOrigin Origin { get; set; }

		///<summary>
		/// <para><c>cloud.target</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("target"), DataMember(Name = "target")]
		public CloudTarget Target { get; set; }
	}

	///<inheritdoc cref="CodeSignatureFieldSet"/>
	public class CodeSignature : CodeSignatureFieldSet {
	}

	///<inheritdoc cref="ContainerFieldSet"/>
	public class Container : ContainerFieldSet {
	}

	///<inheritdoc cref="DataStreamFieldSet"/>
	public class DataStream : DataStreamFieldSet {
	}

	///<inheritdoc cref="DestinationFieldSet"/>
	public class Destination : DestinationFieldSet {

		///<summary>
		/// <para><c>destination.as</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("as"), DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>
		/// <para><c>destination.geo</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("geo"), DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>
		/// <para><c>destination.user</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("user"), DataMember(Name = "user")]
		public User User { get; set; }
	}

	///<inheritdoc cref="DeviceFieldSet"/>
	public class Device : DeviceFieldSet {
	}

	///<inheritdoc cref="DllFieldSet"/>
	public class Dll : DllFieldSet {

		///<summary>
		/// <para><c>dll.hash</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("hash"), DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		///<summary>
		/// <para><c>dll.pe</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("pe"), DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		///<summary>
		/// <para><c>dll.code_signature</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("code_signature"), DataMember(Name = "code_signature")]
		public CodeSignature CodeSignature { get; set; }
	}

	///<inheritdoc cref="DnsFieldSet"/>
	public class Dns : DnsFieldSet {
	}

	///<inheritdoc cref="EcsFieldSet"/>
	public partial class Ecs : EcsFieldSet {
	}

	///<inheritdoc cref="ElfFieldSet"/>
	public class Elf : ElfFieldSet {
	}

	///<inheritdoc cref="EmailFieldSet"/>
	public class Email : EmailFieldSet {
	}

	///<inheritdoc cref="ErrorFieldSet"/>
	public class Error : ErrorFieldSet {
	}

	///<inheritdoc cref="EventFieldSet"/>
	public class Event : EventFieldSet {
	}

	///<inheritdoc cref="FaasFieldSet"/>
	public class Faas : FaasFieldSet {
	}

	///<inheritdoc cref="FileFieldSet"/>
	public class File : FileFieldSet {

		///<summary>
		/// <para><c>file.hash</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("hash"), DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		///<summary>
		/// <para><c>file.pe</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("pe"), DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		///<summary>
		/// <para><c>file.x509</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("x509"), DataMember(Name = "x509")]
		public X509 X509 { get; set; }

		///<summary>
		/// <para><c>file.code_signature</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("code_signature"), DataMember(Name = "code_signature")]
		public CodeSignature CodeSignature { get; set; }

		///<summary>
		/// <para><c>file.elf</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("elf"), DataMember(Name = "elf")]
		public Elf Elf { get; set; }
	}

	///<inheritdoc cref="GeoFieldSet"/>
	public class Geo : GeoFieldSet {
	}

	///<inheritdoc cref="GroupFieldSet"/>
	public class Group : GroupFieldSet {
	}

	///<inheritdoc cref="HashFieldSet"/>
	public class Hash : HashFieldSet {
	}

	///<inheritdoc cref="HostFieldSet"/>
	public class Host : HostFieldSet {

		///<summary>
		/// <para><c>host.geo</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("geo"), DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>
		/// <para><c>host.os</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("os"), DataMember(Name = "os")]
		public Os Os { get; set; }

		///<summary>
		/// <para><c>host.risk</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("risk"), DataMember(Name = "risk")]
		public Risk Risk { get; set; }
	}

	///<inheritdoc cref="HttpFieldSet"/>
	public class Http : HttpFieldSet {
	}

	///<inheritdoc cref="InterfaceFieldSet"/>
	public class Interface : InterfaceFieldSet {
	}

	///<inheritdoc cref="LogFieldSet"/>
	public partial class Log : LogFieldSet {
	}

	///<inheritdoc cref="NetworkFieldSet"/>
	public class Network : NetworkFieldSet {

		///<summary>
		/// <para><c>network.vlan</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("vlan"), DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }
	}

	///<inheritdoc cref="ObserverFieldSet"/>
	public class Observer : ObserverFieldSet {

		///<summary>
		/// <para><c>observer.geo</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("geo"), DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>
		/// <para><c>observer.os</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("os"), DataMember(Name = "os")]
		public Os Os { get; set; }
	}

	///<inheritdoc cref="OrchestratorFieldSet"/>
	public class Orchestrator : OrchestratorFieldSet {
	}

	///<inheritdoc cref="OrganizationFieldSet"/>
	public class Organization : OrganizationFieldSet {
	}

	///<inheritdoc cref="OsFieldSet"/>
	public class Os : OsFieldSet {
	}

	///<inheritdoc cref="PackageFieldSet"/>
	public class Package : PackageFieldSet {
	}

	///<inheritdoc cref="PeFieldSet"/>
	public class Pe : PeFieldSet {
	}

	///<inheritdoc cref="ProcessFieldSet"/>
	public class Process : ProcessFieldSet {

		///<summary>
		/// <para><c>process.group</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("group"), DataMember(Name = "group")]
		public Group Group { get; set; }

		///<summary>
		/// <para><c>process.real_group</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("real_group"), DataMember(Name = "real_group")]
		public Group RealGroup { get; set; }

		///<summary>
		/// <para><c>process.saved_group</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("saved_group"), DataMember(Name = "saved_group")]
		public Group SavedGroup { get; set; }

		///<summary>
		/// <para><c>process.supplemental_groups</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("supplemental_groups"), DataMember(Name = "supplemental_groups")]
		public Group[] SupplementalGroups { get; set; }

		///<summary>
		/// <para><c>process.attested_groups</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("attested_groups"), DataMember(Name = "attested_groups")]
		public Group[] AttestedGroups { get; set; }

		///<summary>
		/// <para><c>process.hash</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("hash"), DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		///<summary>
		/// <para><c>process.pe</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("pe"), DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		///<summary>
		/// <para><c>process.code_signature</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("code_signature"), DataMember(Name = "code_signature")]
		public CodeSignature CodeSignature { get; set; }

		///<summary>
		/// <para><c>process.elf</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("elf"), DataMember(Name = "elf")]
		public Elf Elf { get; set; }

		///<summary>
		/// <para><c>process.entry_meta.source</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("entry_meta.source"), DataMember(Name = "entry_meta.source")]
		public Source EntryMetaSource { get; set; }

		///<summary>
		/// <para><c>process.user</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("user"), DataMember(Name = "user")]
		public User User { get; set; }

		///<summary>
		/// <para><c>process.saved_user</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("saved_user"), DataMember(Name = "saved_user")]
		public User SavedUser { get; set; }

		///<summary>
		/// <para><c>process.real_user</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("real_user"), DataMember(Name = "real_user")]
		public User RealUser { get; set; }

		///<summary>
		/// <para><c>process.attested_user</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("attested_user"), DataMember(Name = "attested_user")]
		public User AttestedUser { get; set; }

		///<summary>
		/// <para><c>process.parent</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("parent"), DataMember(Name = "parent")]
		public ProcessParent Parent { get; set; }

		///<summary>
		/// <para><c>process.entry_leader</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("entry_leader"), DataMember(Name = "entry_leader")]
		public ProcessEntryLeader EntryLeader { get; set; }

		///<summary>
		/// <para><c>process.session_leader</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("session_leader"), DataMember(Name = "session_leader")]
		public ProcessSessionLeader SessionLeader { get; set; }

		///<summary>
		/// <para><c>process.group_leader</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("group_leader"), DataMember(Name = "group_leader")]
		public ProcessGroupLeader GroupLeader { get; set; }

		///<summary>
		/// <para><c>process.previous</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("previous"), DataMember(Name = "previous")]
		public ProcessPrevious[] Previous { get; set; }
	}

	///<inheritdoc cref="RegistryFieldSet"/>
	public class Registry : RegistryFieldSet {
	}

	///<inheritdoc cref="RelatedFieldSet"/>
	public class Related : RelatedFieldSet {
	}

	///<inheritdoc cref="RiskFieldSet"/>
	public class Risk : RiskFieldSet {
	}

	///<inheritdoc cref="RuleFieldSet"/>
	public class Rule : RuleFieldSet {
	}

	///<inheritdoc cref="ServerFieldSet"/>
	public class Server : ServerFieldSet {

		///<summary>
		/// <para><c>server.as</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("as"), DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>
		/// <para><c>server.geo</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("geo"), DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>
		/// <para><c>server.user</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("user"), DataMember(Name = "user")]
		public User User { get; set; }
	}

	///<inheritdoc cref="ServiceFieldSet"/>
	public class Service : ServiceFieldSet {

		///<summary>
		/// <para><c>service.origin</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("origin"), DataMember(Name = "origin")]
		public ServiceOrigin Origin { get; set; }

		///<summary>
		/// <para><c>service.target</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("target"), DataMember(Name = "target")]
		public ServiceTarget Target { get; set; }
	}

	///<inheritdoc cref="SourceFieldSet"/>
	public class Source : SourceFieldSet {

		///<summary>
		/// <para><c>source.as</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("as"), DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>
		/// <para><c>source.geo</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("geo"), DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>
		/// <para><c>source.user</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("user"), DataMember(Name = "user")]
		public User User { get; set; }
	}

	///<inheritdoc cref="ThreatFieldSet"/>
	public class Threat : ThreatFieldSet {

		///<summary>
		/// <para><c>threat.indicator.x509</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("indicator.x509"), DataMember(Name = "indicator.x509")]
		public X509 IndicatorX509 { get; set; }

		///<summary>
		/// <para><c>threat.indicator.as</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("indicator.as"), DataMember(Name = "indicator.as")]
		public As IndicatorAs { get; set; }

		///<summary>
		/// <para><c>threat.indicator.file</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("indicator.file"), DataMember(Name = "indicator.file")]
		public File IndicatorFile { get; set; }

		///<summary>
		/// <para><c>threat.indicator.geo</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("indicator.geo"), DataMember(Name = "indicator.geo")]
		public Geo IndicatorGeo { get; set; }

		///<summary>
		/// <para><c>threat.indicator.registry</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("indicator.registry"), DataMember(Name = "indicator.registry")]
		public Registry IndicatorRegistry { get; set; }

		///<summary>
		/// <para><c>threat.indicator.url</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("indicator.url"), DataMember(Name = "indicator.url")]
		public Url IndicatorUrl { get; set; }
	}

	///<inheritdoc cref="TlsFieldSet"/>
	public class Tls : TlsFieldSet {

		///<summary>
		/// <para><c>tls.client.x509</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("client.x509"), DataMember(Name = "client.x509")]
		public X509 ClientX509 { get; set; }

		///<summary>
		/// <para><c>tls.server.x509</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("server.x509"), DataMember(Name = "server.x509")]
		public X509 ServerX509 { get; set; }
	}

	///<inheritdoc cref="UrlFieldSet"/>
	public class Url : UrlFieldSet {
	}

	///<inheritdoc cref="UserFieldSet"/>
	public class User : UserFieldSet {

		///<summary>
		/// <para><c>user.group</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("group"), DataMember(Name = "group")]
		public Group Group { get; set; }

		///<summary>
		/// <para><c>user.risk</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("risk"), DataMember(Name = "risk")]
		public Risk Risk { get; set; }

		///<summary>
		/// <para><c>user.target</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("target"), DataMember(Name = "target")]
		public UserTarget Target { get; set; }

		///<summary>
		/// <para><c>user.effective</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("effective"), DataMember(Name = "effective")]
		public UserEffective Effective { get; set; }

		///<summary>
		/// <para><c>user.changes</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("changes"), DataMember(Name = "changes")]
		public UserChanges Changes { get; set; }
	}

	///<inheritdoc cref="UserAgentFieldSet"/>
	public class UserAgent : UserAgentFieldSet {

		///<summary>
		/// <para><c>user_agent.os</c></para>
		/// <example></example>
		///</summary>
		[JsonPropertyName("os"), DataMember(Name = "os")]
		public Os Os { get; set; }
	}

	///<inheritdoc cref="VlanFieldSet"/>
	public class Vlan : VlanFieldSet {
	}

	///<inheritdoc cref="VulnerabilityFieldSet"/>
	public class Vulnerability : VulnerabilityFieldSet {
	}

	///<inheritdoc cref="X509FieldSet"/>
	public class X509 : X509FieldSet {
	}
}
