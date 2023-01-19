// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Elastic.Transport;

namespace Elastic.Ingest.Elasticsearch
{
	internal class ElasticsearchRequestParameters : RequestParameters { }
	internal static class ElasticsearchChannelStatics
	{
		public static readonly byte[] LineFeed = { (byte)'\n' };

		public static readonly byte[] DocUpdateHeaderStart = Encoding.UTF8.GetBytes("{\"doc\": ");
		public static readonly byte[] DocUpdateHeaderEnd = Encoding.UTF8.GetBytes(" }");

		public static readonly ElasticsearchRequestParameters RequestParams =
			new() { QueryString = { { "filter_path", "error, items.*.status,items.*.error" } } };

		public static readonly HashSet<int> RetryStatusCodes = new(new[] { 502, 503, 504, 429 });

		public static readonly JsonSerializerOptions SerializerOptions = new ()
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
		};
	}
}
