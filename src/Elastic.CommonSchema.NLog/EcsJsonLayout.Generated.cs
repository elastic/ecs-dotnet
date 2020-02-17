// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

/*
IMPORTANT NOTE
==============
This file has been generated.
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

using System;
using NLog;
using NLog.Layouts;
using NLog.Config;
using System.Text;
using System.Collections.Generic;

namespace Elastic.CommonSchema
{
	public class EcsSchemaLayout : Layout
	{
	     private class EcsJsonLayout : JsonLayout
         {
            public JsonAttribute Timestamp { get; } = new JsonAttribute("@timestamp", "${date}", true);
            public JsonAttribute LogLevel { get; } = new JsonAttribute("log.level", "${level}", true);
            public JsonAttribute Message { get; } = new JsonAttribute("message", "${message}", true);
            public JsonAttribute Tags { get; } = new JsonAttribute("tags", "", true);
            public JsonAttribute Labels { get; } = new JsonAttribute("labels", "", true);

            public JsonAttribute AgentVersion { get; } = new JsonAttribute("version", "", true);
            public JsonAttribute AgentName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute AgentType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute AgentId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute AgentEphemeralId { get; } = new JsonAttribute("ephemeral_id", "", true);
            public JsonAttribute AsNumber { get; } = new JsonAttribute("number", "", true);
            public JsonAttribute ClientAddress { get; } = new JsonAttribute("address", "", true);
            public JsonAttribute ClientIp { get; } = new JsonAttribute("ip", "", true);
            public JsonAttribute ClientPort { get; } = new JsonAttribute("port", "", true);
            public JsonAttribute ClientMac { get; } = new JsonAttribute("mac", "", true);
            public JsonAttribute ClientDomain { get; } = new JsonAttribute("domain", "", true);
            public JsonAttribute ClientRegisteredDomain { get; } = new JsonAttribute("registered_domain", "", true);
            public JsonAttribute ClientTopLevelDomain { get; } = new JsonAttribute("top_level_domain", "", true);
            public JsonAttribute ClientBytes { get; } = new JsonAttribute("bytes", "", true);
            public JsonAttribute ClientPackets { get; } = new JsonAttribute("packets", "", true);
            public JsonAttribute CloudProvider { get; } = new JsonAttribute("provider", "", true);
            public JsonAttribute CloudAvailabilityZone { get; } = new JsonAttribute("availability_zone", "", true);
            public JsonAttribute CloudRegion { get; } = new JsonAttribute("region", "", true);
            public JsonAttribute ContainerRuntime { get; } = new JsonAttribute("runtime", "", true);
            public JsonAttribute ContainerId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute ContainerName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute ContainerLabels { get; } = new JsonAttribute("labels", "", true);
            public JsonAttribute DestinationAddress { get; } = new JsonAttribute("address", "", true);
            public JsonAttribute DestinationIp { get; } = new JsonAttribute("ip", "", true);
            public JsonAttribute DestinationPort { get; } = new JsonAttribute("port", "", true);
            public JsonAttribute DestinationMac { get; } = new JsonAttribute("mac", "", true);
            public JsonAttribute DestinationDomain { get; } = new JsonAttribute("domain", "", true);
            public JsonAttribute DestinationRegisteredDomain { get; } = new JsonAttribute("registered_domain", "", true);
            public JsonAttribute DestinationTopLevelDomain { get; } = new JsonAttribute("top_level_domain", "", true);
            public JsonAttribute DestinationBytes { get; } = new JsonAttribute("bytes", "", true);
            public JsonAttribute DestinationPackets { get; } = new JsonAttribute("packets", "", true);
            public JsonAttribute DnsType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute DnsId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute DnsOpCode { get; } = new JsonAttribute("op_code", "", true);
            public JsonAttribute DnsHeaderFlags { get; } = new JsonAttribute("header_flags", "", true);
            public JsonAttribute DnsResponseCode { get; } = new JsonAttribute("response_code", "", true);
            public JsonAttribute DnsResolvedIp { get; } = new JsonAttribute("resolved_ip", "", true);
            public JsonAttribute EcsVersion { get; } = new JsonAttribute("version", "1.4.0", true);
            public JsonAttribute ErrorId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute ErrorMessage { get; } = new JsonAttribute("message", "", true);
            public JsonAttribute ErrorCode { get; } = new JsonAttribute("code", "", true);
            public JsonAttribute ErrorType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute ErrorStackTrace { get; } = new JsonAttribute("stack_trace", "", true);
            public JsonAttribute EventId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute EventCode { get; } = new JsonAttribute("code", "", true);
            public JsonAttribute EventKind { get; } = new JsonAttribute("kind", "", true);
            public JsonAttribute EventCategory { get; } = new JsonAttribute("category", "", true);
            public JsonAttribute EventAction { get; } = new JsonAttribute("action", "", true);
            public JsonAttribute EventOutcome { get; } = new JsonAttribute("outcome", "", true);
            public JsonAttribute EventType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute EventModule { get; } = new JsonAttribute("module", "", true);
            public JsonAttribute EventDataset { get; } = new JsonAttribute("dataset", "", true);
            public JsonAttribute EventProvider { get; } = new JsonAttribute("provider", "", true);
            public JsonAttribute EventSeverity { get; } = new JsonAttribute("severity", "", true);
            public JsonAttribute EventOriginal { get; } = new JsonAttribute("original", "", true);
            public JsonAttribute EventHash { get; } = new JsonAttribute("hash", "", true);
            public JsonAttribute EventDuration { get; } = new JsonAttribute("duration", "", true);
            public JsonAttribute EventSequence { get; } = new JsonAttribute("sequence", "", true);
            public JsonAttribute EventTimezone { get; } = new JsonAttribute("timezone", "", true);
            public JsonAttribute EventCreated { get; } = new JsonAttribute("created", "", true);
            public JsonAttribute EventStart { get; } = new JsonAttribute("start", "", true);
            public JsonAttribute EventEnd { get; } = new JsonAttribute("end", "", true);
            public JsonAttribute EventRiskScore { get; } = new JsonAttribute("risk_score", "", true);
            public JsonAttribute EventRiskScoreNorm { get; } = new JsonAttribute("risk_score_norm", "", true);
            public JsonAttribute EventIngested { get; } = new JsonAttribute("ingested", "", true);
            public JsonAttribute FileName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute FileAttributes { get; } = new JsonAttribute("attributes", "", true);
            public JsonAttribute FileDirectory { get; } = new JsonAttribute("directory", "", true);
            public JsonAttribute FileDriveLetter { get; } = new JsonAttribute("drive_letter", "", true);
            public JsonAttribute FilePath { get; } = new JsonAttribute("path", "", true);
            public JsonAttribute FileTargetPath { get; } = new JsonAttribute("target_path", "", true);
            public JsonAttribute FileExtension { get; } = new JsonAttribute("extension", "", true);
            public JsonAttribute FileType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute FileDevice { get; } = new JsonAttribute("device", "", true);
            public JsonAttribute FileInode { get; } = new JsonAttribute("inode", "", true);
            public JsonAttribute FileUid { get; } = new JsonAttribute("uid", "", true);
            public JsonAttribute FileOwner { get; } = new JsonAttribute("owner", "", true);
            public JsonAttribute FileGid { get; } = new JsonAttribute("gid", "", true);
            public JsonAttribute FileGroup { get; } = new JsonAttribute("group", "", true);
            public JsonAttribute FileMode { get; } = new JsonAttribute("mode", "", true);
            public JsonAttribute FileSize { get; } = new JsonAttribute("size", "", true);
            public JsonAttribute FileMtime { get; } = new JsonAttribute("mtime", "", true);
            public JsonAttribute FileCtime { get; } = new JsonAttribute("ctime", "", true);
            public JsonAttribute FileCreated { get; } = new JsonAttribute("created", "", true);
            public JsonAttribute FileAccessed { get; } = new JsonAttribute("accessed", "", true);
            public JsonAttribute GeoLocation { get; } = new JsonAttribute("location", "", true);
            public JsonAttribute GeoContinentName { get; } = new JsonAttribute("continent_name", "", true);
            public JsonAttribute GeoCountryName { get; } = new JsonAttribute("country_name", "", true);
            public JsonAttribute GeoRegionName { get; } = new JsonAttribute("region_name", "", true);
            public JsonAttribute GeoCityName { get; } = new JsonAttribute("city_name", "", true);
            public JsonAttribute GeoCountryIsoCode { get; } = new JsonAttribute("country_iso_code", "", true);
            public JsonAttribute GeoRegionIsoCode { get; } = new JsonAttribute("region_iso_code", "", true);
            public JsonAttribute GeoName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute GroupId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute GroupName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute GroupDomain { get; } = new JsonAttribute("domain", "", true);
            public JsonAttribute HashMd5 { get; } = new JsonAttribute("md5", "", true);
            public JsonAttribute HashSha1 { get; } = new JsonAttribute("sha1", "", true);
            public JsonAttribute HashSha256 { get; } = new JsonAttribute("sha256", "", true);
            public JsonAttribute HashSha512 { get; } = new JsonAttribute("sha512", "", true);
            public JsonAttribute HostHostname { get; } = new JsonAttribute("hostname", "", true);
            public JsonAttribute HostName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute HostId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute HostIp { get; } = new JsonAttribute("ip", "", true);
            public JsonAttribute HostMac { get; } = new JsonAttribute("mac", "", true);
            public JsonAttribute HostType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute HostUptime { get; } = new JsonAttribute("uptime", "", true);
            public JsonAttribute HostArchitecture { get; } = new JsonAttribute("architecture", "", true);
            public JsonAttribute HostDomain { get; } = new JsonAttribute("domain", "", true);
            public JsonAttribute HttpVersion { get; } = new JsonAttribute("version", "", true);
            public JsonAttribute LogOriginal { get; } = new JsonAttribute("original", "", true);
            public JsonAttribute LogLogger { get; } = new JsonAttribute("logger", "", true);
            public JsonAttribute NetworkName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute NetworkType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute NetworkIanaNumber { get; } = new JsonAttribute("iana_number", "", true);
            public JsonAttribute NetworkTransport { get; } = new JsonAttribute("transport", "", true);
            public JsonAttribute NetworkApplication { get; } = new JsonAttribute("application", "", true);
            public JsonAttribute NetworkProtocol { get; } = new JsonAttribute("protocol", "", true);
            public JsonAttribute NetworkDirection { get; } = new JsonAttribute("direction", "", true);
            public JsonAttribute NetworkForwardedIp { get; } = new JsonAttribute("forwarded_ip", "", true);
            public JsonAttribute NetworkCommunityId { get; } = new JsonAttribute("community_id", "", true);
            public JsonAttribute NetworkBytes { get; } = new JsonAttribute("bytes", "", true);
            public JsonAttribute NetworkPackets { get; } = new JsonAttribute("packets", "", true);
            public JsonAttribute ObserverMac { get; } = new JsonAttribute("mac", "", true);
            public JsonAttribute ObserverIp { get; } = new JsonAttribute("ip", "", true);
            public JsonAttribute ObserverHostname { get; } = new JsonAttribute("hostname", "", true);
            public JsonAttribute ObserverName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute ObserverProduct { get; } = new JsonAttribute("product", "", true);
            public JsonAttribute ObserverVendor { get; } = new JsonAttribute("vendor", "", true);
            public JsonAttribute ObserverVersion { get; } = new JsonAttribute("version", "", true);
            public JsonAttribute ObserverSerialNumber { get; } = new JsonAttribute("serial_number", "", true);
            public JsonAttribute ObserverType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute OrganizationName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute OrganizationId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute OsPlatform { get; } = new JsonAttribute("platform", "", true);
            public JsonAttribute OsName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute OsFull { get; } = new JsonAttribute("full", "", true);
            public JsonAttribute OsFamily { get; } = new JsonAttribute("family", "", true);
            public JsonAttribute OsVersion { get; } = new JsonAttribute("version", "", true);
            public JsonAttribute OsKernel { get; } = new JsonAttribute("kernel", "", true);
            public JsonAttribute PackageName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute PackageVersion { get; } = new JsonAttribute("version", "", true);
            public JsonAttribute PackageBuildVersion { get; } = new JsonAttribute("build_version", "", true);
            public JsonAttribute PackageDescription { get; } = new JsonAttribute("description", "", true);
            public JsonAttribute PackageSize { get; } = new JsonAttribute("size", "", true);
            public JsonAttribute PackageInstalled { get; } = new JsonAttribute("installed", "", true);
            public JsonAttribute PackagePath { get; } = new JsonAttribute("path", "", true);
            public JsonAttribute PackageArchitecture { get; } = new JsonAttribute("architecture", "", true);
            public JsonAttribute PackageChecksum { get; } = new JsonAttribute("checksum", "", true);
            public JsonAttribute PackageInstallScope { get; } = new JsonAttribute("install_scope", "", true);
            public JsonAttribute PackageLicense { get; } = new JsonAttribute("license", "", true);
            public JsonAttribute PackageReference { get; } = new JsonAttribute("reference", "", true);
            public JsonAttribute PackageType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute ProcessPid { get; } = new JsonAttribute("pid", "", true);
            public JsonAttribute ProcessName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute ProcessPpid { get; } = new JsonAttribute("ppid", "", true);
            public JsonAttribute ProcessPgid { get; } = new JsonAttribute("pgid", "", true);
            public JsonAttribute ProcessCommandLine { get; } = new JsonAttribute("command_line", "", true);
            public JsonAttribute ProcessArgs { get; } = new JsonAttribute("args", "", true);
            public JsonAttribute ProcessArgsCount { get; } = new JsonAttribute("args_count", "", true);
            public JsonAttribute ProcessExecutable { get; } = new JsonAttribute("executable", "", true);
            public JsonAttribute ProcessTitle { get; } = new JsonAttribute("title", "", true);
            public JsonAttribute ProcessStart { get; } = new JsonAttribute("start", "", true);
            public JsonAttribute ProcessUptime { get; } = new JsonAttribute("uptime", "", true);
            public JsonAttribute ProcessWorkingDirectory { get; } = new JsonAttribute("working_directory", "", true);
            public JsonAttribute ProcessExitCode { get; } = new JsonAttribute("exit_code", "", true);
            public JsonAttribute RegistryHive { get; } = new JsonAttribute("hive", "", true);
            public JsonAttribute RegistryKey { get; } = new JsonAttribute("key", "", true);
            public JsonAttribute RegistryValue { get; } = new JsonAttribute("value", "", true);
            public JsonAttribute RegistryPath { get; } = new JsonAttribute("path", "", true);
            public JsonAttribute RelatedIp { get; } = new JsonAttribute("ip", "", true);
            public JsonAttribute RelatedUser { get; } = new JsonAttribute("user", "", true);
            public JsonAttribute RuleId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute RuleUuid { get; } = new JsonAttribute("uuid", "", true);
            public JsonAttribute RuleVersion { get; } = new JsonAttribute("version", "", true);
            public JsonAttribute RuleName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute RuleDescription { get; } = new JsonAttribute("description", "", true);
            public JsonAttribute RuleCategory { get; } = new JsonAttribute("category", "", true);
            public JsonAttribute RuleRuleset { get; } = new JsonAttribute("ruleset", "", true);
            public JsonAttribute RuleReference { get; } = new JsonAttribute("reference", "", true);
            public JsonAttribute ServerAddress { get; } = new JsonAttribute("address", "", true);
            public JsonAttribute ServerIp { get; } = new JsonAttribute("ip", "", true);
            public JsonAttribute ServerPort { get; } = new JsonAttribute("port", "", true);
            public JsonAttribute ServerMac { get; } = new JsonAttribute("mac", "", true);
            public JsonAttribute ServerDomain { get; } = new JsonAttribute("domain", "", true);
            public JsonAttribute ServerRegisteredDomain { get; } = new JsonAttribute("registered_domain", "", true);
            public JsonAttribute ServerTopLevelDomain { get; } = new JsonAttribute("top_level_domain", "", true);
            public JsonAttribute ServerBytes { get; } = new JsonAttribute("bytes", "", true);
            public JsonAttribute ServerPackets { get; } = new JsonAttribute("packets", "", true);
            public JsonAttribute ServiceId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute ServiceName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute ServiceType { get; } = new JsonAttribute("type", "", true);
            public JsonAttribute ServiceState { get; } = new JsonAttribute("state", "", true);
            public JsonAttribute ServiceVersion { get; } = new JsonAttribute("version", "", true);
            public JsonAttribute ServiceEphemeralId { get; } = new JsonAttribute("ephemeral_id", "", true);
            public JsonAttribute SourceAddress { get; } = new JsonAttribute("address", "", true);
            public JsonAttribute SourceIp { get; } = new JsonAttribute("ip", "", true);
            public JsonAttribute SourcePort { get; } = new JsonAttribute("port", "", true);
            public JsonAttribute SourceMac { get; } = new JsonAttribute("mac", "", true);
            public JsonAttribute SourceDomain { get; } = new JsonAttribute("domain", "", true);
            public JsonAttribute SourceRegisteredDomain { get; } = new JsonAttribute("registered_domain", "", true);
            public JsonAttribute SourceTopLevelDomain { get; } = new JsonAttribute("top_level_domain", "", true);
            public JsonAttribute SourceBytes { get; } = new JsonAttribute("bytes", "", true);
            public JsonAttribute SourcePackets { get; } = new JsonAttribute("packets", "", true);
            public JsonAttribute ThreatFramework { get; } = new JsonAttribute("framework", "", true);
            public JsonAttribute TlsVersion { get; } = new JsonAttribute("version", "", true);
            public JsonAttribute TlsVersionProtocol { get; } = new JsonAttribute("version_protocol", "", true);
            public JsonAttribute TlsCipher { get; } = new JsonAttribute("cipher", "", true);
            public JsonAttribute TlsCurve { get; } = new JsonAttribute("curve", "", true);
            public JsonAttribute TlsResumed { get; } = new JsonAttribute("resumed", "", true);
            public JsonAttribute TlsEstablished { get; } = new JsonAttribute("established", "", true);
            public JsonAttribute TlsNextProtocol { get; } = new JsonAttribute("next_protocol", "", true);
            public JsonAttribute UrlOriginal { get; } = new JsonAttribute("original", "", true);
            public JsonAttribute UrlFull { get; } = new JsonAttribute("full", "", true);
            public JsonAttribute UrlScheme { get; } = new JsonAttribute("scheme", "", true);
            public JsonAttribute UrlDomain { get; } = new JsonAttribute("domain", "", true);
            public JsonAttribute UrlRegisteredDomain { get; } = new JsonAttribute("registered_domain", "", true);
            public JsonAttribute UrlTopLevelDomain { get; } = new JsonAttribute("top_level_domain", "", true);
            public JsonAttribute UrlPort { get; } = new JsonAttribute("port", "", true);
            public JsonAttribute UrlPath { get; } = new JsonAttribute("path", "", true);
            public JsonAttribute UrlQuery { get; } = new JsonAttribute("query", "", true);
            public JsonAttribute UrlExtension { get; } = new JsonAttribute("extension", "", true);
            public JsonAttribute UrlFragment { get; } = new JsonAttribute("fragment", "", true);
            public JsonAttribute UrlUsername { get; } = new JsonAttribute("username", "", true);
            public JsonAttribute UrlPassword { get; } = new JsonAttribute("password", "", true);
            public JsonAttribute UserId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute UserName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute UserFullName { get; } = new JsonAttribute("full_name", "", true);
            public JsonAttribute UserEmail { get; } = new JsonAttribute("email", "", true);
            public JsonAttribute UserHash { get; } = new JsonAttribute("hash", "", true);
            public JsonAttribute UserDomain { get; } = new JsonAttribute("domain", "", true);
            public JsonAttribute UserAgentOriginal { get; } = new JsonAttribute("original", "", true);
            public JsonAttribute UserAgentName { get; } = new JsonAttribute("name", "", true);
            public JsonAttribute UserAgentVersion { get; } = new JsonAttribute("version", "", true);
            public JsonAttribute VulnerabilityClassification { get; } = new JsonAttribute("classification", "", true);
            public JsonAttribute VulnerabilityEnumeration { get; } = new JsonAttribute("enumeration", "", true);
            public JsonAttribute VulnerabilityReference { get; } = new JsonAttribute("reference", "", true);
            public JsonAttribute VulnerabilityCategory { get; } = new JsonAttribute("category", "", true);
            public JsonAttribute VulnerabilityDescription { get; } = new JsonAttribute("description", "", true);
            public JsonAttribute VulnerabilityId { get; } = new JsonAttribute("id", "", true);
            public JsonAttribute VulnerabilitySeverity { get; } = new JsonAttribute("severity", "", true);
            public JsonAttribute VulnerabilityReportId { get; } = new JsonAttribute("report_id", "", true);

                public JsonLayout Metadata { get; }

				public EcsJsonLayout()
                {
			        Attributes.Add(Timestamp);
			        Attributes.Add(LogLevel);
			        Attributes.Add(Message);
			        Attributes.Add(Tags);
			        Attributes.Add(Labels);

			        Attributes.Add(new JsonAttribute("agent", new JsonLayout
			        {
						Attributes =
						{
			        		AgentVersion,
			        		AgentName,
			        		AgentType,
			        		AgentId,
			        		AgentEphemeralId,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("as", new JsonLayout
			        {
						Attributes =
						{
			        		AsNumber,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("client", new JsonLayout
			        {
						Attributes =
						{
			        		ClientAddress,
			        		ClientIp,
			        		ClientPort,
			        		ClientMac,
			        		ClientDomain,
			        		ClientRegisteredDomain,
			        		ClientTopLevelDomain,
			        		ClientBytes,
			        		ClientPackets,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("cloud", new JsonLayout
			        {
						Attributes =
						{
			        		CloudProvider,
			        		CloudAvailabilityZone,
			        		CloudRegion,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("container", new JsonLayout
			        {
						Attributes =
						{
			        		ContainerRuntime,
			        		ContainerId,
			        		ContainerName,
			        		ContainerLabels,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("destination", new JsonLayout
			        {
						Attributes =
						{
			        		DestinationAddress,
			        		DestinationIp,
			        		DestinationPort,
			        		DestinationMac,
			        		DestinationDomain,
			        		DestinationRegisteredDomain,
			        		DestinationTopLevelDomain,
			        		DestinationBytes,
			        		DestinationPackets,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("dns", new JsonLayout
			        {
						Attributes =
						{
			        		DnsType,
			        		DnsId,
			        		DnsOpCode,
			        		DnsHeaderFlags,
			        		DnsResponseCode,
			        		DnsResolvedIp,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("ecs", new JsonLayout
			        {
						Attributes =
						{
			        		EcsVersion,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("error", new JsonLayout
			        {
						Attributes =
						{
			        		ErrorId,
			        		ErrorMessage,
			        		ErrorCode,
			        		ErrorType,
			        		ErrorStackTrace,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("event", new JsonLayout
			        {
						Attributes =
						{
			        		EventId,
			        		EventCode,
			        		EventKind,
			        		EventCategory,
			        		EventAction,
			        		EventOutcome,
			        		EventType,
			        		EventModule,
			        		EventDataset,
			        		EventProvider,
			        		EventSeverity,
			        		EventOriginal,
			        		EventHash,
			        		EventDuration,
			        		EventSequence,
			        		EventTimezone,
			        		EventCreated,
			        		EventStart,
			        		EventEnd,
			        		EventRiskScore,
			        		EventRiskScoreNorm,
			        		EventIngested,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("file", new JsonLayout
			        {
						Attributes =
						{
			        		FileName,
			        		FileAttributes,
			        		FileDirectory,
			        		FileDriveLetter,
			        		FilePath,
			        		FileTargetPath,
			        		FileExtension,
			        		FileType,
			        		FileDevice,
			        		FileInode,
			        		FileUid,
			        		FileOwner,
			        		FileGid,
			        		FileGroup,
			        		FileMode,
			        		FileSize,
			        		FileMtime,
			        		FileCtime,
			        		FileCreated,
			        		FileAccessed,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("geo", new JsonLayout
			        {
						Attributes =
						{
			        		GeoLocation,
			        		GeoContinentName,
			        		GeoCountryName,
			        		GeoRegionName,
			        		GeoCityName,
			        		GeoCountryIsoCode,
			        		GeoRegionIsoCode,
			        		GeoName,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("group", new JsonLayout
			        {
						Attributes =
						{
			        		GroupId,
			        		GroupName,
			        		GroupDomain,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("hash", new JsonLayout
			        {
						Attributes =
						{
			        		HashMd5,
			        		HashSha1,
			        		HashSha256,
			        		HashSha512,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("host", new JsonLayout
			        {
						Attributes =
						{
			        		HostHostname,
			        		HostName,
			        		HostId,
			        		HostIp,
			        		HostMac,
			        		HostType,
			        		HostUptime,
			        		HostArchitecture,
			        		HostDomain,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("http", new JsonLayout
			        {
						Attributes =
						{
			        		HttpVersion,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("log", new JsonLayout
			        {
						Attributes =
						{
			        		LogLevel,
			        		LogOriginal,
			        		LogLogger,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("network", new JsonLayout
			        {
						Attributes =
						{
			        		NetworkName,
			        		NetworkType,
			        		NetworkIanaNumber,
			        		NetworkTransport,
			        		NetworkApplication,
			        		NetworkProtocol,
			        		NetworkDirection,
			        		NetworkForwardedIp,
			        		NetworkCommunityId,
			        		NetworkBytes,
			        		NetworkPackets,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("observer", new JsonLayout
			        {
						Attributes =
						{
			        		ObserverMac,
			        		ObserverIp,
			        		ObserverHostname,
			        		ObserverName,
			        		ObserverProduct,
			        		ObserverVendor,
			        		ObserverVersion,
			        		ObserverSerialNumber,
			        		ObserverType,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("organization", new JsonLayout
			        {
						Attributes =
						{
			        		OrganizationName,
			        		OrganizationId,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("os", new JsonLayout
			        {
						Attributes =
						{
			        		OsPlatform,
			        		OsName,
			        		OsFull,
			        		OsFamily,
			        		OsVersion,
			        		OsKernel,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("package", new JsonLayout
			        {
						Attributes =
						{
			        		PackageName,
			        		PackageVersion,
			        		PackageBuildVersion,
			        		PackageDescription,
			        		PackageSize,
			        		PackageInstalled,
			        		PackagePath,
			        		PackageArchitecture,
			        		PackageChecksum,
			        		PackageInstallScope,
			        		PackageLicense,
			        		PackageReference,
			        		PackageType,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("process", new JsonLayout
			        {
						Attributes =
						{
			        		ProcessPid,
			        		ProcessName,
			        		ProcessPpid,
			        		ProcessPgid,
			        		ProcessCommandLine,
			        		ProcessArgs,
			        		ProcessArgsCount,
			        		ProcessExecutable,
			        		ProcessTitle,
			        		ProcessStart,
			        		ProcessUptime,
			        		ProcessWorkingDirectory,
			        		ProcessExitCode,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("registry", new JsonLayout
			        {
						Attributes =
						{
			        		RegistryHive,
			        		RegistryKey,
			        		RegistryValue,
			        		RegistryPath,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("related", new JsonLayout
			        {
						Attributes =
						{
			        		RelatedIp,
			        		RelatedUser,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("rule", new JsonLayout
			        {
						Attributes =
						{
			        		RuleId,
			        		RuleUuid,
			        		RuleVersion,
			        		RuleName,
			        		RuleDescription,
			        		RuleCategory,
			        		RuleRuleset,
			        		RuleReference,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("server", new JsonLayout
			        {
						Attributes =
						{
			        		ServerAddress,
			        		ServerIp,
			        		ServerPort,
			        		ServerMac,
			        		ServerDomain,
			        		ServerRegisteredDomain,
			        		ServerTopLevelDomain,
			        		ServerBytes,
			        		ServerPackets,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("service", new JsonLayout
			        {
						Attributes =
						{
			        		ServiceId,
			        		ServiceName,
			        		ServiceType,
			        		ServiceState,
			        		ServiceVersion,
			        		ServiceEphemeralId,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("source", new JsonLayout
			        {
						Attributes =
						{
			        		SourceAddress,
			        		SourceIp,
			        		SourcePort,
			        		SourceMac,
			        		SourceDomain,
			        		SourceRegisteredDomain,
			        		SourceTopLevelDomain,
			        		SourceBytes,
			        		SourcePackets,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("threat", new JsonLayout
			        {
						Attributes =
						{
			        		ThreatFramework,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("tls", new JsonLayout
			        {
						Attributes =
						{
			        		TlsVersion,
			        		TlsVersionProtocol,
			        		TlsCipher,
			        		TlsCurve,
			        		TlsResumed,
			        		TlsEstablished,
			        		TlsNextProtocol,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("url", new JsonLayout
			        {
						Attributes =
						{
			        		UrlOriginal,
			        		UrlFull,
			        		UrlScheme,
			        		UrlDomain,
			        		UrlRegisteredDomain,
			        		UrlTopLevelDomain,
			        		UrlPort,
			        		UrlPath,
			        		UrlQuery,
			        		UrlExtension,
			        		UrlFragment,
			        		UrlUsername,
			        		UrlPassword,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("user", new JsonLayout
			        {
						Attributes =
						{
			        		UserId,
			        		UserName,
			        		UserFullName,
			        		UserEmail,
			        		UserHash,
			        		UserDomain,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("user_agent", new JsonLayout
			        {
						Attributes =
						{
			        		UserAgentOriginal,
			        		UserAgentName,
			        		UserAgentVersion,
			        	}
			        }));

			        Attributes.Add(new JsonAttribute("vulnerability", new JsonLayout
			        {
						Attributes =
						{
			        		VulnerabilityClassification,
			        		VulnerabilityEnumeration,
			        		VulnerabilityReference,
			        		VulnerabilityCategory,
			        		VulnerabilityDescription,
			        		VulnerabilityId,
			        		VulnerabilitySeverity,
			        		VulnerabilityReportId,
			        	}
			        }));


	              Metadata = new JsonLayout()
	              {
	                 IncludeAllProperties = true,
	                 IncludeMdlc = false,
	                 MaxRecursionLimit = 1,
	                 RenderEmptyObject = false,
	             };

	             Attributes.Add(new JsonAttribute("_metadata", Metadata, false));
			}

			public void Render(LogEventInfo logEvent, StringBuilder target) => base.RenderFormattedMessage(logEvent, target);

		}

	     private readonly EcsJsonLayout _innerLayout = new EcsJsonLayout();

	     protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	     {
	          _innerLayout.Render(logEvent, target);
	     }

		 protected override string GetFormattedMessage(LogEventInfo logEvent)
		 {
			 throw new NotImplementedException();
		 }

	     public Layout SchemaLayout => _innerLayout; // Necessary for NLog config reflection/initialization

	     public bool IncludeAllProperties
	     {
	         get => _innerLayout.Metadata.IncludeAllProperties;
	         set => _innerLayout.Metadata.IncludeAllProperties = value;
	     }

	     public bool IncludeMdlc
	     {
	         get => _innerLayout.Metadata.IncludeMdlc;
	         set => _innerLayout.Metadata.IncludeMdlc = value;
	     }

	     public int MaxRecursionLimit
	     {
	         get => _innerLayout.Metadata.MaxRecursionLimit;
	         set => _innerLayout.Metadata.MaxRecursionLimit= value;
	     }

	     [ArrayParameter(typeof(JsonAttribute), "attribute")]
	     public IList<JsonAttribute> Attributes
	     {
	         get => _innerLayout.Metadata.Attributes;
	         set
	         {
	               _innerLayout.Metadata.Attributes.Clear();
				   if (value == null)
					   return;
				   foreach (var jsonAttribute in value)
				   {
					   _innerLayout.Metadata.Attributes.Add(jsonAttribute);
				   }
			 }
	     }

	    public Layout AgentVersion
		{
			get => _innerLayout.AgentVersion.Layout;
			set => _innerLayout.AgentVersion.Layout = value;
		}
 	    public Layout AgentName
		{
			get => _innerLayout.AgentName.Layout;
			set => _innerLayout.AgentName.Layout = value;
		}
 	    public Layout AgentType
		{
			get => _innerLayout.AgentType.Layout;
			set => _innerLayout.AgentType.Layout = value;
		}
 	    public Layout AgentId
		{
			get => _innerLayout.AgentId.Layout;
			set => _innerLayout.AgentId.Layout = value;
		}
 	    public Layout AgentEphemeralId
		{
			get => _innerLayout.AgentEphemeralId.Layout;
			set => _innerLayout.AgentEphemeralId.Layout = value;
		}
 	    public Layout AsNumber
		{
			get => _innerLayout.AsNumber.Layout;
			set => _innerLayout.AsNumber.Layout = value;
		}
 	    public Layout ClientAddress
		{
			get => _innerLayout.ClientAddress.Layout;
			set => _innerLayout.ClientAddress.Layout = value;
		}
 	    public Layout ClientIp
		{
			get => _innerLayout.ClientIp.Layout;
			set => _innerLayout.ClientIp.Layout = value;
		}
 	    public Layout ClientPort
		{
			get => _innerLayout.ClientPort.Layout;
			set => _innerLayout.ClientPort.Layout = value;
		}
 	    public Layout ClientMac
		{
			get => _innerLayout.ClientMac.Layout;
			set => _innerLayout.ClientMac.Layout = value;
		}
 	    public Layout ClientDomain
		{
			get => _innerLayout.ClientDomain.Layout;
			set => _innerLayout.ClientDomain.Layout = value;
		}
 	    public Layout ClientRegisteredDomain
		{
			get => _innerLayout.ClientRegisteredDomain.Layout;
			set => _innerLayout.ClientRegisteredDomain.Layout = value;
		}
 	    public Layout ClientTopLevelDomain
		{
			get => _innerLayout.ClientTopLevelDomain.Layout;
			set => _innerLayout.ClientTopLevelDomain.Layout = value;
		}
 	    public Layout ClientBytes
		{
			get => _innerLayout.ClientBytes.Layout;
			set => _innerLayout.ClientBytes.Layout = value;
		}
 	    public Layout ClientPackets
		{
			get => _innerLayout.ClientPackets.Layout;
			set => _innerLayout.ClientPackets.Layout = value;
		}
 	    public Layout CloudProvider
		{
			get => _innerLayout.CloudProvider.Layout;
			set => _innerLayout.CloudProvider.Layout = value;
		}
 	    public Layout CloudAvailabilityZone
		{
			get => _innerLayout.CloudAvailabilityZone.Layout;
			set => _innerLayout.CloudAvailabilityZone.Layout = value;
		}
 	    public Layout CloudRegion
		{
			get => _innerLayout.CloudRegion.Layout;
			set => _innerLayout.CloudRegion.Layout = value;
		}
 	    public Layout ContainerRuntime
		{
			get => _innerLayout.ContainerRuntime.Layout;
			set => _innerLayout.ContainerRuntime.Layout = value;
		}
 	    public Layout ContainerId
		{
			get => _innerLayout.ContainerId.Layout;
			set => _innerLayout.ContainerId.Layout = value;
		}
 	    public Layout ContainerName
		{
			get => _innerLayout.ContainerName.Layout;
			set => _innerLayout.ContainerName.Layout = value;
		}
 	    public Layout ContainerLabels
		{
			get => _innerLayout.ContainerLabels.Layout;
			set => _innerLayout.ContainerLabels.Layout = value;
		}
 	    public Layout DestinationAddress
		{
			get => _innerLayout.DestinationAddress.Layout;
			set => _innerLayout.DestinationAddress.Layout = value;
		}
 	    public Layout DestinationIp
		{
			get => _innerLayout.DestinationIp.Layout;
			set => _innerLayout.DestinationIp.Layout = value;
		}
 	    public Layout DestinationPort
		{
			get => _innerLayout.DestinationPort.Layout;
			set => _innerLayout.DestinationPort.Layout = value;
		}
 	    public Layout DestinationMac
		{
			get => _innerLayout.DestinationMac.Layout;
			set => _innerLayout.DestinationMac.Layout = value;
		}
 	    public Layout DestinationDomain
		{
			get => _innerLayout.DestinationDomain.Layout;
			set => _innerLayout.DestinationDomain.Layout = value;
		}
 	    public Layout DestinationRegisteredDomain
		{
			get => _innerLayout.DestinationRegisteredDomain.Layout;
			set => _innerLayout.DestinationRegisteredDomain.Layout = value;
		}
 	    public Layout DestinationTopLevelDomain
		{
			get => _innerLayout.DestinationTopLevelDomain.Layout;
			set => _innerLayout.DestinationTopLevelDomain.Layout = value;
		}
 	    public Layout DestinationBytes
		{
			get => _innerLayout.DestinationBytes.Layout;
			set => _innerLayout.DestinationBytes.Layout = value;
		}
 	    public Layout DestinationPackets
		{
			get => _innerLayout.DestinationPackets.Layout;
			set => _innerLayout.DestinationPackets.Layout = value;
		}
 	    public Layout DnsType
		{
			get => _innerLayout.DnsType.Layout;
			set => _innerLayout.DnsType.Layout = value;
		}
 	    public Layout DnsId
		{
			get => _innerLayout.DnsId.Layout;
			set => _innerLayout.DnsId.Layout = value;
		}
 	    public Layout DnsOpCode
		{
			get => _innerLayout.DnsOpCode.Layout;
			set => _innerLayout.DnsOpCode.Layout = value;
		}
 	    public Layout DnsHeaderFlags
		{
			get => _innerLayout.DnsHeaderFlags.Layout;
			set => _innerLayout.DnsHeaderFlags.Layout = value;
		}
 	    public Layout DnsResponseCode
		{
			get => _innerLayout.DnsResponseCode.Layout;
			set => _innerLayout.DnsResponseCode.Layout = value;
		}
 	    public Layout DnsResolvedIp
		{
			get => _innerLayout.DnsResolvedIp.Layout;
			set => _innerLayout.DnsResolvedIp.Layout = value;
		}
 	    public Layout EcsVersion
		{
			get => _innerLayout.EcsVersion.Layout;
			set => _innerLayout.EcsVersion.Layout = value;
		}
 	    public Layout ErrorId
		{
			get => _innerLayout.ErrorId.Layout;
			set => _innerLayout.ErrorId.Layout = value;
		}
 	    public Layout ErrorMessage
		{
			get => _innerLayout.ErrorMessage.Layout;
			set => _innerLayout.ErrorMessage.Layout = value;
		}
 	    public Layout ErrorCode
		{
			get => _innerLayout.ErrorCode.Layout;
			set => _innerLayout.ErrorCode.Layout = value;
		}
 	    public Layout ErrorType
		{
			get => _innerLayout.ErrorType.Layout;
			set => _innerLayout.ErrorType.Layout = value;
		}
 	    public Layout ErrorStackTrace
		{
			get => _innerLayout.ErrorStackTrace.Layout;
			set => _innerLayout.ErrorStackTrace.Layout = value;
		}
 	    public Layout EventId
		{
			get => _innerLayout.EventId.Layout;
			set => _innerLayout.EventId.Layout = value;
		}
 	    public Layout EventCode
		{
			get => _innerLayout.EventCode.Layout;
			set => _innerLayout.EventCode.Layout = value;
		}
 	    public Layout EventKind
		{
			get => _innerLayout.EventKind.Layout;
			set => _innerLayout.EventKind.Layout = value;
		}
 	    public Layout EventCategory
		{
			get => _innerLayout.EventCategory.Layout;
			set => _innerLayout.EventCategory.Layout = value;
		}
 	    public Layout EventAction
		{
			get => _innerLayout.EventAction.Layout;
			set => _innerLayout.EventAction.Layout = value;
		}
 	    public Layout EventOutcome
		{
			get => _innerLayout.EventOutcome.Layout;
			set => _innerLayout.EventOutcome.Layout = value;
		}
 	    public Layout EventType
		{
			get => _innerLayout.EventType.Layout;
			set => _innerLayout.EventType.Layout = value;
		}
 	    public Layout EventModule
		{
			get => _innerLayout.EventModule.Layout;
			set => _innerLayout.EventModule.Layout = value;
		}
 	    public Layout EventDataset
		{
			get => _innerLayout.EventDataset.Layout;
			set => _innerLayout.EventDataset.Layout = value;
		}
 	    public Layout EventProvider
		{
			get => _innerLayout.EventProvider.Layout;
			set => _innerLayout.EventProvider.Layout = value;
		}
 	    public Layout EventSeverity
		{
			get => _innerLayout.EventSeverity.Layout;
			set => _innerLayout.EventSeverity.Layout = value;
		}
 	    public Layout EventOriginal
		{
			get => _innerLayout.EventOriginal.Layout;
			set => _innerLayout.EventOriginal.Layout = value;
		}
 	    public Layout EventHash
		{
			get => _innerLayout.EventHash.Layout;
			set => _innerLayout.EventHash.Layout = value;
		}
 	    public Layout EventDuration
		{
			get => _innerLayout.EventDuration.Layout;
			set => _innerLayout.EventDuration.Layout = value;
		}
 	    public Layout EventSequence
		{
			get => _innerLayout.EventSequence.Layout;
			set => _innerLayout.EventSequence.Layout = value;
		}
 	    public Layout EventTimezone
		{
			get => _innerLayout.EventTimezone.Layout;
			set => _innerLayout.EventTimezone.Layout = value;
		}
 	    public Layout EventCreated
		{
			get => _innerLayout.EventCreated.Layout;
			set => _innerLayout.EventCreated.Layout = value;
		}
 	    public Layout EventStart
		{
			get => _innerLayout.EventStart.Layout;
			set => _innerLayout.EventStart.Layout = value;
		}
 	    public Layout EventEnd
		{
			get => _innerLayout.EventEnd.Layout;
			set => _innerLayout.EventEnd.Layout = value;
		}
 	    public Layout EventRiskScore
		{
			get => _innerLayout.EventRiskScore.Layout;
			set => _innerLayout.EventRiskScore.Layout = value;
		}
 	    public Layout EventRiskScoreNorm
		{
			get => _innerLayout.EventRiskScoreNorm.Layout;
			set => _innerLayout.EventRiskScoreNorm.Layout = value;
		}
 	    public Layout EventIngested
		{
			get => _innerLayout.EventIngested.Layout;
			set => _innerLayout.EventIngested.Layout = value;
		}
 	    public Layout FileName
		{
			get => _innerLayout.FileName.Layout;
			set => _innerLayout.FileName.Layout = value;
		}
 	    public Layout FileAttributes
		{
			get => _innerLayout.FileAttributes.Layout;
			set => _innerLayout.FileAttributes.Layout = value;
		}
 	    public Layout FileDirectory
		{
			get => _innerLayout.FileDirectory.Layout;
			set => _innerLayout.FileDirectory.Layout = value;
		}
 	    public Layout FileDriveLetter
		{
			get => _innerLayout.FileDriveLetter.Layout;
			set => _innerLayout.FileDriveLetter.Layout = value;
		}
 	    public Layout FilePath
		{
			get => _innerLayout.FilePath.Layout;
			set => _innerLayout.FilePath.Layout = value;
		}
 	    public Layout FileTargetPath
		{
			get => _innerLayout.FileTargetPath.Layout;
			set => _innerLayout.FileTargetPath.Layout = value;
		}
 	    public Layout FileExtension
		{
			get => _innerLayout.FileExtension.Layout;
			set => _innerLayout.FileExtension.Layout = value;
		}
 	    public Layout FileType
		{
			get => _innerLayout.FileType.Layout;
			set => _innerLayout.FileType.Layout = value;
		}
 	    public Layout FileDevice
		{
			get => _innerLayout.FileDevice.Layout;
			set => _innerLayout.FileDevice.Layout = value;
		}
 	    public Layout FileInode
		{
			get => _innerLayout.FileInode.Layout;
			set => _innerLayout.FileInode.Layout = value;
		}
 	    public Layout FileUid
		{
			get => _innerLayout.FileUid.Layout;
			set => _innerLayout.FileUid.Layout = value;
		}
 	    public Layout FileOwner
		{
			get => _innerLayout.FileOwner.Layout;
			set => _innerLayout.FileOwner.Layout = value;
		}
 	    public Layout FileGid
		{
			get => _innerLayout.FileGid.Layout;
			set => _innerLayout.FileGid.Layout = value;
		}
 	    public Layout FileGroup
		{
			get => _innerLayout.FileGroup.Layout;
			set => _innerLayout.FileGroup.Layout = value;
		}
 	    public Layout FileMode
		{
			get => _innerLayout.FileMode.Layout;
			set => _innerLayout.FileMode.Layout = value;
		}
 	    public Layout FileSize
		{
			get => _innerLayout.FileSize.Layout;
			set => _innerLayout.FileSize.Layout = value;
		}
 	    public Layout FileMtime
		{
			get => _innerLayout.FileMtime.Layout;
			set => _innerLayout.FileMtime.Layout = value;
		}
 	    public Layout FileCtime
		{
			get => _innerLayout.FileCtime.Layout;
			set => _innerLayout.FileCtime.Layout = value;
		}
 	    public Layout FileCreated
		{
			get => _innerLayout.FileCreated.Layout;
			set => _innerLayout.FileCreated.Layout = value;
		}
 	    public Layout FileAccessed
		{
			get => _innerLayout.FileAccessed.Layout;
			set => _innerLayout.FileAccessed.Layout = value;
		}
 	    public Layout GeoLocation
		{
			get => _innerLayout.GeoLocation.Layout;
			set => _innerLayout.GeoLocation.Layout = value;
		}
 	    public Layout GeoContinentName
		{
			get => _innerLayout.GeoContinentName.Layout;
			set => _innerLayout.GeoContinentName.Layout = value;
		}
 	    public Layout GeoCountryName
		{
			get => _innerLayout.GeoCountryName.Layout;
			set => _innerLayout.GeoCountryName.Layout = value;
		}
 	    public Layout GeoRegionName
		{
			get => _innerLayout.GeoRegionName.Layout;
			set => _innerLayout.GeoRegionName.Layout = value;
		}
 	    public Layout GeoCityName
		{
			get => _innerLayout.GeoCityName.Layout;
			set => _innerLayout.GeoCityName.Layout = value;
		}
 	    public Layout GeoCountryIsoCode
		{
			get => _innerLayout.GeoCountryIsoCode.Layout;
			set => _innerLayout.GeoCountryIsoCode.Layout = value;
		}
 	    public Layout GeoRegionIsoCode
		{
			get => _innerLayout.GeoRegionIsoCode.Layout;
			set => _innerLayout.GeoRegionIsoCode.Layout = value;
		}
 	    public Layout GeoName
		{
			get => _innerLayout.GeoName.Layout;
			set => _innerLayout.GeoName.Layout = value;
		}
 	    public Layout GroupId
		{
			get => _innerLayout.GroupId.Layout;
			set => _innerLayout.GroupId.Layout = value;
		}
 	    public Layout GroupName
		{
			get => _innerLayout.GroupName.Layout;
			set => _innerLayout.GroupName.Layout = value;
		}
 	    public Layout GroupDomain
		{
			get => _innerLayout.GroupDomain.Layout;
			set => _innerLayout.GroupDomain.Layout = value;
		}
 	    public Layout HashMd5
		{
			get => _innerLayout.HashMd5.Layout;
			set => _innerLayout.HashMd5.Layout = value;
		}
 	    public Layout HashSha1
		{
			get => _innerLayout.HashSha1.Layout;
			set => _innerLayout.HashSha1.Layout = value;
		}
 	    public Layout HashSha256
		{
			get => _innerLayout.HashSha256.Layout;
			set => _innerLayout.HashSha256.Layout = value;
		}
 	    public Layout HashSha512
		{
			get => _innerLayout.HashSha512.Layout;
			set => _innerLayout.HashSha512.Layout = value;
		}
 	    public Layout HostHostname
		{
			get => _innerLayout.HostHostname.Layout;
			set => _innerLayout.HostHostname.Layout = value;
		}
 	    public Layout HostName
		{
			get => _innerLayout.HostName.Layout;
			set => _innerLayout.HostName.Layout = value;
		}
 	    public Layout HostId
		{
			get => _innerLayout.HostId.Layout;
			set => _innerLayout.HostId.Layout = value;
		}
 	    public Layout HostIp
		{
			get => _innerLayout.HostIp.Layout;
			set => _innerLayout.HostIp.Layout = value;
		}
 	    public Layout HostMac
		{
			get => _innerLayout.HostMac.Layout;
			set => _innerLayout.HostMac.Layout = value;
		}
 	    public Layout HostType
		{
			get => _innerLayout.HostType.Layout;
			set => _innerLayout.HostType.Layout = value;
		}
 	    public Layout HostUptime
		{
			get => _innerLayout.HostUptime.Layout;
			set => _innerLayout.HostUptime.Layout = value;
		}
 	    public Layout HostArchitecture
		{
			get => _innerLayout.HostArchitecture.Layout;
			set => _innerLayout.HostArchitecture.Layout = value;
		}
 	    public Layout HostDomain
		{
			get => _innerLayout.HostDomain.Layout;
			set => _innerLayout.HostDomain.Layout = value;
		}
 	    public Layout HttpVersion
		{
			get => _innerLayout.HttpVersion.Layout;
			set => _innerLayout.HttpVersion.Layout = value;
		}
 	    public Layout LogLevel
		{
			get => _innerLayout.LogLevel.Layout;
			set => _innerLayout.LogLevel.Layout = value;
		}
 	    public Layout LogOriginal
		{
			get => _innerLayout.LogOriginal.Layout;
			set => _innerLayout.LogOriginal.Layout = value;
		}
 	    public Layout LogLogger
		{
			get => _innerLayout.LogLogger.Layout;
			set => _innerLayout.LogLogger.Layout = value;
		}
 	    public Layout NetworkName
		{
			get => _innerLayout.NetworkName.Layout;
			set => _innerLayout.NetworkName.Layout = value;
		}
 	    public Layout NetworkType
		{
			get => _innerLayout.NetworkType.Layout;
			set => _innerLayout.NetworkType.Layout = value;
		}
 	    public Layout NetworkIanaNumber
		{
			get => _innerLayout.NetworkIanaNumber.Layout;
			set => _innerLayout.NetworkIanaNumber.Layout = value;
		}
 	    public Layout NetworkTransport
		{
			get => _innerLayout.NetworkTransport.Layout;
			set => _innerLayout.NetworkTransport.Layout = value;
		}
 	    public Layout NetworkApplication
		{
			get => _innerLayout.NetworkApplication.Layout;
			set => _innerLayout.NetworkApplication.Layout = value;
		}
 	    public Layout NetworkProtocol
		{
			get => _innerLayout.NetworkProtocol.Layout;
			set => _innerLayout.NetworkProtocol.Layout = value;
		}
 	    public Layout NetworkDirection
		{
			get => _innerLayout.NetworkDirection.Layout;
			set => _innerLayout.NetworkDirection.Layout = value;
		}
 	    public Layout NetworkForwardedIp
		{
			get => _innerLayout.NetworkForwardedIp.Layout;
			set => _innerLayout.NetworkForwardedIp.Layout = value;
		}
 	    public Layout NetworkCommunityId
		{
			get => _innerLayout.NetworkCommunityId.Layout;
			set => _innerLayout.NetworkCommunityId.Layout = value;
		}
 	    public Layout NetworkBytes
		{
			get => _innerLayout.NetworkBytes.Layout;
			set => _innerLayout.NetworkBytes.Layout = value;
		}
 	    public Layout NetworkPackets
		{
			get => _innerLayout.NetworkPackets.Layout;
			set => _innerLayout.NetworkPackets.Layout = value;
		}
 	    public Layout ObserverMac
		{
			get => _innerLayout.ObserverMac.Layout;
			set => _innerLayout.ObserverMac.Layout = value;
		}
 	    public Layout ObserverIp
		{
			get => _innerLayout.ObserverIp.Layout;
			set => _innerLayout.ObserverIp.Layout = value;
		}
 	    public Layout ObserverHostname
		{
			get => _innerLayout.ObserverHostname.Layout;
			set => _innerLayout.ObserverHostname.Layout = value;
		}
 	    public Layout ObserverName
		{
			get => _innerLayout.ObserverName.Layout;
			set => _innerLayout.ObserverName.Layout = value;
		}
 	    public Layout ObserverProduct
		{
			get => _innerLayout.ObserverProduct.Layout;
			set => _innerLayout.ObserverProduct.Layout = value;
		}
 	    public Layout ObserverVendor
		{
			get => _innerLayout.ObserverVendor.Layout;
			set => _innerLayout.ObserverVendor.Layout = value;
		}
 	    public Layout ObserverVersion
		{
			get => _innerLayout.ObserverVersion.Layout;
			set => _innerLayout.ObserverVersion.Layout = value;
		}
 	    public Layout ObserverSerialNumber
		{
			get => _innerLayout.ObserverSerialNumber.Layout;
			set => _innerLayout.ObserverSerialNumber.Layout = value;
		}
 	    public Layout ObserverType
		{
			get => _innerLayout.ObserverType.Layout;
			set => _innerLayout.ObserverType.Layout = value;
		}
 	    public Layout OrganizationName
		{
			get => _innerLayout.OrganizationName.Layout;
			set => _innerLayout.OrganizationName.Layout = value;
		}
 	    public Layout OrganizationId
		{
			get => _innerLayout.OrganizationId.Layout;
			set => _innerLayout.OrganizationId.Layout = value;
		}
 	    public Layout OsPlatform
		{
			get => _innerLayout.OsPlatform.Layout;
			set => _innerLayout.OsPlatform.Layout = value;
		}
 	    public Layout OsName
		{
			get => _innerLayout.OsName.Layout;
			set => _innerLayout.OsName.Layout = value;
		}
 	    public Layout OsFull
		{
			get => _innerLayout.OsFull.Layout;
			set => _innerLayout.OsFull.Layout = value;
		}
 	    public Layout OsFamily
		{
			get => _innerLayout.OsFamily.Layout;
			set => _innerLayout.OsFamily.Layout = value;
		}
 	    public Layout OsVersion
		{
			get => _innerLayout.OsVersion.Layout;
			set => _innerLayout.OsVersion.Layout = value;
		}
 	    public Layout OsKernel
		{
			get => _innerLayout.OsKernel.Layout;
			set => _innerLayout.OsKernel.Layout = value;
		}
 	    public Layout PackageName
		{
			get => _innerLayout.PackageName.Layout;
			set => _innerLayout.PackageName.Layout = value;
		}
 	    public Layout PackageVersion
		{
			get => _innerLayout.PackageVersion.Layout;
			set => _innerLayout.PackageVersion.Layout = value;
		}
 	    public Layout PackageBuildVersion
		{
			get => _innerLayout.PackageBuildVersion.Layout;
			set => _innerLayout.PackageBuildVersion.Layout = value;
		}
 	    public Layout PackageDescription
		{
			get => _innerLayout.PackageDescription.Layout;
			set => _innerLayout.PackageDescription.Layout = value;
		}
 	    public Layout PackageSize
		{
			get => _innerLayout.PackageSize.Layout;
			set => _innerLayout.PackageSize.Layout = value;
		}
 	    public Layout PackageInstalled
		{
			get => _innerLayout.PackageInstalled.Layout;
			set => _innerLayout.PackageInstalled.Layout = value;
		}
 	    public Layout PackagePath
		{
			get => _innerLayout.PackagePath.Layout;
			set => _innerLayout.PackagePath.Layout = value;
		}
 	    public Layout PackageArchitecture
		{
			get => _innerLayout.PackageArchitecture.Layout;
			set => _innerLayout.PackageArchitecture.Layout = value;
		}
 	    public Layout PackageChecksum
		{
			get => _innerLayout.PackageChecksum.Layout;
			set => _innerLayout.PackageChecksum.Layout = value;
		}
 	    public Layout PackageInstallScope
		{
			get => _innerLayout.PackageInstallScope.Layout;
			set => _innerLayout.PackageInstallScope.Layout = value;
		}
 	    public Layout PackageLicense
		{
			get => _innerLayout.PackageLicense.Layout;
			set => _innerLayout.PackageLicense.Layout = value;
		}
 	    public Layout PackageReference
		{
			get => _innerLayout.PackageReference.Layout;
			set => _innerLayout.PackageReference.Layout = value;
		}
 	    public Layout PackageType
		{
			get => _innerLayout.PackageType.Layout;
			set => _innerLayout.PackageType.Layout = value;
		}
 	    public Layout ProcessPid
		{
			get => _innerLayout.ProcessPid.Layout;
			set => _innerLayout.ProcessPid.Layout = value;
		}
 	    public Layout ProcessName
		{
			get => _innerLayout.ProcessName.Layout;
			set => _innerLayout.ProcessName.Layout = value;
		}
 	    public Layout ProcessPpid
		{
			get => _innerLayout.ProcessPpid.Layout;
			set => _innerLayout.ProcessPpid.Layout = value;
		}
 	    public Layout ProcessPgid
		{
			get => _innerLayout.ProcessPgid.Layout;
			set => _innerLayout.ProcessPgid.Layout = value;
		}
 	    public Layout ProcessCommandLine
		{
			get => _innerLayout.ProcessCommandLine.Layout;
			set => _innerLayout.ProcessCommandLine.Layout = value;
		}
 	    public Layout ProcessArgs
		{
			get => _innerLayout.ProcessArgs.Layout;
			set => _innerLayout.ProcessArgs.Layout = value;
		}
 	    public Layout ProcessArgsCount
		{
			get => _innerLayout.ProcessArgsCount.Layout;
			set => _innerLayout.ProcessArgsCount.Layout = value;
		}
 	    public Layout ProcessExecutable
		{
			get => _innerLayout.ProcessExecutable.Layout;
			set => _innerLayout.ProcessExecutable.Layout = value;
		}
 	    public Layout ProcessTitle
		{
			get => _innerLayout.ProcessTitle.Layout;
			set => _innerLayout.ProcessTitle.Layout = value;
		}
 	    public Layout ProcessStart
		{
			get => _innerLayout.ProcessStart.Layout;
			set => _innerLayout.ProcessStart.Layout = value;
		}
 	    public Layout ProcessUptime
		{
			get => _innerLayout.ProcessUptime.Layout;
			set => _innerLayout.ProcessUptime.Layout = value;
		}
 	    public Layout ProcessWorkingDirectory
		{
			get => _innerLayout.ProcessWorkingDirectory.Layout;
			set => _innerLayout.ProcessWorkingDirectory.Layout = value;
		}
 	    public Layout ProcessExitCode
		{
			get => _innerLayout.ProcessExitCode.Layout;
			set => _innerLayout.ProcessExitCode.Layout = value;
		}
 	    public Layout RegistryHive
		{
			get => _innerLayout.RegistryHive.Layout;
			set => _innerLayout.RegistryHive.Layout = value;
		}
 	    public Layout RegistryKey
		{
			get => _innerLayout.RegistryKey.Layout;
			set => _innerLayout.RegistryKey.Layout = value;
		}
 	    public Layout RegistryValue
		{
			get => _innerLayout.RegistryValue.Layout;
			set => _innerLayout.RegistryValue.Layout = value;
		}
 	    public Layout RegistryPath
		{
			get => _innerLayout.RegistryPath.Layout;
			set => _innerLayout.RegistryPath.Layout = value;
		}
 	    public Layout RelatedIp
		{
			get => _innerLayout.RelatedIp.Layout;
			set => _innerLayout.RelatedIp.Layout = value;
		}
 	    public Layout RelatedUser
		{
			get => _innerLayout.RelatedUser.Layout;
			set => _innerLayout.RelatedUser.Layout = value;
		}
 	    public Layout RuleId
		{
			get => _innerLayout.RuleId.Layout;
			set => _innerLayout.RuleId.Layout = value;
		}
 	    public Layout RuleUuid
		{
			get => _innerLayout.RuleUuid.Layout;
			set => _innerLayout.RuleUuid.Layout = value;
		}
 	    public Layout RuleVersion
		{
			get => _innerLayout.RuleVersion.Layout;
			set => _innerLayout.RuleVersion.Layout = value;
		}
 	    public Layout RuleName
		{
			get => _innerLayout.RuleName.Layout;
			set => _innerLayout.RuleName.Layout = value;
		}
 	    public Layout RuleDescription
		{
			get => _innerLayout.RuleDescription.Layout;
			set => _innerLayout.RuleDescription.Layout = value;
		}
 	    public Layout RuleCategory
		{
			get => _innerLayout.RuleCategory.Layout;
			set => _innerLayout.RuleCategory.Layout = value;
		}
 	    public Layout RuleRuleset
		{
			get => _innerLayout.RuleRuleset.Layout;
			set => _innerLayout.RuleRuleset.Layout = value;
		}
 	    public Layout RuleReference
		{
			get => _innerLayout.RuleReference.Layout;
			set => _innerLayout.RuleReference.Layout = value;
		}
 	    public Layout ServerAddress
		{
			get => _innerLayout.ServerAddress.Layout;
			set => _innerLayout.ServerAddress.Layout = value;
		}
 	    public Layout ServerIp
		{
			get => _innerLayout.ServerIp.Layout;
			set => _innerLayout.ServerIp.Layout = value;
		}
 	    public Layout ServerPort
		{
			get => _innerLayout.ServerPort.Layout;
			set => _innerLayout.ServerPort.Layout = value;
		}
 	    public Layout ServerMac
		{
			get => _innerLayout.ServerMac.Layout;
			set => _innerLayout.ServerMac.Layout = value;
		}
 	    public Layout ServerDomain
		{
			get => _innerLayout.ServerDomain.Layout;
			set => _innerLayout.ServerDomain.Layout = value;
		}
 	    public Layout ServerRegisteredDomain
		{
			get => _innerLayout.ServerRegisteredDomain.Layout;
			set => _innerLayout.ServerRegisteredDomain.Layout = value;
		}
 	    public Layout ServerTopLevelDomain
		{
			get => _innerLayout.ServerTopLevelDomain.Layout;
			set => _innerLayout.ServerTopLevelDomain.Layout = value;
		}
 	    public Layout ServerBytes
		{
			get => _innerLayout.ServerBytes.Layout;
			set => _innerLayout.ServerBytes.Layout = value;
		}
 	    public Layout ServerPackets
		{
			get => _innerLayout.ServerPackets.Layout;
			set => _innerLayout.ServerPackets.Layout = value;
		}
 	    public Layout ServiceId
		{
			get => _innerLayout.ServiceId.Layout;
			set => _innerLayout.ServiceId.Layout = value;
		}
 	    public Layout ServiceName
		{
			get => _innerLayout.ServiceName.Layout;
			set => _innerLayout.ServiceName.Layout = value;
		}
 	    public Layout ServiceType
		{
			get => _innerLayout.ServiceType.Layout;
			set => _innerLayout.ServiceType.Layout = value;
		}
 	    public Layout ServiceState
		{
			get => _innerLayout.ServiceState.Layout;
			set => _innerLayout.ServiceState.Layout = value;
		}
 	    public Layout ServiceVersion
		{
			get => _innerLayout.ServiceVersion.Layout;
			set => _innerLayout.ServiceVersion.Layout = value;
		}
 	    public Layout ServiceEphemeralId
		{
			get => _innerLayout.ServiceEphemeralId.Layout;
			set => _innerLayout.ServiceEphemeralId.Layout = value;
		}
 	    public Layout SourceAddress
		{
			get => _innerLayout.SourceAddress.Layout;
			set => _innerLayout.SourceAddress.Layout = value;
		}
 	    public Layout SourceIp
		{
			get => _innerLayout.SourceIp.Layout;
			set => _innerLayout.SourceIp.Layout = value;
		}
 	    public Layout SourcePort
		{
			get => _innerLayout.SourcePort.Layout;
			set => _innerLayout.SourcePort.Layout = value;
		}
 	    public Layout SourceMac
		{
			get => _innerLayout.SourceMac.Layout;
			set => _innerLayout.SourceMac.Layout = value;
		}
 	    public Layout SourceDomain
		{
			get => _innerLayout.SourceDomain.Layout;
			set => _innerLayout.SourceDomain.Layout = value;
		}
 	    public Layout SourceRegisteredDomain
		{
			get => _innerLayout.SourceRegisteredDomain.Layout;
			set => _innerLayout.SourceRegisteredDomain.Layout = value;
		}
 	    public Layout SourceTopLevelDomain
		{
			get => _innerLayout.SourceTopLevelDomain.Layout;
			set => _innerLayout.SourceTopLevelDomain.Layout = value;
		}
 	    public Layout SourceBytes
		{
			get => _innerLayout.SourceBytes.Layout;
			set => _innerLayout.SourceBytes.Layout = value;
		}
 	    public Layout SourcePackets
		{
			get => _innerLayout.SourcePackets.Layout;
			set => _innerLayout.SourcePackets.Layout = value;
		}
 	    public Layout ThreatFramework
		{
			get => _innerLayout.ThreatFramework.Layout;
			set => _innerLayout.ThreatFramework.Layout = value;
		}
 	    public Layout TlsVersion
		{
			get => _innerLayout.TlsVersion.Layout;
			set => _innerLayout.TlsVersion.Layout = value;
		}
 	    public Layout TlsVersionProtocol
		{
			get => _innerLayout.TlsVersionProtocol.Layout;
			set => _innerLayout.TlsVersionProtocol.Layout = value;
		}
 	    public Layout TlsCipher
		{
			get => _innerLayout.TlsCipher.Layout;
			set => _innerLayout.TlsCipher.Layout = value;
		}
 	    public Layout TlsCurve
		{
			get => _innerLayout.TlsCurve.Layout;
			set => _innerLayout.TlsCurve.Layout = value;
		}
 	    public Layout TlsResumed
		{
			get => _innerLayout.TlsResumed.Layout;
			set => _innerLayout.TlsResumed.Layout = value;
		}
 	    public Layout TlsEstablished
		{
			get => _innerLayout.TlsEstablished.Layout;
			set => _innerLayout.TlsEstablished.Layout = value;
		}
 	    public Layout TlsNextProtocol
		{
			get => _innerLayout.TlsNextProtocol.Layout;
			set => _innerLayout.TlsNextProtocol.Layout = value;
		}
 	    public Layout UrlOriginal
		{
			get => _innerLayout.UrlOriginal.Layout;
			set => _innerLayout.UrlOriginal.Layout = value;
		}
 	    public Layout UrlFull
		{
			get => _innerLayout.UrlFull.Layout;
			set => _innerLayout.UrlFull.Layout = value;
		}
 	    public Layout UrlScheme
		{
			get => _innerLayout.UrlScheme.Layout;
			set => _innerLayout.UrlScheme.Layout = value;
		}
 	    public Layout UrlDomain
		{
			get => _innerLayout.UrlDomain.Layout;
			set => _innerLayout.UrlDomain.Layout = value;
		}
 	    public Layout UrlRegisteredDomain
		{
			get => _innerLayout.UrlRegisteredDomain.Layout;
			set => _innerLayout.UrlRegisteredDomain.Layout = value;
		}
 	    public Layout UrlTopLevelDomain
		{
			get => _innerLayout.UrlTopLevelDomain.Layout;
			set => _innerLayout.UrlTopLevelDomain.Layout = value;
		}
 	    public Layout UrlPort
		{
			get => _innerLayout.UrlPort.Layout;
			set => _innerLayout.UrlPort.Layout = value;
		}
 	    public Layout UrlPath
		{
			get => _innerLayout.UrlPath.Layout;
			set => _innerLayout.UrlPath.Layout = value;
		}
 	    public Layout UrlQuery
		{
			get => _innerLayout.UrlQuery.Layout;
			set => _innerLayout.UrlQuery.Layout = value;
		}
 	    public Layout UrlExtension
		{
			get => _innerLayout.UrlExtension.Layout;
			set => _innerLayout.UrlExtension.Layout = value;
		}
 	    public Layout UrlFragment
		{
			get => _innerLayout.UrlFragment.Layout;
			set => _innerLayout.UrlFragment.Layout = value;
		}
 	    public Layout UrlUsername
		{
			get => _innerLayout.UrlUsername.Layout;
			set => _innerLayout.UrlUsername.Layout = value;
		}
 	    public Layout UrlPassword
		{
			get => _innerLayout.UrlPassword.Layout;
			set => _innerLayout.UrlPassword.Layout = value;
		}
 	    public Layout UserId
		{
			get => _innerLayout.UserId.Layout;
			set => _innerLayout.UserId.Layout = value;
		}
 	    public Layout UserName
		{
			get => _innerLayout.UserName.Layout;
			set => _innerLayout.UserName.Layout = value;
		}
 	    public Layout UserFullName
		{
			get => _innerLayout.UserFullName.Layout;
			set => _innerLayout.UserFullName.Layout = value;
		}
 	    public Layout UserEmail
		{
			get => _innerLayout.UserEmail.Layout;
			set => _innerLayout.UserEmail.Layout = value;
		}
 	    public Layout UserHash
		{
			get => _innerLayout.UserHash.Layout;
			set => _innerLayout.UserHash.Layout = value;
		}
 	    public Layout UserDomain
		{
			get => _innerLayout.UserDomain.Layout;
			set => _innerLayout.UserDomain.Layout = value;
		}
 	    public Layout UserAgentOriginal
		{
			get => _innerLayout.UserAgentOriginal.Layout;
			set => _innerLayout.UserAgentOriginal.Layout = value;
		}
 	    public Layout UserAgentName
		{
			get => _innerLayout.UserAgentName.Layout;
			set => _innerLayout.UserAgentName.Layout = value;
		}
 	    public Layout UserAgentVersion
		{
			get => _innerLayout.UserAgentVersion.Layout;
			set => _innerLayout.UserAgentVersion.Layout = value;
		}
 	    public Layout VulnerabilityClassification
		{
			get => _innerLayout.VulnerabilityClassification.Layout;
			set => _innerLayout.VulnerabilityClassification.Layout = value;
		}
 	    public Layout VulnerabilityEnumeration
		{
			get => _innerLayout.VulnerabilityEnumeration.Layout;
			set => _innerLayout.VulnerabilityEnumeration.Layout = value;
		}
 	    public Layout VulnerabilityReference
		{
			get => _innerLayout.VulnerabilityReference.Layout;
			set => _innerLayout.VulnerabilityReference.Layout = value;
		}
 	    public Layout VulnerabilityCategory
		{
			get => _innerLayout.VulnerabilityCategory.Layout;
			set => _innerLayout.VulnerabilityCategory.Layout = value;
		}
 	    public Layout VulnerabilityDescription
		{
			get => _innerLayout.VulnerabilityDescription.Layout;
			set => _innerLayout.VulnerabilityDescription.Layout = value;
		}
 	    public Layout VulnerabilityId
		{
			get => _innerLayout.VulnerabilityId.Layout;
			set => _innerLayout.VulnerabilityId.Layout = value;
		}
 	    public Layout VulnerabilitySeverity
		{
			get => _innerLayout.VulnerabilitySeverity.Layout;
			set => _innerLayout.VulnerabilitySeverity.Layout = value;
		}
 	    public Layout VulnerabilityReportId
		{
			get => _innerLayout.VulnerabilityReportId.Layout;
			set => _innerLayout.VulnerabilityReportId.Layout = value;
		}
 	}
}
