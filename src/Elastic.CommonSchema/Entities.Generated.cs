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

	///<inheritdoc cref="CloudBase"/>
	public class CloudOrigin : CloudBase {
	}

	///<inheritdoc cref="CloudBase"/>
	public class CloudTarget : CloudBase {
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessParent : ProcessBase {

		///<summary>process.parent.group_leader</summary>
		[DataMember(Name = "group_leader")]
		public ProcessParentGroupLeader GroupLeader { get; set; }
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessEntryLeader : ProcessBase {

		///<summary>process.entry_leader.parent</summary>
		[DataMember(Name = "parent")]
		public ProcessEntryLeaderParent Parent { get; set; }
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessSessionLeader : ProcessBase {

		///<summary>process.session_leader.parent</summary>
		[DataMember(Name = "parent")]
		public ProcessSessionLeaderParent Parent { get; set; }
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessGroupLeader : ProcessBase {
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessParentGroupLeader : ProcessBase {
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessEntryLeaderParent : ProcessBase {

		///<summary>process.entry_leader.parent.session_leader</summary>
		[DataMember(Name = "session_leader")]
		public ProcessEntryLeaderParentSessionLeader SessionLeader { get; set; }
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessSessionLeaderParent : ProcessBase {

		///<summary>process.session_leader.parent.session_leader</summary>
		[DataMember(Name = "session_leader")]
		public ProcessSessionLeaderParentSessionLeader SessionLeader { get; set; }
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessEntryLeaderParentSessionLeader : ProcessBase {
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessSessionLeaderParentSessionLeader : ProcessBase {
	}

	///<inheritdoc cref="ProcessBase"/>
	public class ProcessPrevious : ProcessBase {
	}

	///<inheritdoc cref="ServiceBase"/>
	public class ServiceOrigin : ServiceBase {
	}

	///<inheritdoc cref="ServiceBase"/>
	public class ServiceTarget : ServiceBase {
	}

	///<inheritdoc cref="UserBase"/>
	public class UserTarget : UserBase {
	}

	///<inheritdoc cref="UserBase"/>
	public class UserEffective : UserBase {
	}

	///<inheritdoc cref="UserBase"/>
	public class UserChanges : UserBase {
	}

	///<inheritdoc cref="AgentBase"/>
	public class Agent : AgentBase {
	}

	///<inheritdoc cref="AsBase"/>
	public class As : AsBase {
	}

	///<inheritdoc cref="ClientBase"/>
	public class Client : ClientBase {

		///<summary>client.as</summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>client.geo</summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>client.user</summary>
		[DataMember(Name = "user")]
		public User User { get; set; }
	}

	///<inheritdoc cref="CloudBase"/>
	public class Cloud : CloudBase {

		///<summary>cloud.origin</summary>
		[DataMember(Name = "origin")]
		public CloudOrigin Origin { get; set; }

		///<summary>cloud.target</summary>
		[DataMember(Name = "target")]
		public CloudTarget Target { get; set; }
	}

	///<inheritdoc cref="CodeSignatureBase"/>
	public class CodeSignature : CodeSignatureBase {
	}

	///<inheritdoc cref="ContainerBase"/>
	public class Container : ContainerBase {
	}

	///<inheritdoc cref="DataStreamBase"/>
	public class DataStream : DataStreamBase {
	}

	///<inheritdoc cref="DestinationBase"/>
	public class Destination : DestinationBase {

		///<summary>destination.as</summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>destination.geo</summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>destination.user</summary>
		[DataMember(Name = "user")]
		public User User { get; set; }
	}

	///<inheritdoc cref="DllBase"/>
	public class Dll : DllBase {

		///<summary>dll.hash</summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		///<summary>dll.pe</summary>
		[DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		///<summary>dll.code_signature</summary>
		[DataMember(Name = "code_signature")]
		public CodeSignature CodeSignature { get; set; }
	}

	///<inheritdoc cref="DnsBase"/>
	public class Dns : DnsBase {
	}

	///<inheritdoc cref="EcsBase"/>
	public class Ecs : EcsBase {
	}

	///<inheritdoc cref="ElfBase"/>
	public class Elf : ElfBase {
	}

	///<inheritdoc cref="EmailBase"/>
	public class Email : EmailBase {
	}

	///<inheritdoc cref="ErrorBase"/>
	public class Error : ErrorBase {
	}

	///<inheritdoc cref="EventBase"/>
	public class Event : EventBase {
	}

	///<inheritdoc cref="FaasBase"/>
	public class Faas : FaasBase {
	}

	///<inheritdoc cref="FileBase"/>
	public class File : FileBase {

		///<summary>file.hash</summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		///<summary>file.pe</summary>
		[DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		///<summary>file.x509</summary>
		[DataMember(Name = "x509")]
		public X509 X509 { get; set; }

		///<summary>file.code_signature</summary>
		[DataMember(Name = "code_signature")]
		public CodeSignature CodeSignature { get; set; }

		///<summary>file.elf</summary>
		[DataMember(Name = "elf")]
		public Elf Elf { get; set; }
	}

	///<inheritdoc cref="GeoBase"/>
	public class Geo : GeoBase {
	}

	///<inheritdoc cref="GroupBase"/>
	public class Group : GroupBase {
	}

	///<inheritdoc cref="HashBase"/>
	public class Hash : HashBase {
	}

	///<inheritdoc cref="HostBase"/>
	public class Host : HostBase {

		///<summary>host.geo</summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>host.os</summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }
	}

	///<inheritdoc cref="HttpBase"/>
	public class Http : HttpBase {
	}

	///<inheritdoc cref="InterfaceBase"/>
	public class Interface : InterfaceBase {
	}

	///<inheritdoc cref="LogBase"/>
	public partial class Log : LogBase {
	}

	///<inheritdoc cref="NetworkBase"/>
	public class Network : NetworkBase {

		///<summary>network.vlan</summary>
		[DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }
	}

	///<inheritdoc cref="ObserverBase"/>
	public class Observer : ObserverBase {

		///<summary>observer.geo</summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>observer.os</summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }
	}

	///<inheritdoc cref="OrchestratorBase"/>
	public class Orchestrator : OrchestratorBase {
	}

	///<inheritdoc cref="OrganizationBase"/>
	public class Organization : OrganizationBase {
	}

	///<inheritdoc cref="OsBase"/>
	public class Os : OsBase {
	}

	///<inheritdoc cref="PackageBase"/>
	public class Package : PackageBase {
	}

	///<inheritdoc cref="PeBase"/>
	public class Pe : PeBase {
	}

	///<inheritdoc cref="ProcessBase"/>
	public class Process : ProcessBase {

		///<summary>process.group</summary>
		[DataMember(Name = "group")]
		public Group Group { get; set; }

		///<summary>process.real_group</summary>
		[DataMember(Name = "real_group")]
		public Group RealGroup { get; set; }

		///<summary>process.saved_group</summary>
		[DataMember(Name = "saved_group")]
		public Group SavedGroup { get; set; }

		///<summary>process.supplemental_groups</summary>
		[DataMember(Name = "supplemental_groups")]
		public Group SupplementalGroups { get; set; }

		///<summary>process.hash</summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		///<summary>process.pe</summary>
		[DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		///<summary>process.code_signature</summary>
		[DataMember(Name = "code_signature")]
		public CodeSignature CodeSignature { get; set; }

		///<summary>process.elf</summary>
		[DataMember(Name = "elf")]
		public Elf Elf { get; set; }

		///<summary>process.entry_meta.source</summary>
		[DataMember(Name = "entry_meta.source")]
		public Source EntryMetaSource { get; set; }

		///<summary>process.user</summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		///<summary>process.saved_user</summary>
		[DataMember(Name = "saved_user")]
		public User SavedUser { get; set; }

		///<summary>process.real_user</summary>
		[DataMember(Name = "real_user")]
		public User RealUser { get; set; }

		///<summary>process.parent</summary>
		[DataMember(Name = "parent")]
		public ProcessParent Parent { get; set; }

		///<summary>process.entry_leader</summary>
		[DataMember(Name = "entry_leader")]
		public ProcessEntryLeader EntryLeader { get; set; }

		///<summary>process.session_leader</summary>
		[DataMember(Name = "session_leader")]
		public ProcessSessionLeader SessionLeader { get; set; }

		///<summary>process.group_leader</summary>
		[DataMember(Name = "group_leader")]
		public ProcessGroupLeader GroupLeader { get; set; }

		///<summary>process.previous</summary>
		[DataMember(Name = "previous")]
		public ProcessPrevious Previous { get; set; }
	}

	///<inheritdoc cref="RegistryBase"/>
	public class Registry : RegistryBase {
	}

	///<inheritdoc cref="RelatedBase"/>
	public class Related : RelatedBase {
	}

	///<inheritdoc cref="RuleBase"/>
	public class Rule : RuleBase {
	}

	///<inheritdoc cref="ServerBase"/>
	public class Server : ServerBase {

		///<summary>server.as</summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>server.geo</summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>server.user</summary>
		[DataMember(Name = "user")]
		public User User { get; set; }
	}

	///<inheritdoc cref="ServiceBase"/>
	public class Service : ServiceBase {

		///<summary>service.origin</summary>
		[DataMember(Name = "origin")]
		public ServiceOrigin Origin { get; set; }

		///<summary>service.target</summary>
		[DataMember(Name = "target")]
		public ServiceTarget Target { get; set; }
	}

	///<inheritdoc cref="SourceBase"/>
	public class Source : SourceBase {

		///<summary>source.as</summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>source.geo</summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>source.user</summary>
		[DataMember(Name = "user")]
		public User User { get; set; }
	}

	///<inheritdoc cref="ThreatBase"/>
	public class Threat : ThreatBase {

		///<summary>threat.indicator.x509</summary>
		[DataMember(Name = "indicator.x509")]
		public X509 IndicatorX509 { get; set; }

		///<summary>threat.indicator.as</summary>
		[DataMember(Name = "indicator.as")]
		public As IndicatorAs { get; set; }

		///<summary>threat.indicator.file</summary>
		[DataMember(Name = "indicator.file")]
		public File IndicatorFile { get; set; }

		///<summary>threat.indicator.geo</summary>
		[DataMember(Name = "indicator.geo")]
		public Geo IndicatorGeo { get; set; }

		///<summary>threat.indicator.registry</summary>
		[DataMember(Name = "indicator.registry")]
		public Registry IndicatorRegistry { get; set; }

		///<summary>threat.indicator.url</summary>
		[DataMember(Name = "indicator.url")]
		public Url IndicatorUrl { get; set; }
	}

	///<inheritdoc cref="TlsBase"/>
	public class Tls : TlsBase {

		///<summary>tls.client.x509</summary>
		[DataMember(Name = "client.x509")]
		public X509 ClientX509 { get; set; }

		///<summary>tls.server.x509</summary>
		[DataMember(Name = "server.x509")]
		public X509 ServerX509 { get; set; }
	}

	///<inheritdoc cref="UrlBase"/>
	public class Url : UrlBase {
	}

	///<inheritdoc cref="UserBase"/>
	public class User : UserBase {

		///<summary>user.group</summary>
		[DataMember(Name = "group")]
		public Group Group { get; set; }

		///<summary>user.target</summary>
		[DataMember(Name = "target")]
		public UserTarget Target { get; set; }

		///<summary>user.effective</summary>
		[DataMember(Name = "effective")]
		public UserEffective Effective { get; set; }

		///<summary>user.changes</summary>
		[DataMember(Name = "changes")]
		public UserChanges Changes { get; set; }
	}

	///<inheritdoc cref="UserAgentBase"/>
	public class UserAgent : UserAgentBase {

		///<summary>user_agent.os</summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }
	}

	///<inheritdoc cref="VlanBase"/>
	public class Vlan : VlanBase {
	}

	///<inheritdoc cref="VulnerabilityBase"/>
	public class Vulnerability : VulnerabilityBase {
	}

	///<inheritdoc cref="X509Base"/>
	public class X509 : X509Base {
	}
}
