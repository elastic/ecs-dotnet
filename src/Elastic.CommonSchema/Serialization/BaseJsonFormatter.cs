using System;
using System.Collections.Generic;
using Utf8Json;

namespace Elastic.CommonSchema.Serialization
{
    internal class BaseJsonFormatter : IJsonFormatter<Base>
    {
        private static readonly AutoAutomataDictionary AutomataDictionary = new AutoAutomataDictionary
        {
            { "@timestamp"},
            { "log.level"},
            { "message" },
            
            {"_metadata"},
            {"agent"},
            {"client"},
            {"cloud"},
            {"container"},
            {"destination"},
            {"dns"},
            {"ecs"},
            {"error"},
            {"event"},
            {"file"},
            {"geo"},
            {"group"},
            {"hash"},
            {"host"},
            {"http"},
            {"log"},
            {"network"},
            {"observer"},
            {"organization"},
            {"os"},
            {"package"},
            {"process"},
            {"related"},
            {"server"},
            {"service"},
            {"source"},
            {"threat"},
            {"tracing"},
            {"url"},
            {"user"},
            {"user_agent"},
            {"tags"},
            {"labels"},
        };

        public Base Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
        {
            var count = 0;
            var ecsEvent = new Base();
            string logLevel = null;
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
                        0 => ReadRef<DateTimeOffset?>(ref reader, ref timestamp),
                        1 => ReadString(ref reader, ref logLevel),
                        2 => ReadString(ref reader, ref message),
                        4 => Read<IDictionary<string, object>>(ref reader, ecsEvent, (b, v) => b.Metadata = v),
                        5 => Read<Agent>(ref reader, ecsEvent, (b, v) => b.Agent = v),
                        6 => Read<As>(ref reader, ecsEvent, (b, v) => b.As = v),
                        7 => Read<Client>(ref reader, ecsEvent, (b, v) => b.Client = v),
                        8 => Read<Cloud>(ref reader, ecsEvent, (b, v) => b.Cloud = v),
                        9 => Read<Container>(ref reader, ecsEvent, (b, v) => b.Container = v),
                        10 => Read<Destination>(ref reader, ecsEvent, (b, v) => b.Destination = v),
                        11 => Read<Dns>(ref reader, ecsEvent, (b, v) => b.Dns = v),
                        12 => Read<Ecs>(ref reader, ecsEvent, (b, v) => b.Ecs = v),
                        13 => Read<Error>(ref reader, ecsEvent, (b, v) => b.Error = v),
                        14 => Read<Event>(ref reader, ecsEvent, (b, v) => b.Event = v),
                        15 => Read<File>(ref reader, ecsEvent, (b, v) => b.File = v),
                        16 => Read<Geo>(ref reader, ecsEvent, (b, v) => b.Geo = v),
                        17 => Read<Group>(ref reader, ecsEvent, (b, v) => b.Group = v),
                        18 => Read<Hash>(ref reader, ecsEvent, (b, v) => b.Hash = v),
                        19 => Read<Host>(ref reader, ecsEvent, (b, v) => b.Host = v),
                        20 => Read<Http>(ref reader, ecsEvent, (b, v) => b.Http = v),
                        21 => Read<Log>(ref reader, ecsEvent, (b, v) => b.Log = v),
                        22 => Read<Network>(ref reader, ecsEvent, (b, v) => b.Network = v),
                        23 => Read<Observer>(ref reader, ecsEvent, (b, v) => b.Observer = v),
                        24 => Read<Organization>(ref reader, ecsEvent, (b, v) => b.Organization = v),
                        25 => Read<Os>(ref reader, ecsEvent, (b, v) => b.Os = v),
                        26 => Read<Package>(ref reader, ecsEvent, (b, v) => b.Package = v),
                        27 => Read<Process>(ref reader, ecsEvent, (b, v) => b.Process = v),
                        28 => Read<Related>(ref reader, ecsEvent, (b, v) => b.Related = v),
                        29 => Read<Server>(ref reader, ecsEvent, (b, v) => b.Server = v),
                        30 => Read<Service>(ref reader, ecsEvent, (b, v) => b.Service = v),
                        31 => Read<Source>(ref reader, ecsEvent, (b, v) => b.Source = v),
                        32 => Read<Threat>(ref reader, ecsEvent, (b, v) => b.Threat = v),
                        33 => Read<Tracing>(ref reader, ecsEvent, (b, v) => b.Tracing = v),
                        34 => Read<Url>(ref reader, ecsEvent, (b, v) => b.Url = v),
                        35 => Read<User>(ref reader, ecsEvent, (b, v) => b.User = v),
                        36 => Read<UserAgent>(ref reader, ecsEvent, (b, v) => b.UserAgent = v),
                        37 => Read<string[]>(ref reader, ecsEvent, (b, v) => b.Tags = v),
                        38 => Read<IDictionary<string, object>>(ref reader, ecsEvent, (b, v) => b.Labels = v),
                        _ => false
                    };
                }
            }
            ecsEvent.Log ??= new Log();
            ecsEvent.Log.Level = logLevel;
            ecsEvent.Message = message;
            ecsEvent.Timestamp = timestamp;
            return ecsEvent;
        }

        public void Serialize(ref JsonWriter writer, Base value, IJsonFormatterResolver formatterResolver)
        {
            if (value == null) return;

            writer.WriteBeginObject();
            WriteTimestamp(ref writer, value, formatterResolver);
            WriteLogLevel(ref writer, value);
            WriteMessage(ref writer, value);

            WriteProp(ref writer, "_metadata",value.Metadata, formatterResolver);
            WriteProp(ref writer, "agent", value.Agent, formatterResolver);
            WriteProp(ref writer, "as", value.As, formatterResolver);
            WriteProp(ref writer, "client", value.Client, formatterResolver);
            WriteProp(ref writer, "cloud", value.Cloud, formatterResolver);
            WriteProp(ref writer, "container", value.Container, formatterResolver);
            WriteProp(ref writer, "destination", value.Destination, formatterResolver);
            WriteProp(ref writer, "dns", value.Dns, formatterResolver);
            WriteProp(ref writer, "ecs", value.Ecs, formatterResolver);
            WriteProp(ref writer, "error", value.Error, formatterResolver);
            WriteProp(ref writer, "event", value.Event, formatterResolver);
            WriteProp(ref writer, "file", value.File, formatterResolver);
            WriteProp(ref writer, "geo", value.Geo, formatterResolver);
            WriteProp(ref writer, "group", value.Group, formatterResolver);
            WriteProp(ref writer, "hash", value.Hash, formatterResolver);
            WriteProp(ref writer, "host", value.Host, formatterResolver);
            WriteProp(ref writer, "http", value.Http, formatterResolver);
            WriteProp(ref writer, "log", value.Log, formatterResolver);
            WriteProp(ref writer, "network", value.Network, formatterResolver);
            WriteProp(ref writer, "observer", value.Observer, formatterResolver);
            WriteProp(ref writer, "organization", value.Organization, formatterResolver);
            WriteProp(ref writer, "os", value.Os, formatterResolver);
            WriteProp(ref writer, "package", value.Package, formatterResolver);
            WriteProp(ref writer, "process", value.Process, formatterResolver);
            WriteProp(ref writer, "related", value.Related, formatterResolver);
            WriteProp(ref writer, "server", value.Server, formatterResolver);
            WriteProp(ref writer, "service", value.Service, formatterResolver);
            WriteProp(ref writer, "source", value.Source, formatterResolver);
            WriteProp(ref writer, "threat", value.Threat, formatterResolver);
            WriteProp(ref writer, "tracing", value.Tracing, formatterResolver);
            WriteProp(ref writer, "url", value.Url, formatterResolver);
            WriteProp(ref writer, "user", value.User, formatterResolver);
            WriteProp(ref writer, "user_agent", value.UserAgent, formatterResolver);
            WriteProp(ref writer, "tags", value.Tags, formatterResolver);
            WriteProp(ref writer, "labels", value.Labels, formatterResolver);
            writer.WriteEndObject();
        }

        private static void WriteMessage(ref JsonWriter writer, Base value)
        {
            writer.WritePropertyName("message");
            if (value.Message != null)
                writer.WriteString(value.Message);
            else writer.WriteNull();
            writer.WriteValueSeparator();
        }

        private static void WriteLogLevel(ref JsonWriter writer, Base value)
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