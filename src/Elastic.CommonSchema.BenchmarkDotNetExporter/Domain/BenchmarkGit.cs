// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary></summary>
	public class BenchmarkGit
	{
		/// <summary></summary>
		[JsonPropertyName("branch"), DataMember(Name = "branch")]
		public string BranchName { get; set; }

		/// <summary></summary>
		[JsonPropertyName("sha"), DataMember(Name = "sha")]
		public string Sha { get; set; }

		/// <summary></summary>
		[JsonPropertyName("commit_message"), DataMember(Name = "commit_message")]
		public string CommitMessage { get; set; }

		/// <summary></summary>
		[JsonPropertyName("repository"), DataMember(Name = "repository")]
		public string Repository { get; set; }
	}
}
