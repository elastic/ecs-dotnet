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

#nullable enable
namespace Elastic.CommonSchema
{

	///<summary> Interface for entities that can assign an IAs: Client, Destination, Server, Source</summary>
	public interface IAs {
		///<summary>as</summary>
		public As? As { get; set; }
	}

	///<summary> Interface for entities that can assign an IGeo: Client, Destination, Host, Observer, Server, Source</summary>
	public interface IGeo {
		///<summary>geo</summary>
		public Geo? Geo { get; set; }
	}

	///<summary> Interface for entities that can assign an IUser: Client, Destination, Process, Server, Source</summary>
	public interface IUser {
		///<summary>user</summary>
		public User? User { get; set; }
	}

	///<summary> Interface for entities that can assign an ICloudOrigin: Cloud</summary>
	public interface ICloudOrigin {
		///<summary>origin</summary>
		public CloudOrigin? Origin { get; set; }
	}

	///<summary> Interface for entities that can assign an ICloudTarget: Cloud</summary>
	public interface ICloudTarget {
		///<summary>target</summary>
		public CloudTarget? Target { get; set; }
	}

	///<summary> Interface for entities that can assign an IHash: Dll, File, Process</summary>
	public interface IHash {
		///<summary>hash</summary>
		public Hash? Hash { get; set; }
	}

	///<summary> Interface for entities that can assign an IPe: Dll, File, Process</summary>
	public interface IPe {
		///<summary>pe</summary>
		public Pe? Pe { get; set; }
	}

	///<summary> Interface for entities that can assign an ICodeSignature: Dll, File, Process</summary>
	public interface ICodeSignature {
		///<summary>code_signature</summary>
		public CodeSignature? CodeSignature { get; set; }
	}

	///<summary> Interface for entities that can assign an IX509: File</summary>
	public interface IX509 {
		///<summary>x509</summary>
		public X509? X509 { get; set; }
	}

	///<summary> Interface for entities that can assign an IElf: File, Process</summary>
	public interface IElf {
		///<summary>elf</summary>
		public Elf? Elf { get; set; }
	}

	///<summary> Interface for entities that can assign an IMacho: File, Process</summary>
	public interface IMacho {
		///<summary>macho</summary>
		public Macho? Macho { get; set; }
	}

	///<summary> Interface for entities that can assign an IOs: Host, Observer, UserAgent</summary>
	public interface IOs {
		///<summary>os</summary>
		public Os? Os { get; set; }
	}

	///<summary> Interface for entities that can assign an IRisk: Host, User</summary>
	public interface IRisk {
		///<summary>risk</summary>
		public Risk? Risk { get; set; }
	}

	///<summary> Interface for entities that can assign an IVlan: Network</summary>
	public interface IVlan {
		///<summary>vlan</summary>
		public Vlan? Vlan { get; set; }
	}

	///<summary> Interface for entities that can assign an IGroup: Process, User</summary>
	public interface IGroup {
		///<summary>group</summary>
		public Group? Group { get; set; }
	}

	///<summary> Interface for entities that can assign an IRealGroup: Process</summary>
	public interface IRealGroup {
		///<summary>real_group</summary>
		public Group? RealGroup { get; set; }
	}

	///<summary> Interface for entities that can assign an ISavedGroup: Process</summary>
	public interface ISavedGroup {
		///<summary>saved_group</summary>
		public Group? SavedGroup { get; set; }
	}

	///<summary> Interface for entities that can assign an ISupplementalGroups: Process</summary>
	public interface ISupplementalGroups {
		///<summary>supplemental_groups</summary>
		public Group[]? SupplementalGroups { get; set; }
	}

	///<summary> Interface for entities that can assign an IAttestedGroups: Process</summary>
	public interface IAttestedGroups {
		///<summary>attested_groups</summary>
		public Group[]? AttestedGroups { get; set; }
	}

	///<summary> Interface for entities that can assign an IEntryMetaSource: Process</summary>
	public interface IEntryMetaSource {
		///<summary>entry_meta.source</summary>
		public Source? EntryMetaSource { get; set; }
	}

	///<summary> Interface for entities that can assign an ISavedUser: Process</summary>
	public interface ISavedUser {
		///<summary>saved_user</summary>
		public User? SavedUser { get; set; }
	}

	///<summary> Interface for entities that can assign an IRealUser: Process</summary>
	public interface IRealUser {
		///<summary>real_user</summary>
		public User? RealUser { get; set; }
	}

