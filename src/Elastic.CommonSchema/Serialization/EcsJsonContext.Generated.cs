// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information


/*
IMPORTANT NOTE
==============
This file has been generated. 
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization;

[JsonSerializable(typeof(Agent))]
[JsonSerializable(typeof(As))]
[JsonSerializable(typeof(Client))]
[JsonSerializable(typeof(Cloud))]
[JsonSerializable(typeof(CodeSignature))]
[JsonSerializable(typeof(Container))]
[JsonSerializable(typeof(DataStream))]
[JsonSerializable(typeof(Destination))]
[JsonSerializable(typeof(Device))]
[JsonSerializable(typeof(Dll))]
[JsonSerializable(typeof(Dns))]
[JsonSerializable(typeof(Ecs))]
[JsonSerializable(typeof(Elf))]
[JsonSerializable(typeof(Email))]
[JsonSerializable(typeof(Error))]
[JsonSerializable(typeof(Event))]
[JsonSerializable(typeof(Faas))]
[JsonSerializable(typeof(File))]
[JsonSerializable(typeof(Geo))]
[JsonSerializable(typeof(Group))]
[JsonSerializable(typeof(Hash))]
[JsonSerializable(typeof(Host))]
[JsonSerializable(typeof(Http))]
[JsonSerializable(typeof(Interface))]
[JsonSerializable(typeof(Log))]
[JsonSerializable(typeof(Network))]
[JsonSerializable(typeof(Observer))]
[JsonSerializable(typeof(Orchestrator))]
[JsonSerializable(typeof(Organization))]
[JsonSerializable(typeof(Os))]
[JsonSerializable(typeof(Package))]
[JsonSerializable(typeof(Pe))]
[JsonSerializable(typeof(Process))]
[JsonSerializable(typeof(Registry))]
[JsonSerializable(typeof(Related))]
[JsonSerializable(typeof(Risk))]
[JsonSerializable(typeof(Rule))]
[JsonSerializable(typeof(Server))]
[JsonSerializable(typeof(Service))]
[JsonSerializable(typeof(Source))]
[JsonSerializable(typeof(Threat))]
[JsonSerializable(typeof(Tls))]
[JsonSerializable(typeof(Url))]
[JsonSerializable(typeof(User))]
[JsonSerializable(typeof(UserAgent))]
[JsonSerializable(typeof(Vlan))]
[JsonSerializable(typeof(Vulnerability))]
[JsonSerializable(typeof(X509))]
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
internal partial class EcsJsonContext : JsonSerializerContext { }