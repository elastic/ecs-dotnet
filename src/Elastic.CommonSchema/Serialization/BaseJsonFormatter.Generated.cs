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

/*
IMPORTANT NOTE
==============
This file has been generated. 
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

using System;
using System.Collections.Generic;
using Utf8Json;
namespace Elastic.CommonSchema.Serialization
{
    internal class BaseJsonFormatter : IJsonFormatter<Base>
    {
        private static readonly IncrementingAutomataDictionary AutomataDictionary = new IncrementingAutomataDictionary
        {
            // Base fields
            { "@timestamp" }, // 0
            { "log.level" }, // 1
            { "message" }, // 2
            { "_metadata" }, // 3
            { "labels" }, // 4
            { "tags" }, // 5
            // Complex types
            { "agent" }, // 6
            { "as" }, // 7
            { "client" }, // 8
            { "cloud" }, // 9
            { "container" }, // 10
            { "destination" }, // 11
            { "dns" }, // 12
            { "ecs" }, // 13
            { "error" }, // 14
            { "event" }, // 15
            { "file" }, // 16
            { "geo" }, // 17
            { "group" }, // 18
            { "hash" }, // 19
            { "host" }, // 20
            { "http" }, // 21
            { "log" }, // 22
            { "network" }, // 23
            { "observer" }, // 24
            { "organization" }, // 25
            { "os" }, // 26
            { "package" }, // 27
            { "process" }, // 28
            { "related" }, // 29
            { "server" }, // 30
            { "service" }, // 31
            { "source" }, // 32
            { "threat" }, // 33
            { "tracing" }, // 34
            { "url" }, // 35
            { "user" }, // 36
            { "user_agent" }, // 37
        };

        public Base Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
        {
            var count = 0;
            var ecsEvent = new Base();
            string loglevel = null;
            string message = null;
            DateTimeOffset? timestamp = null;
            bool ReadRef<T> (ref JsonReader reader, ref T set)
            {
                var formatter = formatterResolver.GetFormatter<T>();
                set = formatter.Deserialize(ref reader, formatterResolver);
                return true;
            }
            bool Read<T> (ref JsonReader reader, Base b, Action<Base, T> set)
            {
                var formatter = formatterResolver.GetFormatter<T>();
                set(b, formatter.Deserialize(ref reader, formatterResolver));
                return true;
            }
            static bool ReadString(ref JsonReader reader, ref string stringProp)
            {
                stringProp = reader.ReadString();
                return true;
            }
            
            while (reader.ReadIsInObject(ref count))
            {
                var propertyName = reader.ReadPropertyNameSegmentRaw();
                if (AutomataDictionary.TryGetValue(propertyName, out var value))
                {
                    _ = value switch
                    {
                        0 => ReadRef<DateTimeOffset?>(ref reader, ref @timestamp),
                        1 => ReadString(ref reader, ref loglevel),
                        2 => ReadString(ref reader, ref message),
                        3 => Read<IDictionary<string, object>>(ref reader, ecsEvent, (b, v) => b.Metadata = v),
                        4 => Read<IDictionary<string, object>>(ref reader, ecsEvent, (b, v) => b.Labels = v),
                        5 => Read<string[]>(ref reader, ecsEvent, (b, v) => b.Tags = v),
                        6 => Read<Agent>(ref reader, ecsEvent, (b, v) => b.Agent = v),
                        7 => Read<As>(ref reader, ecsEvent, (b, v) => b.As = v),
                        8 => Read<Client>(ref reader, ecsEvent, (b, v) => b.Client = v),
                        9 => Read<Cloud>(ref reader, ecsEvent, (b, v) => b.Cloud = v),
                        10 => Read<Container>(ref reader, ecsEvent, (b, v) => b.Container = v),
                        11 => Read<Destination>(ref reader, ecsEvent, (b, v) => b.Destination = v),
                        12 => Read<Dns>(ref reader, ecsEvent, (b, v) => b.Dns = v),
                        13 => Read<Ecs>(ref reader, ecsEvent, (b, v) => b.Ecs = v),
                        14 => Read<Error>(ref reader, ecsEvent, (b, v) => b.Error = v),
                        15 => Read<Event>(ref reader, ecsEvent, (b, v) => b.Event = v),
                        16 => Read<File>(ref reader, ecsEvent, (b, v) => b.File = v),
                        17 => Read<Geo>(ref reader, ecsEvent, (b, v) => b.Geo = v),
                        18 => Read<Group>(ref reader, ecsEvent, (b, v) => b.Group = v),
                        19 => Read<Hash>(ref reader, ecsEvent, (b, v) => b.Hash = v),
                        20 => Read<Host>(ref reader, ecsEvent, (b, v) => b.Host = v),
                        21 => Read<Http>(ref reader, ecsEvent, (b, v) => b.Http = v),
                        22 => Read<Log>(ref reader, ecsEvent, (b, v) => b.Log = v),
                        23 => Read<Network>(ref reader, ecsEvent, (b, v) => b.Network = v),
                        24 => Read<Observer>(ref reader, ecsEvent, (b, v) => b.Observer = v),
                        25 => Read<Organization>(ref reader, ecsEvent, (b, v) => b.Organization = v),
                        26 => Read<Os>(ref reader, ecsEvent, (b, v) => b.Os = v),
                        27 => Read<Package>(ref reader, ecsEvent, (b, v) => b.Package = v),
                        28 => Read<Process>(ref reader, ecsEvent, (b, v) => b.Process = v),
                        29 => Read<Related>(ref reader, ecsEvent, (b, v) => b.Related = v),
                        30 => Read<Server>(ref reader, ecsEvent, (b, v) => b.Server = v),
                        31 => Read<Service>(ref reader, ecsEvent, (b, v) => b.Service = v),
                        32 => Read<Source>(ref reader, ecsEvent, (b, v) => b.Source = v),
                        33 => Read<Threat>(ref reader, ecsEvent, (b, v) => b.Threat = v),
                        34 => Read<Tracing>(ref reader, ecsEvent, (b, v) => b.Tracing = v),
                        35 => Read<Url>(ref reader, ecsEvent, (b, v) => b.Url = v),
                        36 => Read<User>(ref reader, ecsEvent, (b, v) => b.User = v),
                        37 => Read<UserAgent>(ref reader, ecsEvent, (b, v) => b.UserAgent = v),
                        _ => false
                    };
                }
            }
            ecsEvent.Log ??= new Log();
            ecsEvent.Log.Level = loglevel;
            ecsEvent.Message = message;
            ecsEvent.Timestamp = timestamp;
            return ecsEvent;
        }

        public void Serialize(ref JsonWriter writer, Base value, IJsonFormatterResolver formatterResolver)
        {
            if (value == null) return;
            writer.WriteBeginObject();
            // Base fields
            WriteTimestamp(ref writer, value, formatterResolver); // 0
            WriteLogLevel(ref writer, value, formatterResolver); // 1
            WriteMessage(ref writer, value, formatterResolver); // 2
            WriteProp(ref writer, "_metadata", value.Metadata, formatterResolver); // 3
            WriteProp(ref writer, "labels", value.Labels, formatterResolver); // 4
            WriteProp(ref writer, "tags", value.Tags, formatterResolver); // 5
            // Complex types
            WriteProp(ref writer, "agent", value.Agent, formatterResolver); // 6
            WriteProp(ref writer, "as", value.As, formatterResolver); // 7
            WriteProp(ref writer, "client", value.Client, formatterResolver); // 8
            WriteProp(ref writer, "cloud", value.Cloud, formatterResolver); // 9
            WriteProp(ref writer, "container", value.Container, formatterResolver); // 10
            WriteProp(ref writer, "destination", value.Destination, formatterResolver); // 11
            WriteProp(ref writer, "dns", value.Dns, formatterResolver); // 12
            WriteProp(ref writer, "ecs", value.Ecs, formatterResolver); // 13
            WriteProp(ref writer, "error", value.Error, formatterResolver); // 14
            WriteProp(ref writer, "event", value.Event, formatterResolver); // 15
            WriteProp(ref writer, "file", value.File, formatterResolver); // 16
            WriteProp(ref writer, "geo", value.Geo, formatterResolver); // 17
            WriteProp(ref writer, "group", value.Group, formatterResolver); // 18
            WriteProp(ref writer, "hash", value.Hash, formatterResolver); // 19
            WriteProp(ref writer, "host", value.Host, formatterResolver); // 20
            WriteProp(ref writer, "http", value.Http, formatterResolver); // 21
            WriteProp(ref writer, "log", value.Log, formatterResolver); // 22
            WriteProp(ref writer, "network", value.Network, formatterResolver); // 23
            WriteProp(ref writer, "observer", value.Observer, formatterResolver); // 24
            WriteProp(ref writer, "organization", value.Organization, formatterResolver); // 25
            WriteProp(ref writer, "os", value.Os, formatterResolver); // 26
            WriteProp(ref writer, "package", value.Package, formatterResolver); // 27
            WriteProp(ref writer, "process", value.Process, formatterResolver); // 28
            WriteProp(ref writer, "related", value.Related, formatterResolver); // 29
            WriteProp(ref writer, "server", value.Server, formatterResolver); // 30
            WriteProp(ref writer, "service", value.Service, formatterResolver); // 31
            WriteProp(ref writer, "source", value.Source, formatterResolver); // 32
            WriteProp(ref writer, "threat", value.Threat, formatterResolver); // 33
            WriteProp(ref writer, "tracing", value.Tracing, formatterResolver); // 34
            WriteProp(ref writer, "url", value.Url, formatterResolver); // 35
            WriteProp(ref writer, "user", value.User, formatterResolver); // 36
            WriteProp(ref writer, "user_agent", value.UserAgent, formatterResolver); // 37
            writer.WriteEndObject();
        }

        private static void WriteMessage(ref JsonWriter writer, Base value, IJsonFormatterResolver formatterResolver)
        {
            writer.WritePropertyName("message");
            if (value.Message != null)
                writer.WriteString(value.Message);
            else writer.WriteNull();
            writer.WriteValueSeparator();
        }

        private static void WriteLogLevel(ref JsonWriter writer, Base value, IJsonFormatterResolver formatterResolver)
        {
            writer.WritePropertyName("log.level");
            if (value.Log?.Level != null)
                writer.WriteString(value.Log.Level);
            else writer.WriteNull();
            writer.WriteValueSeparator();
        }
        
        private static void WriteTimestamp(ref JsonWriter writer, Base value, IJsonFormatterResolver formatterResolver)
        {
            writer.WritePropertyName("timestamp");
            var formatter = formatterResolver.GetFormatter<DateTimeOffset?>();
            formatter.Serialize(ref writer, value.Timestamp, formatterResolver);
            writer.WriteValueSeparator();
        }
        
        private static void WriteProp<T>(ref JsonWriter writer, string key, T value, IJsonFormatterResolver formatterResolver)
        {
            if (value == null) return;
            writer.WriteNameSeparator();
            writer.WritePropertyName(key);
            var formatter = formatterResolver.GetFormatter<T>();
            formatter.Serialize(ref writer, value, formatterResolver);
        }
    }
}