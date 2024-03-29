using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests.Repro
{
	public class GithubIssue31 : LogTestsBase
	{
		public GithubIssue31(ITestOutputHelper output) : base(output) { }

		[Fact]
		public void Reproduce() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Язык {@Data}", new { Значение = "Русский" });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Язык { Значение: \"Русский\" }");

			var infoString = info.Serialize();
			infoString.Should().Contain("Язык");
			infoString.Should().Contain("Значение");
			infoString.Should().Contain("Русский");

			var stream = new MemoryStream();
			info.Serialize(stream);

			var streamString = Encoding.UTF8.GetString(stream.GetBuffer());
			streamString.Should().Contain("Язык");
			streamString.Should().Contain("Значение");
			streamString.Should().Contain("Русский");
		});
	}
}
