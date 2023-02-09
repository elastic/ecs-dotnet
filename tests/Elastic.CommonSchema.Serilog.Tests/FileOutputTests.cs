// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.IO;
using FluentAssertions;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests
{
	public class FileOutputTests : LogTestsBase
	{
		private readonly string _path = Path.GetTempFileName();
		public FileOutputTests(ITestOutputHelper output) : base(output) =>
			LoggerConfiguration = LoggerConfiguration
				.WriteTo.File(path: _path, formatter: Formatter)
				.Enrich.WithThreadId()
				.Enrich.WithThreadName()
				.Enrich.WithMachineName()
				.Enrich.WithProcessId()
				.Enrich.WithProcessName()
				.Enrich.WithEnvironmentUserName();

		//TODO not a unit test does IO
		//Run only on CI with a skip attribute
		[Fact(Skip = "This does actual IO and will fail on CI")]
		public void WritesToFileUsingStream() => TestLogger((logger, _) =>
		{
			try
			{
				logger.Information("My log message!");


				var jsonLines = System.IO.File.ReadAllLines(_path);
				jsonLines.Should().NotBeEmpty();

				using var fsSource = new FileStream(_path, FileMode.Open, FileAccess.Read);
				//this only works because the filestream contains one event
				var b = EcsDocument.Deserialize(fsSource);
				b.Should().NotBeNull();
				b.Log.Level.Should().Be("Information");
			}
			finally
			{
				System.IO.File.Delete(_path);
			}
		});
	}
}
