// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using Elastic.CommonSchema;

namespace Elasticsearch.Extensions.Logging
{
	public class LogEvent : Base
	{
		// Custom field; use capitalisation as per ECS
		public string? MessageTemplate { get; set; }

		// Custom field; use capitalisation as per ECS
		public IList<string>? Scopes { get; set; }
	}
}
