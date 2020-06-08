using System;
using System.Text;
using AutoBogus;
using BenchmarkDotNet.Attributes;

namespace Elastic.CommonSchema.Benchmarks
{
	[UnicodeConsoleLogger, MemoryDiagnoser, ThreadingDiagnoser]
	public class SerializingStringBuilderBase
	{
		[Benchmark]
		public StringBuilder Empty()
		{
			var ecs = new Base();
			return ecs.Serialize(new StringBuilder());
		}
		[Benchmark]
		public StringBuilder Minimal()
		{
			var ecs = new Base
			{
				Timestamp =  DateTimeOffset.UtcNow,
				Log = new Log
				{
					Level = "Debug"
				},
				Message = "hello world!"
			};
			return ecs.Serialize(new StringBuilder());
		}
		[Benchmark]
		public StringBuilder Complex()
		{
			var ecs = new Base
			{
				Timestamp =  DateTimeOffset.UtcNow,
				Log = new Log
				{
					Level = "Debug", Logger = "Logger",
					Origin = new LogOrigin
					{
						File = new OriginFile { Line = 12, Name = "file.cs"}, Function = "Complex"
					},
					Original = "new log line",
					Syslog = new LogSyslog {
						Facility = new SyslogFacility
						{
							Code = 12, Name = "syslog"
						}, Priority = 12, Severity = new SyslogSeverity()
						{
							Code = 12, Name =  "asd"
						},
					}
				},
				Message = "hello world!",
				Agent = new Agent
				{
					Name = "test"
				}

			};
			return ecs.Serialize(new StringBuilder());
		}

		public static readonly Base FullInstance = new AutoFaker<Base>().Generate();

		[Benchmark]
		public StringBuilder Full() => FullInstance.Serialize(new StringBuilder());
	}
}
