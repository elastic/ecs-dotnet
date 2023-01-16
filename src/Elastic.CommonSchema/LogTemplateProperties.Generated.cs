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
	public static class LogTemplateProperties
	{
		public static string Timestamp = nameof(Timestamp);
		public static string Message = nameof(Message);
		public static string SpanId = nameof(SpanId);
		public static string TraceId = nameof(TraceId);
		public static string TransactionId = nameof(TransactionId);
		public static string AgentBuildOriginal = nameof(AgentBuildOriginal);
		public static string AgentEphemeralId = nameof(AgentEphemeralId);
		public static string AgentId = nameof(AgentId);
		public static string AgentName = nameof(AgentName);
		public static string AgentType = nameof(AgentType);
		public static string AgentVersion = nameof(AgentVersion);
		public static string AsNumber = nameof(AsNumber);
		public static string AsOrganizationName = nameof(AsOrganizationName);
		public static string ClientAddress = nameof(ClientAddress);
		public static string ClientBytes = nameof(ClientBytes);
		public static string ClientDomain = nameof(ClientDomain);
		public static string ClientIp = nameof(ClientIp);
		public static string ClientMac = nameof(ClientMac);
		public static string ClientNatIp = nameof(ClientNatIp);
		public static string ClientNatPort = nameof(ClientNatPort);
		public static string ClientPackets = nameof(ClientPackets);
		public static string ClientPort = nameof(ClientPort);
		public static string ClientRegisteredDomain = nameof(ClientRegisteredDomain);
		public static string ClientSubdomain = nameof(ClientSubdomain);
		public static string ClientTopLevelDomain = nameof(ClientTopLevelDomain);
		public static string CloudAccountId = nameof(CloudAccountId);
		public static string CloudAccountName = nameof(CloudAccountName);
		public static string CloudAvailabilityZone = nameof(CloudAvailabilityZone);
		public static string CloudInstanceId = nameof(CloudInstanceId);
		public static string CloudInstanceName = nameof(CloudInstanceName);
		public static string CloudMachineType = nameof(CloudMachineType);
		public static string CloudProjectId = nameof(CloudProjectId);
		public static string CloudProjectName = nameof(CloudProjectName);
		public static string CloudProvider = nameof(CloudProvider);
		public static string CloudRegion = nameof(CloudRegion);
		public static string CloudServiceName = nameof(CloudServiceName);
		public static string CodeSignatureDigestAlgorithm = nameof(CodeSignatureDigestAlgorithm);
		public static string CodeSignatureExists = nameof(CodeSignatureExists);
		public static string CodeSignatureSigningId = nameof(CodeSignatureSigningId);
		public static string CodeSignatureStatus = nameof(CodeSignatureStatus);
		public static string CodeSignatureSubjectName = nameof(CodeSignatureSubjectName);
		public static string CodeSignatureTeamId = nameof(CodeSignatureTeamId);
		public static string CodeSignatureTimestamp = nameof(CodeSignatureTimestamp);
		public static string CodeSignatureTrusted = nameof(CodeSignatureTrusted);
		public static string CodeSignatureValid = nameof(CodeSignatureValid);
		public static string ContainerCpuUsage = nameof(ContainerCpuUsage);
		public static string ContainerDiskReadBytes = nameof(ContainerDiskReadBytes);
		public static string ContainerDiskWriteBytes = nameof(ContainerDiskWriteBytes);
		public static string ContainerId = nameof(ContainerId);
		public static string ContainerImageName = nameof(ContainerImageName);
		public static string ContainerMemoryUsage = nameof(ContainerMemoryUsage);
		public static string ContainerName = nameof(ContainerName);
		public static string ContainerNetworkEgressBytes = nameof(ContainerNetworkEgressBytes);
		public static string ContainerNetworkIngressBytes = nameof(ContainerNetworkIngressBytes);
		public static string ContainerRuntime = nameof(ContainerRuntime);
		public static string DataStreamDataset = nameof(DataStreamDataset);
		public static string DataStreamNamespace = nameof(DataStreamNamespace);
		public static string DataStreamType = nameof(DataStreamType);
		public static string DestinationAddress = nameof(DestinationAddress);
		public static string DestinationBytes = nameof(DestinationBytes);
		public static string DestinationDomain = nameof(DestinationDomain);
		public static string DestinationIp = nameof(DestinationIp);
		public static string DestinationMac = nameof(DestinationMac);
		public static string DestinationNatIp = nameof(DestinationNatIp);
		public static string DestinationNatPort = nameof(DestinationNatPort);
		public static string DestinationPackets = nameof(DestinationPackets);
		public static string DestinationPort = nameof(DestinationPort);
		public static string DestinationRegisteredDomain = nameof(DestinationRegisteredDomain);
		public static string DestinationSubdomain = nameof(DestinationSubdomain);
		public static string DestinationTopLevelDomain = nameof(DestinationTopLevelDomain);
		public static string DllName = nameof(DllName);
		public static string DllPath = nameof(DllPath);
		public static string DnsId = nameof(DnsId);
		public static string DnsOpCode = nameof(DnsOpCode);
		public static string DnsQuestionClass = nameof(DnsQuestionClass);
		public static string DnsQuestionName = nameof(DnsQuestionName);
		public static string DnsQuestionRegisteredDomain = nameof(DnsQuestionRegisteredDomain);
		public static string DnsQuestionSubdomain = nameof(DnsQuestionSubdomain);
		public static string DnsQuestionTopLevelDomain = nameof(DnsQuestionTopLevelDomain);
		public static string DnsQuestionType = nameof(DnsQuestionType);
		public static string DnsResponseCode = nameof(DnsResponseCode);
		public static string DnsType = nameof(DnsType);
		public static string EcsVersion = nameof(EcsVersion);
		public static string ElfArchitecture = nameof(ElfArchitecture);
		public static string ElfByteOrder = nameof(ElfByteOrder);
		public static string ElfCpuType = nameof(ElfCpuType);
		public static string ElfCreationDate = nameof(ElfCreationDate);
		public static string ElfHeaderAbiVersion = nameof(ElfHeaderAbiVersion);
		public static string ElfHeaderClass = nameof(ElfHeaderClass);
		public static string ElfHeaderData = nameof(ElfHeaderData);
		public static string ElfHeaderEntrypoint = nameof(ElfHeaderEntrypoint);
		public static string ElfHeaderObjectVersion = nameof(ElfHeaderObjectVersion);
		public static string ElfHeaderOsAbi = nameof(ElfHeaderOsAbi);
		public static string ElfHeaderType = nameof(ElfHeaderType);
		public static string ElfHeaderVersion = nameof(ElfHeaderVersion);
		public static string ElfTelfhash = nameof(ElfTelfhash);
		public static string EmailContentType = nameof(EmailContentType);
		public static string EmailDeliveryTimestamp = nameof(EmailDeliveryTimestamp);
		public static string EmailDirection = nameof(EmailDirection);
		public static string EmailLocalId = nameof(EmailLocalId);
		public static string EmailMessageId = nameof(EmailMessageId);
		public static string EmailOriginationTimestamp = nameof(EmailOriginationTimestamp);
		public static string EmailSenderAddress = nameof(EmailSenderAddress);
		public static string EmailSubject = nameof(EmailSubject);
		public static string EmailXMailer = nameof(EmailXMailer);
		public static string ErrorCode = nameof(ErrorCode);
		public static string ErrorId = nameof(ErrorId);
		public static string ErrorMessage = nameof(ErrorMessage);
		public static string ErrorStackTrace = nameof(ErrorStackTrace);
		public static string ErrorType = nameof(ErrorType);
		public static string EventAction = nameof(EventAction);
		public static string EventAgentIdStatus = nameof(EventAgentIdStatus);
		public static string EventCode = nameof(EventCode);
		public static string EventCreated = nameof(EventCreated);
		public static string EventDataset = nameof(EventDataset);
		public static string EventDuration = nameof(EventDuration);
		public static string EventEnd = nameof(EventEnd);
		public static string EventHash = nameof(EventHash);
		public static string EventId = nameof(EventId);
		public static string EventIngested = nameof(EventIngested);
		public static string EventKind = nameof(EventKind);
		public static string EventModule = nameof(EventModule);
		public static string EventOriginal = nameof(EventOriginal);
		public static string EventOutcome = nameof(EventOutcome);
		public static string EventProvider = nameof(EventProvider);
		public static string EventReason = nameof(EventReason);
		public static string EventReference = nameof(EventReference);
		public static string EventRiskScore = nameof(EventRiskScore);
		public static string EventRiskScoreNorm = nameof(EventRiskScoreNorm);
		public static string EventSequence = nameof(EventSequence);
		public static string EventSeverity = nameof(EventSeverity);
		public static string EventStart = nameof(EventStart);
		public static string EventTimezone = nameof(EventTimezone);
		public static string EventUrl = nameof(EventUrl);
		public static string FaasColdstart = nameof(FaasColdstart);
		public static string FaasExecution = nameof(FaasExecution);
		public static string FaasId = nameof(FaasId);
		public static string FaasName = nameof(FaasName);
		public static string FaasVersion = nameof(FaasVersion);
		public static string FileAccessed = nameof(FileAccessed);
		public static string FileCreated = nameof(FileCreated);
		public static string FileCtime = nameof(FileCtime);
		public static string FileDevice = nameof(FileDevice);
		public static string FileDirectory = nameof(FileDirectory);
		public static string FileDriveLetter = nameof(FileDriveLetter);
		public static string FileExtension = nameof(FileExtension);
		public static string FileForkName = nameof(FileForkName);
		public static string FileGid = nameof(FileGid);
		public static string FileGroup = nameof(FileGroup);
		public static string FileInode = nameof(FileInode);
		public static string FileMimeType = nameof(FileMimeType);
		public static string FileMode = nameof(FileMode);
		public static string FileMtime = nameof(FileMtime);
		public static string FileName = nameof(FileName);
		public static string FileOwner = nameof(FileOwner);
		public static string FilePath = nameof(FilePath);
		public static string FileSize = nameof(FileSize);
		public static string FileTargetPath = nameof(FileTargetPath);
		public static string FileType = nameof(FileType);
		public static string FileUid = nameof(FileUid);
		public static string GeoCityName = nameof(GeoCityName);
		public static string GeoContinentCode = nameof(GeoContinentCode);
		public static string GeoContinentName = nameof(GeoContinentName);
		public static string GeoCountryIsoCode = nameof(GeoCountryIsoCode);
		public static string GeoCountryName = nameof(GeoCountryName);
		public static string GeoName = nameof(GeoName);
		public static string GeoPostalCode = nameof(GeoPostalCode);
		public static string GeoRegionIsoCode = nameof(GeoRegionIsoCode);
		public static string GeoRegionName = nameof(GeoRegionName);
		public static string GeoTimezone = nameof(GeoTimezone);
		public static string GroupDomain = nameof(GroupDomain);
		public static string GroupId = nameof(GroupId);
		public static string GroupName = nameof(GroupName);
		public static string HashMd5 = nameof(HashMd5);
		public static string HashSha1 = nameof(HashSha1);
		public static string HashSha256 = nameof(HashSha256);
		public static string HashSha384 = nameof(HashSha384);
		public static string HashSha512 = nameof(HashSha512);
		public static string HashSsdeep = nameof(HashSsdeep);
		public static string HashTlsh = nameof(HashTlsh);
		public static string HostArchitecture = nameof(HostArchitecture);
		public static string HostBootId = nameof(HostBootId);
		public static string HostCpuUsage = nameof(HostCpuUsage);
		public static string HostDiskReadBytes = nameof(HostDiskReadBytes);
		public static string HostDiskWriteBytes = nameof(HostDiskWriteBytes);
		public static string HostDomain = nameof(HostDomain);
		public static string HostHostname = nameof(HostHostname);
		public static string HostId = nameof(HostId);
		public static string HostName = nameof(HostName);
		public static string HostNetworkEgressBytes = nameof(HostNetworkEgressBytes);
		public static string HostNetworkEgressPackets = nameof(HostNetworkEgressPackets);
		public static string HostNetworkIngressBytes = nameof(HostNetworkIngressBytes);
		public static string HostNetworkIngressPackets = nameof(HostNetworkIngressPackets);
		public static string HostPidNsIno = nameof(HostPidNsIno);
		public static string HostType = nameof(HostType);
		public static string HostUptime = nameof(HostUptime);
		public static string HttpRequestBodyBytes = nameof(HttpRequestBodyBytes);
		public static string HttpRequestBodyContent = nameof(HttpRequestBodyContent);
		public static string HttpRequestBytes = nameof(HttpRequestBytes);
		public static string HttpRequestId = nameof(HttpRequestId);
		public static string HttpRequestMethod = nameof(HttpRequestMethod);
		public static string HttpRequestMimeType = nameof(HttpRequestMimeType);
		public static string HttpRequestReferrer = nameof(HttpRequestReferrer);
		public static string HttpResponseBodyBytes = nameof(HttpResponseBodyBytes);
		public static string HttpResponseBodyContent = nameof(HttpResponseBodyContent);
		public static string HttpResponseBytes = nameof(HttpResponseBytes);
		public static string HttpResponseMimeType = nameof(HttpResponseMimeType);
		public static string HttpResponseStatusCode = nameof(HttpResponseStatusCode);
		public static string HttpVersion = nameof(HttpVersion);
		public static string InterfaceAlias = nameof(InterfaceAlias);
		public static string InterfaceId = nameof(InterfaceId);
		public static string InterfaceName = nameof(InterfaceName);
		public static string LogFilePath = nameof(LogFilePath);
		public static string LogLevel = nameof(LogLevel);
		public static string LogLogger = nameof(LogLogger);
		public static string LogOriginFileLine = nameof(LogOriginFileLine);
		public static string LogOriginFileName = nameof(LogOriginFileName);
		public static string LogOriginFunction = nameof(LogOriginFunction);
		public static string NetworkApplication = nameof(NetworkApplication);
		public static string NetworkBytes = nameof(NetworkBytes);
		public static string NetworkCommunityId = nameof(NetworkCommunityId);
		public static string NetworkDirection = nameof(NetworkDirection);
		public static string NetworkForwardedIp = nameof(NetworkForwardedIp);
		public static string NetworkIanaNumber = nameof(NetworkIanaNumber);
		public static string NetworkName = nameof(NetworkName);
		public static string NetworkPackets = nameof(NetworkPackets);
		public static string NetworkProtocol = nameof(NetworkProtocol);
		public static string NetworkTransport = nameof(NetworkTransport);
		public static string NetworkType = nameof(NetworkType);
		public static string ObserverHostname = nameof(ObserverHostname);
		public static string ObserverName = nameof(ObserverName);
		public static string ObserverProduct = nameof(ObserverProduct);
		public static string ObserverSerialNumber = nameof(ObserverSerialNumber);
		public static string ObserverType = nameof(ObserverType);
		public static string ObserverVendor = nameof(ObserverVendor);
		public static string ObserverVersion = nameof(ObserverVersion);
		public static string OrchestratorApiVersion = nameof(OrchestratorApiVersion);
		public static string OrchestratorClusterId = nameof(OrchestratorClusterId);
		public static string OrchestratorClusterName = nameof(OrchestratorClusterName);
		public static string OrchestratorClusterUrl = nameof(OrchestratorClusterUrl);
		public static string OrchestratorClusterVersion = nameof(OrchestratorClusterVersion);
		public static string OrchestratorNamespace = nameof(OrchestratorNamespace);
		public static string OrchestratorOrganization = nameof(OrchestratorOrganization);
		public static string OrchestratorResourceId = nameof(OrchestratorResourceId);
		public static string OrchestratorResourceName = nameof(OrchestratorResourceName);
		public static string OrchestratorResourceParentType = nameof(OrchestratorResourceParentType);
		public static string OrchestratorResourceType = nameof(OrchestratorResourceType);
		public static string OrchestratorType = nameof(OrchestratorType);
		public static string OrganizationId = nameof(OrganizationId);
		public static string OrganizationName = nameof(OrganizationName);
		public static string OsFamily = nameof(OsFamily);
		public static string OsFull = nameof(OsFull);
		public static string OsKernel = nameof(OsKernel);
		public static string OsName = nameof(OsName);
		public static string OsPlatform = nameof(OsPlatform);
		public static string OsType = nameof(OsType);
		public static string OsVersion = nameof(OsVersion);
		public static string PackageArchitecture = nameof(PackageArchitecture);
		public static string PackageBuildVersion = nameof(PackageBuildVersion);
		public static string PackageChecksum = nameof(PackageChecksum);
		public static string PackageDescription = nameof(PackageDescription);
		public static string PackageInstallScope = nameof(PackageInstallScope);
		public static string PackageInstalled = nameof(PackageInstalled);
		public static string PackageLicense = nameof(PackageLicense);
		public static string PackageName = nameof(PackageName);
		public static string PackagePath = nameof(PackagePath);
		public static string PackageReference = nameof(PackageReference);
		public static string PackageSize = nameof(PackageSize);
		public static string PackageType = nameof(PackageType);
		public static string PackageVersion = nameof(PackageVersion);
		public static string PeArchitecture = nameof(PeArchitecture);
		public static string PeCompany = nameof(PeCompany);
		public static string PeDescription = nameof(PeDescription);
		public static string PeFileVersion = nameof(PeFileVersion);
		public static string PeImphash = nameof(PeImphash);
		public static string PeOriginalFileName = nameof(PeOriginalFileName);
		public static string PePehash = nameof(PePehash);
		public static string PeProduct = nameof(PeProduct);
		public static string ProcessArgsCount = nameof(ProcessArgsCount);
		public static string ProcessCommandLine = nameof(ProcessCommandLine);
		public static string ProcessEnd = nameof(ProcessEnd);
		public static string ProcessEntityId = nameof(ProcessEntityId);
		public static string ProcessExecutable = nameof(ProcessExecutable);
		public static string ProcessExitCode = nameof(ProcessExitCode);
		public static string ProcessInteractive = nameof(ProcessInteractive);
		public static string ProcessName = nameof(ProcessName);
		public static string ProcessPgid = nameof(ProcessPgid);
		public static string ProcessPid = nameof(ProcessPid);
		public static string ProcessStart = nameof(ProcessStart);
		public static string ProcessThreadId = nameof(ProcessThreadId);
		public static string ProcessThreadName = nameof(ProcessThreadName);
		public static string ProcessTitle = nameof(ProcessTitle);
		public static string ProcessUptime = nameof(ProcessUptime);
		public static string ProcessWorkingDirectory = nameof(ProcessWorkingDirectory);
		public static string RegistryDataBytes = nameof(RegistryDataBytes);
		public static string RegistryDataType = nameof(RegistryDataType);
		public static string RegistryHive = nameof(RegistryHive);
		public static string RegistryKey = nameof(RegistryKey);
		public static string RegistryPath = nameof(RegistryPath);
		public static string RegistryValue = nameof(RegistryValue);
		public static string RuleCategory = nameof(RuleCategory);
		public static string RuleDescription = nameof(RuleDescription);
		public static string RuleId = nameof(RuleId);
		public static string RuleLicense = nameof(RuleLicense);
		public static string RuleName = nameof(RuleName);
		public static string RuleReference = nameof(RuleReference);
		public static string RuleRuleset = nameof(RuleRuleset);
		public static string RuleUuid = nameof(RuleUuid);
		public static string RuleVersion = nameof(RuleVersion);
		public static string ServerAddress = nameof(ServerAddress);
		public static string ServerBytes = nameof(ServerBytes);
		public static string ServerDomain = nameof(ServerDomain);
		public static string ServerIp = nameof(ServerIp);
		public static string ServerMac = nameof(ServerMac);
		public static string ServerNatIp = nameof(ServerNatIp);
		public static string ServerNatPort = nameof(ServerNatPort);
		public static string ServerPackets = nameof(ServerPackets);
		public static string ServerPort = nameof(ServerPort);
		public static string ServerRegisteredDomain = nameof(ServerRegisteredDomain);
		public static string ServerSubdomain = nameof(ServerSubdomain);
		public static string ServerTopLevelDomain = nameof(ServerTopLevelDomain);
		public static string ServiceAddress = nameof(ServiceAddress);
		public static string ServiceEnvironment = nameof(ServiceEnvironment);
		public static string ServiceEphemeralId = nameof(ServiceEphemeralId);
		public static string ServiceId = nameof(ServiceId);
		public static string ServiceName = nameof(ServiceName);
		public static string ServiceNodeName = nameof(ServiceNodeName);
		public static string ServiceNodeRole = nameof(ServiceNodeRole);
		public static string ServiceState = nameof(ServiceState);
		public static string ServiceType = nameof(ServiceType);
		public static string ServiceVersion = nameof(ServiceVersion);
		public static string SourceAddress = nameof(SourceAddress);
		public static string SourceBytes = nameof(SourceBytes);
		public static string SourceDomain = nameof(SourceDomain);
		public static string SourceIp = nameof(SourceIp);
		public static string SourceMac = nameof(SourceMac);
		public static string SourceNatIp = nameof(SourceNatIp);
		public static string SourceNatPort = nameof(SourceNatPort);
		public static string SourcePackets = nameof(SourcePackets);
		public static string SourcePort = nameof(SourcePort);
		public static string SourceRegisteredDomain = nameof(SourceRegisteredDomain);
		public static string SourceSubdomain = nameof(SourceSubdomain);
		public static string SourceTopLevelDomain = nameof(SourceTopLevelDomain);
		public static string ThreatFeedDashboardId = nameof(ThreatFeedDashboardId);
		public static string ThreatFeedDescription = nameof(ThreatFeedDescription);
		public static string ThreatFeedName = nameof(ThreatFeedName);
		public static string ThreatFeedReference = nameof(ThreatFeedReference);
		public static string ThreatFramework = nameof(ThreatFramework);
		public static string ThreatGroupId = nameof(ThreatGroupId);
		public static string ThreatGroupName = nameof(ThreatGroupName);
		public static string ThreatGroupReference = nameof(ThreatGroupReference);
		public static string ThreatIndicatorConfidence = nameof(ThreatIndicatorConfidence);
		public static string ThreatIndicatorDescription = nameof(ThreatIndicatorDescription);
		public static string ThreatIndicatorEmailAddress = nameof(ThreatIndicatorEmailAddress);
		public static string ThreatIndicatorFirstSeen = nameof(ThreatIndicatorFirstSeen);
		public static string ThreatIndicatorIp = nameof(ThreatIndicatorIp);
		public static string ThreatIndicatorLastSeen = nameof(ThreatIndicatorLastSeen);
		public static string ThreatIndicatorMarkingTlp = nameof(ThreatIndicatorMarkingTlp);
		public static string ThreatIndicatorModifiedAt = nameof(ThreatIndicatorModifiedAt);
		public static string ThreatIndicatorPort = nameof(ThreatIndicatorPort);
		public static string ThreatIndicatorProvider = nameof(ThreatIndicatorProvider);
		public static string ThreatIndicatorReference = nameof(ThreatIndicatorReference);
		public static string ThreatIndicatorScannerStats = nameof(ThreatIndicatorScannerStats);
		public static string ThreatIndicatorSightings = nameof(ThreatIndicatorSightings);
		public static string ThreatIndicatorType = nameof(ThreatIndicatorType);
		public static string ThreatSoftwareId = nameof(ThreatSoftwareId);
		public static string ThreatSoftwareName = nameof(ThreatSoftwareName);
		public static string ThreatSoftwareReference = nameof(ThreatSoftwareReference);
		public static string ThreatSoftwareType = nameof(ThreatSoftwareType);
		public static string TlsCipher = nameof(TlsCipher);
		public static string TlsClientCertificate = nameof(TlsClientCertificate);
		public static string TlsClientHashMd5 = nameof(TlsClientHashMd5);
		public static string TlsClientHashSha1 = nameof(TlsClientHashSha1);
		public static string TlsClientHashSha256 = nameof(TlsClientHashSha256);
		public static string TlsClientIssuer = nameof(TlsClientIssuer);
		public static string TlsClientJa3 = nameof(TlsClientJa3);
		public static string TlsClientNotAfter = nameof(TlsClientNotAfter);
		public static string TlsClientNotBefore = nameof(TlsClientNotBefore);
		public static string TlsClientServerName = nameof(TlsClientServerName);
		public static string TlsClientSubject = nameof(TlsClientSubject);
		public static string TlsCurve = nameof(TlsCurve);
		public static string TlsEstablished = nameof(TlsEstablished);
		public static string TlsNextProtocol = nameof(TlsNextProtocol);
		public static string TlsResumed = nameof(TlsResumed);
		public static string TlsServerCertificate = nameof(TlsServerCertificate);
		public static string TlsServerHashMd5 = nameof(TlsServerHashMd5);
		public static string TlsServerHashSha1 = nameof(TlsServerHashSha1);
		public static string TlsServerHashSha256 = nameof(TlsServerHashSha256);
		public static string TlsServerIssuer = nameof(TlsServerIssuer);
		public static string TlsServerJa3s = nameof(TlsServerJa3s);
		public static string TlsServerNotAfter = nameof(TlsServerNotAfter);
		public static string TlsServerNotBefore = nameof(TlsServerNotBefore);
		public static string TlsServerSubject = nameof(TlsServerSubject);
		public static string TlsVersion = nameof(TlsVersion);
		public static string TlsVersionProtocol = nameof(TlsVersionProtocol);
		public static string UrlDomain = nameof(UrlDomain);
		public static string UrlExtension = nameof(UrlExtension);
		public static string UrlFragment = nameof(UrlFragment);
		public static string UrlFull = nameof(UrlFull);
		public static string UrlOriginal = nameof(UrlOriginal);
		public static string UrlPassword = nameof(UrlPassword);
		public static string UrlPath = nameof(UrlPath);
		public static string UrlPort = nameof(UrlPort);
		public static string UrlQuery = nameof(UrlQuery);
		public static string UrlRegisteredDomain = nameof(UrlRegisteredDomain);
		public static string UrlScheme = nameof(UrlScheme);
		public static string UrlSubdomain = nameof(UrlSubdomain);
		public static string UrlTopLevelDomain = nameof(UrlTopLevelDomain);
		public static string UrlUsername = nameof(UrlUsername);
		public static string UserDomain = nameof(UserDomain);
		public static string UserEmail = nameof(UserEmail);
		public static string UserFullName = nameof(UserFullName);
		public static string UserHash = nameof(UserHash);
		public static string UserId = nameof(UserId);
		public static string UserName = nameof(UserName);
		public static string UserAgentDeviceName = nameof(UserAgentDeviceName);
		public static string UserAgentName = nameof(UserAgentName);
		public static string UserAgentOriginal = nameof(UserAgentOriginal);
		public static string UserAgentVersion = nameof(UserAgentVersion);
		public static string VlanId = nameof(VlanId);
		public static string VlanName = nameof(VlanName);
		public static string VulnerabilityClassification = nameof(VulnerabilityClassification);
		public static string VulnerabilityDescription = nameof(VulnerabilityDescription);
		public static string VulnerabilityEnumeration = nameof(VulnerabilityEnumeration);
		public static string VulnerabilityId = nameof(VulnerabilityId);
		public static string VulnerabilityReference = nameof(VulnerabilityReference);
		public static string VulnerabilityReportId = nameof(VulnerabilityReportId);
		public static string VulnerabilityScannerVendor = nameof(VulnerabilityScannerVendor);
		public static string VulnerabilityScoreBase = nameof(VulnerabilityScoreBase);
		public static string VulnerabilityScoreEnvironmental = nameof(VulnerabilityScoreEnvironmental);
		public static string VulnerabilityScoreTemporal = nameof(VulnerabilityScoreTemporal);
		public static string VulnerabilityScoreVersion = nameof(VulnerabilityScoreVersion);
		public static string VulnerabilitySeverity = nameof(VulnerabilitySeverity);
		public static string X509IssuerDistinguishedName = nameof(X509IssuerDistinguishedName);
		public static string X509NotAfter = nameof(X509NotAfter);
		public static string X509NotBefore = nameof(X509NotBefore);
		public static string X509PublicKeyAlgorithm = nameof(X509PublicKeyAlgorithm);
		public static string X509PublicKeyCurve = nameof(X509PublicKeyCurve);
		public static string X509PublicKeyExponent = nameof(X509PublicKeyExponent);
		public static string X509PublicKeySize = nameof(X509PublicKeySize);
		public static string X509SerialNumber = nameof(X509SerialNumber);
		public static string X509SignatureAlgorithm = nameof(X509SignatureAlgorithm);
		public static string X509SubjectDistinguishedName = nameof(X509SubjectDistinguishedName);
		public static string X509VersionNumber = nameof(X509VersionNumber);

		public static readonly HashSet<string> All = new()
		{
			"@timestamp", Timestamp,
			"message", Message,
			"span.id", SpanId,
			"trace.id", TraceId,
			"transaction.id", TransactionId,
			"agent.build.original", AgentBuildOriginal,
			"agent.ephemeral_id", AgentEphemeralId,
			"agent.id", AgentId,
			"agent.name", AgentName,
			"agent.type", AgentType,
			"agent.version", AgentVersion,
			"as.number", AsNumber,
			"as.organization.name", AsOrganizationName,
			"client.address", ClientAddress,
			"client.bytes", ClientBytes,
			"client.domain", ClientDomain,
			"client.ip", ClientIp,
			"client.mac", ClientMac,
			"client.nat.ip", ClientNatIp,
			"client.nat.port", ClientNatPort,
			"client.packets", ClientPackets,
			"client.port", ClientPort,
			"client.registered_domain", ClientRegisteredDomain,
			"client.subdomain", ClientSubdomain,
			"client.top_level_domain", ClientTopLevelDomain,
			"cloud.account.id", CloudAccountId,
			"cloud.account.name", CloudAccountName,
			"cloud.availability_zone", CloudAvailabilityZone,
			"cloud.instance.id", CloudInstanceId,
			"cloud.instance.name", CloudInstanceName,
			"cloud.machine.type", CloudMachineType,
			"cloud.project.id", CloudProjectId,
			"cloud.project.name", CloudProjectName,
			"cloud.provider", CloudProvider,
			"cloud.region", CloudRegion,
			"cloud.service.name", CloudServiceName,
			"code_signature.digest_algorithm", CodeSignatureDigestAlgorithm,
			"code_signature.exists", CodeSignatureExists,
			"code_signature.signing_id", CodeSignatureSigningId,
			"code_signature.status", CodeSignatureStatus,
			"code_signature.subject_name", CodeSignatureSubjectName,
			"code_signature.team_id", CodeSignatureTeamId,
			"code_signature.timestamp", CodeSignatureTimestamp,
			"code_signature.trusted", CodeSignatureTrusted,
			"code_signature.valid", CodeSignatureValid,
			"container.cpu.usage", ContainerCpuUsage,
			"container.disk.read.bytes", ContainerDiskReadBytes,
			"container.disk.write.bytes", ContainerDiskWriteBytes,
			"container.id", ContainerId,
			"container.image.name", ContainerImageName,
			"container.memory.usage", ContainerMemoryUsage,
			"container.name", ContainerName,
			"container.network.egress.bytes", ContainerNetworkEgressBytes,
			"container.network.ingress.bytes", ContainerNetworkIngressBytes,
			"container.runtime", ContainerRuntime,
			"data_stream.dataset", DataStreamDataset,
			"data_stream.namespace", DataStreamNamespace,
			"data_stream.type", DataStreamType,
			"destination.address", DestinationAddress,
			"destination.bytes", DestinationBytes,
			"destination.domain", DestinationDomain,
			"destination.ip", DestinationIp,
			"destination.mac", DestinationMac,
			"destination.nat.ip", DestinationNatIp,
			"destination.nat.port", DestinationNatPort,
			"destination.packets", DestinationPackets,
			"destination.port", DestinationPort,
			"destination.registered_domain", DestinationRegisteredDomain,
			"destination.subdomain", DestinationSubdomain,
			"destination.top_level_domain", DestinationTopLevelDomain,
			"dll.name", DllName,
			"dll.path", DllPath,
			"dns.id", DnsId,
			"dns.op_code", DnsOpCode,
			"dns.question.class", DnsQuestionClass,
			"dns.question.name", DnsQuestionName,
			"dns.question.registered_domain", DnsQuestionRegisteredDomain,
			"dns.question.subdomain", DnsQuestionSubdomain,
			"dns.question.top_level_domain", DnsQuestionTopLevelDomain,
			"dns.question.type", DnsQuestionType,
			"dns.response_code", DnsResponseCode,
			"dns.type", DnsType,
			"ecs.version", EcsVersion,
			"elf.architecture", ElfArchitecture,
			"elf.byte_order", ElfByteOrder,
			"elf.cpu_type", ElfCpuType,
			"elf.creation_date", ElfCreationDate,
			"elf.header.abi_version", ElfHeaderAbiVersion,
			"elf.header.class", ElfHeaderClass,
			"elf.header.data", ElfHeaderData,
			"elf.header.entrypoint", ElfHeaderEntrypoint,
			"elf.header.object_version", ElfHeaderObjectVersion,
			"elf.header.os_abi", ElfHeaderOsAbi,
			"elf.header.type", ElfHeaderType,
			"elf.header.version", ElfHeaderVersion,
			"elf.telfhash", ElfTelfhash,
			"email.content_type", EmailContentType,
			"email.delivery_timestamp", EmailDeliveryTimestamp,
			"email.direction", EmailDirection,
			"email.local_id", EmailLocalId,
			"email.message_id", EmailMessageId,
			"email.origination_timestamp", EmailOriginationTimestamp,
			"email.sender.address", EmailSenderAddress,
			"email.subject", EmailSubject,
			"email.x_mailer", EmailXMailer,
			"error.code", ErrorCode,
			"error.id", ErrorId,
			"error.message", ErrorMessage,
			"error.stack_trace", ErrorStackTrace,
			"error.type", ErrorType,
			"event.action", EventAction,
			"event.agent_id_status", EventAgentIdStatus,
			"event.code", EventCode,
			"event.created", EventCreated,
			"event.dataset", EventDataset,
			"event.duration", EventDuration,
			"event.end", EventEnd,
			"event.hash", EventHash,
			"event.id", EventId,
			"event.ingested", EventIngested,
			"event.kind", EventKind,
			"event.module", EventModule,
			"event.original", EventOriginal,
			"event.outcome", EventOutcome,
			"event.provider", EventProvider,
			"event.reason", EventReason,
			"event.reference", EventReference,
			"event.risk_score", EventRiskScore,
			"event.risk_score_norm", EventRiskScoreNorm,
			"event.sequence", EventSequence,
			"event.severity", EventSeverity,
			"event.start", EventStart,
			"event.timezone", EventTimezone,
			"event.url", EventUrl,
			"faas.coldstart", FaasColdstart,
			"faas.execution", FaasExecution,
			"faas.id", FaasId,
			"faas.name", FaasName,
			"faas.version", FaasVersion,
			"file.accessed", FileAccessed,
			"file.created", FileCreated,
			"file.ctime", FileCtime,
			"file.device", FileDevice,
			"file.directory", FileDirectory,
			"file.drive_letter", FileDriveLetter,
			"file.extension", FileExtension,
			"file.fork_name", FileForkName,
			"file.gid", FileGid,
			"file.group", FileGroup,
			"file.inode", FileInode,
			"file.mime_type", FileMimeType,
			"file.mode", FileMode,
			"file.mtime", FileMtime,
			"file.name", FileName,
			"file.owner", FileOwner,
			"file.path", FilePath,
			"file.size", FileSize,
			"file.target_path", FileTargetPath,
			"file.type", FileType,
			"file.uid", FileUid,
			"geo.city_name", GeoCityName,
			"geo.continent_code", GeoContinentCode,
			"geo.continent_name", GeoContinentName,
			"geo.country_iso_code", GeoCountryIsoCode,
			"geo.country_name", GeoCountryName,
			"geo.name", GeoName,
			"geo.postal_code", GeoPostalCode,
			"geo.region_iso_code", GeoRegionIsoCode,
			"geo.region_name", GeoRegionName,
			"geo.timezone", GeoTimezone,
			"group.domain", GroupDomain,
			"group.id", GroupId,
			"group.name", GroupName,
			"hash.md5", HashMd5,
			"hash.sha1", HashSha1,
			"hash.sha256", HashSha256,
			"hash.sha384", HashSha384,
			"hash.sha512", HashSha512,
			"hash.ssdeep", HashSsdeep,
			"hash.tlsh", HashTlsh,
			"host.architecture", HostArchitecture,
			"host.boot.id", HostBootId,
			"host.cpu.usage", HostCpuUsage,
			"host.disk.read.bytes", HostDiskReadBytes,
			"host.disk.write.bytes", HostDiskWriteBytes,
			"host.domain", HostDomain,
			"host.hostname", HostHostname,
			"host.id", HostId,
			"host.name", HostName,
			"host.network.egress.bytes", HostNetworkEgressBytes,
			"host.network.egress.packets", HostNetworkEgressPackets,
			"host.network.ingress.bytes", HostNetworkIngressBytes,
			"host.network.ingress.packets", HostNetworkIngressPackets,
			"host.pid_ns_ino", HostPidNsIno,
			"host.type", HostType,
			"host.uptime", HostUptime,
			"http.request.body.bytes", HttpRequestBodyBytes,
			"http.request.body.content", HttpRequestBodyContent,
			"http.request.bytes", HttpRequestBytes,
			"http.request.id", HttpRequestId,
			"http.request.method", HttpRequestMethod,
			"http.request.mime_type", HttpRequestMimeType,
			"http.request.referrer", HttpRequestReferrer,
			"http.response.body.bytes", HttpResponseBodyBytes,
			"http.response.body.content", HttpResponseBodyContent,
			"http.response.bytes", HttpResponseBytes,
			"http.response.mime_type", HttpResponseMimeType,
			"http.response.status_code", HttpResponseStatusCode,
			"http.version", HttpVersion,
			"interface.alias", InterfaceAlias,
			"interface.id", InterfaceId,
			"interface.name", InterfaceName,
			"log.file.path", LogFilePath,
			"log.level", LogLevel,
			"log.logger", LogLogger,
			"log.origin.file.line", LogOriginFileLine,
			"log.origin.file.name", LogOriginFileName,
			"log.origin.function", LogOriginFunction,
			"network.application", NetworkApplication,
			"network.bytes", NetworkBytes,
			"network.community_id", NetworkCommunityId,
			"network.direction", NetworkDirection,
			"network.forwarded_ip", NetworkForwardedIp,
			"network.iana_number", NetworkIanaNumber,
			"network.name", NetworkName,
			"network.packets", NetworkPackets,
			"network.protocol", NetworkProtocol,
			"network.transport", NetworkTransport,
			"network.type", NetworkType,
			"observer.hostname", ObserverHostname,
			"observer.name", ObserverName,
			"observer.product", ObserverProduct,
			"observer.serial_number", ObserverSerialNumber,
			"observer.type", ObserverType,
			"observer.vendor", ObserverVendor,
			"observer.version", ObserverVersion,
			"orchestrator.api_version", OrchestratorApiVersion,
			"orchestrator.cluster.id", OrchestratorClusterId,
			"orchestrator.cluster.name", OrchestratorClusterName,
			"orchestrator.cluster.url", OrchestratorClusterUrl,
			"orchestrator.cluster.version", OrchestratorClusterVersion,
			"orchestrator.namespace", OrchestratorNamespace,
			"orchestrator.organization", OrchestratorOrganization,
			"orchestrator.resource.id", OrchestratorResourceId,
			"orchestrator.resource.name", OrchestratorResourceName,
			"orchestrator.resource.parent.type", OrchestratorResourceParentType,
			"orchestrator.resource.type", OrchestratorResourceType,
			"orchestrator.type", OrchestratorType,
			"organization.id", OrganizationId,
			"organization.name", OrganizationName,
			"os.family", OsFamily,
			"os.full", OsFull,
			"os.kernel", OsKernel,
			"os.name", OsName,
			"os.platform", OsPlatform,
			"os.type", OsType,
			"os.version", OsVersion,
			"package.architecture", PackageArchitecture,
			"package.build_version", PackageBuildVersion,
			"package.checksum", PackageChecksum,
			"package.description", PackageDescription,
			"package.install_scope", PackageInstallScope,
			"package.installed", PackageInstalled,
			"package.license", PackageLicense,
			"package.name", PackageName,
			"package.path", PackagePath,
			"package.reference", PackageReference,
			"package.size", PackageSize,
			"package.type", PackageType,
			"package.version", PackageVersion,
			"pe.architecture", PeArchitecture,
			"pe.company", PeCompany,
			"pe.description", PeDescription,
			"pe.file_version", PeFileVersion,
			"pe.imphash", PeImphash,
			"pe.original_file_name", PeOriginalFileName,
			"pe.pehash", PePehash,
			"pe.product", PeProduct,
			"process.args_count", ProcessArgsCount,
			"process.command_line", ProcessCommandLine,
			"process.end", ProcessEnd,
			"process.entity_id", ProcessEntityId,
			"process.executable", ProcessExecutable,
			"process.exit_code", ProcessExitCode,
			"process.interactive", ProcessInteractive,
			"process.name", ProcessName,
			"process.pgid", ProcessPgid,
			"process.pid", ProcessPid,
			"process.start", ProcessStart,
			"process.thread.id", ProcessThreadId,
			"process.thread.name", ProcessThreadName,
			"process.title", ProcessTitle,
			"process.uptime", ProcessUptime,
			"process.working_directory", ProcessWorkingDirectory,
			"registry.data.bytes", RegistryDataBytes,
			"registry.data.type", RegistryDataType,
			"registry.hive", RegistryHive,
			"registry.key", RegistryKey,
			"registry.path", RegistryPath,
			"registry.value", RegistryValue,
			"rule.category", RuleCategory,
			"rule.description", RuleDescription,
			"rule.id", RuleId,
			"rule.license", RuleLicense,
			"rule.name", RuleName,
			"rule.reference", RuleReference,
			"rule.ruleset", RuleRuleset,
			"rule.uuid", RuleUuid,
			"rule.version", RuleVersion,
			"server.address", ServerAddress,
			"server.bytes", ServerBytes,
			"server.domain", ServerDomain,
			"server.ip", ServerIp,
			"server.mac", ServerMac,
			"server.nat.ip", ServerNatIp,
			"server.nat.port", ServerNatPort,
			"server.packets", ServerPackets,
			"server.port", ServerPort,
			"server.registered_domain", ServerRegisteredDomain,
			"server.subdomain", ServerSubdomain,
			"server.top_level_domain", ServerTopLevelDomain,
			"service.address", ServiceAddress,
			"service.environment", ServiceEnvironment,
			"service.ephemeral_id", ServiceEphemeralId,
			"service.id", ServiceId,
			"service.name", ServiceName,
			"service.node.name", ServiceNodeName,
			"service.node.role", ServiceNodeRole,
			"service.state", ServiceState,
			"service.type", ServiceType,
			"service.version", ServiceVersion,
			"source.address", SourceAddress,
			"source.bytes", SourceBytes,
			"source.domain", SourceDomain,
			"source.ip", SourceIp,
			"source.mac", SourceMac,
			"source.nat.ip", SourceNatIp,
			"source.nat.port", SourceNatPort,
			"source.packets", SourcePackets,
			"source.port", SourcePort,
			"source.registered_domain", SourceRegisteredDomain,
			"source.subdomain", SourceSubdomain,
			"source.top_level_domain", SourceTopLevelDomain,
			"threat.feed.dashboard_id", ThreatFeedDashboardId,
			"threat.feed.description", ThreatFeedDescription,
			"threat.feed.name", ThreatFeedName,
			"threat.feed.reference", ThreatFeedReference,
			"threat.framework", ThreatFramework,
			"threat.group.id", ThreatGroupId,
			"threat.group.name", ThreatGroupName,
			"threat.group.reference", ThreatGroupReference,
			"threat.indicator.confidence", ThreatIndicatorConfidence,
			"threat.indicator.description", ThreatIndicatorDescription,
			"threat.indicator.email.address", ThreatIndicatorEmailAddress,
			"threat.indicator.first_seen", ThreatIndicatorFirstSeen,
			"threat.indicator.ip", ThreatIndicatorIp,
			"threat.indicator.last_seen", ThreatIndicatorLastSeen,
			"threat.indicator.marking.tlp", ThreatIndicatorMarkingTlp,
			"threat.indicator.modified_at", ThreatIndicatorModifiedAt,
			"threat.indicator.port", ThreatIndicatorPort,
			"threat.indicator.provider", ThreatIndicatorProvider,
			"threat.indicator.reference", ThreatIndicatorReference,
			"threat.indicator.scanner_stats", ThreatIndicatorScannerStats,
			"threat.indicator.sightings", ThreatIndicatorSightings,
			"threat.indicator.type", ThreatIndicatorType,
			"threat.software.id", ThreatSoftwareId,
			"threat.software.name", ThreatSoftwareName,
			"threat.software.reference", ThreatSoftwareReference,
			"threat.software.type", ThreatSoftwareType,
			"tls.cipher", TlsCipher,
			"tls.client.certificate", TlsClientCertificate,
			"tls.client.hash.md5", TlsClientHashMd5,
			"tls.client.hash.sha1", TlsClientHashSha1,
			"tls.client.hash.sha256", TlsClientHashSha256,
			"tls.client.issuer", TlsClientIssuer,
			"tls.client.ja3", TlsClientJa3,
			"tls.client.not_after", TlsClientNotAfter,
			"tls.client.not_before", TlsClientNotBefore,
			"tls.client.server_name", TlsClientServerName,
			"tls.client.subject", TlsClientSubject,
			"tls.curve", TlsCurve,
			"tls.established", TlsEstablished,
			"tls.next_protocol", TlsNextProtocol,
			"tls.resumed", TlsResumed,
			"tls.server.certificate", TlsServerCertificate,
			"tls.server.hash.md5", TlsServerHashMd5,
			"tls.server.hash.sha1", TlsServerHashSha1,
			"tls.server.hash.sha256", TlsServerHashSha256,
			"tls.server.issuer", TlsServerIssuer,
			"tls.server.ja3s", TlsServerJa3s,
			"tls.server.not_after", TlsServerNotAfter,
			"tls.server.not_before", TlsServerNotBefore,
			"tls.server.subject", TlsServerSubject,
			"tls.version", TlsVersion,
			"tls.version_protocol", TlsVersionProtocol,
			"url.domain", UrlDomain,
			"url.extension", UrlExtension,
			"url.fragment", UrlFragment,
			"url.full", UrlFull,
			"url.original", UrlOriginal,
			"url.password", UrlPassword,
			"url.path", UrlPath,
			"url.port", UrlPort,
			"url.query", UrlQuery,
			"url.registered_domain", UrlRegisteredDomain,
			"url.scheme", UrlScheme,
			"url.subdomain", UrlSubdomain,
			"url.top_level_domain", UrlTopLevelDomain,
			"url.username", UrlUsername,
			"user.domain", UserDomain,
			"user.email", UserEmail,
			"user.full_name", UserFullName,
			"user.hash", UserHash,
			"user.id", UserId,
			"user.name", UserName,
			"user_agent.device.name", UserAgentDeviceName,
			"user_agent.name", UserAgentName,
			"user_agent.original", UserAgentOriginal,
			"user_agent.version", UserAgentVersion,
			"vlan.id", VlanId,
			"vlan.name", VlanName,
			"vulnerability.classification", VulnerabilityClassification,
			"vulnerability.description", VulnerabilityDescription,
			"vulnerability.enumeration", VulnerabilityEnumeration,
			"vulnerability.id", VulnerabilityId,
			"vulnerability.reference", VulnerabilityReference,
			"vulnerability.report_id", VulnerabilityReportId,
			"vulnerability.scanner.vendor", VulnerabilityScannerVendor,
			"vulnerability.score.base", VulnerabilityScoreBase,
			"vulnerability.score.environmental", VulnerabilityScoreEnvironmental,
			"vulnerability.score.temporal", VulnerabilityScoreTemporal,
			"vulnerability.score.version", VulnerabilityScoreVersion,
			"vulnerability.severity", VulnerabilitySeverity,
			"x509.issuer.distinguished_name", X509IssuerDistinguishedName,
			"x509.not_after", X509NotAfter,
			"x509.not_before", X509NotBefore,
			"x509.public_key_algorithm", X509PublicKeyAlgorithm,
			"x509.public_key_curve", X509PublicKeyCurve,
			"x509.public_key_exponent", X509PublicKeyExponent,
			"x509.public_key_size", X509PublicKeySize,
			"x509.serial_number", X509SerialNumber,
			"x509.signature_algorithm", X509SignatureAlgorithm,
			"x509.subject.distinguished_name", X509SubjectDistinguishedName,
			"x509.version_number", X509VersionNumber,
		};
	}

}