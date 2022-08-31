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

namespace Elastic.CommonSchema
{
	///<inheritdoc cref="BaseFieldSet"/>
	public partial class EcsDocument : BaseFieldSet 
	{

		/// <summary>
		/// Elastic Common Schema version v8.4.0
		/// </summary>
		public static string Version => "v8.4.0";

		/// <summary>
		/// Container for additional metadata against this event.
		/// </summary>
		[JsonPropertyName("metadata")]
		public IDictionary<string, object> Metadata { get; set; }


		///<summary>agent</summary>
		[JsonPropertyName("agent")]
		public Agent Agent { get; set; }

		///<summary>as</summary>
		[JsonPropertyName("as")]
		public As As { get; set; }

		///<summary>client</summary>
		[JsonPropertyName("client")]
		public Client Client { get; set; }

		///<summary>cloud</summary>
		[JsonPropertyName("cloud")]
		public Cloud Cloud { get; set; }

		///<summary>code_signature</summary>
		[JsonPropertyName("code_signature")]
		public CodeSignature CodeSignature { get; set; }

		///<summary>container</summary>
		[JsonPropertyName("container")]
		public Container Container { get; set; }

		///<summary>data_stream</summary>
		[JsonPropertyName("data_stream")]
		public DataStream DataStream { get; set; }

		///<summary>destination</summary>
		[JsonPropertyName("destination")]
		public Destination Destination { get; set; }

		///<summary>dll</summary>
		[JsonPropertyName("dll")]
		public Dll Dll { get; set; }

		///<summary>dns</summary>
		[JsonPropertyName("dns")]
		public Dns Dns { get; set; }

		///<summary>ecs</summary>
		[JsonPropertyName("ecs")]
		public Ecs Ecs { get; set; }

		///<summary>elf</summary>
		[JsonPropertyName("elf")]
		public Elf Elf { get; set; }

		///<summary>email</summary>
		[JsonPropertyName("email")]
		public Email Email { get; set; }

		///<summary>error</summary>
		[JsonPropertyName("error")]
		public Error Error { get; set; }

		///<summary>event</summary>
		[JsonPropertyName("event")]
		public Event Event { get; set; }

		///<summary>faas</summary>
		[JsonPropertyName("faas")]
		public Faas Faas { get; set; }

		///<summary>file</summary>
		[JsonPropertyName("file")]
		public File File { get; set; }

		///<summary>geo</summary>
		[JsonPropertyName("geo")]
		public Geo Geo { get; set; }

		///<summary>group</summary>
		[JsonPropertyName("group")]
		public Group Group { get; set; }

		///<summary>hash</summary>
		[JsonPropertyName("hash")]
		public Hash Hash { get; set; }

		///<summary>host</summary>
		[JsonPropertyName("host")]
		public Host Host { get; set; }

		///<summary>http</summary>
		[JsonPropertyName("http")]
		public Http Http { get; set; }

		///<summary>interface</summary>
		[JsonPropertyName("interface")]
		public Interface Interface { get; set; }

		///<summary>log</summary>
		[JsonPropertyName("log")]
		public Log Log { get; set; }

		///<summary>network</summary>
		[JsonPropertyName("network")]
		public Network Network { get; set; }

		///<summary>observer</summary>
		[JsonPropertyName("observer")]
		public Observer Observer { get; set; }

		///<summary>orchestrator</summary>
		[JsonPropertyName("orchestrator")]
		public Orchestrator Orchestrator { get; set; }

		///<summary>organization</summary>
		[JsonPropertyName("organization")]
		public Organization Organization { get; set; }

		///<summary>os</summary>
		[JsonPropertyName("os")]
		public Os Os { get; set; }

		///<summary>package</summary>
		[JsonPropertyName("package")]
		public Package Package { get; set; }

		///<summary>pe</summary>
		[JsonPropertyName("pe")]
		public Pe Pe { get; set; }

		///<summary>process</summary>
		[JsonPropertyName("process")]
		public Process Process { get; set; }

		///<summary>registry</summary>
		[JsonPropertyName("registry")]
		public Registry Registry { get; set; }

		///<summary>related</summary>
		[JsonPropertyName("related")]
		public Related Related { get; set; }

		///<summary>rule</summary>
		[JsonPropertyName("rule")]
		public Rule Rule { get; set; }

		///<summary>server</summary>
		[JsonPropertyName("server")]
		public Server Server { get; set; }

		///<summary>service</summary>
		[JsonPropertyName("service")]
		public Service Service { get; set; }

		///<summary>source</summary>
		[JsonPropertyName("source")]
		public Source Source { get; set; }

		///<summary>threat</summary>
		[JsonPropertyName("threat")]
		public Threat Threat { get; set; }

		///<summary>tls</summary>
		[JsonPropertyName("tls")]
		public Tls Tls { get; set; }

		///<summary>url</summary>
		[JsonPropertyName("url")]
		public Url Url { get; set; }

		///<summary>user</summary>
		[JsonPropertyName("user")]
		public User User { get; set; }

		///<summary>user_agent</summary>
		[JsonPropertyName("user_agent")]
		public UserAgent UserAgent { get; set; }

		///<summary>vlan</summary>
		[JsonPropertyName("vlan")]
		public Vlan Vlan { get; set; }

		///<summary>vulnerability</summary>
		[JsonPropertyName("vulnerability")]
		public Vulnerability Vulnerability { get; set; }

		///<summary>x509</summary>
		[JsonPropertyName("x509")]
		public X509 X509 { get; set; }
	}
}
