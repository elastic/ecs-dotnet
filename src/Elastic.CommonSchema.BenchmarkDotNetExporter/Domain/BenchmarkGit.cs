// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkGit
	{
		[DataMember(Name = "branch")]
		public string BranchName { get; set; }

		[DataMember(Name = "sha")]
		public string Sha { get; set; }

		[DataMember(Name = "commit_message")]
		public string CommitMessage { get; set; }

		[DataMember(Name = "repository")]
		public string Repository { get; set; }
	}
}
