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
			var ecs = new EcsDocument();
			return ecs.Serialize(new StringBuilder());
		}
		[Benchmark]
		public StringBuilder Minimal()
		{
			var ecs = new EcsDocument
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
			var ecs = new EcsDocument
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

		public static readonly EcsDocument FullInstance = new AutoFaker<EcsDocument>().Generate();

		[Benchmark]
		public StringBuilder Full() => FullInstance.Serialize(new StringBuilder());
	}
}
