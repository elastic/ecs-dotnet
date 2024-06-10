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
	///<summary>All properties that <see cref="EcsDocument.AssignField" /> supports </summary>
	public static class LogTemplateEntities
	{

		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Agent"/> </summary>
		public static string Agent = nameof(Agent);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.As"/> </summary>
		public static string As = nameof(As);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Client"/> </summary>
		public static string Client = nameof(Client);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Cloud"/> </summary>
		public static string Cloud = nameof(Cloud);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.CodeSignature"/> </summary>
		public static string CodeSignature = nameof(CodeSignature);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Container"/> </summary>
		public static string Container = nameof(Container);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.DataStream"/> </summary>
		public static string DataStream = nameof(DataStream);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Destination"/> </summary>
		public static string Destination = nameof(Destination);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Device"/> </summary>
		public static string Device = nameof(Device);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Dll"/> </summary>
		public static string Dll = nameof(Dll);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Dns"/> </summary>
		public static string Dns = nameof(Dns);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Ecs"/> </summary>
		public static string Ecs = nameof(Ecs);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Elf"/> </summary>
		public static string Elf = nameof(Elf);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Email"/> </summary>
		public static string Email = nameof(Email);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Error"/> </summary>
		public static string Error = nameof(Error);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Event"/> </summary>
		public static string Event = nameof(Event);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Faas"/> </summary>
		public static string Faas = nameof(Faas);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.File"/> </summary>
		public static string File = nameof(File);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Geo"/> </summary>
		public static string Geo = nameof(Geo);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Group"/> </summary>
		public static string Group = nameof(Group);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Hash"/> </summary>
		public static string Hash = nameof(Hash);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Host"/> </summary>
		public static string Host = nameof(Host);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Http"/> </summary>
		public static string Http = nameof(Http);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Interface"/> </summary>
		public static string Interface = nameof(Interface);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Log"/> </summary>
		public static string Log = nameof(Log);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Macho"/> </summary>
		public static string Macho = nameof(Macho);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Network"/> </summary>
		public static string Network = nameof(Network);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Observer"/> </summary>
		public static string Observer = nameof(Observer);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Orchestrator"/> </summary>
		public static string Orchestrator = nameof(Orchestrator);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Organization"/> </summary>
		public static string Organization = nameof(Organization);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Os"/> </summary>
		public static string Os = nameof(Os);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Package"/> </summary>
		public static string Package = nameof(Package);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Pe"/> </summary>
		public static string Pe = nameof(Pe);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Process"/> </summary>
		public static string Process = nameof(Process);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Registry"/> </summary>
		public static string Registry = nameof(Registry);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Related"/> </summary>
		public static string Related = nameof(Related);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Risk"/> </summary>
		public static string Risk = nameof(Risk);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Rule"/> </summary>
		public static string Rule = nameof(Rule);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Server"/> </summary>
		public static string Server = nameof(Server);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Service"/> </summary>
		public static string Service = nameof(Service);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Source"/> </summary>
		public static string Source = nameof(Source);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Threat"/> </summary>
		public static string Threat = nameof(Threat);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Tls"/> </summary>
		public static string Tls = nameof(Tls);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Url"/> </summary>
		public static string Url = nameof(Url);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.User"/> </summary>
		public static string User = nameof(User);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.UserAgent"/> </summary>
		public static string UserAgent = nameof(UserAgent);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Vlan"/> </summary>
		public static string Vlan = nameof(Vlan);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.Vulnerability"/> </summary>
		public static string Vulnerability = nameof(Vulnerability);
		///<summary>Static field name to supply an instance of <see cref="Elastic.CommonSchema.X509"/> </summary>
		public static string X509 = nameof(X509);

		///<summary>All properties that <see cref="EcsDocument.AssignField" /> supports </summary>
		public static readonly HashSet<string> All = new()
		{

			"agent", "Agent",
			"as", "As",
			"client", "Client",
			"cloud", "Cloud",
			"codesignature", "CodeSignature",
			"container", "Container",
			"datastream", "DataStream",
			"destination", "Destination",
			"device", "Device",
			"dll", "Dll",
			"dns", "Dns",
			"ecs", "Ecs",
			"elf", "Elf",
			"email", "Email",
			"error", "Error",
			"event", "Event",
			"faas", "Faas",
			"file", "File",
			"geo", "Geo",
			"group", "Group",
			"hash", "Hash",
			"host", "Host",
			"http", "Http",
			"interface", "Interface",
			"log", "Log",
			"macho", "Macho",
			"network", "Network",
			"observer", "Observer",
			"orchestrator", "Orchestrator",
			"organization", "Organization",
			"os", "Os",
			"package", "Package",
			"pe", "Pe",
			"process", "Process",
			"registry", "Registry",
			"related", "Related",
			"risk", "Risk",
			"rule", "Rule",
			"server", "Server",
			"service", "Service",
			"source", "Source",
			"threat", "Threat",
			"tls", "Tls",
			"url", "Url",
			"user", "User",
			"useragent", "UserAgent",
			"vlan", "Vlan",
			"vulnerability", "Vulnerability",
			"x509", "X509",
		};
	}

}