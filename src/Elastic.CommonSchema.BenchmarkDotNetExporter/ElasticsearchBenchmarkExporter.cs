// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using Elastic.CommonSchema.BenchmarkDotNetExporter.Domain;
using Elastic.CommonSchema.Elasticsearch;
using Elasticsearch.Net;
using static Elastic.CommonSchema.BenchmarkDotNetExporter.ElasticsearchBenchmarkExporterOptions.TimeSeriesStrategy;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter
{
	public class ElasticsearchBenchmarkExporter : ExporterBase
	{
		public ElasticsearchBenchmarkExporter(string cloudId, string apiKey)
			: this(new ElasticsearchBenchmarkExporterOptions(cloudId) { ApiKey = apiKey}) { }

		public ElasticsearchBenchmarkExporter(ElasticsearchBenchmarkExporterOptions options)
		{
			Options = options;
			Client = new ElasticLowLevelClient(Options.CreateConnectionSettings());
		}

		public ElasticsearchBenchmarkExporter(ElasticsearchBenchmarkExporterOptions options, Func<ElasticsearchBenchmarkExporterOptions, IConnectionConfigurationValues> configure)
		{
			Options = options;
			Client = new ElasticLowLevelClient(configure(Options));
		}

		private ElasticsearchBenchmarkExporterOptions Options { get; }
		private IElasticLowLevelClient Client { get; set; }

		// We only log when we cannot write to Elasticsearch
		protected override string FileExtension => "log";
		protected override string FileNameSuffix => "-elasticsearch-error";

		public override void ExportToLog(Summary summary, ILogger logger)
		{
			if (!TryPutIndexTemplate(logger)) return;
			if (!TryPutPipeline(logger)) return;

			var benchmarks = CreateBenchmarkDocuments(summary);

			IndexBenchmarksIntoElasticsearch(logger, benchmarks);
		}

		private void IndexBenchmarksIntoElasticsearch(ILogger logger, List<BenchmarkDocument> benchmarks)
		{
			var action =
				!string.IsNullOrWhiteSpace(Options.PipelineName)
				? @"{""index"":{""pipeline"":""" + Options.PipelineName + @"""}}"
				: @"{""index"":{}}";
			var operations = benchmarks.SelectMany(b => new[] { action, b.Serialize() });

			var result = Client.Bulk<VoidResponse>(Options.IndexName, PostData.MultiJson(operations));

			if (!result.Success) logger.WriteLine(result.DebugInformation);
		}

		private bool TryPutIndexTemplate(ILogger logger)
		{
			var template = IndexTemplates.GetIndexTemplateForElasticsearch7($"{Options.IndexName}-*");
			var templateExist = Client.Indices.TemplateExistsForAll<VoidResponse>(Options.TemplateName);
			if (templateExist.HttpStatusCode == 200) return true;

			var putIndexTemplate = Client.Indices.PutTemplateForAll<VoidResponse>(Options.TemplateName, template);
			if (putIndexTemplate.Success) return true;

			logger.WriteLine(putIndexTemplate.DebugInformation);
			return false;
		}

		private bool TryPutPipeline(ILogger logger)
		{
			if (string.IsNullOrWhiteSpace(Options.PipelineName)) return true;

			var getPipelineResponse = Client.Ingest.GetPipeline<VoidResponse>(Options.PipelineName);
			if (getPipelineResponse.Success) return true;

			var rounding = GetIndexRounding();

			var pipeline = new
			{
				description = "Enriches the benchmark exports from BenchmarkDotNet",
				processors = new[]
				{
					new
					{
						date_index_name = new
						{
							field = "@timestamp",
							index_name_prefix = $"{Options.IndexName}-",
							// 2020-01-08T20:48:18.1548182+00:00
							date_formats = new[] { "ISO8601", "yyyy-MM-dd'T'HH:mm:ss.SSSSSSSZ" },
							date_rounding = rounding
						}
					}
				}
			};

			var putPipeline = Client.Ingest.PutPipeline<VoidResponse>(Options.PipelineName, PostData.Serializable(pipeline));
			if (putPipeline.Success) return true;

			logger.WriteLine(putPipeline.DebugInformation);
			return false;
		}

		private string GetIndexRounding() =>
			Options.IndexStrategy switch
			{
				Monthly => "M",
				Daily => "d",
				Weekly => "w",
				_ => "y"
			};

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
