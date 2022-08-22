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

namespace Elastic.CommonSchema
{
	///<inheritdoc cref="BaseFieldSet"/>
	public partial class EcsDocument : BaseFieldSet 
	{

		/// <summary>
		/// Elastic Common Schema version v8.3.1
		/// </summary>
		public static string Version => "v8.3.1";

		/// <summary>
		/// Container for additional metadata against this event.
		/// </summary>
		[DataMember(Name = "metadata")]
		public IDictionary<string, object> Metadata { get; set; }


		///<summary>agent</summary>
		[DataMember(Name = "agent")]
		public Agent Agent { get; set; }

		///<summary>as</summary>
		[DataMember(Name = "as")]
		public As As { get; set; }

		///<summary>client</summary>
		[DataMember(Name = "client")]
		public Client Client { get; set; }

		///<summary>cloud</summary>
		[DataMember(Name = "cloud")]
		public Cloud Cloud { get; set; }

		///<summary>code_signature</summary>
		[DataMember(Name = "code_signature")]
		public CodeSignature CodeSignature { get; set; }

		///<summary>container</summary>
		[DataMember(Name = "container")]
		public Container Container { get; set; }

		///<summary>data_stream</summary>
		[DataMember(Name = "data_stream")]
		public DataStream DataStream { get; set; }

		///<summary>destination</summary>
		[DataMember(Name = "destination")]
		public Destination Destination { get; set; }

		///<summary>dll</summary>
		[DataMember(Name = "dll")]
		public Dll Dll { get; set; }

		///<summary>dns</summary>
		[DataMember(Name = "dns")]
		public Dns Dns { get; set; }

		///<summary>ecs</summary>
		[DataMember(Name = "ecs")]
		public Ecs Ecs { get; set; }

		///<summary>elf</summary>
		[DataMember(Name = "elf")]
		public Elf Elf { get; set; }

		///<summary>email</summary>
		[DataMember(Name = "email")]
		public Email Email { get; set; }

		///<summary>error</summary>
		[DataMember(Name = "error")]
		public Error Error { get; set; }

		///<summary>event</summary>
		[DataMember(Name = "event")]
		public Event Event { get; set; }

		///<summary>faas</summary>
		[DataMember(Name = "faas")]
		public Faas Faas { get; set; }

		///<summary>file</summary>
		[DataMember(Name = "file")]
		public File File { get; set; }

		///<summary>geo</summary>
		[DataMember(Name = "geo")]
		public Geo Geo { get; set; }

		///<summary>group</summary>
		[DataMember(Name = "group")]
		public Group Group { get; set; }

		///<summary>hash</summary>
		[DataMember(Name = "hash")]
		public Hash Hash { get; set; }

		///<summary>host</summary>
		[DataMember(Name = "host")]
		public Host Host { get; set; }

		///<summary>http</summary>
		[DataMember(Name = "http")]
		public Http Http { get; set; }

		///<summary>interface</summary>
		[DataMember(Name = "interface")]
		public Interface Interface { get; set; }

		///<summary>log</summary>
		[DataMember(Name = "log")]
		public Log Log { get; set; }

		///<summary>network</summary>
		[DataMember(Name = "network")]
		public Network Network { get; set; }

		///<summary>observer</summary>
		[DataMember(Name = "observer")]
		public Observer Observer { get; set; }

		///<summary>orchestrator</summary>
		[DataMember(Name = "orchestrator")]
		public Orchestrator Orchestrator { get; set; }

		///<summary>organization</summary>
		[DataMember(Name = "organization")]
		public Organization Organization { get; set; }

		///<summary>os</summary>
		[DataMember(Name = "os")]
		public Os Os { get; set; }

		///<summary>package</summary>
		[DataMember(Name = "package")]
		public Package Package { get; set; }

		///<summary>pe</summary>
		[DataMember(Name = "pe")]
		public Pe Pe { get; set; }

		///<summary>process</summary>
		[DataMember(Name = "process")]
		public Process Process { get; set; }

		///<summary>registry</summary>
		[DataMember(Name = "registry")]
		public Registry Registry { get; set; }

		///<summary>related</summary>
		[DataMember(Name = "related")]
		public Related Related { get; set; }

		///<summary>rule</summary>
		[DataMember(Name = "rule")]
		public Rule Rule { get; set; }

		///<summary>server</summary>
		[DataMember(Name = "server")]
		public Server Server { get; set; }

		///<summary>service</summary>
		[DataMember(Name = "service")]
		public Service Service { get; set; }

		///<summary>source</summary>
		[DataMember(Name = "source")]
		public Source Source { get; set; }

		///<summary>threat</summary>
		[DataMember(Name = "threat")]
		public Threat Threat { get; set; }

		///<summary>tls</summary>
		[DataMember(Name = "tls")]
		public Tls Tls { get; set; }

		///<summary>url</summary>
		[DataMember(Name = "url")]
		public Url Url { get; set; }

		///<summary>user</summary>
		[DataMember(Name = "user")]
		public User User { get; set; }

		///<summary>user_agent</summary>
		[DataMember(Name = "user_agent")]
		public UserAgent UserAgent { get; set; }

		///<summary>vlan</summary>
		[DataMember(Name = "vlan")]
		public Vlan Vlan { get; set; }

		///<summary>vulnerability</summary>
		[DataMember(Name = "vulnerability")]
		public Vulnerability Vulnerability { get; set; }

		///<summary>x509</summary>
		[DataMember(Name = "x509")]
		public X509 X509 { get; set; }
	}
}
