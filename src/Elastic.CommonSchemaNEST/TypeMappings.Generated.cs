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
using Nest;

namespace Elastic.CommonSchema.Elasticsearch
{
	/// <summary>
	/// Utilities for Elastic Common Schema version 1.6.0
	/// To be used in conjunction with the NEST client.
	/// <para/>
	/// The Elastic Common Schema (ECS) defines a common set of fields for ingesting data into Elasticsearch.
	/// A common schema helps you correlate data from sources like logs and metrics or IT operations analytics
	/// and security analytics.
	/// <para/>
	/// See: https://github.com/elastic/ecs
	/// </summary>
	public class NESTIndexTemplates
	{
		/// <summary>
		/// Get a Put Index Template Descriptor for use with <see cref="Nest.PutIndexTemplateRequest"/>
		/// designed for use with Elastic Common Schema version 1.6.0
		/// </summary>
		/// <param name="name">The name of the index template.</param>
		/// <returns>An instance of <see cref="Nest.PutIndexTemplateDescriptor"/>.</returns>
		public static PutIndexTemplateDescriptor GetIndexTemplate(Name name)
		{
			var indexTemplate = new PutIndexTemplateDescriptor(name);

			indexTemplate.IndexPatterns("ecs-*");
			indexTemplate.Order(1);
			indexTemplate.Settings(s =>
				s.Setting("index", 
					new
					{
						refresh_interval = "5s",
						mapping = new
						{
							total_fields = new
							{
								limit = 100000
							}
						}
					}));

			indexTemplate.Map(GetTypeMappingDescriptor());
			
			return indexTemplate;
		}