	///<summary> Interface for entities that can assign an IAttestedUser: Process</summary>
	public interface IAttestedUser {
		///<summary>attested_user</summary>
		public User? AttestedUser { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessParent: Process</summary>
	public interface IProcessParent {
		///<summary>parent</summary>
		public ProcessParent? Parent { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessEntryLeader: Process</summary>
	public interface IProcessEntryLeader {
		///<summary>entry_leader</summary>
		public ProcessEntryLeader? EntryLeader { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessSessionLeader: Process</summary>
	public interface IProcessSessionLeader {
		///<summary>session_leader</summary>
		public ProcessSessionLeader? SessionLeader { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessGroupLeader: Process</summary>
	public interface IProcessGroupLeader {
		///<summary>group_leader</summary>
		public ProcessGroupLeader? GroupLeader { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessPrevious: Process</summary>
	public interface IProcessPrevious {
		///<summary>previous</summary>
		public ProcessPrevious[]? Previous { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessResponsible: Process</summary>
	public interface IProcessResponsible {
		///<summary>responsible</summary>
		public ProcessResponsible? Responsible { get; set; }
	}

	///<summary> Interface for entities that can assign an IServiceOrigin: Service</summary>
	public interface IServiceOrigin {
		///<summary>origin</summary>
		public ServiceOrigin? Origin { get; set; }
	}

	///<summary> Interface for entities that can assign an IServiceTarget: Service</summary>
	public interface IServiceTarget {
		///<summary>target</summary>
		public ServiceTarget? Target { get; set; }
	}

	///<summary> Interface for entities that can assign an IIndicatorX509: Threat</summary>
	public interface IIndicatorX509 {
		///<summary>indicator.x509</summary>
		public X509? IndicatorX509 { get; set; }
	}

	///<summary> Interface for entities that can assign an IIndicatorAs: Threat</summary>
	public interface IIndicatorAs {
		///<summary>indicator.as</summary>
		public As? IndicatorAs { get; set; }
	}

	///<summary> Interface for entities that can assign an IIndicatorFile: Threat</summary>
	public interface IIndicatorFile {
		///<summary>indicator.file</summary>
		public File? IndicatorFile { get; set; }
	}

	///<summary> Interface for entities that can assign an IIndicatorGeo: Threat</summary>
	public interface IIndicatorGeo {
		///<summary>indicator.geo</summary>
		public Geo? IndicatorGeo { get; set; }
	}

	///<summary> Interface for entities that can assign an IIndicatorRegistry: Threat</summary>
	public interface IIndicatorRegistry {
		///<summary>indicator.registry</summary>
		public Registry? IndicatorRegistry { get; set; }
	}

	///<summary> Interface for entities that can assign an IIndicatorUrl: Threat</summary>
	public interface IIndicatorUrl {
		///<summary>indicator.url</summary>
		public Url? IndicatorUrl { get; set; }
	}

	///<summary> Interface for entities that can assign an IClientX509: Tls</summary>
	public interface IClientX509 {
		///<summary>client.x509</summary>
		public X509? ClientX509 { get; set; }
	}

	///<summary> Interface for entities that can assign an IServerX509: Tls</summary>
	public interface IServerX509 {
		///<summary>server.x509</summary>
		public X509? ServerX509 { get; set; }
	}

	///<summary> Interface for entities that can assign an IUserTarget: User</summary>
	public interface IUserTarget {
		///<summary>target</summary>
		public UserTarget? Target { get; set; }
	}

	///<summary> Interface for entities that can assign an IUserEffective: User</summary>
	public interface IUserEffective {
		///<summary>effective</summary>
		public UserEffective? Effective { get; set; }
	}

	///<summary> Interface for entities that can assign an IUserChanges: User</summary>
	public interface IUserChanges {
		///<summary>changes</summary>
		public UserChanges? Changes { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessParentGroupLeader: ProcessParent</summary>
	public interface IProcessParentGroupLeader {
		///<summary>group_leader</summary>
		public ProcessParentGroupLeader? GroupLeader { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessEntryLeaderParent: ProcessEntryLeader</summary>
	public interface IProcessEntryLeaderParent {
		///<summary>parent</summary>
		public ProcessEntryLeaderParent? Parent { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessSessionLeaderParent: ProcessSessionLeader</summary>
	public interface IProcessSessionLeaderParent {
		///<summary>parent</summary>
		public ProcessSessionLeaderParent? Parent { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessEntryLeaderParentSessionLeader: ProcessEntryLeaderParent</summary>
	public interface IProcessEntryLeaderParentSessionLeader {
		///<summary>session_leader</summary>
		public ProcessEntryLeaderParentSessionLeader? SessionLeader { get; set; }
	}

	///<summary> Interface for entities that can assign an IProcessSessionLeaderParentSessionLeader: ProcessSessionLeaderParent</summary>
	public interface IProcessSessionLeaderParentSessionLeader {
		///<summary>session_leader</summary>
		public ProcessSessionLeaderParentSessionLeader? SessionLeader { get; set; }
	}
}
