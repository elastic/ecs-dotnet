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
using Elastic.CommonSchema.Serialization;
using static Elastic.CommonSchema.PropDispatch;

namespace Elastic.CommonSchema
{
	///<inheritdoc cref="BaseFieldSet"/>
	public partial class EcsDocument : BaseFieldSet 
	{
		/// <summary>
		/// Set ECS fields by name on <see cref="EcsDocument"/>.
		/// <para>Allows valid ECS fields to be set from log message templates.</para>
		/// Given <paramref name="value"/>'s type matches the corresponding property on <see cref="EcsDocument"/>
		/// <para></para>
		/// <para>See <see cref="LogTemplateProperties"/> for a strongly typed list of valid ECS log template properties</para>
		/// <para>If its not a supported ECS log template property or using the wrong type:</para>
		/// <list type="bullet">
		/// <item>Assigns strings to <see cref="BaseFieldSet.Labels"/> on <see cref="EcsDocument"/></item>
		/// <item>Assigns everything else to <see cref="EcsDocument.Metadata"/> on <see cref="EcsDocument"/></item>
		/// </list>
		/// </summary>
		/// <param name="path">Either a supported ECS Log Template property or any key</param>
		/// <param name="value">The value to persist</param>
		public void AssignField(string path, object value)
		{
			var assigned = LogTemplateProperties.All.Contains(path) && TrySet(this, path, value);
			if (!assigned) 
				SetMetaOrLabel(this, path, value);
		}
	}
	internal static partial class PropDispatch
	{
		public static bool TrySet(EcsDocument document, string path, object value) 
		{
			switch (path) 
			{
				case "@timestamp":
				case "Timestamp":
				case "message":
				case "Message":
				case "span.id":
				case "SpanId":
				case "trace.id":
				case "TraceId":
				case "transaction.id":
				case "TransactionId":
					return TrySetEcsDocument(document, path, value);
				case "agent.build.original":
				case "AgentBuildOriginal":
				case "agent.ephemeral_id":
				case "AgentEphemeralId":
				case "agent.id":
				case "AgentId":
				case "agent.name":
				case "AgentName":
				case "agent.type":
				case "AgentType":
				case "agent.version":
				case "AgentVersion":
					return TrySetAgent(document, path, value);
				case "as.number":
				case "AsNumber":
				case "as.organization.name":
				case "AsOrganizationName":
					return TrySetAs(document, path, value);
				case "client.address":
				case "ClientAddress":
				case "client.bytes":
				case "ClientBytes":
				case "client.domain":
				case "ClientDomain":
				case "client.ip":
				case "ClientIp":
				case "client.mac":
				case "ClientMac":
				case "client.nat.ip":
				case "ClientNatIp":
				case "client.nat.port":
				case "ClientNatPort":
				case "client.packets":
				case "ClientPackets":
				case "client.port":
				case "ClientPort":
				case "client.registered_domain":
				case "ClientRegisteredDomain":
				case "client.subdomain":
				case "ClientSubdomain":
				case "client.top_level_domain":
				case "ClientTopLevelDomain":
					return TrySetClient(document, path, value);
				case "cloud.account.id":
				case "CloudAccountId":
				case "cloud.account.name":
				case "CloudAccountName":
				case "cloud.availability_zone":
				case "CloudAvailabilityZone":
				case "cloud.instance.id":
				case "CloudInstanceId":
				case "cloud.instance.name":
				case "CloudInstanceName":
				case "cloud.machine.type":
				case "CloudMachineType":
				case "cloud.project.id":
				case "CloudProjectId":
				case "cloud.project.name":
				case "CloudProjectName":
				case "cloud.provider":
				case "CloudProvider":
				case "cloud.region":
				case "CloudRegion":
				case "cloud.service.name":
				case "CloudServiceName":
					return TrySetCloud(document, path, value);
				case "code_signature.digest_algorithm":
				case "CodeSignatureDigestAlgorithm":
				case "code_signature.exists":
				case "CodeSignatureExists":
				case "code_signature.signing_id":
				case "CodeSignatureSigningId":
				case "code_signature.status":
				case "CodeSignatureStatus":
				case "code_signature.subject_name":
				case "CodeSignatureSubjectName":
				case "code_signature.team_id":
				case "CodeSignatureTeamId":
				case "code_signature.timestamp":
				case "CodeSignatureTimestamp":
				case "code_signature.trusted":
				case "CodeSignatureTrusted":
				case "code_signature.valid":
				case "CodeSignatureValid":
					return TrySetCodeSignature(document, path, value);
				case "container.cpu.usage":
				case "ContainerCpuUsage":
				case "container.disk.read.bytes":
				case "ContainerDiskReadBytes":
				case "container.disk.write.bytes":
				case "ContainerDiskWriteBytes":
				case "container.id":
				case "ContainerId":
				case "container.image.name":
				case "ContainerImageName":
				case "container.memory.usage":
				case "ContainerMemoryUsage":
				case "container.name":
				case "ContainerName":
				case "container.network.egress.bytes":
				case "ContainerNetworkEgressBytes":
				case "container.network.ingress.bytes":
				case "ContainerNetworkIngressBytes":
				case "container.runtime":
				case "ContainerRuntime":
					return TrySetContainer(document, path, value);
				case "data_stream.dataset":
				case "DataStreamDataset":
				case "data_stream.namespace":
				case "DataStreamNamespace":
				case "data_stream.type":
				case "DataStreamType":
					return TrySetDataStream(document, path, value);
				case "destination.address":
				case "DestinationAddress":
				case "destination.bytes":
				case "DestinationBytes":
				case "destination.domain":
				case "DestinationDomain":
				case "destination.ip":
				case "DestinationIp":
				case "destination.mac":
				case "DestinationMac":
				case "destination.nat.ip":
				case "DestinationNatIp":
				case "destination.nat.port":
				case "DestinationNatPort":
				case "destination.packets":
				case "DestinationPackets":
				case "destination.port":
				case "DestinationPort":
				case "destination.registered_domain":
				case "DestinationRegisteredDomain":
				case "destination.subdomain":
				case "DestinationSubdomain":
				case "destination.top_level_domain":
				case "DestinationTopLevelDomain":
					return TrySetDestination(document, path, value);
				case "dll.name":
				case "DllName":
				case "dll.path":
				case "DllPath":
					return TrySetDll(document, path, value);
				case "dns.id":
				case "DnsId":
				case "dns.op_code":
				case "DnsOpCode":
				case "dns.question.class":
				case "DnsQuestionClass":
				case "dns.question.name":
				case "DnsQuestionName":
				case "dns.question.registered_domain":
				case "DnsQuestionRegisteredDomain":
				case "dns.question.subdomain":
				case "DnsQuestionSubdomain":
				case "dns.question.top_level_domain":
				case "DnsQuestionTopLevelDomain":
				case "dns.question.type":
				case "DnsQuestionType":
				case "dns.response_code":
				case "DnsResponseCode":
				case "dns.type":
				case "DnsType":
					return TrySetDns(document, path, value);
				case "ecs.version":
				case "EcsVersion":
					return TrySetEcs(document, path, value);
				case "elf.architecture":
				case "ElfArchitecture":
				case "elf.byte_order":
				case "ElfByteOrder":
				case "elf.cpu_type":
				case "ElfCpuType":
				case "elf.creation_date":
				case "ElfCreationDate":
				case "elf.header.abi_version":
				case "ElfHeaderAbiVersion":
				case "elf.header.class":
				case "ElfHeaderClass":
				case "elf.header.data":
				case "ElfHeaderData":
				case "elf.header.entrypoint":
				case "ElfHeaderEntrypoint":
				case "elf.header.object_version":
				case "ElfHeaderObjectVersion":
				case "elf.header.os_abi":
				case "ElfHeaderOsAbi":
				case "elf.header.type":
				case "ElfHeaderType":
				case "elf.header.version":
				case "ElfHeaderVersion":
				case "elf.telfhash":
				case "ElfTelfhash":
					return TrySetElf(document, path, value);
				case "email.content_type":
				case "EmailContentType":
				case "email.delivery_timestamp":
				case "EmailDeliveryTimestamp":
				case "email.direction":
				case "EmailDirection":
				case "email.local_id":
				case "EmailLocalId":
				case "email.message_id":
				case "EmailMessageId":
				case "email.origination_timestamp":
				case "EmailOriginationTimestamp":
				case "email.sender.address":
				case "EmailSenderAddress":
				case "email.subject":
				case "EmailSubject":
				case "email.x_mailer":
				case "EmailXMailer":
					return TrySetEmail(document, path, value);
				case "error.code":
				case "ErrorCode":
				case "error.id":
				case "ErrorId":
				case "error.message":
				case "ErrorMessage":
				case "error.stack_trace":
				case "ErrorStackTrace":
				case "error.type":
				case "ErrorType":
					return TrySetError(document, path, value);
				case "event.action":
				case "EventAction":
				case "event.agent_id_status":
				case "EventAgentIdStatus":
				case "event.code":
				case "EventCode":
				case "event.created":
				case "EventCreated":
				case "event.dataset":
				case "EventDataset":
				case "event.duration":
				case "EventDuration":
				case "event.end":
				case "EventEnd":
				case "event.hash":
				case "EventHash":
				case "event.id":
				case "EventId":
				case "event.ingested":
				case "EventIngested":
				case "event.kind":
				case "EventKind":
				case "event.module":
				case "EventModule":
				case "event.original":
				case "EventOriginal":
				case "event.outcome":
				case "EventOutcome":
				case "event.provider":
				case "EventProvider":
				case "event.reason":
				case "EventReason":
				case "event.reference":
				case "EventReference":
				case "event.risk_score":
				case "EventRiskScore":
				case "event.risk_score_norm":
				case "EventRiskScoreNorm":
				case "event.sequence":
				case "EventSequence":
				case "event.severity":
				case "EventSeverity":
				case "event.start":
				case "EventStart":
				case "event.timezone":
				case "EventTimezone":
				case "event.url":
				case "EventUrl":
					return TrySetEvent(document, path, value);
				case "faas.coldstart":
				case "FaasColdstart":
				case "faas.execution":
				case "FaasExecution":
				case "faas.id":
				case "FaasId":
				case "faas.name":
				case "FaasName":
				case "faas.version":
				case "FaasVersion":
					return TrySetFaas(document, path, value);
				case "file.accessed":
				case "FileAccessed":
				case "file.created":
				case "FileCreated":
				case "file.ctime":
				case "FileCtime":
				case "file.device":
				case "FileDevice":
				case "file.directory":
				case "FileDirectory":
				case "file.drive_letter":
				case "FileDriveLetter":
				case "file.extension":
				case "FileExtension":
				case "file.fork_name":
				case "FileForkName":
				case "file.gid":
				case "FileGid":
				case "file.group":
				case "FileGroup":
				case "file.inode":
				case "FileInode":
				case "file.mime_type":
				case "FileMimeType":
				case "file.mode":
				case "FileMode":
				case "file.mtime":
				case "FileMtime":
				case "file.name":
				case "FileName":
				case "file.owner":
				case "FileOwner":
				case "file.path":
				case "FilePath":
				case "file.size":
				case "FileSize":
				case "file.target_path":
				case "FileTargetPath":
				case "file.type":
				case "FileType":
				case "file.uid":
				case "FileUid":
					return TrySetFile(document, path, value);
				case "geo.city_name":
				case "GeoCityName":
				case "geo.continent_code":
				case "GeoContinentCode":
				case "geo.continent_name":
				case "GeoContinentName":
				case "geo.country_iso_code":
				case "GeoCountryIsoCode":
				case "geo.country_name":
				case "GeoCountryName":
				case "geo.name":
				case "GeoName":
				case "geo.postal_code":
				case "GeoPostalCode":
				case "geo.region_iso_code":
				case "GeoRegionIsoCode":
				case "geo.region_name":
				case "GeoRegionName":
				case "geo.timezone":
				case "GeoTimezone":
					return TrySetGeo(document, path, value);
				case "group.domain":
				case "GroupDomain":
				case "group.id":
				case "GroupId":
				case "group.name":
				case "GroupName":
					return TrySetGroup(document, path, value);
				case "hash.md5":
				case "HashMd5":
				case "hash.sha1":
				case "HashSha1":
				case "hash.sha256":
				case "HashSha256":
				case "hash.sha384":
				case "HashSha384":
				case "hash.sha512":
				case "HashSha512":
				case "hash.ssdeep":
				case "HashSsdeep":
				case "hash.tlsh":
				case "HashTlsh":
					return TrySetHash(document, path, value);
				case "host.architecture":
				case "HostArchitecture":
				case "host.boot.id":
				case "HostBootId":
				case "host.cpu.usage":
				case "HostCpuUsage":
				case "host.disk.read.bytes":
				case "HostDiskReadBytes":
				case "host.disk.write.bytes":
				case "HostDiskWriteBytes":
				case "host.domain":
				case "HostDomain":
				case "host.hostname":
				case "HostHostname":
				case "host.id":
				case "HostId":
				case "host.name":
				case "HostName":
				case "host.network.egress.bytes":
				case "HostNetworkEgressBytes":
				case "host.network.egress.packets":
				case "HostNetworkEgressPackets":
				case "host.network.ingress.bytes":
				case "HostNetworkIngressBytes":
				case "host.network.ingress.packets":
				case "HostNetworkIngressPackets":
				case "host.pid_ns_ino":
				case "HostPidNsIno":
				case "host.type":
				case "HostType":
				case "host.uptime":
				case "HostUptime":
					return TrySetHost(document, path, value);
				case "http.request.body.bytes":
				case "HttpRequestBodyBytes":
				case "http.request.body.content":
				case "HttpRequestBodyContent":
				case "http.request.bytes":
				case "HttpRequestBytes":
				case "http.request.id":
				case "HttpRequestId":
				case "http.request.method":
				case "HttpRequestMethod":
				case "http.request.mime_type":
				case "HttpRequestMimeType":
				case "http.request.referrer":
				case "HttpRequestReferrer":
				case "http.response.body.bytes":
				case "HttpResponseBodyBytes":
				case "http.response.body.content":
				case "HttpResponseBodyContent":
				case "http.response.bytes":
				case "HttpResponseBytes":
				case "http.response.mime_type":
				case "HttpResponseMimeType":
				case "http.response.status_code":
				case "HttpResponseStatusCode":
				case "http.version":
				case "HttpVersion":
					return TrySetHttp(document, path, value);
				case "interface.alias":
				case "InterfaceAlias":
				case "interface.id":
				case "InterfaceId":
				case "interface.name":
				case "InterfaceName":
					return TrySetInterface(document, path, value);
				case "log.file.path":
				case "LogFilePath":
				case "log.level":
				case "LogLevel":
				case "log.logger":
				case "LogLogger":
				case "log.origin.file.line":
				case "LogOriginFileLine":
				case "log.origin.file.name":
				case "LogOriginFileName":
				case "log.origin.function":
				case "LogOriginFunction":
					return TrySetLog(document, path, value);
				case "network.application":
				case "NetworkApplication":
				case "network.bytes":
				case "NetworkBytes":
				case "network.community_id":
				case "NetworkCommunityId":
				case "network.direction":
				case "NetworkDirection":
				case "network.forwarded_ip":
				case "NetworkForwardedIp":
				case "network.iana_number":
				case "NetworkIanaNumber":
				case "network.name":
				case "NetworkName":
				case "network.packets":
				case "NetworkPackets":
				case "network.protocol":
				case "NetworkProtocol":
				case "network.transport":
				case "NetworkTransport":
				case "network.type":
				case "NetworkType":
					return TrySetNetwork(document, path, value);
				case "observer.hostname":
				case "ObserverHostname":
				case "observer.name":
				case "ObserverName":
				case "observer.product":
				case "ObserverProduct":
				case "observer.serial_number":
				case "ObserverSerialNumber":
				case "observer.type":
				case "ObserverType":
				case "observer.vendor":
				case "ObserverVendor":
				case "observer.version":
				case "ObserverVersion":
					return TrySetObserver(document, path, value);
				case "orchestrator.api_version":
				case "OrchestratorApiVersion":
				case "orchestrator.cluster.id":
				case "OrchestratorClusterId":
				case "orchestrator.cluster.name":
				case "OrchestratorClusterName":
				case "orchestrator.cluster.url":
				case "OrchestratorClusterUrl":
				case "orchestrator.cluster.version":
				case "OrchestratorClusterVersion":
				case "orchestrator.namespace":
				case "OrchestratorNamespace":
				case "orchestrator.organization":
				case "OrchestratorOrganization":
				case "orchestrator.resource.id":
				case "OrchestratorResourceId":
				case "orchestrator.resource.name":
				case "OrchestratorResourceName":
				case "orchestrator.resource.parent.type":
				case "OrchestratorResourceParentType":
				case "orchestrator.resource.type":
				case "OrchestratorResourceType":
				case "orchestrator.type":
				case "OrchestratorType":
					return TrySetOrchestrator(document, path, value);
				case "organization.id":
				case "OrganizationId":
				case "organization.name":
				case "OrganizationName":
					return TrySetOrganization(document, path, value);
				case "os.family":
				case "OsFamily":
				case "os.full":
				case "OsFull":
				case "os.kernel":
				case "OsKernel":
				case "os.name":
				case "OsName":
				case "os.platform":
				case "OsPlatform":
				case "os.type":
				case "OsType":
				case "os.version":
				case "OsVersion":
					return TrySetOs(document, path, value);
				case "package.architecture":
				case "PackageArchitecture":
				case "package.build_version":
				case "PackageBuildVersion":
				case "package.checksum":
				case "PackageChecksum":
				case "package.description":
				case "PackageDescription":
				case "package.install_scope":
				case "PackageInstallScope":
				case "package.installed":
				case "PackageInstalled":
				case "package.license":
				case "PackageLicense":
				case "package.name":
				case "PackageName":
				case "package.path":
				case "PackagePath":
				case "package.reference":
				case "PackageReference":
				case "package.size":
				case "PackageSize":
				case "package.type":
				case "PackageType":
				case "package.version":
				case "PackageVersion":
					return TrySetPackage(document, path, value);
				case "pe.architecture":
				case "PeArchitecture":
				case "pe.company":
				case "PeCompany":
				case "pe.description":
				case "PeDescription":
				case "pe.file_version":
				case "PeFileVersion":
				case "pe.imphash":
				case "PeImphash":
				case "pe.original_file_name":
				case "PeOriginalFileName":
				case "pe.pehash":
				case "PePehash":
				case "pe.product":
				case "PeProduct":
					return TrySetPe(document, path, value);
				case "process.args_count":
				case "ProcessArgsCount":
				case "process.command_line":
				case "ProcessCommandLine":
				case "process.end":
				case "ProcessEnd":
				case "process.entity_id":
				case "ProcessEntityId":
				case "process.executable":
				case "ProcessExecutable":
				case "process.exit_code":
				case "ProcessExitCode":
				case "process.interactive":
				case "ProcessInteractive":
				case "process.name":
				case "ProcessName":
				case "process.pgid":
				case "ProcessPgid":
				case "process.pid":
				case "ProcessPid":
				case "process.start":
				case "ProcessStart":
				case "process.thread.id":
				case "ProcessThreadId":
				case "process.thread.name":
				case "ProcessThreadName":
				case "process.title":
				case "ProcessTitle":
				case "process.uptime":
				case "ProcessUptime":
				case "process.working_directory":
				case "ProcessWorkingDirectory":
					return TrySetProcess(document, path, value);
				case "registry.data.bytes":
				case "RegistryDataBytes":
				case "registry.data.type":
				case "RegistryDataType":
				case "registry.hive":
				case "RegistryHive":
				case "registry.key":
				case "RegistryKey":
				case "registry.path":
				case "RegistryPath":
				case "registry.value":
				case "RegistryValue":
					return TrySetRegistry(document, path, value);
				case "rule.category":
				case "RuleCategory":
				case "rule.description":
				case "RuleDescription":
				case "rule.id":
				case "RuleId":
				case "rule.license":
				case "RuleLicense":
				case "rule.name":
				case "RuleName":
				case "rule.reference":
				case "RuleReference":
				case "rule.ruleset":
				case "RuleRuleset":
				case "rule.uuid":
				case "RuleUuid":
				case "rule.version":
				case "RuleVersion":
					return TrySetRule(document, path, value);
				case "server.address":
				case "ServerAddress":
				case "server.bytes":
				case "ServerBytes":
				case "server.domain":
				case "ServerDomain":
				case "server.ip":
				case "ServerIp":
				case "server.mac":
				case "ServerMac":
				case "server.nat.ip":
				case "ServerNatIp":
				case "server.nat.port":
				case "ServerNatPort":
				case "server.packets":
				case "ServerPackets":
				case "server.port":
				case "ServerPort":
				case "server.registered_domain":
				case "ServerRegisteredDomain":
				case "server.subdomain":
				case "ServerSubdomain":
				case "server.top_level_domain":
				case "ServerTopLevelDomain":
					return TrySetServer(document, path, value);
				case "service.address":
				case "ServiceAddress":
				case "service.environment":
				case "ServiceEnvironment":
				case "service.ephemeral_id":
				case "ServiceEphemeralId":
				case "service.id":
				case "ServiceId":
				case "service.name":
				case "ServiceName":
				case "service.node.name":
				case "ServiceNodeName":
				case "service.node.role":
				case "ServiceNodeRole":
				case "service.state":
				case "ServiceState":
				case "service.type":
				case "ServiceType":
				case "service.version":
				case "ServiceVersion":
					return TrySetService(document, path, value);
				case "source.address":
				case "SourceAddress":
				case "source.bytes":
				case "SourceBytes":
				case "source.domain":
				case "SourceDomain":
				case "source.ip":
				case "SourceIp":
				case "source.mac":
				case "SourceMac":
				case "source.nat.ip":
				case "SourceNatIp":
				case "source.nat.port":
				case "SourceNatPort":
				case "source.packets":
				case "SourcePackets":
				case "source.port":
				case "SourcePort":
				case "source.registered_domain":
				case "SourceRegisteredDomain":
				case "source.subdomain":
				case "SourceSubdomain":
				case "source.top_level_domain":
				case "SourceTopLevelDomain":
					return TrySetSource(document, path, value);
				case "threat.feed.dashboard_id":
				case "ThreatFeedDashboardId":
				case "threat.feed.description":
				case "ThreatFeedDescription":
				case "threat.feed.name":
				case "ThreatFeedName":
				case "threat.feed.reference":
				case "ThreatFeedReference":
				case "threat.framework":
				case "ThreatFramework":
				case "threat.group.id":
				case "ThreatGroupId":
				case "threat.group.name":
				case "ThreatGroupName":
				case "threat.group.reference":
				case "ThreatGroupReference":
				case "threat.indicator.confidence":
				case "ThreatIndicatorConfidence":
				case "threat.indicator.description":
				case "ThreatIndicatorDescription":
				case "threat.indicator.email.address":
				case "ThreatIndicatorEmailAddress":
				case "threat.indicator.first_seen":
				case "ThreatIndicatorFirstSeen":
				case "threat.indicator.ip":
				case "ThreatIndicatorIp":
				case "threat.indicator.last_seen":
				case "ThreatIndicatorLastSeen":
				case "threat.indicator.marking.tlp":
				case "ThreatIndicatorMarkingTlp":
				case "threat.indicator.modified_at":
				case "ThreatIndicatorModifiedAt":
				case "threat.indicator.port":
				case "ThreatIndicatorPort":
				case "threat.indicator.provider":
				case "ThreatIndicatorProvider":
				case "threat.indicator.reference":
				case "ThreatIndicatorReference":
				case "threat.indicator.scanner_stats":
				case "ThreatIndicatorScannerStats":
				case "threat.indicator.sightings":
				case "ThreatIndicatorSightings":
				case "threat.indicator.type":
				case "ThreatIndicatorType":
				case "threat.software.id":
				case "ThreatSoftwareId":
				case "threat.software.name":
				case "ThreatSoftwareName":
				case "threat.software.reference":
				case "ThreatSoftwareReference":
				case "threat.software.type":
				case "ThreatSoftwareType":
					return TrySetThreat(document, path, value);
				case "tls.cipher":
				case "TlsCipher":
				case "tls.client.certificate":
				case "TlsClientCertificate":
				case "tls.client.hash.md5":
				case "TlsClientHashMd5":
				case "tls.client.hash.sha1":
				case "TlsClientHashSha1":
				case "tls.client.hash.sha256":
				case "TlsClientHashSha256":
				case "tls.client.issuer":
				case "TlsClientIssuer":
				case "tls.client.ja3":
				case "TlsClientJa3":
				case "tls.client.not_after":
				case "TlsClientNotAfter":
				case "tls.client.not_before":
				case "TlsClientNotBefore":
				case "tls.client.server_name":
				case "TlsClientServerName":
				case "tls.client.subject":
				case "TlsClientSubject":
				case "tls.curve":
				case "TlsCurve":
				case "tls.established":
				case "TlsEstablished":
				case "tls.next_protocol":
				case "TlsNextProtocol":
				case "tls.resumed":
				case "TlsResumed":
				case "tls.server.certificate":
				case "TlsServerCertificate":
				case "tls.server.hash.md5":
				case "TlsServerHashMd5":
				case "tls.server.hash.sha1":
				case "TlsServerHashSha1":
				case "tls.server.hash.sha256":
				case "TlsServerHashSha256":
				case "tls.server.issuer":
				case "TlsServerIssuer":
				case "tls.server.ja3s":
				case "TlsServerJa3s":
				case "tls.server.not_after":
				case "TlsServerNotAfter":
				case "tls.server.not_before":
				case "TlsServerNotBefore":
				case "tls.server.subject":
				case "TlsServerSubject":
				case "tls.version":
				case "TlsVersion":
				case "tls.version_protocol":
				case "TlsVersionProtocol":
					return TrySetTls(document, path, value);
				case "url.domain":
				case "UrlDomain":
				case "url.extension":
				case "UrlExtension":
				case "url.fragment":
				case "UrlFragment":
				case "url.full":
				case "UrlFull":
				case "url.original":
				case "UrlOriginal":
				case "url.password":
				case "UrlPassword":
				case "url.path":
				case "UrlPath":
				case "url.port":
				case "UrlPort":
				case "url.query":
				case "UrlQuery":
				case "url.registered_domain":
				case "UrlRegisteredDomain":
				case "url.scheme":
				case "UrlScheme":
				case "url.subdomain":
				case "UrlSubdomain":
				case "url.top_level_domain":
				case "UrlTopLevelDomain":
				case "url.username":
				case "UrlUsername":
					return TrySetUrl(document, path, value);
				case "user.domain":
				case "UserDomain":
				case "user.email":
				case "UserEmail":
				case "user.full_name":
				case "UserFullName":
				case "user.hash":
				case "UserHash":
				case "user.id":
				case "UserId":
				case "user.name":
				case "UserName":
					return TrySetUser(document, path, value);
				case "user_agent.device.name":
				case "UserAgentDeviceName":
				case "user_agent.name":
				case "UserAgentName":
				case "user_agent.original":
				case "UserAgentOriginal":
				case "user_agent.version":
				case "UserAgentVersion":
					return TrySetUserAgent(document, path, value);
				case "vlan.id":
				case "VlanId":
				case "vlan.name":
				case "VlanName":
					return TrySetVlan(document, path, value);
				case "vulnerability.classification":
				case "VulnerabilityClassification":
				case "vulnerability.description":
				case "VulnerabilityDescription":
				case "vulnerability.enumeration":
				case "VulnerabilityEnumeration":
				case "vulnerability.id":
				case "VulnerabilityId":
				case "vulnerability.reference":
				case "VulnerabilityReference":
				case "vulnerability.report_id":
				case "VulnerabilityReportId":
				case "vulnerability.scanner.vendor":
				case "VulnerabilityScannerVendor":
				case "vulnerability.score.base":
				case "VulnerabilityScoreBase":
				case "vulnerability.score.environmental":
				case "VulnerabilityScoreEnvironmental":
				case "vulnerability.score.temporal":
				case "VulnerabilityScoreTemporal":
				case "vulnerability.score.version":
				case "VulnerabilityScoreVersion":
				case "vulnerability.severity":
				case "VulnerabilitySeverity":
					return TrySetVulnerability(document, path, value);
				case "x509.issuer.distinguished_name":
				case "X509IssuerDistinguishedName":
				case "x509.not_after":
				case "X509NotAfter":
				case "x509.not_before":
				case "X509NotBefore":
				case "x509.public_key_algorithm":
				case "X509PublicKeyAlgorithm":
				case "x509.public_key_curve":
				case "X509PublicKeyCurve":
				case "x509.public_key_exponent":
				case "X509PublicKeyExponent":
				case "x509.public_key_size":
				case "X509PublicKeySize":
				case "x509.serial_number":
				case "X509SerialNumber":
				case "x509.signature_algorithm":
				case "X509SignatureAlgorithm":
				case "x509.subject.distinguished_name":
				case "X509SubjectDistinguishedName":
				case "x509.version_number":
				case "X509VersionNumber":
					return TrySetX509(document, path, value);
				default:
					SetMetaOrLabel(document, path, value);
					return true;
			}
		}

