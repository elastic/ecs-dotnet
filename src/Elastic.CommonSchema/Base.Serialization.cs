// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.CommonSchema.Serialization;
using Utf8Json;
using Utf8Json.Resolvers;

namespace Elastic.CommonSchema
{
	[JsonFormatter(typeof(BaseJsonFormatter))]
	public partial class Base
	{
		public byte[] Serialize() => JsonSerializer.Serialize(this, StandardResolver.ExcludeNull);

		public static Base Deserialize(string s) =>
			JsonSerializer.Deserialize<Base>(s, StandardResolver.ExcludeNull);
	}
}
