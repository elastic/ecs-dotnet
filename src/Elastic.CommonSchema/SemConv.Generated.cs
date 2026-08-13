// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

/*
IMPORTANT NOTE
==============
This file has been generated.
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

namespace Elastic.CommonSchema
{
	/// <summary>
	/// OpenTelemetry semantic convention attribute name constants.
	/// Use these with <see cref="EcsDocument.AssignOTelField"/> and <see cref="EcsDocument.Attributes"/>.
	/// </summary>
	public static class SemConv
	{
		/// <summary>
		/// OTel <c>client.address</c> (match: same as ECS)
		/// </summary>
		public const string ClientAddress = "client.address";

		/// <summary>
		/// OTel <c>client.port</c> (match: same as ECS)
		/// </summary>
		public const string ClientPort = "client.port";

		/// <summary>
		/// OTel <c>cloud.account.id</c> (match: same as ECS)
		/// </summary>
		public const string CloudAccountId = "cloud.account.id";

		/// <summary>
		/// OTel <c>cloud.availability_zone</c> (match: same as ECS)
		/// </summary>
		public const string CloudAvailabilityZone = "cloud.availability_zone";

		/// <summary>
		/// OTel <c>cloud.platform</c> (equivalent: ECS <c>cloud.service.name</c>)
		/// </summary>
		public const string CloudPlatform = "cloud.platform";

		/// <summary>
		/// OTel <c>cloud.provider</c> (match: same as ECS)
		/// </summary>
		public const string CloudProvider = "cloud.provider";

		/// <summary>
		/// OTel <c>cloud.region</c> (match: same as ECS)
		/// </summary>
		public const string CloudRegion = "cloud.region";

		/// <summary>
		/// OTel <c>container.id</c> (match: same as ECS)
		/// </summary>
		public const string ContainerId = "container.id";

		/// <summary>
		/// OTel <c>container.image.name</c> (match: same as ECS)
		/// </summary>
		public const string ContainerImageName = "container.image.name";

		/// <summary>
		/// OTel <c>container.image.repo_digests</c> (equivalent: ECS <c>container.image.hash.all</c>)
		/// </summary>
		public const string ContainerImageRepoDigests = "container.image.repo_digests";

		/// <summary>
		/// OTel <c>container.image.tags</c> (equivalent: ECS <c>container.image.tag</c>)
		/// </summary>
		public const string ContainerImageTags = "container.image.tags";

		/// <summary>
		/// OTel <c>container.name</c> (match: same as ECS)
		/// </summary>
		public const string ContainerName = "container.name";

		/// <summary>
		/// OTel <c>container.runtime.name</c> (equivalent: ECS <c>container.runtime</c>)
		/// </summary>
		public const string ContainerRuntimeName = "container.runtime.name";

		/// <summary>
		/// OTel <c>deployment.environment.name</c> (equivalent: ECS <c>service.environment</c>)
		/// </summary>
		public const string DeploymentEnvironmentName = "deployment.environment.name";

		/// <summary>
		/// OTel <c>destination.address</c> (match: same as ECS)
		/// </summary>
		public const string DestinationAddress = "destination.address";

		/// <summary>
		/// OTel <c>destination.port</c> (match: same as ECS)
		/// </summary>
		public const string DestinationPort = "destination.port";

		/// <summary>
		/// OTel <c>device.id</c> (match: same as ECS)
		/// </summary>
		public const string DeviceId = "device.id";

		/// <summary>
		/// OTel <c>device.manufacturer</c> (match: same as ECS)
		/// </summary>
		public const string DeviceManufacturer = "device.manufacturer";

		/// <summary>
		/// OTel <c>device.model.identifier</c> (match: same as ECS)
		/// </summary>
		public const string DeviceModelIdentifier = "device.model.identifier";

		/// <summary>
		/// OTel <c>device.model.name</c> (match: same as ECS)
		/// </summary>
		public const string DeviceModelName = "device.model.name";

		/// <summary>
		/// OTel <c>dns.question.name</c> (match: same as ECS)
		/// </summary>
		public const string DnsQuestionName = "dns.question.name";

		/// <summary>
		/// OTel <c>error.type</c> (match: same as ECS)
		/// </summary>
		public const string ErrorType = "error.type";

		/// <summary>
		/// OTel <c>exception.message</c> (equivalent: ECS <c>error.message</c>)
		/// </summary>
		public const string ExceptionMessage = "exception.message";

		/// <summary>
		/// OTel <c>exception.stacktrace</c> (equivalent: ECS <c>error.stack_trace</c>)
		/// </summary>
		public const string ExceptionStacktrace = "exception.stacktrace";

		/// <summary>
		/// OTel <c>faas.coldstart</c> (match: same as ECS)
		/// </summary>
		public const string FaasColdstart = "faas.coldstart";

		/// <summary>
		/// OTel <c>faas.invocation_id</c> (equivalent: ECS <c>faas.execution</c>)
		/// </summary>
		public const string FaasInvocationId = "faas.invocation_id";

		/// <summary>
		/// OTel <c>faas.name</c> (match: same as ECS)
		/// </summary>
		public const string FaasName = "faas.name";

		/// <summary>
		/// OTel <c>faas.trigger</c> (equivalent: ECS <c>faas.trigger.type</c>)
		/// </summary>
		public const string FaasTrigger = "faas.trigger";

		/// <summary>
		/// OTel <c>faas.version</c> (match: same as ECS)
		/// </summary>
		public const string FaasVersion = "faas.version";

		/// <summary>
		/// OTel <c>file.accessed</c> (match: same as ECS)
		/// </summary>
		public const string FileAccessed = "file.accessed";

		/// <summary>
		/// OTel <c>file.attributes</c> (match: same as ECS)
		/// </summary>
		public const string FileAttributes = "file.attributes";

		/// <summary>
		/// OTel <c>file.changed</c> (equivalent: ECS <c>file.ctime</c>)
		/// </summary>
		public const string FileChanged = "file.changed";

		/// <summary>
		/// OTel <c>file.created</c> (match: same as ECS)
		/// </summary>
		public const string FileCreated = "file.created";

		/// <summary>
		/// OTel <c>file.directory</c> (match: same as ECS)
		/// </summary>
		public const string FileDirectory = "file.directory";

		/// <summary>
		/// OTel <c>file.extension</c> (match: same as ECS)
		/// </summary>
		public const string FileExtension = "file.extension";

		/// <summary>
		/// OTel <c>file.fork_name</c> (match: same as ECS)
		/// </summary>
		public const string FileForkName = "file.fork_name";

		/// <summary>
		/// OTel <c>file.group.id</c> (equivalent: ECS <c>file.gid</c>)
		/// </summary>
		public const string FileGroupId = "file.group.id";

		/// <summary>
		/// OTel <c>file.group.name</c> (equivalent: ECS <c>file.group</c>)
		/// </summary>
		public const string FileGroupName = "file.group.name";

		/// <summary>
		/// OTel <c>file.inode</c> (match: same as ECS)
		/// </summary>
		public const string FileInode = "file.inode";

		/// <summary>
		/// OTel <c>file.mode</c> (match: same as ECS)
		/// </summary>
		public const string FileMode = "file.mode";

		/// <summary>
		/// OTel <c>file.modified</c> (equivalent: ECS <c>file.mtime</c>)
		/// </summary>
		public const string FileModified = "file.modified";

		/// <summary>
		/// OTel <c>file.name</c> (match: same as ECS)
		/// </summary>
		public const string FileName = "file.name";

		/// <summary>
		/// OTel <c>file.owner.id</c> (equivalent: ECS <c>file.uid</c>)
		/// </summary>
		public const string FileOwnerId = "file.owner.id";

		/// <summary>
		/// OTel <c>file.owner.name</c> (equivalent: ECS <c>file.owner</c>)
		/// </summary>
		public const string FileOwnerName = "file.owner.name";

		/// <summary>
		/// OTel <c>file.path</c> (match: same as ECS)
		/// </summary>
		public const string FilePath = "file.path";

		/// <summary>
		/// OTel <c>file.size</c> (match: same as ECS)
		/// </summary>
		public const string FileSize = "file.size";

		/// <summary>
		/// OTel <c>file.symbolic_link.target_path</c> (equivalent: ECS <c>file.target_path</c>)
		/// </summary>
		public const string FileSymbolicLinkTargetPath = "file.symbolic_link.target_path";

		/// <summary>
		/// OTel <c>gen_ai.agent.description</c> (match: same as ECS)
		/// </summary>
		public const string GenAiAgentDescription = "gen_ai.agent.description";

		/// <summary>
		/// OTel <c>gen_ai.agent.id</c> (match: same as ECS)
		/// </summary>
		public const string GenAiAgentId = "gen_ai.agent.id";

		/// <summary>
		/// OTel <c>gen_ai.agent.name</c> (match: same as ECS)
		/// </summary>
		public const string GenAiAgentName = "gen_ai.agent.name";

		/// <summary>
		/// OTel <c>gen_ai.operation.name</c> (match: same as ECS)
		/// </summary>
		public const string GenAiOperationName = "gen_ai.operation.name";

		/// <summary>
		/// OTel <c>gen_ai.output.type</c> (match: same as ECS)
		/// </summary>
		public const string GenAiOutputType = "gen_ai.output.type";

		/// <summary>
		/// OTel <c>gen_ai.provider.name</c> (equivalent: ECS <c>gen_ai.system</c>)
		/// </summary>
		public const string GenAiProviderName = "gen_ai.provider.name";

		/// <summary>
		/// OTel <c>gen_ai.request.choice.count</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestChoiceCount = "gen_ai.request.choice.count";

		/// <summary>
		/// OTel <c>gen_ai.request.encoding_formats</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestEncodingFormats = "gen_ai.request.encoding_formats";

		/// <summary>
		/// OTel <c>gen_ai.request.frequency_penalty</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestFrequencyPenalty = "gen_ai.request.frequency_penalty";

		/// <summary>
		/// OTel <c>gen_ai.request.max_tokens</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestMaxTokens = "gen_ai.request.max_tokens";

		/// <summary>
		/// OTel <c>gen_ai.request.model</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestModel = "gen_ai.request.model";

		/// <summary>
		/// OTel <c>gen_ai.request.presence_penalty</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestPresencePenalty = "gen_ai.request.presence_penalty";

		/// <summary>
		/// OTel <c>gen_ai.request.seed</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestSeed = "gen_ai.request.seed";

		/// <summary>
		/// OTel <c>gen_ai.request.stop_sequences</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestStopSequences = "gen_ai.request.stop_sequences";

		/// <summary>
		/// OTel <c>gen_ai.request.temperature</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestTemperature = "gen_ai.request.temperature";

		/// <summary>
		/// OTel <c>gen_ai.request.top_k</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestTopK = "gen_ai.request.top_k";

		/// <summary>
		/// OTel <c>gen_ai.request.top_p</c> (match: same as ECS)
		/// </summary>
		public const string GenAiRequestTopP = "gen_ai.request.top_p";

		/// <summary>
		/// OTel <c>gen_ai.response.finish_reasons</c> (match: same as ECS)
		/// </summary>
		public const string GenAiResponseFinishReasons = "gen_ai.response.finish_reasons";

		/// <summary>
		/// OTel <c>gen_ai.response.id</c> (match: same as ECS)
		/// </summary>
		public const string GenAiResponseId = "gen_ai.response.id";

		/// <summary>
		/// OTel <c>gen_ai.response.model</c> (match: same as ECS)
		/// </summary>
		public const string GenAiResponseModel = "gen_ai.response.model";

		/// <summary>
		/// OTel <c>gen_ai.token.type</c> (match: same as ECS)
		/// </summary>
		public const string GenAiTokenType = "gen_ai.token.type";

		/// <summary>
		/// OTel <c>gen_ai.tool.call.id</c> (match: same as ECS)
		/// </summary>
		public const string GenAiToolCallId = "gen_ai.tool.call.id";

		/// <summary>
		/// OTel <c>gen_ai.tool.name</c> (match: same as ECS)
		/// </summary>
		public const string GenAiToolName = "gen_ai.tool.name";

		/// <summary>
		/// OTel <c>gen_ai.tool.type</c> (match: same as ECS)
		/// </summary>
		public const string GenAiToolType = "gen_ai.tool.type";

		/// <summary>
		/// OTel <c>gen_ai.usage.input_tokens</c> (match: same as ECS)
		/// </summary>
		public const string GenAiUsageInputTokens = "gen_ai.usage.input_tokens";

		/// <summary>
		/// OTel <c>gen_ai.usage.output_tokens</c> (match: same as ECS)
		/// </summary>
		public const string GenAiUsageOutputTokens = "gen_ai.usage.output_tokens";

		/// <summary>
		/// OTel <c>geo.continent.code</c> (equivalent: ECS <c>geo.continent_code</c>)
		/// </summary>
		public const string GeoContinentCode = "geo.continent.code";

		/// <summary>
		/// OTel <c>geo.country.iso_code</c> (equivalent: ECS <c>geo.country_iso_code</c>)
		/// </summary>
		public const string GeoCountryIsoCode = "geo.country.iso_code";

		/// <summary>
		/// OTel <c>geo.locality.name</c> (equivalent: ECS <c>geo.city_name</c>)
		/// </summary>
		public const string GeoLocalityName = "geo.locality.name";

		/// <summary>
		/// OTel <c>geo.postal_code</c> (match: same as ECS)
		/// </summary>
		public const string GeoPostalCode = "geo.postal_code";

		/// <summary>
		/// OTel <c>geo.region.iso_code</c> (equivalent: ECS <c>geo.region_iso_code</c>)
		/// </summary>
		public const string GeoRegionIsoCode = "geo.region.iso_code";

		/// <summary>
		/// OTel <c>host.arch</c> (equivalent: ECS <c>host.architecture</c>)
		/// </summary>
		public const string HostArch = "host.arch";

		/// <summary>
		/// OTel <c>host.id</c> (match: same as ECS)
		/// </summary>
		public const string HostId = "host.id";

		/// <summary>
		/// OTel <c>host.ip</c> (match: same as ECS)
		/// </summary>
		public const string HostIp = "host.ip";

		/// <summary>
		/// OTel <c>host.mac</c> (match: same as ECS)
		/// </summary>
		public const string HostMac = "host.mac";

		/// <summary>
		/// OTel <c>host.name</c> (match: same as ECS)
		/// </summary>
		public const string HostName = "host.name";

		/// <summary>
		/// OTel <c>host.type</c> (match: same as ECS)
		/// </summary>
		public const string HostType = "host.type";

		/// <summary>
		/// OTel <c>http.request.body.size</c> (equivalent: ECS <c>http.request.body.bytes</c>)
		/// </summary>
		public const string HttpRequestBodySize = "http.request.body.size";

		/// <summary>
		/// OTel <c>http.request.method_original</c> (equivalent: ECS <c>http.request.method</c>)
		/// </summary>
		public const string HttpRequestMethodOriginal = "http.request.method_original";

		/// <summary>
		/// OTel <c>http.request.size</c> (equivalent: ECS <c>http.request.bytes</c>)
		/// </summary>
		public const string HttpRequestSize = "http.request.size";

		/// <summary>
		/// OTel <c>http.response.body.size</c> (equivalent: ECS <c>http.response.body.bytes</c>)
		/// </summary>
		public const string HttpResponseBodySize = "http.response.body.size";

		/// <summary>
		/// OTel <c>http.response.size</c> (equivalent: ECS <c>http.response.bytes</c>)
		/// </summary>
		public const string HttpResponseSize = "http.response.size";

		/// <summary>
		/// OTel <c>http.response.status_code</c> (match: same as ECS)
		/// </summary>
		public const string HttpResponseStatusCode = "http.response.status_code";

		/// <summary>
		/// OTel <c>log.file.path</c> (match: same as ECS)
		/// </summary>
		public const string LogFilePath = "log.file.path";

		/// <summary>
		/// OTel <c>network.protocol.name</c> (equivalent: ECS <c>network.protocol</c>)
		/// </summary>
		public const string NetworkProtocolName = "network.protocol.name";

		/// <summary>
		/// OTel <c>network.transport</c> (match: same as ECS)
		/// </summary>
		public const string NetworkTransport = "network.transport";

		/// <summary>
		/// OTel <c>network.type</c> (match: same as ECS)
		/// </summary>
		public const string NetworkType = "network.type";

		/// <summary>
		/// OTel <c>os.description</c> (equivalent: ECS <c>os.full</c>)
		/// </summary>
		public const string OsDescription = "os.description";

		/// <summary>
		/// OTel <c>os.name</c> (match: same as ECS)
		/// </summary>
		public const string OsName = "os.name";

		/// <summary>
		/// OTel <c>os.version</c> (match: same as ECS)
		/// </summary>
		public const string OsVersion = "os.version";

		/// <summary>
		/// OTel <c>process.args_count</c> (match: same as ECS)
		/// </summary>
		public const string ProcessArgsCount = "process.args_count";

		/// <summary>
		/// OTel <c>process.command_args</c> (equivalent: ECS <c>process.args</c>)
		/// </summary>
		public const string ProcessCommandArgs = "process.command_args";

		/// <summary>
		/// OTel <c>process.command_line</c> (match: same as ECS)
		/// </summary>
		public const string ProcessCommandLine = "process.command_line";

		/// <summary>
		/// OTel <c>process.executable.path</c> (equivalent: ECS <c>process.executable</c>)
		/// </summary>
		public const string ProcessExecutablePath = "process.executable.path";

		/// <summary>
		/// OTel <c>process.group_leader.pid</c> (match: same as ECS)
		/// </summary>
		public const string ProcessGroupLeaderPid = "process.group_leader.pid";

		/// <summary>
		/// OTel <c>process.interactive</c> (match: same as ECS)
		/// </summary>
		public const string ProcessInteractive = "process.interactive";

		/// <summary>
		/// OTel <c>process.pid</c> (match: same as ECS)
		/// </summary>
		public const string ProcessPid = "process.pid";

		/// <summary>
		/// OTel <c>process.real_user.id</c> (match: same as ECS)
		/// </summary>
		public const string ProcessRealUserId = "process.real_user.id";

		/// <summary>
		/// OTel <c>process.real_user.name</c> (match: same as ECS)
		/// </summary>
		public const string ProcessRealUserName = "process.real_user.name";

		/// <summary>
		/// OTel <c>process.saved_user.id</c> (match: same as ECS)
		/// </summary>
		public const string ProcessSavedUserId = "process.saved_user.id";

		/// <summary>
		/// OTel <c>process.saved_user.name</c> (match: same as ECS)
		/// </summary>
		public const string ProcessSavedUserName = "process.saved_user.name";

		/// <summary>
		/// OTel <c>process.session_leader.pid</c> (match: same as ECS)
		/// </summary>
		public const string ProcessSessionLeaderPid = "process.session_leader.pid";

		/// <summary>
		/// OTel <c>process.title</c> (match: same as ECS)
		/// </summary>
		public const string ProcessTitle = "process.title";

		/// <summary>
		/// OTel <c>process.user.id</c> (match: same as ECS)
		/// </summary>
		public const string ProcessUserId = "process.user.id";

		/// <summary>
		/// OTel <c>process.user.name</c> (match: same as ECS)
		/// </summary>
		public const string ProcessUserName = "process.user.name";

		/// <summary>
		/// OTel <c>process.vpid</c> (match: same as ECS)
		/// </summary>
		public const string ProcessVpid = "process.vpid";

		/// <summary>
		/// OTel <c>process.working_directory</c> (match: same as ECS)
		/// </summary>
		public const string ProcessWorkingDirectory = "process.working_directory";

		/// <summary>
		/// OTel <c>server.address</c> (match: same as ECS)
		/// </summary>
		public const string ServerAddress = "server.address";

		/// <summary>
		/// OTel <c>server.port</c> (match: same as ECS)
		/// </summary>
		public const string ServerPort = "server.port";

		/// <summary>
		/// OTel <c>service.instance.id</c> (equivalent: ECS <c>service.node.name</c>)
		/// </summary>
		public const string ServiceInstanceId = "service.instance.id";

		/// <summary>
		/// OTel <c>service.name</c> (match: same as ECS)
		/// </summary>
		public const string ServiceName = "service.name";

		/// <summary>
		/// OTel <c>service.version</c> (match: same as ECS)
		/// </summary>
		public const string ServiceVersion = "service.version";

		/// <summary>
		/// OTel <c>source.address</c> (match: same as ECS)
		/// </summary>
		public const string SourceAddress = "source.address";

		/// <summary>
		/// OTel <c>source.port</c> (match: same as ECS)
		/// </summary>
		public const string SourcePort = "source.port";

		/// <summary>
		/// OTel <c>tls.cipher</c> (match: same as ECS)
		/// </summary>
		public const string TlsCipher = "tls.cipher";

		/// <summary>
		/// OTel <c>tls.client.certificate</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientCertificate = "tls.client.certificate";

		/// <summary>
		/// OTel <c>tls.client.certificate_chain</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientCertificateChain = "tls.client.certificate_chain";

		/// <summary>
		/// OTel <c>tls.client.hash.md5</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientHashMd5 = "tls.client.hash.md5";

		/// <summary>
		/// OTel <c>tls.client.hash.sha1</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientHashSha1 = "tls.client.hash.sha1";

		/// <summary>
		/// OTel <c>tls.client.hash.sha256</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientHashSha256 = "tls.client.hash.sha256";

		/// <summary>
		/// OTel <c>tls.client.issuer</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientIssuer = "tls.client.issuer";

		/// <summary>
		/// OTel <c>tls.client.ja3</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientJa3 = "tls.client.ja3";

		/// <summary>
		/// OTel <c>tls.client.not_after</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientNotAfter = "tls.client.not_after";

		/// <summary>
		/// OTel <c>tls.client.not_before</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientNotBefore = "tls.client.not_before";

		/// <summary>
		/// OTel <c>tls.client.subject</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientSubject = "tls.client.subject";

		/// <summary>
		/// OTel <c>tls.client.supported_ciphers</c> (match: same as ECS)
		/// </summary>
		public const string TlsClientSupportedCiphers = "tls.client.supported_ciphers";

		/// <summary>
		/// OTel <c>tls.curve</c> (match: same as ECS)
		/// </summary>
		public const string TlsCurve = "tls.curve";

		/// <summary>
		/// OTel <c>tls.established</c> (match: same as ECS)
		/// </summary>
		public const string TlsEstablished = "tls.established";

		/// <summary>
		/// OTel <c>tls.next_protocol</c> (match: same as ECS)
		/// </summary>
		public const string TlsNextProtocol = "tls.next_protocol";

		/// <summary>
		/// OTel <c>tls.resumed</c> (match: same as ECS)
		/// </summary>
		public const string TlsResumed = "tls.resumed";

		/// <summary>
		/// OTel <c>tls.server.certificate</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerCertificate = "tls.server.certificate";

		/// <summary>
		/// OTel <c>tls.server.certificate_chain</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerCertificateChain = "tls.server.certificate_chain";

		/// <summary>
		/// OTel <c>tls.server.hash.md5</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerHashMd5 = "tls.server.hash.md5";

		/// <summary>
		/// OTel <c>tls.server.hash.sha1</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerHashSha1 = "tls.server.hash.sha1";

		/// <summary>
		/// OTel <c>tls.server.hash.sha256</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerHashSha256 = "tls.server.hash.sha256";

		/// <summary>
		/// OTel <c>tls.server.issuer</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerIssuer = "tls.server.issuer";

		/// <summary>
		/// OTel <c>tls.server.ja3s</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerJa3s = "tls.server.ja3s";

		/// <summary>
		/// OTel <c>tls.server.not_after</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerNotAfter = "tls.server.not_after";

		/// <summary>
		/// OTel <c>tls.server.not_before</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerNotBefore = "tls.server.not_before";

		/// <summary>
		/// OTel <c>tls.server.subject</c> (match: same as ECS)
		/// </summary>
		public const string TlsServerSubject = "tls.server.subject";

		/// <summary>
		/// OTel <c>url.domain</c> (match: same as ECS)
		/// </summary>
		public const string UrlDomain = "url.domain";

		/// <summary>
		/// OTel <c>url.extension</c> (match: same as ECS)
		/// </summary>
		public const string UrlExtension = "url.extension";

		/// <summary>
		/// OTel <c>url.fragment</c> (match: same as ECS)
		/// </summary>
		public const string UrlFragment = "url.fragment";

		/// <summary>
		/// OTel <c>url.full</c> (match: same as ECS)
		/// </summary>
		public const string UrlFull = "url.full";

		/// <summary>
		/// OTel <c>url.original</c> (match: same as ECS)
		/// </summary>
		public const string UrlOriginal = "url.original";

		/// <summary>
		/// OTel <c>url.path</c> (match: same as ECS)
		/// </summary>
		public const string UrlPath = "url.path";

		/// <summary>
		/// OTel <c>url.port</c> (match: same as ECS)
		/// </summary>
		public const string UrlPort = "url.port";

		/// <summary>
		/// OTel <c>url.query</c> (match: same as ECS)
		/// </summary>
		public const string UrlQuery = "url.query";

		/// <summary>
		/// OTel <c>url.registered_domain</c> (match: same as ECS)
		/// </summary>
		public const string UrlRegisteredDomain = "url.registered_domain";

		/// <summary>
		/// OTel <c>url.scheme</c> (match: same as ECS)
		/// </summary>
		public const string UrlScheme = "url.scheme";

		/// <summary>
		/// OTel <c>url.subdomain</c> (match: same as ECS)
		/// </summary>
		public const string UrlSubdomain = "url.subdomain";

		/// <summary>
		/// OTel <c>url.top_level_domain</c> (match: same as ECS)
		/// </summary>
		public const string UrlTopLevelDomain = "url.top_level_domain";

		/// <summary>
		/// OTel <c>user_agent.name</c> (match: same as ECS)
		/// </summary>
		public const string UserAgentName = "user_agent.name";

		/// <summary>
		/// OTel <c>user_agent.original</c> (match: same as ECS)
		/// </summary>
		public const string UserAgentOriginal = "user_agent.original";

		/// <summary>
		/// OTel <c>user_agent.version</c> (match: same as ECS)
		/// </summary>
		public const string UserAgentVersion = "user_agent.version";

		/// <summary>
		/// OTel <c>user.email</c> (match: same as ECS)
		/// </summary>
		public const string UserEmail = "user.email";

		/// <summary>
		/// OTel <c>user.full_name</c> (match: same as ECS)
		/// </summary>
		public const string UserFullName = "user.full_name";

		/// <summary>
		/// OTel <c>user.hash</c> (match: same as ECS)
		/// </summary>
		public const string UserHash = "user.hash";

		/// <summary>
		/// OTel <c>user.id</c> (match: same as ECS)
		/// </summary>
		public const string UserId = "user.id";

		/// <summary>
		/// OTel <c>user.name</c> (match: same as ECS)
		/// </summary>
		public const string UserName = "user.name";

		/// <summary>
		/// OTel <c>user.roles</c> (match: same as ECS)
		/// </summary>
		public const string UserRoles = "user.roles";

	}
}
