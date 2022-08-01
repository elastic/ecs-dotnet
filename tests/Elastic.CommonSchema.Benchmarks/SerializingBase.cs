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
			var ecs = new EcsDocument();
			return ecs.Serialize();
		}
		[Benchmark]
		public string Minimal()
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
			return ecs.Serialize();
		}
		[Benchmark]
		public string Complex()
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
			return ecs.Serialize();
		}

		public static readonly EcsDocument FullInstance = new AutoFaker<EcsDocument>().Generate();

		[Benchmark]
		public string Full() => FullInstance.Serialize();
	}
}
