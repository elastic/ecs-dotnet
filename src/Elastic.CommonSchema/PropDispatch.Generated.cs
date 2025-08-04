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
				case "volume" when value is Volume @volume:
					document.Volume = @volume;
					return true;
				case "volume" when value is Dictionary<string, object> @volume:
					if (!TypeCheck(@volume, LogTemplateEntities.Volume)) return false;
					foreach (var kvp in @volume)
					{
						if (kvp.Value == null || kvp.Key == "$type") continue;
						if (!TrySetVolume(document, $"Volume{kvp.Key}", kvp.Value))
							SetMetaOrLabel(document, $"Volume{kvp.Key}", kvp.Value);
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
				case "client.geo.location":
				case "ClientGeoLocation":
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
				case "code_signature.flags":
				case "CodeSignatureFlags":
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
				case "destination.geo.location":
				case "DestinationGeoLocation":
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
					return TrySetDestination(document, path, value);
				case "device.id":
				case "DeviceId":
				case "device.manufacturer":
				case "DeviceManufacturer":
				case "device.model.identifier":
				case "DeviceModelIdentifier":
				case "device.model.name":
				case "DeviceModelName":
				case "device.serial_number":
				case "DeviceSerialNumber":
					return TrySetDevice(document, path, value);
				case "dll.name":
				case "DllName":
				case "dll.path":
				case "DllPath":
				case "dll.hash.cdhash":
				case "DllHashCdhash":
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
				case "dll.code_signature.flags":
				case "DllCodeSignatureFlags":
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
				case "file.hash.cdhash":
				case "FileHashCdhash":
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
				case "file.code_signature.flags":
				case "FileCodeSignatureFlags":
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
				case "geo.location":
				case "GeoLocation":
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
				case "hash.cdhash":
				case "HashCdhash":
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
				case "host.geo.location":
				case "HostGeoLocation":
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
				case "observer.geo.location":
				case "ObserverGeoLocation":
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
				case "process.real_group.domain":
				case "ProcessRealGroupDomain":
				case "process.real_group.id":
				case "ProcessRealGroupId":
				case "process.real_group.name":
				case "ProcessRealGroupName":
				case "process.saved_group.domain":
				case "ProcessSavedGroupDomain":
				case "process.saved_group.id":
				case "ProcessSavedGroupId":
				case "process.saved_group.name":
				case "ProcessSavedGroupName":
				case "process.hash.cdhash":
				case "ProcessHashCdhash":
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
				case "process.code_signature.flags":
				case "ProcessCodeSignatureFlags":
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
				case "process.entry_meta.source.address":
				case "ProcessEntryMetaSourceAddress":
				case "process.entry_meta.source.bytes":
				case "ProcessEntryMetaSourceBytes":
				case "process.entry_meta.source.domain":
				case "ProcessEntryMetaSourceDomain":
				case "process.entry_meta.source.ip":
				case "ProcessEntryMetaSourceIp":
				case "process.entry_meta.source.mac":
				case "ProcessEntryMetaSourceMac":
				case "process.entry_meta.source.nat.ip":
				case "ProcessEntryMetaSourceNatIp":
				case "process.entry_meta.source.nat.port":
				case "ProcessEntryMetaSourceNatPort":
				case "process.entry_meta.source.packets":
				case "ProcessEntryMetaSourcePackets":
				case "process.entry_meta.source.port":
				case "ProcessEntryMetaSourcePort":
				case "process.entry_meta.source.registered_domain":
				case "ProcessEntryMetaSourceRegisteredDomain":
				case "process.entry_meta.source.subdomain":
				case "ProcessEntryMetaSourceSubdomain":
				case "process.entry_meta.source.top_level_domain":
				case "ProcessEntryMetaSourceTopLevelDomain":
				case "process.entry_meta.source.as.number":
				case "ProcessEntryMetaSourceAsNumber":
				case "process.entry_meta.source.as.organization.name":
				case "ProcessEntryMetaSourceAsOrganizationName":
				case "process.entry_meta.source.geo.city_name":
				case "ProcessEntryMetaSourceGeoCityName":
				case "process.entry_meta.source.geo.continent_code":
				case "ProcessEntryMetaSourceGeoContinentCode":
				case "process.entry_meta.source.geo.continent_name":
				case "ProcessEntryMetaSourceGeoContinentName":
				case "process.entry_meta.source.geo.country_iso_code":
				case "ProcessEntryMetaSourceGeoCountryIsoCode":
				case "process.entry_meta.source.geo.country_name":
				case "ProcessEntryMetaSourceGeoCountryName":
				case "process.entry_meta.source.geo.location":
				case "ProcessEntryMetaSourceGeoLocation":
				case "process.entry_meta.source.geo.name":
				case "ProcessEntryMetaSourceGeoName":
				case "process.entry_meta.source.geo.postal_code":
				case "ProcessEntryMetaSourceGeoPostalCode":
				case "process.entry_meta.source.geo.region_iso_code":
				case "ProcessEntryMetaSourceGeoRegionIsoCode":
				case "process.entry_meta.source.geo.region_name":
				case "ProcessEntryMetaSourceGeoRegionName":
				case "process.entry_meta.source.geo.timezone":
				case "ProcessEntryMetaSourceGeoTimezone":
				case "process.entry_meta.source.user.domain":
				case "ProcessEntryMetaSourceUserDomain":
				case "process.entry_meta.source.user.email":
				case "ProcessEntryMetaSourceUserEmail":
				case "process.entry_meta.source.user.full_name":
				case "ProcessEntryMetaSourceUserFullName":
				case "process.entry_meta.source.user.hash":
				case "ProcessEntryMetaSourceUserHash":
				case "process.entry_meta.source.user.id":
				case "ProcessEntryMetaSourceUserId":
				case "process.entry_meta.source.user.name":
				case "ProcessEntryMetaSourceUserName":
				case "process.entry_meta.source.user.group.domain":
				case "ProcessEntryMetaSourceUserGroupDomain":
				case "process.entry_meta.source.user.group.id":
				case "ProcessEntryMetaSourceUserGroupId":
				case "process.entry_meta.source.user.group.name":
				case "ProcessEntryMetaSourceUserGroupName":
				case "process.entry_meta.source.user.risk.calculated_level":
				case "ProcessEntryMetaSourceUserRiskCalculatedLevel":
				case "process.entry_meta.source.user.risk.calculated_score":
				case "ProcessEntryMetaSourceUserRiskCalculatedScore":
				case "process.entry_meta.source.user.risk.calculated_score_norm":
				case "ProcessEntryMetaSourceUserRiskCalculatedScoreNorm":
				case "process.entry_meta.source.user.risk.static_level":
				case "ProcessEntryMetaSourceUserRiskStaticLevel":
				case "process.entry_meta.source.user.risk.static_score":
				case "ProcessEntryMetaSourceUserRiskStaticScore":
				case "process.entry_meta.source.user.risk.static_score_norm":
				case "ProcessEntryMetaSourceUserRiskStaticScoreNorm":
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
				case "process.saved_user.domain":
				case "ProcessSavedUserDomain":
				case "process.saved_user.email":
				case "ProcessSavedUserEmail":
				case "process.saved_user.full_name":
				case "ProcessSavedUserFullName":
				case "process.saved_user.hash":
				case "ProcessSavedUserHash":
				case "process.saved_user.id":
				case "ProcessSavedUserId":
				case "process.saved_user.name":
				case "ProcessSavedUserName":
				case "process.saved_user.group.domain":
				case "ProcessSavedUserGroupDomain":
				case "process.saved_user.group.id":
				case "ProcessSavedUserGroupId":
				case "process.saved_user.group.name":
				case "ProcessSavedUserGroupName":
				case "process.saved_user.risk.calculated_level":
				case "ProcessSavedUserRiskCalculatedLevel":
				case "process.saved_user.risk.calculated_score":
				case "ProcessSavedUserRiskCalculatedScore":
				case "process.saved_user.risk.calculated_score_norm":
				case "ProcessSavedUserRiskCalculatedScoreNorm":
				case "process.saved_user.risk.static_level":
				case "ProcessSavedUserRiskStaticLevel":
				case "process.saved_user.risk.static_score":
				case "ProcessSavedUserRiskStaticScore":
				case "process.saved_user.risk.static_score_norm":
				case "ProcessSavedUserRiskStaticScoreNorm":
				case "process.real_user.domain":
				case "ProcessRealUserDomain":
				case "process.real_user.email":
				case "ProcessRealUserEmail":
				case "process.real_user.full_name":
				case "ProcessRealUserFullName":
				case "process.real_user.hash":
				case "ProcessRealUserHash":
				case "process.real_user.id":
				case "ProcessRealUserId":
				case "process.real_user.name":
				case "ProcessRealUserName":
				case "process.real_user.group.domain":
				case "ProcessRealUserGroupDomain":
				case "process.real_user.group.id":
				case "ProcessRealUserGroupId":
				case "process.real_user.group.name":
				case "ProcessRealUserGroupName":
				case "process.real_user.risk.calculated_level":
				case "ProcessRealUserRiskCalculatedLevel":
				case "process.real_user.risk.calculated_score":
				case "ProcessRealUserRiskCalculatedScore":
				case "process.real_user.risk.calculated_score_norm":
				case "ProcessRealUserRiskCalculatedScoreNorm":
				case "process.real_user.risk.static_level":
				case "ProcessRealUserRiskStaticLevel":
				case "process.real_user.risk.static_score":
				case "ProcessRealUserRiskStaticScore":
				case "process.real_user.risk.static_score_norm":
				case "ProcessRealUserRiskStaticScoreNorm":
				case "process.attested_user.domain":
				case "ProcessAttestedUserDomain":
				case "process.attested_user.email":
				case "ProcessAttestedUserEmail":
				case "process.attested_user.full_name":
				case "ProcessAttestedUserFullName":
				case "process.attested_user.hash":
				case "ProcessAttestedUserHash":
				case "process.attested_user.id":
				case "ProcessAttestedUserId":
				case "process.attested_user.name":
				case "ProcessAttestedUserName":
				case "process.attested_user.group.domain":
				case "ProcessAttestedUserGroupDomain":
				case "process.attested_user.group.id":
				case "ProcessAttestedUserGroupId":
				case "process.attested_user.group.name":
				case "ProcessAttestedUserGroupName":
				case "process.attested_user.risk.calculated_level":
				case "ProcessAttestedUserRiskCalculatedLevel":
				case "process.attested_user.risk.calculated_score":
				case "ProcessAttestedUserRiskCalculatedScore":
				case "process.attested_user.risk.calculated_score_norm":
				case "ProcessAttestedUserRiskCalculatedScoreNorm":
				case "process.attested_user.risk.static_level":
				case "ProcessAttestedUserRiskStaticLevel":
				case "process.attested_user.risk.static_score":
				case "ProcessAttestedUserRiskStaticScore":
				case "process.attested_user.risk.static_score_norm":
				case "ProcessAttestedUserRiskStaticScoreNorm":
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
				case "server.geo.location":
				case "ServerGeoLocation":
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
				case "source.geo.location":
				case "SourceGeoLocation":
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
				case "threat.indicator.x509.issuer.distinguished_name":
				case "ThreatIndicatorX509IssuerDistinguishedName":
				case "threat.indicator.x509.not_after":
				case "ThreatIndicatorX509NotAfter":
				case "threat.indicator.x509.not_before":
				case "ThreatIndicatorX509NotBefore":
				case "threat.indicator.x509.public_key_algorithm":
				case "ThreatIndicatorX509PublicKeyAlgorithm":
				case "threat.indicator.x509.public_key_curve":
				case "ThreatIndicatorX509PublicKeyCurve":
				case "threat.indicator.x509.public_key_exponent":
				case "ThreatIndicatorX509PublicKeyExponent":
				case "threat.indicator.x509.public_key_size":
				case "ThreatIndicatorX509PublicKeySize":
				case "threat.indicator.x509.serial_number":
				case "ThreatIndicatorX509SerialNumber":
				case "threat.indicator.x509.signature_algorithm":
				case "ThreatIndicatorX509SignatureAlgorithm":
				case "threat.indicator.x509.subject.distinguished_name":
				case "ThreatIndicatorX509SubjectDistinguishedName":
				case "threat.indicator.x509.version_number":
				case "ThreatIndicatorX509VersionNumber":
				case "threat.indicator.as.number":
				case "ThreatIndicatorAsNumber":
				case "threat.indicator.as.organization.name":
				case "ThreatIndicatorAsOrganizationName":
				case "threat.indicator.file.accessed":
				case "ThreatIndicatorFileAccessed":
				case "threat.indicator.file.created":
				case "ThreatIndicatorFileCreated":
				case "threat.indicator.file.ctime":
				case "ThreatIndicatorFileCtime":
				case "threat.indicator.file.device":
				case "ThreatIndicatorFileDevice":
				case "threat.indicator.file.directory":
				case "ThreatIndicatorFileDirectory":
				case "threat.indicator.file.drive_letter":
				case "ThreatIndicatorFileDriveLetter":
				case "threat.indicator.file.extension":
				case "ThreatIndicatorFileExtension":
				case "threat.indicator.file.fork_name":
				case "ThreatIndicatorFileForkName":
				case "threat.indicator.file.gid":
				case "ThreatIndicatorFileGid":
				case "threat.indicator.file.group":
				case "ThreatIndicatorFileGroup":
				case "threat.indicator.file.inode":
				case "ThreatIndicatorFileInode":
				case "threat.indicator.file.mime_type":
				case "ThreatIndicatorFileMimeType":
				case "threat.indicator.file.mode":
				case "ThreatIndicatorFileMode":
				case "threat.indicator.file.mtime":
				case "ThreatIndicatorFileMtime":
				case "threat.indicator.file.name":
				case "ThreatIndicatorFileName":
				case "threat.indicator.file.owner":
				case "ThreatIndicatorFileOwner":
				case "threat.indicator.file.path":
				case "ThreatIndicatorFilePath":
				case "threat.indicator.file.size":
				case "ThreatIndicatorFileSize":
				case "threat.indicator.file.target_path":
				case "ThreatIndicatorFileTargetPath":
				case "threat.indicator.file.type":
				case "ThreatIndicatorFileType":
				case "threat.indicator.file.uid":
				case "ThreatIndicatorFileUid":
				case "threat.indicator.file.hash.cdhash":
				case "ThreatIndicatorFileHashCdhash":
				case "threat.indicator.file.hash.md5":
				case "ThreatIndicatorFileHashMd5":
				case "threat.indicator.file.hash.sha1":
				case "ThreatIndicatorFileHashSha1":
				case "threat.indicator.file.hash.sha256":
				case "ThreatIndicatorFileHashSha256":
				case "threat.indicator.file.hash.sha384":
				case "ThreatIndicatorFileHashSha384":
				case "threat.indicator.file.hash.sha512":
				case "ThreatIndicatorFileHashSha512":
				case "threat.indicator.file.hash.ssdeep":
				case "ThreatIndicatorFileHashSsdeep":
				case "threat.indicator.file.hash.tlsh":
				case "ThreatIndicatorFileHashTlsh":
				case "threat.indicator.file.pe.architecture":
				case "ThreatIndicatorFilePeArchitecture":
				case "threat.indicator.file.pe.company":
				case "ThreatIndicatorFilePeCompany":
				case "threat.indicator.file.pe.description":
				case "ThreatIndicatorFilePeDescription":
				case "threat.indicator.file.pe.file_version":
				case "ThreatIndicatorFilePeFileVersion":
				case "threat.indicator.file.pe.go_import_hash":
				case "ThreatIndicatorFilePeGoImportHash":
				case "threat.indicator.file.pe.go_imports":
				case "ThreatIndicatorFilePeGoImports":
				case "threat.indicator.file.pe.go_imports_names_entropy":
				case "ThreatIndicatorFilePeGoImportsNamesEntropy":
				case "threat.indicator.file.pe.go_imports_names_var_entropy":
				case "ThreatIndicatorFilePeGoImportsNamesVarEntropy":
				case "threat.indicator.file.pe.go_stripped":
				case "ThreatIndicatorFilePeGoStripped":
				case "threat.indicator.file.pe.imphash":
				case "ThreatIndicatorFilePeImphash":
				case "threat.indicator.file.pe.import_hash":
				case "ThreatIndicatorFilePeImportHash":
				case "threat.indicator.file.pe.imports_names_entropy":
				case "ThreatIndicatorFilePeImportsNamesEntropy":
				case "threat.indicator.file.pe.imports_names_var_entropy":
				case "ThreatIndicatorFilePeImportsNamesVarEntropy":
				case "threat.indicator.file.pe.original_file_name":
				case "ThreatIndicatorFilePeOriginalFileName":
				case "threat.indicator.file.pe.pehash":
				case "ThreatIndicatorFilePePehash":
				case "threat.indicator.file.pe.product":
				case "ThreatIndicatorFilePeProduct":
				case "threat.indicator.file.x509.issuer.distinguished_name":
				case "ThreatIndicatorFileX509IssuerDistinguishedName":
				case "threat.indicator.file.x509.not_after":
				case "ThreatIndicatorFileX509NotAfter":
				case "threat.indicator.file.x509.not_before":
				case "ThreatIndicatorFileX509NotBefore":
				case "threat.indicator.file.x509.public_key_algorithm":
				case "ThreatIndicatorFileX509PublicKeyAlgorithm":
				case "threat.indicator.file.x509.public_key_curve":
				case "ThreatIndicatorFileX509PublicKeyCurve":
				case "threat.indicator.file.x509.public_key_exponent":
				case "ThreatIndicatorFileX509PublicKeyExponent":
				case "threat.indicator.file.x509.public_key_size":
				case "ThreatIndicatorFileX509PublicKeySize":
				case "threat.indicator.file.x509.serial_number":
				case "ThreatIndicatorFileX509SerialNumber":
				case "threat.indicator.file.x509.signature_algorithm":
				case "ThreatIndicatorFileX509SignatureAlgorithm":
				case "threat.indicator.file.x509.subject.distinguished_name":
				case "ThreatIndicatorFileX509SubjectDistinguishedName":
				case "threat.indicator.file.x509.version_number":
				case "ThreatIndicatorFileX509VersionNumber":
				case "threat.indicator.file.code_signature.digest_algorithm":
				case "ThreatIndicatorFileCodeSignatureDigestAlgorithm":
				case "threat.indicator.file.code_signature.exists":
				case "ThreatIndicatorFileCodeSignatureExists":
				case "threat.indicator.file.code_signature.flags":
				case "ThreatIndicatorFileCodeSignatureFlags":
				case "threat.indicator.file.code_signature.signing_id":
				case "ThreatIndicatorFileCodeSignatureSigningId":
				case "threat.indicator.file.code_signature.status":
				case "ThreatIndicatorFileCodeSignatureStatus":
				case "threat.indicator.file.code_signature.subject_name":
				case "ThreatIndicatorFileCodeSignatureSubjectName":
				case "threat.indicator.file.code_signature.team_id":
				case "ThreatIndicatorFileCodeSignatureTeamId":
				case "threat.indicator.file.code_signature.timestamp":
				case "ThreatIndicatorFileCodeSignatureTimestamp":
				case "threat.indicator.file.code_signature.trusted":
				case "ThreatIndicatorFileCodeSignatureTrusted":
				case "threat.indicator.file.code_signature.valid":
				case "ThreatIndicatorFileCodeSignatureValid":
				case "threat.indicator.file.elf.architecture":
				case "ThreatIndicatorFileElfArchitecture":
				case "threat.indicator.file.elf.byte_order":
				case "ThreatIndicatorFileElfByteOrder":
				case "threat.indicator.file.elf.cpu_type":
				case "ThreatIndicatorFileElfCpuType":
				case "threat.indicator.file.elf.creation_date":
				case "ThreatIndicatorFileElfCreationDate":
				case "threat.indicator.file.elf.go_import_hash":
				case "ThreatIndicatorFileElfGoImportHash":
				case "threat.indicator.file.elf.go_imports":
				case "ThreatIndicatorFileElfGoImports":
				case "threat.indicator.file.elf.go_imports_names_entropy":
				case "ThreatIndicatorFileElfGoImportsNamesEntropy":
				case "threat.indicator.file.elf.go_imports_names_var_entropy":
				case "ThreatIndicatorFileElfGoImportsNamesVarEntropy":
				case "threat.indicator.file.elf.go_stripped":
				case "ThreatIndicatorFileElfGoStripped":
				case "threat.indicator.file.elf.header.abi_version":
				case "ThreatIndicatorFileElfHeaderAbiVersion":
				case "threat.indicator.file.elf.header.class":
				case "ThreatIndicatorFileElfHeaderClass":
				case "threat.indicator.file.elf.header.data":
				case "ThreatIndicatorFileElfHeaderData":
				case "threat.indicator.file.elf.header.entrypoint":
				case "ThreatIndicatorFileElfHeaderEntrypoint":
				case "threat.indicator.file.elf.header.object_version":
				case "ThreatIndicatorFileElfHeaderObjectVersion":
				case "threat.indicator.file.elf.header.os_abi":
				case "ThreatIndicatorFileElfHeaderOsAbi":
				case "threat.indicator.file.elf.header.type":
				case "ThreatIndicatorFileElfHeaderType":
				case "threat.indicator.file.elf.header.version":
				case "ThreatIndicatorFileElfHeaderVersion":
				case "threat.indicator.file.elf.import_hash":
				case "ThreatIndicatorFileElfImportHash":
				case "threat.indicator.file.elf.imports_names_entropy":
				case "ThreatIndicatorFileElfImportsNamesEntropy":
				case "threat.indicator.file.elf.imports_names_var_entropy":
				case "ThreatIndicatorFileElfImportsNamesVarEntropy":
				case "threat.indicator.file.elf.telfhash":
				case "ThreatIndicatorFileElfTelfhash":
				case "threat.indicator.file.macho.go_import_hash":
				case "ThreatIndicatorFileMachoGoImportHash":
				case "threat.indicator.file.macho.go_imports":
				case "ThreatIndicatorFileMachoGoImports":
				case "threat.indicator.file.macho.go_imports_names_entropy":
				case "ThreatIndicatorFileMachoGoImportsNamesEntropy":
				case "threat.indicator.file.macho.go_imports_names_var_entropy":
				case "ThreatIndicatorFileMachoGoImportsNamesVarEntropy":
				case "threat.indicator.file.macho.go_stripped":
				case "ThreatIndicatorFileMachoGoStripped":
				case "threat.indicator.file.macho.import_hash":
				case "ThreatIndicatorFileMachoImportHash":
				case "threat.indicator.file.macho.imports_names_entropy":
				case "ThreatIndicatorFileMachoImportsNamesEntropy":
				case "threat.indicator.file.macho.imports_names_var_entropy":
				case "ThreatIndicatorFileMachoImportsNamesVarEntropy":
				case "threat.indicator.file.macho.symhash":
				case "ThreatIndicatorFileMachoSymhash":
				case "threat.indicator.geo.city_name":
				case "ThreatIndicatorGeoCityName":
				case "threat.indicator.geo.continent_code":
				case "ThreatIndicatorGeoContinentCode":
				case "threat.indicator.geo.continent_name":
				case "ThreatIndicatorGeoContinentName":
				case "threat.indicator.geo.country_iso_code":
				case "ThreatIndicatorGeoCountryIsoCode":
				case "threat.indicator.geo.country_name":
				case "ThreatIndicatorGeoCountryName":
				case "threat.indicator.geo.location":
				case "ThreatIndicatorGeoLocation":
				case "threat.indicator.geo.name":
				case "ThreatIndicatorGeoName":
				case "threat.indicator.geo.postal_code":
				case "ThreatIndicatorGeoPostalCode":
				case "threat.indicator.geo.region_iso_code":
				case "ThreatIndicatorGeoRegionIsoCode":
				case "threat.indicator.geo.region_name":
				case "ThreatIndicatorGeoRegionName":
				case "threat.indicator.geo.timezone":
				case "ThreatIndicatorGeoTimezone":
				case "threat.indicator.registry.data.bytes":
				case "ThreatIndicatorRegistryDataBytes":
				case "threat.indicator.registry.data.type":
				case "ThreatIndicatorRegistryDataType":
				case "threat.indicator.registry.hive":
				case "ThreatIndicatorRegistryHive":
				case "threat.indicator.registry.key":
				case "ThreatIndicatorRegistryKey":
				case "threat.indicator.registry.path":
				case "ThreatIndicatorRegistryPath":
				case "threat.indicator.registry.value":
				case "ThreatIndicatorRegistryValue":
				case "threat.indicator.url.domain":
				case "ThreatIndicatorUrlDomain":
				case "threat.indicator.url.extension":
				case "ThreatIndicatorUrlExtension":
				case "threat.indicator.url.fragment":
				case "ThreatIndicatorUrlFragment":
				case "threat.indicator.url.full":
				case "ThreatIndicatorUrlFull":
				case "threat.indicator.url.original":
				case "ThreatIndicatorUrlOriginal":
				case "threat.indicator.url.password":
				case "ThreatIndicatorUrlPassword":
				case "threat.indicator.url.path":
				case "ThreatIndicatorUrlPath":
				case "threat.indicator.url.port":
				case "ThreatIndicatorUrlPort":
				case "threat.indicator.url.query":
				case "ThreatIndicatorUrlQuery":
				case "threat.indicator.url.registered_domain":
				case "ThreatIndicatorUrlRegisteredDomain":
				case "threat.indicator.url.scheme":
				case "ThreatIndicatorUrlScheme":
				case "threat.indicator.url.subdomain":
				case "ThreatIndicatorUrlSubdomain":
				case "threat.indicator.url.top_level_domain":
				case "ThreatIndicatorUrlTopLevelDomain":
				case "threat.indicator.url.username":
				case "ThreatIndicatorUrlUsername":
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
				case "tls.client.x509.issuer.distinguished_name":
				case "TlsClientX509IssuerDistinguishedName":
				case "tls.client.x509.not_after":
				case "TlsClientX509NotAfter":
				case "tls.client.x509.not_before":
				case "TlsClientX509NotBefore":
				case "tls.client.x509.public_key_algorithm":
				case "TlsClientX509PublicKeyAlgorithm":
				case "tls.client.x509.public_key_curve":
				case "TlsClientX509PublicKeyCurve":
				case "tls.client.x509.public_key_exponent":
				case "TlsClientX509PublicKeyExponent":
				case "tls.client.x509.public_key_size":
				case "TlsClientX509PublicKeySize":
				case "tls.client.x509.serial_number":
				case "TlsClientX509SerialNumber":
				case "tls.client.x509.signature_algorithm":
				case "TlsClientX509SignatureAlgorithm":
				case "tls.client.x509.subject.distinguished_name":
				case "TlsClientX509SubjectDistinguishedName":
				case "tls.client.x509.version_number":
				case "TlsClientX509VersionNumber":
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
				case "volume.bus_type":
				case "VolumeBusType":
				case "volume.default_access":
				case "VolumeDefaultAccess":
				case "volume.device_name":
				case "VolumeDeviceName":
				case "volume.device_type":
				case "VolumeDeviceType":
				case "volume.dos_name":
				case "VolumeDosName":
				case "volume.file_system_type":
				case "VolumeFileSystemType":
				case "volume.mount_name":
				case "VolumeMountName":
				case "volume.nt_name":
				case "VolumeNtName":
				case "volume.product_id":
				case "VolumeProductId":
				case "volume.product_name":
				case "VolumeProductName":
				case "volume.removable":
				case "VolumeRemovable":
				case "volume.serial_number":
				case "VolumeSerialNumber":
				case "volume.size":
				case "VolumeSize":
				case "volume.vendor_id":
				case "VolumeVendorId":
				case "volume.vendor_name":
				case "VolumeVendorName":
				case "volume.writable":
				case "VolumeWritable":
					return TrySetVolume(document, path, value);
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

		public static Func<Agent, object, bool> TryAssignAgent(string path)
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
			return assign;
		}
		public static bool TrySetAgent(EcsDocument document, string path, object value)
		{
			var assign = TryAssignAgent(path);
			if (assign == null) return false;
		
			var entity = document.Agent ?? new Agent();
			var assigned = assign(entity, value);
			if (assigned) document.Agent = entity;
			return assigned;
		}

		public static Func<As, object, bool> TryAssignAs(string path)
		{
			Func<As, object, bool> assign = path switch
			{
				"as.number" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Number = p),
				"AsNumber" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Number = p),
				"as.organization.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OrganizationName = p),
				"AsOrganizationName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.OrganizationName = p),
				_ => null
			};
			return assign;
		}
		public static bool TrySetAs(IAs document, string path, object value)
		{
			var assign = TryAssignAs(path);
			if (assign == null) return false;
		
			var entity = document.As ?? new As();
			var assigned = assign(entity, value);
			if (assigned) document.As = entity;
			return assigned;
		}

		public static Func<Client, object, bool> TryAssignClient(string path)
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
				"client.as.number" => static (e, v) => TryAssignAs("as.number")(e.As ??= new As(),v),
				"ClientAsNumber" => static (e, v) => TryAssignAs("as.number")(e.As ??= new As(),v),
				"client.as.organization.name" => static (e, v) => TryAssignAs("as.organization.name")(e.As ??= new As(),v),
				"ClientAsOrganizationName" => static (e, v) => TryAssignAs("as.organization.name")(e.As ??= new As(),v),
				"client.geo.city_name" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"ClientGeoCityName" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"client.geo.continent_code" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"ClientGeoContinentCode" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"client.geo.continent_name" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"ClientGeoContinentName" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"client.geo.country_iso_code" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"ClientGeoCountryIsoCode" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"client.geo.country_name" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"ClientGeoCountryName" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"client.geo.location" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"ClientGeoLocation" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"client.geo.name" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"ClientGeoName" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"client.geo.postal_code" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"ClientGeoPostalCode" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"client.geo.region_iso_code" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"ClientGeoRegionIsoCode" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"client.geo.region_name" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"ClientGeoRegionName" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"client.geo.timezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"ClientGeoTimezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"client.user.domain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"ClientUserDomain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"client.user.email" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"ClientUserEmail" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"client.user.full_name" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"ClientUserFullName" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"client.user.hash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"ClientUserHash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"client.user.id" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"ClientUserId" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"client.user.name" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"ClientUserName" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"client.user.group.domain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"ClientUserGroupDomain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"client.user.group.id" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"ClientUserGroupId" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"client.user.group.name" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"ClientUserGroupName" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"client.user.risk.calculated_level" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"ClientUserRiskCalculatedLevel" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"client.user.risk.calculated_score" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"ClientUserRiskCalculatedScore" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"client.user.risk.calculated_score_norm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"ClientUserRiskCalculatedScoreNorm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"client.user.risk.static_level" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"ClientUserRiskStaticLevel" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"client.user.risk.static_score" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"ClientUserRiskStaticScore" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"client.user.risk.static_score_norm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				"ClientUserRiskStaticScoreNorm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetClient(EcsDocument document, string path, object value)
		{
			var assign = TryAssignClient(path);
			if (assign == null) return false;
		
			var entity = document.Client ?? new Client();
			var assigned = assign(entity, value);
			if (assigned) document.Client = entity;
			return assigned;
		}

		public static Func<Cloud, object, bool> TryAssignCloud(string path)
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
			return assign;
		}
		public static bool TrySetCloud(EcsDocument document, string path, object value)
		{
			var assign = TryAssignCloud(path);
			if (assign == null) return false;
		
			var entity = document.Cloud ?? new Cloud();
			var assigned = assign(entity, value);
			if (assigned) document.Cloud = entity;
			return assigned;
		}

		public static Func<CodeSignature, object, bool> TryAssignCodeSignature(string path)
		{
			Func<CodeSignature, object, bool> assign = path switch
			{
				"code_signature.digest_algorithm" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DigestAlgorithm = p),
				"CodeSignatureDigestAlgorithm" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DigestAlgorithm = p),
				"code_signature.exists" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Exists = p),
				"CodeSignatureExists" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Exists = p),
				"code_signature.flags" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Flags = p),
				"CodeSignatureFlags" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Flags = p),
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
			return assign;
		}
		public static bool TrySetCodeSignature(ICodeSignature document, string path, object value)
		{
			var assign = TryAssignCodeSignature(path);
			if (assign == null) return false;
		
			var entity = document.CodeSignature ?? new CodeSignature();
			var assigned = assign(entity, value);
			if (assigned) document.CodeSignature = entity;
			return assigned;
		}

		public static Func<Container, object, bool> TryAssignContainer(string path)
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
			return assign;
		}
		public static bool TrySetContainer(EcsDocument document, string path, object value)
		{
			var assign = TryAssignContainer(path);
			if (assign == null) return false;
		
			var entity = document.Container ?? new Container();
			var assigned = assign(entity, value);
			if (assigned) document.Container = entity;
			return assigned;
		}

		public static Func<DataStream, object, bool> TryAssignDataStream(string path)
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
			return assign;
		}
		public static bool TrySetDataStream(EcsDocument document, string path, object value)
		{
			var assign = TryAssignDataStream(path);
			if (assign == null) return false;
		
			var entity = document.DataStream ?? new DataStream();
			var assigned = assign(entity, value);
			if (assigned) document.DataStream = entity;
			return assigned;
		}

		public static Func<Destination, object, bool> TryAssignDestination(string path)
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
				"destination.as.number" => static (e, v) => TryAssignAs("as.number")(e.As ??= new As(),v),
				"DestinationAsNumber" => static (e, v) => TryAssignAs("as.number")(e.As ??= new As(),v),
				"destination.as.organization.name" => static (e, v) => TryAssignAs("as.organization.name")(e.As ??= new As(),v),
				"DestinationAsOrganizationName" => static (e, v) => TryAssignAs("as.organization.name")(e.As ??= new As(),v),
				"destination.geo.city_name" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"DestinationGeoCityName" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"destination.geo.continent_code" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"DestinationGeoContinentCode" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"destination.geo.continent_name" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"DestinationGeoContinentName" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"destination.geo.country_iso_code" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"DestinationGeoCountryIsoCode" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"destination.geo.country_name" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"DestinationGeoCountryName" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"destination.geo.location" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"DestinationGeoLocation" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"destination.geo.name" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"DestinationGeoName" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"destination.geo.postal_code" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"DestinationGeoPostalCode" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"destination.geo.region_iso_code" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"DestinationGeoRegionIsoCode" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"destination.geo.region_name" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"DestinationGeoRegionName" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"destination.geo.timezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"DestinationGeoTimezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"destination.user.domain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"DestinationUserDomain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"destination.user.email" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"DestinationUserEmail" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"destination.user.full_name" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"DestinationUserFullName" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"destination.user.hash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"DestinationUserHash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"destination.user.id" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"DestinationUserId" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"destination.user.name" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"DestinationUserName" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"destination.user.group.domain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"DestinationUserGroupDomain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"destination.user.group.id" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"DestinationUserGroupId" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"destination.user.group.name" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"DestinationUserGroupName" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"destination.user.risk.calculated_level" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"DestinationUserRiskCalculatedLevel" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"destination.user.risk.calculated_score" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"DestinationUserRiskCalculatedScore" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"destination.user.risk.calculated_score_norm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"DestinationUserRiskCalculatedScoreNorm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"destination.user.risk.static_level" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"DestinationUserRiskStaticLevel" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"destination.user.risk.static_score" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"DestinationUserRiskStaticScore" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"destination.user.risk.static_score_norm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				"DestinationUserRiskStaticScoreNorm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetDestination(EcsDocument document, string path, object value)
		{
			var assign = TryAssignDestination(path);
			if (assign == null) return false;
		
			var entity = document.Destination ?? new Destination();
			var assigned = assign(entity, value);
			if (assigned) document.Destination = entity;
			return assigned;
		}

		public static Func<Device, object, bool> TryAssignDevice(string path)
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
				"device.serial_number" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SerialNumber = p),
				"DeviceSerialNumber" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SerialNumber = p),
				_ => null
			};
			return assign;
		}
		public static bool TrySetDevice(EcsDocument document, string path, object value)
		{
			var assign = TryAssignDevice(path);
			if (assign == null) return false;
		
			var entity = document.Device ?? new Device();
			var assigned = assign(entity, value);
			if (assigned) document.Device = entity;
			return assigned;
		}

		public static Func<Dll, object, bool> TryAssignDll(string path)
		{
			Func<Dll, object, bool> assign = path switch
			{
				"dll.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"DllName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"dll.path" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"DllPath" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Path = p),
				"dll.hash.cdhash" => static (e, v) => TryAssignHash("hash.cdhash")(e.Hash ??= new Hash(),v),
				"DllHashCdhash" => static (e, v) => TryAssignHash("hash.cdhash")(e.Hash ??= new Hash(),v),
				"dll.hash.md5" => static (e, v) => TryAssignHash("hash.md5")(e.Hash ??= new Hash(),v),
				"DllHashMd5" => static (e, v) => TryAssignHash("hash.md5")(e.Hash ??= new Hash(),v),
				"dll.hash.sha1" => static (e, v) => TryAssignHash("hash.sha1")(e.Hash ??= new Hash(),v),
				"DllHashSha1" => static (e, v) => TryAssignHash("hash.sha1")(e.Hash ??= new Hash(),v),
				"dll.hash.sha256" => static (e, v) => TryAssignHash("hash.sha256")(e.Hash ??= new Hash(),v),
				"DllHashSha256" => static (e, v) => TryAssignHash("hash.sha256")(e.Hash ??= new Hash(),v),
				"dll.hash.sha384" => static (e, v) => TryAssignHash("hash.sha384")(e.Hash ??= new Hash(),v),
				"DllHashSha384" => static (e, v) => TryAssignHash("hash.sha384")(e.Hash ??= new Hash(),v),
				"dll.hash.sha512" => static (e, v) => TryAssignHash("hash.sha512")(e.Hash ??= new Hash(),v),
				"DllHashSha512" => static (e, v) => TryAssignHash("hash.sha512")(e.Hash ??= new Hash(),v),
				"dll.hash.ssdeep" => static (e, v) => TryAssignHash("hash.ssdeep")(e.Hash ??= new Hash(),v),
				"DllHashSsdeep" => static (e, v) => TryAssignHash("hash.ssdeep")(e.Hash ??= new Hash(),v),
				"dll.hash.tlsh" => static (e, v) => TryAssignHash("hash.tlsh")(e.Hash ??= new Hash(),v),
				"DllHashTlsh" => static (e, v) => TryAssignHash("hash.tlsh")(e.Hash ??= new Hash(),v),
				"dll.pe.architecture" => static (e, v) => TryAssignPe("pe.architecture")(e.Pe ??= new Pe(),v),
				"DllPeArchitecture" => static (e, v) => TryAssignPe("pe.architecture")(e.Pe ??= new Pe(),v),
				"dll.pe.company" => static (e, v) => TryAssignPe("pe.company")(e.Pe ??= new Pe(),v),
				"DllPeCompany" => static (e, v) => TryAssignPe("pe.company")(e.Pe ??= new Pe(),v),
				"dll.pe.description" => static (e, v) => TryAssignPe("pe.description")(e.Pe ??= new Pe(),v),
				"DllPeDescription" => static (e, v) => TryAssignPe("pe.description")(e.Pe ??= new Pe(),v),
				"dll.pe.file_version" => static (e, v) => TryAssignPe("pe.file_version")(e.Pe ??= new Pe(),v),
				"DllPeFileVersion" => static (e, v) => TryAssignPe("pe.file_version")(e.Pe ??= new Pe(),v),
				"dll.pe.go_import_hash" => static (e, v) => TryAssignPe("pe.go_import_hash")(e.Pe ??= new Pe(),v),
				"DllPeGoImportHash" => static (e, v) => TryAssignPe("pe.go_import_hash")(e.Pe ??= new Pe(),v),
				"dll.pe.go_imports" => static (e, v) => TryAssignPe("pe.go_imports")(e.Pe ??= new Pe(),v),
				"DllPeGoImports" => static (e, v) => TryAssignPe("pe.go_imports")(e.Pe ??= new Pe(),v),
				"dll.pe.go_imports_names_entropy" => static (e, v) => TryAssignPe("pe.go_imports_names_entropy")(e.Pe ??= new Pe(),v),
				"DllPeGoImportsNamesEntropy" => static (e, v) => TryAssignPe("pe.go_imports_names_entropy")(e.Pe ??= new Pe(),v),
				"dll.pe.go_imports_names_var_entropy" => static (e, v) => TryAssignPe("pe.go_imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"DllPeGoImportsNamesVarEntropy" => static (e, v) => TryAssignPe("pe.go_imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"dll.pe.go_stripped" => static (e, v) => TryAssignPe("pe.go_stripped")(e.Pe ??= new Pe(),v),
				"DllPeGoStripped" => static (e, v) => TryAssignPe("pe.go_stripped")(e.Pe ??= new Pe(),v),
				"dll.pe.imphash" => static (e, v) => TryAssignPe("pe.imphash")(e.Pe ??= new Pe(),v),
				"DllPeImphash" => static (e, v) => TryAssignPe("pe.imphash")(e.Pe ??= new Pe(),v),
				"dll.pe.import_hash" => static (e, v) => TryAssignPe("pe.import_hash")(e.Pe ??= new Pe(),v),
				"DllPeImportHash" => static (e, v) => TryAssignPe("pe.import_hash")(e.Pe ??= new Pe(),v),
				"dll.pe.imports_names_entropy" => static (e, v) => TryAssignPe("pe.imports_names_entropy")(e.Pe ??= new Pe(),v),
				"DllPeImportsNamesEntropy" => static (e, v) => TryAssignPe("pe.imports_names_entropy")(e.Pe ??= new Pe(),v),
				"dll.pe.imports_names_var_entropy" => static (e, v) => TryAssignPe("pe.imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"DllPeImportsNamesVarEntropy" => static (e, v) => TryAssignPe("pe.imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"dll.pe.original_file_name" => static (e, v) => TryAssignPe("pe.original_file_name")(e.Pe ??= new Pe(),v),
				"DllPeOriginalFileName" => static (e, v) => TryAssignPe("pe.original_file_name")(e.Pe ??= new Pe(),v),
				"dll.pe.pehash" => static (e, v) => TryAssignPe("pe.pehash")(e.Pe ??= new Pe(),v),
				"DllPePehash" => static (e, v) => TryAssignPe("pe.pehash")(e.Pe ??= new Pe(),v),
				"dll.pe.product" => static (e, v) => TryAssignPe("pe.product")(e.Pe ??= new Pe(),v),
				"DllPeProduct" => static (e, v) => TryAssignPe("pe.product")(e.Pe ??= new Pe(),v),
				"dll.code_signature.digest_algorithm" => static (e, v) => TryAssignCodeSignature("code_signature.digest_algorithm")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureDigestAlgorithm" => static (e, v) => TryAssignCodeSignature("code_signature.digest_algorithm")(e.CodeSignature ??= new CodeSignature(),v),
				"dll.code_signature.exists" => static (e, v) => TryAssignCodeSignature("code_signature.exists")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureExists" => static (e, v) => TryAssignCodeSignature("code_signature.exists")(e.CodeSignature ??= new CodeSignature(),v),
				"dll.code_signature.flags" => static (e, v) => TryAssignCodeSignature("code_signature.flags")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureFlags" => static (e, v) => TryAssignCodeSignature("code_signature.flags")(e.CodeSignature ??= new CodeSignature(),v),
				"dll.code_signature.signing_id" => static (e, v) => TryAssignCodeSignature("code_signature.signing_id")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureSigningId" => static (e, v) => TryAssignCodeSignature("code_signature.signing_id")(e.CodeSignature ??= new CodeSignature(),v),
				"dll.code_signature.status" => static (e, v) => TryAssignCodeSignature("code_signature.status")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureStatus" => static (e, v) => TryAssignCodeSignature("code_signature.status")(e.CodeSignature ??= new CodeSignature(),v),
				"dll.code_signature.subject_name" => static (e, v) => TryAssignCodeSignature("code_signature.subject_name")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureSubjectName" => static (e, v) => TryAssignCodeSignature("code_signature.subject_name")(e.CodeSignature ??= new CodeSignature(),v),
				"dll.code_signature.team_id" => static (e, v) => TryAssignCodeSignature("code_signature.team_id")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureTeamId" => static (e, v) => TryAssignCodeSignature("code_signature.team_id")(e.CodeSignature ??= new CodeSignature(),v),
				"dll.code_signature.timestamp" => static (e, v) => TryAssignCodeSignature("code_signature.timestamp")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureTimestamp" => static (e, v) => TryAssignCodeSignature("code_signature.timestamp")(e.CodeSignature ??= new CodeSignature(),v),
				"dll.code_signature.trusted" => static (e, v) => TryAssignCodeSignature("code_signature.trusted")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureTrusted" => static (e, v) => TryAssignCodeSignature("code_signature.trusted")(e.CodeSignature ??= new CodeSignature(),v),
				"dll.code_signature.valid" => static (e, v) => TryAssignCodeSignature("code_signature.valid")(e.CodeSignature ??= new CodeSignature(),v),
				"DllCodeSignatureValid" => static (e, v) => TryAssignCodeSignature("code_signature.valid")(e.CodeSignature ??= new CodeSignature(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetDll(EcsDocument document, string path, object value)
		{
			var assign = TryAssignDll(path);
			if (assign == null) return false;
		
			var entity = document.Dll ?? new Dll();
			var assigned = assign(entity, value);
			if (assigned) document.Dll = entity;
			return assigned;
		}

		public static Func<Dns, object, bool> TryAssignDns(string path)
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
			return assign;
		}
		public static bool TrySetDns(EcsDocument document, string path, object value)
		{
			var assign = TryAssignDns(path);
			if (assign == null) return false;
		
			var entity = document.Dns ?? new Dns();
			var assigned = assign(entity, value);
			if (assigned) document.Dns = entity;
			return assigned;
		}

		public static Func<Ecs, object, bool> TryAssignEcs(string path)
		{
			Func<Ecs, object, bool> assign = path switch
			{
				"ecs.version" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				"EcsVersion" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Version = p),
				_ => null
			};
			return assign;
		}
		public static bool TrySetEcs(EcsDocument document, string path, object value)
		{
			var assign = TryAssignEcs(path);
			if (assign == null) return false;
		
			var entity = document.Ecs ?? new Ecs();
			var assigned = assign(entity, value);
			if (assigned) document.Ecs = entity;
			return assigned;
		}

		public static Func<Elf, object, bool> TryAssignElf(string path)
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
			return assign;
		}
		public static bool TrySetElf(IElf document, string path, object value)
		{
			var assign = TryAssignElf(path);
			if (assign == null) return false;
		
			var entity = document.Elf ?? new Elf();
			var assigned = assign(entity, value);
			if (assigned) document.Elf = entity;
			return assigned;
		}

		public static Func<Email, object, bool> TryAssignEmail(string path)
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
			return assign;
		}
		public static bool TrySetEmail(EcsDocument document, string path, object value)
		{
			var assign = TryAssignEmail(path);
			if (assign == null) return false;
		
			var entity = document.Email ?? new Email();
			var assigned = assign(entity, value);
			if (assigned) document.Email = entity;
			return assigned;
		}

		public static Func<Error, object, bool> TryAssignError(string path)
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
			return assign;
		}
		public static bool TrySetError(EcsDocument document, string path, object value)
		{
			var assign = TryAssignError(path);
			if (assign == null) return false;
		
			var entity = document.Error ?? new Error();
			var assigned = assign(entity, value);
			if (assigned) document.Error = entity;
			return assigned;
		}

		public static Func<Event, object, bool> TryAssignEvent(string path)
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
			return assign;
		}
		public static bool TrySetEvent(EcsDocument document, string path, object value)
		{
			var assign = TryAssignEvent(path);
			if (assign == null) return false;
		
			var entity = document.Event ?? new Event();
			var assigned = assign(entity, value);
			if (assigned) document.Event = entity;
			return assigned;
		}

		public static Func<Faas, object, bool> TryAssignFaas(string path)
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
			return assign;
		}
		public static bool TrySetFaas(EcsDocument document, string path, object value)
		{
			var assign = TryAssignFaas(path);
			if (assign == null) return false;
		
			var entity = document.Faas ?? new Faas();
			var assigned = assign(entity, value);
			if (assigned) document.Faas = entity;
			return assigned;
		}

		public static Func<File, object, bool> TryAssignFile(string path)
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
				"file.hash.cdhash" => static (e, v) => TryAssignHash("hash.cdhash")(e.Hash ??= new Hash(),v),
				"FileHashCdhash" => static (e, v) => TryAssignHash("hash.cdhash")(e.Hash ??= new Hash(),v),
				"file.hash.md5" => static (e, v) => TryAssignHash("hash.md5")(e.Hash ??= new Hash(),v),
				"FileHashMd5" => static (e, v) => TryAssignHash("hash.md5")(e.Hash ??= new Hash(),v),
				"file.hash.sha1" => static (e, v) => TryAssignHash("hash.sha1")(e.Hash ??= new Hash(),v),
				"FileHashSha1" => static (e, v) => TryAssignHash("hash.sha1")(e.Hash ??= new Hash(),v),
				"file.hash.sha256" => static (e, v) => TryAssignHash("hash.sha256")(e.Hash ??= new Hash(),v),
				"FileHashSha256" => static (e, v) => TryAssignHash("hash.sha256")(e.Hash ??= new Hash(),v),
				"file.hash.sha384" => static (e, v) => TryAssignHash("hash.sha384")(e.Hash ??= new Hash(),v),
				"FileHashSha384" => static (e, v) => TryAssignHash("hash.sha384")(e.Hash ??= new Hash(),v),
				"file.hash.sha512" => static (e, v) => TryAssignHash("hash.sha512")(e.Hash ??= new Hash(),v),
				"FileHashSha512" => static (e, v) => TryAssignHash("hash.sha512")(e.Hash ??= new Hash(),v),
				"file.hash.ssdeep" => static (e, v) => TryAssignHash("hash.ssdeep")(e.Hash ??= new Hash(),v),
				"FileHashSsdeep" => static (e, v) => TryAssignHash("hash.ssdeep")(e.Hash ??= new Hash(),v),
				"file.hash.tlsh" => static (e, v) => TryAssignHash("hash.tlsh")(e.Hash ??= new Hash(),v),
				"FileHashTlsh" => static (e, v) => TryAssignHash("hash.tlsh")(e.Hash ??= new Hash(),v),
				"file.pe.architecture" => static (e, v) => TryAssignPe("pe.architecture")(e.Pe ??= new Pe(),v),
				"FilePeArchitecture" => static (e, v) => TryAssignPe("pe.architecture")(e.Pe ??= new Pe(),v),
				"file.pe.company" => static (e, v) => TryAssignPe("pe.company")(e.Pe ??= new Pe(),v),
				"FilePeCompany" => static (e, v) => TryAssignPe("pe.company")(e.Pe ??= new Pe(),v),
				"file.pe.description" => static (e, v) => TryAssignPe("pe.description")(e.Pe ??= new Pe(),v),
				"FilePeDescription" => static (e, v) => TryAssignPe("pe.description")(e.Pe ??= new Pe(),v),
				"file.pe.file_version" => static (e, v) => TryAssignPe("pe.file_version")(e.Pe ??= new Pe(),v),
				"FilePeFileVersion" => static (e, v) => TryAssignPe("pe.file_version")(e.Pe ??= new Pe(),v),
				"file.pe.go_import_hash" => static (e, v) => TryAssignPe("pe.go_import_hash")(e.Pe ??= new Pe(),v),
				"FilePeGoImportHash" => static (e, v) => TryAssignPe("pe.go_import_hash")(e.Pe ??= new Pe(),v),
				"file.pe.go_imports" => static (e, v) => TryAssignPe("pe.go_imports")(e.Pe ??= new Pe(),v),
				"FilePeGoImports" => static (e, v) => TryAssignPe("pe.go_imports")(e.Pe ??= new Pe(),v),
				"file.pe.go_imports_names_entropy" => static (e, v) => TryAssignPe("pe.go_imports_names_entropy")(e.Pe ??= new Pe(),v),
				"FilePeGoImportsNamesEntropy" => static (e, v) => TryAssignPe("pe.go_imports_names_entropy")(e.Pe ??= new Pe(),v),
				"file.pe.go_imports_names_var_entropy" => static (e, v) => TryAssignPe("pe.go_imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"FilePeGoImportsNamesVarEntropy" => static (e, v) => TryAssignPe("pe.go_imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"file.pe.go_stripped" => static (e, v) => TryAssignPe("pe.go_stripped")(e.Pe ??= new Pe(),v),
				"FilePeGoStripped" => static (e, v) => TryAssignPe("pe.go_stripped")(e.Pe ??= new Pe(),v),
				"file.pe.imphash" => static (e, v) => TryAssignPe("pe.imphash")(e.Pe ??= new Pe(),v),
				"FilePeImphash" => static (e, v) => TryAssignPe("pe.imphash")(e.Pe ??= new Pe(),v),
				"file.pe.import_hash" => static (e, v) => TryAssignPe("pe.import_hash")(e.Pe ??= new Pe(),v),
				"FilePeImportHash" => static (e, v) => TryAssignPe("pe.import_hash")(e.Pe ??= new Pe(),v),
				"file.pe.imports_names_entropy" => static (e, v) => TryAssignPe("pe.imports_names_entropy")(e.Pe ??= new Pe(),v),
				"FilePeImportsNamesEntropy" => static (e, v) => TryAssignPe("pe.imports_names_entropy")(e.Pe ??= new Pe(),v),
				"file.pe.imports_names_var_entropy" => static (e, v) => TryAssignPe("pe.imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"FilePeImportsNamesVarEntropy" => static (e, v) => TryAssignPe("pe.imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"file.pe.original_file_name" => static (e, v) => TryAssignPe("pe.original_file_name")(e.Pe ??= new Pe(),v),
				"FilePeOriginalFileName" => static (e, v) => TryAssignPe("pe.original_file_name")(e.Pe ??= new Pe(),v),
				"file.pe.pehash" => static (e, v) => TryAssignPe("pe.pehash")(e.Pe ??= new Pe(),v),
				"FilePePehash" => static (e, v) => TryAssignPe("pe.pehash")(e.Pe ??= new Pe(),v),
				"file.pe.product" => static (e, v) => TryAssignPe("pe.product")(e.Pe ??= new Pe(),v),
				"FilePeProduct" => static (e, v) => TryAssignPe("pe.product")(e.Pe ??= new Pe(),v),
				"file.x509.issuer.distinguished_name" => static (e, v) => TryAssignX509("x509.issuer.distinguished_name")(e.X509 ??= new X509(),v),
				"FileX509IssuerDistinguishedName" => static (e, v) => TryAssignX509("x509.issuer.distinguished_name")(e.X509 ??= new X509(),v),
				"file.x509.not_after" => static (e, v) => TryAssignX509("x509.not_after")(e.X509 ??= new X509(),v),
				"FileX509NotAfter" => static (e, v) => TryAssignX509("x509.not_after")(e.X509 ??= new X509(),v),
				"file.x509.not_before" => static (e, v) => TryAssignX509("x509.not_before")(e.X509 ??= new X509(),v),
				"FileX509NotBefore" => static (e, v) => TryAssignX509("x509.not_before")(e.X509 ??= new X509(),v),
				"file.x509.public_key_algorithm" => static (e, v) => TryAssignX509("x509.public_key_algorithm")(e.X509 ??= new X509(),v),
				"FileX509PublicKeyAlgorithm" => static (e, v) => TryAssignX509("x509.public_key_algorithm")(e.X509 ??= new X509(),v),
				"file.x509.public_key_curve" => static (e, v) => TryAssignX509("x509.public_key_curve")(e.X509 ??= new X509(),v),
				"FileX509PublicKeyCurve" => static (e, v) => TryAssignX509("x509.public_key_curve")(e.X509 ??= new X509(),v),
				"file.x509.public_key_exponent" => static (e, v) => TryAssignX509("x509.public_key_exponent")(e.X509 ??= new X509(),v),
				"FileX509PublicKeyExponent" => static (e, v) => TryAssignX509("x509.public_key_exponent")(e.X509 ??= new X509(),v),
				"file.x509.public_key_size" => static (e, v) => TryAssignX509("x509.public_key_size")(e.X509 ??= new X509(),v),
				"FileX509PublicKeySize" => static (e, v) => TryAssignX509("x509.public_key_size")(e.X509 ??= new X509(),v),
				"file.x509.serial_number" => static (e, v) => TryAssignX509("x509.serial_number")(e.X509 ??= new X509(),v),
				"FileX509SerialNumber" => static (e, v) => TryAssignX509("x509.serial_number")(e.X509 ??= new X509(),v),
				"file.x509.signature_algorithm" => static (e, v) => TryAssignX509("x509.signature_algorithm")(e.X509 ??= new X509(),v),
				"FileX509SignatureAlgorithm" => static (e, v) => TryAssignX509("x509.signature_algorithm")(e.X509 ??= new X509(),v),
				"file.x509.subject.distinguished_name" => static (e, v) => TryAssignX509("x509.subject.distinguished_name")(e.X509 ??= new X509(),v),
				"FileX509SubjectDistinguishedName" => static (e, v) => TryAssignX509("x509.subject.distinguished_name")(e.X509 ??= new X509(),v),
				"file.x509.version_number" => static (e, v) => TryAssignX509("x509.version_number")(e.X509 ??= new X509(),v),
				"FileX509VersionNumber" => static (e, v) => TryAssignX509("x509.version_number")(e.X509 ??= new X509(),v),
				"file.code_signature.digest_algorithm" => static (e, v) => TryAssignCodeSignature("code_signature.digest_algorithm")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureDigestAlgorithm" => static (e, v) => TryAssignCodeSignature("code_signature.digest_algorithm")(e.CodeSignature ??= new CodeSignature(),v),
				"file.code_signature.exists" => static (e, v) => TryAssignCodeSignature("code_signature.exists")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureExists" => static (e, v) => TryAssignCodeSignature("code_signature.exists")(e.CodeSignature ??= new CodeSignature(),v),
				"file.code_signature.flags" => static (e, v) => TryAssignCodeSignature("code_signature.flags")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureFlags" => static (e, v) => TryAssignCodeSignature("code_signature.flags")(e.CodeSignature ??= new CodeSignature(),v),
				"file.code_signature.signing_id" => static (e, v) => TryAssignCodeSignature("code_signature.signing_id")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureSigningId" => static (e, v) => TryAssignCodeSignature("code_signature.signing_id")(e.CodeSignature ??= new CodeSignature(),v),
				"file.code_signature.status" => static (e, v) => TryAssignCodeSignature("code_signature.status")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureStatus" => static (e, v) => TryAssignCodeSignature("code_signature.status")(e.CodeSignature ??= new CodeSignature(),v),
				"file.code_signature.subject_name" => static (e, v) => TryAssignCodeSignature("code_signature.subject_name")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureSubjectName" => static (e, v) => TryAssignCodeSignature("code_signature.subject_name")(e.CodeSignature ??= new CodeSignature(),v),
				"file.code_signature.team_id" => static (e, v) => TryAssignCodeSignature("code_signature.team_id")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureTeamId" => static (e, v) => TryAssignCodeSignature("code_signature.team_id")(e.CodeSignature ??= new CodeSignature(),v),
				"file.code_signature.timestamp" => static (e, v) => TryAssignCodeSignature("code_signature.timestamp")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureTimestamp" => static (e, v) => TryAssignCodeSignature("code_signature.timestamp")(e.CodeSignature ??= new CodeSignature(),v),
				"file.code_signature.trusted" => static (e, v) => TryAssignCodeSignature("code_signature.trusted")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureTrusted" => static (e, v) => TryAssignCodeSignature("code_signature.trusted")(e.CodeSignature ??= new CodeSignature(),v),
				"file.code_signature.valid" => static (e, v) => TryAssignCodeSignature("code_signature.valid")(e.CodeSignature ??= new CodeSignature(),v),
				"FileCodeSignatureValid" => static (e, v) => TryAssignCodeSignature("code_signature.valid")(e.CodeSignature ??= new CodeSignature(),v),
				"file.elf.architecture" => static (e, v) => TryAssignElf("elf.architecture")(e.Elf ??= new Elf(),v),
				"FileElfArchitecture" => static (e, v) => TryAssignElf("elf.architecture")(e.Elf ??= new Elf(),v),
				"file.elf.byte_order" => static (e, v) => TryAssignElf("elf.byte_order")(e.Elf ??= new Elf(),v),
				"FileElfByteOrder" => static (e, v) => TryAssignElf("elf.byte_order")(e.Elf ??= new Elf(),v),
				"file.elf.cpu_type" => static (e, v) => TryAssignElf("elf.cpu_type")(e.Elf ??= new Elf(),v),
				"FileElfCpuType" => static (e, v) => TryAssignElf("elf.cpu_type")(e.Elf ??= new Elf(),v),
				"file.elf.creation_date" => static (e, v) => TryAssignElf("elf.creation_date")(e.Elf ??= new Elf(),v),
				"FileElfCreationDate" => static (e, v) => TryAssignElf("elf.creation_date")(e.Elf ??= new Elf(),v),
				"file.elf.go_import_hash" => static (e, v) => TryAssignElf("elf.go_import_hash")(e.Elf ??= new Elf(),v),
				"FileElfGoImportHash" => static (e, v) => TryAssignElf("elf.go_import_hash")(e.Elf ??= new Elf(),v),
				"file.elf.go_imports" => static (e, v) => TryAssignElf("elf.go_imports")(e.Elf ??= new Elf(),v),
				"FileElfGoImports" => static (e, v) => TryAssignElf("elf.go_imports")(e.Elf ??= new Elf(),v),
				"file.elf.go_imports_names_entropy" => static (e, v) => TryAssignElf("elf.go_imports_names_entropy")(e.Elf ??= new Elf(),v),
				"FileElfGoImportsNamesEntropy" => static (e, v) => TryAssignElf("elf.go_imports_names_entropy")(e.Elf ??= new Elf(),v),
				"file.elf.go_imports_names_var_entropy" => static (e, v) => TryAssignElf("elf.go_imports_names_var_entropy")(e.Elf ??= new Elf(),v),
				"FileElfGoImportsNamesVarEntropy" => static (e, v) => TryAssignElf("elf.go_imports_names_var_entropy")(e.Elf ??= new Elf(),v),
				"file.elf.go_stripped" => static (e, v) => TryAssignElf("elf.go_stripped")(e.Elf ??= new Elf(),v),
				"FileElfGoStripped" => static (e, v) => TryAssignElf("elf.go_stripped")(e.Elf ??= new Elf(),v),
				"file.elf.header.abi_version" => static (e, v) => TryAssignElf("elf.header.abi_version")(e.Elf ??= new Elf(),v),
				"FileElfHeaderAbiVersion" => static (e, v) => TryAssignElf("elf.header.abi_version")(e.Elf ??= new Elf(),v),
				"file.elf.header.class" => static (e, v) => TryAssignElf("elf.header.class")(e.Elf ??= new Elf(),v),
				"FileElfHeaderClass" => static (e, v) => TryAssignElf("elf.header.class")(e.Elf ??= new Elf(),v),
				"file.elf.header.data" => static (e, v) => TryAssignElf("elf.header.data")(e.Elf ??= new Elf(),v),
				"FileElfHeaderData" => static (e, v) => TryAssignElf("elf.header.data")(e.Elf ??= new Elf(),v),
				"file.elf.header.entrypoint" => static (e, v) => TryAssignElf("elf.header.entrypoint")(e.Elf ??= new Elf(),v),
				"FileElfHeaderEntrypoint" => static (e, v) => TryAssignElf("elf.header.entrypoint")(e.Elf ??= new Elf(),v),
				"file.elf.header.object_version" => static (e, v) => TryAssignElf("elf.header.object_version")(e.Elf ??= new Elf(),v),
				"FileElfHeaderObjectVersion" => static (e, v) => TryAssignElf("elf.header.object_version")(e.Elf ??= new Elf(),v),
				"file.elf.header.os_abi" => static (e, v) => TryAssignElf("elf.header.os_abi")(e.Elf ??= new Elf(),v),
				"FileElfHeaderOsAbi" => static (e, v) => TryAssignElf("elf.header.os_abi")(e.Elf ??= new Elf(),v),
				"file.elf.header.type" => static (e, v) => TryAssignElf("elf.header.type")(e.Elf ??= new Elf(),v),
				"FileElfHeaderType" => static (e, v) => TryAssignElf("elf.header.type")(e.Elf ??= new Elf(),v),
				"file.elf.header.version" => static (e, v) => TryAssignElf("elf.header.version")(e.Elf ??= new Elf(),v),
				"FileElfHeaderVersion" => static (e, v) => TryAssignElf("elf.header.version")(e.Elf ??= new Elf(),v),
				"file.elf.import_hash" => static (e, v) => TryAssignElf("elf.import_hash")(e.Elf ??= new Elf(),v),
				"FileElfImportHash" => static (e, v) => TryAssignElf("elf.import_hash")(e.Elf ??= new Elf(),v),
				"file.elf.imports_names_entropy" => static (e, v) => TryAssignElf("elf.imports_names_entropy")(e.Elf ??= new Elf(),v),
				"FileElfImportsNamesEntropy" => static (e, v) => TryAssignElf("elf.imports_names_entropy")(e.Elf ??= new Elf(),v),
				"file.elf.imports_names_var_entropy" => static (e, v) => TryAssignElf("elf.imports_names_var_entropy")(e.Elf ??= new Elf(),v),
				"FileElfImportsNamesVarEntropy" => static (e, v) => TryAssignElf("elf.imports_names_var_entropy")(e.Elf ??= new Elf(),v),
				"file.elf.telfhash" => static (e, v) => TryAssignElf("elf.telfhash")(e.Elf ??= new Elf(),v),
				"FileElfTelfhash" => static (e, v) => TryAssignElf("elf.telfhash")(e.Elf ??= new Elf(),v),
				"file.macho.go_import_hash" => static (e, v) => TryAssignMacho("macho.go_import_hash")(e.Macho ??= new Macho(),v),
				"FileMachoGoImportHash" => static (e, v) => TryAssignMacho("macho.go_import_hash")(e.Macho ??= new Macho(),v),
				"file.macho.go_imports" => static (e, v) => TryAssignMacho("macho.go_imports")(e.Macho ??= new Macho(),v),
				"FileMachoGoImports" => static (e, v) => TryAssignMacho("macho.go_imports")(e.Macho ??= new Macho(),v),
				"file.macho.go_imports_names_entropy" => static (e, v) => TryAssignMacho("macho.go_imports_names_entropy")(e.Macho ??= new Macho(),v),
				"FileMachoGoImportsNamesEntropy" => static (e, v) => TryAssignMacho("macho.go_imports_names_entropy")(e.Macho ??= new Macho(),v),
				"file.macho.go_imports_names_var_entropy" => static (e, v) => TryAssignMacho("macho.go_imports_names_var_entropy")(e.Macho ??= new Macho(),v),
				"FileMachoGoImportsNamesVarEntropy" => static (e, v) => TryAssignMacho("macho.go_imports_names_var_entropy")(e.Macho ??= new Macho(),v),
				"file.macho.go_stripped" => static (e, v) => TryAssignMacho("macho.go_stripped")(e.Macho ??= new Macho(),v),
				"FileMachoGoStripped" => static (e, v) => TryAssignMacho("macho.go_stripped")(e.Macho ??= new Macho(),v),
				"file.macho.import_hash" => static (e, v) => TryAssignMacho("macho.import_hash")(e.Macho ??= new Macho(),v),
				"FileMachoImportHash" => static (e, v) => TryAssignMacho("macho.import_hash")(e.Macho ??= new Macho(),v),
				"file.macho.imports_names_entropy" => static (e, v) => TryAssignMacho("macho.imports_names_entropy")(e.Macho ??= new Macho(),v),
				"FileMachoImportsNamesEntropy" => static (e, v) => TryAssignMacho("macho.imports_names_entropy")(e.Macho ??= new Macho(),v),
				"file.macho.imports_names_var_entropy" => static (e, v) => TryAssignMacho("macho.imports_names_var_entropy")(e.Macho ??= new Macho(),v),
				"FileMachoImportsNamesVarEntropy" => static (e, v) => TryAssignMacho("macho.imports_names_var_entropy")(e.Macho ??= new Macho(),v),
				"file.macho.symhash" => static (e, v) => TryAssignMacho("macho.symhash")(e.Macho ??= new Macho(),v),
				"FileMachoSymhash" => static (e, v) => TryAssignMacho("macho.symhash")(e.Macho ??= new Macho(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetFile(EcsDocument document, string path, object value)
		{
			var assign = TryAssignFile(path);
			if (assign == null) return false;
		
			var entity = document.File ?? new File();
			var assigned = assign(entity, value);
			if (assigned) document.File = entity;
			return assigned;
		}

		public static Func<Geo, object, bool> TryAssignGeo(string path)
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
				"geo.location" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Location = p),
				"GeoLocation" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Location = p),
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
			return assign;
		}
		public static bool TrySetGeo(IGeo document, string path, object value)
		{
			var assign = TryAssignGeo(path);
			if (assign == null) return false;
		
			var entity = document.Geo ?? new Geo();
			var assigned = assign(entity, value);
			if (assigned) document.Geo = entity;
			return assigned;
		}

		public static Func<Group, object, bool> TryAssignGroup(string path)
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
			return assign;
		}
		public static bool TrySetGroup(IGroup document, string path, object value)
		{
			var assign = TryAssignGroup(path);
			if (assign == null) return false;
		
			var entity = document.Group ?? new Group();
			var assigned = assign(entity, value);
			if (assigned) document.Group = entity;
			return assigned;
		}

		public static Func<Hash, object, bool> TryAssignHash(string path)
		{
			Func<Hash, object, bool> assign = path switch
			{
				"hash.cdhash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Cdhash = p),
				"HashCdhash" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Cdhash = p),
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
			return assign;
		}
		public static bool TrySetHash(IHash document, string path, object value)
		{
			var assign = TryAssignHash(path);
			if (assign == null) return false;
		
			var entity = document.Hash ?? new Hash();
			var assigned = assign(entity, value);
			if (assigned) document.Hash = entity;
			return assigned;
		}

		public static Func<Host, object, bool> TryAssignHost(string path)
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
				"host.geo.city_name" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"HostGeoCityName" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"host.geo.continent_code" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"HostGeoContinentCode" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"host.geo.continent_name" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"HostGeoContinentName" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"host.geo.country_iso_code" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"HostGeoCountryIsoCode" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"host.geo.country_name" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"HostGeoCountryName" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"host.geo.location" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"HostGeoLocation" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"host.geo.name" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"HostGeoName" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"host.geo.postal_code" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"HostGeoPostalCode" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"host.geo.region_iso_code" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"HostGeoRegionIsoCode" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"host.geo.region_name" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"HostGeoRegionName" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"host.geo.timezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"HostGeoTimezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"host.os.family" => static (e, v) => TryAssignOs("os.family")(e.Os ??= new Os(),v),
				"HostOsFamily" => static (e, v) => TryAssignOs("os.family")(e.Os ??= new Os(),v),
				"host.os.full" => static (e, v) => TryAssignOs("os.full")(e.Os ??= new Os(),v),
				"HostOsFull" => static (e, v) => TryAssignOs("os.full")(e.Os ??= new Os(),v),
				"host.os.kernel" => static (e, v) => TryAssignOs("os.kernel")(e.Os ??= new Os(),v),
				"HostOsKernel" => static (e, v) => TryAssignOs("os.kernel")(e.Os ??= new Os(),v),
				"host.os.name" => static (e, v) => TryAssignOs("os.name")(e.Os ??= new Os(),v),
				"HostOsName" => static (e, v) => TryAssignOs("os.name")(e.Os ??= new Os(),v),
				"host.os.platform" => static (e, v) => TryAssignOs("os.platform")(e.Os ??= new Os(),v),
				"HostOsPlatform" => static (e, v) => TryAssignOs("os.platform")(e.Os ??= new Os(),v),
				"host.os.type" => static (e, v) => TryAssignOs("os.type")(e.Os ??= new Os(),v),
				"HostOsType" => static (e, v) => TryAssignOs("os.type")(e.Os ??= new Os(),v),
				"host.os.version" => static (e, v) => TryAssignOs("os.version")(e.Os ??= new Os(),v),
				"HostOsVersion" => static (e, v) => TryAssignOs("os.version")(e.Os ??= new Os(),v),
				"host.risk.calculated_level" => static (e, v) => TryAssignRisk("risk.calculated_level")(e.Risk ??= new Risk(),v),
				"HostRiskCalculatedLevel" => static (e, v) => TryAssignRisk("risk.calculated_level")(e.Risk ??= new Risk(),v),
				"host.risk.calculated_score" => static (e, v) => TryAssignRisk("risk.calculated_score")(e.Risk ??= new Risk(),v),
				"HostRiskCalculatedScore" => static (e, v) => TryAssignRisk("risk.calculated_score")(e.Risk ??= new Risk(),v),
				"host.risk.calculated_score_norm" => static (e, v) => TryAssignRisk("risk.calculated_score_norm")(e.Risk ??= new Risk(),v),
				"HostRiskCalculatedScoreNorm" => static (e, v) => TryAssignRisk("risk.calculated_score_norm")(e.Risk ??= new Risk(),v),
				"host.risk.static_level" => static (e, v) => TryAssignRisk("risk.static_level")(e.Risk ??= new Risk(),v),
				"HostRiskStaticLevel" => static (e, v) => TryAssignRisk("risk.static_level")(e.Risk ??= new Risk(),v),
				"host.risk.static_score" => static (e, v) => TryAssignRisk("risk.static_score")(e.Risk ??= new Risk(),v),
				"HostRiskStaticScore" => static (e, v) => TryAssignRisk("risk.static_score")(e.Risk ??= new Risk(),v),
				"host.risk.static_score_norm" => static (e, v) => TryAssignRisk("risk.static_score_norm")(e.Risk ??= new Risk(),v),
				"HostRiskStaticScoreNorm" => static (e, v) => TryAssignRisk("risk.static_score_norm")(e.Risk ??= new Risk(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetHost(EcsDocument document, string path, object value)
		{
			var assign = TryAssignHost(path);
			if (assign == null) return false;
		
			var entity = document.Host ?? new Host();
			var assigned = assign(entity, value);
			if (assigned) document.Host = entity;
			return assigned;
		}

		public static Func<Http, object, bool> TryAssignHttp(string path)
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
			return assign;
		}
		public static bool TrySetHttp(EcsDocument document, string path, object value)
		{
			var assign = TryAssignHttp(path);
			if (assign == null) return false;
		
			var entity = document.Http ?? new Http();
			var assigned = assign(entity, value);
			if (assigned) document.Http = entity;
			return assigned;
		}

		public static Func<Interface, object, bool> TryAssignInterface(string path)
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
			return assign;
		}
		public static bool TrySetInterface(EcsDocument document, string path, object value)
		{
			var assign = TryAssignInterface(path);
			if (assign == null) return false;
		
			var entity = document.Interface ?? new Interface();
			var assigned = assign(entity, value);
			if (assigned) document.Interface = entity;
			return assigned;
		}

		public static Func<Log, object, bool> TryAssignLog(string path)
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
			return assign;
		}
		public static bool TrySetLog(EcsDocument document, string path, object value)
		{
			var assign = TryAssignLog(path);
			if (assign == null) return false;
		
			var entity = document.Log ?? new Log();
			var assigned = assign(entity, value);
			if (assigned) document.Log = entity;
			return assigned;
		}

		public static Func<Macho, object, bool> TryAssignMacho(string path)
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
			return assign;
		}
		public static bool TrySetMacho(IMacho document, string path, object value)
		{
			var assign = TryAssignMacho(path);
			if (assign == null) return false;
		
			var entity = document.Macho ?? new Macho();
			var assigned = assign(entity, value);
			if (assigned) document.Macho = entity;
			return assigned;
		}

		public static Func<Network, object, bool> TryAssignNetwork(string path)
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
				"network.vlan.id" => static (e, v) => TryAssignVlan("vlan.id")(e.Vlan ??= new Vlan(),v),
				"NetworkVlanId" => static (e, v) => TryAssignVlan("vlan.id")(e.Vlan ??= new Vlan(),v),
				"network.vlan.name" => static (e, v) => TryAssignVlan("vlan.name")(e.Vlan ??= new Vlan(),v),
				"NetworkVlanName" => static (e, v) => TryAssignVlan("vlan.name")(e.Vlan ??= new Vlan(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetNetwork(EcsDocument document, string path, object value)
		{
			var assign = TryAssignNetwork(path);
			if (assign == null) return false;
		
			var entity = document.Network ?? new Network();
			var assigned = assign(entity, value);
			if (assigned) document.Network = entity;
			return assigned;
		}

		public static Func<Observer, object, bool> TryAssignObserver(string path)
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
				"observer.geo.city_name" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"ObserverGeoCityName" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"observer.geo.continent_code" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"ObserverGeoContinentCode" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"observer.geo.continent_name" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"ObserverGeoContinentName" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"observer.geo.country_iso_code" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"ObserverGeoCountryIsoCode" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"observer.geo.country_name" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"ObserverGeoCountryName" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"observer.geo.location" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"ObserverGeoLocation" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"observer.geo.name" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"ObserverGeoName" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"observer.geo.postal_code" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"ObserverGeoPostalCode" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"observer.geo.region_iso_code" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"ObserverGeoRegionIsoCode" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"observer.geo.region_name" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"ObserverGeoRegionName" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"observer.geo.timezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"ObserverGeoTimezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"observer.os.family" => static (e, v) => TryAssignOs("os.family")(e.Os ??= new Os(),v),
				"ObserverOsFamily" => static (e, v) => TryAssignOs("os.family")(e.Os ??= new Os(),v),
				"observer.os.full" => static (e, v) => TryAssignOs("os.full")(e.Os ??= new Os(),v),
				"ObserverOsFull" => static (e, v) => TryAssignOs("os.full")(e.Os ??= new Os(),v),
				"observer.os.kernel" => static (e, v) => TryAssignOs("os.kernel")(e.Os ??= new Os(),v),
				"ObserverOsKernel" => static (e, v) => TryAssignOs("os.kernel")(e.Os ??= new Os(),v),
				"observer.os.name" => static (e, v) => TryAssignOs("os.name")(e.Os ??= new Os(),v),
				"ObserverOsName" => static (e, v) => TryAssignOs("os.name")(e.Os ??= new Os(),v),
				"observer.os.platform" => static (e, v) => TryAssignOs("os.platform")(e.Os ??= new Os(),v),
				"ObserverOsPlatform" => static (e, v) => TryAssignOs("os.platform")(e.Os ??= new Os(),v),
				"observer.os.type" => static (e, v) => TryAssignOs("os.type")(e.Os ??= new Os(),v),
				"ObserverOsType" => static (e, v) => TryAssignOs("os.type")(e.Os ??= new Os(),v),
				"observer.os.version" => static (e, v) => TryAssignOs("os.version")(e.Os ??= new Os(),v),
				"ObserverOsVersion" => static (e, v) => TryAssignOs("os.version")(e.Os ??= new Os(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetObserver(EcsDocument document, string path, object value)
		{
			var assign = TryAssignObserver(path);
			if (assign == null) return false;
		
			var entity = document.Observer ?? new Observer();
			var assigned = assign(entity, value);
			if (assigned) document.Observer = entity;
			return assigned;
		}

		public static Func<Orchestrator, object, bool> TryAssignOrchestrator(string path)
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
			return assign;
		}
		public static bool TrySetOrchestrator(EcsDocument document, string path, object value)
		{
			var assign = TryAssignOrchestrator(path);
			if (assign == null) return false;
		
			var entity = document.Orchestrator ?? new Orchestrator();
			var assigned = assign(entity, value);
			if (assigned) document.Orchestrator = entity;
			return assigned;
		}

		public static Func<Organization, object, bool> TryAssignOrganization(string path)
		{
			Func<Organization, object, bool> assign = path switch
			{
				"organization.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"OrganizationId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"organization.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"OrganizationName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				_ => null
			};
			return assign;
		}
		public static bool TrySetOrganization(EcsDocument document, string path, object value)
		{
			var assign = TryAssignOrganization(path);
			if (assign == null) return false;
		
			var entity = document.Organization ?? new Organization();
			var assigned = assign(entity, value);
			if (assigned) document.Organization = entity;
			return assigned;
		}

		public static Func<Os, object, bool> TryAssignOs(string path)
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
			return assign;
		}
		public static bool TrySetOs(IOs document, string path, object value)
		{
			var assign = TryAssignOs(path);
			if (assign == null) return false;
		
			var entity = document.Os ?? new Os();
			var assigned = assign(entity, value);
			if (assigned) document.Os = entity;
			return assigned;
		}

		public static Func<Package, object, bool> TryAssignPackage(string path)
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
			return assign;
		}
		public static bool TrySetPackage(EcsDocument document, string path, object value)
		{
			var assign = TryAssignPackage(path);
			if (assign == null) return false;
		
			var entity = document.Package ?? new Package();
			var assigned = assign(entity, value);
			if (assigned) document.Package = entity;
			return assigned;
		}

		public static Func<Pe, object, bool> TryAssignPe(string path)
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
			return assign;
		}
		public static bool TrySetPe(IPe document, string path, object value)
		{
			var assign = TryAssignPe(path);
			if (assign == null) return false;
		
			var entity = document.Pe ?? new Pe();
			var assigned = assign(entity, value);
			if (assigned) document.Pe = entity;
			return assigned;
		}

		public static Func<Process, object, bool> TryAssignProcess(string path)
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
				"process.group.domain" => static (e, v) => TryAssignGroup("group.domain")(e.Group ??= new Group(),v),
				"ProcessGroupDomain" => static (e, v) => TryAssignGroup("group.domain")(e.Group ??= new Group(),v),
				"process.group.id" => static (e, v) => TryAssignGroup("group.id")(e.Group ??= new Group(),v),
				"ProcessGroupId" => static (e, v) => TryAssignGroup("group.id")(e.Group ??= new Group(),v),
				"process.group.name" => static (e, v) => TryAssignGroup("group.name")(e.Group ??= new Group(),v),
				"ProcessGroupName" => static (e, v) => TryAssignGroup("group.name")(e.Group ??= new Group(),v),
				"process.real_group.domain" => static (e, v) => TryAssignGroup("real_group.domain")(e.RealGroup ??= new Group(),v),
				"ProcessRealGroupDomain" => static (e, v) => TryAssignGroup("real_group.domain")(e.RealGroup ??= new Group(),v),
				"process.real_group.id" => static (e, v) => TryAssignGroup("real_group.id")(e.RealGroup ??= new Group(),v),
				"ProcessRealGroupId" => static (e, v) => TryAssignGroup("real_group.id")(e.RealGroup ??= new Group(),v),
				"process.real_group.name" => static (e, v) => TryAssignGroup("real_group.name")(e.RealGroup ??= new Group(),v),
				"ProcessRealGroupName" => static (e, v) => TryAssignGroup("real_group.name")(e.RealGroup ??= new Group(),v),
				"process.saved_group.domain" => static (e, v) => TryAssignGroup("saved_group.domain")(e.SavedGroup ??= new Group(),v),
				"ProcessSavedGroupDomain" => static (e, v) => TryAssignGroup("saved_group.domain")(e.SavedGroup ??= new Group(),v),
				"process.saved_group.id" => static (e, v) => TryAssignGroup("saved_group.id")(e.SavedGroup ??= new Group(),v),
				"ProcessSavedGroupId" => static (e, v) => TryAssignGroup("saved_group.id")(e.SavedGroup ??= new Group(),v),
				"process.saved_group.name" => static (e, v) => TryAssignGroup("saved_group.name")(e.SavedGroup ??= new Group(),v),
				"ProcessSavedGroupName" => static (e, v) => TryAssignGroup("saved_group.name")(e.SavedGroup ??= new Group(),v),
				"process.hash.cdhash" => static (e, v) => TryAssignHash("hash.cdhash")(e.Hash ??= new Hash(),v),
				"ProcessHashCdhash" => static (e, v) => TryAssignHash("hash.cdhash")(e.Hash ??= new Hash(),v),
				"process.hash.md5" => static (e, v) => TryAssignHash("hash.md5")(e.Hash ??= new Hash(),v),
				"ProcessHashMd5" => static (e, v) => TryAssignHash("hash.md5")(e.Hash ??= new Hash(),v),
				"process.hash.sha1" => static (e, v) => TryAssignHash("hash.sha1")(e.Hash ??= new Hash(),v),
				"ProcessHashSha1" => static (e, v) => TryAssignHash("hash.sha1")(e.Hash ??= new Hash(),v),
				"process.hash.sha256" => static (e, v) => TryAssignHash("hash.sha256")(e.Hash ??= new Hash(),v),
				"ProcessHashSha256" => static (e, v) => TryAssignHash("hash.sha256")(e.Hash ??= new Hash(),v),
				"process.hash.sha384" => static (e, v) => TryAssignHash("hash.sha384")(e.Hash ??= new Hash(),v),
				"ProcessHashSha384" => static (e, v) => TryAssignHash("hash.sha384")(e.Hash ??= new Hash(),v),
				"process.hash.sha512" => static (e, v) => TryAssignHash("hash.sha512")(e.Hash ??= new Hash(),v),
				"ProcessHashSha512" => static (e, v) => TryAssignHash("hash.sha512")(e.Hash ??= new Hash(),v),
				"process.hash.ssdeep" => static (e, v) => TryAssignHash("hash.ssdeep")(e.Hash ??= new Hash(),v),
				"ProcessHashSsdeep" => static (e, v) => TryAssignHash("hash.ssdeep")(e.Hash ??= new Hash(),v),
				"process.hash.tlsh" => static (e, v) => TryAssignHash("hash.tlsh")(e.Hash ??= new Hash(),v),
				"ProcessHashTlsh" => static (e, v) => TryAssignHash("hash.tlsh")(e.Hash ??= new Hash(),v),
				"process.pe.architecture" => static (e, v) => TryAssignPe("pe.architecture")(e.Pe ??= new Pe(),v),
				"ProcessPeArchitecture" => static (e, v) => TryAssignPe("pe.architecture")(e.Pe ??= new Pe(),v),
				"process.pe.company" => static (e, v) => TryAssignPe("pe.company")(e.Pe ??= new Pe(),v),
				"ProcessPeCompany" => static (e, v) => TryAssignPe("pe.company")(e.Pe ??= new Pe(),v),
				"process.pe.description" => static (e, v) => TryAssignPe("pe.description")(e.Pe ??= new Pe(),v),
				"ProcessPeDescription" => static (e, v) => TryAssignPe("pe.description")(e.Pe ??= new Pe(),v),
				"process.pe.file_version" => static (e, v) => TryAssignPe("pe.file_version")(e.Pe ??= new Pe(),v),
				"ProcessPeFileVersion" => static (e, v) => TryAssignPe("pe.file_version")(e.Pe ??= new Pe(),v),
				"process.pe.go_import_hash" => static (e, v) => TryAssignPe("pe.go_import_hash")(e.Pe ??= new Pe(),v),
				"ProcessPeGoImportHash" => static (e, v) => TryAssignPe("pe.go_import_hash")(e.Pe ??= new Pe(),v),
				"process.pe.go_imports" => static (e, v) => TryAssignPe("pe.go_imports")(e.Pe ??= new Pe(),v),
				"ProcessPeGoImports" => static (e, v) => TryAssignPe("pe.go_imports")(e.Pe ??= new Pe(),v),
				"process.pe.go_imports_names_entropy" => static (e, v) => TryAssignPe("pe.go_imports_names_entropy")(e.Pe ??= new Pe(),v),
				"ProcessPeGoImportsNamesEntropy" => static (e, v) => TryAssignPe("pe.go_imports_names_entropy")(e.Pe ??= new Pe(),v),
				"process.pe.go_imports_names_var_entropy" => static (e, v) => TryAssignPe("pe.go_imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"ProcessPeGoImportsNamesVarEntropy" => static (e, v) => TryAssignPe("pe.go_imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"process.pe.go_stripped" => static (e, v) => TryAssignPe("pe.go_stripped")(e.Pe ??= new Pe(),v),
				"ProcessPeGoStripped" => static (e, v) => TryAssignPe("pe.go_stripped")(e.Pe ??= new Pe(),v),
				"process.pe.imphash" => static (e, v) => TryAssignPe("pe.imphash")(e.Pe ??= new Pe(),v),
				"ProcessPeImphash" => static (e, v) => TryAssignPe("pe.imphash")(e.Pe ??= new Pe(),v),
				"process.pe.import_hash" => static (e, v) => TryAssignPe("pe.import_hash")(e.Pe ??= new Pe(),v),
				"ProcessPeImportHash" => static (e, v) => TryAssignPe("pe.import_hash")(e.Pe ??= new Pe(),v),
				"process.pe.imports_names_entropy" => static (e, v) => TryAssignPe("pe.imports_names_entropy")(e.Pe ??= new Pe(),v),
				"ProcessPeImportsNamesEntropy" => static (e, v) => TryAssignPe("pe.imports_names_entropy")(e.Pe ??= new Pe(),v),
				"process.pe.imports_names_var_entropy" => static (e, v) => TryAssignPe("pe.imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"ProcessPeImportsNamesVarEntropy" => static (e, v) => TryAssignPe("pe.imports_names_var_entropy")(e.Pe ??= new Pe(),v),
				"process.pe.original_file_name" => static (e, v) => TryAssignPe("pe.original_file_name")(e.Pe ??= new Pe(),v),
				"ProcessPeOriginalFileName" => static (e, v) => TryAssignPe("pe.original_file_name")(e.Pe ??= new Pe(),v),
				"process.pe.pehash" => static (e, v) => TryAssignPe("pe.pehash")(e.Pe ??= new Pe(),v),
				"ProcessPePehash" => static (e, v) => TryAssignPe("pe.pehash")(e.Pe ??= new Pe(),v),
				"process.pe.product" => static (e, v) => TryAssignPe("pe.product")(e.Pe ??= new Pe(),v),
				"ProcessPeProduct" => static (e, v) => TryAssignPe("pe.product")(e.Pe ??= new Pe(),v),
				"process.code_signature.digest_algorithm" => static (e, v) => TryAssignCodeSignature("code_signature.digest_algorithm")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureDigestAlgorithm" => static (e, v) => TryAssignCodeSignature("code_signature.digest_algorithm")(e.CodeSignature ??= new CodeSignature(),v),
				"process.code_signature.exists" => static (e, v) => TryAssignCodeSignature("code_signature.exists")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureExists" => static (e, v) => TryAssignCodeSignature("code_signature.exists")(e.CodeSignature ??= new CodeSignature(),v),
				"process.code_signature.flags" => static (e, v) => TryAssignCodeSignature("code_signature.flags")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureFlags" => static (e, v) => TryAssignCodeSignature("code_signature.flags")(e.CodeSignature ??= new CodeSignature(),v),
				"process.code_signature.signing_id" => static (e, v) => TryAssignCodeSignature("code_signature.signing_id")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureSigningId" => static (e, v) => TryAssignCodeSignature("code_signature.signing_id")(e.CodeSignature ??= new CodeSignature(),v),
				"process.code_signature.status" => static (e, v) => TryAssignCodeSignature("code_signature.status")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureStatus" => static (e, v) => TryAssignCodeSignature("code_signature.status")(e.CodeSignature ??= new CodeSignature(),v),
				"process.code_signature.subject_name" => static (e, v) => TryAssignCodeSignature("code_signature.subject_name")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureSubjectName" => static (e, v) => TryAssignCodeSignature("code_signature.subject_name")(e.CodeSignature ??= new CodeSignature(),v),
				"process.code_signature.team_id" => static (e, v) => TryAssignCodeSignature("code_signature.team_id")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureTeamId" => static (e, v) => TryAssignCodeSignature("code_signature.team_id")(e.CodeSignature ??= new CodeSignature(),v),
				"process.code_signature.timestamp" => static (e, v) => TryAssignCodeSignature("code_signature.timestamp")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureTimestamp" => static (e, v) => TryAssignCodeSignature("code_signature.timestamp")(e.CodeSignature ??= new CodeSignature(),v),
				"process.code_signature.trusted" => static (e, v) => TryAssignCodeSignature("code_signature.trusted")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureTrusted" => static (e, v) => TryAssignCodeSignature("code_signature.trusted")(e.CodeSignature ??= new CodeSignature(),v),
				"process.code_signature.valid" => static (e, v) => TryAssignCodeSignature("code_signature.valid")(e.CodeSignature ??= new CodeSignature(),v),
				"ProcessCodeSignatureValid" => static (e, v) => TryAssignCodeSignature("code_signature.valid")(e.CodeSignature ??= new CodeSignature(),v),
				"process.elf.architecture" => static (e, v) => TryAssignElf("elf.architecture")(e.Elf ??= new Elf(),v),
				"ProcessElfArchitecture" => static (e, v) => TryAssignElf("elf.architecture")(e.Elf ??= new Elf(),v),
				"process.elf.byte_order" => static (e, v) => TryAssignElf("elf.byte_order")(e.Elf ??= new Elf(),v),
				"ProcessElfByteOrder" => static (e, v) => TryAssignElf("elf.byte_order")(e.Elf ??= new Elf(),v),
				"process.elf.cpu_type" => static (e, v) => TryAssignElf("elf.cpu_type")(e.Elf ??= new Elf(),v),
				"ProcessElfCpuType" => static (e, v) => TryAssignElf("elf.cpu_type")(e.Elf ??= new Elf(),v),
				"process.elf.creation_date" => static (e, v) => TryAssignElf("elf.creation_date")(e.Elf ??= new Elf(),v),
				"ProcessElfCreationDate" => static (e, v) => TryAssignElf("elf.creation_date")(e.Elf ??= new Elf(),v),
				"process.elf.go_import_hash" => static (e, v) => TryAssignElf("elf.go_import_hash")(e.Elf ??= new Elf(),v),
				"ProcessElfGoImportHash" => static (e, v) => TryAssignElf("elf.go_import_hash")(e.Elf ??= new Elf(),v),
				"process.elf.go_imports" => static (e, v) => TryAssignElf("elf.go_imports")(e.Elf ??= new Elf(),v),
				"ProcessElfGoImports" => static (e, v) => TryAssignElf("elf.go_imports")(e.Elf ??= new Elf(),v),
				"process.elf.go_imports_names_entropy" => static (e, v) => TryAssignElf("elf.go_imports_names_entropy")(e.Elf ??= new Elf(),v),
				"ProcessElfGoImportsNamesEntropy" => static (e, v) => TryAssignElf("elf.go_imports_names_entropy")(e.Elf ??= new Elf(),v),
				"process.elf.go_imports_names_var_entropy" => static (e, v) => TryAssignElf("elf.go_imports_names_var_entropy")(e.Elf ??= new Elf(),v),
				"ProcessElfGoImportsNamesVarEntropy" => static (e, v) => TryAssignElf("elf.go_imports_names_var_entropy")(e.Elf ??= new Elf(),v),
				"process.elf.go_stripped" => static (e, v) => TryAssignElf("elf.go_stripped")(e.Elf ??= new Elf(),v),
				"ProcessElfGoStripped" => static (e, v) => TryAssignElf("elf.go_stripped")(e.Elf ??= new Elf(),v),
				"process.elf.header.abi_version" => static (e, v) => TryAssignElf("elf.header.abi_version")(e.Elf ??= new Elf(),v),
				"ProcessElfHeaderAbiVersion" => static (e, v) => TryAssignElf("elf.header.abi_version")(e.Elf ??= new Elf(),v),
				"process.elf.header.class" => static (e, v) => TryAssignElf("elf.header.class")(e.Elf ??= new Elf(),v),
				"ProcessElfHeaderClass" => static (e, v) => TryAssignElf("elf.header.class")(e.Elf ??= new Elf(),v),
				"process.elf.header.data" => static (e, v) => TryAssignElf("elf.header.data")(e.Elf ??= new Elf(),v),
				"ProcessElfHeaderData" => static (e, v) => TryAssignElf("elf.header.data")(e.Elf ??= new Elf(),v),
				"process.elf.header.entrypoint" => static (e, v) => TryAssignElf("elf.header.entrypoint")(e.Elf ??= new Elf(),v),
				"ProcessElfHeaderEntrypoint" => static (e, v) => TryAssignElf("elf.header.entrypoint")(e.Elf ??= new Elf(),v),
				"process.elf.header.object_version" => static (e, v) => TryAssignElf("elf.header.object_version")(e.Elf ??= new Elf(),v),
				"ProcessElfHeaderObjectVersion" => static (e, v) => TryAssignElf("elf.header.object_version")(e.Elf ??= new Elf(),v),
				"process.elf.header.os_abi" => static (e, v) => TryAssignElf("elf.header.os_abi")(e.Elf ??= new Elf(),v),
				"ProcessElfHeaderOsAbi" => static (e, v) => TryAssignElf("elf.header.os_abi")(e.Elf ??= new Elf(),v),
				"process.elf.header.type" => static (e, v) => TryAssignElf("elf.header.type")(e.Elf ??= new Elf(),v),
				"ProcessElfHeaderType" => static (e, v) => TryAssignElf("elf.header.type")(e.Elf ??= new Elf(),v),
				"process.elf.header.version" => static (e, v) => TryAssignElf("elf.header.version")(e.Elf ??= new Elf(),v),
				"ProcessElfHeaderVersion" => static (e, v) => TryAssignElf("elf.header.version")(e.Elf ??= new Elf(),v),
				"process.elf.import_hash" => static (e, v) => TryAssignElf("elf.import_hash")(e.Elf ??= new Elf(),v),
				"ProcessElfImportHash" => static (e, v) => TryAssignElf("elf.import_hash")(e.Elf ??= new Elf(),v),
				"process.elf.imports_names_entropy" => static (e, v) => TryAssignElf("elf.imports_names_entropy")(e.Elf ??= new Elf(),v),
				"ProcessElfImportsNamesEntropy" => static (e, v) => TryAssignElf("elf.imports_names_entropy")(e.Elf ??= new Elf(),v),
				"process.elf.imports_names_var_entropy" => static (e, v) => TryAssignElf("elf.imports_names_var_entropy")(e.Elf ??= new Elf(),v),
				"ProcessElfImportsNamesVarEntropy" => static (e, v) => TryAssignElf("elf.imports_names_var_entropy")(e.Elf ??= new Elf(),v),
				"process.elf.telfhash" => static (e, v) => TryAssignElf("elf.telfhash")(e.Elf ??= new Elf(),v),
				"ProcessElfTelfhash" => static (e, v) => TryAssignElf("elf.telfhash")(e.Elf ??= new Elf(),v),
				"process.macho.go_import_hash" => static (e, v) => TryAssignMacho("macho.go_import_hash")(e.Macho ??= new Macho(),v),
				"ProcessMachoGoImportHash" => static (e, v) => TryAssignMacho("macho.go_import_hash")(e.Macho ??= new Macho(),v),
				"process.macho.go_imports" => static (e, v) => TryAssignMacho("macho.go_imports")(e.Macho ??= new Macho(),v),
				"ProcessMachoGoImports" => static (e, v) => TryAssignMacho("macho.go_imports")(e.Macho ??= new Macho(),v),
				"process.macho.go_imports_names_entropy" => static (e, v) => TryAssignMacho("macho.go_imports_names_entropy")(e.Macho ??= new Macho(),v),
				"ProcessMachoGoImportsNamesEntropy" => static (e, v) => TryAssignMacho("macho.go_imports_names_entropy")(e.Macho ??= new Macho(),v),
				"process.macho.go_imports_names_var_entropy" => static (e, v) => TryAssignMacho("macho.go_imports_names_var_entropy")(e.Macho ??= new Macho(),v),
				"ProcessMachoGoImportsNamesVarEntropy" => static (e, v) => TryAssignMacho("macho.go_imports_names_var_entropy")(e.Macho ??= new Macho(),v),
				"process.macho.go_stripped" => static (e, v) => TryAssignMacho("macho.go_stripped")(e.Macho ??= new Macho(),v),
				"ProcessMachoGoStripped" => static (e, v) => TryAssignMacho("macho.go_stripped")(e.Macho ??= new Macho(),v),
				"process.macho.import_hash" => static (e, v) => TryAssignMacho("macho.import_hash")(e.Macho ??= new Macho(),v),
				"ProcessMachoImportHash" => static (e, v) => TryAssignMacho("macho.import_hash")(e.Macho ??= new Macho(),v),
				"process.macho.imports_names_entropy" => static (e, v) => TryAssignMacho("macho.imports_names_entropy")(e.Macho ??= new Macho(),v),
				"ProcessMachoImportsNamesEntropy" => static (e, v) => TryAssignMacho("macho.imports_names_entropy")(e.Macho ??= new Macho(),v),
				"process.macho.imports_names_var_entropy" => static (e, v) => TryAssignMacho("macho.imports_names_var_entropy")(e.Macho ??= new Macho(),v),
				"ProcessMachoImportsNamesVarEntropy" => static (e, v) => TryAssignMacho("macho.imports_names_var_entropy")(e.Macho ??= new Macho(),v),
				"process.macho.symhash" => static (e, v) => TryAssignMacho("macho.symhash")(e.Macho ??= new Macho(),v),
				"ProcessMachoSymhash" => static (e, v) => TryAssignMacho("macho.symhash")(e.Macho ??= new Macho(),v),
				"process.entry_meta.source.address" => static (e, v) => TryAssignSource("source.address")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceAddress" => static (e, v) => TryAssignSource("source.address")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.bytes" => static (e, v) => TryAssignSource("source.bytes")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceBytes" => static (e, v) => TryAssignSource("source.bytes")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.domain" => static (e, v) => TryAssignSource("source.domain")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceDomain" => static (e, v) => TryAssignSource("source.domain")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.ip" => static (e, v) => TryAssignSource("source.ip")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceIp" => static (e, v) => TryAssignSource("source.ip")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.mac" => static (e, v) => TryAssignSource("source.mac")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceMac" => static (e, v) => TryAssignSource("source.mac")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.nat.ip" => static (e, v) => TryAssignSource("source.nat.ip")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceNatIp" => static (e, v) => TryAssignSource("source.nat.ip")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.nat.port" => static (e, v) => TryAssignSource("source.nat.port")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceNatPort" => static (e, v) => TryAssignSource("source.nat.port")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.packets" => static (e, v) => TryAssignSource("source.packets")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourcePackets" => static (e, v) => TryAssignSource("source.packets")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.port" => static (e, v) => TryAssignSource("source.port")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourcePort" => static (e, v) => TryAssignSource("source.port")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.registered_domain" => static (e, v) => TryAssignSource("source.registered_domain")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceRegisteredDomain" => static (e, v) => TryAssignSource("source.registered_domain")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.subdomain" => static (e, v) => TryAssignSource("source.subdomain")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceSubdomain" => static (e, v) => TryAssignSource("source.subdomain")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.top_level_domain" => static (e, v) => TryAssignSource("source.top_level_domain")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceTopLevelDomain" => static (e, v) => TryAssignSource("source.top_level_domain")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.as.number" => static (e, v) => TryAssignSource("source.as.number")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceAsNumber" => static (e, v) => TryAssignSource("source.as.number")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.as.organization.name" => static (e, v) => TryAssignSource("source.as.organization.name")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceAsOrganizationName" => static (e, v) => TryAssignSource("source.as.organization.name")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.city_name" => static (e, v) => TryAssignSource("source.geo.city_name")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoCityName" => static (e, v) => TryAssignSource("source.geo.city_name")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.continent_code" => static (e, v) => TryAssignSource("source.geo.continent_code")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoContinentCode" => static (e, v) => TryAssignSource("source.geo.continent_code")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.continent_name" => static (e, v) => TryAssignSource("source.geo.continent_name")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoContinentName" => static (e, v) => TryAssignSource("source.geo.continent_name")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.country_iso_code" => static (e, v) => TryAssignSource("source.geo.country_iso_code")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoCountryIsoCode" => static (e, v) => TryAssignSource("source.geo.country_iso_code")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.country_name" => static (e, v) => TryAssignSource("source.geo.country_name")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoCountryName" => static (e, v) => TryAssignSource("source.geo.country_name")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.location" => static (e, v) => TryAssignSource("source.geo.location")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoLocation" => static (e, v) => TryAssignSource("source.geo.location")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.name" => static (e, v) => TryAssignSource("source.geo.name")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoName" => static (e, v) => TryAssignSource("source.geo.name")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.postal_code" => static (e, v) => TryAssignSource("source.geo.postal_code")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoPostalCode" => static (e, v) => TryAssignSource("source.geo.postal_code")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.region_iso_code" => static (e, v) => TryAssignSource("source.geo.region_iso_code")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoRegionIsoCode" => static (e, v) => TryAssignSource("source.geo.region_iso_code")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.region_name" => static (e, v) => TryAssignSource("source.geo.region_name")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoRegionName" => static (e, v) => TryAssignSource("source.geo.region_name")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.geo.timezone" => static (e, v) => TryAssignSource("source.geo.timezone")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceGeoTimezone" => static (e, v) => TryAssignSource("source.geo.timezone")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.domain" => static (e, v) => TryAssignSource("source.user.domain")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserDomain" => static (e, v) => TryAssignSource("source.user.domain")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.email" => static (e, v) => TryAssignSource("source.user.email")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserEmail" => static (e, v) => TryAssignSource("source.user.email")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.full_name" => static (e, v) => TryAssignSource("source.user.full_name")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserFullName" => static (e, v) => TryAssignSource("source.user.full_name")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.hash" => static (e, v) => TryAssignSource("source.user.hash")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserHash" => static (e, v) => TryAssignSource("source.user.hash")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.id" => static (e, v) => TryAssignSource("source.user.id")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserId" => static (e, v) => TryAssignSource("source.user.id")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.name" => static (e, v) => TryAssignSource("source.user.name")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserName" => static (e, v) => TryAssignSource("source.user.name")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.group.domain" => static (e, v) => TryAssignSource("source.user.group.domain")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserGroupDomain" => static (e, v) => TryAssignSource("source.user.group.domain")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.group.id" => static (e, v) => TryAssignSource("source.user.group.id")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserGroupId" => static (e, v) => TryAssignSource("source.user.group.id")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.group.name" => static (e, v) => TryAssignSource("source.user.group.name")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserGroupName" => static (e, v) => TryAssignSource("source.user.group.name")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.risk.calculated_level" => static (e, v) => TryAssignSource("source.user.risk.calculated_level")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserRiskCalculatedLevel" => static (e, v) => TryAssignSource("source.user.risk.calculated_level")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.risk.calculated_score" => static (e, v) => TryAssignSource("source.user.risk.calculated_score")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserRiskCalculatedScore" => static (e, v) => TryAssignSource("source.user.risk.calculated_score")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.risk.calculated_score_norm" => static (e, v) => TryAssignSource("source.user.risk.calculated_score_norm")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserRiskCalculatedScoreNorm" => static (e, v) => TryAssignSource("source.user.risk.calculated_score_norm")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.risk.static_level" => static (e, v) => TryAssignSource("source.user.risk.static_level")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserRiskStaticLevel" => static (e, v) => TryAssignSource("source.user.risk.static_level")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.risk.static_score" => static (e, v) => TryAssignSource("source.user.risk.static_score")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserRiskStaticScore" => static (e, v) => TryAssignSource("source.user.risk.static_score")(e.EntryMetaSource ??= new Source(),v),
				"process.entry_meta.source.user.risk.static_score_norm" => static (e, v) => TryAssignSource("source.user.risk.static_score_norm")(e.EntryMetaSource ??= new Source(),v),
				"ProcessEntryMetaSourceUserRiskStaticScoreNorm" => static (e, v) => TryAssignSource("source.user.risk.static_score_norm")(e.EntryMetaSource ??= new Source(),v),
				"process.user.domain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"ProcessUserDomain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"process.user.email" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"ProcessUserEmail" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"process.user.full_name" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"ProcessUserFullName" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"process.user.hash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"ProcessUserHash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"process.user.id" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"ProcessUserId" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"process.user.name" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"ProcessUserName" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"process.user.group.domain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"ProcessUserGroupDomain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"process.user.group.id" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"ProcessUserGroupId" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"process.user.group.name" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"ProcessUserGroupName" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"process.user.risk.calculated_level" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"ProcessUserRiskCalculatedLevel" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"process.user.risk.calculated_score" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"ProcessUserRiskCalculatedScore" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"process.user.risk.calculated_score_norm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"ProcessUserRiskCalculatedScoreNorm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"process.user.risk.static_level" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"ProcessUserRiskStaticLevel" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"process.user.risk.static_score" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"ProcessUserRiskStaticScore" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"process.user.risk.static_score_norm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				"ProcessUserRiskStaticScoreNorm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				"process.saved_user.domain" => static (e, v) => TryAssignUser("saved_user.domain")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserDomain" => static (e, v) => TryAssignUser("saved_user.domain")(e.SavedUser ??= new User(),v),
				"process.saved_user.email" => static (e, v) => TryAssignUser("saved_user.email")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserEmail" => static (e, v) => TryAssignUser("saved_user.email")(e.SavedUser ??= new User(),v),
				"process.saved_user.full_name" => static (e, v) => TryAssignUser("saved_user.full_name")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserFullName" => static (e, v) => TryAssignUser("saved_user.full_name")(e.SavedUser ??= new User(),v),
				"process.saved_user.hash" => static (e, v) => TryAssignUser("saved_user.hash")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserHash" => static (e, v) => TryAssignUser("saved_user.hash")(e.SavedUser ??= new User(),v),
				"process.saved_user.id" => static (e, v) => TryAssignUser("saved_user.id")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserId" => static (e, v) => TryAssignUser("saved_user.id")(e.SavedUser ??= new User(),v),
				"process.saved_user.name" => static (e, v) => TryAssignUser("saved_user.name")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserName" => static (e, v) => TryAssignUser("saved_user.name")(e.SavedUser ??= new User(),v),
				"process.saved_user.group.domain" => static (e, v) => TryAssignUser("saved_user.group.domain")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserGroupDomain" => static (e, v) => TryAssignUser("saved_user.group.domain")(e.SavedUser ??= new User(),v),
				"process.saved_user.group.id" => static (e, v) => TryAssignUser("saved_user.group.id")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserGroupId" => static (e, v) => TryAssignUser("saved_user.group.id")(e.SavedUser ??= new User(),v),
				"process.saved_user.group.name" => static (e, v) => TryAssignUser("saved_user.group.name")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserGroupName" => static (e, v) => TryAssignUser("saved_user.group.name")(e.SavedUser ??= new User(),v),
				"process.saved_user.risk.calculated_level" => static (e, v) => TryAssignUser("saved_user.risk.calculated_level")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserRiskCalculatedLevel" => static (e, v) => TryAssignUser("saved_user.risk.calculated_level")(e.SavedUser ??= new User(),v),
				"process.saved_user.risk.calculated_score" => static (e, v) => TryAssignUser("saved_user.risk.calculated_score")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserRiskCalculatedScore" => static (e, v) => TryAssignUser("saved_user.risk.calculated_score")(e.SavedUser ??= new User(),v),
				"process.saved_user.risk.calculated_score_norm" => static (e, v) => TryAssignUser("saved_user.risk.calculated_score_norm")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserRiskCalculatedScoreNorm" => static (e, v) => TryAssignUser("saved_user.risk.calculated_score_norm")(e.SavedUser ??= new User(),v),
				"process.saved_user.risk.static_level" => static (e, v) => TryAssignUser("saved_user.risk.static_level")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserRiskStaticLevel" => static (e, v) => TryAssignUser("saved_user.risk.static_level")(e.SavedUser ??= new User(),v),
				"process.saved_user.risk.static_score" => static (e, v) => TryAssignUser("saved_user.risk.static_score")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserRiskStaticScore" => static (e, v) => TryAssignUser("saved_user.risk.static_score")(e.SavedUser ??= new User(),v),
				"process.saved_user.risk.static_score_norm" => static (e, v) => TryAssignUser("saved_user.risk.static_score_norm")(e.SavedUser ??= new User(),v),
				"ProcessSavedUserRiskStaticScoreNorm" => static (e, v) => TryAssignUser("saved_user.risk.static_score_norm")(e.SavedUser ??= new User(),v),
				"process.real_user.domain" => static (e, v) => TryAssignUser("real_user.domain")(e.RealUser ??= new User(),v),
				"ProcessRealUserDomain" => static (e, v) => TryAssignUser("real_user.domain")(e.RealUser ??= new User(),v),
				"process.real_user.email" => static (e, v) => TryAssignUser("real_user.email")(e.RealUser ??= new User(),v),
				"ProcessRealUserEmail" => static (e, v) => TryAssignUser("real_user.email")(e.RealUser ??= new User(),v),
				"process.real_user.full_name" => static (e, v) => TryAssignUser("real_user.full_name")(e.RealUser ??= new User(),v),
				"ProcessRealUserFullName" => static (e, v) => TryAssignUser("real_user.full_name")(e.RealUser ??= new User(),v),
				"process.real_user.hash" => static (e, v) => TryAssignUser("real_user.hash")(e.RealUser ??= new User(),v),
				"ProcessRealUserHash" => static (e, v) => TryAssignUser("real_user.hash")(e.RealUser ??= new User(),v),
				"process.real_user.id" => static (e, v) => TryAssignUser("real_user.id")(e.RealUser ??= new User(),v),
				"ProcessRealUserId" => static (e, v) => TryAssignUser("real_user.id")(e.RealUser ??= new User(),v),
				"process.real_user.name" => static (e, v) => TryAssignUser("real_user.name")(e.RealUser ??= new User(),v),
				"ProcessRealUserName" => static (e, v) => TryAssignUser("real_user.name")(e.RealUser ??= new User(),v),
				"process.real_user.group.domain" => static (e, v) => TryAssignUser("real_user.group.domain")(e.RealUser ??= new User(),v),
				"ProcessRealUserGroupDomain" => static (e, v) => TryAssignUser("real_user.group.domain")(e.RealUser ??= new User(),v),
				"process.real_user.group.id" => static (e, v) => TryAssignUser("real_user.group.id")(e.RealUser ??= new User(),v),
				"ProcessRealUserGroupId" => static (e, v) => TryAssignUser("real_user.group.id")(e.RealUser ??= new User(),v),
				"process.real_user.group.name" => static (e, v) => TryAssignUser("real_user.group.name")(e.RealUser ??= new User(),v),
				"ProcessRealUserGroupName" => static (e, v) => TryAssignUser("real_user.group.name")(e.RealUser ??= new User(),v),
				"process.real_user.risk.calculated_level" => static (e, v) => TryAssignUser("real_user.risk.calculated_level")(e.RealUser ??= new User(),v),
				"ProcessRealUserRiskCalculatedLevel" => static (e, v) => TryAssignUser("real_user.risk.calculated_level")(e.RealUser ??= new User(),v),
				"process.real_user.risk.calculated_score" => static (e, v) => TryAssignUser("real_user.risk.calculated_score")(e.RealUser ??= new User(),v),
				"ProcessRealUserRiskCalculatedScore" => static (e, v) => TryAssignUser("real_user.risk.calculated_score")(e.RealUser ??= new User(),v),
				"process.real_user.risk.calculated_score_norm" => static (e, v) => TryAssignUser("real_user.risk.calculated_score_norm")(e.RealUser ??= new User(),v),
				"ProcessRealUserRiskCalculatedScoreNorm" => static (e, v) => TryAssignUser("real_user.risk.calculated_score_norm")(e.RealUser ??= new User(),v),
				"process.real_user.risk.static_level" => static (e, v) => TryAssignUser("real_user.risk.static_level")(e.RealUser ??= new User(),v),
				"ProcessRealUserRiskStaticLevel" => static (e, v) => TryAssignUser("real_user.risk.static_level")(e.RealUser ??= new User(),v),
				"process.real_user.risk.static_score" => static (e, v) => TryAssignUser("real_user.risk.static_score")(e.RealUser ??= new User(),v),
				"ProcessRealUserRiskStaticScore" => static (e, v) => TryAssignUser("real_user.risk.static_score")(e.RealUser ??= new User(),v),
				"process.real_user.risk.static_score_norm" => static (e, v) => TryAssignUser("real_user.risk.static_score_norm")(e.RealUser ??= new User(),v),
				"ProcessRealUserRiskStaticScoreNorm" => static (e, v) => TryAssignUser("real_user.risk.static_score_norm")(e.RealUser ??= new User(),v),
				"process.attested_user.domain" => static (e, v) => TryAssignUser("attested_user.domain")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserDomain" => static (e, v) => TryAssignUser("attested_user.domain")(e.AttestedUser ??= new User(),v),
				"process.attested_user.email" => static (e, v) => TryAssignUser("attested_user.email")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserEmail" => static (e, v) => TryAssignUser("attested_user.email")(e.AttestedUser ??= new User(),v),
				"process.attested_user.full_name" => static (e, v) => TryAssignUser("attested_user.full_name")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserFullName" => static (e, v) => TryAssignUser("attested_user.full_name")(e.AttestedUser ??= new User(),v),
				"process.attested_user.hash" => static (e, v) => TryAssignUser("attested_user.hash")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserHash" => static (e, v) => TryAssignUser("attested_user.hash")(e.AttestedUser ??= new User(),v),
				"process.attested_user.id" => static (e, v) => TryAssignUser("attested_user.id")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserId" => static (e, v) => TryAssignUser("attested_user.id")(e.AttestedUser ??= new User(),v),
				"process.attested_user.name" => static (e, v) => TryAssignUser("attested_user.name")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserName" => static (e, v) => TryAssignUser("attested_user.name")(e.AttestedUser ??= new User(),v),
				"process.attested_user.group.domain" => static (e, v) => TryAssignUser("attested_user.group.domain")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserGroupDomain" => static (e, v) => TryAssignUser("attested_user.group.domain")(e.AttestedUser ??= new User(),v),
				"process.attested_user.group.id" => static (e, v) => TryAssignUser("attested_user.group.id")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserGroupId" => static (e, v) => TryAssignUser("attested_user.group.id")(e.AttestedUser ??= new User(),v),
				"process.attested_user.group.name" => static (e, v) => TryAssignUser("attested_user.group.name")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserGroupName" => static (e, v) => TryAssignUser("attested_user.group.name")(e.AttestedUser ??= new User(),v),
				"process.attested_user.risk.calculated_level" => static (e, v) => TryAssignUser("attested_user.risk.calculated_level")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserRiskCalculatedLevel" => static (e, v) => TryAssignUser("attested_user.risk.calculated_level")(e.AttestedUser ??= new User(),v),
				"process.attested_user.risk.calculated_score" => static (e, v) => TryAssignUser("attested_user.risk.calculated_score")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserRiskCalculatedScore" => static (e, v) => TryAssignUser("attested_user.risk.calculated_score")(e.AttestedUser ??= new User(),v),
				"process.attested_user.risk.calculated_score_norm" => static (e, v) => TryAssignUser("attested_user.risk.calculated_score_norm")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserRiskCalculatedScoreNorm" => static (e, v) => TryAssignUser("attested_user.risk.calculated_score_norm")(e.AttestedUser ??= new User(),v),
				"process.attested_user.risk.static_level" => static (e, v) => TryAssignUser("attested_user.risk.static_level")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserRiskStaticLevel" => static (e, v) => TryAssignUser("attested_user.risk.static_level")(e.AttestedUser ??= new User(),v),
				"process.attested_user.risk.static_score" => static (e, v) => TryAssignUser("attested_user.risk.static_score")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserRiskStaticScore" => static (e, v) => TryAssignUser("attested_user.risk.static_score")(e.AttestedUser ??= new User(),v),
				"process.attested_user.risk.static_score_norm" => static (e, v) => TryAssignUser("attested_user.risk.static_score_norm")(e.AttestedUser ??= new User(),v),
				"ProcessAttestedUserRiskStaticScoreNorm" => static (e, v) => TryAssignUser("attested_user.risk.static_score_norm")(e.AttestedUser ??= new User(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetProcess(EcsDocument document, string path, object value)
		{
			var assign = TryAssignProcess(path);
			if (assign == null) return false;
		
			var entity = document.Process ?? new Process();
			var assigned = assign(entity, value);
			if (assigned) document.Process = entity;
			return assigned;
		}

		public static Func<Registry, object, bool> TryAssignRegistry(string path)
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
			return assign;
		}
		public static bool TrySetRegistry(EcsDocument document, string path, object value)
		{
			var assign = TryAssignRegistry(path);
			if (assign == null) return false;
		
			var entity = document.Registry ?? new Registry();
			var assigned = assign(entity, value);
			if (assigned) document.Registry = entity;
			return assigned;
		}

		public static Func<Related, object, bool> TryAssignRelated(string path)
		{
			Func<Related, object, bool> assign = path switch
			{
				_ => null
			};
			return assign;
		}
		public static bool TrySetRelated(EcsDocument document, string path, object value)
		{
			var assign = TryAssignRelated(path);
			if (assign == null) return false;
		
			var entity = document.Related ?? new Related();
			var assigned = assign(entity, value);
			if (assigned) document.Related = entity;
			return assigned;
		}

		public static Func<Risk, object, bool> TryAssignRisk(string path)
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
			return assign;
		}
		public static bool TrySetRisk(IRisk document, string path, object value)
		{
			var assign = TryAssignRisk(path);
			if (assign == null) return false;
		
			var entity = document.Risk ?? new Risk();
			var assigned = assign(entity, value);
			if (assigned) document.Risk = entity;
			return assigned;
		}

		public static Func<Rule, object, bool> TryAssignRule(string path)
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
			return assign;
		}
		public static bool TrySetRule(EcsDocument document, string path, object value)
		{
			var assign = TryAssignRule(path);
			if (assign == null) return false;
		
			var entity = document.Rule ?? new Rule();
			var assigned = assign(entity, value);
			if (assigned) document.Rule = entity;
			return assigned;
		}

		public static Func<Server, object, bool> TryAssignServer(string path)
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
				"server.as.number" => static (e, v) => TryAssignAs("as.number")(e.As ??= new As(),v),
				"ServerAsNumber" => static (e, v) => TryAssignAs("as.number")(e.As ??= new As(),v),
				"server.as.organization.name" => static (e, v) => TryAssignAs("as.organization.name")(e.As ??= new As(),v),
				"ServerAsOrganizationName" => static (e, v) => TryAssignAs("as.organization.name")(e.As ??= new As(),v),
				"server.geo.city_name" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"ServerGeoCityName" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"server.geo.continent_code" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"ServerGeoContinentCode" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"server.geo.continent_name" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"ServerGeoContinentName" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"server.geo.country_iso_code" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"ServerGeoCountryIsoCode" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"server.geo.country_name" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"ServerGeoCountryName" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"server.geo.location" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"ServerGeoLocation" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"server.geo.name" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"ServerGeoName" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"server.geo.postal_code" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"ServerGeoPostalCode" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"server.geo.region_iso_code" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"ServerGeoRegionIsoCode" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"server.geo.region_name" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"ServerGeoRegionName" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"server.geo.timezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"ServerGeoTimezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"server.user.domain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"ServerUserDomain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"server.user.email" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"ServerUserEmail" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"server.user.full_name" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"ServerUserFullName" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"server.user.hash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"ServerUserHash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"server.user.id" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"ServerUserId" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"server.user.name" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"ServerUserName" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"server.user.group.domain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"ServerUserGroupDomain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"server.user.group.id" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"ServerUserGroupId" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"server.user.group.name" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"ServerUserGroupName" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"server.user.risk.calculated_level" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"ServerUserRiskCalculatedLevel" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"server.user.risk.calculated_score" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"ServerUserRiskCalculatedScore" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"server.user.risk.calculated_score_norm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"ServerUserRiskCalculatedScoreNorm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"server.user.risk.static_level" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"ServerUserRiskStaticLevel" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"server.user.risk.static_score" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"ServerUserRiskStaticScore" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"server.user.risk.static_score_norm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				"ServerUserRiskStaticScoreNorm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetServer(EcsDocument document, string path, object value)
		{
			var assign = TryAssignServer(path);
			if (assign == null) return false;
		
			var entity = document.Server ?? new Server();
			var assigned = assign(entity, value);
			if (assigned) document.Server = entity;
			return assigned;
		}

		public static Func<Service, object, bool> TryAssignService(string path)
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
			return assign;
		}
		public static bool TrySetService(EcsDocument document, string path, object value)
		{
			var assign = TryAssignService(path);
			if (assign == null) return false;
		
			var entity = document.Service ?? new Service();
			var assigned = assign(entity, value);
			if (assigned) document.Service = entity;
			return assigned;
		}

		public static Func<Source, object, bool> TryAssignSource(string path)
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
				"source.as.number" => static (e, v) => TryAssignAs("as.number")(e.As ??= new As(),v),
				"SourceAsNumber" => static (e, v) => TryAssignAs("as.number")(e.As ??= new As(),v),
				"source.as.organization.name" => static (e, v) => TryAssignAs("as.organization.name")(e.As ??= new As(),v),
				"SourceAsOrganizationName" => static (e, v) => TryAssignAs("as.organization.name")(e.As ??= new As(),v),
				"source.geo.city_name" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"SourceGeoCityName" => static (e, v) => TryAssignGeo("geo.city_name")(e.Geo ??= new Geo(),v),
				"source.geo.continent_code" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"SourceGeoContinentCode" => static (e, v) => TryAssignGeo("geo.continent_code")(e.Geo ??= new Geo(),v),
				"source.geo.continent_name" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"SourceGeoContinentName" => static (e, v) => TryAssignGeo("geo.continent_name")(e.Geo ??= new Geo(),v),
				"source.geo.country_iso_code" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"SourceGeoCountryIsoCode" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.Geo ??= new Geo(),v),
				"source.geo.country_name" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"SourceGeoCountryName" => static (e, v) => TryAssignGeo("geo.country_name")(e.Geo ??= new Geo(),v),
				"source.geo.location" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"SourceGeoLocation" => static (e, v) => TryAssignGeo("geo.location")(e.Geo ??= new Geo(),v),
				"source.geo.name" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"SourceGeoName" => static (e, v) => TryAssignGeo("geo.name")(e.Geo ??= new Geo(),v),
				"source.geo.postal_code" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"SourceGeoPostalCode" => static (e, v) => TryAssignGeo("geo.postal_code")(e.Geo ??= new Geo(),v),
				"source.geo.region_iso_code" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"SourceGeoRegionIsoCode" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.Geo ??= new Geo(),v),
				"source.geo.region_name" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"SourceGeoRegionName" => static (e, v) => TryAssignGeo("geo.region_name")(e.Geo ??= new Geo(),v),
				"source.geo.timezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"SourceGeoTimezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.Geo ??= new Geo(),v),
				"source.user.domain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"SourceUserDomain" => static (e, v) => TryAssignUser("user.domain")(e.User ??= new User(),v),
				"source.user.email" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"SourceUserEmail" => static (e, v) => TryAssignUser("user.email")(e.User ??= new User(),v),
				"source.user.full_name" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"SourceUserFullName" => static (e, v) => TryAssignUser("user.full_name")(e.User ??= new User(),v),
				"source.user.hash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"SourceUserHash" => static (e, v) => TryAssignUser("user.hash")(e.User ??= new User(),v),
				"source.user.id" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"SourceUserId" => static (e, v) => TryAssignUser("user.id")(e.User ??= new User(),v),
				"source.user.name" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"SourceUserName" => static (e, v) => TryAssignUser("user.name")(e.User ??= new User(),v),
				"source.user.group.domain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"SourceUserGroupDomain" => static (e, v) => TryAssignUser("user.group.domain")(e.User ??= new User(),v),
				"source.user.group.id" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"SourceUserGroupId" => static (e, v) => TryAssignUser("user.group.id")(e.User ??= new User(),v),
				"source.user.group.name" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"SourceUserGroupName" => static (e, v) => TryAssignUser("user.group.name")(e.User ??= new User(),v),
				"source.user.risk.calculated_level" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"SourceUserRiskCalculatedLevel" => static (e, v) => TryAssignUser("user.risk.calculated_level")(e.User ??= new User(),v),
				"source.user.risk.calculated_score" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"SourceUserRiskCalculatedScore" => static (e, v) => TryAssignUser("user.risk.calculated_score")(e.User ??= new User(),v),
				"source.user.risk.calculated_score_norm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"SourceUserRiskCalculatedScoreNorm" => static (e, v) => TryAssignUser("user.risk.calculated_score_norm")(e.User ??= new User(),v),
				"source.user.risk.static_level" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"SourceUserRiskStaticLevel" => static (e, v) => TryAssignUser("user.risk.static_level")(e.User ??= new User(),v),
				"source.user.risk.static_score" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"SourceUserRiskStaticScore" => static (e, v) => TryAssignUser("user.risk.static_score")(e.User ??= new User(),v),
				"source.user.risk.static_score_norm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				"SourceUserRiskStaticScoreNorm" => static (e, v) => TryAssignUser("user.risk.static_score_norm")(e.User ??= new User(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetSource(EcsDocument document, string path, object value)
		{
			var assign = TryAssignSource(path);
			if (assign == null) return false;
		
			var entity = document.Source ?? new Source();
			var assigned = assign(entity, value);
			if (assigned) document.Source = entity;
			return assigned;
		}

		public static Func<Threat, object, bool> TryAssignThreat(string path)
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
				"threat.indicator.x509.issuer.distinguished_name" => static (e, v) => TryAssignX509("x509.issuer.distinguished_name")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509IssuerDistinguishedName" => static (e, v) => TryAssignX509("x509.issuer.distinguished_name")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.not_after" => static (e, v) => TryAssignX509("x509.not_after")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509NotAfter" => static (e, v) => TryAssignX509("x509.not_after")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.not_before" => static (e, v) => TryAssignX509("x509.not_before")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509NotBefore" => static (e, v) => TryAssignX509("x509.not_before")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.public_key_algorithm" => static (e, v) => TryAssignX509("x509.public_key_algorithm")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509PublicKeyAlgorithm" => static (e, v) => TryAssignX509("x509.public_key_algorithm")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.public_key_curve" => static (e, v) => TryAssignX509("x509.public_key_curve")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509PublicKeyCurve" => static (e, v) => TryAssignX509("x509.public_key_curve")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.public_key_exponent" => static (e, v) => TryAssignX509("x509.public_key_exponent")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509PublicKeyExponent" => static (e, v) => TryAssignX509("x509.public_key_exponent")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.public_key_size" => static (e, v) => TryAssignX509("x509.public_key_size")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509PublicKeySize" => static (e, v) => TryAssignX509("x509.public_key_size")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.serial_number" => static (e, v) => TryAssignX509("x509.serial_number")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509SerialNumber" => static (e, v) => TryAssignX509("x509.serial_number")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.signature_algorithm" => static (e, v) => TryAssignX509("x509.signature_algorithm")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509SignatureAlgorithm" => static (e, v) => TryAssignX509("x509.signature_algorithm")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.subject.distinguished_name" => static (e, v) => TryAssignX509("x509.subject.distinguished_name")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509SubjectDistinguishedName" => static (e, v) => TryAssignX509("x509.subject.distinguished_name")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.x509.version_number" => static (e, v) => TryAssignX509("x509.version_number")(e.IndicatorX509 ??= new X509(),v),
				"ThreatIndicatorX509VersionNumber" => static (e, v) => TryAssignX509("x509.version_number")(e.IndicatorX509 ??= new X509(),v),
				"threat.indicator.as.number" => static (e, v) => TryAssignAs("as.number")(e.IndicatorAs ??= new As(),v),
				"ThreatIndicatorAsNumber" => static (e, v) => TryAssignAs("as.number")(e.IndicatorAs ??= new As(),v),
				"threat.indicator.as.organization.name" => static (e, v) => TryAssignAs("as.organization.name")(e.IndicatorAs ??= new As(),v),
				"ThreatIndicatorAsOrganizationName" => static (e, v) => TryAssignAs("as.organization.name")(e.IndicatorAs ??= new As(),v),
				"threat.indicator.file.accessed" => static (e, v) => TryAssignFile("file.accessed")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileAccessed" => static (e, v) => TryAssignFile("file.accessed")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.created" => static (e, v) => TryAssignFile("file.created")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCreated" => static (e, v) => TryAssignFile("file.created")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.ctime" => static (e, v) => TryAssignFile("file.ctime")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCtime" => static (e, v) => TryAssignFile("file.ctime")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.device" => static (e, v) => TryAssignFile("file.device")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileDevice" => static (e, v) => TryAssignFile("file.device")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.directory" => static (e, v) => TryAssignFile("file.directory")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileDirectory" => static (e, v) => TryAssignFile("file.directory")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.drive_letter" => static (e, v) => TryAssignFile("file.drive_letter")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileDriveLetter" => static (e, v) => TryAssignFile("file.drive_letter")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.extension" => static (e, v) => TryAssignFile("file.extension")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileExtension" => static (e, v) => TryAssignFile("file.extension")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.fork_name" => static (e, v) => TryAssignFile("file.fork_name")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileForkName" => static (e, v) => TryAssignFile("file.fork_name")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.gid" => static (e, v) => TryAssignFile("file.gid")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileGid" => static (e, v) => TryAssignFile("file.gid")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.group" => static (e, v) => TryAssignFile("file.group")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileGroup" => static (e, v) => TryAssignFile("file.group")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.inode" => static (e, v) => TryAssignFile("file.inode")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileInode" => static (e, v) => TryAssignFile("file.inode")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.mime_type" => static (e, v) => TryAssignFile("file.mime_type")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMimeType" => static (e, v) => TryAssignFile("file.mime_type")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.mode" => static (e, v) => TryAssignFile("file.mode")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMode" => static (e, v) => TryAssignFile("file.mode")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.mtime" => static (e, v) => TryAssignFile("file.mtime")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMtime" => static (e, v) => TryAssignFile("file.mtime")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.name" => static (e, v) => TryAssignFile("file.name")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileName" => static (e, v) => TryAssignFile("file.name")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.owner" => static (e, v) => TryAssignFile("file.owner")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileOwner" => static (e, v) => TryAssignFile("file.owner")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.path" => static (e, v) => TryAssignFile("file.path")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePath" => static (e, v) => TryAssignFile("file.path")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.size" => static (e, v) => TryAssignFile("file.size")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileSize" => static (e, v) => TryAssignFile("file.size")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.target_path" => static (e, v) => TryAssignFile("file.target_path")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileTargetPath" => static (e, v) => TryAssignFile("file.target_path")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.type" => static (e, v) => TryAssignFile("file.type")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileType" => static (e, v) => TryAssignFile("file.type")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.uid" => static (e, v) => TryAssignFile("file.uid")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileUid" => static (e, v) => TryAssignFile("file.uid")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.hash.cdhash" => static (e, v) => TryAssignFile("file.hash.cdhash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileHashCdhash" => static (e, v) => TryAssignFile("file.hash.cdhash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.hash.md5" => static (e, v) => TryAssignFile("file.hash.md5")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileHashMd5" => static (e, v) => TryAssignFile("file.hash.md5")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.hash.sha1" => static (e, v) => TryAssignFile("file.hash.sha1")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileHashSha1" => static (e, v) => TryAssignFile("file.hash.sha1")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.hash.sha256" => static (e, v) => TryAssignFile("file.hash.sha256")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileHashSha256" => static (e, v) => TryAssignFile("file.hash.sha256")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.hash.sha384" => static (e, v) => TryAssignFile("file.hash.sha384")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileHashSha384" => static (e, v) => TryAssignFile("file.hash.sha384")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.hash.sha512" => static (e, v) => TryAssignFile("file.hash.sha512")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileHashSha512" => static (e, v) => TryAssignFile("file.hash.sha512")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.hash.ssdeep" => static (e, v) => TryAssignFile("file.hash.ssdeep")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileHashSsdeep" => static (e, v) => TryAssignFile("file.hash.ssdeep")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.hash.tlsh" => static (e, v) => TryAssignFile("file.hash.tlsh")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileHashTlsh" => static (e, v) => TryAssignFile("file.hash.tlsh")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.architecture" => static (e, v) => TryAssignFile("file.pe.architecture")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeArchitecture" => static (e, v) => TryAssignFile("file.pe.architecture")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.company" => static (e, v) => TryAssignFile("file.pe.company")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeCompany" => static (e, v) => TryAssignFile("file.pe.company")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.description" => static (e, v) => TryAssignFile("file.pe.description")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeDescription" => static (e, v) => TryAssignFile("file.pe.description")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.file_version" => static (e, v) => TryAssignFile("file.pe.file_version")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeFileVersion" => static (e, v) => TryAssignFile("file.pe.file_version")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.go_import_hash" => static (e, v) => TryAssignFile("file.pe.go_import_hash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeGoImportHash" => static (e, v) => TryAssignFile("file.pe.go_import_hash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.go_imports" => static (e, v) => TryAssignFile("file.pe.go_imports")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeGoImports" => static (e, v) => TryAssignFile("file.pe.go_imports")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.go_imports_names_entropy" => static (e, v) => TryAssignFile("file.pe.go_imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeGoImportsNamesEntropy" => static (e, v) => TryAssignFile("file.pe.go_imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.go_imports_names_var_entropy" => static (e, v) => TryAssignFile("file.pe.go_imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeGoImportsNamesVarEntropy" => static (e, v) => TryAssignFile("file.pe.go_imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.go_stripped" => static (e, v) => TryAssignFile("file.pe.go_stripped")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeGoStripped" => static (e, v) => TryAssignFile("file.pe.go_stripped")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.imphash" => static (e, v) => TryAssignFile("file.pe.imphash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeImphash" => static (e, v) => TryAssignFile("file.pe.imphash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.import_hash" => static (e, v) => TryAssignFile("file.pe.import_hash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeImportHash" => static (e, v) => TryAssignFile("file.pe.import_hash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.imports_names_entropy" => static (e, v) => TryAssignFile("file.pe.imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeImportsNamesEntropy" => static (e, v) => TryAssignFile("file.pe.imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.imports_names_var_entropy" => static (e, v) => TryAssignFile("file.pe.imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeImportsNamesVarEntropy" => static (e, v) => TryAssignFile("file.pe.imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.original_file_name" => static (e, v) => TryAssignFile("file.pe.original_file_name")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeOriginalFileName" => static (e, v) => TryAssignFile("file.pe.original_file_name")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.pehash" => static (e, v) => TryAssignFile("file.pe.pehash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePePehash" => static (e, v) => TryAssignFile("file.pe.pehash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.pe.product" => static (e, v) => TryAssignFile("file.pe.product")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFilePeProduct" => static (e, v) => TryAssignFile("file.pe.product")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.issuer.distinguished_name" => static (e, v) => TryAssignFile("file.x509.issuer.distinguished_name")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509IssuerDistinguishedName" => static (e, v) => TryAssignFile("file.x509.issuer.distinguished_name")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.not_after" => static (e, v) => TryAssignFile("file.x509.not_after")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509NotAfter" => static (e, v) => TryAssignFile("file.x509.not_after")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.not_before" => static (e, v) => TryAssignFile("file.x509.not_before")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509NotBefore" => static (e, v) => TryAssignFile("file.x509.not_before")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.public_key_algorithm" => static (e, v) => TryAssignFile("file.x509.public_key_algorithm")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509PublicKeyAlgorithm" => static (e, v) => TryAssignFile("file.x509.public_key_algorithm")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.public_key_curve" => static (e, v) => TryAssignFile("file.x509.public_key_curve")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509PublicKeyCurve" => static (e, v) => TryAssignFile("file.x509.public_key_curve")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.public_key_exponent" => static (e, v) => TryAssignFile("file.x509.public_key_exponent")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509PublicKeyExponent" => static (e, v) => TryAssignFile("file.x509.public_key_exponent")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.public_key_size" => static (e, v) => TryAssignFile("file.x509.public_key_size")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509PublicKeySize" => static (e, v) => TryAssignFile("file.x509.public_key_size")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.serial_number" => static (e, v) => TryAssignFile("file.x509.serial_number")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509SerialNumber" => static (e, v) => TryAssignFile("file.x509.serial_number")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.signature_algorithm" => static (e, v) => TryAssignFile("file.x509.signature_algorithm")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509SignatureAlgorithm" => static (e, v) => TryAssignFile("file.x509.signature_algorithm")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.subject.distinguished_name" => static (e, v) => TryAssignFile("file.x509.subject.distinguished_name")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509SubjectDistinguishedName" => static (e, v) => TryAssignFile("file.x509.subject.distinguished_name")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.x509.version_number" => static (e, v) => TryAssignFile("file.x509.version_number")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileX509VersionNumber" => static (e, v) => TryAssignFile("file.x509.version_number")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.digest_algorithm" => static (e, v) => TryAssignFile("file.code_signature.digest_algorithm")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureDigestAlgorithm" => static (e, v) => TryAssignFile("file.code_signature.digest_algorithm")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.exists" => static (e, v) => TryAssignFile("file.code_signature.exists")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureExists" => static (e, v) => TryAssignFile("file.code_signature.exists")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.flags" => static (e, v) => TryAssignFile("file.code_signature.flags")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureFlags" => static (e, v) => TryAssignFile("file.code_signature.flags")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.signing_id" => static (e, v) => TryAssignFile("file.code_signature.signing_id")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureSigningId" => static (e, v) => TryAssignFile("file.code_signature.signing_id")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.status" => static (e, v) => TryAssignFile("file.code_signature.status")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureStatus" => static (e, v) => TryAssignFile("file.code_signature.status")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.subject_name" => static (e, v) => TryAssignFile("file.code_signature.subject_name")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureSubjectName" => static (e, v) => TryAssignFile("file.code_signature.subject_name")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.team_id" => static (e, v) => TryAssignFile("file.code_signature.team_id")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureTeamId" => static (e, v) => TryAssignFile("file.code_signature.team_id")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.timestamp" => static (e, v) => TryAssignFile("file.code_signature.timestamp")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureTimestamp" => static (e, v) => TryAssignFile("file.code_signature.timestamp")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.trusted" => static (e, v) => TryAssignFile("file.code_signature.trusted")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureTrusted" => static (e, v) => TryAssignFile("file.code_signature.trusted")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.code_signature.valid" => static (e, v) => TryAssignFile("file.code_signature.valid")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileCodeSignatureValid" => static (e, v) => TryAssignFile("file.code_signature.valid")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.architecture" => static (e, v) => TryAssignFile("file.elf.architecture")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfArchitecture" => static (e, v) => TryAssignFile("file.elf.architecture")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.byte_order" => static (e, v) => TryAssignFile("file.elf.byte_order")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfByteOrder" => static (e, v) => TryAssignFile("file.elf.byte_order")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.cpu_type" => static (e, v) => TryAssignFile("file.elf.cpu_type")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfCpuType" => static (e, v) => TryAssignFile("file.elf.cpu_type")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.creation_date" => static (e, v) => TryAssignFile("file.elf.creation_date")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfCreationDate" => static (e, v) => TryAssignFile("file.elf.creation_date")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.go_import_hash" => static (e, v) => TryAssignFile("file.elf.go_import_hash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfGoImportHash" => static (e, v) => TryAssignFile("file.elf.go_import_hash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.go_imports" => static (e, v) => TryAssignFile("file.elf.go_imports")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfGoImports" => static (e, v) => TryAssignFile("file.elf.go_imports")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.go_imports_names_entropy" => static (e, v) => TryAssignFile("file.elf.go_imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfGoImportsNamesEntropy" => static (e, v) => TryAssignFile("file.elf.go_imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.go_imports_names_var_entropy" => static (e, v) => TryAssignFile("file.elf.go_imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfGoImportsNamesVarEntropy" => static (e, v) => TryAssignFile("file.elf.go_imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.go_stripped" => static (e, v) => TryAssignFile("file.elf.go_stripped")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfGoStripped" => static (e, v) => TryAssignFile("file.elf.go_stripped")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.header.abi_version" => static (e, v) => TryAssignFile("file.elf.header.abi_version")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfHeaderAbiVersion" => static (e, v) => TryAssignFile("file.elf.header.abi_version")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.header.class" => static (e, v) => TryAssignFile("file.elf.header.class")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfHeaderClass" => static (e, v) => TryAssignFile("file.elf.header.class")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.header.data" => static (e, v) => TryAssignFile("file.elf.header.data")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfHeaderData" => static (e, v) => TryAssignFile("file.elf.header.data")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.header.entrypoint" => static (e, v) => TryAssignFile("file.elf.header.entrypoint")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfHeaderEntrypoint" => static (e, v) => TryAssignFile("file.elf.header.entrypoint")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.header.object_version" => static (e, v) => TryAssignFile("file.elf.header.object_version")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfHeaderObjectVersion" => static (e, v) => TryAssignFile("file.elf.header.object_version")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.header.os_abi" => static (e, v) => TryAssignFile("file.elf.header.os_abi")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfHeaderOsAbi" => static (e, v) => TryAssignFile("file.elf.header.os_abi")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.header.type" => static (e, v) => TryAssignFile("file.elf.header.type")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfHeaderType" => static (e, v) => TryAssignFile("file.elf.header.type")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.header.version" => static (e, v) => TryAssignFile("file.elf.header.version")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfHeaderVersion" => static (e, v) => TryAssignFile("file.elf.header.version")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.import_hash" => static (e, v) => TryAssignFile("file.elf.import_hash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfImportHash" => static (e, v) => TryAssignFile("file.elf.import_hash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.imports_names_entropy" => static (e, v) => TryAssignFile("file.elf.imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfImportsNamesEntropy" => static (e, v) => TryAssignFile("file.elf.imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.imports_names_var_entropy" => static (e, v) => TryAssignFile("file.elf.imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfImportsNamesVarEntropy" => static (e, v) => TryAssignFile("file.elf.imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.elf.telfhash" => static (e, v) => TryAssignFile("file.elf.telfhash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileElfTelfhash" => static (e, v) => TryAssignFile("file.elf.telfhash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.macho.go_import_hash" => static (e, v) => TryAssignFile("file.macho.go_import_hash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMachoGoImportHash" => static (e, v) => TryAssignFile("file.macho.go_import_hash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.macho.go_imports" => static (e, v) => TryAssignFile("file.macho.go_imports")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMachoGoImports" => static (e, v) => TryAssignFile("file.macho.go_imports")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.macho.go_imports_names_entropy" => static (e, v) => TryAssignFile("file.macho.go_imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMachoGoImportsNamesEntropy" => static (e, v) => TryAssignFile("file.macho.go_imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.macho.go_imports_names_var_entropy" => static (e, v) => TryAssignFile("file.macho.go_imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMachoGoImportsNamesVarEntropy" => static (e, v) => TryAssignFile("file.macho.go_imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.macho.go_stripped" => static (e, v) => TryAssignFile("file.macho.go_stripped")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMachoGoStripped" => static (e, v) => TryAssignFile("file.macho.go_stripped")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.macho.import_hash" => static (e, v) => TryAssignFile("file.macho.import_hash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMachoImportHash" => static (e, v) => TryAssignFile("file.macho.import_hash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.macho.imports_names_entropy" => static (e, v) => TryAssignFile("file.macho.imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMachoImportsNamesEntropy" => static (e, v) => TryAssignFile("file.macho.imports_names_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.macho.imports_names_var_entropy" => static (e, v) => TryAssignFile("file.macho.imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMachoImportsNamesVarEntropy" => static (e, v) => TryAssignFile("file.macho.imports_names_var_entropy")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.file.macho.symhash" => static (e, v) => TryAssignFile("file.macho.symhash")(e.IndicatorFile ??= new File(),v),
				"ThreatIndicatorFileMachoSymhash" => static (e, v) => TryAssignFile("file.macho.symhash")(e.IndicatorFile ??= new File(),v),
				"threat.indicator.geo.city_name" => static (e, v) => TryAssignGeo("geo.city_name")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoCityName" => static (e, v) => TryAssignGeo("geo.city_name")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.continent_code" => static (e, v) => TryAssignGeo("geo.continent_code")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoContinentCode" => static (e, v) => TryAssignGeo("geo.continent_code")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.continent_name" => static (e, v) => TryAssignGeo("geo.continent_name")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoContinentName" => static (e, v) => TryAssignGeo("geo.continent_name")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.country_iso_code" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoCountryIsoCode" => static (e, v) => TryAssignGeo("geo.country_iso_code")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.country_name" => static (e, v) => TryAssignGeo("geo.country_name")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoCountryName" => static (e, v) => TryAssignGeo("geo.country_name")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.location" => static (e, v) => TryAssignGeo("geo.location")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoLocation" => static (e, v) => TryAssignGeo("geo.location")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.name" => static (e, v) => TryAssignGeo("geo.name")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoName" => static (e, v) => TryAssignGeo("geo.name")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.postal_code" => static (e, v) => TryAssignGeo("geo.postal_code")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoPostalCode" => static (e, v) => TryAssignGeo("geo.postal_code")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.region_iso_code" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoRegionIsoCode" => static (e, v) => TryAssignGeo("geo.region_iso_code")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.region_name" => static (e, v) => TryAssignGeo("geo.region_name")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoRegionName" => static (e, v) => TryAssignGeo("geo.region_name")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.geo.timezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.IndicatorGeo ??= new Geo(),v),
				"ThreatIndicatorGeoTimezone" => static (e, v) => TryAssignGeo("geo.timezone")(e.IndicatorGeo ??= new Geo(),v),
				"threat.indicator.registry.data.bytes" => static (e, v) => TryAssignRegistry("registry.data.bytes")(e.IndicatorRegistry ??= new Registry(),v),
				"ThreatIndicatorRegistryDataBytes" => static (e, v) => TryAssignRegistry("registry.data.bytes")(e.IndicatorRegistry ??= new Registry(),v),
				"threat.indicator.registry.data.type" => static (e, v) => TryAssignRegistry("registry.data.type")(e.IndicatorRegistry ??= new Registry(),v),
				"ThreatIndicatorRegistryDataType" => static (e, v) => TryAssignRegistry("registry.data.type")(e.IndicatorRegistry ??= new Registry(),v),
				"threat.indicator.registry.hive" => static (e, v) => TryAssignRegistry("registry.hive")(e.IndicatorRegistry ??= new Registry(),v),
				"ThreatIndicatorRegistryHive" => static (e, v) => TryAssignRegistry("registry.hive")(e.IndicatorRegistry ??= new Registry(),v),
				"threat.indicator.registry.key" => static (e, v) => TryAssignRegistry("registry.key")(e.IndicatorRegistry ??= new Registry(),v),
				"ThreatIndicatorRegistryKey" => static (e, v) => TryAssignRegistry("registry.key")(e.IndicatorRegistry ??= new Registry(),v),
				"threat.indicator.registry.path" => static (e, v) => TryAssignRegistry("registry.path")(e.IndicatorRegistry ??= new Registry(),v),
				"ThreatIndicatorRegistryPath" => static (e, v) => TryAssignRegistry("registry.path")(e.IndicatorRegistry ??= new Registry(),v),
				"threat.indicator.registry.value" => static (e, v) => TryAssignRegistry("registry.value")(e.IndicatorRegistry ??= new Registry(),v),
				"ThreatIndicatorRegistryValue" => static (e, v) => TryAssignRegistry("registry.value")(e.IndicatorRegistry ??= new Registry(),v),
				"threat.indicator.url.domain" => static (e, v) => TryAssignUrl("url.domain")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlDomain" => static (e, v) => TryAssignUrl("url.domain")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.extension" => static (e, v) => TryAssignUrl("url.extension")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlExtension" => static (e, v) => TryAssignUrl("url.extension")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.fragment" => static (e, v) => TryAssignUrl("url.fragment")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlFragment" => static (e, v) => TryAssignUrl("url.fragment")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.full" => static (e, v) => TryAssignUrl("url.full")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlFull" => static (e, v) => TryAssignUrl("url.full")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.original" => static (e, v) => TryAssignUrl("url.original")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlOriginal" => static (e, v) => TryAssignUrl("url.original")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.password" => static (e, v) => TryAssignUrl("url.password")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlPassword" => static (e, v) => TryAssignUrl("url.password")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.path" => static (e, v) => TryAssignUrl("url.path")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlPath" => static (e, v) => TryAssignUrl("url.path")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.port" => static (e, v) => TryAssignUrl("url.port")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlPort" => static (e, v) => TryAssignUrl("url.port")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.query" => static (e, v) => TryAssignUrl("url.query")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlQuery" => static (e, v) => TryAssignUrl("url.query")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.registered_domain" => static (e, v) => TryAssignUrl("url.registered_domain")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlRegisteredDomain" => static (e, v) => TryAssignUrl("url.registered_domain")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.scheme" => static (e, v) => TryAssignUrl("url.scheme")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlScheme" => static (e, v) => TryAssignUrl("url.scheme")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.subdomain" => static (e, v) => TryAssignUrl("url.subdomain")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlSubdomain" => static (e, v) => TryAssignUrl("url.subdomain")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.top_level_domain" => static (e, v) => TryAssignUrl("url.top_level_domain")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlTopLevelDomain" => static (e, v) => TryAssignUrl("url.top_level_domain")(e.IndicatorUrl ??= new Url(),v),
				"threat.indicator.url.username" => static (e, v) => TryAssignUrl("url.username")(e.IndicatorUrl ??= new Url(),v),
				"ThreatIndicatorUrlUsername" => static (e, v) => TryAssignUrl("url.username")(e.IndicatorUrl ??= new Url(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetThreat(EcsDocument document, string path, object value)
		{
			var assign = TryAssignThreat(path);
			if (assign == null) return false;
		
			var entity = document.Threat ?? new Threat();
			var assigned = assign(entity, value);
			if (assigned) document.Threat = entity;
			return assigned;
		}

		public static Func<Tls, object, bool> TryAssignTls(string path)
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
				"tls.client.x509.issuer.distinguished_name" => static (e, v) => TryAssignX509("x509.issuer.distinguished_name")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509IssuerDistinguishedName" => static (e, v) => TryAssignX509("x509.issuer.distinguished_name")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.not_after" => static (e, v) => TryAssignX509("x509.not_after")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509NotAfter" => static (e, v) => TryAssignX509("x509.not_after")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.not_before" => static (e, v) => TryAssignX509("x509.not_before")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509NotBefore" => static (e, v) => TryAssignX509("x509.not_before")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.public_key_algorithm" => static (e, v) => TryAssignX509("x509.public_key_algorithm")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509PublicKeyAlgorithm" => static (e, v) => TryAssignX509("x509.public_key_algorithm")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.public_key_curve" => static (e, v) => TryAssignX509("x509.public_key_curve")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509PublicKeyCurve" => static (e, v) => TryAssignX509("x509.public_key_curve")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.public_key_exponent" => static (e, v) => TryAssignX509("x509.public_key_exponent")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509PublicKeyExponent" => static (e, v) => TryAssignX509("x509.public_key_exponent")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.public_key_size" => static (e, v) => TryAssignX509("x509.public_key_size")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509PublicKeySize" => static (e, v) => TryAssignX509("x509.public_key_size")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.serial_number" => static (e, v) => TryAssignX509("x509.serial_number")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509SerialNumber" => static (e, v) => TryAssignX509("x509.serial_number")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.signature_algorithm" => static (e, v) => TryAssignX509("x509.signature_algorithm")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509SignatureAlgorithm" => static (e, v) => TryAssignX509("x509.signature_algorithm")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.subject.distinguished_name" => static (e, v) => TryAssignX509("x509.subject.distinguished_name")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509SubjectDistinguishedName" => static (e, v) => TryAssignX509("x509.subject.distinguished_name")(e.ClientX509 ??= new X509(),v),
				"tls.client.x509.version_number" => static (e, v) => TryAssignX509("x509.version_number")(e.ClientX509 ??= new X509(),v),
				"TlsClientX509VersionNumber" => static (e, v) => TryAssignX509("x509.version_number")(e.ClientX509 ??= new X509(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetTls(EcsDocument document, string path, object value)
		{
			var assign = TryAssignTls(path);
			if (assign == null) return false;
		
			var entity = document.Tls ?? new Tls();
			var assigned = assign(entity, value);
			if (assigned) document.Tls = entity;
			return assigned;
		}

		public static Func<Url, object, bool> TryAssignUrl(string path)
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
			return assign;
		}
		public static bool TrySetUrl(EcsDocument document, string path, object value)
		{
			var assign = TryAssignUrl(path);
			if (assign == null) return false;
		
			var entity = document.Url ?? new Url();
			var assigned = assign(entity, value);
			if (assigned) document.Url = entity;
			return assigned;
		}

		public static Func<User, object, bool> TryAssignUser(string path)
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
				"user.group.domain" => static (e, v) => TryAssignGroup("group.domain")(e.Group ??= new Group(),v),
				"UserGroupDomain" => static (e, v) => TryAssignGroup("group.domain")(e.Group ??= new Group(),v),
				"user.group.id" => static (e, v) => TryAssignGroup("group.id")(e.Group ??= new Group(),v),
				"UserGroupId" => static (e, v) => TryAssignGroup("group.id")(e.Group ??= new Group(),v),
				"user.group.name" => static (e, v) => TryAssignGroup("group.name")(e.Group ??= new Group(),v),
				"UserGroupName" => static (e, v) => TryAssignGroup("group.name")(e.Group ??= new Group(),v),
				"user.risk.calculated_level" => static (e, v) => TryAssignRisk("risk.calculated_level")(e.Risk ??= new Risk(),v),
				"UserRiskCalculatedLevel" => static (e, v) => TryAssignRisk("risk.calculated_level")(e.Risk ??= new Risk(),v),
				"user.risk.calculated_score" => static (e, v) => TryAssignRisk("risk.calculated_score")(e.Risk ??= new Risk(),v),
				"UserRiskCalculatedScore" => static (e, v) => TryAssignRisk("risk.calculated_score")(e.Risk ??= new Risk(),v),
				"user.risk.calculated_score_norm" => static (e, v) => TryAssignRisk("risk.calculated_score_norm")(e.Risk ??= new Risk(),v),
				"UserRiskCalculatedScoreNorm" => static (e, v) => TryAssignRisk("risk.calculated_score_norm")(e.Risk ??= new Risk(),v),
				"user.risk.static_level" => static (e, v) => TryAssignRisk("risk.static_level")(e.Risk ??= new Risk(),v),
				"UserRiskStaticLevel" => static (e, v) => TryAssignRisk("risk.static_level")(e.Risk ??= new Risk(),v),
				"user.risk.static_score" => static (e, v) => TryAssignRisk("risk.static_score")(e.Risk ??= new Risk(),v),
				"UserRiskStaticScore" => static (e, v) => TryAssignRisk("risk.static_score")(e.Risk ??= new Risk(),v),
				"user.risk.static_score_norm" => static (e, v) => TryAssignRisk("risk.static_score_norm")(e.Risk ??= new Risk(),v),
				"UserRiskStaticScoreNorm" => static (e, v) => TryAssignRisk("risk.static_score_norm")(e.Risk ??= new Risk(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetUser(IUser document, string path, object value)
		{
			var assign = TryAssignUser(path);
			if (assign == null) return false;
		
			var entity = document.User ?? new User();
			var assigned = assign(entity, value);
			if (assigned) document.User = entity;
			return assigned;
		}

		public static Func<UserAgent, object, bool> TryAssignUserAgent(string path)
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
				"user_agent.os.family" => static (e, v) => TryAssignOs("os.family")(e.Os ??= new Os(),v),
				"UserAgentOsFamily" => static (e, v) => TryAssignOs("os.family")(e.Os ??= new Os(),v),
				"user_agent.os.full" => static (e, v) => TryAssignOs("os.full")(e.Os ??= new Os(),v),
				"UserAgentOsFull" => static (e, v) => TryAssignOs("os.full")(e.Os ??= new Os(),v),
				"user_agent.os.kernel" => static (e, v) => TryAssignOs("os.kernel")(e.Os ??= new Os(),v),
				"UserAgentOsKernel" => static (e, v) => TryAssignOs("os.kernel")(e.Os ??= new Os(),v),
				"user_agent.os.name" => static (e, v) => TryAssignOs("os.name")(e.Os ??= new Os(),v),
				"UserAgentOsName" => static (e, v) => TryAssignOs("os.name")(e.Os ??= new Os(),v),
				"user_agent.os.platform" => static (e, v) => TryAssignOs("os.platform")(e.Os ??= new Os(),v),
				"UserAgentOsPlatform" => static (e, v) => TryAssignOs("os.platform")(e.Os ??= new Os(),v),
				"user_agent.os.type" => static (e, v) => TryAssignOs("os.type")(e.Os ??= new Os(),v),
				"UserAgentOsType" => static (e, v) => TryAssignOs("os.type")(e.Os ??= new Os(),v),
				"user_agent.os.version" => static (e, v) => TryAssignOs("os.version")(e.Os ??= new Os(),v),
				"UserAgentOsVersion" => static (e, v) => TryAssignOs("os.version")(e.Os ??= new Os(),v),
				_ => null
			};
			return assign;
		}
		public static bool TrySetUserAgent(EcsDocument document, string path, object value)
		{
			var assign = TryAssignUserAgent(path);
			if (assign == null) return false;
		
			var entity = document.UserAgent ?? new UserAgent();
			var assigned = assign(entity, value);
			if (assigned) document.UserAgent = entity;
			return assigned;
		}

		public static Func<Vlan, object, bool> TryAssignVlan(string path)
		{
			Func<Vlan, object, bool> assign = path switch
			{
				"vlan.id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"VlanId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Id = p),
				"vlan.name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				"VlanName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.Name = p),
				_ => null
			};
			return assign;
		}
		public static bool TrySetVlan(IVlan document, string path, object value)
		{
			var assign = TryAssignVlan(path);
			if (assign == null) return false;
		
			var entity = document.Vlan ?? new Vlan();
			var assigned = assign(entity, value);
			if (assigned) document.Vlan = entity;
			return assigned;
		}

		public static Func<Volume, object, bool> TryAssignVolume(string path)
		{
			Func<Volume, object, bool> assign = path switch
			{
				"volume.bus_type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.BusType = p),
				"VolumeBusType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.BusType = p),
				"volume.default_access" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DefaultAccess = p),
				"VolumeDefaultAccess" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DefaultAccess = p),
				"volume.device_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DeviceName = p),
				"VolumeDeviceName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DeviceName = p),
				"volume.device_type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DeviceType = p),
				"VolumeDeviceType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DeviceType = p),
				"volume.dos_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DosName = p),
				"VolumeDosName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.DosName = p),
				"volume.file_system_type" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FileSystemType = p),
				"VolumeFileSystemType" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.FileSystemType = p),
				"volume.mount_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.MountName = p),
				"VolumeMountName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.MountName = p),
				"volume.nt_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NtName = p),
				"VolumeNtName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.NtName = p),
				"volume.product_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ProductId = p),
				"VolumeProductId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ProductId = p),
				"volume.product_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ProductName = p),
				"VolumeProductName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.ProductName = p),
				"volume.removable" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Removable = p),
				"VolumeRemovable" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Removable = p),
				"volume.serial_number" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SerialNumber = p),
				"VolumeSerialNumber" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.SerialNumber = p),
				"volume.size" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Size = p),
				"VolumeSize" => static (e, v) => TrySetLong(e, v, static (ee, p) => ee.Size = p),
				"volume.vendor_id" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.VendorId = p),
				"VolumeVendorId" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.VendorId = p),
				"volume.vendor_name" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.VendorName = p),
				"VolumeVendorName" => static (e, v) => TrySetString(e, v, static (ee, p) => ee.VendorName = p),
				"volume.writable" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Writable = p),
				"VolumeWritable" => static (e, v) => TrySetBool(e, v, static (ee, p) => ee.Writable = p),
				_ => null
			};
			return assign;
		}
		public static bool TrySetVolume(EcsDocument document, string path, object value)
		{
			var assign = TryAssignVolume(path);
			if (assign == null) return false;
		
			var entity = document.Volume ?? new Volume();
			var assigned = assign(entity, value);
			if (assigned) document.Volume = entity;
			return assigned;
		}

		public static Func<Vulnerability, object, bool> TryAssignVulnerability(string path)
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
			return assign;
		}
		public static bool TrySetVulnerability(EcsDocument document, string path, object value)
		{
			var assign = TryAssignVulnerability(path);
			if (assign == null) return false;
		
			var entity = document.Vulnerability ?? new Vulnerability();
			var assigned = assign(entity, value);
			if (assigned) document.Vulnerability = entity;
			return assigned;
		}

		public static Func<X509, object, bool> TryAssignX509(string path)
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
			return assign;
		}
		public static bool TrySetX509(IX509 document, string path, object value)
		{
			var assign = TryAssignX509(path);
			if (assign == null) return false;
		
			var entity = document.X509 ?? new X509();
			var assigned = assign(entity, value);
			if (assigned) document.X509 = entity;
			return assigned;
		}
	}
}
