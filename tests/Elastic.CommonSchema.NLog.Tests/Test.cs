using NLog;
using NLog.LayoutRenderers;
using NLog.Layouts;
using Xunit;
using Xunit.Abstractions;
using Xunit.NLog.Targets;

namespace Elastic.CommonSchema.Tests
{
	public class Test
	{
		private readonly ILogger _logger;

		public Test(ITestOutputHelper outputHelper)
		{
			LayoutRenderer.Register<EcsLayoutRenderer>("ecs");
			var config = new NLog.Config.LoggingConfiguration();
			var testOutputTarget = new TestOutputTarget { Layout = Layout.FromString("${ecs}") };
			config.AddRule(LogLevel.Debug, LogLevel.Fatal, testOutputTarget);
			LogManager.Configuration = config;

			_logger = outputHelper.GetNLogLogger();
		}

		public void Dispose() => _logger.RemoveTestOutputHelper();

		[Fact]
		public void TestMethod()
		{
			_logger.Debug("Hello {Name}", "Earth");
			_logger.Info("Hello {Name}", "Earth");
		}
	}
}
