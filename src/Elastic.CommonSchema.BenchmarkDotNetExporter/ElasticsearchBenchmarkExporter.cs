// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using Elastic.CommonSchema.BenchmarkDotNetExporter.Domain;
using Elastic.Ingest;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.CommonSchema;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter
{
	public class ElasticsearchBenchmarkExporter : ExporterBase
	{
		public ElasticsearchBenchmarkExporter(string cloudId, string apiKey)
			: this(new ElasticsearchBenchmarkExporterOptions(cloudId) { ApiKey = apiKey}) { }

		public ElasticsearchBenchmarkExporter(ElasticsearchBenchmarkExporterOptions options)
		{
			Options = options;
			var config = Options.CreateTransportConfiguration();
			Transport = new Transport<TransportConfiguration>(config);
		}

		public ElasticsearchBenchmarkExporter(ElasticsearchBenchmarkExporterOptions options, Func<ElasticsearchBenchmarkExporterOptions, TransportConfiguration> configure)
		{
			Options = options;
			Transport = new Transport<TransportConfiguration>(configure(Options));
		}


		private Transport<TransportConfiguration> Transport { get; }
		private ElasticsearchBenchmarkExporterOptions Options { get; }

		// We only log when we cannot write to Elasticsearch
		protected override string FileExtension => "log";
		protected override string FileNameSuffix => "-elasticsearch-error";

		public override void ExportToLog(Summary summary, ILogger logger)
		{
			var benchmarks = CreateBenchmarkDocuments(summary);
			var waitHandle = new CountdownEvent(1);

			var options = new DataStreamChannelOptions<BenchmarkDocument>(Transport)
			{
				DataStream = new DataStreamName("benchmarks", "dotnet", Options.DataStreamNamespace),
				BufferOptions = new ElasticsearchBufferOptions<BenchmarkDocument>
				{
					WaitHandle = waitHandle,
					MaxConsumerBufferSize = benchmarks.Count
				},
				ResponseCallback = ((response, statistics) =>
				{
					var errorItems = response.Items.Where(i => i.Status >= 300).ToList();
					if (response.TryGetElasticsearchServerError(out var error))
						logger.WriteError(error.ToString());
					else if (errorItems.Count == 0)
						logger.WriteLine("Successfully indexed benchmark results");
					foreach (var errorItem in errorItems)
						logger.WriteError($"Failed to {errorItem.Action} document status: ${errorItem.Status}, error: ${errorItem.Error}");

				})
			};
			var channel = new CommonSchemaChannel<BenchmarkDocument>(options);
			if (!channel.SetupElasticsearchTemplates()) return;

			channel.TryWriteMany(benchmarks);

			var waited = waitHandle.Wait(TimeSpan.FromSeconds(10));
			if (!waited)
				logger.WriteError($"failed to flush benchmarks within 10second timeout");
		}

		private List<BenchmarkDocument> CreateBenchmarkDocuments(Summary summary)
		{
			var benchmarks = summary.Reports.Select(r =>
				{
					var gc = r.BenchmarkCase.Job.Environment.Gc;
					var run = r.BenchmarkCase.Job.Run;
					var jobConfig = new BenchmarkJobConfig
					{
						Platform = Enum.GetName(typeof(Platform), r.BenchmarkCase.Job.Environment.Platform),
						Launch = new BenchmarkLaunchInformation
						{
							RunStrategy = Enum.GetName(typeof(RunStrategy), run.RunStrategy),
							LaunchCount = run.LaunchCount,
							WarmCount = run.WarmupCount,
							UnrollFactor = run.UnrollFactor,
							IterationCount = run.IterationCount,
							InvocationCount = run.InvocationCount,
							MaxIterationCount = run.MaxIterationCount,
							MinIterationCount = run.MinIterationCount,
							MaxWarmupIterationCount = run.MaxWarmupIterationCount,
							MinWarmupIterationCount = run.MinWarmupIterationCount,
							IterationTimeInMilliseconds = run.IterationTime.ToMilliseconds(),
						},
						RunTime = r.BenchmarkCase.Job.Environment.Runtime?.Name,
						Jit = Enum.GetName(typeof(Jit), r.BenchmarkCase.Job.Environment.Jit),
						Gc = new BenchmarkGcInfo
						{
							Force = gc.Force,
							Server = gc.Server,
							Concurrent = gc.Concurrent,
							RetainVm = gc.RetainVm,
							CpuGroups = gc.CpuGroups,
							HeapCount = gc.HeapCount,
							NoAffinitize = gc.NoAffinitize,
							HeapAffinitizeMask = gc.HeapAffinitizeMask,
							AllowVeryLargeObjects = gc.AllowVeryLargeObjects,
						},
						Id = r.BenchmarkCase.Job.Environment.Id,
					};
					var host = CreateHostEnvironmentInformation(summary);
					var git = new BenchmarkGit
					{
						Sha = Options.GitCommitSha,
						BranchName = Options.GitBranch,
						CommitMessage = Options.GitCommitMessage,
						Repository = Options.GitRepositoryIdentifier
					};
					var runtimeVersion = new BenchmarkLanguage
					{
						Version = summary.HostEnvironmentInfo.RuntimeVersion,
						DotNetSdkVersion = summary.HostEnvironmentInfo.DotNetSdkVersion.Value,
						HasRyuJit = summary.HostEnvironmentInfo.HasRyuJit,
						//JitModules = summary.HostEnvironmentInfo.,
						JitInfo = summary.HostEnvironmentInfo.JitInfo,
						BuildConfiguration = summary.HostEnvironmentInfo.Configuration,
						BenchmarkDotNetCaption = HostEnvironmentInfo.BenchmarkDotNetCaption,
						BenchmarkDotNetVersion = summary.HostEnvironmentInfo.BenchmarkDotNetVersion,
					};
					var agent = new BenchmarkAgent { Git = git, Language = runtimeVersion, };

					var @event = new BenchmarkEvent
					{
						Description = r.BenchmarkCase.Descriptor.WorkloadMethodDisplayInfo,
						Action = r.BenchmarkCase.Descriptor.WorkloadMethod.Name,
						Module = r.BenchmarkCase.Descriptor.Type.Namespace,
						Category = new [] { summary.Title },
						Type = new [] { FullNameProvider.GetTypeName(r.BenchmarkCase.Descriptor.Type) },
						Duration = summary.TotalTime.Ticks * 100,
						Original = r.BenchmarkCase.DisplayInfo,
						JobConfig = jobConfig,
						Method = FullNameProvider.GetBenchmarkName(r.BenchmarkCase),
						Parameters = r.BenchmarkCase.Parameters.PrintInfo,
					};

					var data = new BenchmarkDocument
					{
						Timestamp = DateTime.UtcNow,
						Host = host,
						Agent = agent,
						Event = @event,
						Benchmark = new BenchmarkData(r.ResultStatistics),
					};

					if (summary.BenchmarksCases.Any(c => c.Config.HasMemoryDiagnoser()))
						data.Benchmark.Memory = new BenchmarkGcStats(r.GcStats, r.BenchmarkCase);

					var grouped = r.AllMeasurements
						.GroupBy(m => $"{m.IterationStage.ToString()}-{m.IterationMode.ToString()}")
						.Where(g => g.Any())
						.ToList();

					@event.MeasurementStages = grouped
						.Select(g => new BenchmarkMeasurementStage
						{
							IterationMode = g.First().IterationMode.ToString(),
							IterationStage = g.First().IterationStage.ToString(),
							Operations = g.First().Operations,
						});

					var warmupCount = grouped.Select(g => g.First())
						.FirstOrDefault(s => s.IterationStage == IterationStage.Warmup && s.IterationMode == IterationMode.Workload)
						.Operations;
					var measuredCount = grouped.Select(g => g.First())
						.FirstOrDefault(s => s.IterationStage == IterationStage.Result && s.IterationMode == IterationMode.Workload)
						.Operations;
					@event.Repetitions = new BenchmarkSimplifiedWorkloadCounts { Warmup = warmupCount, Measured = measuredCount };
					return data;
				})
				.ToList();
			return benchmarks;
		}

		private static string OsName() =>
			Environment.OSVersion.Platform switch
			{
				PlatformID.MacOSX => "Max OS X",
				PlatformID.Unix => "Linux",
				PlatformID.Win32NT => "Windows",
				PlatformID.Win32S => "Windows",
				PlatformID.Win32Windows => "Windows",
				PlatformID.WinCE => "Windows",
				PlatformID.Xbox => "XBox",
				_ => "Unknown"
			};

		private static string OsPlatform() =>
			Environment.OSVersion.Platform switch
			{
				PlatformID.MacOSX => "darwin",
				PlatformID.Unix => "unix",
				_ => OsName().ToLowerInvariant()
			};

		private static BenchmarkHost CreateHostEnvironmentInformation(Summary summary)
		{
			var environmentInfo = new BenchmarkHost
			{
				ProcessorName = summary.HostEnvironmentInfo.CpuInfo.Value.ProcessorName,
				PhysicalProcessorCount = summary.HostEnvironmentInfo.CpuInfo.Value?.PhysicalProcessorCount,
				PhysicalCoreCount = summary.HostEnvironmentInfo.CpuInfo.Value?.PhysicalCoreCount,
				LogicalCoreCount = summary.HostEnvironmentInfo.CpuInfo.Value?.LogicalCoreCount,
				Architecture = summary.HostEnvironmentInfo.Architecture,
				VirtualMachineHypervisor = summary.HostEnvironmentInfo.VirtualMachineHypervisor.Value?.Name,
				InDocker = summary.HostEnvironmentInfo.InDocker,
				HasAttachedDebugger = summary.HostEnvironmentInfo.HasAttachedDebugger,
				ChronometerFrequencyHertz = summary.HostEnvironmentInfo.ChronometerFrequency.Hertz,
				HardwareTimerKind = summary.HostEnvironmentInfo.HardwareTimerKind.ToString(),
				Os = new Os
				{
					Version = summary.HostEnvironmentInfo.OsVersion.Value,
					Name = OsName(),
					Platform = OsPlatform()
				}
			};
			return environmentInfo;
		}
	}
}
