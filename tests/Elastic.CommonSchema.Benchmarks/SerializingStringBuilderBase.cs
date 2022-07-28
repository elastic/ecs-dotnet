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
					OriginFunction = "Complext",
					OriginFileLine = 12,
					OriginFileName = "file.cs",
					Syslog = new LogSyslog {
						FacilityCode = 12,
						FacilityName = "syslog",
						Priority = 12,
						SeverityCode = 12,
						SeverityName = "asd",
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
