using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Elastic.CommonSchema.Serialization;
using FluentAssertions;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests.Repro
{
	public class GithubIssue167
	{
		public class ContosoDocument : EcsDocument
		{
			[JsonPropertyName("contoso"), DataMember(Name = "contoso")]
			public Contoso Contoso { get; set; }

			protected override bool TryRead(string propertyName, out Type type)
			{
				type = propertyName switch
				{
					"contoso" => typeof(Contoso),
					_ => null
				};
				return type != null;
			}

			protected override bool ReceiveProperty(string propertyName, object value) =>
				propertyName switch
				{
					"contoso" => null != (Contoso = value as Contoso),
					_ => false
				};

			protected override void WriteAdditionalProperties(Action<string, object> write) => write("contoso", Contoso);
		}

		public class Contoso
		{
			[JsonPropertyName("company_name"), DataMember(Name = "company_name")]
			public string CompanyName { get; set; }
		}

		public class ContosoEcsTextFormatter : EcsTextFormatter<ContosoDocument>
		{
			public override void Format(LogEvent logEvent, TextWriter output)
			{
				var ecsEvent = LogEventConverter.ConvertToEcs(logEvent, Configuration);
				ecsEvent.Contoso = new Contoso { CompanyName = "Elastic", };
				output.WriteLine(ecsEvent.Serialize());
			}
		}

		private LoggerConfiguration LoggerConfiguration { get; }
		private ContosoEcsTextFormatter Formatter { get; }

		public GithubIssue167(ITestOutputHelper output)
		{
			Formatter = new ContosoEcsTextFormatter();
			LoggerConfiguration = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.Console(Formatter)
				.WriteTo.TestOutput(output, formatter: Formatter, LogEventLevel.Verbose)
				.WriteTo.TestCorrelator();
		}

		[Fact]
		public void CanFormatBaseImplementationOfEcsDocument()
		{
			using var context = TestCorrelator.CreateContext();
			var logger = LoggerConfiguration.CreateLogger().ForContext(GetType());

			logger.Information("My log message!");

			var logEvents = TestCorrelator.GetLogEventsFromCurrentContext().ToList();

			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Timestamp.Should().NotBeNull();
			info.Contoso.Should().NotBeNull();
			info.Contoso.CompanyName.Should().Be("Elastic");
		}

		private List<string> ToFormattedStrings(List<LogEvent> logEvents) =>
			logEvents
				.Select(l =>
				{
					using var stringWriter = new StringWriter();
					Formatter.Format(l, stringWriter);
					return stringWriter.ToString();
				})
				.ToList();

		protected List<(string Json, ContosoDocument Base)> ToEcsEvents(List<LogEvent> logEvents) =>
			ToFormattedStrings(logEvents)
				.Select(s => (s, EcsSerializerFactory<ContosoDocument>.Deserialize(s)))
				.ToList();
	}
}
