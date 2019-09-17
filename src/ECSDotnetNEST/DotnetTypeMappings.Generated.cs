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
using ElasticCommonSchema;

namespace ElasticCommonSchema
{
    public class ECSNamespace : NamespacedClientProxy
    {
        internal ECSNamespace(ElasticClient client) : base(client) { }

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

            indexTemplate.Map(GetTypeDescriptor());
            
            return indexTemplate;
        }

        private static Func<TypeMappingDescriptor<ECS>, ITypeMapping> GetTypeDescriptor()
        {
            return map =>
                map.Meta(meta => meta.Add("version", "1.1.0"))
                    .DateDetection(false)
                    .DynamicTemplates(dynamicTemplate =>
                        dynamicTemplate.DynamicTemplate("strings_as_keyword",
                            template =>
                                template.MatchMappingType("string")
                                    .Mapping(mapping =>
                                        mapping.Keyword(keyword =>
                                            keyword.IgnoreAbove(1024)))))
                    .Properties<ECS>(properties =>
                        properties
                            .Date(p => p.Name(n => n.))
                            .Keyword(p => p.Name(n => n.).IgnoreAbove(1024))
                            .Object<object>(p => p.Name(n => n.))
                            .Text(p => p.Name(n => n.))
                            .Object<Agent>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.EphemeralId).IgnoreAbove(1024))
                            ))
                            .Object<Client>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
                                    .GeoPoint(p => p.Name(n => n.GeoLocation))
                                    .Keyword(p => p.Name(n => n.UserGroupId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoContinentName).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Keyword(p => p.Name(n => n.UserGroupName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCountryName).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.UserFullName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserEmail).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCityName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserHash).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.GeoCountryIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionIsoCode).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.GeoName).IgnoreAbove(1024))
                            ))
                            .Object<Cloud>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Provider).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.AvailabilityZone).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Region).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.InstanceId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.InstanceName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.MachineType).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.AccountId).IgnoreAbove(1024))
                            ))
                            .Object<Container>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Runtime).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.ImageName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.ImageTag).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Object<object>(p => p.Name(n => n.Labels))
                            ))
                            .Object<Destination>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
                                    .GeoPoint(p => p.Name(n => n.GeoLocation))
                                    .Keyword(p => p.Name(n => n.UserGroupId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoContinentName).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Keyword(p => p.Name(n => n.UserGroupName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCountryName).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.UserFullName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserEmail).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCityName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserHash).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.GeoCountryIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionIsoCode).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.GeoName).IgnoreAbove(1024))
                            ))
                            .Object<Ecs>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                            ))
                            .Object<Error>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Text(p => p.Name(n => n.Message))
                                    .Keyword(p => p.Name(n => n.Code).IgnoreAbove(1024))
                            ))
                            .Object<Event>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Kind).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Category).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Action).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Outcome).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Module).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Dataset).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Severity).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024).Index(false).DocValues(false))
                                    .Keyword(p => p.Name(n => n.Hash).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Duration).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Timezone).IgnoreAbove(1024))
                                    .Date(p => p.Name(n => n.Created))
                                    .Date(p => p.Name(n => n.Start))
                                    .Date(p => p.Name(n => n.End))
                                    .Number(p => p.Name(n => n.RiskScore).Type(NumberType.Float))
                                    .Number(p => p.Name(n => n.RiskScoreNorm).Type(NumberType.Float))
                            ))
                            .Object<File>(o =>
                                o.Properties(a => a
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
                            ))
                            .Object<Host>(o =>
                                o.Properties(a => a
                                    .GeoPoint(p => p.Name(n => n.GeoLocation))
                                    .Keyword(p => p.Name(n => n.Hostname).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsPlatform).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserGroupId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoContinentName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserGroupName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCountryName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsFull).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserFullName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionName).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Keyword(p => p.Name(n => n.OsFamily).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserEmail).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCityName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsVersion).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserHash).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCountryIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsKernel).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Architecture).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoName).IgnoreAbove(1024))
                            ))
                            .Object<Http>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.RequestMethod).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.RequestBodyContent).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.RequestReferrer).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.ResponseStatusCode).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.ResponseBodyContent).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.RequestBytes).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.RequestBodyBytes).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.ResponseBytes).Type(NumberType.Long))
                                    .Number(p => p.Name(n => n.ResponseBodyBytes).Type(NumberType.Long))
                            ))
                            .Object<Log>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Level).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024).Index(false).DocValues(false))
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
                                    .GeoPoint(p => p.Name(n => n.GeoLocation))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsPlatform).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoContinentName).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Keyword(p => p.Name(n => n.OsName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCountryName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Hostname).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsFull).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsFamily).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Vendor).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCityName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsVersion).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCountryIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsKernel).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.SerialNumber).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Type).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoName).IgnoreAbove(1024))
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
                            .Object<Process>(o =>
                                o.Properties(a => a
                                    .Number(p => p.Name(n => n.Pid).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Ppid).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Args).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Executable).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Title).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.ThreadId).Type(NumberType.Long))
                                    .Date(p => p.Name(n => n.Start))
                                    .Keyword(p => p.Name(n => n.WorkingDirectory).IgnoreAbove(1024))
                            ))
                            .Object<Related>(o =>
                                o.Properties(a => a
                                    .Ip(p => p.Name(n => n.Ip))
                            ))
                            .Object<Server>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Address).IgnoreAbove(1024))
                                    .GeoPoint(p => p.Name(n => n.GeoLocation))
                                    .Keyword(p => p.Name(n => n.UserGroupId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoContinentName).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Keyword(p => p.Name(n => n.UserGroupName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCountryName).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.UserFullName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserEmail).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCityName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserHash).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.GeoCountryIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionIsoCode).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.GeoName).IgnoreAbove(1024))
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
                                    .GeoPoint(p => p.Name(n => n.GeoLocation))
                                    .Keyword(p => p.Name(n => n.UserGroupId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoContinentName).IgnoreAbove(1024))
                                    .Ip(p => p.Name(n => n.Ip))
                                    .Keyword(p => p.Name(n => n.UserGroupName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCountryName).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.UserFullName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Mac).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserEmail).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoCityName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.UserHash).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Bytes).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.GeoCountryIsoCode).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GeoRegionIsoCode).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Packets).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.GeoName).IgnoreAbove(1024))
                            ))
                            .Object<Url>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Full).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Scheme).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Domain).IgnoreAbove(1024))
                                    .Number(p => p.Name(n => n.Port).Type(NumberType.Long))
                                    .Keyword(p => p.Name(n => n.Path).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Query).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Fragment).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Username).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Password).IgnoreAbove(1024))
                            ))
                            .Object<User>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.GroupId).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Id).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.GroupName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.FullName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Email).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Hash).IgnoreAbove(1024))
                            ))
                            .Object<UserAgent>(o =>
                                o.Properties(a => a
                                    .Keyword(p => p.Name(n => n.Original).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsPlatform).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Name).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsFull).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.Version).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.DeviceName).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsFamily).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsVersion).IgnoreAbove(1024))
                                    .Keyword(p => p.Name(n => n.OsKernel).IgnoreAbove(1024))
                            ))
                        );
        }
    }
}