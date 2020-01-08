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
