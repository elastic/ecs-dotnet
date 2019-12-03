using System;
using System.IO;
using System.Linq;
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
		[Fact]
		public void WritesToFileUsingStream() => TestLogger((logger, getLogEvents) =>
		{
			try
			{
				logger.Information("My log message!");
				var jsonLines = System.IO.File.ReadAllLines(_path);
				jsonLines.Should().NotBeEmpty();
			}
			finally
			{
				System.IO.File.Delete(_path);
			}
		});
	}
}
