using System;
using AutoBogus;
using BenchmarkDotNet.Attributes;

namespace Elastic.CommonSchema.Benchmarks
{
	[UnicodeConsoleLogger, MemoryDiagnoser, ThreadingDiagnoser]
	public class SerializingBase
	{
		[Benchmark]
		public string Empty()
		{
			var ecs = new Base();
			return ecs.Serialize();
		}
		[Benchmark]
		public string Minimal()
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
			return ecs.Serialize();
		}
		[Benchmark]
		public string Complex()
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
			return ecs.Serialize();
		}

		public static readonly Base FullInstance = new AutoFaker<Base>().Generate();

		[Benchmark]
		public string Full() => FullInstance.Serialize();
	}
}
