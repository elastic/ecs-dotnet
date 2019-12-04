// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

/*
IMPORTANT NOTE
==============
This file has been generated. 
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Elastic.CommonSchema.Serialization
{
	internal partial class BaseJsonConverter : EcsJsonConverterBase<Base>
	{
		private static bool ReadProperties(
			ref Utf8JsonReader reader, 
			Base ecsEvent, 
			ref DateTimeOffset? timestamp, 
			ref string loglevel
		)
		{
			var propertyName = reader.GetString();
			reader.Read();
			return propertyName switch
			{
				"@timestamp" => ReadDateTime(ref reader, ref @timestamp),
				"log.level" => ReadString(ref reader, ref loglevel),
				"message" => ReadProp<string>(ref reader, "message", ecsEvent, (b, v) => b.Message = v),
				"_metadata" => ReadProp<IDictionary<string, object>>(ref reader, "_metadata", ecsEvent, (b, v) => b.Metadata = v),
				"labels" => ReadProp<IDictionary<string, object>>(ref reader, "labels", ecsEvent, (b, v) => b.Labels = v),
				"tags" => ReadProp<string[]>(ref reader, "tags", ecsEvent, (b, v) => b.Tags = v),
				"agent" => ReadProp<Agent>(ref reader, "agent", ecsEvent, (b, v) => b.Agent = v),
				"as" => ReadProp<As>(ref reader, "as", ecsEvent, (b, v) => b.As = v),
				"client" => ReadProp<Client>(ref reader, "client", ecsEvent, (b, v) => b.Client = v),
				"cloud" => ReadProp<Cloud>(ref reader, "cloud", ecsEvent, (b, v) => b.Cloud = v),
				"container" => ReadProp<Container>(ref reader, "container", ecsEvent, (b, v) => b.Container = v),
				"destination" => ReadProp<Destination>(ref reader, "destination", ecsEvent, (b, v) => b.Destination = v),
				"dns" => ReadProp<Dns>(ref reader, "dns", ecsEvent, (b, v) => b.Dns = v),
				"ecs" => ReadProp<Ecs>(ref reader, "ecs", ecsEvent, (b, v) => b.Ecs = v),
				"error" => ReadProp<Error>(ref reader, "error", ecsEvent, (b, v) => b.Error = v),
				"event" => ReadProp<Event>(ref reader, "event", ecsEvent, (b, v) => b.Event = v),
				"file" => ReadProp<File>(ref reader, "file", ecsEvent, (b, v) => b.File = v),
				"geo" => ReadProp<Geo>(ref reader, "geo", ecsEvent, (b, v) => b.Geo = v),
				"group" => ReadProp<Group>(ref reader, "group", ecsEvent, (b, v) => b.Group = v),
				"hash" => ReadProp<Hash>(ref reader, "hash", ecsEvent, (b, v) => b.Hash = v),
				"host" => ReadProp<Host>(ref reader, "host", ecsEvent, (b, v) => b.Host = v),
				"http" => ReadProp<Http>(ref reader, "http", ecsEvent, (b, v) => b.Http = v),
				"log" => ReadProp<Log>(ref reader, "log", ecsEvent, (b, v) => b.Log = v),
				"network" => ReadProp<Network>(ref reader, "network", ecsEvent, (b, v) => b.Network = v),
				"observer" => ReadProp<Observer>(ref reader, "observer", ecsEvent, (b, v) => b.Observer = v),
				"organization" => ReadProp<Organization>(ref reader, "organization", ecsEvent, (b, v) => b.Organization = v),
				"os" => ReadProp<Os>(ref reader, "os", ecsEvent, (b, v) => b.Os = v),
				"package" => ReadProp<Package>(ref reader, "package", ecsEvent, (b, v) => b.Package = v),
				"process" => ReadProp<Process>(ref reader, "process", ecsEvent, (b, v) => b.Process = v),
				"related" => ReadProp<Related>(ref reader, "related", ecsEvent, (b, v) => b.Related = v),
				"server" => ReadProp<Server>(ref reader, "server", ecsEvent, (b, v) => b.Server = v),
				"service" => ReadProp<Service>(ref reader, "service", ecsEvent, (b, v) => b.Service = v),
				"source" => ReadProp<Source>(ref reader, "source", ecsEvent, (b, v) => b.Source = v),
				"threat" => ReadProp<Threat>(ref reader, "threat", ecsEvent, (b, v) => b.Threat = v),
				"tls" => ReadProp<Tls>(ref reader, "tls", ecsEvent, (b, v) => b.Tls = v),
				"tracing" => ReadProp<Tracing>(ref reader, "tracing", ecsEvent, (b, v) => b.Tracing = v),
				"url" => ReadProp<Url>(ref reader, "url", ecsEvent, (b, v) => b.Url = v),
				"user" => ReadProp<User>(ref reader, "user", ecsEvent, (b, v) => b.User = v),
				"user_agent" => ReadProp<UserAgent>(ref reader, "user_agent", ecsEvent, (b, v) => b.UserAgent = v),
				"vulnerability" => ReadProp<Vulnerability>(ref reader, "vulnerability", ecsEvent, (b, v) => b.Vulnerability = v),
				_ => false
			};
		}

		public override void Write(Utf8JsonWriter writer, Base value, JsonSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			// Base fields
			WriteTimestamp(writer, value);
			WriteLogLevel(writer, value);
			WriteMessage(writer, value);
			WriteProp(writer, "_metadata", value.Metadata);
			WriteProp(writer, "labels", value.Labels);
			WriteProp(writer, "tags", value.Tags);
			// Complex types
			WriteProp(writer, "agent", value.Agent);
			WriteProp(writer, "as", value.As);
			WriteProp(writer, "client", value.Client);
			WriteProp(writer, "cloud", value.Cloud);
			WriteProp(writer, "container", value.Container);
			WriteProp(writer, "destination", value.Destination);
			WriteProp(writer, "dns", value.Dns);
			WriteProp(writer, "ecs", value.Ecs);
			WriteProp(writer, "error", value.Error);
			WriteProp(writer, "event", value.Event);
			WriteProp(writer, "file", value.File);
			WriteProp(writer, "geo", value.Geo);
			WriteProp(writer, "group", value.Group);
			WriteProp(writer, "hash", value.Hash);
			WriteProp(writer, "host", value.Host);
			WriteProp(writer, "http", value.Http);
			WriteProp(writer, "log", value.Log);
			WriteProp(writer, "network", value.Network);
			WriteProp(writer, "observer", value.Observer);
			WriteProp(writer, "organization", value.Organization);
			WriteProp(writer, "os", value.Os);
			WriteProp(writer, "package", value.Package);
			WriteProp(writer, "process", value.Process);
			WriteProp(writer, "related", value.Related);
			WriteProp(writer, "server", value.Server);
			WriteProp(writer, "service", value.Service);
			WriteProp(writer, "source", value.Source);
			WriteProp(writer, "threat", value.Threat);
			WriteProp(writer, "tls", value.Tls);
			WriteProp(writer, "tracing", value.Tracing);
			WriteProp(writer, "url", value.Url);
			WriteProp(writer, "user", value.User);
			WriteProp(writer, "user_agent", value.UserAgent);
			WriteProp(writer, "vulnerability", value.Vulnerability);
			writer.WriteEndObject();
		}
	}
}