		/// <summary>
		/// Get a type mapping descriptor for use with <see cref="Nest.PutIndexTemplateDescriptor"/>
		/// designed for use with Elastic Common Schema version 1.6.0
		/// </summary>
		public static Func<TypeMappingDescriptor<Base>, ITypeMapping> GetTypeMappingDescriptor()
		{
			return map =>
				 map.Meta(meta => meta.Add("version", "1.6.0"))
					.DateDetection(false)
					.DynamicTemplates(dynamicTemplate =>
						dynamicTemplate.DynamicTemplate("strings_as_keyword",
							template =>
								template.MatchMappingType("string")
									.Mapping(mapping =>
										mapping.Keyword(keyword =>
											keyword.IgnoreAbove(1024)))))
					.Properties<Base>(properties =>
						properties
							.Date(p => p.Name(n => n.Timestamp))
							.Object<IDictionary<string, string>>(p => p.Name(n => n.Labels))
							.Text(p => p.Name(n => n.Message).Norms(false))
							.Keyword(p => p.Name(n => n.Tags).IgnoreAbove(1024))
							.Object<Agent>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.EphemeralId).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
							))
							.Object<Client>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
									.Ip(p => p.Name(n => n.Ip))
									.Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
									.Number(p => p.Name(n => n.Port).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
							))
							.Object<Cloud>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.AvailabilityZone).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Provider).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Region).IgnoreAbove(1024))
							))
							.Object<Container>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Object<IDictionary<string, string>>(p => p.Name(n => n.Labels))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Runtime).IgnoreAbove(1024))
							))
							.Object<Destination>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
									.Ip(p => p.Name(n => n.Ip))
									.Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
									.Number(p => p.Name(n => n.Port).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
							))
							.Object<Dll>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Path).IgnoreAbove(1024))
							))
							.Object<Dns>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.HeaderFlags).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.OpCode).IgnoreAbove(1024))
									.Ip(p => p.Name(n => n.ResolvedIp))
									.Keyword(p => p.Name(n => n.ResponseCode).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
							))
							.Object<Ecs>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
							))
							.Object<Error>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Code).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Text(p => p.Name(n => n.Message).Norms(false))
									.Keyword(p => p.Name(n => n.StackTrace).IgnoreAbove(1024).Index(false).DocValues(false))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
							))
							.Object<Event>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Action).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Category).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Code).IgnoreAbove(1024))
									.Date(p => p.Name(n => n.Created))
									.Keyword(p => p.Name(n => n.Dataset).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Duration).Type(NumberType.Long))
									.Date(p => p.Name(n => n.End))
									.Keyword(p => p.Name(n => n.Hash).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Date(p => p.Name(n => n.Ingested))
									.Keyword(p => p.Name(n => n.Kind).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Module).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024).Index(false).DocValues(false))
									.Keyword(p => p.Name(n => n.Outcome).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Provider).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Reason).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Reference).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.RiskScore).Type(NumberType.Float))
									.Number(p => p.Name(n => n.RiskScoreNorm).Type(NumberType.Float))
									.Number(p => p.Name(n => n.Sequence).Type(NumberType.Long))
									.Number(p => p.Name(n => n.Severity).Type(NumberType.Long))
									.Date(p => p.Name(n => n.Start))
									.Keyword(p => p.Name(n => n.Timezone).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Url).IgnoreAbove(1024))
							))
							.Object<File>(o =>
								o.Properties(a => a
									.Date(p => p.Name(n => n.Accessed))
									.Keyword(p => p.Name(n => n.Attributes).IgnoreAbove(1024))
									.Date(p => p.Name(n => n.Created))
									.Date(p => p.Name(n => n.Ctime))
									.Keyword(p => p.Name(n => n.Device).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Directory).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.DriveLetter).IgnoreAbove(1))
									.Keyword(p => p.Name(n => n.Extension).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Gid).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Group).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Inode).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.MimeType).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Mode).IgnoreAbove(1024))
									.Date(p => p.Name(n => n.Mtime))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Owner).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Path).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Size).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.TargetPath).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Uid).IgnoreAbove(1024))
							))
							.Object<Group>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
							))
							.Object<Host>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Architecture).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Hostname).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Ip(p => p.Name(n => n.Ip))
									.Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Uptime).Type(NumberType.Long))
							))
							.Object<Http>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
							))
							.Object<Log>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Level).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Logger).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024).Index(false).DocValues(false))
							))
							.Object<Network>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Application).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.CommunityId).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Direction).IgnoreAbove(1024))
									.Ip(p => p.Name(n => n.ForwardedIp))
									.Keyword(p => p.Name(n => n.IanaNumber).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.Protocol).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Transport).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
							))
							.Object<Observer>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Hostname).IgnoreAbove(1024))
									.Ip(p => p.Name(n => n.Ip))
									.Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Product).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.SerialNumber).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Vendor).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
							))
							.Object<Organization>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
							))
							.Object<Package>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Architecture).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.BuildVersion).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Checksum).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Description).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.InstallScope).IgnoreAbove(1024))
									.Date(p => p.Name(n => n.Installed))
									.Keyword(p => p.Name(n => n.License).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Path).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Reference).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Size).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
							))
							.Object<Process>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Args).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.ArgsCount).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.CommandLine).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.EntityId).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Executable).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.ExitCode).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Pgid).Type(NumberType.Long))
									.Number(p => p.Name(n => n.Pid).Type(NumberType.Long))
									.Number(p => p.Name(n => n.Ppid).Type(NumberType.Long))
									.Date(p => p.Name(n => n.Start))
									.Keyword(p => p.Name(n => n.Title).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Uptime).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.WorkingDirectory).IgnoreAbove(1024))
							))
							.Object<Registry>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Hive).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Key).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Path).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Value).IgnoreAbove(1024))
							))
							.Object<Related>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Hash).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Hosts).IgnoreAbove(1024))
									.Ip(p => p.Name(n => n.Ip))
									.Keyword(p => p.Name(n => n.User).IgnoreAbove(1024))
							))
							.Object<Rule>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Author).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Category).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Description).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.License).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Reference).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Ruleset).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Uuid).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
							))
							.Object<Server>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
									.Ip(p => p.Name(n => n.Ip))
									.Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
									.Number(p => p.Name(n => n.Port).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
							))
							.Object<Service>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.EphemeralId).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.State).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
							))
							.Object<Source>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
									.Ip(p => p.Name(n => n.Ip))
									.Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
									.Number(p => p.Name(n => n.Port).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
							))
							.Object<Threat>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Framework).IgnoreAbove(1024))
							))
							.Object<Tls>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Cipher).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Curve).IgnoreAbove(1024))
									.Boolean(p => p.Name(n => n.Established))
									.Keyword(p => p.Name(n => n.NextProtocol).IgnoreAbove(1024))
									.Boolean(p => p.Name(n => n.Resumed))
									.Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.VersionProtocol).IgnoreAbove(1024))
							))
							.Object<Url>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Extension).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Fragment).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Full).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Password).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Path).IgnoreAbove(1024))
									.Number(p => p.Name(n => n.Port).Type(NumberType.Long))
									.Keyword(p => p.Name(n => n.Query).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Scheme).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Username).IgnoreAbove(1024))
							))
							.Object<User>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Email).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.FullName).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Hash).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Roles).IgnoreAbove(1024))
							))
							.Object<UserAgent>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
							))
							.Object<Vulnerability>(o =>
								o.Properties(a => a
									.Keyword(p => p.Name(n => n.Category).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Classification).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Description).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Enumeration).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Reference).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.ReportId).IgnoreAbove(1024))
									.Keyword(p => p.Name(n => n.Severity).IgnoreAbove(1024))
							))
						);
		}
	}
}