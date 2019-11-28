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

using System;
using Utf8Json;

namespace Elastic.CommonSchema.Serialization
{
    internal class LogJsonFormatter : IJsonFormatter<Log>
    {
        public Log Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver) => throw new NotImplementedException();

        public void Serialize(ref JsonWriter writer, Log value, IJsonFormatterResolver formatterResolver)
        {
            if (value == null) return;

            writer.WriteBeginObject();
            var written = false;
            WriteProp(ref writer, "original",value.Original, formatterResolver, ref written);
            WriteProp(ref writer, "origin", value.Origin, formatterResolver, ref written);
            WriteProp(ref writer, "syslog", value.Syslog, formatterResolver, ref written);
            WriteProp(ref writer, "logger", value.Logger, formatterResolver, ref written);
            writer.WriteEndObject();
        }

        private static void WriteProp<T>(ref JsonWriter writer, string key, T value, IJsonFormatterResolver formatterResolver, ref bool written)
        {
            if (value == null) return;
            if (written)
                writer.WriteNameSeparator();
            writer.WritePropertyName(key);
            var formatter = formatterResolver.GetFormatter<T>();
            formatter.Serialize(ref writer, value, formatterResolver);
            written = true;
        }
    }
}