		public static bool TrySetEcsDocument(EcsDocument document, string path, object value)
		{
			Func<EcsDocument, object, bool> assign = path switch
			{
				"@timestamp" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Timestamp = p),
				"Timestamp" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Timestamp = p),
				"message" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Message = p),
				"Message" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Message = p),
				"span.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SpanId = p),
				"SpanId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SpanId = p),
				"trace.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TraceId = p),
				"TraceId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TraceId = p),
				"transaction.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TransactionId = p),
				"TransactionId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TransactionId = p),
				_ => null
			};
			return assign != null && assign(document, value);
		}

		public static bool TrySetAgent(EcsDocument document, string path, object value)
		{
			Func<Agent, object, bool> assign = path switch
			{
				"agent.build.original" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.BuildOriginal = p),
				"AgentBuildOriginal" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.BuildOriginal = p),
				"agent.ephemeral_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.EphemeralId = p),
				"AgentEphemeralId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.EphemeralId = p),
				"agent.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"AgentId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"agent.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"AgentName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"agent.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"AgentType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"agent.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"AgentVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Agent ?? new Agent();
			var assigned = assign(entity, value);
			if (assigned) document.Agent = entity;
			return assigned;
		}

		public static bool TrySetAs(EcsDocument document, string path, object value)
		{
			Func<As, object, bool> assign = path switch
			{
				"as.number" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Number = p),
				"AsNumber" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Number = p),
				"as.organization.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OrganizationName = p),
				"AsOrganizationName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OrganizationName = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.As ?? new As();
			var assigned = assign(entity, value);
			if (assigned) document.As = entity;
			return assigned;
		}

		public static bool TrySetClient(EcsDocument document, string path, object value)
		{
			Func<Client, object, bool> assign = path switch
			{
				"client.address" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"ClientAddress" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"client.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"ClientBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"client.domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"ClientDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"client.ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ip = p),
				"ClientIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ip = p),
				"client.mac" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mac = p),
				"ClientMac" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mac = p),
				"client.nat.ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NatIp = p),
				"ClientNatIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NatIp = p),
				"client.nat.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NatPort = p),
				"ClientNatPort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NatPort = p),
				"client.packets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"ClientPackets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"client.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"ClientPort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"client.registered_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"ClientRegisteredDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"client.subdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"ClientSubdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"client.top_level_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				"ClientTopLevelDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Client ?? new Client();
			var assigned = assign(entity, value);
			if (assigned) document.Client = entity;
			return assigned;
		}

		public static bool TrySetCloud(EcsDocument document, string path, object value)
		{
			Func<Cloud, object, bool> assign = path switch
			{
				"cloud.account.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.AccountId = p),
				"CloudAccountId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.AccountId = p),
				"cloud.account.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.AccountName = p),
				"CloudAccountName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.AccountName = p),
				"cloud.availability_zone" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.AvailabilityZone = p),
				"CloudAvailabilityZone" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.AvailabilityZone = p),
				"cloud.instance.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.InstanceId = p),
				"CloudInstanceId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.InstanceId = p),
				"cloud.instance.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.InstanceName = p),
				"CloudInstanceName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.InstanceName = p),
				"cloud.machine.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.MachineType = p),
				"CloudMachineType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.MachineType = p),
				"cloud.project.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ProjectId = p),
				"CloudProjectId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ProjectId = p),
				"cloud.project.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ProjectName = p),
				"CloudProjectName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ProjectName = p),
				"cloud.provider" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Provider = p),
				"CloudProvider" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Provider = p),
				"cloud.region" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Region = p),
				"CloudRegion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Region = p),
				"cloud.service.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServiceName = p),
				"CloudServiceName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServiceName = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Cloud ?? new Cloud();
			var assigned = assign(entity, value);
			if (assigned) document.Cloud = entity;
			return assigned;
		}

		public static bool TrySetCodeSignature(EcsDocument document, string path, object value)
		{
			Func<CodeSignature, object, bool> assign = path switch
			{
				"code_signature.digest_algorithm" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DigestAlgorithm = p),
				"CodeSignatureDigestAlgorithm" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DigestAlgorithm = p),
				"code_signature.exists" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Exists = p),
				"CodeSignatureExists" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Exists = p),
				"code_signature.signing_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SigningId = p),
				"CodeSignatureSigningId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SigningId = p),
				"code_signature.status" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Status = p),
				"CodeSignatureStatus" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Status = p),
				"code_signature.subject_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SubjectName = p),
				"CodeSignatureSubjectName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SubjectName = p),
				"code_signature.team_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TeamId = p),
				"CodeSignatureTeamId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TeamId = p),
				"code_signature.timestamp" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Timestamp = p),
				"CodeSignatureTimestamp" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Timestamp = p),
				"code_signature.trusted" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Trusted = p),
				"CodeSignatureTrusted" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Trusted = p),
				"code_signature.valid" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Valid = p),
				"CodeSignatureValid" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Valid = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.CodeSignature ?? new CodeSignature();
			var assigned = assign(entity, value);
			if (assigned) document.CodeSignature = entity;
			return assigned;
		}

		public static bool TrySetContainer(EcsDocument document, string path, object value)
		{
			Func<Container, object, bool> assign = path switch
			{
				"container.cpu.usage" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.CpuUsage = p),
				"ContainerCpuUsage" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.CpuUsage = p),
				"container.disk.read.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.DiskReadBytes = p),
				"ContainerDiskReadBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.DiskReadBytes = p),
				"container.disk.write.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.DiskWriteBytes = p),
				"ContainerDiskWriteBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.DiskWriteBytes = p),
				"container.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"ContainerId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"container.image.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ImageName = p),
				"ContainerImageName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ImageName = p),
				"container.memory.usage" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.MemoryUsage = p),
				"ContainerMemoryUsage" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.MemoryUsage = p),
				"container.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"ContainerName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"container.network.egress.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkEgressBytes = p),
				"ContainerNetworkEgressBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkEgressBytes = p),
				"container.network.ingress.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkIngressBytes = p),
				"ContainerNetworkIngressBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkIngressBytes = p),
				"container.runtime" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Runtime = p),
				"ContainerRuntime" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Runtime = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Container ?? new Container();
			var assigned = assign(entity, value);
			if (assigned) document.Container = entity;
			return assigned;
		}

		public static bool TrySetDataStream(EcsDocument document, string path, object value)
		{
			Func<DataStream, object, bool> assign = path switch
			{
				"data_stream.dataset" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Dataset = p),
				"DataStreamDataset" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Dataset = p),
				"data_stream.namespace" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Namespace = p),
				"DataStreamNamespace" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Namespace = p),
				"data_stream.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"DataStreamType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.DataStream ?? new DataStream();
			var assigned = assign(entity, value);
			if (assigned) document.DataStream = entity;
			return assigned;
		}

		public static bool TrySetDestination(EcsDocument document, string path, object value)
		{
			Func<Destination, object, bool> assign = path switch
			{
				"destination.address" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"DestinationAddress" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"destination.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"DestinationBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"destination.domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"DestinationDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"destination.ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ip = p),
				"DestinationIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ip = p),
				"destination.mac" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mac = p),
				"DestinationMac" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mac = p),
				"destination.nat.ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NatIp = p),
				"DestinationNatIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NatIp = p),
				"destination.nat.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NatPort = p),
				"DestinationNatPort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NatPort = p),
				"destination.packets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"DestinationPackets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"destination.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"DestinationPort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"destination.registered_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"DestinationRegisteredDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"destination.subdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"DestinationSubdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"destination.top_level_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				"DestinationTopLevelDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Destination ?? new Destination();
			var assigned = assign(entity, value);
			if (assigned) document.Destination = entity;
			return assigned;
		}

		public static bool TrySetDll(EcsDocument document, string path, object value)
		{
			Func<Dll, object, bool> assign = path switch
			{
				"dll.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"DllName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"dll.path" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"DllPath" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Dll ?? new Dll();
			var assigned = assign(entity, value);
			if (assigned) document.Dll = entity;
			return assigned;
		}

		public static bool TrySetDns(EcsDocument document, string path, object value)
		{
			Func<Dns, object, bool> assign = path switch
			{
				"dns.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"DnsId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"dns.op_code" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OpCode = p),
				"DnsOpCode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OpCode = p),
				"dns.question.class" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionClass = p),
				"DnsQuestionClass" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionClass = p),
				"dns.question.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionName = p),
				"DnsQuestionName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionName = p),
				"dns.question.registered_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionRegisteredDomain = p),
				"DnsQuestionRegisteredDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionRegisteredDomain = p),
				"dns.question.subdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionSubdomain = p),
				"DnsQuestionSubdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionSubdomain = p),
				"dns.question.top_level_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionTopLevelDomain = p),
				"DnsQuestionTopLevelDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionTopLevelDomain = p),
				"dns.question.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionType = p),
				"DnsQuestionType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.QuestionType = p),
				"dns.response_code" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResponseCode = p),
				"DnsResponseCode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResponseCode = p),
				"dns.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"DnsType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Dns ?? new Dns();
			var assigned = assign(entity, value);
			if (assigned) document.Dns = entity;
			return assigned;
		}

		public static bool TrySetEcs(EcsDocument document, string path, object value)
		{
			Func<Ecs, object, bool> assign = path switch
			{
				"ecs.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"EcsVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Ecs ?? new Ecs();
			var assigned = assign(entity, value);
			if (assigned) document.Ecs = entity;
			return assigned;
		}

		public static bool TrySetElf(EcsDocument document, string path, object value)
		{
			Func<Elf, object, bool> assign = path switch
			{
				"elf.architecture" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Architecture = p),
				"ElfArchitecture" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Architecture = p),
				"elf.byte_order" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ByteOrder = p),
				"ElfByteOrder" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ByteOrder = p),
				"elf.cpu_type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CpuType = p),
				"ElfCpuType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CpuType = p),
				"elf.creation_date" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.CreationDate = p),
				"ElfCreationDate" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.CreationDate = p),
				"elf.header.abi_version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderAbiVersion = p),
				"ElfHeaderAbiVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderAbiVersion = p),
				"elf.header.class" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderClass = p),
				"ElfHeaderClass" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderClass = p),
				"elf.header.data" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderData = p),
				"ElfHeaderData" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderData = p),
				"elf.header.entrypoint" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.HeaderEntrypoint = p),
				"ElfHeaderEntrypoint" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.HeaderEntrypoint = p),
				"elf.header.object_version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderObjectVersion = p),
				"ElfHeaderObjectVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderObjectVersion = p),
				"elf.header.os_abi" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderOsAbi = p),
				"ElfHeaderOsAbi" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderOsAbi = p),
				"elf.header.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderType = p),
				"ElfHeaderType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderType = p),
				"elf.header.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderVersion = p),
				"ElfHeaderVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.HeaderVersion = p),
				"elf.telfhash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Telfhash = p),
				"ElfTelfhash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Telfhash = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Elf ?? new Elf();
			var assigned = assign(entity, value);
			if (assigned) document.Elf = entity;
			return assigned;
		}

		public static bool TrySetEmail(EcsDocument document, string path, object value)
		{
			Func<Email, object, bool> assign = path switch
			{
				"email.content_type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ContentType = p),
				"EmailContentType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ContentType = p),
				"email.delivery_timestamp" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.DeliveryTimestamp = p),
				"EmailDeliveryTimestamp" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.DeliveryTimestamp = p),
				"email.direction" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Direction = p),
				"EmailDirection" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Direction = p),
				"email.local_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.LocalId = p),
				"EmailLocalId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.LocalId = p),
				"email.message_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.MessageId = p),
				"EmailMessageId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.MessageId = p),
				"email.origination_timestamp" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.OriginationTimestamp = p),
				"EmailOriginationTimestamp" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.OriginationTimestamp = p),
				"email.sender.address" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SenderAddress = p),
				"EmailSenderAddress" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SenderAddress = p),
				"email.subject" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subject = p),
				"EmailSubject" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subject = p),
				"email.x_mailer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.XMailer = p),
				"EmailXMailer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.XMailer = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Email ?? new Email();
			var assigned = assign(entity, value);
			if (assigned) document.Email = entity;
			return assigned;
		}

		public static bool TrySetError(EcsDocument document, string path, object value)
		{
			Func<Error, object, bool> assign = path switch
			{
				"error.code" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Code = p),
				"ErrorCode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Code = p),
				"error.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"ErrorId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"error.message" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Message = p),
				"ErrorMessage" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Message = p),
				"error.stack_trace" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.StackTrace = p),
				"ErrorStackTrace" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.StackTrace = p),
				"error.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"ErrorType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Error ?? new Error();
			var assigned = assign(entity, value);
			if (assigned) document.Error = entity;
			return assigned;
		}

		public static bool TrySetEvent(EcsDocument document, string path, object value)
		{
			Func<Event, object, bool> assign = path switch
			{
				"event.action" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Action = p),
				"EventAction" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Action = p),
				"event.agent_id_status" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.AgentIdStatus = p),
				"EventAgentIdStatus" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.AgentIdStatus = p),
				"event.code" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Code = p),
				"EventCode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Code = p),
				"event.created" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Created = p),
				"EventCreated" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Created = p),
				"event.dataset" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Dataset = p),
				"EventDataset" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Dataset = p),
				"event.duration" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Duration = p),
				"EventDuration" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Duration = p),
				"event.end" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.End = p),
				"EventEnd" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.End = p),
				"event.hash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hash = p),
				"EventHash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hash = p),
				"event.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"EventId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"event.ingested" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Ingested = p),
				"EventIngested" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Ingested = p),
				"event.kind" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Kind = p),
				"EventKind" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Kind = p),
				"event.module" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Module = p),
				"EventModule" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Module = p),
				"event.original" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Original = p),
				"EventOriginal" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Original = p),
				"event.outcome" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Outcome = p),
				"EventOutcome" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Outcome = p),
				"event.provider" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Provider = p),
				"EventProvider" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Provider = p),
				"event.reason" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reason = p),
				"EventReason" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reason = p),
				"event.reference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reference = p),
				"EventReference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reference = p),
				"event.risk_score" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.RiskScore = p),
				"EventRiskScore" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.RiskScore = p),
				"event.risk_score_norm" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.RiskScoreNorm = p),
				"EventRiskScoreNorm" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.RiskScoreNorm = p),
				"event.sequence" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Sequence = p),
				"EventSequence" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Sequence = p),
				"event.severity" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Severity = p),
				"EventSeverity" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Severity = p),
				"event.start" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Start = p),
				"EventStart" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Start = p),
				"event.timezone" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Timezone = p),
				"EventTimezone" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Timezone = p),
				"event.url" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Url = p),
				"EventUrl" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Url = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Event ?? new Event();
			var assigned = assign(entity, value);
			if (assigned) document.Event = entity;
			return assigned;
		}

		public static bool TrySetFaas(EcsDocument document, string path, object value)
		{
			Func<Faas, object, bool> assign = path switch
			{
				"faas.coldstart" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Coldstart = p),
				"FaasColdstart" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Coldstart = p),
				"faas.execution" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Execution = p),
				"FaasExecution" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Execution = p),
				"faas.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"FaasId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"faas.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"FaasName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"faas.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"FaasVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Faas ?? new Faas();
			var assigned = assign(entity, value);
			if (assigned) document.Faas = entity;
			return assigned;
		}

		public static bool TrySetFile(EcsDocument document, string path, object value)
		{
			Func<File, object, bool> assign = path switch
			{
				"file.accessed" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Accessed = p),
				"FileAccessed" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Accessed = p),
				"file.created" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Created = p),
				"FileCreated" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Created = p),
				"file.ctime" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Ctime = p),
				"FileCtime" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Ctime = p),
				"file.device" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Device = p),
				"FileDevice" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Device = p),
				"file.directory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Directory = p),
				"FileDirectory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Directory = p),
				"file.drive_letter" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DriveLetter = p),
				"FileDriveLetter" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DriveLetter = p),
				"file.extension" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Extension = p),
				"FileExtension" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Extension = p),
				"file.fork_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ForkName = p),
				"FileForkName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ForkName = p),
				"file.gid" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Gid = p),
				"FileGid" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Gid = p),
				"file.group" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Group = p),
				"FileGroup" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Group = p),
				"file.inode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Inode = p),
				"FileInode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Inode = p),
				"file.mime_type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.MimeType = p),
				"FileMimeType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.MimeType = p),
				"file.mode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mode = p),
				"FileMode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mode = p),
				"file.mtime" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Mtime = p),
				"FileMtime" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Mtime = p),
				"file.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"FileName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"file.owner" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Owner = p),
				"FileOwner" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Owner = p),
				"file.path" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"FilePath" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"file.size" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Size = p),
				"FileSize" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Size = p),
				"file.target_path" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TargetPath = p),
				"FileTargetPath" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TargetPath = p),
				"file.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"FileType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"file.uid" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Uid = p),
				"FileUid" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Uid = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.File ?? new File();
			var assigned = assign(entity, value);
			if (assigned) document.File = entity;
			return assigned;
		}

		public static bool TrySetGeo(EcsDocument document, string path, object value)
		{
			Func<Geo, object, bool> assign = path switch
			{
				"geo.city_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CityName = p),
				"GeoCityName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CityName = p),
				"geo.continent_code" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ContinentCode = p),
				"GeoContinentCode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ContinentCode = p),
				"geo.continent_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ContinentName = p),
				"GeoContinentName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ContinentName = p),
				"geo.country_iso_code" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CountryIsoCode = p),
				"GeoCountryIsoCode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CountryIsoCode = p),
				"geo.country_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CountryName = p),
				"GeoCountryName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CountryName = p),
				"geo.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"GeoName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"geo.postal_code" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.PostalCode = p),
				"GeoPostalCode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.PostalCode = p),
				"geo.region_iso_code" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegionIsoCode = p),
				"GeoRegionIsoCode" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegionIsoCode = p),
				"geo.region_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegionName = p),
				"GeoRegionName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegionName = p),
				"geo.timezone" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Timezone = p),
				"GeoTimezone" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Timezone = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Geo ?? new Geo();
			var assigned = assign(entity, value);
			if (assigned) document.Geo = entity;
			return assigned;
		}

		public static bool TrySetGroup(EcsDocument document, string path, object value)
		{
			Func<Group, object, bool> assign = path switch
			{
				"group.domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"GroupDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"group.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"GroupId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"group.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"GroupName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Group ?? new Group();
			var assigned = assign(entity, value);
			if (assigned) document.Group = entity;
			return assigned;
		}

		public static bool TrySetHash(EcsDocument document, string path, object value)
		{
			Func<Hash, object, bool> assign = path switch
			{
				"hash.md5" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Md5 = p),
				"HashMd5" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Md5 = p),
				"hash.sha1" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Sha1 = p),
				"HashSha1" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Sha1 = p),
				"hash.sha256" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Sha256 = p),
				"HashSha256" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Sha256 = p),
				"hash.sha384" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Sha384 = p),
				"HashSha384" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Sha384 = p),
				"hash.sha512" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Sha512 = p),
				"HashSha512" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Sha512 = p),
				"hash.ssdeep" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ssdeep = p),
				"HashSsdeep" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ssdeep = p),
				"hash.tlsh" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Tlsh = p),
				"HashTlsh" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Tlsh = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Hash ?? new Hash();
			var assigned = assign(entity, value);
			if (assigned) document.Hash = entity;
			return assigned;
		}

		public static bool TrySetHost(EcsDocument document, string path, object value)
		{
			Func<Host, object, bool> assign = path switch
			{
				"host.architecture" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Architecture = p),
				"HostArchitecture" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Architecture = p),
				"host.boot.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.BootId = p),
				"HostBootId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.BootId = p),
				"host.cpu.usage" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.CpuUsage = p),
				"HostCpuUsage" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.CpuUsage = p),
				"host.disk.read.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.DiskReadBytes = p),
				"HostDiskReadBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.DiskReadBytes = p),
				"host.disk.write.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.DiskWriteBytes = p),
				"HostDiskWriteBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.DiskWriteBytes = p),
				"host.domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"HostDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"host.hostname" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hostname = p),
				"HostHostname" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hostname = p),
				"host.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"HostId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"host.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"HostName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"host.network.egress.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkEgressBytes = p),
				"HostNetworkEgressBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkEgressBytes = p),
				"host.network.egress.packets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkEgressPackets = p),
				"HostNetworkEgressPackets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkEgressPackets = p),
				"host.network.ingress.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkIngressBytes = p),
				"HostNetworkIngressBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkIngressBytes = p),
				"host.network.ingress.packets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkIngressPackets = p),
				"HostNetworkIngressPackets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NetworkIngressPackets = p),
				"host.pid_ns_ino" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.PidNsIno = p),
				"HostPidNsIno" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.PidNsIno = p),
				"host.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"HostType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"host.uptime" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Uptime = p),
				"HostUptime" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Uptime = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Host ?? new Host();
			var assigned = assign(entity, value);
			if (assigned) document.Host = entity;
			return assigned;
		}

		public static bool TrySetHttp(EcsDocument document, string path, object value)
		{
			Func<Http, object, bool> assign = path switch
			{
				"http.request.body.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.RequestBodyBytes = p),
				"HttpRequestBodyBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.RequestBodyBytes = p),
				"http.request.body.content" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestBodyContent = p),
				"HttpRequestBodyContent" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestBodyContent = p),
				"http.request.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.RequestBytes = p),
				"HttpRequestBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.RequestBytes = p),
				"http.request.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestId = p),
				"HttpRequestId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestId = p),
				"http.request.method" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestMethod = p),
				"HttpRequestMethod" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestMethod = p),
				"http.request.mime_type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestMimeType = p),
				"HttpRequestMimeType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestMimeType = p),
				"http.request.referrer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestReferrer = p),
				"HttpRequestReferrer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RequestReferrer = p),
				"http.response.body.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ResponseBodyBytes = p),
				"HttpResponseBodyBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ResponseBodyBytes = p),
				"http.response.body.content" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResponseBodyContent = p),
				"HttpResponseBodyContent" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResponseBodyContent = p),
				"http.response.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ResponseBytes = p),
				"HttpResponseBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ResponseBytes = p),
				"http.response.mime_type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResponseMimeType = p),
				"HttpResponseMimeType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResponseMimeType = p),
				"http.response.status_code" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ResponseStatusCode = p),
				"HttpResponseStatusCode" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ResponseStatusCode = p),
				"http.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"HttpVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Http ?? new Http();
			var assigned = assign(entity, value);
			if (assigned) document.Http = entity;
			return assigned;
		}

		public static bool TrySetInterface(EcsDocument document, string path, object value)
		{
			Func<Interface, object, bool> assign = path switch
			{
				"interface.alias" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Alias = p),
				"InterfaceAlias" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Alias = p),
				"interface.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"InterfaceId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"interface.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"InterfaceName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Interface ?? new Interface();
			var assigned = assign(entity, value);
			if (assigned) document.Interface = entity;
			return assigned;
		}

		public static bool TrySetLog(EcsDocument document, string path, object value)
		{
			Func<Log, object, bool> assign = path switch
			{
				"log.file.path" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FilePath = p),
				"LogFilePath" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FilePath = p),
				"log.level" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Level = p),
				"LogLevel" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Level = p),
				"log.logger" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Logger = p),
				"LogLogger" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Logger = p),
				"log.origin.file.line" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.OriginFileLine = p),
				"LogOriginFileLine" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.OriginFileLine = p),
				"log.origin.file.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OriginFileName = p),
				"LogOriginFileName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OriginFileName = p),
				"log.origin.function" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OriginFunction = p),
				"LogOriginFunction" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OriginFunction = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Log ?? new Log();
			var assigned = assign(entity, value);
			if (assigned) document.Log = entity;
			return assigned;
		}

		public static bool TrySetNetwork(EcsDocument document, string path, object value)
		{
			Func<Network, object, bool> assign = path switch
			{
				"network.application" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Application = p),
				"NetworkApplication" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Application = p),
				"network.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"NetworkBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"network.community_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CommunityId = p),
				"NetworkCommunityId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CommunityId = p),
				"network.direction" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Direction = p),
				"NetworkDirection" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Direction = p),
				"network.forwarded_ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ForwardedIp = p),
				"NetworkForwardedIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ForwardedIp = p),
				"network.iana_number" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IanaNumber = p),
				"NetworkIanaNumber" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IanaNumber = p),
				"network.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"NetworkName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"network.packets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"NetworkPackets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"network.protocol" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Protocol = p),
				"NetworkProtocol" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Protocol = p),
				"network.transport" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Transport = p),
				"NetworkTransport" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Transport = p),
				"network.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"NetworkType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Network ?? new Network();
			var assigned = assign(entity, value);
			if (assigned) document.Network = entity;
			return assigned;
		}

		public static bool TrySetObserver(EcsDocument document, string path, object value)
		{
			Func<Observer, object, bool> assign = path switch
			{
				"observer.hostname" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hostname = p),
				"ObserverHostname" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hostname = p),
				"observer.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"ObserverName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"observer.product" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Product = p),
				"ObserverProduct" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Product = p),
				"observer.serial_number" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SerialNumber = p),
				"ObserverSerialNumber" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SerialNumber = p),
				"observer.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"ObserverType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"observer.vendor" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Vendor = p),
				"ObserverVendor" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Vendor = p),
				"observer.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"ObserverVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Observer ?? new Observer();
			var assigned = assign(entity, value);
			if (assigned) document.Observer = entity;
			return assigned;
		}

		public static bool TrySetOrchestrator(EcsDocument document, string path, object value)
		{
			Func<Orchestrator, object, bool> assign = path switch
			{
				"orchestrator.api_version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ApiVersion = p),
				"OrchestratorApiVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ApiVersion = p),
				"orchestrator.cluster.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClusterId = p),
				"OrchestratorClusterId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClusterId = p),
				"orchestrator.cluster.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClusterName = p),
				"OrchestratorClusterName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClusterName = p),
				"orchestrator.cluster.url" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClusterUrl = p),
				"OrchestratorClusterUrl" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClusterUrl = p),
				"orchestrator.cluster.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClusterVersion = p),
				"OrchestratorClusterVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClusterVersion = p),
				"orchestrator.namespace" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Namespace = p),
				"OrchestratorNamespace" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Namespace = p),
				"orchestrator.organization" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Organization = p),
				"OrchestratorOrganization" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Organization = p),
				"orchestrator.resource.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResourceId = p),
				"OrchestratorResourceId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResourceId = p),
				"orchestrator.resource.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResourceName = p),
				"OrchestratorResourceName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResourceName = p),
				"orchestrator.resource.parent.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResourceParentType = p),
				"OrchestratorResourceParentType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResourceParentType = p),
				"orchestrator.resource.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResourceType = p),
				"OrchestratorResourceType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ResourceType = p),
				"orchestrator.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"OrchestratorType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Orchestrator ?? new Orchestrator();
			var assigned = assign(entity, value);
			if (assigned) document.Orchestrator = entity;
			return assigned;
		}

		public static bool TrySetOrganization(EcsDocument document, string path, object value)
		{
			Func<Organization, object, bool> assign = path switch
			{
				"organization.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"OrganizationId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"organization.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"OrganizationName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Organization ?? new Organization();
			var assigned = assign(entity, value);
			if (assigned) document.Organization = entity;
			return assigned;
		}

		public static bool TrySetOs(EcsDocument document, string path, object value)
		{
			Func<Os, object, bool> assign = path switch
			{
				"os.family" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Family = p),
				"OsFamily" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Family = p),
				"os.full" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Full = p),
				"OsFull" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Full = p),
				"os.kernel" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Kernel = p),
				"OsKernel" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Kernel = p),
				"os.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"OsName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"os.platform" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Platform = p),
				"OsPlatform" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Platform = p),
				"os.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"OsType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"os.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"OsVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Os ?? new Os();
			var assigned = assign(entity, value);
			if (assigned) document.Os = entity;
			return assigned;
		}

		public static bool TrySetPackage(EcsDocument document, string path, object value)
		{
			Func<Package, object, bool> assign = path switch
			{
				"package.architecture" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Architecture = p),
				"PackageArchitecture" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Architecture = p),
				"package.build_version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.BuildVersion = p),
				"PackageBuildVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.BuildVersion = p),
				"package.checksum" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Checksum = p),
				"PackageChecksum" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Checksum = p),
				"package.description" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Description = p),
				"PackageDescription" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Description = p),
				"package.install_scope" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.InstallScope = p),
				"PackageInstallScope" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.InstallScope = p),
				"package.installed" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Installed = p),
				"PackageInstalled" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Installed = p),
				"package.license" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.License = p),
				"PackageLicense" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.License = p),
				"package.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"PackageName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"package.path" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"PackagePath" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"package.reference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reference = p),
				"PackageReference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reference = p),
				"package.size" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Size = p),
				"PackageSize" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Size = p),
				"package.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"PackageType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"package.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"PackageVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Package ?? new Package();
			var assigned = assign(entity, value);
			if (assigned) document.Package = entity;
			return assigned;
		}

		public static bool TrySetPe(EcsDocument document, string path, object value)
		{
			Func<Pe, object, bool> assign = path switch
			{
				"pe.architecture" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Architecture = p),
				"PeArchitecture" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Architecture = p),
				"pe.company" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Company = p),
				"PeCompany" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Company = p),
				"pe.description" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Description = p),
				"PeDescription" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Description = p),
				"pe.file_version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FileVersion = p),
				"PeFileVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FileVersion = p),
				"pe.imphash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Imphash = p),
				"PeImphash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Imphash = p),
				"pe.original_file_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OriginalFileName = p),
				"PeOriginalFileName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OriginalFileName = p),
				"pe.pehash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Pehash = p),
				"PePehash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Pehash = p),
				"pe.product" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Product = p),
				"PeProduct" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Product = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Pe ?? new Pe();
			var assigned = assign(entity, value);
			if (assigned) document.Pe = entity;
			return assigned;
		}

		public static bool TrySetProcess(EcsDocument document, string path, object value)
		{
			Func<Process, object, bool> assign = path switch
			{
				"process.args_count" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ArgsCount = p),
				"ProcessArgsCount" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ArgsCount = p),
				"process.command_line" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CommandLine = p),
				"ProcessCommandLine" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CommandLine = p),
				"process.end" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.End = p),
				"ProcessEnd" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.End = p),
				"process.entity_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.EntityId = p),
				"ProcessEntityId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.EntityId = p),
				"process.executable" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Executable = p),
				"ProcessExecutable" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Executable = p),
				"process.exit_code" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ExitCode = p),
				"ProcessExitCode" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ExitCode = p),
				"process.interactive" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Interactive = p),
				"ProcessInteractive" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Interactive = p),
				"process.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"ProcessName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"process.pgid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Pgid = p),
				"ProcessPgid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Pgid = p),
				"process.pid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Pid = p),
				"ProcessPid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Pid = p),
				"process.start" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Start = p),
				"ProcessStart" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.Start = p),
				"process.thread.id" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ThreadId = p),
				"ProcessThreadId" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ThreadId = p),
				"process.thread.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ThreadName = p),
				"ProcessThreadName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ThreadName = p),
				"process.title" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Title = p),
				"ProcessTitle" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Title = p),
				"process.uptime" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Uptime = p),
				"ProcessUptime" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Uptime = p),
				"process.working_directory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"ProcessWorkingDirectory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Process ?? new Process();
			var assigned = assign(entity, value);
			if (assigned) document.Process = entity;
			return assigned;
		}

		public static bool TrySetRegistry(EcsDocument document, string path, object value)
		{
			Func<Registry, object, bool> assign = path switch
			{
				"registry.data.bytes" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DataBytes = p),
				"RegistryDataBytes" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DataBytes = p),
				"registry.data.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DataType = p),
				"RegistryDataType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DataType = p),
				"registry.hive" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hive = p),
				"RegistryHive" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hive = p),
				"registry.key" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Key = p),
				"RegistryKey" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Key = p),
				"registry.path" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"RegistryPath" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"registry.value" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Value = p),
				"RegistryValue" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Value = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Registry ?? new Registry();
			var assigned = assign(entity, value);
			if (assigned) document.Registry = entity;
			return assigned;
		}

		public static bool TrySetRelated(EcsDocument document, string path, object value)
		{
			Func<Related, object, bool> assign = path switch
			{
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Related ?? new Related();
			var assigned = assign(entity, value);
			if (assigned) document.Related = entity;
			return assigned;
		}

		public static bool TrySetRule(EcsDocument document, string path, object value)
		{
			Func<Rule, object, bool> assign = path switch
			{
				"rule.category" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Category = p),
				"RuleCategory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Category = p),
				"rule.description" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Description = p),
				"RuleDescription" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Description = p),
				"rule.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"RuleId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"rule.license" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.License = p),
				"RuleLicense" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.License = p),
				"rule.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"RuleName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"rule.reference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reference = p),
				"RuleReference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reference = p),
				"rule.ruleset" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ruleset = p),
				"RuleRuleset" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ruleset = p),
				"rule.uuid" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Uuid = p),
				"RuleUuid" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Uuid = p),
				"rule.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"RuleVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Rule ?? new Rule();
			var assigned = assign(entity, value);
			if (assigned) document.Rule = entity;
			return assigned;
		}

		public static bool TrySetServer(EcsDocument document, string path, object value)
		{
			Func<Server, object, bool> assign = path switch
			{
				"server.address" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"ServerAddress" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"server.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"ServerBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"server.domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"ServerDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"server.ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ip = p),
				"ServerIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ip = p),
				"server.mac" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mac = p),
				"ServerMac" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mac = p),
				"server.nat.ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NatIp = p),
				"ServerNatIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NatIp = p),
				"server.nat.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NatPort = p),
				"ServerNatPort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NatPort = p),
				"server.packets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"ServerPackets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"server.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"ServerPort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"server.registered_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"ServerRegisteredDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"server.subdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"ServerSubdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"server.top_level_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				"ServerTopLevelDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Server ?? new Server();
			var assigned = assign(entity, value);
			if (assigned) document.Server = entity;
			return assigned;
		}

		public static bool TrySetService(EcsDocument document, string path, object value)
		{
			Func<Service, object, bool> assign = path switch
			{
				"service.address" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"ServiceAddress" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"service.environment" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Environment = p),
				"ServiceEnvironment" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Environment = p),
				"service.ephemeral_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.EphemeralId = p),
				"ServiceEphemeralId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.EphemeralId = p),
				"service.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"ServiceId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"service.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"ServiceName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"service.node.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NodeName = p),
				"ServiceNodeName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NodeName = p),
				"service.node.role" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NodeRole = p),
				"ServiceNodeRole" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NodeRole = p),
				"service.state" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.State = p),
				"ServiceState" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.State = p),
				"service.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"ServiceType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Type = p),
				"service.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"ServiceVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Service ?? new Service();
			var assigned = assign(entity, value);
			if (assigned) document.Service = entity;
			return assigned;
		}

		public static bool TrySetSource(EcsDocument document, string path, object value)
		{
			Func<Source, object, bool> assign = path switch
			{
				"source.address" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"SourceAddress" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Address = p),
				"source.bytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"SourceBytes" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Bytes = p),
				"source.domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"SourceDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"source.ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ip = p),
				"SourceIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Ip = p),
				"source.mac" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mac = p),
				"SourceMac" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Mac = p),
				"source.nat.ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NatIp = p),
				"SourceNatIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NatIp = p),
				"source.nat.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NatPort = p),
				"SourceNatPort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.NatPort = p),
				"source.packets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"SourcePackets" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Packets = p),
				"source.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"SourcePort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"source.registered_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"SourceRegisteredDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"source.subdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"SourceSubdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"source.top_level_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				"SourceTopLevelDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Source ?? new Source();
			var assigned = assign(entity, value);
			if (assigned) document.Source = entity;
			return assigned;
		}

		public static bool TrySetThreat(EcsDocument document, string path, object value)
		{
			Func<Threat, object, bool> assign = path switch
			{
				"threat.feed.dashboard_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FeedDashboardId = p),
				"ThreatFeedDashboardId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FeedDashboardId = p),
				"threat.feed.description" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FeedDescription = p),
				"ThreatFeedDescription" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FeedDescription = p),
				"threat.feed.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FeedName = p),
				"ThreatFeedName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FeedName = p),
				"threat.feed.reference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FeedReference = p),
				"ThreatFeedReference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FeedReference = p),
				"threat.framework" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Framework = p),
				"ThreatFramework" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Framework = p),
				"threat.group.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GroupId = p),
				"ThreatGroupId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GroupId = p),
				"threat.group.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GroupName = p),
				"ThreatGroupName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GroupName = p),
				"threat.group.reference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GroupReference = p),
				"ThreatGroupReference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GroupReference = p),
				"threat.indicator.confidence" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorConfidence = p),
				"ThreatIndicatorConfidence" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorConfidence = p),
				"threat.indicator.description" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorDescription = p),
				"ThreatIndicatorDescription" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorDescription = p),
				"threat.indicator.email.address" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorEmailAddress = p),
				"ThreatIndicatorEmailAddress" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorEmailAddress = p),
				"threat.indicator.first_seen" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.IndicatorFirstSeen = p),
				"ThreatIndicatorFirstSeen" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.IndicatorFirstSeen = p),
				"threat.indicator.ip" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorIp = p),
				"ThreatIndicatorIp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorIp = p),
				"threat.indicator.last_seen" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.IndicatorLastSeen = p),
				"ThreatIndicatorLastSeen" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.IndicatorLastSeen = p),
				"threat.indicator.marking.tlp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorMarkingTlp = p),
				"ThreatIndicatorMarkingTlp" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorMarkingTlp = p),
				"threat.indicator.modified_at" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.IndicatorModifiedAt = p),
				"ThreatIndicatorModifiedAt" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.IndicatorModifiedAt = p),
				"threat.indicator.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.IndicatorPort = p),
				"ThreatIndicatorPort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.IndicatorPort = p),
				"threat.indicator.provider" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorProvider = p),
				"ThreatIndicatorProvider" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorProvider = p),
				"threat.indicator.reference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorReference = p),
				"ThreatIndicatorReference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorReference = p),
				"threat.indicator.scanner_stats" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.IndicatorScannerStats = p),
				"ThreatIndicatorScannerStats" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.IndicatorScannerStats = p),
				"threat.indicator.sightings" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.IndicatorSightings = p),
				"ThreatIndicatorSightings" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.IndicatorSightings = p),
				"threat.indicator.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorType = p),
				"ThreatIndicatorType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorType = p),
				"threat.software.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SoftwareId = p),
				"ThreatSoftwareId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SoftwareId = p),
				"threat.software.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SoftwareName = p),
				"ThreatSoftwareName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SoftwareName = p),
				"threat.software.reference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SoftwareReference = p),
				"ThreatSoftwareReference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SoftwareReference = p),
				"threat.software.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SoftwareType = p),
				"ThreatSoftwareType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SoftwareType = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Threat ?? new Threat();
			var assigned = assign(entity, value);
			if (assigned) document.Threat = entity;
			return assigned;
		}

		public static bool TrySetTls(EcsDocument document, string path, object value)
		{
			Func<Tls, object, bool> assign = path switch
			{
				"tls.cipher" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Cipher = p),
				"TlsCipher" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Cipher = p),
				"tls.client.certificate" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientCertificate = p),
				"TlsClientCertificate" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientCertificate = p),
				"tls.client.hash.md5" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientHashMd5 = p),
				"TlsClientHashMd5" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientHashMd5 = p),
				"tls.client.hash.sha1" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientHashSha1 = p),
				"TlsClientHashSha1" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientHashSha1 = p),
				"tls.client.hash.sha256" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientHashSha256 = p),
				"TlsClientHashSha256" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientHashSha256 = p),
				"tls.client.issuer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientIssuer = p),
				"TlsClientIssuer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientIssuer = p),
				"tls.client.ja3" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientJa3 = p),
				"TlsClientJa3" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientJa3 = p),
				"tls.client.not_after" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.ClientNotAfter = p),
				"TlsClientNotAfter" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.ClientNotAfter = p),
				"tls.client.not_before" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.ClientNotBefore = p),
				"TlsClientNotBefore" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.ClientNotBefore = p),
				"tls.client.server_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientServerName = p),
				"TlsClientServerName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientServerName = p),
				"tls.client.subject" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientSubject = p),
				"TlsClientSubject" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ClientSubject = p),
				"tls.curve" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Curve = p),
				"TlsCurve" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Curve = p),
				"tls.established" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Established = p),
				"TlsEstablished" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Established = p),
				"tls.next_protocol" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NextProtocol = p),
				"TlsNextProtocol" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NextProtocol = p),
				"tls.resumed" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Resumed = p),
				"TlsResumed" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Resumed = p),
				"tls.server.certificate" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerCertificate = p),
				"TlsServerCertificate" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerCertificate = p),
				"tls.server.hash.md5" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerHashMd5 = p),
				"TlsServerHashMd5" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerHashMd5 = p),
				"tls.server.hash.sha1" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerHashSha1 = p),
				"TlsServerHashSha1" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerHashSha1 = p),
				"tls.server.hash.sha256" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerHashSha256 = p),
				"TlsServerHashSha256" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerHashSha256 = p),
				"tls.server.issuer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerIssuer = p),
				"TlsServerIssuer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerIssuer = p),
				"tls.server.ja3s" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerJa3s = p),
				"TlsServerJa3s" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerJa3s = p),
				"tls.server.not_after" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.ServerNotAfter = p),
				"TlsServerNotAfter" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.ServerNotAfter = p),
				"tls.server.not_before" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.ServerNotBefore = p),
				"TlsServerNotBefore" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.ServerNotBefore = p),
				"tls.server.subject" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerSubject = p),
				"TlsServerSubject" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ServerSubject = p),
				"tls.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"TlsVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"tls.version_protocol" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.VersionProtocol = p),
				"TlsVersionProtocol" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.VersionProtocol = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Tls ?? new Tls();
			var assigned = assign(entity, value);
			if (assigned) document.Tls = entity;
			return assigned;
		}

		public static bool TrySetUrl(EcsDocument document, string path, object value)
		{
			Func<Url, object, bool> assign = path switch
			{
				"url.domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"UrlDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"url.extension" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Extension = p),
				"UrlExtension" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Extension = p),
				"url.fragment" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Fragment = p),
				"UrlFragment" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Fragment = p),
				"url.full" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Full = p),
				"UrlFull" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Full = p),
				"url.original" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Original = p),
				"UrlOriginal" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Original = p),
				"url.password" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Password = p),
				"UrlPassword" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Password = p),
				"url.path" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"UrlPath" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"url.port" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"UrlPort" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Port = p),
				"url.query" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Query = p),
				"UrlQuery" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Query = p),
				"url.registered_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"UrlRegisteredDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.RegisteredDomain = p),
				"url.scheme" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Scheme = p),
				"UrlScheme" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Scheme = p),
				"url.subdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"UrlSubdomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Subdomain = p),
				"url.top_level_domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				"UrlTopLevelDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TopLevelDomain = p),
				"url.username" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Username = p),
				"UrlUsername" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Username = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Url ?? new Url();
			var assigned = assign(entity, value);
			if (assigned) document.Url = entity;
			return assigned;
		}

		public static bool TrySetUser(EcsDocument document, string path, object value)
		{
			Func<User, object, bool> assign = path switch
			{
				"user.domain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"UserDomain" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Domain = p),
				"user.email" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Email = p),
				"UserEmail" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Email = p),
				"user.full_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FullName = p),
				"UserFullName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FullName = p),
				"user.hash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hash = p),
				"UserHash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Hash = p),
				"user.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"UserId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"user.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"UserName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.User ?? new User();
			var assigned = assign(entity, value);
			if (assigned) document.User = entity;
			return assigned;
		}

		public static bool TrySetUserAgent(EcsDocument document, string path, object value)
		{
			Func<UserAgent, object, bool> assign = path switch
			{
				"user_agent.device.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DeviceName = p),
				"UserAgentDeviceName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DeviceName = p),
				"user_agent.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"UserAgentName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"user_agent.original" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Original = p),
				"UserAgentOriginal" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Original = p),
				"user_agent.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"UserAgentVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.UserAgent ?? new UserAgent();
			var assigned = assign(entity, value);
			if (assigned) document.UserAgent = entity;
			return assigned;
		}

		public static bool TrySetVlan(EcsDocument document, string path, object value)
		{
			Func<Vlan, object, bool> assign = path switch
			{
				"vlan.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"VlanId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"vlan.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"VlanName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Vlan ?? new Vlan();
			var assigned = assign(entity, value);
			if (assigned) document.Vlan = entity;
			return assigned;
		}

		public static bool TrySetVulnerability(EcsDocument document, string path, object value)
		{
			Func<Vulnerability, object, bool> assign = path switch
			{
				"vulnerability.classification" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Classification = p),
				"VulnerabilityClassification" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Classification = p),
				"vulnerability.description" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Description = p),
				"VulnerabilityDescription" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Description = p),
				"vulnerability.enumeration" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Enumeration = p),
				"VulnerabilityEnumeration" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Enumeration = p),
				"vulnerability.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"VulnerabilityId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"vulnerability.reference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reference = p),
				"VulnerabilityReference" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Reference = p),
				"vulnerability.report_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ReportId = p),
				"VulnerabilityReportId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ReportId = p),
				"vulnerability.scanner.vendor" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ScannerVendor = p),
				"VulnerabilityScannerVendor" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ScannerVendor = p),
				"vulnerability.score.base" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.ScoreBase = p),
				"VulnerabilityScoreBase" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.ScoreBase = p),
				"vulnerability.score.environmental" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.ScoreEnvironmental = p),
				"VulnerabilityScoreEnvironmental" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.ScoreEnvironmental = p),
				"vulnerability.score.temporal" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.ScoreTemporal = p),
				"VulnerabilityScoreTemporal" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.ScoreTemporal = p),
				"vulnerability.score.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ScoreVersion = p),
				"VulnerabilityScoreVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ScoreVersion = p),
				"vulnerability.severity" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Severity = p),
				"VulnerabilitySeverity" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Severity = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Vulnerability ?? new Vulnerability();
			var assigned = assign(entity, value);
			if (assigned) document.Vulnerability = entity;
			return assigned;
		}

		public static bool TrySetX509(EcsDocument document, string path, object value)
		{
			Func<X509, object, bool> assign = path switch
			{
				"x509.issuer.distinguished_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IssuerDistinguishedName = p),
				"X509IssuerDistinguishedName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IssuerDistinguishedName = p),
				"x509.not_after" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.NotAfter = p),
				"X509NotAfter" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.NotAfter = p),
				"x509.not_before" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.NotBefore = p),
				"X509NotBefore" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.NotBefore = p),
				"x509.public_key_algorithm" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.PublicKeyAlgorithm = p),
				"X509PublicKeyAlgorithm" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.PublicKeyAlgorithm = p),
				"x509.public_key_curve" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.PublicKeyCurve = p),
				"X509PublicKeyCurve" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.PublicKeyCurve = p),
				"x509.public_key_exponent" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.PublicKeyExponent = p),
				"X509PublicKeyExponent" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.PublicKeyExponent = p),
				"x509.public_key_size" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.PublicKeySize = p),
				"X509PublicKeySize" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.PublicKeySize = p),
				"x509.serial_number" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SerialNumber = p),
				"X509SerialNumber" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SerialNumber = p),
				"x509.signature_algorithm" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SignatureAlgorithm = p),
				"X509SignatureAlgorithm" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SignatureAlgorithm = p),
				"x509.subject.distinguished_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SubjectDistinguishedName = p),
				"X509SubjectDistinguishedName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SubjectDistinguishedName = p),
				"x509.version_number" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.VersionNumber = p),
				"X509VersionNumber" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.VersionNumber = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.X509 ?? new X509();
			var assigned = assign(entity, value);
			if (assigned) document.X509 = entity;
			return assigned;
		}
	}
}
