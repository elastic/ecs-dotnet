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

namespace Elastic.CommonSchema
{
	///<inheritdoc cref="BaseFieldSet"/>
	public partial class EcsDocument : BaseFieldSet 
	{

		/// <summary>
		/// Elastic Common Schema version 8.6.0
		/// </summary>
		public static string Version => "8.6.0";

		/// <summary>
		/// Container for additional metadata against this event.
		/// <para/>
		/// When working with unknown fields use <see cref="AssignField"/>. <br/>
		/// <para> This will try to assign valid ECS fields to their respective property 
		/// Failing that it will assign strings to <see cref="Labels"/> and everything else to <see cref="Metadata"/> </para>
		/// </summary>
		[JsonPropertyName("metadata"), DataMember(Name = "metadata")]
		[JsonConverter(typeof(MetadataDictionaryConverter))]
		public MetadataDictionary Metadata { get; set; }


		///<summary>agent</summary>
		[JsonPropertyName("agent"), DataMember(Name = "agent")]
		public Agent Agent { get; set; }

		///<summary>as</summary>
		[JsonPropertyName("as"), DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>client</summary>
		[JsonPropertyName("client"), DataMember(Name = "client")]
		public Client Client { get; set; }

		///<summary>cloud</summary>
		[JsonPropertyName("cloud"), DataMember(Name = "cloud")]
		public Cloud Cloud { get; set; }

		///<summary>code_signature</summary>
		[JsonPropertyName("code_signature"), DataMember(Name = "code_signature")]
		public CodeSignature CodeSignature { get; set; }

		///<summary>container</summary>
		[JsonPropertyName("container"), DataMember(Name = "container")]
		public Container Container { get; set; }

		///<summary>data_stream</summary>
		[JsonPropertyName("data_stream"), DataMember(Name = "data_stream")]
		public DataStream DataStream { get; set; }

		///<summary>destination</summary>
		[JsonPropertyName("destination"), DataMember(Name = "destination")]
		public Destination Destination { get; set; }

		///<summary>device</summary>
		[JsonPropertyName("device"), DataMember(Name = "device")]
		public Device Device { get; set; }

		///<summary>dll</summary>
		[JsonPropertyName("dll"), DataMember(Name = "dll")]
		public Dll Dll { get; set; }

		///<summary>dns</summary>
		[JsonPropertyName("dns"), DataMember(Name = "dns")]
		public Dns Dns { get; set; }

		///<summary>ecs</summary>
		[JsonPropertyName("ecs"), DataMember(Name = "ecs")]
		public Ecs Ecs { get; set; }

		///<summary>elf</summary>
		[JsonPropertyName("elf"), DataMember(Name = "elf")]
		public Elf Elf { get; set; }

		///<summary>email</summary>
		[JsonPropertyName("email"), DataMember(Name = "email")]
		public Email Email { get; set; }

		///<summary>error</summary>
		[JsonPropertyName("error"), DataMember(Name = "error")]
		public Error Error { get; set; }

		///<summary>event</summary>
		[JsonPropertyName("event"), DataMember(Name = "event")]
		public Event Event { get; set; }

		///<summary>faas</summary>
		[JsonPropertyName("faas"), DataMember(Name = "faas")]
		public Faas Faas { get; set; }

		///<summary>file</summary>
		[JsonPropertyName("file"), DataMember(Name = "file")]
		public File File { get; set; }

		///<summary>geo</summary>
		[JsonPropertyName("geo"), DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>group</summary>
		[JsonPropertyName("group"), DataMember(Name = "group")]
		public Group Group { get; set; }

		///<summary>hash</summary>
		[JsonPropertyName("hash"), DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		///<summary>host</summary>
		[JsonPropertyName("host"), DataMember(Name = "host")]
		public Host Host { get; set; }

		///<summary>http</summary>
		[JsonPropertyName("http"), DataMember(Name = "http")]
		public Http Http { get; set; }

		///<summary>interface</summary>
		[JsonPropertyName("interface"), DataMember(Name = "interface")]
		public Interface Interface { get; set; }

		///<summary>log</summary>
		[JsonPropertyName("log"), DataMember(Name = "log")]
		public Log Log { get; set; }

		///<summary>network</summary>
		[JsonPropertyName("network"), DataMember(Name = "network")]
		public Network Network { get; set; }

		///<summary>observer</summary>
		[JsonPropertyName("observer"), DataMember(Name = "observer")]
		public Observer Observer { get; set; }

		///<summary>orchestrator</summary>
		[JsonPropertyName("orchestrator"), DataMember(Name = "orchestrator")]
		public Orchestrator Orchestrator { get; set; }

		///<summary>organization</summary>
		[JsonPropertyName("organization"), DataMember(Name = "organization")]
		public Organization Organization { get; set; }

		///<summary>os</summary>
		[JsonPropertyName("os"), DataMember(Name = "os")]
		public Os Os { get; set; }

		///<summary>package</summary>
		[JsonPropertyName("package"), DataMember(Name = "package")]
		public Package Package { get; set; }

		///<summary>pe</summary>
		[JsonPropertyName("pe"), DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		///<summary>process</summary>
		[JsonPropertyName("process"), DataMember(Name = "process")]
		public Process Process { get; set; }

		///<summary>registry</summary>
		[JsonPropertyName("registry"), DataMember(Name = "registry")]
		public Registry Registry { get; set; }

		///<summary>related</summary>
		[JsonPropertyName("related"), DataMember(Name = "related")]
		public Related Related { get; set; }

		///<summary>risk</summary>
		[JsonPropertyName("risk"), DataMember(Name = "risk")]
		public Risk Risk { get; set; }

		///<summary>rule</summary>
		[JsonPropertyName("rule"), DataMember(Name = "rule")]
		public Rule Rule { get; set; }

		///<summary>server</summary>
		[JsonPropertyName("server"), DataMember(Name = "server")]
		public Server Server { get; set; }

		///<summary>service</summary>
		[JsonPropertyName("service"), DataMember(Name = "service")]
		public Service Service { get; set; }

		///<summary>source</summary>
		[JsonPropertyName("source"), DataMember(Name = "source")]
		public Source Source { get; set; }

		///<summary>threat</summary>
		[JsonPropertyName("threat"), DataMember(Name = "threat")]
		public Threat Threat { get; set; }

		///<summary>tls</summary>
		[JsonPropertyName("tls"), DataMember(Name = "tls")]
		public Tls Tls { get; set; }

		///<summary>url</summary>
		[JsonPropertyName("url"), DataMember(Name = "url")]
		public Url Url { get; set; }

		///<summary>user</summary>
		[JsonPropertyName("user"), DataMember(Name = "user")]
		public User User { get; set; }

		///<summary>user_agent</summary>
		[JsonPropertyName("user_agent"), DataMember(Name = "user_agent")]
		public UserAgent UserAgent { get; set; }

		///<summary>vlan</summary>
		[JsonPropertyName("vlan"), DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }

		///<summary>vulnerability</summary>
		[JsonPropertyName("vulnerability"), DataMember(Name = "vulnerability")]
		public Vulnerability Vulnerability { get; set; }

		///<summary>x509</summary>
		[JsonPropertyName("x509"), DataMember(Name = "x509")]
		public X509 X509 { get; set; }
	}
}
