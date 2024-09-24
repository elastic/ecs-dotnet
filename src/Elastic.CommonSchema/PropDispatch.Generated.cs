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
			if (!assigned && LogTemplateEntities.All.Contains(path))
				assigned = TrySetEntity(this, path, value);
			if (!assigned)
				SetMetaOrLabel(this, path, value);
		}
	}
	internal static partial class PropDispatch
	{

		internal static bool TrySetEntity(EcsDocument document, string path, object value)
		{
			bool TypeCheck(Dictionary<string, object> templatedObject, string typeName) =>
				templatedObject.TryGetValue("$type", out var t) && t is string s && s == typeName;
			switch (path.ToLowerInvariant())
			{

				case "agent" when value is Agent @agent:
					document.Agent = @agent;
					return true;
				case "agent" when value is Dictionary<string, object> @agent:
					if (!TypeCheck(@agent, LogTemplateEntities.Agent)) return false;
					foreach (var kvp in @agent)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetAgent(document, $"Agent{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Agent{kvp.Key}", kvp.Value);
					}
					return true;
				case "as" when value is As @as:
					document.As = @as;
					return true;
				case "as" when value is Dictionary<string, object> @as:
					if (!TypeCheck(@as, LogTemplateEntities.As)) return false;
					foreach (var kvp in @as)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetAs(document, $"As{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"As{kvp.Key}", kvp.Value);
					}
					return true;
				case "client" when value is Client @client:
					document.Client = @client;
					return true;
				case "client" when value is Dictionary<string, object> @client:
					if (!TypeCheck(@client, LogTemplateEntities.Client)) return false;
					foreach (var kvp in @client)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetClient(document, $"Client{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Client{kvp.Key}", kvp.Value);
					}
					return true;
				case "cloud" when value is Cloud @cloud:
					document.Cloud = @cloud;
					return true;
				case "cloud" when value is Dictionary<string, object> @cloud:
					if (!TypeCheck(@cloud, LogTemplateEntities.Cloud)) return false;
					foreach (var kvp in @cloud)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetCloud(document, $"Cloud{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Cloud{kvp.Key}", kvp.Value);
					}
					return true;
				case "codesignature" when value is CodeSignature @codesignature:
					document.CodeSignature = @codesignature;
					return true;
				case "codesignature" when value is Dictionary<string, object> @codesignature:
					if (!TypeCheck(@codesignature, LogTemplateEntities.CodeSignature)) return false;
					foreach (var kvp in @codesignature)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetCodeSignature(document, $"CodeSignature{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"CodeSignature{kvp.Key}", kvp.Value);
					}
					return true;
				case "container" when value is Container @container:
					document.Container = @container;
					return true;
				case "container" when value is Dictionary<string, object> @container:
					if (!TypeCheck(@container, LogTemplateEntities.Container)) return false;
					foreach (var kvp in @container)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetContainer(document, $"Container{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Container{kvp.Key}", kvp.Value);
					}
					return true;
				case "datastream" when value is DataStream @datastream:
					document.DataStream = @datastream;
					return true;
				case "datastream" when value is Dictionary<string, object> @datastream:
					if (!TypeCheck(@datastream, LogTemplateEntities.DataStream)) return false;
					foreach (var kvp in @datastream)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetDataStream(document, $"DataStream{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"DataStream{kvp.Key}", kvp.Value);
					}
					return true;
				case "destination" when value is Destination @destination:
					document.Destination = @destination;
					return true;
				case "destination" when value is Dictionary<string, object> @destination:
					if (!TypeCheck(@destination, LogTemplateEntities.Destination)) return false;
					foreach (var kvp in @destination)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetDestination(document, $"Destination{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Destination{kvp.Key}", kvp.Value);
					}
					return true;
				case "device" when value is Device @device:
					document.Device = @device;
					return true;
				case "device" when value is Dictionary<string, object> @device:
					if (!TypeCheck(@device, LogTemplateEntities.Device)) return false;
					foreach (var kvp in @device)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetDevice(document, $"Device{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Device{kvp.Key}", kvp.Value);
					}
					return true;
				case "dll" when value is Dll @dll:
					document.Dll = @dll;
					return true;
				case "dll" when value is Dictionary<string, object> @dll:
					if (!TypeCheck(@dll, LogTemplateEntities.Dll)) return false;
					foreach (var kvp in @dll)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetDll(document, $"Dll{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Dll{kvp.Key}", kvp.Value);
					}
					return true;
				case "dns" when value is Dns @dns:
					document.Dns = @dns;
					return true;
				case "dns" when value is Dictionary<string, object> @dns:
					if (!TypeCheck(@dns, LogTemplateEntities.Dns)) return false;
					foreach (var kvp in @dns)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetDns(document, $"Dns{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Dns{kvp.Key}", kvp.Value);
					}
					return true;
				case "ecs" when value is Ecs @ecs:
					document.Ecs = @ecs;
					return true;
				case "ecs" when value is Dictionary<string, object> @ecs:
					if (!TypeCheck(@ecs, LogTemplateEntities.Ecs)) return false;
					foreach (var kvp in @ecs)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetEcs(document, $"Ecs{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Ecs{kvp.Key}", kvp.Value);
					}
					return true;
				case "elf" when value is Elf @elf:
					document.Elf = @elf;
					return true;
				case "elf" when value is Dictionary<string, object> @elf:
					if (!TypeCheck(@elf, LogTemplateEntities.Elf)) return false;
					foreach (var kvp in @elf)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetElf(document, $"Elf{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Elf{kvp.Key}", kvp.Value);
					}
					return true;
				case "email" when value is Email @email:
					document.Email = @email;
					return true;
				case "email" when value is Dictionary<string, object> @email:
					if (!TypeCheck(@email, LogTemplateEntities.Email)) return false;
					foreach (var kvp in @email)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetEmail(document, $"Email{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Email{kvp.Key}", kvp.Value);
					}
					return true;
				case "error" when value is Error @error:
					document.Error = @error;
					return true;
				case "error" when value is Dictionary<string, object> @error:
					if (!TypeCheck(@error, LogTemplateEntities.Error)) return false;
					foreach (var kvp in @error)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetError(document, $"Error{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Error{kvp.Key}", kvp.Value);
					}
					return true;
				case "event" when value is Event @event:
					document.Event = @event;
					return true;
				case "event" when value is Dictionary<string, object> @event:
					if (!TypeCheck(@event, LogTemplateEntities.Event)) return false;
					foreach (var kvp in @event)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetEvent(document, $"Event{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Event{kvp.Key}", kvp.Value);
					}
					return true;
				case "faas" when value is Faas @faas:
					document.Faas = @faas;
					return true;
				case "faas" when value is Dictionary<string, object> @faas:
					if (!TypeCheck(@faas, LogTemplateEntities.Faas)) return false;
					foreach (var kvp in @faas)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetFaas(document, $"Faas{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Faas{kvp.Key}", kvp.Value);
					}
					return true;
				case "file" when value is File @file:
					document.File = @file;
					return true;
				case "file" when value is Dictionary<string, object> @file:
					if (!TypeCheck(@file, LogTemplateEntities.File)) return false;
					foreach (var kvp in @file)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetFile(document, $"File{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"File{kvp.Key}", kvp.Value);
					}
					return true;
				case "geo" when value is Geo @geo:
					document.Geo = @geo;
					return true;
				case "geo" when value is Dictionary<string, object> @geo:
					if (!TypeCheck(@geo, LogTemplateEntities.Geo)) return false;
					foreach (var kvp in @geo)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetGeo(document, $"Geo{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Geo{kvp.Key}", kvp.Value);
					}
					return true;
				case "group" when value is Group @group:
					document.Group = @group;
					return true;
				case "group" when value is Dictionary<string, object> @group:
					if (!TypeCheck(@group, LogTemplateEntities.Group)) return false;
					foreach (var kvp in @group)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetGroup(document, $"Group{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Group{kvp.Key}", kvp.Value);
					}
					return true;
				case "hash" when value is Hash @hash:
					document.Hash = @hash;
					return true;
				case "hash" when value is Dictionary<string, object> @hash:
					if (!TypeCheck(@hash, LogTemplateEntities.Hash)) return false;
					foreach (var kvp in @hash)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetHash(document, $"Hash{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Hash{kvp.Key}", kvp.Value);
					}
					return true;
				case "host" when value is Host @host:
					document.Host = @host;
					return true;
				case "host" when value is Dictionary<string, object> @host:
					if (!TypeCheck(@host, LogTemplateEntities.Host)) return false;
					foreach (var kvp in @host)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetHost(document, $"Host{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Host{kvp.Key}", kvp.Value);
					}
					return true;
				case "http" when value is Http @http:
					document.Http = @http;
					return true;
				case "http" when value is Dictionary<string, object> @http:
					if (!TypeCheck(@http, LogTemplateEntities.Http)) return false;
					foreach (var kvp in @http)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetHttp(document, $"Http{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Http{kvp.Key}", kvp.Value);
					}
					return true;
				case "interface" when value is Interface @interface:
					document.Interface = @interface;
					return true;
				case "interface" when value is Dictionary<string, object> @interface:
					if (!TypeCheck(@interface, LogTemplateEntities.Interface)) return false;
					foreach (var kvp in @interface)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetInterface(document, $"Interface{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Interface{kvp.Key}", kvp.Value);
					}
					return true;
				case "log" when value is Log @log:
					document.Log = @log;
					return true;
				case "log" when value is Dictionary<string, object> @log:
					if (!TypeCheck(@log, LogTemplateEntities.Log)) return false;
					foreach (var kvp in @log)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetLog(document, $"Log{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Log{kvp.Key}", kvp.Value);
					}
					return true;
				case "macho" when value is Macho @macho:
					document.Macho = @macho;
					return true;
				case "macho" when value is Dictionary<string, object> @macho:
					if (!TypeCheck(@macho, LogTemplateEntities.Macho)) return false;
					foreach (var kvp in @macho)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetMacho(document, $"Macho{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Macho{kvp.Key}", kvp.Value);
					}
					return true;
				case "network" when value is Network @network:
					document.Network = @network;
					return true;
				case "network" when value is Dictionary<string, object> @network:
					if (!TypeCheck(@network, LogTemplateEntities.Network)) return false;
					foreach (var kvp in @network)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetNetwork(document, $"Network{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Network{kvp.Key}", kvp.Value);
					}
					return true;
				case "observer" when value is Observer @observer:
					document.Observer = @observer;
					return true;
				case "observer" when value is Dictionary<string, object> @observer:
					if (!TypeCheck(@observer, LogTemplateEntities.Observer)) return false;
					foreach (var kvp in @observer)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetObserver(document, $"Observer{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Observer{kvp.Key}", kvp.Value);
					}
					return true;
				case "orchestrator" when value is Orchestrator @orchestrator:
					document.Orchestrator = @orchestrator;
					return true;
				case "orchestrator" when value is Dictionary<string, object> @orchestrator:
					if (!TypeCheck(@orchestrator, LogTemplateEntities.Orchestrator)) return false;
					foreach (var kvp in @orchestrator)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetOrchestrator(document, $"Orchestrator{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Orchestrator{kvp.Key}", kvp.Value);
					}
					return true;
				case "organization" when value is Organization @organization:
					document.Organization = @organization;
					return true;
				case "organization" when value is Dictionary<string, object> @organization:
					if (!TypeCheck(@organization, LogTemplateEntities.Organization)) return false;
					foreach (var kvp in @organization)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetOrganization(document, $"Organization{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Organization{kvp.Key}", kvp.Value);
					}
					return true;
				case "os" when value is Os @os:
					document.Os = @os;
					return true;
				case "os" when value is Dictionary<string, object> @os:
					if (!TypeCheck(@os, LogTemplateEntities.Os)) return false;
					foreach (var kvp in @os)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetOs(document, $"Os{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Os{kvp.Key}", kvp.Value);
					}
					return true;
				case "package" when value is Package @package:
					document.Package = @package;
					return true;
				case "package" when value is Dictionary<string, object> @package:
					if (!TypeCheck(@package, LogTemplateEntities.Package)) return false;
					foreach (var kvp in @package)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetPackage(document, $"Package{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Package{kvp.Key}", kvp.Value);
					}
					return true;
				case "pe" when value is Pe @pe:
					document.Pe = @pe;
					return true;
				case "pe" when value is Dictionary<string, object> @pe:
					if (!TypeCheck(@pe, LogTemplateEntities.Pe)) return false;
					foreach (var kvp in @pe)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetPe(document, $"Pe{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Pe{kvp.Key}", kvp.Value);
					}
					return true;
				case "process" when value is Process @process:
					document.Process = @process;
					return true;
				case "process" when value is Dictionary<string, object> @process:
					if (!TypeCheck(@process, LogTemplateEntities.Process)) return false;
					foreach (var kvp in @process)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetProcess(document, $"Process{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Process{kvp.Key}", kvp.Value);
					}
					return true;
				case "registry" when value is Registry @registry:
					document.Registry = @registry;
					return true;
				case "registry" when value is Dictionary<string, object> @registry:
					if (!TypeCheck(@registry, LogTemplateEntities.Registry)) return false;
					foreach (var kvp in @registry)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetRegistry(document, $"Registry{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Registry{kvp.Key}", kvp.Value);
					}
					return true;
				case "related" when value is Related @related:
					document.Related = @related;
					return true;
				case "related" when value is Dictionary<string, object> @related:
					if (!TypeCheck(@related, LogTemplateEntities.Related)) return false;
					foreach (var kvp in @related)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetRelated(document, $"Related{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Related{kvp.Key}", kvp.Value);
					}
					return true;
				case "risk" when value is Risk @risk:
					document.Risk = @risk;
					return true;
				case "risk" when value is Dictionary<string, object> @risk:
					if (!TypeCheck(@risk, LogTemplateEntities.Risk)) return false;
					foreach (var kvp in @risk)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetRisk(document, $"Risk{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Risk{kvp.Key}", kvp.Value);
					}
					return true;
				case "rule" when value is Rule @rule:
					document.Rule = @rule;
					return true;
				case "rule" when value is Dictionary<string, object> @rule:
					if (!TypeCheck(@rule, LogTemplateEntities.Rule)) return false;
					foreach (var kvp in @rule)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetRule(document, $"Rule{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Rule{kvp.Key}", kvp.Value);
					}
					return true;
				case "server" when value is Server @server:
					document.Server = @server;
					return true;
				case "server" when value is Dictionary<string, object> @server:
					if (!TypeCheck(@server, LogTemplateEntities.Server)) return false;
					foreach (var kvp in @server)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetServer(document, $"Server{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Server{kvp.Key}", kvp.Value);
					}
					return true;
				case "service" when value is Service @service:
					document.Service = @service;
					return true;
				case "service" when value is Dictionary<string, object> @service:
					if (!TypeCheck(@service, LogTemplateEntities.Service)) return false;
					foreach (var kvp in @service)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetService(document, $"Service{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Service{kvp.Key}", kvp.Value);
					}
					return true;
				case "source" when value is Source @source:
					document.Source = @source;
					return true;
				case "source" when value is Dictionary<string, object> @source:
					if (!TypeCheck(@source, LogTemplateEntities.Source)) return false;
					foreach (var kvp in @source)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetSource(document, $"Source{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Source{kvp.Key}", kvp.Value);
					}
					return true;
				case "threat" when value is Threat @threat:
					document.Threat = @threat;
					return true;
				case "threat" when value is Dictionary<string, object> @threat:
					if (!TypeCheck(@threat, LogTemplateEntities.Threat)) return false;
					foreach (var kvp in @threat)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetThreat(document, $"Threat{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Threat{kvp.Key}", kvp.Value);
					}
					return true;
				case "tls" when value is Tls @tls:
					document.Tls = @tls;
					return true;
				case "tls" when value is Dictionary<string, object> @tls:
					if (!TypeCheck(@tls, LogTemplateEntities.Tls)) return false;
					foreach (var kvp in @tls)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetTls(document, $"Tls{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Tls{kvp.Key}", kvp.Value);
					}
					return true;
				case "url" when value is Url @url:
					document.Url = @url;
					return true;
				case "url" when value is Dictionary<string, object> @url:
					if (!TypeCheck(@url, LogTemplateEntities.Url)) return false;
					foreach (var kvp in @url)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetUrl(document, $"Url{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Url{kvp.Key}", kvp.Value);
					}
					return true;
				case "user" when value is User @user:
					document.User = @user;
					return true;
				case "user" when value is Dictionary<string, object> @user:
					if (!TypeCheck(@user, LogTemplateEntities.User)) return false;
					foreach (var kvp in @user)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetUser(document, $"User{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"User{kvp.Key}", kvp.Value);
					}
					return true;
				case "useragent" when value is UserAgent @useragent:
					document.UserAgent = @useragent;
					return true;
				case "useragent" when value is Dictionary<string, object> @useragent:
					if (!TypeCheck(@useragent, LogTemplateEntities.UserAgent)) return false;
					foreach (var kvp in @useragent)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetUserAgent(document, $"UserAgent{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"UserAgent{kvp.Key}", kvp.Value);
					}
					return true;
				case "vlan" when value is Vlan @vlan:
					document.Vlan = @vlan;
					return true;
				case "vlan" when value is Dictionary<string, object> @vlan:
					if (!TypeCheck(@vlan, LogTemplateEntities.Vlan)) return false;
					foreach (var kvp in @vlan)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetVlan(document, $"Vlan{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Vlan{kvp.Key}", kvp.Value);
					}
					return true;
				case "vulnerability" when value is Vulnerability @vulnerability:
					document.Vulnerability = @vulnerability;
					return true;
				case "vulnerability" when value is Dictionary<string, object> @vulnerability:
					if (!TypeCheck(@vulnerability, LogTemplateEntities.Vulnerability)) return false;
					foreach (var kvp in @vulnerability)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetVulnerability(document, $"Vulnerability{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Vulnerability{kvp.Key}", kvp.Value);
					}
					return true;
				case "x509" when value is X509 @x509:
					document.X509 = @x509;
					return true;
				case "x509" when value is Dictionary<string, object> @x509:
					if (!TypeCheck(@x509, LogTemplateEntities.X509)) return false;
					foreach (var kvp in @x509)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetX509(document, $"X509{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"X509{kvp.Key}", kvp.Value);
					}
					return true;
				default:
					return false;
			}
		}

		internal static bool TrySet(EcsDocument document, string path, object value)
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
				case "client.as.number":
				case "ClientAsNumber":
				case "client.as.organization.name":
				case "ClientAsOrganizationName":
				case "client.geo.city_name":
				case "ClientGeoCityName":
				case "client.geo.continent_code":
				case "ClientGeoContinentCode":
				case "client.geo.continent_name":
				case "ClientGeoContinentName":
				case "client.geo.country_iso_code":
				case "ClientGeoCountryIsoCode":
				case "client.geo.country_name":
				case "ClientGeoCountryName":
				case "client.geo.name":
				case "ClientGeoName":
				case "client.geo.postal_code":
				case "ClientGeoPostalCode":
				case "client.geo.region_iso_code":
				case "ClientGeoRegionIsoCode":
				case "client.geo.region_name":
				case "ClientGeoRegionName":
				case "client.geo.timezone":
				case "ClientGeoTimezone":
				case "client.user.domain":
				case "ClientUserDomain":
				case "client.user.email":
				case "ClientUserEmail":
				case "client.user.full_name":
				case "ClientUserFullName":
				case "client.user.hash":
				case "ClientUserHash":
				case "client.user.id":
				case "ClientUserId":
				case "client.user.name":
				case "ClientUserName":
				case "client.user.group.domain":
				case "ClientUserGroupDomain":
				case "client.user.group.id":
				case "ClientUserGroupId":
				case "client.user.group.name":
				case "ClientUserGroupName":
				case "client.user.risk.calculated_level":
				case "ClientUserRiskCalculatedLevel":
				case "client.user.risk.calculated_score":
				case "ClientUserRiskCalculatedScore":
				case "client.user.risk.calculated_score_norm":
				case "ClientUserRiskCalculatedScoreNorm":
				case "client.user.risk.static_level":
				case "ClientUserRiskStaticLevel":
				case "client.user.risk.static_score":
				case "ClientUserRiskStaticScore":
				case "client.user.risk.static_score_norm":
				case "ClientUserRiskStaticScoreNorm":
				case "client.user.user.domain":
				case "ClientUserUserDomain":
				case "client.user.user.email":
				case "ClientUserUserEmail":
				case "client.user.user.full_name":
				case "ClientUserUserFullName":
				case "client.user.user.hash":
				case "ClientUserUserHash":
				case "client.user.user.id":
				case "ClientUserUserId":
				case "client.user.user.name":
				case "ClientUserUserName":
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
				case "cloud.cloud.account.id":
				case "CloudCloudAccountId":
				case "cloud.cloud.account.name":
				case "CloudCloudAccountName":
				case "cloud.cloud.availability_zone":
				case "CloudCloudAvailabilityZone":
				case "cloud.cloud.instance.id":
				case "CloudCloudInstanceId":
				case "cloud.cloud.instance.name":
				case "CloudCloudInstanceName":
				case "cloud.cloud.machine.type":
				case "CloudCloudMachineType":
				case "cloud.cloud.project.id":
				case "CloudCloudProjectId":
				case "cloud.cloud.project.name":
				case "CloudCloudProjectName":
				case "cloud.cloud.provider":
				case "CloudCloudProvider":
				case "cloud.cloud.region":
				case "CloudCloudRegion":
				case "cloud.cloud.service.name":
				case "CloudCloudServiceName":
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
				case "container.security_context.privileged":
				case "ContainerSecurityContextPrivileged":
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
				case "destination.as.number":
				case "DestinationAsNumber":
				case "destination.as.organization.name":
				case "DestinationAsOrganizationName":
				case "destination.geo.city_name":
				case "DestinationGeoCityName":
				case "destination.geo.continent_code":
				case "DestinationGeoContinentCode":
				case "destination.geo.continent_name":
				case "DestinationGeoContinentName":
				case "destination.geo.country_iso_code":
				case "DestinationGeoCountryIsoCode":
				case "destination.geo.country_name":
				case "DestinationGeoCountryName":
				case "destination.geo.name":
				case "DestinationGeoName":
				case "destination.geo.postal_code":
				case "DestinationGeoPostalCode":
				case "destination.geo.region_iso_code":
				case "DestinationGeoRegionIsoCode":
				case "destination.geo.region_name":
				case "DestinationGeoRegionName":
				case "destination.geo.timezone":
				case "DestinationGeoTimezone":
				case "destination.user.domain":
				case "DestinationUserDomain":
				case "destination.user.email":
				case "DestinationUserEmail":
				case "destination.user.full_name":
				case "DestinationUserFullName":
				case "destination.user.hash":
				case "DestinationUserHash":
				case "destination.user.id":
				case "DestinationUserId":
				case "destination.user.name":
				case "DestinationUserName":
				case "destination.user.group.domain":
				case "DestinationUserGroupDomain":
				case "destination.user.group.id":
				case "DestinationUserGroupId":
				case "destination.user.group.name":
				case "DestinationUserGroupName":
				case "destination.user.risk.calculated_level":
				case "DestinationUserRiskCalculatedLevel":
				case "destination.user.risk.calculated_score":
				case "DestinationUserRiskCalculatedScore":
				case "destination.user.risk.calculated_score_norm":
				case "DestinationUserRiskCalculatedScoreNorm":
				case "destination.user.risk.static_level":
				case "DestinationUserRiskStaticLevel":
				case "destination.user.risk.static_score":
				case "DestinationUserRiskStaticScore":
				case "destination.user.risk.static_score_norm":
				case "DestinationUserRiskStaticScoreNorm":
				case "destination.user.user.domain":
				case "DestinationUserUserDomain":
				case "destination.user.user.email":
				case "DestinationUserUserEmail":
				case "destination.user.user.full_name":
				case "DestinationUserUserFullName":
				case "destination.user.user.hash":
				case "DestinationUserUserHash":
				case "destination.user.user.id":
				case "DestinationUserUserId":
				case "destination.user.user.name":
				case "DestinationUserUserName":
					return TrySetDestination(document, path, value);
				case "device.id":
				case "DeviceId":
				case "device.manufacturer":
				case "DeviceManufacturer":
				case "device.model.identifier":
				case "DeviceModelIdentifier":
				case "device.model.name":
				case "DeviceModelName":
					return TrySetDevice(document, path, value);
				case "dll.name":
				case "DllName":
				case "dll.path":
				case "DllPath":
				case "dll.hash.md5":
				case "DllHashMd5":
				case "dll.hash.sha1":
				case "DllHashSha1":
				case "dll.hash.sha256":
				case "DllHashSha256":
				case "dll.hash.sha384":
				case "DllHashSha384":
				case "dll.hash.sha512":
				case "DllHashSha512":
				case "dll.hash.ssdeep":
				case "DllHashSsdeep":
				case "dll.hash.tlsh":
				case "DllHashTlsh":
				case "dll.pe.architecture":
				case "DllPeArchitecture":
				case "dll.pe.company":
				case "DllPeCompany":
				case "dll.pe.description":
				case "DllPeDescription":
				case "dll.pe.file_version":
				case "DllPeFileVersion":
				case "dll.pe.go_import_hash":
				case "DllPeGoImportHash":
				case "dll.pe.go_imports":
				case "DllPeGoImports":
				case "dll.pe.go_imports_names_entropy":
				case "DllPeGoImportsNamesEntropy":
				case "dll.pe.go_imports_names_var_entropy":
				case "DllPeGoImportsNamesVarEntropy":
				case "dll.pe.go_stripped":
				case "DllPeGoStripped":
				case "dll.pe.imphash":
				case "DllPeImphash":
				case "dll.pe.import_hash":
				case "DllPeImportHash":
				case "dll.pe.imports_names_entropy":
				case "DllPeImportsNamesEntropy":
				case "dll.pe.imports_names_var_entropy":
				case "DllPeImportsNamesVarEntropy":
				case "dll.pe.original_file_name":
				case "DllPeOriginalFileName":
				case "dll.pe.pehash":
				case "DllPePehash":
				case "dll.pe.product":
				case "DllPeProduct":
				case "dll.code_signature.digest_algorithm":
				case "DllCodeSignatureDigestAlgorithm":
				case "dll.code_signature.exists":
				case "DllCodeSignatureExists":
				case "dll.code_signature.signing_id":
				case "DllCodeSignatureSigningId":
				case "dll.code_signature.status":
				case "DllCodeSignatureStatus":
				case "dll.code_signature.subject_name":
				case "DllCodeSignatureSubjectName":
				case "dll.code_signature.team_id":
				case "DllCodeSignatureTeamId":
				case "dll.code_signature.timestamp":
				case "DllCodeSignatureTimestamp":
				case "dll.code_signature.trusted":
				case "DllCodeSignatureTrusted":
				case "dll.code_signature.valid":
				case "DllCodeSignatureValid":
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
				case "elf.go_import_hash":
				case "ElfGoImportHash":
				case "elf.go_imports":
				case "ElfGoImports":
				case "elf.go_imports_names_entropy":
				case "ElfGoImportsNamesEntropy":
				case "elf.go_imports_names_var_entropy":
				case "ElfGoImportsNamesVarEntropy":
				case "elf.go_stripped":
				case "ElfGoStripped":
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
				case "elf.import_hash":
				case "ElfImportHash":
				case "elf.imports_names_entropy":
				case "ElfImportsNamesEntropy":
				case "elf.imports_names_var_entropy":
				case "ElfImportsNamesVarEntropy":
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
				case "faas.trigger.request_id":
				case "FaasTriggerRequestId":
				case "faas.trigger.type":
				case "FaasTriggerType":
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
				case "file.hash.md5":
				case "FileHashMd5":
				case "file.hash.sha1":
				case "FileHashSha1":
				case "file.hash.sha256":
				case "FileHashSha256":
				case "file.hash.sha384":
				case "FileHashSha384":
				case "file.hash.sha512":
				case "FileHashSha512":
				case "file.hash.ssdeep":
				case "FileHashSsdeep":
				case "file.hash.tlsh":
				case "FileHashTlsh":
				case "file.pe.architecture":
				case "FilePeArchitecture":
				case "file.pe.company":
				case "FilePeCompany":
				case "file.pe.description":
				case "FilePeDescription":
				case "file.pe.file_version":
				case "FilePeFileVersion":
				case "file.pe.go_import_hash":
				case "FilePeGoImportHash":
				case "file.pe.go_imports":
				case "FilePeGoImports":
				case "file.pe.go_imports_names_entropy":
				case "FilePeGoImportsNamesEntropy":
				case "file.pe.go_imports_names_var_entropy":
				case "FilePeGoImportsNamesVarEntropy":
				case "file.pe.go_stripped":
				case "FilePeGoStripped":
				case "file.pe.imphash":
				case "FilePeImphash":
				case "file.pe.import_hash":
				case "FilePeImportHash":
				case "file.pe.imports_names_entropy":
				case "FilePeImportsNamesEntropy":
				case "file.pe.imports_names_var_entropy":
				case "FilePeImportsNamesVarEntropy":
				case "file.pe.original_file_name":
				case "FilePeOriginalFileName":
				case "file.pe.pehash":
				case "FilePePehash":
				case "file.pe.product":
				case "FilePeProduct":
				case "file.x509.issuer.distinguished_name":
				case "FileX509IssuerDistinguishedName":
				case "file.x509.not_after":
				case "FileX509NotAfter":
				case "file.x509.not_before":
				case "FileX509NotBefore":
				case "file.x509.public_key_algorithm":
				case "FileX509PublicKeyAlgorithm":
				case "file.x509.public_key_curve":
				case "FileX509PublicKeyCurve":
				case "file.x509.public_key_exponent":
				case "FileX509PublicKeyExponent":
				case "file.x509.public_key_size":
				case "FileX509PublicKeySize":
				case "file.x509.serial_number":
				case "FileX509SerialNumber":
				case "file.x509.signature_algorithm":
				case "FileX509SignatureAlgorithm":
				case "file.x509.subject.distinguished_name":
				case "FileX509SubjectDistinguishedName":
				case "file.x509.version_number":
				case "FileX509VersionNumber":
				case "file.code_signature.digest_algorithm":
				case "FileCodeSignatureDigestAlgorithm":
				case "file.code_signature.exists":
				case "FileCodeSignatureExists":
				case "file.code_signature.signing_id":
				case "FileCodeSignatureSigningId":
				case "file.code_signature.status":
				case "FileCodeSignatureStatus":
				case "file.code_signature.subject_name":
				case "FileCodeSignatureSubjectName":
				case "file.code_signature.team_id":
				case "FileCodeSignatureTeamId":
				case "file.code_signature.timestamp":
				case "FileCodeSignatureTimestamp":
				case "file.code_signature.trusted":
				case "FileCodeSignatureTrusted":
				case "file.code_signature.valid":
				case "FileCodeSignatureValid":
				case "file.elf.architecture":
				case "FileElfArchitecture":
				case "file.elf.byte_order":
				case "FileElfByteOrder":
				case "file.elf.cpu_type":
				case "FileElfCpuType":
				case "file.elf.creation_date":
				case "FileElfCreationDate":
				case "file.elf.go_import_hash":
				case "FileElfGoImportHash":
				case "file.elf.go_imports":
				case "FileElfGoImports":
				case "file.elf.go_imports_names_entropy":
				case "FileElfGoImportsNamesEntropy":
				case "file.elf.go_imports_names_var_entropy":
				case "FileElfGoImportsNamesVarEntropy":
				case "file.elf.go_stripped":
				case "FileElfGoStripped":
				case "file.elf.header.abi_version":
				case "FileElfHeaderAbiVersion":
				case "file.elf.header.class":
				case "FileElfHeaderClass":
				case "file.elf.header.data":
				case "FileElfHeaderData":
				case "file.elf.header.entrypoint":
				case "FileElfHeaderEntrypoint":
				case "file.elf.header.object_version":
				case "FileElfHeaderObjectVersion":
				case "file.elf.header.os_abi":
				case "FileElfHeaderOsAbi":
				case "file.elf.header.type":
				case "FileElfHeaderType":
				case "file.elf.header.version":
				case "FileElfHeaderVersion":
				case "file.elf.import_hash":
				case "FileElfImportHash":
				case "file.elf.imports_names_entropy":
				case "FileElfImportsNamesEntropy":
				case "file.elf.imports_names_var_entropy":
				case "FileElfImportsNamesVarEntropy":
				case "file.elf.telfhash":
				case "FileElfTelfhash":
				case "file.macho.go_import_hash":
				case "FileMachoGoImportHash":
				case "file.macho.go_imports":
				case "FileMachoGoImports":
				case "file.macho.go_imports_names_entropy":
				case "FileMachoGoImportsNamesEntropy":
				case "file.macho.go_imports_names_var_entropy":
				case "FileMachoGoImportsNamesVarEntropy":
				case "file.macho.go_stripped":
				case "FileMachoGoStripped":
				case "file.macho.import_hash":
				case "FileMachoImportHash":
				case "file.macho.imports_names_entropy":
				case "FileMachoImportsNamesEntropy":
				case "file.macho.imports_names_var_entropy":
				case "FileMachoImportsNamesVarEntropy":
				case "file.macho.symhash":
				case "FileMachoSymhash":
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
				case "host.geo.city_name":
				case "HostGeoCityName":
				case "host.geo.continent_code":
				case "HostGeoContinentCode":
				case "host.geo.continent_name":
				case "HostGeoContinentName":
				case "host.geo.country_iso_code":
				case "HostGeoCountryIsoCode":
				case "host.geo.country_name":
				case "HostGeoCountryName":
				case "host.geo.name":
				case "HostGeoName":
				case "host.geo.postal_code":
				case "HostGeoPostalCode":
				case "host.geo.region_iso_code":
				case "HostGeoRegionIsoCode":
				case "host.geo.region_name":
				case "HostGeoRegionName":
				case "host.geo.timezone":
				case "HostGeoTimezone":
				case "host.os.family":
				case "HostOsFamily":
				case "host.os.full":
				case "HostOsFull":
				case "host.os.kernel":
				case "HostOsKernel":
				case "host.os.name":
				case "HostOsName":
				case "host.os.platform":
				case "HostOsPlatform":
				case "host.os.type":
				case "HostOsType":
				case "host.os.version":
				case "HostOsVersion":
				case "host.risk.calculated_level":
				case "HostRiskCalculatedLevel":
				case "host.risk.calculated_score":
				case "HostRiskCalculatedScore":
				case "host.risk.calculated_score_norm":
				case "HostRiskCalculatedScoreNorm":
				case "host.risk.static_level":
				case "HostRiskStaticLevel":
				case "host.risk.static_score":
				case "HostRiskStaticScore":
				case "host.risk.static_score_norm":
				case "HostRiskStaticScoreNorm":
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
				case "macho.go_import_hash":
				case "MachoGoImportHash":
				case "macho.go_imports":
				case "MachoGoImports":
				case "macho.go_imports_names_entropy":
				case "MachoGoImportsNamesEntropy":
				case "macho.go_imports_names_var_entropy":
				case "MachoGoImportsNamesVarEntropy":
				case "macho.go_stripped":
				case "MachoGoStripped":
				case "macho.import_hash":
				case "MachoImportHash":
				case "macho.imports_names_entropy":
				case "MachoImportsNamesEntropy":
				case "macho.imports_names_var_entropy":
				case "MachoImportsNamesVarEntropy":
				case "macho.symhash":
				case "MachoSymhash":
					return TrySetMacho(document, path, value);
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
				case "network.vlan.id":
				case "NetworkVlanId":
				case "network.vlan.name":
				case "NetworkVlanName":
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
				case "observer.geo.city_name":
				case "ObserverGeoCityName":
				case "observer.geo.continent_code":
				case "ObserverGeoContinentCode":
				case "observer.geo.continent_name":
				case "ObserverGeoContinentName":
				case "observer.geo.country_iso_code":
				case "ObserverGeoCountryIsoCode":
				case "observer.geo.country_name":
				case "ObserverGeoCountryName":
				case "observer.geo.name":
				case "ObserverGeoName":
				case "observer.geo.postal_code":
				case "ObserverGeoPostalCode":
				case "observer.geo.region_iso_code":
				case "ObserverGeoRegionIsoCode":
				case "observer.geo.region_name":
				case "ObserverGeoRegionName":
				case "observer.geo.timezone":
				case "ObserverGeoTimezone":
				case "observer.os.family":
				case "ObserverOsFamily":
				case "observer.os.full":
				case "ObserverOsFull":
				case "observer.os.kernel":
				case "ObserverOsKernel":
				case "observer.os.name":
				case "ObserverOsName":
				case "observer.os.platform":
				case "ObserverOsPlatform":
				case "observer.os.type":
				case "ObserverOsType":
				case "observer.os.version":
				case "ObserverOsVersion":
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
				case "pe.go_import_hash":
				case "PeGoImportHash":
				case "pe.go_imports":
				case "PeGoImports":
				case "pe.go_imports_names_entropy":
				case "PeGoImportsNamesEntropy":
				case "pe.go_imports_names_var_entropy":
				case "PeGoImportsNamesVarEntropy":
				case "pe.go_stripped":
				case "PeGoStripped":
				case "pe.imphash":
				case "PeImphash":
				case "pe.import_hash":
				case "PeImportHash":
				case "pe.imports_names_entropy":
				case "PeImportsNamesEntropy":
				case "pe.imports_names_var_entropy":
				case "PeImportsNamesVarEntropy":
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
				case "process.vpid":
				case "ProcessVpid":
				case "process.working_directory":
				case "ProcessWorkingDirectory":
				case "process.group.domain":
				case "ProcessGroupDomain":
				case "process.group.id":
				case "ProcessGroupId":
				case "process.group.name":
				case "ProcessGroupName":
				case "process.hash.md5":
				case "ProcessHashMd5":
				case "process.hash.sha1":
				case "ProcessHashSha1":
				case "process.hash.sha256":
				case "ProcessHashSha256":
				case "process.hash.sha384":
				case "ProcessHashSha384":
				case "process.hash.sha512":
				case "ProcessHashSha512":
				case "process.hash.ssdeep":
				case "ProcessHashSsdeep":
				case "process.hash.tlsh":
				case "ProcessHashTlsh":
				case "process.pe.architecture":
				case "ProcessPeArchitecture":
				case "process.pe.company":
				case "ProcessPeCompany":
				case "process.pe.description":
				case "ProcessPeDescription":
				case "process.pe.file_version":
				case "ProcessPeFileVersion":
				case "process.pe.go_import_hash":
				case "ProcessPeGoImportHash":
				case "process.pe.go_imports":
				case "ProcessPeGoImports":
				case "process.pe.go_imports_names_entropy":
				case "ProcessPeGoImportsNamesEntropy":
				case "process.pe.go_imports_names_var_entropy":
				case "ProcessPeGoImportsNamesVarEntropy":
				case "process.pe.go_stripped":
				case "ProcessPeGoStripped":
				case "process.pe.imphash":
				case "ProcessPeImphash":
				case "process.pe.import_hash":
				case "ProcessPeImportHash":
				case "process.pe.imports_names_entropy":
				case "ProcessPeImportsNamesEntropy":
				case "process.pe.imports_names_var_entropy":
				case "ProcessPeImportsNamesVarEntropy":
				case "process.pe.original_file_name":
				case "ProcessPeOriginalFileName":
				case "process.pe.pehash":
				case "ProcessPePehash":
				case "process.pe.product":
				case "ProcessPeProduct":
				case "process.code_signature.digest_algorithm":
				case "ProcessCodeSignatureDigestAlgorithm":
				case "process.code_signature.exists":
				case "ProcessCodeSignatureExists":
				case "process.code_signature.signing_id":
				case "ProcessCodeSignatureSigningId":
				case "process.code_signature.status":
				case "ProcessCodeSignatureStatus":
				case "process.code_signature.subject_name":
				case "ProcessCodeSignatureSubjectName":
				case "process.code_signature.team_id":
				case "ProcessCodeSignatureTeamId":
				case "process.code_signature.timestamp":
				case "ProcessCodeSignatureTimestamp":
				case "process.code_signature.trusted":
				case "ProcessCodeSignatureTrusted":
				case "process.code_signature.valid":
				case "ProcessCodeSignatureValid":
				case "process.elf.architecture":
				case "ProcessElfArchitecture":
				case "process.elf.byte_order":
				case "ProcessElfByteOrder":
				case "process.elf.cpu_type":
				case "ProcessElfCpuType":
				case "process.elf.creation_date":
				case "ProcessElfCreationDate":
				case "process.elf.go_import_hash":
				case "ProcessElfGoImportHash":
				case "process.elf.go_imports":
				case "ProcessElfGoImports":
				case "process.elf.go_imports_names_entropy":
				case "ProcessElfGoImportsNamesEntropy":
				case "process.elf.go_imports_names_var_entropy":
				case "ProcessElfGoImportsNamesVarEntropy":
				case "process.elf.go_stripped":
				case "ProcessElfGoStripped":
				case "process.elf.header.abi_version":
				case "ProcessElfHeaderAbiVersion":
				case "process.elf.header.class":
				case "ProcessElfHeaderClass":
				case "process.elf.header.data":
				case "ProcessElfHeaderData":
				case "process.elf.header.entrypoint":
				case "ProcessElfHeaderEntrypoint":
				case "process.elf.header.object_version":
				case "ProcessElfHeaderObjectVersion":
				case "process.elf.header.os_abi":
				case "ProcessElfHeaderOsAbi":
				case "process.elf.header.type":
				case "ProcessElfHeaderType":
				case "process.elf.header.version":
				case "ProcessElfHeaderVersion":
				case "process.elf.import_hash":
				case "ProcessElfImportHash":
				case "process.elf.imports_names_entropy":
				case "ProcessElfImportsNamesEntropy":
				case "process.elf.imports_names_var_entropy":
				case "ProcessElfImportsNamesVarEntropy":
				case "process.elf.telfhash":
				case "ProcessElfTelfhash":
				case "process.macho.go_import_hash":
				case "ProcessMachoGoImportHash":
				case "process.macho.go_imports":
				case "ProcessMachoGoImports":
				case "process.macho.go_imports_names_entropy":
				case "ProcessMachoGoImportsNamesEntropy":
				case "process.macho.go_imports_names_var_entropy":
				case "ProcessMachoGoImportsNamesVarEntropy":
				case "process.macho.go_stripped":
				case "ProcessMachoGoStripped":
				case "process.macho.import_hash":
				case "ProcessMachoImportHash":
				case "process.macho.imports_names_entropy":
				case "ProcessMachoImportsNamesEntropy":
				case "process.macho.imports_names_var_entropy":
				case "ProcessMachoImportsNamesVarEntropy":
				case "process.macho.symhash":
				case "ProcessMachoSymhash":
				case "process.source.address":
				case "ProcessSourceAddress":
				case "process.source.bytes":
				case "ProcessSourceBytes":
				case "process.source.domain":
				case "ProcessSourceDomain":
				case "process.source.ip":
				case "ProcessSourceIp":
				case "process.source.mac":
				case "ProcessSourceMac":
				case "process.source.nat.ip":
				case "ProcessSourceNatIp":
				case "process.source.nat.port":
				case "ProcessSourceNatPort":
				case "process.source.packets":
				case "ProcessSourcePackets":
				case "process.source.port":
				case "ProcessSourcePort":
				case "process.source.registered_domain":
				case "ProcessSourceRegisteredDomain":
				case "process.source.subdomain":
				case "ProcessSourceSubdomain":
				case "process.source.top_level_domain":
				case "ProcessSourceTopLevelDomain":
				case "process.source.as.number":
				case "ProcessSourceAsNumber":
				case "process.source.as.organization.name":
				case "ProcessSourceAsOrganizationName":
				case "process.source.geo.city_name":
				case "ProcessSourceGeoCityName":
				case "process.source.geo.continent_code":
				case "ProcessSourceGeoContinentCode":
				case "process.source.geo.continent_name":
				case "ProcessSourceGeoContinentName":
				case "process.source.geo.country_iso_code":
				case "ProcessSourceGeoCountryIsoCode":
				case "process.source.geo.country_name":
				case "ProcessSourceGeoCountryName":
				case "process.source.geo.name":
				case "ProcessSourceGeoName":
				case "process.source.geo.postal_code":
				case "ProcessSourceGeoPostalCode":
				case "process.source.geo.region_iso_code":
				case "ProcessSourceGeoRegionIsoCode":
				case "process.source.geo.region_name":
				case "ProcessSourceGeoRegionName":
				case "process.source.geo.timezone":
				case "ProcessSourceGeoTimezone":
				case "process.source.user.domain":
				case "ProcessSourceUserDomain":
				case "process.source.user.email":
				case "ProcessSourceUserEmail":
				case "process.source.user.full_name":
				case "ProcessSourceUserFullName":
				case "process.source.user.hash":
				case "ProcessSourceUserHash":
				case "process.source.user.id":
				case "ProcessSourceUserId":
				case "process.source.user.name":
				case "ProcessSourceUserName":
				case "process.source.user.group.domain":
				case "ProcessSourceUserGroupDomain":
				case "process.source.user.group.id":
				case "ProcessSourceUserGroupId":
				case "process.source.user.group.name":
				case "ProcessSourceUserGroupName":
				case "process.source.user.risk.calculated_level":
				case "ProcessSourceUserRiskCalculatedLevel":
				case "process.source.user.risk.calculated_score":
				case "ProcessSourceUserRiskCalculatedScore":
				case "process.source.user.risk.calculated_score_norm":
				case "ProcessSourceUserRiskCalculatedScoreNorm":
				case "process.source.user.risk.static_level":
				case "ProcessSourceUserRiskStaticLevel":
				case "process.source.user.risk.static_score":
				case "ProcessSourceUserRiskStaticScore":
				case "process.source.user.risk.static_score_norm":
				case "ProcessSourceUserRiskStaticScoreNorm":
				case "process.source.user.user.domain":
				case "ProcessSourceUserUserDomain":
				case "process.source.user.user.email":
				case "ProcessSourceUserUserEmail":
				case "process.source.user.user.full_name":
				case "ProcessSourceUserUserFullName":
				case "process.source.user.user.hash":
				case "ProcessSourceUserUserHash":
				case "process.source.user.user.id":
				case "ProcessSourceUserUserId":
				case "process.source.user.user.name":
				case "ProcessSourceUserUserName":
				case "process.user.domain":
				case "ProcessUserDomain":
				case "process.user.email":
				case "ProcessUserEmail":
				case "process.user.full_name":
				case "ProcessUserFullName":
				case "process.user.hash":
				case "ProcessUserHash":
				case "process.user.id":
				case "ProcessUserId":
				case "process.user.name":
				case "ProcessUserName":
				case "process.user.group.domain":
				case "ProcessUserGroupDomain":
				case "process.user.group.id":
				case "ProcessUserGroupId":
				case "process.user.group.name":
				case "ProcessUserGroupName":
				case "process.user.risk.calculated_level":
				case "ProcessUserRiskCalculatedLevel":
				case "process.user.risk.calculated_score":
				case "ProcessUserRiskCalculatedScore":
				case "process.user.risk.calculated_score_norm":
				case "ProcessUserRiskCalculatedScoreNorm":
				case "process.user.risk.static_level":
				case "ProcessUserRiskStaticLevel":
				case "process.user.risk.static_score":
				case "ProcessUserRiskStaticScore":
				case "process.user.risk.static_score_norm":
				case "ProcessUserRiskStaticScoreNorm":
				case "process.user.user.domain":
				case "ProcessUserUserDomain":
				case "process.user.user.email":
				case "ProcessUserUserEmail":
				case "process.user.user.full_name":
				case "ProcessUserUserFullName":
				case "process.user.user.hash":
				case "ProcessUserUserHash":
				case "process.user.user.id":
				case "ProcessUserUserId":
				case "process.user.user.name":
				case "ProcessUserUserName":
				case "process.process.args_count":
				case "ProcessProcessArgsCount":
				case "process.process.command_line":
				case "ProcessProcessCommandLine":
				case "process.process.end":
				case "ProcessProcessEnd":
				case "process.process.entity_id":
				case "ProcessProcessEntityId":
				case "process.process.executable":
				case "ProcessProcessExecutable":
				case "process.process.exit_code":
				case "ProcessProcessExitCode":
				case "process.process.interactive":
				case "ProcessProcessInteractive":
				case "process.process.name":
				case "ProcessProcessName":
				case "process.process.pgid":
				case "ProcessProcessPgid":
				case "process.process.pid":
				case "ProcessProcessPid":
				case "process.process.start":
				case "ProcessProcessStart":
				case "process.process.thread.id":
				case "ProcessProcessThreadId":
				case "process.process.thread.name":
				case "ProcessProcessThreadName":
				case "process.process.title":
				case "ProcessProcessTitle":
				case "process.process.uptime":
				case "ProcessProcessUptime":
				case "process.process.vpid":
				case "ProcessProcessVpid":
				case "process.process.working_directory":
				case "ProcessProcessWorkingDirectory":
				case "process.process.parent.process.args_count":
				case "ProcessProcessParentProcessArgsCount":
				case "process.process.parent.process.command_line":
				case "ProcessProcessParentProcessCommandLine":
				case "process.process.parent.process.end":
				case "ProcessProcessParentProcessEnd":
				case "process.process.parent.process.entity_id":
				case "ProcessProcessParentProcessEntityId":
				case "process.process.parent.process.executable":
				case "ProcessProcessParentProcessExecutable":
				case "process.process.parent.process.exit_code":
				case "ProcessProcessParentProcessExitCode":
				case "process.process.parent.process.interactive":
				case "ProcessProcessParentProcessInteractive":
				case "process.process.parent.process.name":
				case "ProcessProcessParentProcessName":
				case "process.process.parent.process.pgid":
				case "ProcessProcessParentProcessPgid":
				case "process.process.parent.process.pid":
				case "ProcessProcessParentProcessPid":
				case "process.process.parent.process.start":
				case "ProcessProcessParentProcessStart":
				case "process.process.parent.process.thread.id":
				case "ProcessProcessParentProcessThreadId":
				case "process.process.parent.process.thread.name":
				case "ProcessProcessParentProcessThreadName":
				case "process.process.parent.process.title":
				case "ProcessProcessParentProcessTitle":
				case "process.process.parent.process.uptime":
				case "ProcessProcessParentProcessUptime":
				case "process.process.parent.process.vpid":
				case "ProcessProcessParentProcessVpid":
				case "process.process.parent.process.working_directory":
				case "ProcessProcessParentProcessWorkingDirectory":
				case "process.process.entry_leader.process.args_count":
				case "ProcessProcessEntryLeaderProcessArgsCount":
				case "process.process.entry_leader.process.command_line":
				case "ProcessProcessEntryLeaderProcessCommandLine":
				case "process.process.entry_leader.process.end":
				case "ProcessProcessEntryLeaderProcessEnd":
				case "process.process.entry_leader.process.entity_id":
				case "ProcessProcessEntryLeaderProcessEntityId":
				case "process.process.entry_leader.process.executable":
				case "ProcessProcessEntryLeaderProcessExecutable":
				case "process.process.entry_leader.process.exit_code":
				case "ProcessProcessEntryLeaderProcessExitCode":
				case "process.process.entry_leader.process.interactive":
				case "ProcessProcessEntryLeaderProcessInteractive":
				case "process.process.entry_leader.process.name":
				case "ProcessProcessEntryLeaderProcessName":
				case "process.process.entry_leader.process.pgid":
				case "ProcessProcessEntryLeaderProcessPgid":
				case "process.process.entry_leader.process.pid":
				case "ProcessProcessEntryLeaderProcessPid":
				case "process.process.entry_leader.process.start":
				case "ProcessProcessEntryLeaderProcessStart":
				case "process.process.entry_leader.process.thread.id":
				case "ProcessProcessEntryLeaderProcessThreadId":
				case "process.process.entry_leader.process.thread.name":
				case "ProcessProcessEntryLeaderProcessThreadName":
				case "process.process.entry_leader.process.title":
				case "ProcessProcessEntryLeaderProcessTitle":
				case "process.process.entry_leader.process.uptime":
				case "ProcessProcessEntryLeaderProcessUptime":
				case "process.process.entry_leader.process.vpid":
				case "ProcessProcessEntryLeaderProcessVpid":
				case "process.process.entry_leader.process.working_directory":
				case "ProcessProcessEntryLeaderProcessWorkingDirectory":
				case "process.process.entry_leader.process.entry_leader.parent.process.args_count":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessArgsCount":
				case "process.process.entry_leader.process.entry_leader.parent.process.command_line":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessCommandLine":
				case "process.process.entry_leader.process.entry_leader.parent.process.end":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessEnd":
				case "process.process.entry_leader.process.entry_leader.parent.process.entity_id":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessEntityId":
				case "process.process.entry_leader.process.entry_leader.parent.process.executable":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessExecutable":
				case "process.process.entry_leader.process.entry_leader.parent.process.exit_code":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessExitCode":
				case "process.process.entry_leader.process.entry_leader.parent.process.interactive":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessInteractive":
				case "process.process.entry_leader.process.entry_leader.parent.process.name":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessName":
				case "process.process.entry_leader.process.entry_leader.parent.process.pgid":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessPgid":
				case "process.process.entry_leader.process.entry_leader.parent.process.pid":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessPid":
				case "process.process.entry_leader.process.entry_leader.parent.process.start":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessStart":
				case "process.process.entry_leader.process.entry_leader.parent.process.thread.id":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessThreadId":
				case "process.process.entry_leader.process.entry_leader.parent.process.thread.name":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessThreadName":
				case "process.process.entry_leader.process.entry_leader.parent.process.title":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessTitle":
				case "process.process.entry_leader.process.entry_leader.parent.process.uptime":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessUptime":
				case "process.process.entry_leader.process.entry_leader.parent.process.vpid":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessVpid":
				case "process.process.entry_leader.process.entry_leader.parent.process.working_directory":
				case "ProcessProcessEntryLeaderProcessEntryLeaderParentProcessWorkingDirectory":
				case "process.process.session_leader.process.args_count":
				case "ProcessProcessSessionLeaderProcessArgsCount":
				case "process.process.session_leader.process.command_line":
				case "ProcessProcessSessionLeaderProcessCommandLine":
				case "process.process.session_leader.process.end":
				case "ProcessProcessSessionLeaderProcessEnd":
				case "process.process.session_leader.process.entity_id":
				case "ProcessProcessSessionLeaderProcessEntityId":
				case "process.process.session_leader.process.executable":
				case "ProcessProcessSessionLeaderProcessExecutable":
				case "process.process.session_leader.process.exit_code":
				case "ProcessProcessSessionLeaderProcessExitCode":
				case "process.process.session_leader.process.interactive":
				case "ProcessProcessSessionLeaderProcessInteractive":
				case "process.process.session_leader.process.name":
				case "ProcessProcessSessionLeaderProcessName":
				case "process.process.session_leader.process.pgid":
				case "ProcessProcessSessionLeaderProcessPgid":
				case "process.process.session_leader.process.pid":
				case "ProcessProcessSessionLeaderProcessPid":
				case "process.process.session_leader.process.start":
				case "ProcessProcessSessionLeaderProcessStart":
				case "process.process.session_leader.process.thread.id":
				case "ProcessProcessSessionLeaderProcessThreadId":
				case "process.process.session_leader.process.thread.name":
				case "ProcessProcessSessionLeaderProcessThreadName":
				case "process.process.session_leader.process.title":
				case "ProcessProcessSessionLeaderProcessTitle":
				case "process.process.session_leader.process.uptime":
				case "ProcessProcessSessionLeaderProcessUptime":
				case "process.process.session_leader.process.vpid":
				case "ProcessProcessSessionLeaderProcessVpid":
				case "process.process.session_leader.process.working_directory":
				case "ProcessProcessSessionLeaderProcessWorkingDirectory":
				case "process.process.session_leader.process.session_leader.parent.process.args_count":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessArgsCount":
				case "process.process.session_leader.process.session_leader.parent.process.command_line":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessCommandLine":
				case "process.process.session_leader.process.session_leader.parent.process.end":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessEnd":
				case "process.process.session_leader.process.session_leader.parent.process.entity_id":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessEntityId":
				case "process.process.session_leader.process.session_leader.parent.process.executable":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessExecutable":
				case "process.process.session_leader.process.session_leader.parent.process.exit_code":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessExitCode":
				case "process.process.session_leader.process.session_leader.parent.process.interactive":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessInteractive":
				case "process.process.session_leader.process.session_leader.parent.process.name":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessName":
				case "process.process.session_leader.process.session_leader.parent.process.pgid":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessPgid":
				case "process.process.session_leader.process.session_leader.parent.process.pid":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessPid":
				case "process.process.session_leader.process.session_leader.parent.process.start":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessStart":
				case "process.process.session_leader.process.session_leader.parent.process.thread.id":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessThreadId":
				case "process.process.session_leader.process.session_leader.parent.process.thread.name":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessThreadName":
				case "process.process.session_leader.process.session_leader.parent.process.title":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessTitle":
				case "process.process.session_leader.process.session_leader.parent.process.uptime":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessUptime":
				case "process.process.session_leader.process.session_leader.parent.process.vpid":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessVpid":
				case "process.process.session_leader.process.session_leader.parent.process.working_directory":
				case "ProcessProcessSessionLeaderProcessSessionLeaderParentProcessWorkingDirectory":
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
				case "risk.calculated_level":
				case "RiskCalculatedLevel":
				case "risk.calculated_score":
				case "RiskCalculatedScore":
				case "risk.calculated_score_norm":
				case "RiskCalculatedScoreNorm":
				case "risk.static_level":
				case "RiskStaticLevel":
				case "risk.static_score":
				case "RiskStaticScore":
				case "risk.static_score_norm":
				case "RiskStaticScoreNorm":
					return TrySetRisk(document, path, value);
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
				case "server.as.number":
				case "ServerAsNumber":
				case "server.as.organization.name":
				case "ServerAsOrganizationName":
				case "server.geo.city_name":
				case "ServerGeoCityName":
				case "server.geo.continent_code":
				case "ServerGeoContinentCode":
				case "server.geo.continent_name":
				case "ServerGeoContinentName":
				case "server.geo.country_iso_code":
				case "ServerGeoCountryIsoCode":
				case "server.geo.country_name":
				case "ServerGeoCountryName":
				case "server.geo.name":
				case "ServerGeoName":
				case "server.geo.postal_code":
				case "ServerGeoPostalCode":
				case "server.geo.region_iso_code":
				case "ServerGeoRegionIsoCode":
				case "server.geo.region_name":
				case "ServerGeoRegionName":
				case "server.geo.timezone":
				case "ServerGeoTimezone":
				case "server.user.domain":
				case "ServerUserDomain":
				case "server.user.email":
				case "ServerUserEmail":
				case "server.user.full_name":
				case "ServerUserFullName":
				case "server.user.hash":
				case "ServerUserHash":
				case "server.user.id":
				case "ServerUserId":
				case "server.user.name":
				case "ServerUserName":
				case "server.user.group.domain":
				case "ServerUserGroupDomain":
				case "server.user.group.id":
				case "ServerUserGroupId":
				case "server.user.group.name":
				case "ServerUserGroupName":
				case "server.user.risk.calculated_level":
				case "ServerUserRiskCalculatedLevel":
				case "server.user.risk.calculated_score":
				case "ServerUserRiskCalculatedScore":
				case "server.user.risk.calculated_score_norm":
				case "ServerUserRiskCalculatedScoreNorm":
				case "server.user.risk.static_level":
				case "ServerUserRiskStaticLevel":
				case "server.user.risk.static_score":
				case "ServerUserRiskStaticScore":
				case "server.user.risk.static_score_norm":
				case "ServerUserRiskStaticScoreNorm":
				case "server.user.user.domain":
				case "ServerUserUserDomain":
				case "server.user.user.email":
				case "ServerUserUserEmail":
				case "server.user.user.full_name":
				case "ServerUserUserFullName":
				case "server.user.user.hash":
				case "ServerUserUserHash":
				case "server.user.user.id":
				case "ServerUserUserId":
				case "server.user.user.name":
				case "ServerUserUserName":
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
				case "service.service.address":
				case "ServiceServiceAddress":
				case "service.service.environment":
				case "ServiceServiceEnvironment":
				case "service.service.ephemeral_id":
				case "ServiceServiceEphemeralId":
				case "service.service.id":
				case "ServiceServiceId":
				case "service.service.name":
				case "ServiceServiceName":
				case "service.service.node.name":
				case "ServiceServiceNodeName":
				case "service.service.node.role":
				case "ServiceServiceNodeRole":
				case "service.service.state":
				case "ServiceServiceState":
				case "service.service.type":
				case "ServiceServiceType":
				case "service.service.version":
				case "ServiceServiceVersion":
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
				case "source.as.number":
				case "SourceAsNumber":
				case "source.as.organization.name":
				case "SourceAsOrganizationName":
				case "source.geo.city_name":
				case "SourceGeoCityName":
				case "source.geo.continent_code":
				case "SourceGeoContinentCode":
				case "source.geo.continent_name":
				case "SourceGeoContinentName":
				case "source.geo.country_iso_code":
				case "SourceGeoCountryIsoCode":
				case "source.geo.country_name":
				case "SourceGeoCountryName":
				case "source.geo.name":
				case "SourceGeoName":
				case "source.geo.postal_code":
				case "SourceGeoPostalCode":
				case "source.geo.region_iso_code":
				case "SourceGeoRegionIsoCode":
				case "source.geo.region_name":
				case "SourceGeoRegionName":
				case "source.geo.timezone":
				case "SourceGeoTimezone":
				case "source.user.domain":
				case "SourceUserDomain":
				case "source.user.email":
				case "SourceUserEmail":
				case "source.user.full_name":
				case "SourceUserFullName":
				case "source.user.hash":
				case "SourceUserHash":
				case "source.user.id":
				case "SourceUserId":
				case "source.user.name":
				case "SourceUserName":
				case "source.user.group.domain":
				case "SourceUserGroupDomain":
				case "source.user.group.id":
				case "SourceUserGroupId":
				case "source.user.group.name":
				case "SourceUserGroupName":
				case "source.user.risk.calculated_level":
				case "SourceUserRiskCalculatedLevel":
				case "source.user.risk.calculated_score":
				case "SourceUserRiskCalculatedScore":
				case "source.user.risk.calculated_score_norm":
				case "SourceUserRiskCalculatedScoreNorm":
				case "source.user.risk.static_level":
				case "SourceUserRiskStaticLevel":
				case "source.user.risk.static_score":
				case "SourceUserRiskStaticScore":
				case "source.user.risk.static_score_norm":
				case "SourceUserRiskStaticScoreNorm":
				case "source.user.user.domain":
				case "SourceUserUserDomain":
				case "source.user.user.email":
				case "SourceUserUserEmail":
				case "source.user.user.full_name":
				case "SourceUserUserFullName":
				case "source.user.user.hash":
				case "SourceUserUserHash":
				case "source.user.user.id":
				case "SourceUserUserId":
				case "source.user.user.name":
				case "SourceUserUserName":
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
				case "threat.indicator.marking.tlp_version":
				case "ThreatIndicatorMarkingTlpVersion":
				case "threat.indicator.modified_at":
				case "ThreatIndicatorModifiedAt":
				case "threat.indicator.name":
				case "ThreatIndicatorName":
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
				case "threat.x509.issuer.distinguished_name":
				case "ThreatX509IssuerDistinguishedName":
				case "threat.x509.not_after":
				case "ThreatX509NotAfter":
				case "threat.x509.not_before":
				case "ThreatX509NotBefore":
				case "threat.x509.public_key_algorithm":
				case "ThreatX509PublicKeyAlgorithm":
				case "threat.x509.public_key_curve":
				case "ThreatX509PublicKeyCurve":
				case "threat.x509.public_key_exponent":
				case "ThreatX509PublicKeyExponent":
				case "threat.x509.public_key_size":
				case "ThreatX509PublicKeySize":
				case "threat.x509.serial_number":
				case "ThreatX509SerialNumber":
				case "threat.x509.signature_algorithm":
				case "ThreatX509SignatureAlgorithm":
				case "threat.x509.subject.distinguished_name":
				case "ThreatX509SubjectDistinguishedName":
				case "threat.x509.version_number":
				case "ThreatX509VersionNumber":
				case "threat.as.number":
				case "ThreatAsNumber":
				case "threat.as.organization.name":
				case "ThreatAsOrganizationName":
				case "threat.file.accessed":
				case "ThreatFileAccessed":
				case "threat.file.created":
				case "ThreatFileCreated":
				case "threat.file.ctime":
				case "ThreatFileCtime":
				case "threat.file.device":
				case "ThreatFileDevice":
				case "threat.file.directory":
				case "ThreatFileDirectory":
				case "threat.file.drive_letter":
				case "ThreatFileDriveLetter":
				case "threat.file.extension":
				case "ThreatFileExtension":
				case "threat.file.fork_name":
				case "ThreatFileForkName":
				case "threat.file.gid":
				case "ThreatFileGid":
				case "threat.file.group":
				case "ThreatFileGroup":
				case "threat.file.inode":
				case "ThreatFileInode":
				case "threat.file.mime_type":
				case "ThreatFileMimeType":
				case "threat.file.mode":
				case "ThreatFileMode":
				case "threat.file.mtime":
				case "ThreatFileMtime":
				case "threat.file.name":
				case "ThreatFileName":
				case "threat.file.owner":
				case "ThreatFileOwner":
				case "threat.file.path":
				case "ThreatFilePath":
				case "threat.file.size":
				case "ThreatFileSize":
				case "threat.file.target_path":
				case "ThreatFileTargetPath":
				case "threat.file.type":
				case "ThreatFileType":
				case "threat.file.uid":
				case "ThreatFileUid":
				case "threat.file.hash.md5":
				case "ThreatFileHashMd5":
				case "threat.file.hash.sha1":
				case "ThreatFileHashSha1":
				case "threat.file.hash.sha256":
				case "ThreatFileHashSha256":
				case "threat.file.hash.sha384":
				case "ThreatFileHashSha384":
				case "threat.file.hash.sha512":
				case "ThreatFileHashSha512":
				case "threat.file.hash.ssdeep":
				case "ThreatFileHashSsdeep":
				case "threat.file.hash.tlsh":
				case "ThreatFileHashTlsh":
				case "threat.file.pe.architecture":
				case "ThreatFilePeArchitecture":
				case "threat.file.pe.company":
				case "ThreatFilePeCompany":
				case "threat.file.pe.description":
				case "ThreatFilePeDescription":
				case "threat.file.pe.file_version":
				case "ThreatFilePeFileVersion":
				case "threat.file.pe.go_import_hash":
				case "ThreatFilePeGoImportHash":
				case "threat.file.pe.go_imports":
				case "ThreatFilePeGoImports":
				case "threat.file.pe.go_imports_names_entropy":
				case "ThreatFilePeGoImportsNamesEntropy":
				case "threat.file.pe.go_imports_names_var_entropy":
				case "ThreatFilePeGoImportsNamesVarEntropy":
				case "threat.file.pe.go_stripped":
				case "ThreatFilePeGoStripped":
				case "threat.file.pe.imphash":
				case "ThreatFilePeImphash":
				case "threat.file.pe.import_hash":
				case "ThreatFilePeImportHash":
				case "threat.file.pe.imports_names_entropy":
				case "ThreatFilePeImportsNamesEntropy":
				case "threat.file.pe.imports_names_var_entropy":
				case "ThreatFilePeImportsNamesVarEntropy":
				case "threat.file.pe.original_file_name":
				case "ThreatFilePeOriginalFileName":
				case "threat.file.pe.pehash":
				case "ThreatFilePePehash":
				case "threat.file.pe.product":
				case "ThreatFilePeProduct":
				case "threat.file.x509.issuer.distinguished_name":
				case "ThreatFileX509IssuerDistinguishedName":
				case "threat.file.x509.not_after":
				case "ThreatFileX509NotAfter":
				case "threat.file.x509.not_before":
				case "ThreatFileX509NotBefore":
				case "threat.file.x509.public_key_algorithm":
				case "ThreatFileX509PublicKeyAlgorithm":
				case "threat.file.x509.public_key_curve":
				case "ThreatFileX509PublicKeyCurve":
				case "threat.file.x509.public_key_exponent":
				case "ThreatFileX509PublicKeyExponent":
				case "threat.file.x509.public_key_size":
				case "ThreatFileX509PublicKeySize":
				case "threat.file.x509.serial_number":
				case "ThreatFileX509SerialNumber":
				case "threat.file.x509.signature_algorithm":
				case "ThreatFileX509SignatureAlgorithm":
				case "threat.file.x509.subject.distinguished_name":
				case "ThreatFileX509SubjectDistinguishedName":
				case "threat.file.x509.version_number":
				case "ThreatFileX509VersionNumber":
				case "threat.file.code_signature.digest_algorithm":
				case "ThreatFileCodeSignatureDigestAlgorithm":
				case "threat.file.code_signature.exists":
				case "ThreatFileCodeSignatureExists":
				case "threat.file.code_signature.signing_id":
				case "ThreatFileCodeSignatureSigningId":
				case "threat.file.code_signature.status":
				case "ThreatFileCodeSignatureStatus":
				case "threat.file.code_signature.subject_name":
				case "ThreatFileCodeSignatureSubjectName":
				case "threat.file.code_signature.team_id":
				case "ThreatFileCodeSignatureTeamId":
				case "threat.file.code_signature.timestamp":
				case "ThreatFileCodeSignatureTimestamp":
				case "threat.file.code_signature.trusted":
				case "ThreatFileCodeSignatureTrusted":
				case "threat.file.code_signature.valid":
				case "ThreatFileCodeSignatureValid":
				case "threat.file.elf.architecture":
				case "ThreatFileElfArchitecture":
				case "threat.file.elf.byte_order":
				case "ThreatFileElfByteOrder":
				case "threat.file.elf.cpu_type":
				case "ThreatFileElfCpuType":
				case "threat.file.elf.creation_date":
				case "ThreatFileElfCreationDate":
				case "threat.file.elf.go_import_hash":
				case "ThreatFileElfGoImportHash":
				case "threat.file.elf.go_imports":
				case "ThreatFileElfGoImports":
				case "threat.file.elf.go_imports_names_entropy":
				case "ThreatFileElfGoImportsNamesEntropy":
				case "threat.file.elf.go_imports_names_var_entropy":
				case "ThreatFileElfGoImportsNamesVarEntropy":
				case "threat.file.elf.go_stripped":
				case "ThreatFileElfGoStripped":
				case "threat.file.elf.header.abi_version":
				case "ThreatFileElfHeaderAbiVersion":
				case "threat.file.elf.header.class":
				case "ThreatFileElfHeaderClass":
				case "threat.file.elf.header.data":
				case "ThreatFileElfHeaderData":
				case "threat.file.elf.header.entrypoint":
				case "ThreatFileElfHeaderEntrypoint":
				case "threat.file.elf.header.object_version":
				case "ThreatFileElfHeaderObjectVersion":
				case "threat.file.elf.header.os_abi":
				case "ThreatFileElfHeaderOsAbi":
				case "threat.file.elf.header.type":
				case "ThreatFileElfHeaderType":
				case "threat.file.elf.header.version":
				case "ThreatFileElfHeaderVersion":
				case "threat.file.elf.import_hash":
				case "ThreatFileElfImportHash":
				case "threat.file.elf.imports_names_entropy":
				case "ThreatFileElfImportsNamesEntropy":
				case "threat.file.elf.imports_names_var_entropy":
				case "ThreatFileElfImportsNamesVarEntropy":
				case "threat.file.elf.telfhash":
				case "ThreatFileElfTelfhash":
				case "threat.file.macho.go_import_hash":
				case "ThreatFileMachoGoImportHash":
				case "threat.file.macho.go_imports":
				case "ThreatFileMachoGoImports":
				case "threat.file.macho.go_imports_names_entropy":
				case "ThreatFileMachoGoImportsNamesEntropy":
				case "threat.file.macho.go_imports_names_var_entropy":
				case "ThreatFileMachoGoImportsNamesVarEntropy":
				case "threat.file.macho.go_stripped":
				case "ThreatFileMachoGoStripped":
				case "threat.file.macho.import_hash":
				case "ThreatFileMachoImportHash":
				case "threat.file.macho.imports_names_entropy":
				case "ThreatFileMachoImportsNamesEntropy":
				case "threat.file.macho.imports_names_var_entropy":
				case "ThreatFileMachoImportsNamesVarEntropy":
				case "threat.file.macho.symhash":
				case "ThreatFileMachoSymhash":
				case "threat.geo.city_name":
				case "ThreatGeoCityName":
				case "threat.geo.continent_code":
				case "ThreatGeoContinentCode":
				case "threat.geo.continent_name":
				case "ThreatGeoContinentName":
				case "threat.geo.country_iso_code":
				case "ThreatGeoCountryIsoCode":
				case "threat.geo.country_name":
				case "ThreatGeoCountryName":
				case "threat.geo.name":
				case "ThreatGeoName":
				case "threat.geo.postal_code":
				case "ThreatGeoPostalCode":
				case "threat.geo.region_iso_code":
				case "ThreatGeoRegionIsoCode":
				case "threat.geo.region_name":
				case "ThreatGeoRegionName":
				case "threat.geo.timezone":
				case "ThreatGeoTimezone":
				case "threat.registry.data.bytes":
				case "ThreatRegistryDataBytes":
				case "threat.registry.data.type":
				case "ThreatRegistryDataType":
				case "threat.registry.hive":
				case "ThreatRegistryHive":
				case "threat.registry.key":
				case "ThreatRegistryKey":
				case "threat.registry.path":
				case "ThreatRegistryPath":
				case "threat.registry.value":
				case "ThreatRegistryValue":
				case "threat.url.domain":
				case "ThreatUrlDomain":
				case "threat.url.extension":
				case "ThreatUrlExtension":
				case "threat.url.fragment":
				case "ThreatUrlFragment":
				case "threat.url.full":
				case "ThreatUrlFull":
				case "threat.url.original":
				case "ThreatUrlOriginal":
				case "threat.url.password":
				case "ThreatUrlPassword":
				case "threat.url.path":
				case "ThreatUrlPath":
				case "threat.url.port":
				case "ThreatUrlPort":
				case "threat.url.query":
				case "ThreatUrlQuery":
				case "threat.url.registered_domain":
				case "ThreatUrlRegisteredDomain":
				case "threat.url.scheme":
				case "ThreatUrlScheme":
				case "threat.url.subdomain":
				case "ThreatUrlSubdomain":
				case "threat.url.top_level_domain":
				case "ThreatUrlTopLevelDomain":
				case "threat.url.username":
				case "ThreatUrlUsername":
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
				case "tls.x509.issuer.distinguished_name":
				case "TlsX509IssuerDistinguishedName":
				case "tls.x509.not_after":
				case "TlsX509NotAfter":
				case "tls.x509.not_before":
				case "TlsX509NotBefore":
				case "tls.x509.public_key_algorithm":
				case "TlsX509PublicKeyAlgorithm":
				case "tls.x509.public_key_curve":
				case "TlsX509PublicKeyCurve":
				case "tls.x509.public_key_exponent":
				case "TlsX509PublicKeyExponent":
				case "tls.x509.public_key_size":
				case "TlsX509PublicKeySize":
				case "tls.x509.serial_number":
				case "TlsX509SerialNumber":
				case "tls.x509.signature_algorithm":
				case "TlsX509SignatureAlgorithm":
				case "tls.x509.subject.distinguished_name":
				case "TlsX509SubjectDistinguishedName":
				case "tls.x509.version_number":
				case "TlsX509VersionNumber":
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
				case "user.group.domain":
				case "UserGroupDomain":
				case "user.group.id":
				case "UserGroupId":
				case "user.group.name":
				case "UserGroupName":
				case "user.risk.calculated_level":
				case "UserRiskCalculatedLevel":
				case "user.risk.calculated_score":
				case "UserRiskCalculatedScore":
				case "user.risk.calculated_score_norm":
				case "UserRiskCalculatedScoreNorm":
				case "user.risk.static_level":
				case "UserRiskStaticLevel":
				case "user.risk.static_score":
				case "UserRiskStaticScore":
				case "user.risk.static_score_norm":
				case "UserRiskStaticScoreNorm":
				case "user.user.domain":
				case "UserUserDomain":
				case "user.user.email":
				case "UserUserEmail":
				case "user.user.full_name":
				case "UserUserFullName":
				case "user.user.hash":
				case "UserUserHash":
				case "user.user.id":
				case "UserUserId":
				case "user.user.name":
				case "UserUserName":
					return TrySetUser(document, path, value);
				case "user_agent.device.name":
				case "UserAgentDeviceName":
				case "user_agent.name":
				case "UserAgentName":
				case "user_agent.original":
				case "UserAgentOriginal":
				case "user_agent.version":
				case "UserAgentVersion":
				case "user_agent.os.family":
				case "UserAgentOsFamily":
				case "user_agent.os.full":
				case "UserAgentOsFull":
				case "user_agent.os.kernel":
				case "UserAgentOsKernel":
				case "user_agent.os.name":
				case "UserAgentOsName":
				case "user_agent.os.platform":
				case "UserAgentOsPlatform":
				case "user_agent.os.type":
				case "UserAgentOsType":
				case "user_agent.os.version":
				case "UserAgentOsVersion":
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
					return false;
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
				"client.as.number" => static (e, v) => TrySetAs(e, "as.number", v),
				"ClientAsNumber" => static (e, v) => TrySetAs(e, "as.number", v),
				"client.as.organization.name" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"ClientAsOrganizationName" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"client.geo.city_name" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"ClientGeoCityName" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"client.geo.continent_code" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"ClientGeoContinentCode" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"client.geo.continent_name" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"ClientGeoContinentName" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"client.geo.country_iso_code" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"ClientGeoCountryIsoCode" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"client.geo.country_name" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"ClientGeoCountryName" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"client.geo.name" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"ClientGeoName" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"client.geo.postal_code" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"ClientGeoPostalCode" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"client.geo.region_iso_code" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"ClientGeoRegionIsoCode" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"client.geo.region_name" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"ClientGeoRegionName" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"client.geo.timezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"ClientGeoTimezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"client.user.domain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"ClientUserDomain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"client.user.email" => static (e, v) => TrySetUser(e, "user.email", v),
				"ClientUserEmail" => static (e, v) => TrySetUser(e, "user.email", v),
				"client.user.full_name" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"ClientUserFullName" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"client.user.hash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"ClientUserHash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"client.user.id" => static (e, v) => TrySetUser(e, "user.id", v),
				"ClientUserId" => static (e, v) => TrySetUser(e, "user.id", v),
				"client.user.name" => static (e, v) => TrySetUser(e, "user.name", v),
				"ClientUserName" => static (e, v) => TrySetUser(e, "user.name", v),
				"client.user.group.domain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"ClientUserGroupDomain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"client.user.group.id" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"ClientUserGroupId" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"client.user.group.name" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"ClientUserGroupName" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"client.user.risk.calculated_level" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"ClientUserRiskCalculatedLevel" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"client.user.risk.calculated_score" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"ClientUserRiskCalculatedScore" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"client.user.risk.calculated_score_norm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"ClientUserRiskCalculatedScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"client.user.risk.static_level" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"ClientUserRiskStaticLevel" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"client.user.risk.static_score" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"ClientUserRiskStaticScore" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"client.user.risk.static_score_norm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"ClientUserRiskStaticScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"client.user.user.domain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"ClientUserUserDomain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"client.user.user.email" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"ClientUserUserEmail" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"client.user.user.full_name" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"ClientUserUserFullName" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"client.user.user.hash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"ClientUserUserHash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"client.user.user.id" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"ClientUserUserId" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"client.user.user.name" => static (e, v) => TrySetUser(e, "user.user.name", v),
				"ClientUserUserName" => static (e, v) => TrySetUser(e, "user.user.name", v),
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
				"cloud.cloud.account.id" => static (e, v) => TrySetCloudOrigin(e, "cloud.account.id", v),
				"CloudCloudAccountId" => static (e, v) => TrySetCloudOrigin(e, "cloud.account.id", v),
				"cloud.cloud.account.name" => static (e, v) => TrySetCloudOrigin(e, "cloud.account.name", v),
				"CloudCloudAccountName" => static (e, v) => TrySetCloudOrigin(e, "cloud.account.name", v),
				"cloud.cloud.availability_zone" => static (e, v) => TrySetCloudOrigin(e, "cloud.availability_zone", v),
				"CloudCloudAvailabilityZone" => static (e, v) => TrySetCloudOrigin(e, "cloud.availability_zone", v),
				"cloud.cloud.instance.id" => static (e, v) => TrySetCloudOrigin(e, "cloud.instance.id", v),
				"CloudCloudInstanceId" => static (e, v) => TrySetCloudOrigin(e, "cloud.instance.id", v),
				"cloud.cloud.instance.name" => static (e, v) => TrySetCloudOrigin(e, "cloud.instance.name", v),
				"CloudCloudInstanceName" => static (e, v) => TrySetCloudOrigin(e, "cloud.instance.name", v),
				"cloud.cloud.machine.type" => static (e, v) => TrySetCloudOrigin(e, "cloud.machine.type", v),
				"CloudCloudMachineType" => static (e, v) => TrySetCloudOrigin(e, "cloud.machine.type", v),
				"cloud.cloud.project.id" => static (e, v) => TrySetCloudOrigin(e, "cloud.project.id", v),
				"CloudCloudProjectId" => static (e, v) => TrySetCloudOrigin(e, "cloud.project.id", v),
				"cloud.cloud.project.name" => static (e, v) => TrySetCloudOrigin(e, "cloud.project.name", v),
				"CloudCloudProjectName" => static (e, v) => TrySetCloudOrigin(e, "cloud.project.name", v),
				"cloud.cloud.provider" => static (e, v) => TrySetCloudOrigin(e, "cloud.provider", v),
				"CloudCloudProvider" => static (e, v) => TrySetCloudOrigin(e, "cloud.provider", v),
				"cloud.cloud.region" => static (e, v) => TrySetCloudOrigin(e, "cloud.region", v),
				"CloudCloudRegion" => static (e, v) => TrySetCloudOrigin(e, "cloud.region", v),
				"cloud.cloud.service.name" => static (e, v) => TrySetCloudOrigin(e, "cloud.service.name", v),
				"CloudCloudServiceName" => static (e, v) => TrySetCloudOrigin(e, "cloud.service.name", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Cloud ?? new Cloud();
			var assigned = assign(entity, value);
			if (assigned) document.Cloud = entity;
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
				"container.security_context.privileged" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.SecurityContextPrivileged = p),
				"ContainerSecurityContextPrivileged" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.SecurityContextPrivileged = p),
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
				"destination.as.number" => static (e, v) => TrySetAs(e, "as.number", v),
				"DestinationAsNumber" => static (e, v) => TrySetAs(e, "as.number", v),
				"destination.as.organization.name" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"DestinationAsOrganizationName" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"destination.geo.city_name" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"DestinationGeoCityName" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"destination.geo.continent_code" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"DestinationGeoContinentCode" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"destination.geo.continent_name" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"DestinationGeoContinentName" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"destination.geo.country_iso_code" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"DestinationGeoCountryIsoCode" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"destination.geo.country_name" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"DestinationGeoCountryName" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"destination.geo.name" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"DestinationGeoName" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"destination.geo.postal_code" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"DestinationGeoPostalCode" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"destination.geo.region_iso_code" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"DestinationGeoRegionIsoCode" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"destination.geo.region_name" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"DestinationGeoRegionName" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"destination.geo.timezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"DestinationGeoTimezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"destination.user.domain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"DestinationUserDomain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"destination.user.email" => static (e, v) => TrySetUser(e, "user.email", v),
				"DestinationUserEmail" => static (e, v) => TrySetUser(e, "user.email", v),
				"destination.user.full_name" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"DestinationUserFullName" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"destination.user.hash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"DestinationUserHash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"destination.user.id" => static (e, v) => TrySetUser(e, "user.id", v),
				"DestinationUserId" => static (e, v) => TrySetUser(e, "user.id", v),
				"destination.user.name" => static (e, v) => TrySetUser(e, "user.name", v),
				"DestinationUserName" => static (e, v) => TrySetUser(e, "user.name", v),
				"destination.user.group.domain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"DestinationUserGroupDomain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"destination.user.group.id" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"DestinationUserGroupId" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"destination.user.group.name" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"DestinationUserGroupName" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"destination.user.risk.calculated_level" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"DestinationUserRiskCalculatedLevel" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"destination.user.risk.calculated_score" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"DestinationUserRiskCalculatedScore" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"destination.user.risk.calculated_score_norm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"DestinationUserRiskCalculatedScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"destination.user.risk.static_level" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"DestinationUserRiskStaticLevel" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"destination.user.risk.static_score" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"DestinationUserRiskStaticScore" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"destination.user.risk.static_score_norm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"DestinationUserRiskStaticScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"destination.user.user.domain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"DestinationUserUserDomain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"destination.user.user.email" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"DestinationUserUserEmail" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"destination.user.user.full_name" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"DestinationUserUserFullName" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"destination.user.user.hash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"DestinationUserUserHash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"destination.user.user.id" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"DestinationUserUserId" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"destination.user.user.name" => static (e, v) => TrySetUser(e, "user.user.name", v),
				"DestinationUserUserName" => static (e, v) => TrySetUser(e, "user.user.name", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Destination ?? new Destination();
			var assigned = assign(entity, value);
			if (assigned) document.Destination = entity;
			return assigned;
		}

		public static bool TrySetDevice(EcsDocument document, string path, object value)
		{
			Func<Device, object, bool> assign = path switch
			{
				"device.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"DeviceId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"device.manufacturer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Manufacturer = p),
				"DeviceManufacturer" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Manufacturer = p),
				"device.model.identifier" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ModelIdentifier = p),
				"DeviceModelIdentifier" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ModelIdentifier = p),
				"device.model.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ModelName = p),
				"DeviceModelName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ModelName = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Device ?? new Device();
			var assigned = assign(entity, value);
			if (assigned) document.Device = entity;
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
				"dll.hash.md5" => static (e, v) => TrySetHash(e, "hash.md5", v),
				"DllHashMd5" => static (e, v) => TrySetHash(e, "hash.md5", v),
				"dll.hash.sha1" => static (e, v) => TrySetHash(e, "hash.sha1", v),
				"DllHashSha1" => static (e, v) => TrySetHash(e, "hash.sha1", v),
				"dll.hash.sha256" => static (e, v) => TrySetHash(e, "hash.sha256", v),
				"DllHashSha256" => static (e, v) => TrySetHash(e, "hash.sha256", v),
				"dll.hash.sha384" => static (e, v) => TrySetHash(e, "hash.sha384", v),
				"DllHashSha384" => static (e, v) => TrySetHash(e, "hash.sha384", v),
				"dll.hash.sha512" => static (e, v) => TrySetHash(e, "hash.sha512", v),
				"DllHashSha512" => static (e, v) => TrySetHash(e, "hash.sha512", v),
				"dll.hash.ssdeep" => static (e, v) => TrySetHash(e, "hash.ssdeep", v),
				"DllHashSsdeep" => static (e, v) => TrySetHash(e, "hash.ssdeep", v),
				"dll.hash.tlsh" => static (e, v) => TrySetHash(e, "hash.tlsh", v),
				"DllHashTlsh" => static (e, v) => TrySetHash(e, "hash.tlsh", v),
				"dll.pe.architecture" => static (e, v) => TrySetPe(e, "pe.architecture", v),
				"DllPeArchitecture" => static (e, v) => TrySetPe(e, "pe.architecture", v),
				"dll.pe.company" => static (e, v) => TrySetPe(e, "pe.company", v),
				"DllPeCompany" => static (e, v) => TrySetPe(e, "pe.company", v),
				"dll.pe.description" => static (e, v) => TrySetPe(e, "pe.description", v),
				"DllPeDescription" => static (e, v) => TrySetPe(e, "pe.description", v),
				"dll.pe.file_version" => static (e, v) => TrySetPe(e, "pe.file_version", v),
				"DllPeFileVersion" => static (e, v) => TrySetPe(e, "pe.file_version", v),
				"dll.pe.go_import_hash" => static (e, v) => TrySetPe(e, "pe.go_import_hash", v),
				"DllPeGoImportHash" => static (e, v) => TrySetPe(e, "pe.go_import_hash", v),
				"dll.pe.go_imports" => static (e, v) => TrySetPe(e, "pe.go_imports", v),
				"DllPeGoImports" => static (e, v) => TrySetPe(e, "pe.go_imports", v),
				"dll.pe.go_imports_names_entropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_entropy", v),
				"DllPeGoImportsNamesEntropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_entropy", v),
				"dll.pe.go_imports_names_var_entropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_var_entropy", v),
				"DllPeGoImportsNamesVarEntropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_var_entropy", v),
				"dll.pe.go_stripped" => static (e, v) => TrySetPe(e, "pe.go_stripped", v),
				"DllPeGoStripped" => static (e, v) => TrySetPe(e, "pe.go_stripped", v),
				"dll.pe.imphash" => static (e, v) => TrySetPe(e, "pe.imphash", v),
				"DllPeImphash" => static (e, v) => TrySetPe(e, "pe.imphash", v),
				"dll.pe.import_hash" => static (e, v) => TrySetPe(e, "pe.import_hash", v),
				"DllPeImportHash" => static (e, v) => TrySetPe(e, "pe.import_hash", v),
				"dll.pe.imports_names_entropy" => static (e, v) => TrySetPe(e, "pe.imports_names_entropy", v),
				"DllPeImportsNamesEntropy" => static (e, v) => TrySetPe(e, "pe.imports_names_entropy", v),
				"dll.pe.imports_names_var_entropy" => static (e, v) => TrySetPe(e, "pe.imports_names_var_entropy", v),
				"DllPeImportsNamesVarEntropy" => static (e, v) => TrySetPe(e, "pe.imports_names_var_entropy", v),
				"dll.pe.original_file_name" => static (e, v) => TrySetPe(e, "pe.original_file_name", v),
				"DllPeOriginalFileName" => static (e, v) => TrySetPe(e, "pe.original_file_name", v),
				"dll.pe.pehash" => static (e, v) => TrySetPe(e, "pe.pehash", v),
				"DllPePehash" => static (e, v) => TrySetPe(e, "pe.pehash", v),
				"dll.pe.product" => static (e, v) => TrySetPe(e, "pe.product", v),
				"DllPeProduct" => static (e, v) => TrySetPe(e, "pe.product", v),
				"dll.code_signature.digest_algorithm" => static (e, v) => TrySetCodeSignature(e, "code_signature.digest_algorithm", v),
				"DllCodeSignatureDigestAlgorithm" => static (e, v) => TrySetCodeSignature(e, "code_signature.digest_algorithm", v),
				"dll.code_signature.exists" => static (e, v) => TrySetCodeSignature(e, "code_signature.exists", v),
				"DllCodeSignatureExists" => static (e, v) => TrySetCodeSignature(e, "code_signature.exists", v),
				"dll.code_signature.signing_id" => static (e, v) => TrySetCodeSignature(e, "code_signature.signing_id", v),
				"DllCodeSignatureSigningId" => static (e, v) => TrySetCodeSignature(e, "code_signature.signing_id", v),
				"dll.code_signature.status" => static (e, v) => TrySetCodeSignature(e, "code_signature.status", v),
				"DllCodeSignatureStatus" => static (e, v) => TrySetCodeSignature(e, "code_signature.status", v),
				"dll.code_signature.subject_name" => static (e, v) => TrySetCodeSignature(e, "code_signature.subject_name", v),
				"DllCodeSignatureSubjectName" => static (e, v) => TrySetCodeSignature(e, "code_signature.subject_name", v),
				"dll.code_signature.team_id" => static (e, v) => TrySetCodeSignature(e, "code_signature.team_id", v),
				"DllCodeSignatureTeamId" => static (e, v) => TrySetCodeSignature(e, "code_signature.team_id", v),
				"dll.code_signature.timestamp" => static (e, v) => TrySetCodeSignature(e, "code_signature.timestamp", v),
				"DllCodeSignatureTimestamp" => static (e, v) => TrySetCodeSignature(e, "code_signature.timestamp", v),
				"dll.code_signature.trusted" => static (e, v) => TrySetCodeSignature(e, "code_signature.trusted", v),
				"DllCodeSignatureTrusted" => static (e, v) => TrySetCodeSignature(e, "code_signature.trusted", v),
				"dll.code_signature.valid" => static (e, v) => TrySetCodeSignature(e, "code_signature.valid", v),
				"DllCodeSignatureValid" => static (e, v) => TrySetCodeSignature(e, "code_signature.valid", v),
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
				"faas.trigger.request_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TriggerRequestId = p),
				"FaasTriggerRequestId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TriggerRequestId = p),
				"faas.trigger.type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TriggerType = p),
				"FaasTriggerType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.TriggerType = p),
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
				"file.hash.md5" => static (e, v) => TrySetHash(e, "hash.md5", v),
				"FileHashMd5" => static (e, v) => TrySetHash(e, "hash.md5", v),
				"file.hash.sha1" => static (e, v) => TrySetHash(e, "hash.sha1", v),
				"FileHashSha1" => static (e, v) => TrySetHash(e, "hash.sha1", v),
				"file.hash.sha256" => static (e, v) => TrySetHash(e, "hash.sha256", v),
				"FileHashSha256" => static (e, v) => TrySetHash(e, "hash.sha256", v),
				"file.hash.sha384" => static (e, v) => TrySetHash(e, "hash.sha384", v),
				"FileHashSha384" => static (e, v) => TrySetHash(e, "hash.sha384", v),
				"file.hash.sha512" => static (e, v) => TrySetHash(e, "hash.sha512", v),
				"FileHashSha512" => static (e, v) => TrySetHash(e, "hash.sha512", v),
				"file.hash.ssdeep" => static (e, v) => TrySetHash(e, "hash.ssdeep", v),
				"FileHashSsdeep" => static (e, v) => TrySetHash(e, "hash.ssdeep", v),
				"file.hash.tlsh" => static (e, v) => TrySetHash(e, "hash.tlsh", v),
				"FileHashTlsh" => static (e, v) => TrySetHash(e, "hash.tlsh", v),
				"file.pe.architecture" => static (e, v) => TrySetPe(e, "pe.architecture", v),
				"FilePeArchitecture" => static (e, v) => TrySetPe(e, "pe.architecture", v),
				"file.pe.company" => static (e, v) => TrySetPe(e, "pe.company", v),
				"FilePeCompany" => static (e, v) => TrySetPe(e, "pe.company", v),
				"file.pe.description" => static (e, v) => TrySetPe(e, "pe.description", v),
				"FilePeDescription" => static (e, v) => TrySetPe(e, "pe.description", v),
				"file.pe.file_version" => static (e, v) => TrySetPe(e, "pe.file_version", v),
				"FilePeFileVersion" => static (e, v) => TrySetPe(e, "pe.file_version", v),
				"file.pe.go_import_hash" => static (e, v) => TrySetPe(e, "pe.go_import_hash", v),
				"FilePeGoImportHash" => static (e, v) => TrySetPe(e, "pe.go_import_hash", v),
				"file.pe.go_imports" => static (e, v) => TrySetPe(e, "pe.go_imports", v),
				"FilePeGoImports" => static (e, v) => TrySetPe(e, "pe.go_imports", v),
				"file.pe.go_imports_names_entropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_entropy", v),
				"FilePeGoImportsNamesEntropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_entropy", v),
				"file.pe.go_imports_names_var_entropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_var_entropy", v),
				"FilePeGoImportsNamesVarEntropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_var_entropy", v),
				"file.pe.go_stripped" => static (e, v) => TrySetPe(e, "pe.go_stripped", v),
				"FilePeGoStripped" => static (e, v) => TrySetPe(e, "pe.go_stripped", v),
				"file.pe.imphash" => static (e, v) => TrySetPe(e, "pe.imphash", v),
				"FilePeImphash" => static (e, v) => TrySetPe(e, "pe.imphash", v),
				"file.pe.import_hash" => static (e, v) => TrySetPe(e, "pe.import_hash", v),
				"FilePeImportHash" => static (e, v) => TrySetPe(e, "pe.import_hash", v),
				"file.pe.imports_names_entropy" => static (e, v) => TrySetPe(e, "pe.imports_names_entropy", v),
				"FilePeImportsNamesEntropy" => static (e, v) => TrySetPe(e, "pe.imports_names_entropy", v),
				"file.pe.imports_names_var_entropy" => static (e, v) => TrySetPe(e, "pe.imports_names_var_entropy", v),
				"FilePeImportsNamesVarEntropy" => static (e, v) => TrySetPe(e, "pe.imports_names_var_entropy", v),
				"file.pe.original_file_name" => static (e, v) => TrySetPe(e, "pe.original_file_name", v),
				"FilePeOriginalFileName" => static (e, v) => TrySetPe(e, "pe.original_file_name", v),
				"file.pe.pehash" => static (e, v) => TrySetPe(e, "pe.pehash", v),
				"FilePePehash" => static (e, v) => TrySetPe(e, "pe.pehash", v),
				"file.pe.product" => static (e, v) => TrySetPe(e, "pe.product", v),
				"FilePeProduct" => static (e, v) => TrySetPe(e, "pe.product", v),
				"file.x509.issuer.distinguished_name" => static (e, v) => TrySetX509(e, "x509.issuer.distinguished_name", v),
				"FileX509IssuerDistinguishedName" => static (e, v) => TrySetX509(e, "x509.issuer.distinguished_name", v),
				"file.x509.not_after" => static (e, v) => TrySetX509(e, "x509.not_after", v),
				"FileX509NotAfter" => static (e, v) => TrySetX509(e, "x509.not_after", v),
				"file.x509.not_before" => static (e, v) => TrySetX509(e, "x509.not_before", v),
				"FileX509NotBefore" => static (e, v) => TrySetX509(e, "x509.not_before", v),
				"file.x509.public_key_algorithm" => static (e, v) => TrySetX509(e, "x509.public_key_algorithm", v),
				"FileX509PublicKeyAlgorithm" => static (e, v) => TrySetX509(e, "x509.public_key_algorithm", v),
				"file.x509.public_key_curve" => static (e, v) => TrySetX509(e, "x509.public_key_curve", v),
				"FileX509PublicKeyCurve" => static (e, v) => TrySetX509(e, "x509.public_key_curve", v),
				"file.x509.public_key_exponent" => static (e, v) => TrySetX509(e, "x509.public_key_exponent", v),
				"FileX509PublicKeyExponent" => static (e, v) => TrySetX509(e, "x509.public_key_exponent", v),
				"file.x509.public_key_size" => static (e, v) => TrySetX509(e, "x509.public_key_size", v),
				"FileX509PublicKeySize" => static (e, v) => TrySetX509(e, "x509.public_key_size", v),
				"file.x509.serial_number" => static (e, v) => TrySetX509(e, "x509.serial_number", v),
				"FileX509SerialNumber" => static (e, v) => TrySetX509(e, "x509.serial_number", v),
				"file.x509.signature_algorithm" => static (e, v) => TrySetX509(e, "x509.signature_algorithm", v),
				"FileX509SignatureAlgorithm" => static (e, v) => TrySetX509(e, "x509.signature_algorithm", v),
				"file.x509.subject.distinguished_name" => static (e, v) => TrySetX509(e, "x509.subject.distinguished_name", v),
				"FileX509SubjectDistinguishedName" => static (e, v) => TrySetX509(e, "x509.subject.distinguished_name", v),
				"file.x509.version_number" => static (e, v) => TrySetX509(e, "x509.version_number", v),
				"FileX509VersionNumber" => static (e, v) => TrySetX509(e, "x509.version_number", v),
				"file.code_signature.digest_algorithm" => static (e, v) => TrySetCodeSignature(e, "code_signature.digest_algorithm", v),
				"FileCodeSignatureDigestAlgorithm" => static (e, v) => TrySetCodeSignature(e, "code_signature.digest_algorithm", v),
				"file.code_signature.exists" => static (e, v) => TrySetCodeSignature(e, "code_signature.exists", v),
				"FileCodeSignatureExists" => static (e, v) => TrySetCodeSignature(e, "code_signature.exists", v),
				"file.code_signature.signing_id" => static (e, v) => TrySetCodeSignature(e, "code_signature.signing_id", v),
				"FileCodeSignatureSigningId" => static (e, v) => TrySetCodeSignature(e, "code_signature.signing_id", v),
				"file.code_signature.status" => static (e, v) => TrySetCodeSignature(e, "code_signature.status", v),
				"FileCodeSignatureStatus" => static (e, v) => TrySetCodeSignature(e, "code_signature.status", v),
				"file.code_signature.subject_name" => static (e, v) => TrySetCodeSignature(e, "code_signature.subject_name", v),
				"FileCodeSignatureSubjectName" => static (e, v) => TrySetCodeSignature(e, "code_signature.subject_name", v),
				"file.code_signature.team_id" => static (e, v) => TrySetCodeSignature(e, "code_signature.team_id", v),
				"FileCodeSignatureTeamId" => static (e, v) => TrySetCodeSignature(e, "code_signature.team_id", v),
				"file.code_signature.timestamp" => static (e, v) => TrySetCodeSignature(e, "code_signature.timestamp", v),
				"FileCodeSignatureTimestamp" => static (e, v) => TrySetCodeSignature(e, "code_signature.timestamp", v),
				"file.code_signature.trusted" => static (e, v) => TrySetCodeSignature(e, "code_signature.trusted", v),
				"FileCodeSignatureTrusted" => static (e, v) => TrySetCodeSignature(e, "code_signature.trusted", v),
				"file.code_signature.valid" => static (e, v) => TrySetCodeSignature(e, "code_signature.valid", v),
				"FileCodeSignatureValid" => static (e, v) => TrySetCodeSignature(e, "code_signature.valid", v),
				"file.elf.architecture" => static (e, v) => TrySetElf(e, "elf.architecture", v),
				"FileElfArchitecture" => static (e, v) => TrySetElf(e, "elf.architecture", v),
				"file.elf.byte_order" => static (e, v) => TrySetElf(e, "elf.byte_order", v),
				"FileElfByteOrder" => static (e, v) => TrySetElf(e, "elf.byte_order", v),
				"file.elf.cpu_type" => static (e, v) => TrySetElf(e, "elf.cpu_type", v),
				"FileElfCpuType" => static (e, v) => TrySetElf(e, "elf.cpu_type", v),
				"file.elf.creation_date" => static (e, v) => TrySetElf(e, "elf.creation_date", v),
				"FileElfCreationDate" => static (e, v) => TrySetElf(e, "elf.creation_date", v),
				"file.elf.go_import_hash" => static (e, v) => TrySetElf(e, "elf.go_import_hash", v),
				"FileElfGoImportHash" => static (e, v) => TrySetElf(e, "elf.go_import_hash", v),
				"file.elf.go_imports" => static (e, v) => TrySetElf(e, "elf.go_imports", v),
				"FileElfGoImports" => static (e, v) => TrySetElf(e, "elf.go_imports", v),
				"file.elf.go_imports_names_entropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_entropy", v),
				"FileElfGoImportsNamesEntropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_entropy", v),
				"file.elf.go_imports_names_var_entropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_var_entropy", v),
				"FileElfGoImportsNamesVarEntropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_var_entropy", v),
				"file.elf.go_stripped" => static (e, v) => TrySetElf(e, "elf.go_stripped", v),
				"FileElfGoStripped" => static (e, v) => TrySetElf(e, "elf.go_stripped", v),
				"file.elf.header.abi_version" => static (e, v) => TrySetElf(e, "elf.header.abi_version", v),
				"FileElfHeaderAbiVersion" => static (e, v) => TrySetElf(e, "elf.header.abi_version", v),
				"file.elf.header.class" => static (e, v) => TrySetElf(e, "elf.header.class", v),
				"FileElfHeaderClass" => static (e, v) => TrySetElf(e, "elf.header.class", v),
				"file.elf.header.data" => static (e, v) => TrySetElf(e, "elf.header.data", v),
				"FileElfHeaderData" => static (e, v) => TrySetElf(e, "elf.header.data", v),
				"file.elf.header.entrypoint" => static (e, v) => TrySetElf(e, "elf.header.entrypoint", v),
				"FileElfHeaderEntrypoint" => static (e, v) => TrySetElf(e, "elf.header.entrypoint", v),
				"file.elf.header.object_version" => static (e, v) => TrySetElf(e, "elf.header.object_version", v),
				"FileElfHeaderObjectVersion" => static (e, v) => TrySetElf(e, "elf.header.object_version", v),
				"file.elf.header.os_abi" => static (e, v) => TrySetElf(e, "elf.header.os_abi", v),
				"FileElfHeaderOsAbi" => static (e, v) => TrySetElf(e, "elf.header.os_abi", v),
				"file.elf.header.type" => static (e, v) => TrySetElf(e, "elf.header.type", v),
				"FileElfHeaderType" => static (e, v) => TrySetElf(e, "elf.header.type", v),
				"file.elf.header.version" => static (e, v) => TrySetElf(e, "elf.header.version", v),
				"FileElfHeaderVersion" => static (e, v) => TrySetElf(e, "elf.header.version", v),
				"file.elf.import_hash" => static (e, v) => TrySetElf(e, "elf.import_hash", v),
				"FileElfImportHash" => static (e, v) => TrySetElf(e, "elf.import_hash", v),
				"file.elf.imports_names_entropy" => static (e, v) => TrySetElf(e, "elf.imports_names_entropy", v),
				"FileElfImportsNamesEntropy" => static (e, v) => TrySetElf(e, "elf.imports_names_entropy", v),
				"file.elf.imports_names_var_entropy" => static (e, v) => TrySetElf(e, "elf.imports_names_var_entropy", v),
				"FileElfImportsNamesVarEntropy" => static (e, v) => TrySetElf(e, "elf.imports_names_var_entropy", v),
				"file.elf.telfhash" => static (e, v) => TrySetElf(e, "elf.telfhash", v),
				"FileElfTelfhash" => static (e, v) => TrySetElf(e, "elf.telfhash", v),
				"file.macho.go_import_hash" => static (e, v) => TrySetMacho(e, "macho.go_import_hash", v),
				"FileMachoGoImportHash" => static (e, v) => TrySetMacho(e, "macho.go_import_hash", v),
				"file.macho.go_imports" => static (e, v) => TrySetMacho(e, "macho.go_imports", v),
				"FileMachoGoImports" => static (e, v) => TrySetMacho(e, "macho.go_imports", v),
				"file.macho.go_imports_names_entropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_entropy", v),
				"FileMachoGoImportsNamesEntropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_entropy", v),
				"file.macho.go_imports_names_var_entropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_var_entropy", v),
				"FileMachoGoImportsNamesVarEntropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_var_entropy", v),
				"file.macho.go_stripped" => static (e, v) => TrySetMacho(e, "macho.go_stripped", v),
				"FileMachoGoStripped" => static (e, v) => TrySetMacho(e, "macho.go_stripped", v),
				"file.macho.import_hash" => static (e, v) => TrySetMacho(e, "macho.import_hash", v),
				"FileMachoImportHash" => static (e, v) => TrySetMacho(e, "macho.import_hash", v),
				"file.macho.imports_names_entropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_entropy", v),
				"FileMachoImportsNamesEntropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_entropy", v),
				"file.macho.imports_names_var_entropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_var_entropy", v),
				"FileMachoImportsNamesVarEntropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_var_entropy", v),
				"file.macho.symhash" => static (e, v) => TrySetMacho(e, "macho.symhash", v),
				"FileMachoSymhash" => static (e, v) => TrySetMacho(e, "macho.symhash", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.File ?? new File();
			var assigned = assign(entity, value);
			if (assigned) document.File = entity;
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
				"host.geo.city_name" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"HostGeoCityName" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"host.geo.continent_code" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"HostGeoContinentCode" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"host.geo.continent_name" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"HostGeoContinentName" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"host.geo.country_iso_code" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"HostGeoCountryIsoCode" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"host.geo.country_name" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"HostGeoCountryName" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"host.geo.name" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"HostGeoName" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"host.geo.postal_code" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"HostGeoPostalCode" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"host.geo.region_iso_code" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"HostGeoRegionIsoCode" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"host.geo.region_name" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"HostGeoRegionName" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"host.geo.timezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"HostGeoTimezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"host.os.family" => static (e, v) => TrySetOs(e, "os.family", v),
				"HostOsFamily" => static (e, v) => TrySetOs(e, "os.family", v),
				"host.os.full" => static (e, v) => TrySetOs(e, "os.full", v),
				"HostOsFull" => static (e, v) => TrySetOs(e, "os.full", v),
				"host.os.kernel" => static (e, v) => TrySetOs(e, "os.kernel", v),
				"HostOsKernel" => static (e, v) => TrySetOs(e, "os.kernel", v),
				"host.os.name" => static (e, v) => TrySetOs(e, "os.name", v),
				"HostOsName" => static (e, v) => TrySetOs(e, "os.name", v),
				"host.os.platform" => static (e, v) => TrySetOs(e, "os.platform", v),
				"HostOsPlatform" => static (e, v) => TrySetOs(e, "os.platform", v),
				"host.os.type" => static (e, v) => TrySetOs(e, "os.type", v),
				"HostOsType" => static (e, v) => TrySetOs(e, "os.type", v),
				"host.os.version" => static (e, v) => TrySetOs(e, "os.version", v),
				"HostOsVersion" => static (e, v) => TrySetOs(e, "os.version", v),
				"host.risk.calculated_level" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"HostRiskCalculatedLevel" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"host.risk.calculated_score" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"HostRiskCalculatedScore" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"host.risk.calculated_score_norm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"HostRiskCalculatedScoreNorm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"host.risk.static_level" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"HostRiskStaticLevel" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"host.risk.static_score" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"HostRiskStaticScore" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"host.risk.static_score_norm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
				"HostRiskStaticScoreNorm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
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
				"network.vlan.id" => static (e, v) => TrySetVlan(e, "vlan.id", v),
				"NetworkVlanId" => static (e, v) => TrySetVlan(e, "vlan.id", v),
				"network.vlan.name" => static (e, v) => TrySetVlan(e, "vlan.name", v),
				"NetworkVlanName" => static (e, v) => TrySetVlan(e, "vlan.name", v),
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
				"observer.geo.city_name" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"ObserverGeoCityName" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"observer.geo.continent_code" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"ObserverGeoContinentCode" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"observer.geo.continent_name" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"ObserverGeoContinentName" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"observer.geo.country_iso_code" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"ObserverGeoCountryIsoCode" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"observer.geo.country_name" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"ObserverGeoCountryName" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"observer.geo.name" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"ObserverGeoName" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"observer.geo.postal_code" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"ObserverGeoPostalCode" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"observer.geo.region_iso_code" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"ObserverGeoRegionIsoCode" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"observer.geo.region_name" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"ObserverGeoRegionName" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"observer.geo.timezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"ObserverGeoTimezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"observer.os.family" => static (e, v) => TrySetOs(e, "os.family", v),
				"ObserverOsFamily" => static (e, v) => TrySetOs(e, "os.family", v),
				"observer.os.full" => static (e, v) => TrySetOs(e, "os.full", v),
				"ObserverOsFull" => static (e, v) => TrySetOs(e, "os.full", v),
				"observer.os.kernel" => static (e, v) => TrySetOs(e, "os.kernel", v),
				"ObserverOsKernel" => static (e, v) => TrySetOs(e, "os.kernel", v),
				"observer.os.name" => static (e, v) => TrySetOs(e, "os.name", v),
				"ObserverOsName" => static (e, v) => TrySetOs(e, "os.name", v),
				"observer.os.platform" => static (e, v) => TrySetOs(e, "os.platform", v),
				"ObserverOsPlatform" => static (e, v) => TrySetOs(e, "os.platform", v),
				"observer.os.type" => static (e, v) => TrySetOs(e, "os.type", v),
				"ObserverOsType" => static (e, v) => TrySetOs(e, "os.type", v),
				"observer.os.version" => static (e, v) => TrySetOs(e, "os.version", v),
				"ObserverOsVersion" => static (e, v) => TrySetOs(e, "os.version", v),
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
				"process.vpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"ProcessVpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"process.working_directory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"ProcessWorkingDirectory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"process.group.domain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"ProcessGroupDomain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"process.group.id" => static (e, v) => TrySetGroup(e, "group.id", v),
				"ProcessGroupId" => static (e, v) => TrySetGroup(e, "group.id", v),
				"process.group.name" => static (e, v) => TrySetGroup(e, "group.name", v),
				"ProcessGroupName" => static (e, v) => TrySetGroup(e, "group.name", v),
				"process.hash.md5" => static (e, v) => TrySetHash(e, "hash.md5", v),
				"ProcessHashMd5" => static (e, v) => TrySetHash(e, "hash.md5", v),
				"process.hash.sha1" => static (e, v) => TrySetHash(e, "hash.sha1", v),
				"ProcessHashSha1" => static (e, v) => TrySetHash(e, "hash.sha1", v),
				"process.hash.sha256" => static (e, v) => TrySetHash(e, "hash.sha256", v),
				"ProcessHashSha256" => static (e, v) => TrySetHash(e, "hash.sha256", v),
				"process.hash.sha384" => static (e, v) => TrySetHash(e, "hash.sha384", v),
				"ProcessHashSha384" => static (e, v) => TrySetHash(e, "hash.sha384", v),
				"process.hash.sha512" => static (e, v) => TrySetHash(e, "hash.sha512", v),
				"ProcessHashSha512" => static (e, v) => TrySetHash(e, "hash.sha512", v),
				"process.hash.ssdeep" => static (e, v) => TrySetHash(e, "hash.ssdeep", v),
				"ProcessHashSsdeep" => static (e, v) => TrySetHash(e, "hash.ssdeep", v),
				"process.hash.tlsh" => static (e, v) => TrySetHash(e, "hash.tlsh", v),
				"ProcessHashTlsh" => static (e, v) => TrySetHash(e, "hash.tlsh", v),
				"process.pe.architecture" => static (e, v) => TrySetPe(e, "pe.architecture", v),
				"ProcessPeArchitecture" => static (e, v) => TrySetPe(e, "pe.architecture", v),
				"process.pe.company" => static (e, v) => TrySetPe(e, "pe.company", v),
				"ProcessPeCompany" => static (e, v) => TrySetPe(e, "pe.company", v),
				"process.pe.description" => static (e, v) => TrySetPe(e, "pe.description", v),
				"ProcessPeDescription" => static (e, v) => TrySetPe(e, "pe.description", v),
				"process.pe.file_version" => static (e, v) => TrySetPe(e, "pe.file_version", v),
				"ProcessPeFileVersion" => static (e, v) => TrySetPe(e, "pe.file_version", v),
				"process.pe.go_import_hash" => static (e, v) => TrySetPe(e, "pe.go_import_hash", v),
				"ProcessPeGoImportHash" => static (e, v) => TrySetPe(e, "pe.go_import_hash", v),
				"process.pe.go_imports" => static (e, v) => TrySetPe(e, "pe.go_imports", v),
				"ProcessPeGoImports" => static (e, v) => TrySetPe(e, "pe.go_imports", v),
				"process.pe.go_imports_names_entropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_entropy", v),
				"ProcessPeGoImportsNamesEntropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_entropy", v),
				"process.pe.go_imports_names_var_entropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_var_entropy", v),
				"ProcessPeGoImportsNamesVarEntropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_var_entropy", v),
				"process.pe.go_stripped" => static (e, v) => TrySetPe(e, "pe.go_stripped", v),
				"ProcessPeGoStripped" => static (e, v) => TrySetPe(e, "pe.go_stripped", v),
				"process.pe.imphash" => static (e, v) => TrySetPe(e, "pe.imphash", v),
				"ProcessPeImphash" => static (e, v) => TrySetPe(e, "pe.imphash", v),
				"process.pe.import_hash" => static (e, v) => TrySetPe(e, "pe.import_hash", v),
				"ProcessPeImportHash" => static (e, v) => TrySetPe(e, "pe.import_hash", v),
				"process.pe.imports_names_entropy" => static (e, v) => TrySetPe(e, "pe.imports_names_entropy", v),
				"ProcessPeImportsNamesEntropy" => static (e, v) => TrySetPe(e, "pe.imports_names_entropy", v),
				"process.pe.imports_names_var_entropy" => static (e, v) => TrySetPe(e, "pe.imports_names_var_entropy", v),
				"ProcessPeImportsNamesVarEntropy" => static (e, v) => TrySetPe(e, "pe.imports_names_var_entropy", v),
				"process.pe.original_file_name" => static (e, v) => TrySetPe(e, "pe.original_file_name", v),
				"ProcessPeOriginalFileName" => static (e, v) => TrySetPe(e, "pe.original_file_name", v),
				"process.pe.pehash" => static (e, v) => TrySetPe(e, "pe.pehash", v),
				"ProcessPePehash" => static (e, v) => TrySetPe(e, "pe.pehash", v),
				"process.pe.product" => static (e, v) => TrySetPe(e, "pe.product", v),
				"ProcessPeProduct" => static (e, v) => TrySetPe(e, "pe.product", v),
				"process.code_signature.digest_algorithm" => static (e, v) => TrySetCodeSignature(e, "code_signature.digest_algorithm", v),
				"ProcessCodeSignatureDigestAlgorithm" => static (e, v) => TrySetCodeSignature(e, "code_signature.digest_algorithm", v),
				"process.code_signature.exists" => static (e, v) => TrySetCodeSignature(e, "code_signature.exists", v),
				"ProcessCodeSignatureExists" => static (e, v) => TrySetCodeSignature(e, "code_signature.exists", v),
				"process.code_signature.signing_id" => static (e, v) => TrySetCodeSignature(e, "code_signature.signing_id", v),
				"ProcessCodeSignatureSigningId" => static (e, v) => TrySetCodeSignature(e, "code_signature.signing_id", v),
				"process.code_signature.status" => static (e, v) => TrySetCodeSignature(e, "code_signature.status", v),
				"ProcessCodeSignatureStatus" => static (e, v) => TrySetCodeSignature(e, "code_signature.status", v),
				"process.code_signature.subject_name" => static (e, v) => TrySetCodeSignature(e, "code_signature.subject_name", v),
				"ProcessCodeSignatureSubjectName" => static (e, v) => TrySetCodeSignature(e, "code_signature.subject_name", v),
				"process.code_signature.team_id" => static (e, v) => TrySetCodeSignature(e, "code_signature.team_id", v),
				"ProcessCodeSignatureTeamId" => static (e, v) => TrySetCodeSignature(e, "code_signature.team_id", v),
				"process.code_signature.timestamp" => static (e, v) => TrySetCodeSignature(e, "code_signature.timestamp", v),
				"ProcessCodeSignatureTimestamp" => static (e, v) => TrySetCodeSignature(e, "code_signature.timestamp", v),
				"process.code_signature.trusted" => static (e, v) => TrySetCodeSignature(e, "code_signature.trusted", v),
				"ProcessCodeSignatureTrusted" => static (e, v) => TrySetCodeSignature(e, "code_signature.trusted", v),
				"process.code_signature.valid" => static (e, v) => TrySetCodeSignature(e, "code_signature.valid", v),
				"ProcessCodeSignatureValid" => static (e, v) => TrySetCodeSignature(e, "code_signature.valid", v),
				"process.elf.architecture" => static (e, v) => TrySetElf(e, "elf.architecture", v),
				"ProcessElfArchitecture" => static (e, v) => TrySetElf(e, "elf.architecture", v),
				"process.elf.byte_order" => static (e, v) => TrySetElf(e, "elf.byte_order", v),
				"ProcessElfByteOrder" => static (e, v) => TrySetElf(e, "elf.byte_order", v),
				"process.elf.cpu_type" => static (e, v) => TrySetElf(e, "elf.cpu_type", v),
				"ProcessElfCpuType" => static (e, v) => TrySetElf(e, "elf.cpu_type", v),
				"process.elf.creation_date" => static (e, v) => TrySetElf(e, "elf.creation_date", v),
				"ProcessElfCreationDate" => static (e, v) => TrySetElf(e, "elf.creation_date", v),
				"process.elf.go_import_hash" => static (e, v) => TrySetElf(e, "elf.go_import_hash", v),
				"ProcessElfGoImportHash" => static (e, v) => TrySetElf(e, "elf.go_import_hash", v),
				"process.elf.go_imports" => static (e, v) => TrySetElf(e, "elf.go_imports", v),
				"ProcessElfGoImports" => static (e, v) => TrySetElf(e, "elf.go_imports", v),
				"process.elf.go_imports_names_entropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_entropy", v),
				"ProcessElfGoImportsNamesEntropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_entropy", v),
				"process.elf.go_imports_names_var_entropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_var_entropy", v),
				"ProcessElfGoImportsNamesVarEntropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_var_entropy", v),
				"process.elf.go_stripped" => static (e, v) => TrySetElf(e, "elf.go_stripped", v),
				"ProcessElfGoStripped" => static (e, v) => TrySetElf(e, "elf.go_stripped", v),
				"process.elf.header.abi_version" => static (e, v) => TrySetElf(e, "elf.header.abi_version", v),
				"ProcessElfHeaderAbiVersion" => static (e, v) => TrySetElf(e, "elf.header.abi_version", v),
				"process.elf.header.class" => static (e, v) => TrySetElf(e, "elf.header.class", v),
				"ProcessElfHeaderClass" => static (e, v) => TrySetElf(e, "elf.header.class", v),
				"process.elf.header.data" => static (e, v) => TrySetElf(e, "elf.header.data", v),
				"ProcessElfHeaderData" => static (e, v) => TrySetElf(e, "elf.header.data", v),
				"process.elf.header.entrypoint" => static (e, v) => TrySetElf(e, "elf.header.entrypoint", v),
				"ProcessElfHeaderEntrypoint" => static (e, v) => TrySetElf(e, "elf.header.entrypoint", v),
				"process.elf.header.object_version" => static (e, v) => TrySetElf(e, "elf.header.object_version", v),
				"ProcessElfHeaderObjectVersion" => static (e, v) => TrySetElf(e, "elf.header.object_version", v),
				"process.elf.header.os_abi" => static (e, v) => TrySetElf(e, "elf.header.os_abi", v),
				"ProcessElfHeaderOsAbi" => static (e, v) => TrySetElf(e, "elf.header.os_abi", v),
				"process.elf.header.type" => static (e, v) => TrySetElf(e, "elf.header.type", v),
				"ProcessElfHeaderType" => static (e, v) => TrySetElf(e, "elf.header.type", v),
				"process.elf.header.version" => static (e, v) => TrySetElf(e, "elf.header.version", v),
				"ProcessElfHeaderVersion" => static (e, v) => TrySetElf(e, "elf.header.version", v),
				"process.elf.import_hash" => static (e, v) => TrySetElf(e, "elf.import_hash", v),
				"ProcessElfImportHash" => static (e, v) => TrySetElf(e, "elf.import_hash", v),
				"process.elf.imports_names_entropy" => static (e, v) => TrySetElf(e, "elf.imports_names_entropy", v),
				"ProcessElfImportsNamesEntropy" => static (e, v) => TrySetElf(e, "elf.imports_names_entropy", v),
				"process.elf.imports_names_var_entropy" => static (e, v) => TrySetElf(e, "elf.imports_names_var_entropy", v),
				"ProcessElfImportsNamesVarEntropy" => static (e, v) => TrySetElf(e, "elf.imports_names_var_entropy", v),
				"process.elf.telfhash" => static (e, v) => TrySetElf(e, "elf.telfhash", v),
				"ProcessElfTelfhash" => static (e, v) => TrySetElf(e, "elf.telfhash", v),
				"process.macho.go_import_hash" => static (e, v) => TrySetMacho(e, "macho.go_import_hash", v),
				"ProcessMachoGoImportHash" => static (e, v) => TrySetMacho(e, "macho.go_import_hash", v),
				"process.macho.go_imports" => static (e, v) => TrySetMacho(e, "macho.go_imports", v),
				"ProcessMachoGoImports" => static (e, v) => TrySetMacho(e, "macho.go_imports", v),
				"process.macho.go_imports_names_entropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_entropy", v),
				"ProcessMachoGoImportsNamesEntropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_entropy", v),
				"process.macho.go_imports_names_var_entropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_var_entropy", v),
				"ProcessMachoGoImportsNamesVarEntropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_var_entropy", v),
				"process.macho.go_stripped" => static (e, v) => TrySetMacho(e, "macho.go_stripped", v),
				"ProcessMachoGoStripped" => static (e, v) => TrySetMacho(e, "macho.go_stripped", v),
				"process.macho.import_hash" => static (e, v) => TrySetMacho(e, "macho.import_hash", v),
				"ProcessMachoImportHash" => static (e, v) => TrySetMacho(e, "macho.import_hash", v),
				"process.macho.imports_names_entropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_entropy", v),
				"ProcessMachoImportsNamesEntropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_entropy", v),
				"process.macho.imports_names_var_entropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_var_entropy", v),
				"ProcessMachoImportsNamesVarEntropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_var_entropy", v),
				"process.macho.symhash" => static (e, v) => TrySetMacho(e, "macho.symhash", v),
				"ProcessMachoSymhash" => static (e, v) => TrySetMacho(e, "macho.symhash", v),
				"process.source.address" => static (e, v) => TrySetSource(e, "source.address", v),
				"ProcessSourceAddress" => static (e, v) => TrySetSource(e, "source.address", v),
				"process.source.bytes" => static (e, v) => TrySetSource(e, "source.bytes", v),
				"ProcessSourceBytes" => static (e, v) => TrySetSource(e, "source.bytes", v),
				"process.source.domain" => static (e, v) => TrySetSource(e, "source.domain", v),
				"ProcessSourceDomain" => static (e, v) => TrySetSource(e, "source.domain", v),
				"process.source.ip" => static (e, v) => TrySetSource(e, "source.ip", v),
				"ProcessSourceIp" => static (e, v) => TrySetSource(e, "source.ip", v),
				"process.source.mac" => static (e, v) => TrySetSource(e, "source.mac", v),
				"ProcessSourceMac" => static (e, v) => TrySetSource(e, "source.mac", v),
				"process.source.nat.ip" => static (e, v) => TrySetSource(e, "source.nat.ip", v),
				"ProcessSourceNatIp" => static (e, v) => TrySetSource(e, "source.nat.ip", v),
				"process.source.nat.port" => static (e, v) => TrySetSource(e, "source.nat.port", v),
				"ProcessSourceNatPort" => static (e, v) => TrySetSource(e, "source.nat.port", v),
				"process.source.packets" => static (e, v) => TrySetSource(e, "source.packets", v),
				"ProcessSourcePackets" => static (e, v) => TrySetSource(e, "source.packets", v),
				"process.source.port" => static (e, v) => TrySetSource(e, "source.port", v),
				"ProcessSourcePort" => static (e, v) => TrySetSource(e, "source.port", v),
				"process.source.registered_domain" => static (e, v) => TrySetSource(e, "source.registered_domain", v),
				"ProcessSourceRegisteredDomain" => static (e, v) => TrySetSource(e, "source.registered_domain", v),
				"process.source.subdomain" => static (e, v) => TrySetSource(e, "source.subdomain", v),
				"ProcessSourceSubdomain" => static (e, v) => TrySetSource(e, "source.subdomain", v),
				"process.source.top_level_domain" => static (e, v) => TrySetSource(e, "source.top_level_domain", v),
				"ProcessSourceTopLevelDomain" => static (e, v) => TrySetSource(e, "source.top_level_domain", v),
				"process.source.as.number" => static (e, v) => TrySetSource(e, "source.as.number", v),
				"ProcessSourceAsNumber" => static (e, v) => TrySetSource(e, "source.as.number", v),
				"process.source.as.organization.name" => static (e, v) => TrySetSource(e, "source.as.organization.name", v),
				"ProcessSourceAsOrganizationName" => static (e, v) => TrySetSource(e, "source.as.organization.name", v),
				"process.source.geo.city_name" => static (e, v) => TrySetSource(e, "source.geo.city_name", v),
				"ProcessSourceGeoCityName" => static (e, v) => TrySetSource(e, "source.geo.city_name", v),
				"process.source.geo.continent_code" => static (e, v) => TrySetSource(e, "source.geo.continent_code", v),
				"ProcessSourceGeoContinentCode" => static (e, v) => TrySetSource(e, "source.geo.continent_code", v),
				"process.source.geo.continent_name" => static (e, v) => TrySetSource(e, "source.geo.continent_name", v),
				"ProcessSourceGeoContinentName" => static (e, v) => TrySetSource(e, "source.geo.continent_name", v),
				"process.source.geo.country_iso_code" => static (e, v) => TrySetSource(e, "source.geo.country_iso_code", v),
				"ProcessSourceGeoCountryIsoCode" => static (e, v) => TrySetSource(e, "source.geo.country_iso_code", v),
				"process.source.geo.country_name" => static (e, v) => TrySetSource(e, "source.geo.country_name", v),
				"ProcessSourceGeoCountryName" => static (e, v) => TrySetSource(e, "source.geo.country_name", v),
				"process.source.geo.name" => static (e, v) => TrySetSource(e, "source.geo.name", v),
				"ProcessSourceGeoName" => static (e, v) => TrySetSource(e, "source.geo.name", v),
				"process.source.geo.postal_code" => static (e, v) => TrySetSource(e, "source.geo.postal_code", v),
				"ProcessSourceGeoPostalCode" => static (e, v) => TrySetSource(e, "source.geo.postal_code", v),
				"process.source.geo.region_iso_code" => static (e, v) => TrySetSource(e, "source.geo.region_iso_code", v),
				"ProcessSourceGeoRegionIsoCode" => static (e, v) => TrySetSource(e, "source.geo.region_iso_code", v),
				"process.source.geo.region_name" => static (e, v) => TrySetSource(e, "source.geo.region_name", v),
				"ProcessSourceGeoRegionName" => static (e, v) => TrySetSource(e, "source.geo.region_name", v),
				"process.source.geo.timezone" => static (e, v) => TrySetSource(e, "source.geo.timezone", v),
				"ProcessSourceGeoTimezone" => static (e, v) => TrySetSource(e, "source.geo.timezone", v),
				"process.source.user.domain" => static (e, v) => TrySetSource(e, "source.user.domain", v),
				"ProcessSourceUserDomain" => static (e, v) => TrySetSource(e, "source.user.domain", v),
				"process.source.user.email" => static (e, v) => TrySetSource(e, "source.user.email", v),
				"ProcessSourceUserEmail" => static (e, v) => TrySetSource(e, "source.user.email", v),
				"process.source.user.full_name" => static (e, v) => TrySetSource(e, "source.user.full_name", v),
				"ProcessSourceUserFullName" => static (e, v) => TrySetSource(e, "source.user.full_name", v),
				"process.source.user.hash" => static (e, v) => TrySetSource(e, "source.user.hash", v),
				"ProcessSourceUserHash" => static (e, v) => TrySetSource(e, "source.user.hash", v),
				"process.source.user.id" => static (e, v) => TrySetSource(e, "source.user.id", v),
				"ProcessSourceUserId" => static (e, v) => TrySetSource(e, "source.user.id", v),
				"process.source.user.name" => static (e, v) => TrySetSource(e, "source.user.name", v),
				"ProcessSourceUserName" => static (e, v) => TrySetSource(e, "source.user.name", v),
				"process.source.user.group.domain" => static (e, v) => TrySetSource(e, "source.user.group.domain", v),
				"ProcessSourceUserGroupDomain" => static (e, v) => TrySetSource(e, "source.user.group.domain", v),
				"process.source.user.group.id" => static (e, v) => TrySetSource(e, "source.user.group.id", v),
				"ProcessSourceUserGroupId" => static (e, v) => TrySetSource(e, "source.user.group.id", v),
				"process.source.user.group.name" => static (e, v) => TrySetSource(e, "source.user.group.name", v),
				"ProcessSourceUserGroupName" => static (e, v) => TrySetSource(e, "source.user.group.name", v),
				"process.source.user.risk.calculated_level" => static (e, v) => TrySetSource(e, "source.user.risk.calculated_level", v),
				"ProcessSourceUserRiskCalculatedLevel" => static (e, v) => TrySetSource(e, "source.user.risk.calculated_level", v),
				"process.source.user.risk.calculated_score" => static (e, v) => TrySetSource(e, "source.user.risk.calculated_score", v),
				"ProcessSourceUserRiskCalculatedScore" => static (e, v) => TrySetSource(e, "source.user.risk.calculated_score", v),
				"process.source.user.risk.calculated_score_norm" => static (e, v) => TrySetSource(e, "source.user.risk.calculated_score_norm", v),
				"ProcessSourceUserRiskCalculatedScoreNorm" => static (e, v) => TrySetSource(e, "source.user.risk.calculated_score_norm", v),
				"process.source.user.risk.static_level" => static (e, v) => TrySetSource(e, "source.user.risk.static_level", v),
				"ProcessSourceUserRiskStaticLevel" => static (e, v) => TrySetSource(e, "source.user.risk.static_level", v),
				"process.source.user.risk.static_score" => static (e, v) => TrySetSource(e, "source.user.risk.static_score", v),
				"ProcessSourceUserRiskStaticScore" => static (e, v) => TrySetSource(e, "source.user.risk.static_score", v),
				"process.source.user.risk.static_score_norm" => static (e, v) => TrySetSource(e, "source.user.risk.static_score_norm", v),
				"ProcessSourceUserRiskStaticScoreNorm" => static (e, v) => TrySetSource(e, "source.user.risk.static_score_norm", v),
				"process.source.user.user.domain" => static (e, v) => TrySetSource(e, "source.user.user.domain", v),
				"ProcessSourceUserUserDomain" => static (e, v) => TrySetSource(e, "source.user.user.domain", v),
				"process.source.user.user.email" => static (e, v) => TrySetSource(e, "source.user.user.email", v),
				"ProcessSourceUserUserEmail" => static (e, v) => TrySetSource(e, "source.user.user.email", v),
				"process.source.user.user.full_name" => static (e, v) => TrySetSource(e, "source.user.user.full_name", v),
				"ProcessSourceUserUserFullName" => static (e, v) => TrySetSource(e, "source.user.user.full_name", v),
				"process.source.user.user.hash" => static (e, v) => TrySetSource(e, "source.user.user.hash", v),
				"ProcessSourceUserUserHash" => static (e, v) => TrySetSource(e, "source.user.user.hash", v),
				"process.source.user.user.id" => static (e, v) => TrySetSource(e, "source.user.user.id", v),
				"ProcessSourceUserUserId" => static (e, v) => TrySetSource(e, "source.user.user.id", v),
				"process.source.user.user.name" => static (e, v) => TrySetSource(e, "source.user.user.name", v),
				"ProcessSourceUserUserName" => static (e, v) => TrySetSource(e, "source.user.user.name", v),
				"process.user.domain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"ProcessUserDomain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"process.user.email" => static (e, v) => TrySetUser(e, "user.email", v),
				"ProcessUserEmail" => static (e, v) => TrySetUser(e, "user.email", v),
				"process.user.full_name" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"ProcessUserFullName" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"process.user.hash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"ProcessUserHash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"process.user.id" => static (e, v) => TrySetUser(e, "user.id", v),
				"ProcessUserId" => static (e, v) => TrySetUser(e, "user.id", v),
				"process.user.name" => static (e, v) => TrySetUser(e, "user.name", v),
				"ProcessUserName" => static (e, v) => TrySetUser(e, "user.name", v),
				"process.user.group.domain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"ProcessUserGroupDomain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"process.user.group.id" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"ProcessUserGroupId" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"process.user.group.name" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"ProcessUserGroupName" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"process.user.risk.calculated_level" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"ProcessUserRiskCalculatedLevel" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"process.user.risk.calculated_score" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"ProcessUserRiskCalculatedScore" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"process.user.risk.calculated_score_norm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"ProcessUserRiskCalculatedScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"process.user.risk.static_level" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"ProcessUserRiskStaticLevel" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"process.user.risk.static_score" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"ProcessUserRiskStaticScore" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"process.user.risk.static_score_norm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"ProcessUserRiskStaticScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"process.user.user.domain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"ProcessUserUserDomain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"process.user.user.email" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"ProcessUserUserEmail" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"process.user.user.full_name" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"ProcessUserUserFullName" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"process.user.user.hash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"ProcessUserUserHash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"process.user.user.id" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"ProcessUserUserId" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"process.user.user.name" => static (e, v) => TrySetUser(e, "user.user.name", v),
				"ProcessUserUserName" => static (e, v) => TrySetUser(e, "user.user.name", v),
				"process.process.args_count" => static (e, v) => TrySetProcessParent(e, "process.args_count", v),
				"ProcessProcessArgsCount" => static (e, v) => TrySetProcessParent(e, "process.args_count", v),
				"process.process.command_line" => static (e, v) => TrySetProcessParent(e, "process.command_line", v),
				"ProcessProcessCommandLine" => static (e, v) => TrySetProcessParent(e, "process.command_line", v),
				"process.process.end" => static (e, v) => TrySetProcessParent(e, "process.end", v),
				"ProcessProcessEnd" => static (e, v) => TrySetProcessParent(e, "process.end", v),
				"process.process.entity_id" => static (e, v) => TrySetProcessParent(e, "process.entity_id", v),
				"ProcessProcessEntityId" => static (e, v) => TrySetProcessParent(e, "process.entity_id", v),
				"process.process.executable" => static (e, v) => TrySetProcessParent(e, "process.executable", v),
				"ProcessProcessExecutable" => static (e, v) => TrySetProcessParent(e, "process.executable", v),
				"process.process.exit_code" => static (e, v) => TrySetProcessParent(e, "process.exit_code", v),
				"ProcessProcessExitCode" => static (e, v) => TrySetProcessParent(e, "process.exit_code", v),
				"process.process.interactive" => static (e, v) => TrySetProcessParent(e, "process.interactive", v),
				"ProcessProcessInteractive" => static (e, v) => TrySetProcessParent(e, "process.interactive", v),
				"process.process.name" => static (e, v) => TrySetProcessParent(e, "process.name", v),
				"ProcessProcessName" => static (e, v) => TrySetProcessParent(e, "process.name", v),
				"process.process.pgid" => static (e, v) => TrySetProcessParent(e, "process.pgid", v),
				"ProcessProcessPgid" => static (e, v) => TrySetProcessParent(e, "process.pgid", v),
				"process.process.pid" => static (e, v) => TrySetProcessParent(e, "process.pid", v),
				"ProcessProcessPid" => static (e, v) => TrySetProcessParent(e, "process.pid", v),
				"process.process.start" => static (e, v) => TrySetProcessParent(e, "process.start", v),
				"ProcessProcessStart" => static (e, v) => TrySetProcessParent(e, "process.start", v),
				"process.process.thread.id" => static (e, v) => TrySetProcessParent(e, "process.thread.id", v),
				"ProcessProcessThreadId" => static (e, v) => TrySetProcessParent(e, "process.thread.id", v),
				"process.process.thread.name" => static (e, v) => TrySetProcessParent(e, "process.thread.name", v),
				"ProcessProcessThreadName" => static (e, v) => TrySetProcessParent(e, "process.thread.name", v),
				"process.process.title" => static (e, v) => TrySetProcessParent(e, "process.title", v),
				"ProcessProcessTitle" => static (e, v) => TrySetProcessParent(e, "process.title", v),
				"process.process.uptime" => static (e, v) => TrySetProcessParent(e, "process.uptime", v),
				"ProcessProcessUptime" => static (e, v) => TrySetProcessParent(e, "process.uptime", v),
				"process.process.vpid" => static (e, v) => TrySetProcessParent(e, "process.vpid", v),
				"ProcessProcessVpid" => static (e, v) => TrySetProcessParent(e, "process.vpid", v),
				"process.process.working_directory" => static (e, v) => TrySetProcessParent(e, "process.working_directory", v),
				"ProcessProcessWorkingDirectory" => static (e, v) => TrySetProcessParent(e, "process.working_directory", v),
				"process.process.parent.process.args_count" => static (e, v) => TrySetProcessParent(e, "process.parent.process.args_count", v),
				"ProcessProcessParentProcessArgsCount" => static (e, v) => TrySetProcessParent(e, "process.parent.process.args_count", v),
				"process.process.parent.process.command_line" => static (e, v) => TrySetProcessParent(e, "process.parent.process.command_line", v),
				"ProcessProcessParentProcessCommandLine" => static (e, v) => TrySetProcessParent(e, "process.parent.process.command_line", v),
				"process.process.parent.process.end" => static (e, v) => TrySetProcessParent(e, "process.parent.process.end", v),
				"ProcessProcessParentProcessEnd" => static (e, v) => TrySetProcessParent(e, "process.parent.process.end", v),
				"process.process.parent.process.entity_id" => static (e, v) => TrySetProcessParent(e, "process.parent.process.entity_id", v),
				"ProcessProcessParentProcessEntityId" => static (e, v) => TrySetProcessParent(e, "process.parent.process.entity_id", v),
				"process.process.parent.process.executable" => static (e, v) => TrySetProcessParent(e, "process.parent.process.executable", v),
				"ProcessProcessParentProcessExecutable" => static (e, v) => TrySetProcessParent(e, "process.parent.process.executable", v),
				"process.process.parent.process.exit_code" => static (e, v) => TrySetProcessParent(e, "process.parent.process.exit_code", v),
				"ProcessProcessParentProcessExitCode" => static (e, v) => TrySetProcessParent(e, "process.parent.process.exit_code", v),
				"process.process.parent.process.interactive" => static (e, v) => TrySetProcessParent(e, "process.parent.process.interactive", v),
				"ProcessProcessParentProcessInteractive" => static (e, v) => TrySetProcessParent(e, "process.parent.process.interactive", v),
				"process.process.parent.process.name" => static (e, v) => TrySetProcessParent(e, "process.parent.process.name", v),
				"ProcessProcessParentProcessName" => static (e, v) => TrySetProcessParent(e, "process.parent.process.name", v),
				"process.process.parent.process.pgid" => static (e, v) => TrySetProcessParent(e, "process.parent.process.pgid", v),
				"ProcessProcessParentProcessPgid" => static (e, v) => TrySetProcessParent(e, "process.parent.process.pgid", v),
				"process.process.parent.process.pid" => static (e, v) => TrySetProcessParent(e, "process.parent.process.pid", v),
				"ProcessProcessParentProcessPid" => static (e, v) => TrySetProcessParent(e, "process.parent.process.pid", v),
				"process.process.parent.process.start" => static (e, v) => TrySetProcessParent(e, "process.parent.process.start", v),
				"ProcessProcessParentProcessStart" => static (e, v) => TrySetProcessParent(e, "process.parent.process.start", v),
				"process.process.parent.process.thread.id" => static (e, v) => TrySetProcessParent(e, "process.parent.process.thread.id", v),
				"ProcessProcessParentProcessThreadId" => static (e, v) => TrySetProcessParent(e, "process.parent.process.thread.id", v),
				"process.process.parent.process.thread.name" => static (e, v) => TrySetProcessParent(e, "process.parent.process.thread.name", v),
				"ProcessProcessParentProcessThreadName" => static (e, v) => TrySetProcessParent(e, "process.parent.process.thread.name", v),
				"process.process.parent.process.title" => static (e, v) => TrySetProcessParent(e, "process.parent.process.title", v),
				"ProcessProcessParentProcessTitle" => static (e, v) => TrySetProcessParent(e, "process.parent.process.title", v),
				"process.process.parent.process.uptime" => static (e, v) => TrySetProcessParent(e, "process.parent.process.uptime", v),
				"ProcessProcessParentProcessUptime" => static (e, v) => TrySetProcessParent(e, "process.parent.process.uptime", v),
				"process.process.parent.process.vpid" => static (e, v) => TrySetProcessParent(e, "process.parent.process.vpid", v),
				"ProcessProcessParentProcessVpid" => static (e, v) => TrySetProcessParent(e, "process.parent.process.vpid", v),
				"process.process.parent.process.working_directory" => static (e, v) => TrySetProcessParent(e, "process.parent.process.working_directory", v),
				"ProcessProcessParentProcessWorkingDirectory" => static (e, v) => TrySetProcessParent(e, "process.parent.process.working_directory", v),
				"process.process.entry_leader.process.args_count" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.args_count", v),
				"ProcessProcessEntryLeaderProcessArgsCount" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.args_count", v),
				"process.process.entry_leader.process.command_line" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.command_line", v),
				"ProcessProcessEntryLeaderProcessCommandLine" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.command_line", v),
				"process.process.entry_leader.process.end" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.end", v),
				"ProcessProcessEntryLeaderProcessEnd" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.end", v),
				"process.process.entry_leader.process.entity_id" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entity_id", v),
				"ProcessProcessEntryLeaderProcessEntityId" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entity_id", v),
				"process.process.entry_leader.process.executable" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.executable", v),
				"ProcessProcessEntryLeaderProcessExecutable" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.executable", v),
				"process.process.entry_leader.process.exit_code" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.exit_code", v),
				"ProcessProcessEntryLeaderProcessExitCode" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.exit_code", v),
				"process.process.entry_leader.process.interactive" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.interactive", v),
				"ProcessProcessEntryLeaderProcessInteractive" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.interactive", v),
				"process.process.entry_leader.process.name" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.name", v),
				"ProcessProcessEntryLeaderProcessName" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.name", v),
				"process.process.entry_leader.process.pgid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.pgid", v),
				"ProcessProcessEntryLeaderProcessPgid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.pgid", v),
				"process.process.entry_leader.process.pid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.pid", v),
				"ProcessProcessEntryLeaderProcessPid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.pid", v),
				"process.process.entry_leader.process.start" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.start", v),
				"ProcessProcessEntryLeaderProcessStart" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.start", v),
				"process.process.entry_leader.process.thread.id" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.thread.id", v),
				"ProcessProcessEntryLeaderProcessThreadId" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.thread.id", v),
				"process.process.entry_leader.process.thread.name" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.thread.name", v),
				"ProcessProcessEntryLeaderProcessThreadName" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.thread.name", v),
				"process.process.entry_leader.process.title" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.title", v),
				"ProcessProcessEntryLeaderProcessTitle" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.title", v),
				"process.process.entry_leader.process.uptime" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.uptime", v),
				"ProcessProcessEntryLeaderProcessUptime" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.uptime", v),
				"process.process.entry_leader.process.vpid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.vpid", v),
				"ProcessProcessEntryLeaderProcessVpid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.vpid", v),
				"process.process.entry_leader.process.working_directory" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.working_directory", v),
				"ProcessProcessEntryLeaderProcessWorkingDirectory" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.working_directory", v),
				"process.process.entry_leader.process.entry_leader.parent.process.args_count" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.args_count", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessArgsCount" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.args_count", v),
				"process.process.entry_leader.process.entry_leader.parent.process.command_line" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.command_line", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessCommandLine" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.command_line", v),
				"process.process.entry_leader.process.entry_leader.parent.process.end" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.end", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessEnd" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.end", v),
				"process.process.entry_leader.process.entry_leader.parent.process.entity_id" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.entity_id", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessEntityId" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.entity_id", v),
				"process.process.entry_leader.process.entry_leader.parent.process.executable" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.executable", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessExecutable" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.executable", v),
				"process.process.entry_leader.process.entry_leader.parent.process.exit_code" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.exit_code", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessExitCode" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.exit_code", v),
				"process.process.entry_leader.process.entry_leader.parent.process.interactive" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.interactive", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessInteractive" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.interactive", v),
				"process.process.entry_leader.process.entry_leader.parent.process.name" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.name", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessName" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.name", v),
				"process.process.entry_leader.process.entry_leader.parent.process.pgid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.pgid", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessPgid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.pgid", v),
				"process.process.entry_leader.process.entry_leader.parent.process.pid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.pid", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessPid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.pid", v),
				"process.process.entry_leader.process.entry_leader.parent.process.start" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.start", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessStart" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.start", v),
				"process.process.entry_leader.process.entry_leader.parent.process.thread.id" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.thread.id", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessThreadId" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.thread.id", v),
				"process.process.entry_leader.process.entry_leader.parent.process.thread.name" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.thread.name", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessThreadName" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.thread.name", v),
				"process.process.entry_leader.process.entry_leader.parent.process.title" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.title", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessTitle" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.title", v),
				"process.process.entry_leader.process.entry_leader.parent.process.uptime" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.uptime", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessUptime" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.uptime", v),
				"process.process.entry_leader.process.entry_leader.parent.process.vpid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.vpid", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessVpid" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.vpid", v),
				"process.process.entry_leader.process.entry_leader.parent.process.working_directory" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.working_directory", v),
				"ProcessProcessEntryLeaderProcessEntryLeaderParentProcessWorkingDirectory" => static (e, v) => TrySetProcessEntryLeader(e, "process.entry_leader.process.entry_leader.parent.process.working_directory", v),
				"process.process.session_leader.process.args_count" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.args_count", v),
				"ProcessProcessSessionLeaderProcessArgsCount" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.args_count", v),
				"process.process.session_leader.process.command_line" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.command_line", v),
				"ProcessProcessSessionLeaderProcessCommandLine" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.command_line", v),
				"process.process.session_leader.process.end" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.end", v),
				"ProcessProcessSessionLeaderProcessEnd" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.end", v),
				"process.process.session_leader.process.entity_id" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.entity_id", v),
				"ProcessProcessSessionLeaderProcessEntityId" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.entity_id", v),
				"process.process.session_leader.process.executable" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.executable", v),
				"ProcessProcessSessionLeaderProcessExecutable" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.executable", v),
				"process.process.session_leader.process.exit_code" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.exit_code", v),
				"ProcessProcessSessionLeaderProcessExitCode" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.exit_code", v),
				"process.process.session_leader.process.interactive" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.interactive", v),
				"ProcessProcessSessionLeaderProcessInteractive" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.interactive", v),
				"process.process.session_leader.process.name" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.name", v),
				"ProcessProcessSessionLeaderProcessName" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.name", v),
				"process.process.session_leader.process.pgid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.pgid", v),
				"ProcessProcessSessionLeaderProcessPgid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.pgid", v),
				"process.process.session_leader.process.pid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.pid", v),
				"ProcessProcessSessionLeaderProcessPid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.pid", v),
				"process.process.session_leader.process.start" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.start", v),
				"ProcessProcessSessionLeaderProcessStart" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.start", v),
				"process.process.session_leader.process.thread.id" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.thread.id", v),
				"ProcessProcessSessionLeaderProcessThreadId" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.thread.id", v),
				"process.process.session_leader.process.thread.name" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.thread.name", v),
				"ProcessProcessSessionLeaderProcessThreadName" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.thread.name", v),
				"process.process.session_leader.process.title" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.title", v),
				"ProcessProcessSessionLeaderProcessTitle" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.title", v),
				"process.process.session_leader.process.uptime" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.uptime", v),
				"ProcessProcessSessionLeaderProcessUptime" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.uptime", v),
				"process.process.session_leader.process.vpid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.vpid", v),
				"ProcessProcessSessionLeaderProcessVpid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.vpid", v),
				"process.process.session_leader.process.working_directory" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.working_directory", v),
				"ProcessProcessSessionLeaderProcessWorkingDirectory" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.working_directory", v),
				"process.process.session_leader.process.session_leader.parent.process.args_count" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.args_count", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessArgsCount" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.args_count", v),
				"process.process.session_leader.process.session_leader.parent.process.command_line" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.command_line", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessCommandLine" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.command_line", v),
				"process.process.session_leader.process.session_leader.parent.process.end" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.end", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessEnd" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.end", v),
				"process.process.session_leader.process.session_leader.parent.process.entity_id" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.entity_id", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessEntityId" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.entity_id", v),
				"process.process.session_leader.process.session_leader.parent.process.executable" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.executable", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessExecutable" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.executable", v),
				"process.process.session_leader.process.session_leader.parent.process.exit_code" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.exit_code", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessExitCode" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.exit_code", v),
				"process.process.session_leader.process.session_leader.parent.process.interactive" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.interactive", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessInteractive" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.interactive", v),
				"process.process.session_leader.process.session_leader.parent.process.name" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.name", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessName" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.name", v),
				"process.process.session_leader.process.session_leader.parent.process.pgid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.pgid", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessPgid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.pgid", v),
				"process.process.session_leader.process.session_leader.parent.process.pid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.pid", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessPid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.pid", v),
				"process.process.session_leader.process.session_leader.parent.process.start" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.start", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessStart" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.start", v),
				"process.process.session_leader.process.session_leader.parent.process.thread.id" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.thread.id", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessThreadId" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.thread.id", v),
				"process.process.session_leader.process.session_leader.parent.process.thread.name" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.thread.name", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessThreadName" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.thread.name", v),
				"process.process.session_leader.process.session_leader.parent.process.title" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.title", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessTitle" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.title", v),
				"process.process.session_leader.process.session_leader.parent.process.uptime" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.uptime", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessUptime" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.uptime", v),
				"process.process.session_leader.process.session_leader.parent.process.vpid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.vpid", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessVpid" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.vpid", v),
				"process.process.session_leader.process.session_leader.parent.process.working_directory" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.working_directory", v),
				"ProcessProcessSessionLeaderProcessSessionLeaderParentProcessWorkingDirectory" => static (e, v) => TrySetProcessSessionLeader(e, "process.session_leader.process.session_leader.parent.process.working_directory", v),
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
				"server.as.number" => static (e, v) => TrySetAs(e, "as.number", v),
				"ServerAsNumber" => static (e, v) => TrySetAs(e, "as.number", v),
				"server.as.organization.name" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"ServerAsOrganizationName" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"server.geo.city_name" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"ServerGeoCityName" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"server.geo.continent_code" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"ServerGeoContinentCode" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"server.geo.continent_name" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"ServerGeoContinentName" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"server.geo.country_iso_code" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"ServerGeoCountryIsoCode" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"server.geo.country_name" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"ServerGeoCountryName" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"server.geo.name" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"ServerGeoName" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"server.geo.postal_code" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"ServerGeoPostalCode" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"server.geo.region_iso_code" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"ServerGeoRegionIsoCode" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"server.geo.region_name" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"ServerGeoRegionName" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"server.geo.timezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"ServerGeoTimezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"server.user.domain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"ServerUserDomain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"server.user.email" => static (e, v) => TrySetUser(e, "user.email", v),
				"ServerUserEmail" => static (e, v) => TrySetUser(e, "user.email", v),
				"server.user.full_name" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"ServerUserFullName" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"server.user.hash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"ServerUserHash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"server.user.id" => static (e, v) => TrySetUser(e, "user.id", v),
				"ServerUserId" => static (e, v) => TrySetUser(e, "user.id", v),
				"server.user.name" => static (e, v) => TrySetUser(e, "user.name", v),
				"ServerUserName" => static (e, v) => TrySetUser(e, "user.name", v),
				"server.user.group.domain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"ServerUserGroupDomain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"server.user.group.id" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"ServerUserGroupId" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"server.user.group.name" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"ServerUserGroupName" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"server.user.risk.calculated_level" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"ServerUserRiskCalculatedLevel" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"server.user.risk.calculated_score" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"ServerUserRiskCalculatedScore" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"server.user.risk.calculated_score_norm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"ServerUserRiskCalculatedScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"server.user.risk.static_level" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"ServerUserRiskStaticLevel" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"server.user.risk.static_score" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"ServerUserRiskStaticScore" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"server.user.risk.static_score_norm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"ServerUserRiskStaticScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"server.user.user.domain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"ServerUserUserDomain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"server.user.user.email" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"ServerUserUserEmail" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"server.user.user.full_name" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"ServerUserUserFullName" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"server.user.user.hash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"ServerUserUserHash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"server.user.user.id" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"ServerUserUserId" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"server.user.user.name" => static (e, v) => TrySetUser(e, "user.user.name", v),
				"ServerUserUserName" => static (e, v) => TrySetUser(e, "user.user.name", v),
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
				"service.origin.address" => static (e, v) => TrySetService(e, "service.address", v),
				"ServiceServiceAddress" => static (e, v) => TrySetServiceOrigin(e, "service.address", v),
				"service.service.environment" => static (e, v) => TrySetServiceOrigin(e, "service.environment", v),
				"ServiceServiceEnvironment" => static (e, v) => TrySetServiceOrigin(e, "service.environment", v),
				"service.service.ephemeral_id" => static (e, v) => TrySetServiceOrigin(e, "service.ephemeral_id", v),
				"ServiceServiceEphemeralId" => static (e, v) => TrySetServiceOrigin(e, "service.ephemeral_id", v),
				"service.service.id" => static (e, v) => TrySetServiceOrigin(e, "service.id", v),
				"ServiceServiceId" => static (e, v) => TrySetServiceOrigin(e, "service.id", v),
				"service.service.name" => static (e, v) => TrySetServiceOrigin(e, "service.name", v),
				"ServiceServiceName" => static (e, v) => TrySetServiceOrigin(e, "service.name", v),
				"service.service.node.name" => static (e, v) => TrySetServiceOrigin(e, "service.node.name", v),
				"ServiceServiceNodeName" => static (e, v) => TrySetServiceOrigin(e, "service.node.name", v),
				"service.service.node.role" => static (e, v) => TrySetServiceOrigin(e, "service.node.role", v),
				"ServiceServiceNodeRole" => static (e, v) => TrySetServiceOrigin(e, "service.node.role", v),
				"service.service.state" => static (e, v) => TrySetServiceOrigin(e, "service.state", v),
				"ServiceServiceState" => static (e, v) => TrySetServiceOrigin(e, "service.state", v),
				"service.service.type" => static (e, v) => TrySetServiceOrigin(e, "service.type", v),
				"ServiceServiceType" => static (e, v) => TrySetServiceOrigin(e, "service.type", v),
				"service.service.version" => static (e, v) => TrySetServiceOrigin(e, "service.version", v),
				"ServiceServiceVersion" => static (e, v) => TrySetServiceOrigin(e, "service.version", v),
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
				"source.as.number" => static (e, v) => TrySetAs(e, "as.number", v),
				"SourceAsNumber" => static (e, v) => TrySetAs(e, "as.number", v),
				"source.as.organization.name" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"SourceAsOrganizationName" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"source.geo.city_name" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"SourceGeoCityName" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"source.geo.continent_code" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"SourceGeoContinentCode" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"source.geo.continent_name" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"SourceGeoContinentName" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"source.geo.country_iso_code" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"SourceGeoCountryIsoCode" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"source.geo.country_name" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"SourceGeoCountryName" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"source.geo.name" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"SourceGeoName" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"source.geo.postal_code" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"SourceGeoPostalCode" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"source.geo.region_iso_code" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"SourceGeoRegionIsoCode" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"source.geo.region_name" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"SourceGeoRegionName" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"source.geo.timezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"SourceGeoTimezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"source.user.domain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"SourceUserDomain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"source.user.email" => static (e, v) => TrySetUser(e, "user.email", v),
				"SourceUserEmail" => static (e, v) => TrySetUser(e, "user.email", v),
				"source.user.full_name" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"SourceUserFullName" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"source.user.hash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"SourceUserHash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"source.user.id" => static (e, v) => TrySetUser(e, "user.id", v),
				"SourceUserId" => static (e, v) => TrySetUser(e, "user.id", v),
				"source.user.name" => static (e, v) => TrySetUser(e, "user.name", v),
				"SourceUserName" => static (e, v) => TrySetUser(e, "user.name", v),
				"source.user.group.domain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"SourceUserGroupDomain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"source.user.group.id" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"SourceUserGroupId" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"source.user.group.name" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"SourceUserGroupName" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"source.user.risk.calculated_level" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"SourceUserRiskCalculatedLevel" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"source.user.risk.calculated_score" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"SourceUserRiskCalculatedScore" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"source.user.risk.calculated_score_norm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"SourceUserRiskCalculatedScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"source.user.risk.static_level" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"SourceUserRiskStaticLevel" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"source.user.risk.static_score" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"SourceUserRiskStaticScore" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"source.user.risk.static_score_norm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"SourceUserRiskStaticScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"source.user.user.domain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"SourceUserUserDomain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"source.user.user.email" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"SourceUserUserEmail" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"source.user.user.full_name" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"SourceUserUserFullName" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"source.user.user.hash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"SourceUserUserHash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"source.user.user.id" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"SourceUserUserId" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"source.user.user.name" => static (e, v) => TrySetUser(e, "user.user.name", v),
				"SourceUserUserName" => static (e, v) => TrySetUser(e, "user.user.name", v),
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
				"threat.indicator.marking.tlp_version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorMarkingTlpVersion = p),
				"ThreatIndicatorMarkingTlpVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorMarkingTlpVersion = p),
				"threat.indicator.modified_at" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.IndicatorModifiedAt = p),
				"ThreatIndicatorModifiedAt" => static (e, v) => TrySetDateTimeOffset(e, v, static (ee, p) => ee.IndicatorModifiedAt = p),
				"threat.indicator.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorName = p),
				"ThreatIndicatorName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.IndicatorName = p),
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
				"threat.x509.issuer.distinguished_name" => static (e, v) => TrySetX509(e, "x509.issuer.distinguished_name", v),
				"ThreatX509IssuerDistinguishedName" => static (e, v) => TrySetX509(e, "x509.issuer.distinguished_name", v),
				"threat.x509.not_after" => static (e, v) => TrySetX509(e, "x509.not_after", v),
				"ThreatX509NotAfter" => static (e, v) => TrySetX509(e, "x509.not_after", v),
				"threat.x509.not_before" => static (e, v) => TrySetX509(e, "x509.not_before", v),
				"ThreatX509NotBefore" => static (e, v) => TrySetX509(e, "x509.not_before", v),
				"threat.x509.public_key_algorithm" => static (e, v) => TrySetX509(e, "x509.public_key_algorithm", v),
				"ThreatX509PublicKeyAlgorithm" => static (e, v) => TrySetX509(e, "x509.public_key_algorithm", v),
				"threat.x509.public_key_curve" => static (e, v) => TrySetX509(e, "x509.public_key_curve", v),
				"ThreatX509PublicKeyCurve" => static (e, v) => TrySetX509(e, "x509.public_key_curve", v),
				"threat.x509.public_key_exponent" => static (e, v) => TrySetX509(e, "x509.public_key_exponent", v),
				"ThreatX509PublicKeyExponent" => static (e, v) => TrySetX509(e, "x509.public_key_exponent", v),
				"threat.x509.public_key_size" => static (e, v) => TrySetX509(e, "x509.public_key_size", v),
				"ThreatX509PublicKeySize" => static (e, v) => TrySetX509(e, "x509.public_key_size", v),
				"threat.x509.serial_number" => static (e, v) => TrySetX509(e, "x509.serial_number", v),
				"ThreatX509SerialNumber" => static (e, v) => TrySetX509(e, "x509.serial_number", v),
				"threat.x509.signature_algorithm" => static (e, v) => TrySetX509(e, "x509.signature_algorithm", v),
				"ThreatX509SignatureAlgorithm" => static (e, v) => TrySetX509(e, "x509.signature_algorithm", v),
				"threat.x509.subject.distinguished_name" => static (e, v) => TrySetX509(e, "x509.subject.distinguished_name", v),
				"ThreatX509SubjectDistinguishedName" => static (e, v) => TrySetX509(e, "x509.subject.distinguished_name", v),
				"threat.x509.version_number" => static (e, v) => TrySetX509(e, "x509.version_number", v),
				"ThreatX509VersionNumber" => static (e, v) => TrySetX509(e, "x509.version_number", v),
				"threat.as.number" => static (e, v) => TrySetAs(e, "as.number", v),
				"ThreatAsNumber" => static (e, v) => TrySetAs(e, "as.number", v),
				"threat.as.organization.name" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"ThreatAsOrganizationName" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"threat.file.accessed" => static (e, v) => TrySetFile(e, "file.accessed", v),
				"ThreatFileAccessed" => static (e, v) => TrySetFile(e, "file.accessed", v),
				"threat.file.created" => static (e, v) => TrySetFile(e, "file.created", v),
				"ThreatFileCreated" => static (e, v) => TrySetFile(e, "file.created", v),
				"threat.file.ctime" => static (e, v) => TrySetFile(e, "file.ctime", v),
				"ThreatFileCtime" => static (e, v) => TrySetFile(e, "file.ctime", v),
				"threat.file.device" => static (e, v) => TrySetFile(e, "file.device", v),
				"ThreatFileDevice" => static (e, v) => TrySetFile(e, "file.device", v),
				"threat.file.directory" => static (e, v) => TrySetFile(e, "file.directory", v),
				"ThreatFileDirectory" => static (e, v) => TrySetFile(e, "file.directory", v),
				"threat.file.drive_letter" => static (e, v) => TrySetFile(e, "file.drive_letter", v),
				"ThreatFileDriveLetter" => static (e, v) => TrySetFile(e, "file.drive_letter", v),
				"threat.file.extension" => static (e, v) => TrySetFile(e, "file.extension", v),
				"ThreatFileExtension" => static (e, v) => TrySetFile(e, "file.extension", v),
				"threat.file.fork_name" => static (e, v) => TrySetFile(e, "file.fork_name", v),
				"ThreatFileForkName" => static (e, v) => TrySetFile(e, "file.fork_name", v),
				"threat.file.gid" => static (e, v) => TrySetFile(e, "file.gid", v),
				"ThreatFileGid" => static (e, v) => TrySetFile(e, "file.gid", v),
				"threat.file.group" => static (e, v) => TrySetFile(e, "file.group", v),
				"ThreatFileGroup" => static (e, v) => TrySetFile(e, "file.group", v),
				"threat.file.inode" => static (e, v) => TrySetFile(e, "file.inode", v),
				"ThreatFileInode" => static (e, v) => TrySetFile(e, "file.inode", v),
				"threat.file.mime_type" => static (e, v) => TrySetFile(e, "file.mime_type", v),
				"ThreatFileMimeType" => static (e, v) => TrySetFile(e, "file.mime_type", v),
				"threat.file.mode" => static (e, v) => TrySetFile(e, "file.mode", v),
				"ThreatFileMode" => static (e, v) => TrySetFile(e, "file.mode", v),
				"threat.file.mtime" => static (e, v) => TrySetFile(e, "file.mtime", v),
				"ThreatFileMtime" => static (e, v) => TrySetFile(e, "file.mtime", v),
				"threat.file.name" => static (e, v) => TrySetFile(e, "file.name", v),
				"ThreatFileName" => static (e, v) => TrySetFile(e, "file.name", v),
				"threat.file.owner" => static (e, v) => TrySetFile(e, "file.owner", v),
				"ThreatFileOwner" => static (e, v) => TrySetFile(e, "file.owner", v),
				"threat.file.path" => static (e, v) => TrySetFile(e, "file.path", v),
				"ThreatFilePath" => static (e, v) => TrySetFile(e, "file.path", v),
				"threat.file.size" => static (e, v) => TrySetFile(e, "file.size", v),
				"ThreatFileSize" => static (e, v) => TrySetFile(e, "file.size", v),
				"threat.file.target_path" => static (e, v) => TrySetFile(e, "file.target_path", v),
				"ThreatFileTargetPath" => static (e, v) => TrySetFile(e, "file.target_path", v),
				"threat.file.type" => static (e, v) => TrySetFile(e, "file.type", v),
				"ThreatFileType" => static (e, v) => TrySetFile(e, "file.type", v),
				"threat.file.uid" => static (e, v) => TrySetFile(e, "file.uid", v),
				"ThreatFileUid" => static (e, v) => TrySetFile(e, "file.uid", v),
				"threat.file.hash.md5" => static (e, v) => TrySetFile(e, "file.hash.md5", v),
				"ThreatFileHashMd5" => static (e, v) => TrySetFile(e, "file.hash.md5", v),
				"threat.file.hash.sha1" => static (e, v) => TrySetFile(e, "file.hash.sha1", v),
				"ThreatFileHashSha1" => static (e, v) => TrySetFile(e, "file.hash.sha1", v),
				"threat.file.hash.sha256" => static (e, v) => TrySetFile(e, "file.hash.sha256", v),
				"ThreatFileHashSha256" => static (e, v) => TrySetFile(e, "file.hash.sha256", v),
				"threat.file.hash.sha384" => static (e, v) => TrySetFile(e, "file.hash.sha384", v),
				"ThreatFileHashSha384" => static (e, v) => TrySetFile(e, "file.hash.sha384", v),
				"threat.file.hash.sha512" => static (e, v) => TrySetFile(e, "file.hash.sha512", v),
				"ThreatFileHashSha512" => static (e, v) => TrySetFile(e, "file.hash.sha512", v),
				"threat.file.hash.ssdeep" => static (e, v) => TrySetFile(e, "file.hash.ssdeep", v),
				"ThreatFileHashSsdeep" => static (e, v) => TrySetFile(e, "file.hash.ssdeep", v),
				"threat.file.hash.tlsh" => static (e, v) => TrySetFile(e, "file.hash.tlsh", v),
				"ThreatFileHashTlsh" => static (e, v) => TrySetFile(e, "file.hash.tlsh", v),
				"threat.file.pe.architecture" => static (e, v) => TrySetFile(e, "file.pe.architecture", v),
				"ThreatFilePeArchitecture" => static (e, v) => TrySetFile(e, "file.pe.architecture", v),
				"threat.file.pe.company" => static (e, v) => TrySetFile(e, "file.pe.company", v),
				"ThreatFilePeCompany" => static (e, v) => TrySetFile(e, "file.pe.company", v),
				"threat.file.pe.description" => static (e, v) => TrySetFile(e, "file.pe.description", v),
				"ThreatFilePeDescription" => static (e, v) => TrySetFile(e, "file.pe.description", v),
				"threat.file.pe.file_version" => static (e, v) => TrySetFile(e, "file.pe.file_version", v),
				"ThreatFilePeFileVersion" => static (e, v) => TrySetFile(e, "file.pe.file_version", v),
				"threat.file.pe.go_import_hash" => static (e, v) => TrySetFile(e, "file.pe.go_import_hash", v),
				"ThreatFilePeGoImportHash" => static (e, v) => TrySetFile(e, "file.pe.go_import_hash", v),
				"threat.file.pe.go_imports" => static (e, v) => TrySetFile(e, "file.pe.go_imports", v),
				"ThreatFilePeGoImports" => static (e, v) => TrySetFile(e, "file.pe.go_imports", v),
				"threat.file.pe.go_imports_names_entropy" => static (e, v) => TrySetFile(e, "file.pe.go_imports_names_entropy", v),
				"ThreatFilePeGoImportsNamesEntropy" => static (e, v) => TrySetFile(e, "file.pe.go_imports_names_entropy", v),
				"threat.file.pe.go_imports_names_var_entropy" => static (e, v) => TrySetFile(e, "file.pe.go_imports_names_var_entropy", v),
				"ThreatFilePeGoImportsNamesVarEntropy" => static (e, v) => TrySetFile(e, "file.pe.go_imports_names_var_entropy", v),
				"threat.file.pe.go_stripped" => static (e, v) => TrySetFile(e, "file.pe.go_stripped", v),
				"ThreatFilePeGoStripped" => static (e, v) => TrySetFile(e, "file.pe.go_stripped", v),
				"threat.file.pe.imphash" => static (e, v) => TrySetFile(e, "file.pe.imphash", v),
				"ThreatFilePeImphash" => static (e, v) => TrySetFile(e, "file.pe.imphash", v),
				"threat.file.pe.import_hash" => static (e, v) => TrySetFile(e, "file.pe.import_hash", v),
				"ThreatFilePeImportHash" => static (e, v) => TrySetFile(e, "file.pe.import_hash", v),
				"threat.file.pe.imports_names_entropy" => static (e, v) => TrySetFile(e, "file.pe.imports_names_entropy", v),
				"ThreatFilePeImportsNamesEntropy" => static (e, v) => TrySetFile(e, "file.pe.imports_names_entropy", v),
				"threat.file.pe.imports_names_var_entropy" => static (e, v) => TrySetFile(e, "file.pe.imports_names_var_entropy", v),
				"ThreatFilePeImportsNamesVarEntropy" => static (e, v) => TrySetFile(e, "file.pe.imports_names_var_entropy", v),
				"threat.file.pe.original_file_name" => static (e, v) => TrySetFile(e, "file.pe.original_file_name", v),
				"ThreatFilePeOriginalFileName" => static (e, v) => TrySetFile(e, "file.pe.original_file_name", v),
				"threat.file.pe.pehash" => static (e, v) => TrySetFile(e, "file.pe.pehash", v),
				"ThreatFilePePehash" => static (e, v) => TrySetFile(e, "file.pe.pehash", v),
				"threat.file.pe.product" => static (e, v) => TrySetFile(e, "file.pe.product", v),
				"ThreatFilePeProduct" => static (e, v) => TrySetFile(e, "file.pe.product", v),
				"threat.file.x509.issuer.distinguished_name" => static (e, v) => TrySetFile(e, "file.x509.issuer.distinguished_name", v),
				"ThreatFileX509IssuerDistinguishedName" => static (e, v) => TrySetFile(e, "file.x509.issuer.distinguished_name", v),
				"threat.file.x509.not_after" => static (e, v) => TrySetFile(e, "file.x509.not_after", v),
				"ThreatFileX509NotAfter" => static (e, v) => TrySetFile(e, "file.x509.not_after", v),
				"threat.file.x509.not_before" => static (e, v) => TrySetFile(e, "file.x509.not_before", v),
				"ThreatFileX509NotBefore" => static (e, v) => TrySetFile(e, "file.x509.not_before", v),
				"threat.file.x509.public_key_algorithm" => static (e, v) => TrySetFile(e, "file.x509.public_key_algorithm", v),
				"ThreatFileX509PublicKeyAlgorithm" => static (e, v) => TrySetFile(e, "file.x509.public_key_algorithm", v),
				"threat.file.x509.public_key_curve" => static (e, v) => TrySetFile(e, "file.x509.public_key_curve", v),
				"ThreatFileX509PublicKeyCurve" => static (e, v) => TrySetFile(e, "file.x509.public_key_curve", v),
				"threat.file.x509.public_key_exponent" => static (e, v) => TrySetFile(e, "file.x509.public_key_exponent", v),
				"ThreatFileX509PublicKeyExponent" => static (e, v) => TrySetFile(e, "file.x509.public_key_exponent", v),
				"threat.file.x509.public_key_size" => static (e, v) => TrySetFile(e, "file.x509.public_key_size", v),
				"ThreatFileX509PublicKeySize" => static (e, v) => TrySetFile(e, "file.x509.public_key_size", v),
				"threat.file.x509.serial_number" => static (e, v) => TrySetFile(e, "file.x509.serial_number", v),
				"ThreatFileX509SerialNumber" => static (e, v) => TrySetFile(e, "file.x509.serial_number", v),
				"threat.file.x509.signature_algorithm" => static (e, v) => TrySetFile(e, "file.x509.signature_algorithm", v),
				"ThreatFileX509SignatureAlgorithm" => static (e, v) => TrySetFile(e, "file.x509.signature_algorithm", v),
				"threat.file.x509.subject.distinguished_name" => static (e, v) => TrySetFile(e, "file.x509.subject.distinguished_name", v),
				"ThreatFileX509SubjectDistinguishedName" => static (e, v) => TrySetFile(e, "file.x509.subject.distinguished_name", v),
				"threat.file.x509.version_number" => static (e, v) => TrySetFile(e, "file.x509.version_number", v),
				"ThreatFileX509VersionNumber" => static (e, v) => TrySetFile(e, "file.x509.version_number", v),
				"threat.file.code_signature.digest_algorithm" => static (e, v) => TrySetFile(e, "file.code_signature.digest_algorithm", v),
				"ThreatFileCodeSignatureDigestAlgorithm" => static (e, v) => TrySetFile(e, "file.code_signature.digest_algorithm", v),
				"threat.file.code_signature.exists" => static (e, v) => TrySetFile(e, "file.code_signature.exists", v),
				"ThreatFileCodeSignatureExists" => static (e, v) => TrySetFile(e, "file.code_signature.exists", v),
				"threat.file.code_signature.signing_id" => static (e, v) => TrySetFile(e, "file.code_signature.signing_id", v),
				"ThreatFileCodeSignatureSigningId" => static (e, v) => TrySetFile(e, "file.code_signature.signing_id", v),
				"threat.file.code_signature.status" => static (e, v) => TrySetFile(e, "file.code_signature.status", v),
				"ThreatFileCodeSignatureStatus" => static (e, v) => TrySetFile(e, "file.code_signature.status", v),
				"threat.file.code_signature.subject_name" => static (e, v) => TrySetFile(e, "file.code_signature.subject_name", v),
				"ThreatFileCodeSignatureSubjectName" => static (e, v) => TrySetFile(e, "file.code_signature.subject_name", v),
				"threat.file.code_signature.team_id" => static (e, v) => TrySetFile(e, "file.code_signature.team_id", v),
				"ThreatFileCodeSignatureTeamId" => static (e, v) => TrySetFile(e, "file.code_signature.team_id", v),
				"threat.file.code_signature.timestamp" => static (e, v) => TrySetFile(e, "file.code_signature.timestamp", v),
				"ThreatFileCodeSignatureTimestamp" => static (e, v) => TrySetFile(e, "file.code_signature.timestamp", v),
				"threat.file.code_signature.trusted" => static (e, v) => TrySetFile(e, "file.code_signature.trusted", v),
				"ThreatFileCodeSignatureTrusted" => static (e, v) => TrySetFile(e, "file.code_signature.trusted", v),
				"threat.file.code_signature.valid" => static (e, v) => TrySetFile(e, "file.code_signature.valid", v),
				"ThreatFileCodeSignatureValid" => static (e, v) => TrySetFile(e, "file.code_signature.valid", v),
				"threat.file.elf.architecture" => static (e, v) => TrySetFile(e, "file.elf.architecture", v),
				"ThreatFileElfArchitecture" => static (e, v) => TrySetFile(e, "file.elf.architecture", v),
				"threat.file.elf.byte_order" => static (e, v) => TrySetFile(e, "file.elf.byte_order", v),
				"ThreatFileElfByteOrder" => static (e, v) => TrySetFile(e, "file.elf.byte_order", v),
				"threat.file.elf.cpu_type" => static (e, v) => TrySetFile(e, "file.elf.cpu_type", v),
				"ThreatFileElfCpuType" => static (e, v) => TrySetFile(e, "file.elf.cpu_type", v),
				"threat.file.elf.creation_date" => static (e, v) => TrySetFile(e, "file.elf.creation_date", v),
				"ThreatFileElfCreationDate" => static (e, v) => TrySetFile(e, "file.elf.creation_date", v),
				"threat.file.elf.go_import_hash" => static (e, v) => TrySetFile(e, "file.elf.go_import_hash", v),
				"ThreatFileElfGoImportHash" => static (e, v) => TrySetFile(e, "file.elf.go_import_hash", v),
				"threat.file.elf.go_imports" => static (e, v) => TrySetFile(e, "file.elf.go_imports", v),
				"ThreatFileElfGoImports" => static (e, v) => TrySetFile(e, "file.elf.go_imports", v),
				"threat.file.elf.go_imports_names_entropy" => static (e, v) => TrySetFile(e, "file.elf.go_imports_names_entropy", v),
				"ThreatFileElfGoImportsNamesEntropy" => static (e, v) => TrySetFile(e, "file.elf.go_imports_names_entropy", v),
				"threat.file.elf.go_imports_names_var_entropy" => static (e, v) => TrySetFile(e, "file.elf.go_imports_names_var_entropy", v),
				"ThreatFileElfGoImportsNamesVarEntropy" => static (e, v) => TrySetFile(e, "file.elf.go_imports_names_var_entropy", v),
				"threat.file.elf.go_stripped" => static (e, v) => TrySetFile(e, "file.elf.go_stripped", v),
				"ThreatFileElfGoStripped" => static (e, v) => TrySetFile(e, "file.elf.go_stripped", v),
				"threat.file.elf.header.abi_version" => static (e, v) => TrySetFile(e, "file.elf.header.abi_version", v),
				"ThreatFileElfHeaderAbiVersion" => static (e, v) => TrySetFile(e, "file.elf.header.abi_version", v),
				"threat.file.elf.header.class" => static (e, v) => TrySetFile(e, "file.elf.header.class", v),
				"ThreatFileElfHeaderClass" => static (e, v) => TrySetFile(e, "file.elf.header.class", v),
				"threat.file.elf.header.data" => static (e, v) => TrySetFile(e, "file.elf.header.data", v),
				"ThreatFileElfHeaderData" => static (e, v) => TrySetFile(e, "file.elf.header.data", v),
				"threat.file.elf.header.entrypoint" => static (e, v) => TrySetFile(e, "file.elf.header.entrypoint", v),
				"ThreatFileElfHeaderEntrypoint" => static (e, v) => TrySetFile(e, "file.elf.header.entrypoint", v),
				"threat.file.elf.header.object_version" => static (e, v) => TrySetFile(e, "file.elf.header.object_version", v),
				"ThreatFileElfHeaderObjectVersion" => static (e, v) => TrySetFile(e, "file.elf.header.object_version", v),
				"threat.file.elf.header.os_abi" => static (e, v) => TrySetFile(e, "file.elf.header.os_abi", v),
				"ThreatFileElfHeaderOsAbi" => static (e, v) => TrySetFile(e, "file.elf.header.os_abi", v),
				"threat.file.elf.header.type" => static (e, v) => TrySetFile(e, "file.elf.header.type", v),
				"ThreatFileElfHeaderType" => static (e, v) => TrySetFile(e, "file.elf.header.type", v),
				"threat.file.elf.header.version" => static (e, v) => TrySetFile(e, "file.elf.header.version", v),
				"ThreatFileElfHeaderVersion" => static (e, v) => TrySetFile(e, "file.elf.header.version", v),
				"threat.file.elf.import_hash" => static (e, v) => TrySetFile(e, "file.elf.import_hash", v),
				"ThreatFileElfImportHash" => static (e, v) => TrySetFile(e, "file.elf.import_hash", v),
				"threat.file.elf.imports_names_entropy" => static (e, v) => TrySetFile(e, "file.elf.imports_names_entropy", v),
				"ThreatFileElfImportsNamesEntropy" => static (e, v) => TrySetFile(e, "file.elf.imports_names_entropy", v),
				"threat.file.elf.imports_names_var_entropy" => static (e, v) => TrySetFile(e, "file.elf.imports_names_var_entropy", v),
				"ThreatFileElfImportsNamesVarEntropy" => static (e, v) => TrySetFile(e, "file.elf.imports_names_var_entropy", v),
				"threat.file.elf.telfhash" => static (e, v) => TrySetFile(e, "file.elf.telfhash", v),
				"ThreatFileElfTelfhash" => static (e, v) => TrySetFile(e, "file.elf.telfhash", v),
				"threat.file.macho.go_import_hash" => static (e, v) => TrySetFile(e, "file.macho.go_import_hash", v),
				"ThreatFileMachoGoImportHash" => static (e, v) => TrySetFile(e, "file.macho.go_import_hash", v),
				"threat.file.macho.go_imports" => static (e, v) => TrySetFile(e, "file.macho.go_imports", v),
				"ThreatFileMachoGoImports" => static (e, v) => TrySetFile(e, "file.macho.go_imports", v),
				"threat.file.macho.go_imports_names_entropy" => static (e, v) => TrySetFile(e, "file.macho.go_imports_names_entropy", v),
				"ThreatFileMachoGoImportsNamesEntropy" => static (e, v) => TrySetFile(e, "file.macho.go_imports_names_entropy", v),
				"threat.file.macho.go_imports_names_var_entropy" => static (e, v) => TrySetFile(e, "file.macho.go_imports_names_var_entropy", v),
				"ThreatFileMachoGoImportsNamesVarEntropy" => static (e, v) => TrySetFile(e, "file.macho.go_imports_names_var_entropy", v),
				"threat.file.macho.go_stripped" => static (e, v) => TrySetFile(e, "file.macho.go_stripped", v),
				"ThreatFileMachoGoStripped" => static (e, v) => TrySetFile(e, "file.macho.go_stripped", v),
				"threat.file.macho.import_hash" => static (e, v) => TrySetFile(e, "file.macho.import_hash", v),
				"ThreatFileMachoImportHash" => static (e, v) => TrySetFile(e, "file.macho.import_hash", v),
				"threat.file.macho.imports_names_entropy" => static (e, v) => TrySetFile(e, "file.macho.imports_names_entropy", v),
				"ThreatFileMachoImportsNamesEntropy" => static (e, v) => TrySetFile(e, "file.macho.imports_names_entropy", v),
				"threat.file.macho.imports_names_var_entropy" => static (e, v) => TrySetFile(e, "file.macho.imports_names_var_entropy", v),
				"ThreatFileMachoImportsNamesVarEntropy" => static (e, v) => TrySetFile(e, "file.macho.imports_names_var_entropy", v),
				"threat.file.macho.symhash" => static (e, v) => TrySetFile(e, "file.macho.symhash", v),
				"ThreatFileMachoSymhash" => static (e, v) => TrySetFile(e, "file.macho.symhash", v),
				"threat.geo.city_name" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"ThreatGeoCityName" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"threat.geo.continent_code" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"ThreatGeoContinentCode" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"threat.geo.continent_name" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"ThreatGeoContinentName" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"threat.geo.country_iso_code" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"ThreatGeoCountryIsoCode" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"threat.geo.country_name" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"ThreatGeoCountryName" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"threat.geo.name" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"ThreatGeoName" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"threat.geo.postal_code" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"ThreatGeoPostalCode" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"threat.geo.region_iso_code" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"ThreatGeoRegionIsoCode" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"threat.geo.region_name" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"ThreatGeoRegionName" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"threat.geo.timezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"ThreatGeoTimezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"threat.registry.data.bytes" => static (e, v) => TrySetRegistry(e, "registry.data.bytes", v),
				"ThreatRegistryDataBytes" => static (e, v) => TrySetRegistry(e, "registry.data.bytes", v),
				"threat.registry.data.type" => static (e, v) => TrySetRegistry(e, "registry.data.type", v),
				"ThreatRegistryDataType" => static (e, v) => TrySetRegistry(e, "registry.data.type", v),
				"threat.registry.hive" => static (e, v) => TrySetRegistry(e, "registry.hive", v),
				"ThreatRegistryHive" => static (e, v) => TrySetRegistry(e, "registry.hive", v),
				"threat.registry.key" => static (e, v) => TrySetRegistry(e, "registry.key", v),
				"ThreatRegistryKey" => static (e, v) => TrySetRegistry(e, "registry.key", v),
				"threat.registry.path" => static (e, v) => TrySetRegistry(e, "registry.path", v),
				"ThreatRegistryPath" => static (e, v) => TrySetRegistry(e, "registry.path", v),
				"threat.registry.value" => static (e, v) => TrySetRegistry(e, "registry.value", v),
				"ThreatRegistryValue" => static (e, v) => TrySetRegistry(e, "registry.value", v),
				"threat.url.domain" => static (e, v) => TrySetUrl(e, "url.domain", v),
				"ThreatUrlDomain" => static (e, v) => TrySetUrl(e, "url.domain", v),
				"threat.url.extension" => static (e, v) => TrySetUrl(e, "url.extension", v),
				"ThreatUrlExtension" => static (e, v) => TrySetUrl(e, "url.extension", v),
				"threat.url.fragment" => static (e, v) => TrySetUrl(e, "url.fragment", v),
				"ThreatUrlFragment" => static (e, v) => TrySetUrl(e, "url.fragment", v),
				"threat.url.full" => static (e, v) => TrySetUrl(e, "url.full", v),
				"ThreatUrlFull" => static (e, v) => TrySetUrl(e, "url.full", v),
				"threat.url.original" => static (e, v) => TrySetUrl(e, "url.original", v),
				"ThreatUrlOriginal" => static (e, v) => TrySetUrl(e, "url.original", v),
				"threat.url.password" => static (e, v) => TrySetUrl(e, "url.password", v),
				"ThreatUrlPassword" => static (e, v) => TrySetUrl(e, "url.password", v),
				"threat.url.path" => static (e, v) => TrySetUrl(e, "url.path", v),
				"ThreatUrlPath" => static (e, v) => TrySetUrl(e, "url.path", v),
				"threat.url.port" => static (e, v) => TrySetUrl(e, "url.port", v),
				"ThreatUrlPort" => static (e, v) => TrySetUrl(e, "url.port", v),
				"threat.url.query" => static (e, v) => TrySetUrl(e, "url.query", v),
				"ThreatUrlQuery" => static (e, v) => TrySetUrl(e, "url.query", v),
				"threat.url.registered_domain" => static (e, v) => TrySetUrl(e, "url.registered_domain", v),
				"ThreatUrlRegisteredDomain" => static (e, v) => TrySetUrl(e, "url.registered_domain", v),
				"threat.url.scheme" => static (e, v) => TrySetUrl(e, "url.scheme", v),
				"ThreatUrlScheme" => static (e, v) => TrySetUrl(e, "url.scheme", v),
				"threat.url.subdomain" => static (e, v) => TrySetUrl(e, "url.subdomain", v),
				"ThreatUrlSubdomain" => static (e, v) => TrySetUrl(e, "url.subdomain", v),
				"threat.url.top_level_domain" => static (e, v) => TrySetUrl(e, "url.top_level_domain", v),
				"ThreatUrlTopLevelDomain" => static (e, v) => TrySetUrl(e, "url.top_level_domain", v),
				"threat.url.username" => static (e, v) => TrySetUrl(e, "url.username", v),
				"ThreatUrlUsername" => static (e, v) => TrySetUrl(e, "url.username", v),
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
				"tls.x509.issuer.distinguished_name" => static (e, v) => TrySetX509(e, "x509.issuer.distinguished_name", v),
				"TlsX509IssuerDistinguishedName" => static (e, v) => TrySetX509(e, "x509.issuer.distinguished_name", v),
				"tls.x509.not_after" => static (e, v) => TrySetX509(e, "x509.not_after", v),
				"TlsX509NotAfter" => static (e, v) => TrySetX509(e, "x509.not_after", v),
				"tls.x509.not_before" => static (e, v) => TrySetX509(e, "x509.not_before", v),
				"TlsX509NotBefore" => static (e, v) => TrySetX509(e, "x509.not_before", v),
				"tls.x509.public_key_algorithm" => static (e, v) => TrySetX509(e, "x509.public_key_algorithm", v),
				"TlsX509PublicKeyAlgorithm" => static (e, v) => TrySetX509(e, "x509.public_key_algorithm", v),
				"tls.x509.public_key_curve" => static (e, v) => TrySetX509(e, "x509.public_key_curve", v),
				"TlsX509PublicKeyCurve" => static (e, v) => TrySetX509(e, "x509.public_key_curve", v),
				"tls.x509.public_key_exponent" => static (e, v) => TrySetX509(e, "x509.public_key_exponent", v),
				"TlsX509PublicKeyExponent" => static (e, v) => TrySetX509(e, "x509.public_key_exponent", v),
				"tls.x509.public_key_size" => static (e, v) => TrySetX509(e, "x509.public_key_size", v),
				"TlsX509PublicKeySize" => static (e, v) => TrySetX509(e, "x509.public_key_size", v),
				"tls.x509.serial_number" => static (e, v) => TrySetX509(e, "x509.serial_number", v),
				"TlsX509SerialNumber" => static (e, v) => TrySetX509(e, "x509.serial_number", v),
				"tls.x509.signature_algorithm" => static (e, v) => TrySetX509(e, "x509.signature_algorithm", v),
				"TlsX509SignatureAlgorithm" => static (e, v) => TrySetX509(e, "x509.signature_algorithm", v),
				"tls.x509.subject.distinguished_name" => static (e, v) => TrySetX509(e, "x509.subject.distinguished_name", v),
				"TlsX509SubjectDistinguishedName" => static (e, v) => TrySetX509(e, "x509.subject.distinguished_name", v),
				"tls.x509.version_number" => static (e, v) => TrySetX509(e, "x509.version_number", v),
				"TlsX509VersionNumber" => static (e, v) => TrySetX509(e, "x509.version_number", v),
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
				"user_agent.os.family" => static (e, v) => TrySetOs(e, "os.family", v),
				"UserAgentOsFamily" => static (e, v) => TrySetOs(e, "os.family", v),
				"user_agent.os.full" => static (e, v) => TrySetOs(e, "os.full", v),
				"UserAgentOsFull" => static (e, v) => TrySetOs(e, "os.full", v),
				"user_agent.os.kernel" => static (e, v) => TrySetOs(e, "os.kernel", v),
				"UserAgentOsKernel" => static (e, v) => TrySetOs(e, "os.kernel", v),
				"user_agent.os.name" => static (e, v) => TrySetOs(e, "os.name", v),
				"UserAgentOsName" => static (e, v) => TrySetOs(e, "os.name", v),
				"user_agent.os.platform" => static (e, v) => TrySetOs(e, "os.platform", v),
				"UserAgentOsPlatform" => static (e, v) => TrySetOs(e, "os.platform", v),
				"user_agent.os.type" => static (e, v) => TrySetOs(e, "os.type", v),
				"UserAgentOsType" => static (e, v) => TrySetOs(e, "os.type", v),
				"user_agent.os.version" => static (e, v) => TrySetOs(e, "os.version", v),
				"UserAgentOsVersion" => static (e, v) => TrySetOs(e, "os.version", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.UserAgent ?? new UserAgent();
			var assigned = assign(entity, value);
			if (assigned) document.UserAgent = entity;
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

		public static bool TrySetAs(IAs document, string path, object value)
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

		public static bool TrySetGeo(IGeo document, string path, object value)
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

		public static bool TrySetUser(IUser document, string path, object value)
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
				"user.group.domain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"UserGroupDomain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"user.group.id" => static (e, v) => TrySetGroup(e, "group.id", v),
				"UserGroupId" => static (e, v) => TrySetGroup(e, "group.id", v),
				"user.group.name" => static (e, v) => TrySetGroup(e, "group.name", v),
				"UserGroupName" => static (e, v) => TrySetGroup(e, "group.name", v),
				"user.risk.calculated_level" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"UserRiskCalculatedLevel" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"user.risk.calculated_score" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"UserRiskCalculatedScore" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"user.risk.calculated_score_norm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"UserRiskCalculatedScoreNorm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"user.risk.static_level" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"UserRiskStaticLevel" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"user.risk.static_score" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"UserRiskStaticScore" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"user.risk.static_score_norm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
				"UserRiskStaticScoreNorm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
				"user.user.domain" => static (e, v) => TrySetUserTarget(e, "user.domain", v),
				"UserUserDomain" => static (e, v) => TrySetUserTarget(e, "user.domain", v),
				"user.user.email" => static (e, v) => TrySetUserTarget(e, "user.email", v),
				"UserUserEmail" => static (e, v) => TrySetUserTarget(e, "user.email", v),
				"user.user.full_name" => static (e, v) => TrySetUserTarget(e, "user.full_name", v),
				"UserUserFullName" => static (e, v) => TrySetUserTarget(e, "user.full_name", v),
				"user.user.hash" => static (e, v) => TrySetUserTarget(e, "user.hash", v),
				"UserUserHash" => static (e, v) => TrySetUserTarget(e, "user.hash", v),
				"user.user.id" => static (e, v) => TrySetUserTarget(e, "user.id", v),
				"UserUserId" => static (e, v) => TrySetUserTarget(e, "user.id", v),
				"user.user.name" => static (e, v) => TrySetUserTarget(e, "user.name", v),
				"UserUserName" => static (e, v) => TrySetUserTarget(e, "user.name", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.User ?? new User();
			var assigned = assign(entity, value);
			if (assigned) document.User = entity;
			return assigned;
		}

		public static bool TrySetOrigin(IOrigin document, string path, object value)
		{
			Func<CloudOrigin, object, bool> assign = path switch
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

			var entity = document.Origin ?? new CloudOrigin();
			var assigned = assign(entity, value);
			if (assigned) document.Origin = entity;
			return assigned;
		}

		public static bool TrySetTarget(ITarget document, string path, object value)
		{
			Func<CloudTarget, object, bool> assign = path switch
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

			var entity = document.Target ?? new CloudTarget();
			var assigned = assign(entity, value);
			if (assigned) document.Target = entity;
			return assigned;
		}

		public static bool TrySetHash(IHash document, string path, object value)
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

		public static bool TrySetPe(IPe document, string path, object value)
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
				"pe.go_import_hash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImportHash = p),
				"PeGoImportHash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImportHash = p),
				"pe.go_imports" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImports = p),
				"PeGoImports" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImports = p),
				"pe.go_imports_names_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesEntropy = p),
				"PeGoImportsNamesEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesEntropy = p),
				"pe.go_imports_names_var_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesVarEntropy = p),
				"PeGoImportsNamesVarEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesVarEntropy = p),
				"pe.go_stripped" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.GoStripped = p),
				"PeGoStripped" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.GoStripped = p),
				"pe.imphash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Imphash = p),
				"PeImphash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Imphash = p),
				"pe.import_hash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ImportHash = p),
				"PeImportHash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ImportHash = p),
				"pe.imports_names_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesEntropy = p),
				"PeImportsNamesEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesEntropy = p),
				"pe.imports_names_var_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesVarEntropy = p),
				"PeImportsNamesVarEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesVarEntropy = p),
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

		public static bool TrySetCodeSignature(ICodeSignature document, string path, object value)
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

		public static bool TrySetX509(IX509 document, string path, object value)
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

		public static bool TrySetElf(IElf document, string path, object value)
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
				"elf.go_import_hash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImportHash = p),
				"ElfGoImportHash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImportHash = p),
				"elf.go_imports" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImports = p),
				"ElfGoImports" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImports = p),
				"elf.go_imports_names_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesEntropy = p),
				"ElfGoImportsNamesEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesEntropy = p),
				"elf.go_imports_names_var_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesVarEntropy = p),
				"ElfGoImportsNamesVarEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesVarEntropy = p),
				"elf.go_stripped" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.GoStripped = p),
				"ElfGoStripped" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.GoStripped = p),
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
				"elf.import_hash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ImportHash = p),
				"ElfImportHash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ImportHash = p),
				"elf.imports_names_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesEntropy = p),
				"ElfImportsNamesEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesEntropy = p),
				"elf.imports_names_var_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesVarEntropy = p),
				"ElfImportsNamesVarEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesVarEntropy = p),
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

		public static bool TrySetMacho(IMacho document, string path, object value)
		{
			Func<Macho, object, bool> assign = path switch
			{
				"macho.go_import_hash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImportHash = p),
				"MachoGoImportHash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImportHash = p),
				"macho.go_imports" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImports = p),
				"MachoGoImports" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.GoImports = p),
				"macho.go_imports_names_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesEntropy = p),
				"MachoGoImportsNamesEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesEntropy = p),
				"macho.go_imports_names_var_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesVarEntropy = p),
				"MachoGoImportsNamesVarEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.GoImportsNamesVarEntropy = p),
				"macho.go_stripped" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.GoStripped = p),
				"MachoGoStripped" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.GoStripped = p),
				"macho.import_hash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ImportHash = p),
				"MachoImportHash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ImportHash = p),
				"macho.imports_names_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesEntropy = p),
				"MachoImportsNamesEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesEntropy = p),
				"macho.imports_names_var_entropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesVarEntropy = p),
				"MachoImportsNamesVarEntropy" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.ImportsNamesVarEntropy = p),
				"macho.symhash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Symhash = p),
				"MachoSymhash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Symhash = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Macho ?? new Macho();
			var assigned = assign(entity, value);
			if (assigned) document.Macho = entity;
			return assigned;
		}

		public static bool TrySetOs(IOs document, string path, object value)
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

		public static bool TrySetRisk(IRisk document, string path, object value)
		{
			Func<Risk, object, bool> assign = path switch
			{
				"risk.calculated_level" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CalculatedLevel = p),
				"RiskCalculatedLevel" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.CalculatedLevel = p),
				"risk.calculated_score" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.CalculatedScore = p),
				"RiskCalculatedScore" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.CalculatedScore = p),
				"risk.calculated_score_norm" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.CalculatedScoreNorm = p),
				"RiskCalculatedScoreNorm" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.CalculatedScoreNorm = p),
				"risk.static_level" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.StaticLevel = p),
				"RiskStaticLevel" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.StaticLevel = p),
				"risk.static_score" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.StaticScore = p),
				"RiskStaticScore" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.StaticScore = p),
				"risk.static_score_norm" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.StaticScoreNorm = p),
				"RiskStaticScoreNorm" => static (e, v) => TrySetFloat(e, v, static (ee, p) => ee.StaticScoreNorm = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Risk ?? new Risk();
			var assigned = assign(entity, value);
			if (assigned) document.Risk = entity;
			return assigned;
		}

		public static bool TrySetVlan(IVlan document, string path, object value)
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

		public static bool TrySetGroup(IGroup document, string path, object value)
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

		public static bool TrySetRealGroup(IRealGroup document, string path, object value)
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

			var entity = document.RealGroup ?? new Group();
			var assigned = assign(entity, value);
			if (assigned) document.RealGroup = entity;
			return assigned;
		}

		public static bool TrySetSavedGroup(ISavedGroup document, string path, object value)
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

			var entity = document.SavedGroup ?? new Group();
			var assigned = assign(entity, value);
			if (assigned) document.SavedGroup = entity;
			return assigned;
		}

		public static bool TrySetSupplementalGroups(ISupplementalGroups document, string path, object value)
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

			var entity = document.SupplementalGroups ?? new Group();
			var assigned = assign(entity, value);
			if (assigned) document.SupplementalGroups = entity;
			return assigned;
		}

		public static bool TrySetAttestedGroups(IAttestedGroups document, string path, object value)
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

			var entity = document.AttestedGroups ?? new Group();
			var assigned = assign(entity, value);
			if (assigned) document.AttestedGroups = entity;
			return assigned;
		}

		public static bool TrySetEntryMetaSource(IEntryMetaSource document, string path, object value)
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
				"source.as.number" => static (e, v) => TrySetAs(e, "as.number", v),
				"SourceAsNumber" => static (e, v) => TrySetAs(e, "as.number", v),
				"source.as.organization.name" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"SourceAsOrganizationName" => static (e, v) => TrySetAs(e, "as.organization.name", v),
				"source.geo.city_name" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"SourceGeoCityName" => static (e, v) => TrySetGeo(e, "geo.city_name", v),
				"source.geo.continent_code" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"SourceGeoContinentCode" => static (e, v) => TrySetGeo(e, "geo.continent_code", v),
				"source.geo.continent_name" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"SourceGeoContinentName" => static (e, v) => TrySetGeo(e, "geo.continent_name", v),
				"source.geo.country_iso_code" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"SourceGeoCountryIsoCode" => static (e, v) => TrySetGeo(e, "geo.country_iso_code", v),
				"source.geo.country_name" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"SourceGeoCountryName" => static (e, v) => TrySetGeo(e, "geo.country_name", v),
				"source.geo.name" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"SourceGeoName" => static (e, v) => TrySetGeo(e, "geo.name", v),
				"source.geo.postal_code" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"SourceGeoPostalCode" => static (e, v) => TrySetGeo(e, "geo.postal_code", v),
				"source.geo.region_iso_code" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"SourceGeoRegionIsoCode" => static (e, v) => TrySetGeo(e, "geo.region_iso_code", v),
				"source.geo.region_name" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"SourceGeoRegionName" => static (e, v) => TrySetGeo(e, "geo.region_name", v),
				"source.geo.timezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"SourceGeoTimezone" => static (e, v) => TrySetGeo(e, "geo.timezone", v),
				"source.user.domain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"SourceUserDomain" => static (e, v) => TrySetUser(e, "user.domain", v),
				"source.user.email" => static (e, v) => TrySetUser(e, "user.email", v),
				"SourceUserEmail" => static (e, v) => TrySetUser(e, "user.email", v),
				"source.user.full_name" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"SourceUserFullName" => static (e, v) => TrySetUser(e, "user.full_name", v),
				"source.user.hash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"SourceUserHash" => static (e, v) => TrySetUser(e, "user.hash", v),
				"source.user.id" => static (e, v) => TrySetUser(e, "user.id", v),
				"SourceUserId" => static (e, v) => TrySetUser(e, "user.id", v),
				"source.user.name" => static (e, v) => TrySetUser(e, "user.name", v),
				"SourceUserName" => static (e, v) => TrySetUser(e, "user.name", v),
				"source.user.group.domain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"SourceUserGroupDomain" => static (e, v) => TrySetUser(e, "user.group.domain", v),
				"source.user.group.id" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"SourceUserGroupId" => static (e, v) => TrySetUser(e, "user.group.id", v),
				"source.user.group.name" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"SourceUserGroupName" => static (e, v) => TrySetUser(e, "user.group.name", v),
				"source.user.risk.calculated_level" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"SourceUserRiskCalculatedLevel" => static (e, v) => TrySetUser(e, "user.risk.calculated_level", v),
				"source.user.risk.calculated_score" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"SourceUserRiskCalculatedScore" => static (e, v) => TrySetUser(e, "user.risk.calculated_score", v),
				"source.user.risk.calculated_score_norm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"SourceUserRiskCalculatedScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.calculated_score_norm", v),
				"source.user.risk.static_level" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"SourceUserRiskStaticLevel" => static (e, v) => TrySetUser(e, "user.risk.static_level", v),
				"source.user.risk.static_score" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"SourceUserRiskStaticScore" => static (e, v) => TrySetUser(e, "user.risk.static_score", v),
				"source.user.risk.static_score_norm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"SourceUserRiskStaticScoreNorm" => static (e, v) => TrySetUser(e, "user.risk.static_score_norm", v),
				"source.user.user.domain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"SourceUserUserDomain" => static (e, v) => TrySetUser(e, "user.user.domain", v),
				"source.user.user.email" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"SourceUserUserEmail" => static (e, v) => TrySetUser(e, "user.user.email", v),
				"source.user.user.full_name" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"SourceUserUserFullName" => static (e, v) => TrySetUser(e, "user.user.full_name", v),
				"source.user.user.hash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"SourceUserUserHash" => static (e, v) => TrySetUser(e, "user.user.hash", v),
				"source.user.user.id" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"SourceUserUserId" => static (e, v) => TrySetUser(e, "user.user.id", v),
				"source.user.user.name" => static (e, v) => TrySetUser(e, "user.user.name", v),
				"SourceUserUserName" => static (e, v) => TrySetUser(e, "user.user.name", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.EntryMetaSource ?? new Source();
			var assigned = assign(entity, value);
			if (assigned) document.EntryMetaSource = entity;
			return assigned;
		}

		public static bool TrySetSavedUser(ISavedUser document, string path, object value)
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
				"user.group.domain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"UserGroupDomain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"user.group.id" => static (e, v) => TrySetGroup(e, "group.id", v),
				"UserGroupId" => static (e, v) => TrySetGroup(e, "group.id", v),
				"user.group.name" => static (e, v) => TrySetGroup(e, "group.name", v),
				"UserGroupName" => static (e, v) => TrySetGroup(e, "group.name", v),
				"user.risk.calculated_level" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"UserRiskCalculatedLevel" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"user.risk.calculated_score" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"UserRiskCalculatedScore" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"user.risk.calculated_score_norm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"UserRiskCalculatedScoreNorm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"user.risk.static_level" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"UserRiskStaticLevel" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"user.risk.static_score" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"UserRiskStaticScore" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"user.risk.static_score_norm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
				"UserRiskStaticScoreNorm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
				"user.user.domain" => static (e, v) => TrySetUserTarget(e, "user.domain", v),
				"UserUserDomain" => static (e, v) => TrySetUserTarget(e, "user.domain", v),
				"user.user.email" => static (e, v) => TrySetUserTarget(e, "user.email", v),
				"UserUserEmail" => static (e, v) => TrySetUserTarget(e, "user.email", v),
				"user.user.full_name" => static (e, v) => TrySetUserTarget(e, "user.full_name", v),
				"UserUserFullName" => static (e, v) => TrySetUserTarget(e, "user.full_name", v),
				"user.user.hash" => static (e, v) => TrySetUserTarget(e, "user.hash", v),
				"UserUserHash" => static (e, v) => TrySetUserTarget(e, "user.hash", v),
				"user.user.id" => static (e, v) => TrySetUserTarget(e, "user.id", v),
				"UserUserId" => static (e, v) => TrySetUserTarget(e, "user.id", v),
				"user.user.name" => static (e, v) => TrySetUserTarget(e, "user.name", v),
				"UserUserName" => static (e, v) => TrySetUserTarget(e, "user.name", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.SavedUser ?? new User();
			var assigned = assign(entity, value);
			if (assigned) document.SavedUser = entity;
			return assigned;
		}

		public static bool TrySetRealUser(IRealUser document, string path, object value)
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
				"user.group.domain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"UserGroupDomain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"user.group.id" => static (e, v) => TrySetGroup(e, "group.id", v),
				"UserGroupId" => static (e, v) => TrySetGroup(e, "group.id", v),
				"user.group.name" => static (e, v) => TrySetGroup(e, "group.name", v),
				"UserGroupName" => static (e, v) => TrySetGroup(e, "group.name", v),
				"user.risk.calculated_level" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"UserRiskCalculatedLevel" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"user.risk.calculated_score" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"UserRiskCalculatedScore" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"user.risk.calculated_score_norm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"UserRiskCalculatedScoreNorm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"user.risk.static_level" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"UserRiskStaticLevel" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"user.risk.static_score" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"UserRiskStaticScore" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"user.risk.static_score_norm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
				"UserRiskStaticScoreNorm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
				"user.user.domain" => static (e, v) => TrySetUserTarget(e, "user.domain", v),
				"UserUserDomain" => static (e, v) => TrySetUserTarget(e, "user.domain", v),
				"user.user.email" => static (e, v) => TrySetUserTarget(e, "user.email", v),
				"UserUserEmail" => static (e, v) => TrySetUserTarget(e, "user.email", v),
				"user.user.full_name" => static (e, v) => TrySetUserTarget(e, "user.full_name", v),
				"UserUserFullName" => static (e, v) => TrySetUserTarget(e, "user.full_name", v),
				"user.user.hash" => static (e, v) => TrySetUserTarget(e, "user.hash", v),
				"UserUserHash" => static (e, v) => TrySetUserTarget(e, "user.hash", v),
				"user.user.id" => static (e, v) => TrySetUserTarget(e, "user.id", v),
				"UserUserId" => static (e, v) => TrySetUserTarget(e, "user.id", v),
				"user.user.name" => static (e, v) => TrySetUserTarget(e, "user.name", v),
				"UserUserName" => static (e, v) => TrySetUserTarget(e, "user.name", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.RealUser ?? new User();
			var assigned = assign(entity, value);
			if (assigned) document.RealUser = entity;
			return assigned;
		}

		public static bool TrySetAttestedUser(IAttestedUser document, string path, object value)
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
				"user.group.domain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"UserGroupDomain" => static (e, v) => TrySetGroup(e, "group.domain", v),
				"user.group.id" => static (e, v) => TrySetGroup(e, "group.id", v),
				"UserGroupId" => static (e, v) => TrySetGroup(e, "group.id", v),
				"user.group.name" => static (e, v) => TrySetGroup(e, "group.name", v),
				"UserGroupName" => static (e, v) => TrySetGroup(e, "group.name", v),
				"user.risk.calculated_level" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"UserRiskCalculatedLevel" => static (e, v) => TrySetRisk(e, "risk.calculated_level", v),
				"user.risk.calculated_score" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"UserRiskCalculatedScore" => static (e, v) => TrySetRisk(e, "risk.calculated_score", v),
				"user.risk.calculated_score_norm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"UserRiskCalculatedScoreNorm" => static (e, v) => TrySetRisk(e, "risk.calculated_score_norm", v),
				"user.risk.static_level" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"UserRiskStaticLevel" => static (e, v) => TrySetRisk(e, "risk.static_level", v),
				"user.risk.static_score" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"UserRiskStaticScore" => static (e, v) => TrySetRisk(e, "risk.static_score", v),
				"user.risk.static_score_norm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
				"UserRiskStaticScoreNorm" => static (e, v) => TrySetRisk(e, "risk.static_score_norm", v),
				"user.user.domain" => static (e, v) => TrySetUserTarget(e, "user.domain", v),
				"UserUserDomain" => static (e, v) => TrySetUserTarget(e, "user.domain", v),
				"user.user.email" => static (e, v) => TrySetUserTarget(e, "user.email", v),
				"UserUserEmail" => static (e, v) => TrySetUserTarget(e, "user.email", v),
				"user.user.full_name" => static (e, v) => TrySetUserTarget(e, "user.full_name", v),
				"UserUserFullName" => static (e, v) => TrySetUserTarget(e, "user.full_name", v),
				"user.user.hash" => static (e, v) => TrySetUserTarget(e, "user.hash", v),
				"UserUserHash" => static (e, v) => TrySetUserTarget(e, "user.hash", v),
				"user.user.id" => static (e, v) => TrySetUserTarget(e, "user.id", v),
				"UserUserId" => static (e, v) => TrySetUserTarget(e, "user.id", v),
				"user.user.name" => static (e, v) => TrySetUserTarget(e, "user.name", v),
				"UserUserName" => static (e, v) => TrySetUserTarget(e, "user.name", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.AttestedUser ?? new User();
			var assigned = assign(entity, value);
			if (assigned) document.AttestedUser = entity;
			return assigned;
		}

		public static bool TrySetParent(IParent document, string path, object value)
		{
			Func<ProcessParent, object, bool> assign = path switch
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
				"process.vpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"ProcessVpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"process.working_directory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"ProcessWorkingDirectory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"process.parent.process.args_count" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.args_count", v),
				"ProcessParentProcessArgsCount" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.args_count", v),
				"process.parent.process.command_line" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.command_line", v),
				"ProcessParentProcessCommandLine" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.command_line", v),
				"process.parent.process.end" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.end", v),
				"ProcessParentProcessEnd" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.end", v),
				"process.parent.process.entity_id" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.entity_id", v),
				"ProcessParentProcessEntityId" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.entity_id", v),
				"process.parent.process.executable" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.executable", v),
				"ProcessParentProcessExecutable" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.executable", v),
				"process.parent.process.exit_code" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.exit_code", v),
				"ProcessParentProcessExitCode" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.exit_code", v),
				"process.parent.process.interactive" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.interactive", v),
				"ProcessParentProcessInteractive" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.interactive", v),
				"process.parent.process.name" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.name", v),
				"ProcessParentProcessName" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.name", v),
				"process.parent.process.pgid" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.pgid", v),
				"ProcessParentProcessPgid" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.pgid", v),
				"process.parent.process.pid" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.pid", v),
				"ProcessParentProcessPid" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.pid", v),
				"process.parent.process.start" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.start", v),
				"ProcessParentProcessStart" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.start", v),
				"process.parent.process.thread.id" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.thread.id", v),
				"ProcessParentProcessThreadId" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.thread.id", v),
				"process.parent.process.thread.name" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.thread.name", v),
				"ProcessParentProcessThreadName" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.thread.name", v),
				"process.parent.process.title" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.title", v),
				"ProcessParentProcessTitle" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.title", v),
				"process.parent.process.uptime" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.uptime", v),
				"ProcessParentProcessUptime" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.uptime", v),
				"process.parent.process.vpid" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.vpid", v),
				"ProcessParentProcessVpid" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.vpid", v),
				"process.parent.process.working_directory" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.working_directory", v),
				"ProcessParentProcessWorkingDirectory" => static (e, v) => TrySetProcessParentGroupLeader(e, "process.working_directory", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Parent ?? new ProcessParent();
			var assigned = assign(entity, value);
			if (assigned) document.Parent = entity;
			return assigned;
		}

		public static bool TrySetEntryLeader(IEntryLeader document, string path, object value)
		{
			Func<ProcessEntryLeader, object, bool> assign = path switch
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
				"process.vpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"ProcessVpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"process.working_directory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"ProcessWorkingDirectory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"process.entry_leader.process.args_count" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.args_count", v),
				"ProcessEntryLeaderProcessArgsCount" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.args_count", v),
				"process.entry_leader.process.command_line" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.command_line", v),
				"ProcessEntryLeaderProcessCommandLine" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.command_line", v),
				"process.entry_leader.process.end" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.end", v),
				"ProcessEntryLeaderProcessEnd" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.end", v),
				"process.entry_leader.process.entity_id" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entity_id", v),
				"ProcessEntryLeaderProcessEntityId" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entity_id", v),
				"process.entry_leader.process.executable" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.executable", v),
				"ProcessEntryLeaderProcessExecutable" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.executable", v),
				"process.entry_leader.process.exit_code" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.exit_code", v),
				"ProcessEntryLeaderProcessExitCode" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.exit_code", v),
				"process.entry_leader.process.interactive" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.interactive", v),
				"ProcessEntryLeaderProcessInteractive" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.interactive", v),
				"process.entry_leader.process.name" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.name", v),
				"ProcessEntryLeaderProcessName" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.name", v),
				"process.entry_leader.process.pgid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.pgid", v),
				"ProcessEntryLeaderProcessPgid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.pgid", v),
				"process.entry_leader.process.pid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.pid", v),
				"ProcessEntryLeaderProcessPid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.pid", v),
				"process.entry_leader.process.start" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.start", v),
				"ProcessEntryLeaderProcessStart" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.start", v),
				"process.entry_leader.process.thread.id" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.thread.id", v),
				"ProcessEntryLeaderProcessThreadId" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.thread.id", v),
				"process.entry_leader.process.thread.name" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.thread.name", v),
				"ProcessEntryLeaderProcessThreadName" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.thread.name", v),
				"process.entry_leader.process.title" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.title", v),
				"ProcessEntryLeaderProcessTitle" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.title", v),
				"process.entry_leader.process.uptime" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.uptime", v),
				"ProcessEntryLeaderProcessUptime" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.uptime", v),
				"process.entry_leader.process.vpid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.vpid", v),
				"ProcessEntryLeaderProcessVpid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.vpid", v),
				"process.entry_leader.process.working_directory" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.working_directory", v),
				"ProcessEntryLeaderProcessWorkingDirectory" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.working_directory", v),
				"process.entry_leader.process.entry_leader.parent.process.args_count" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.args_count", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessArgsCount" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.args_count", v),
				"process.entry_leader.process.entry_leader.parent.process.command_line" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.command_line", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessCommandLine" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.command_line", v),
				"process.entry_leader.process.entry_leader.parent.process.end" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.end", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessEnd" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.end", v),
				"process.entry_leader.process.entry_leader.parent.process.entity_id" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.entity_id", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessEntityId" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.entity_id", v),
				"process.entry_leader.process.entry_leader.parent.process.executable" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.executable", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessExecutable" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.executable", v),
				"process.entry_leader.process.entry_leader.parent.process.exit_code" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.exit_code", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessExitCode" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.exit_code", v),
				"process.entry_leader.process.entry_leader.parent.process.interactive" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.interactive", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessInteractive" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.interactive", v),
				"process.entry_leader.process.entry_leader.parent.process.name" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.name", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessName" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.name", v),
				"process.entry_leader.process.entry_leader.parent.process.pgid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.pgid", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessPgid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.pgid", v),
				"process.entry_leader.process.entry_leader.parent.process.pid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.pid", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessPid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.pid", v),
				"process.entry_leader.process.entry_leader.parent.process.start" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.start", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessStart" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.start", v),
				"process.entry_leader.process.entry_leader.parent.process.thread.id" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.thread.id", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessThreadId" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.thread.id", v),
				"process.entry_leader.process.entry_leader.parent.process.thread.name" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.thread.name", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessThreadName" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.thread.name", v),
				"process.entry_leader.process.entry_leader.parent.process.title" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.title", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessTitle" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.title", v),
				"process.entry_leader.process.entry_leader.parent.process.uptime" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.uptime", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessUptime" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.uptime", v),
				"process.entry_leader.process.entry_leader.parent.process.vpid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.vpid", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessVpid" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.vpid", v),
				"process.entry_leader.process.entry_leader.parent.process.working_directory" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.working_directory", v),
				"ProcessEntryLeaderProcessEntryLeaderParentProcessWorkingDirectory" => static (e, v) => TrySetProcessEntryLeaderParent(e, "process.entry_leader.parent.process.working_directory", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.EntryLeader ?? new ProcessEntryLeader();
			var assigned = assign(entity, value);
			if (assigned) document.EntryLeader = entity;
			return assigned;
		}

		public static bool TrySetSessionLeader(ISessionLeader document, string path, object value)
		{
			Func<ProcessSessionLeader, object, bool> assign = path switch
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
				"process.vpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"ProcessVpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"process.working_directory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"ProcessWorkingDirectory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"process.session_leader.process.args_count" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.args_count", v),
				"ProcessSessionLeaderProcessArgsCount" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.args_count", v),
				"process.session_leader.process.command_line" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.command_line", v),
				"ProcessSessionLeaderProcessCommandLine" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.command_line", v),
				"process.session_leader.process.end" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.end", v),
				"ProcessSessionLeaderProcessEnd" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.end", v),
				"process.session_leader.process.entity_id" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.entity_id", v),
				"ProcessSessionLeaderProcessEntityId" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.entity_id", v),
				"process.session_leader.process.executable" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.executable", v),
				"ProcessSessionLeaderProcessExecutable" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.executable", v),
				"process.session_leader.process.exit_code" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.exit_code", v),
				"ProcessSessionLeaderProcessExitCode" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.exit_code", v),
				"process.session_leader.process.interactive" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.interactive", v),
				"ProcessSessionLeaderProcessInteractive" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.interactive", v),
				"process.session_leader.process.name" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.name", v),
				"ProcessSessionLeaderProcessName" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.name", v),
				"process.session_leader.process.pgid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.pgid", v),
				"ProcessSessionLeaderProcessPgid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.pgid", v),
				"process.session_leader.process.pid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.pid", v),
				"ProcessSessionLeaderProcessPid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.pid", v),
				"process.session_leader.process.start" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.start", v),
				"ProcessSessionLeaderProcessStart" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.start", v),
				"process.session_leader.process.thread.id" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.thread.id", v),
				"ProcessSessionLeaderProcessThreadId" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.thread.id", v),
				"process.session_leader.process.thread.name" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.thread.name", v),
				"ProcessSessionLeaderProcessThreadName" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.thread.name", v),
				"process.session_leader.process.title" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.title", v),
				"ProcessSessionLeaderProcessTitle" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.title", v),
				"process.session_leader.process.uptime" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.uptime", v),
				"ProcessSessionLeaderProcessUptime" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.uptime", v),
				"process.session_leader.process.vpid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.vpid", v),
				"ProcessSessionLeaderProcessVpid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.vpid", v),
				"process.session_leader.process.working_directory" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.working_directory", v),
				"ProcessSessionLeaderProcessWorkingDirectory" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.working_directory", v),
				"process.session_leader.process.session_leader.parent.process.args_count" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.args_count", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessArgsCount" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.args_count", v),
				"process.session_leader.process.session_leader.parent.process.command_line" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.command_line", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessCommandLine" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.command_line", v),
				"process.session_leader.process.session_leader.parent.process.end" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.end", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessEnd" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.end", v),
				"process.session_leader.process.session_leader.parent.process.entity_id" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.entity_id", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessEntityId" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.entity_id", v),
				"process.session_leader.process.session_leader.parent.process.executable" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.executable", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessExecutable" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.executable", v),
				"process.session_leader.process.session_leader.parent.process.exit_code" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.exit_code", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessExitCode" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.exit_code", v),
				"process.session_leader.process.session_leader.parent.process.interactive" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.interactive", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessInteractive" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.interactive", v),
				"process.session_leader.process.session_leader.parent.process.name" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.name", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessName" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.name", v),
				"process.session_leader.process.session_leader.parent.process.pgid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.pgid", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessPgid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.pgid", v),
				"process.session_leader.process.session_leader.parent.process.pid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.pid", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessPid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.pid", v),
				"process.session_leader.process.session_leader.parent.process.start" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.start", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessStart" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.start", v),
				"process.session_leader.process.session_leader.parent.process.thread.id" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.thread.id", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessThreadId" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.thread.id", v),
				"process.session_leader.process.session_leader.parent.process.thread.name" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.thread.name", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessThreadName" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.thread.name", v),
				"process.session_leader.process.session_leader.parent.process.title" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.title", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessTitle" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.title", v),
				"process.session_leader.process.session_leader.parent.process.uptime" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.uptime", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessUptime" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.uptime", v),
				"process.session_leader.process.session_leader.parent.process.vpid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.vpid", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessVpid" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.vpid", v),
				"process.session_leader.process.session_leader.parent.process.working_directory" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.working_directory", v),
				"ProcessSessionLeaderProcessSessionLeaderParentProcessWorkingDirectory" => static (e, v) => TrySetProcessSessionLeaderParent(e, "process.session_leader.parent.process.working_directory", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.SessionLeader ?? new ProcessSessionLeader();
			var assigned = assign(entity, value);
			if (assigned) document.SessionLeader = entity;
			return assigned;
		}

		public static bool TrySetGroupLeader(IGroupLeader document, string path, object value)
		{
			Func<ProcessGroupLeader, object, bool> assign = path switch
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
				"process.vpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"ProcessVpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"process.working_directory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"ProcessWorkingDirectory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.GroupLeader ?? new ProcessGroupLeader();
			var assigned = assign(entity, value);
			if (assigned) document.GroupLeader = entity;
			return assigned;
		}

		public static bool TrySetPrevious(IPrevious document, string path, object value)
		{
			Func<ProcessPrevious, object, bool> assign = path switch
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
				"process.vpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"ProcessVpid" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Vpid = p),
				"process.working_directory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				"ProcessWorkingDirectory" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.WorkingDirectory = p),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.Previous ?? new ProcessPrevious();
			var assigned = assign(entity, value);
			if (assigned) document.Previous = entity;
			return assigned;
		}

		public static bool TrySetOrigin(IOrigin document, string path, object value)
		{
			Func<ServiceOrigin, object, bool> assign = path switch
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

			var entity = document.Origin ?? new ServiceOrigin();
			var assigned = assign(entity, value);
			if (assigned) document.Origin = entity;
			return assigned;
		}

		public static bool TrySetTarget(ITarget document, string path, object value)
		{
			Func<ServiceTarget, object, bool> assign = path switch
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

			var entity = document.Target ?? new ServiceTarget();
			var assigned = assign(entity, value);
			if (assigned) document.Target = entity;
			return assigned;
		}

		public static bool TrySetIndicatorX509(IIndicatorX509 document, string path, object value)
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

			var entity = document.IndicatorX509 ?? new X509();
			var assigned = assign(entity, value);
			if (assigned) document.IndicatorX509 = entity;
			return assigned;
		}

		public static bool TrySetIndicatorAs(IIndicatorAs document, string path, object value)
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

			var entity = document.IndicatorAs ?? new As();
			var assigned = assign(entity, value);
			if (assigned) document.IndicatorAs = entity;
			return assigned;
		}

		public static bool TrySetIndicatorFile(IIndicatorFile document, string path, object value)
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
				"file.hash.md5" => static (e, v) => TrySetHash(e, "hash.md5", v),
				"FileHashMd5" => static (e, v) => TrySetHash(e, "hash.md5", v),
				"file.hash.sha1" => static (e, v) => TrySetHash(e, "hash.sha1", v),
				"FileHashSha1" => static (e, v) => TrySetHash(e, "hash.sha1", v),
				"file.hash.sha256" => static (e, v) => TrySetHash(e, "hash.sha256", v),
				"FileHashSha256" => static (e, v) => TrySetHash(e, "hash.sha256", v),
				"file.hash.sha384" => static (e, v) => TrySetHash(e, "hash.sha384", v),
				"FileHashSha384" => static (e, v) => TrySetHash(e, "hash.sha384", v),
				"file.hash.sha512" => static (e, v) => TrySetHash(e, "hash.sha512", v),
				"FileHashSha512" => static (e, v) => TrySetHash(e, "hash.sha512", v),
				"file.hash.ssdeep" => static (e, v) => TrySetHash(e, "hash.ssdeep", v),
				"FileHashSsdeep" => static (e, v) => TrySetHash(e, "hash.ssdeep", v),
				"file.hash.tlsh" => static (e, v) => TrySetHash(e, "hash.tlsh", v),
				"FileHashTlsh" => static (e, v) => TrySetHash(e, "hash.tlsh", v),
				"file.pe.architecture" => static (e, v) => TrySetPe(e, "pe.architecture", v),
				"FilePeArchitecture" => static (e, v) => TrySetPe(e, "pe.architecture", v),
				"file.pe.company" => static (e, v) => TrySetPe(e, "pe.company", v),
				"FilePeCompany" => static (e, v) => TrySetPe(e, "pe.company", v),
				"file.pe.description" => static (e, v) => TrySetPe(e, "pe.description", v),
				"FilePeDescription" => static (e, v) => TrySetPe(e, "pe.description", v),
				"file.pe.file_version" => static (e, v) => TrySetPe(e, "pe.file_version", v),
				"FilePeFileVersion" => static (e, v) => TrySetPe(e, "pe.file_version", v),
				"file.pe.go_import_hash" => static (e, v) => TrySetPe(e, "pe.go_import_hash", v),
				"FilePeGoImportHash" => static (e, v) => TrySetPe(e, "pe.go_import_hash", v),
				"file.pe.go_imports" => static (e, v) => TrySetPe(e, "pe.go_imports", v),
				"FilePeGoImports" => static (e, v) => TrySetPe(e, "pe.go_imports", v),
				"file.pe.go_imports_names_entropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_entropy", v),
				"FilePeGoImportsNamesEntropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_entropy", v),
				"file.pe.go_imports_names_var_entropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_var_entropy", v),
				"FilePeGoImportsNamesVarEntropy" => static (e, v) => TrySetPe(e, "pe.go_imports_names_var_entropy", v),
				"file.pe.go_stripped" => static (e, v) => TrySetPe(e, "pe.go_stripped", v),
				"FilePeGoStripped" => static (e, v) => TrySetPe(e, "pe.go_stripped", v),
				"file.pe.imphash" => static (e, v) => TrySetPe(e, "pe.imphash", v),
				"FilePeImphash" => static (e, v) => TrySetPe(e, "pe.imphash", v),
				"file.pe.import_hash" => static (e, v) => TrySetPe(e, "pe.import_hash", v),
				"FilePeImportHash" => static (e, v) => TrySetPe(e, "pe.import_hash", v),
				"file.pe.imports_names_entropy" => static (e, v) => TrySetPe(e, "pe.imports_names_entropy", v),
				"FilePeImportsNamesEntropy" => static (e, v) => TrySetPe(e, "pe.imports_names_entropy", v),
				"file.pe.imports_names_var_entropy" => static (e, v) => TrySetPe(e, "pe.imports_names_var_entropy", v),
				"FilePeImportsNamesVarEntropy" => static (e, v) => TrySetPe(e, "pe.imports_names_var_entropy", v),
				"file.pe.original_file_name" => static (e, v) => TrySetPe(e, "pe.original_file_name", v),
				"FilePeOriginalFileName" => static (e, v) => TrySetPe(e, "pe.original_file_name", v),
				"file.pe.pehash" => static (e, v) => TrySetPe(e, "pe.pehash", v),
				"FilePePehash" => static (e, v) => TrySetPe(e, "pe.pehash", v),
				"file.pe.product" => static (e, v) => TrySetPe(e, "pe.product", v),
				"FilePeProduct" => static (e, v) => TrySetPe(e, "pe.product", v),
				"file.x509.issuer.distinguished_name" => static (e, v) => TrySetX509(e, "x509.issuer.distinguished_name", v),
				"FileX509IssuerDistinguishedName" => static (e, v) => TrySetX509(e, "x509.issuer.distinguished_name", v),
				"file.x509.not_after" => static (e, v) => TrySetX509(e, "x509.not_after", v),
				"FileX509NotAfter" => static (e, v) => TrySetX509(e, "x509.not_after", v),
				"file.x509.not_before" => static (e, v) => TrySetX509(e, "x509.not_before", v),
				"FileX509NotBefore" => static (e, v) => TrySetX509(e, "x509.not_before", v),
				"file.x509.public_key_algorithm" => static (e, v) => TrySetX509(e, "x509.public_key_algorithm", v),
				"FileX509PublicKeyAlgorithm" => static (e, v) => TrySetX509(e, "x509.public_key_algorithm", v),
				"file.x509.public_key_curve" => static (e, v) => TrySetX509(e, "x509.public_key_curve", v),
				"FileX509PublicKeyCurve" => static (e, v) => TrySetX509(e, "x509.public_key_curve", v),
				"file.x509.public_key_exponent" => static (e, v) => TrySetX509(e, "x509.public_key_exponent", v),
				"FileX509PublicKeyExponent" => static (e, v) => TrySetX509(e, "x509.public_key_exponent", v),
				"file.x509.public_key_size" => static (e, v) => TrySetX509(e, "x509.public_key_size", v),
				"FileX509PublicKeySize" => static (e, v) => TrySetX509(e, "x509.public_key_size", v),
				"file.x509.serial_number" => static (e, v) => TrySetX509(e, "x509.serial_number", v),
				"FileX509SerialNumber" => static (e, v) => TrySetX509(e, "x509.serial_number", v),
				"file.x509.signature_algorithm" => static (e, v) => TrySetX509(e, "x509.signature_algorithm", v),
				"FileX509SignatureAlgorithm" => static (e, v) => TrySetX509(e, "x509.signature_algorithm", v),
				"file.x509.subject.distinguished_name" => static (e, v) => TrySetX509(e, "x509.subject.distinguished_name", v),
				"FileX509SubjectDistinguishedName" => static (e, v) => TrySetX509(e, "x509.subject.distinguished_name", v),
				"file.x509.version_number" => static (e, v) => TrySetX509(e, "x509.version_number", v),
				"FileX509VersionNumber" => static (e, v) => TrySetX509(e, "x509.version_number", v),
				"file.code_signature.digest_algorithm" => static (e, v) => TrySetCodeSignature(e, "code_signature.digest_algorithm", v),
				"FileCodeSignatureDigestAlgorithm" => static (e, v) => TrySetCodeSignature(e, "code_signature.digest_algorithm", v),
				"file.code_signature.exists" => static (e, v) => TrySetCodeSignature(e, "code_signature.exists", v),
				"FileCodeSignatureExists" => static (e, v) => TrySetCodeSignature(e, "code_signature.exists", v),
				"file.code_signature.signing_id" => static (e, v) => TrySetCodeSignature(e, "code_signature.signing_id", v),
				"FileCodeSignatureSigningId" => static (e, v) => TrySetCodeSignature(e, "code_signature.signing_id", v),
				"file.code_signature.status" => static (e, v) => TrySetCodeSignature(e, "code_signature.status", v),
				"FileCodeSignatureStatus" => static (e, v) => TrySetCodeSignature(e, "code_signature.status", v),
				"file.code_signature.subject_name" => static (e, v) => TrySetCodeSignature(e, "code_signature.subject_name", v),
				"FileCodeSignatureSubjectName" => static (e, v) => TrySetCodeSignature(e, "code_signature.subject_name", v),
				"file.code_signature.team_id" => static (e, v) => TrySetCodeSignature(e, "code_signature.team_id", v),
				"FileCodeSignatureTeamId" => static (e, v) => TrySetCodeSignature(e, "code_signature.team_id", v),
				"file.code_signature.timestamp" => static (e, v) => TrySetCodeSignature(e, "code_signature.timestamp", v),
				"FileCodeSignatureTimestamp" => static (e, v) => TrySetCodeSignature(e, "code_signature.timestamp", v),
				"file.code_signature.trusted" => static (e, v) => TrySetCodeSignature(e, "code_signature.trusted", v),
				"FileCodeSignatureTrusted" => static (e, v) => TrySetCodeSignature(e, "code_signature.trusted", v),
				"file.code_signature.valid" => static (e, v) => TrySetCodeSignature(e, "code_signature.valid", v),
				"FileCodeSignatureValid" => static (e, v) => TrySetCodeSignature(e, "code_signature.valid", v),
				"file.elf.architecture" => static (e, v) => TrySetElf(e, "elf.architecture", v),
				"FileElfArchitecture" => static (e, v) => TrySetElf(e, "elf.architecture", v),
				"file.elf.byte_order" => static (e, v) => TrySetElf(e, "elf.byte_order", v),
				"FileElfByteOrder" => static (e, v) => TrySetElf(e, "elf.byte_order", v),
				"file.elf.cpu_type" => static (e, v) => TrySetElf(e, "elf.cpu_type", v),
				"FileElfCpuType" => static (e, v) => TrySetElf(e, "elf.cpu_type", v),
				"file.elf.creation_date" => static (e, v) => TrySetElf(e, "elf.creation_date", v),
				"FileElfCreationDate" => static (e, v) => TrySetElf(e, "elf.creation_date", v),
				"file.elf.go_import_hash" => static (e, v) => TrySetElf(e, "elf.go_import_hash", v),
				"FileElfGoImportHash" => static (e, v) => TrySetElf(e, "elf.go_import_hash", v),
				"file.elf.go_imports" => static (e, v) => TrySetElf(e, "elf.go_imports", v),
				"FileElfGoImports" => static (e, v) => TrySetElf(e, "elf.go_imports", v),
				"file.elf.go_imports_names_entropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_entropy", v),
				"FileElfGoImportsNamesEntropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_entropy", v),
				"file.elf.go_imports_names_var_entropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_var_entropy", v),
				"FileElfGoImportsNamesVarEntropy" => static (e, v) => TrySetElf(e, "elf.go_imports_names_var_entropy", v),
				"file.elf.go_stripped" => static (e, v) => TrySetElf(e, "elf.go_stripped", v),
				"FileElfGoStripped" => static (e, v) => TrySetElf(e, "elf.go_stripped", v),
				"file.elf.header.abi_version" => static (e, v) => TrySetElf(e, "elf.header.abi_version", v),
				"FileElfHeaderAbiVersion" => static (e, v) => TrySetElf(e, "elf.header.abi_version", v),
				"file.elf.header.class" => static (e, v) => TrySetElf(e, "elf.header.class", v),
				"FileElfHeaderClass" => static (e, v) => TrySetElf(e, "elf.header.class", v),
				"file.elf.header.data" => static (e, v) => TrySetElf(e, "elf.header.data", v),
				"FileElfHeaderData" => static (e, v) => TrySetElf(e, "elf.header.data", v),
				"file.elf.header.entrypoint" => static (e, v) => TrySetElf(e, "elf.header.entrypoint", v),
				"FileElfHeaderEntrypoint" => static (e, v) => TrySetElf(e, "elf.header.entrypoint", v),
				"file.elf.header.object_version" => static (e, v) => TrySetElf(e, "elf.header.object_version", v),
				"FileElfHeaderObjectVersion" => static (e, v) => TrySetElf(e, "elf.header.object_version", v),
				"file.elf.header.os_abi" => static (e, v) => TrySetElf(e, "elf.header.os_abi", v),
				"FileElfHeaderOsAbi" => static (e, v) => TrySetElf(e, "elf.header.os_abi", v),
				"file.elf.header.type" => static (e, v) => TrySetElf(e, "elf.header.type", v),
				"FileElfHeaderType" => static (e, v) => TrySetElf(e, "elf.header.type", v),
				"file.elf.header.version" => static (e, v) => TrySetElf(e, "elf.header.version", v),
				"FileElfHeaderVersion" => static (e, v) => TrySetElf(e, "elf.header.version", v),
				"file.elf.import_hash" => static (e, v) => TrySetElf(e, "elf.import_hash", v),
				"FileElfImportHash" => static (e, v) => TrySetElf(e, "elf.import_hash", v),
				"file.elf.imports_names_entropy" => static (e, v) => TrySetElf(e, "elf.imports_names_entropy", v),
				"FileElfImportsNamesEntropy" => static (e, v) => TrySetElf(e, "elf.imports_names_entropy", v),
				"file.elf.imports_names_var_entropy" => static (e, v) => TrySetElf(e, "elf.imports_names_var_entropy", v),
				"FileElfImportsNamesVarEntropy" => static (e, v) => TrySetElf(e, "elf.imports_names_var_entropy", v),
				"file.elf.telfhash" => static (e, v) => TrySetElf(e, "elf.telfhash", v),
				"FileElfTelfhash" => static (e, v) => TrySetElf(e, "elf.telfhash", v),
				"file.macho.go_import_hash" => static (e, v) => TrySetMacho(e, "macho.go_import_hash", v),
				"FileMachoGoImportHash" => static (e, v) => TrySetMacho(e, "macho.go_import_hash", v),
				"file.macho.go_imports" => static (e, v) => TrySetMacho(e, "macho.go_imports", v),
				"FileMachoGoImports" => static (e, v) => TrySetMacho(e, "macho.go_imports", v),
				"file.macho.go_imports_names_entropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_entropy", v),
				"FileMachoGoImportsNamesEntropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_entropy", v),
				"file.macho.go_imports_names_var_entropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_var_entropy", v),
				"FileMachoGoImportsNamesVarEntropy" => static (e, v) => TrySetMacho(e, "macho.go_imports_names_var_entropy", v),
				"file.macho.go_stripped" => static (e, v) => TrySetMacho(e, "macho.go_stripped", v),
				"FileMachoGoStripped" => static (e, v) => TrySetMacho(e, "macho.go_stripped", v),
				"file.macho.import_hash" => static (e, v) => TrySetMacho(e, "macho.import_hash", v),
				"FileMachoImportHash" => static (e, v) => TrySetMacho(e, "macho.import_hash", v),
				"file.macho.imports_names_entropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_entropy", v),
				"FileMachoImportsNamesEntropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_entropy", v),
				"file.macho.imports_names_var_entropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_var_entropy", v),
				"FileMachoImportsNamesVarEntropy" => static (e, v) => TrySetMacho(e, "macho.imports_names_var_entropy", v),
				"file.macho.symhash" => static (e, v) => TrySetMacho(e, "macho.symhash", v),
				"FileMachoSymhash" => static (e, v) => TrySetMacho(e, "macho.symhash", v),
				_ => null
			};
			if (assign == null) return false;

			var entity = document.IndicatorFile ?? new File();
			var assigned = assign(entity, value);
			if (assigned) document.IndicatorFile = entity;
			return assigned;
		}

		public static bool TrySetIndicatorGeo(IIndicatorGeo document, string path, object value)
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

			var entity = document.IndicatorGeo ?? new Geo();
			var assigned = assign(entity, value);
			if (assigned) document.IndicatorGeo = entity;
			return assigned;
		}

		public static bool TrySetIndicatorRegistry(IIndicatorRegistry document, string path, object value)
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

			var entity = document.IndicatorRegistry ?? new Registry();
			var assigned = assign(entity, value);
			if (assigned) document.IndicatorRegistry = entity;
			return assigned;
		}

		public static bool TrySetIndicatorUrl(IIndicatorUrl document, string path, object value)
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

			var entity = document.IndicatorUrl ?? new Url();
			var assigned = assign(entity, value);
			if (assigned) document.IndicatorUrl = entity;
			return assigned;
		}

		public static bool TrySetClientX509(IClientX509 document, string path, object value)
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

			var entity = document.ClientX509 ?? new X509();
			var assigned = assign(entity, value);
			if (assigned) document.ClientX509 = entity;
			return assigned;
		}

		public static bool TrySetServerX509(IServerX509 document, string path, object value)
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

			var entity = document.ServerX509 ?? new X509();
			var assigned = assign(entity, value);
			if (assigned) document.ServerX509 = entity;
			return assigned;
		}

		public static bool TrySetTarget(ITarget document, string path, object value)
		{
			Func<UserTarget, object, bool> assign = path switch
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

			var entity = document.Target ?? new UserTarget();
			var assigned = assign(entity, value);
			if (assigned) document.Target = entity;
			return assigned;
		}

		public static bool TrySetEffective(IEffective document, string path, object value)
		{
			Func<UserEffective, object, bool> assign = path switch
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

			var entity = document.Effective ?? new UserEffective();
			var assigned = assign(entity, value);
			if (assigned) document.Effective = entity;
			return assigned;
		}

		public static bool TrySetChanges(IChanges document, string path, object value)
		{
			Func<UserChanges, object, bool> assign = path switch
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

			var entity = document.Changes ?? new UserChanges();
			var assigned = assign(entity, value);
			if (assigned) document.Changes = entity;
			return assigned;
		}
	}
}
