// Licensed to Elasticsearch B.V. under one or more contributor
// license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright
// ownership. Elasticsearch B.V. licenses this file to you under
// the Apache License, Version 2.0 (the "License"); you may
// not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using Nest;

namespace Elastic
{
    /// <summary>
    /// Elastic Common Schema utilities for version 1.2.
    /// To be used in conjunction with the NEST client.
    /// <para/>
    /// The Elastic Common Schema (ECS) defines a common set of fields for ingesting data into Elasticsearch.
    /// A common schema helps you correlate data from sources like logs and metrics or IT operations analytics
    /// and security analytics.
    /// <para/>
    /// https://github.com/elastic/ecs
    /// </summary>
    public class CommonSchemaUtilities
    {
        /// <summary>
        /// Get a Put Index Template Descriptor for use with <see cref="Nest.PutIndexTemplateRequest"/>
        /// designed for use with ECS schema version 1.2.
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
        /// designed for use with ECS schema version 1.2.
        /// </summary>
        /// <returns>An instance of <see cref="System.Func{Nest.TypeMappingDescriptor{Elastic.CommonSchema}}{Nest.ITypeMapping}"/>.</returns>
        public static Func<TypeMappingDescriptor<CommonSchema>, ITypeMapping> GetTypeMappingDescriptor()
        {
            return map =>
                 map.Meta(meta => meta.Add("version", "1.2"))
                    .DateDetection(false)
                    .DynamicTemplates(dynamicTemplate =>
                        dynamicTemplate.DynamicTemplate("strings_as_keyword",
                            template =>
                                template.MatchMappingType("string")
                                    .Mapping(mapping =>
                                        mapping.Keyword(keyword =>
                                            keyword.IgnoreAbove(1024)))))
                    .Properties<CommonSchema>(properties =>
                        properties
                            .Date(p => p.Name(n => n.Timestamp))
                            .Keyword(p => p.Name(n => n.Tags).IgnoreAbove(1024))
                            .Object<object>(p => p.Name(n => n.Labels))
                            .Text(p => p.Name(n => n.Message).Norms(false))
                            .Object<Agent>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.EphemeralId).IgnoreAbove(1024))
                            ))
                            .Object<As>(o =>
                                o.Properties(a => a
                                    .Number(p => p.Name(n => n.Number).Type(NumberType.Long))
                            ))
                            .Object<Client>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
                            ))
                            .Object<Cloud>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Provider).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.AvailabilityZone).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Region).IgnoreAbove(1024))
                            ))
                            .Object<Container>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Runtime).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Object<object>(p => p.Name(n => n.Labels))
                            ))
                            .Object<Destination>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
                            ))
                            .Object<Dns>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OpCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.HeaderFlags).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.ResponseCode).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.ResolvedIp))
                            ))
                            .Object<Ecs>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                            ))
                            .Object<Error>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Text(p => p.Name(n => n.Message).Norms(false))
                                    .Keyword(p => p.Name(n => n.Code).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.StackTrace).IgnoreAbove(1024).Index(false).DocValues(false))
                            ))
                            .Object<Event>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Code).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Kind).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Category).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Action).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Outcome).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Module).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Dataset).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Provider).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Severity).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024).Index(false).DocValues(false))
                                    .Keyword(p => p.Name(n => n.Hash).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Duration).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.Sequence).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Timezone).IgnoreAbove(1024))
                                    .Date(p => p.Name(n => n.Created))
                                    .Date(p => p.Name(n => n.Start))
                                    .Date(p => p.Name(n => n.End))
                                    .Number(p => p.Name(n => n.RiskScore).Type(NumberType.Float))
                                    .Number(p => p.Name(n => n.RiskScoreNorm).Type(NumberType.Float))
                            ))
                            .Object<File>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Directory).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Path).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.TargetPath).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Extension).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Device).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Inode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Uid).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Owner).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Gid).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Group).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Mode).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Size).Type(NumberType.Long))
                                    .Date(p => p.Name(n => n.Mtime))
                                    .Date(p => p.Name(n => n.Ctime))
                                    .Date(p => p.Name(n => n.Created))
                                    .Date(p => p.Name(n => n.Accessed))
                            ))
                            .Object<Geo>(o =>
                                o.Properties(a => a
                                    .GeoPoint(p => p.Name(n => n.Location))
                                    .Keyword(p => p.Name(n => n.ContinentName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.CountryName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.RegionName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.CityName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.CountryIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.RegionIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                            ))
                            .Object<Group>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                            ))
                            .Object<Hash>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Md5).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Sha1).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Sha256).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Sha512).IgnoreAbove(1024))
                            ))
                            .Object<Host>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Hostname).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Uptime).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Architecture).IgnoreAbove(1024))
                            ))
                            .Object<Http>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                            ))
                            .Object<Log>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Level).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024).Index(false).DocValues(false))
                                    .Keyword(p => p.Name(n => n.Logger).IgnoreAbove(1024))
                            ))
                            .Object<Network>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.IanaNumber).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Transport).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Application).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Protocol).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Direction).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.ForwardedIp))
                                    .Keyword(p => p.Name(n => n.CommunityId).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
                            ))
                            .Object<Observer>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Keyword(p => p.Name(n => n.Hostname).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Product).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Vendor).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.SerialNumber).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                            ))
                            .Object<Organization>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                            ))
                            .Object<Os>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Platform).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Full).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Family).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Kernel).IgnoreAbove(1024))
                            ))
                            .Object<Package>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Description).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Size).Type(NumberType.Long))
                                    .Date(p => p.Name(n => n.Installed))
                                    .Keyword(p => p.Name(n => n.Path).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Architecture).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Checksum).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.InstallScope).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.License).IgnoreAbove(1024))
                            ))
                            .Object<Process>(o =>
                                o.Properties(a => a
                                    .Number(p => p.Name(n => n.Pid).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Ppid).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.Pgid).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Args).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Executable).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Title).IgnoreAbove(1024))
                                    .Date(p => p.Name(n => n.Start))
                                    .Number(p => p.Name(n => n.Uptime).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.WorkingDirectory).IgnoreAbove(1024))
                            ))
                            .Object<Related>(o =>
                                o.Properties(a => a
                                    .Ip(p => p.Name(n => n.Ip))
                            ))
                            .Object<Server>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
                            ))
                            .Object<Service>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.State).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.EphemeralId).IgnoreAbove(1024))
                            ))
                            .Object<Source>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
                            ))
                            .Object<Threat>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Framework).IgnoreAbove(1024))
                            ))
                            .Object<Tracing>(o =>
                                o.Properties(a => a
                            ))
                            .Object<Url>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Full).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Scheme).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.RegisteredDomain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.TopLevelDomain).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Path).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Query).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Extension).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Fragment).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Username).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Password).IgnoreAbove(1024))
                            ))
                            .Object<User>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.FullName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Email).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Hash).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                            ))
                            .Object<UserAgent>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                            ))
                        );
        }
    }
}