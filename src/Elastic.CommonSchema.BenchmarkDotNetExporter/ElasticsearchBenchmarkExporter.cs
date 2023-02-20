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
using Elastic.Channels;
using Elastic.CommonSchema.BenchmarkDotNetExporter.Domain;
using Elastic.Ingest.Elasticsearch.CommonSchema;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter
{
	/// <summary> Exports benchmark results to Elasticsearch </summary>
	public class ElasticsearchBenchmarkExporter : ExporterBase
	{
		// ReSharper disable once UnusedMember.Global
		/// <summary> Exports benchmark results to Elasticsearch </summary>
		public ElasticsearchBenchmarkExporter(string cloudId, string apiKey)
			: this(new ElasticsearchBenchmarkExporterOptions(cloudId) { ApiKey = apiKey}) { }

		/// <summary> Exports benchmark results to Elasticsearch </summary>
		public ElasticsearchBenchmarkExporter(ElasticsearchBenchmarkExporterOptions options)
		{
			Options = options;
			var config = Options.CreateTransportConfiguration();
			Transport = new DefaultHttpTransport<TransportConfiguration>(config);
		}

		// ReSharper disable once UnusedMember.Global
		/// <summary> Exports benchmark results to Elasticsearch </summary>
		public ElasticsearchBenchmarkExporter(ElasticsearchBenchmarkExporterOptions options, Func<ElasticsearchBenchmarkExporterOptions, TransportConfiguration> configure)
		{
			Options = options;
			Transport = new DefaultHttpTransport<TransportConfiguration>(configure(Options));
		}


		private HttpTransport<TransportConfiguration> Transport { get; }
		private ElasticsearchBenchmarkExporterOptions Options { get; }

		// We only log when we cannot write to Elasticsearch
		/// <inheritdoc cref="ExporterBase.FileExtension"/>
		protected override string FileExtension => "log";
		/// <inheritdoc cref="ExporterBase.FileNameSuffix"/>
		protected override string FileNameSuffix => "-elasticsearch-error";

		/// <inheritdoc cref="ExporterBase.ExportToLog"/>
		public override void ExportToLog(Summary summary, ILogger logger)
		{
			var waitHandle = new CountdownEvent(1);

			var benchmarksCount = summary.Reports.Length;
			Exception observedException = null;
			var options = new DataStreamChannelOptions<BenchmarkDocument>(Transport)
			{
				DataStream = new DataStreamName("benchmarks", "dotnet", Options.DataStreamNamespace),
				BufferOptions = new BufferOptions
				{
					WaitHandle = waitHandle,
					OutboundBufferMaxSize = benchmarksCount,
					OutboundBufferMaxLifetime = TimeSpan.FromSeconds(5)
				},
				ExportExceptionCallback = e => observedException ??= e,
				ExportResponseCallback = (response, _) =>
				{
					var errorItems = response.Items.Where(i => i.Status >= 300).ToList();
					if (response.TryGetElasticsearchServerError(out var error))
						logger.WriteError(error.ToString());
					else if (errorItems.Count == 0)
						logger.WriteLine("Successfully indexed benchmark results");
					foreach (var errorItem in errorItems)
						logger.WriteError($"Failed to {errorItem.Action} document status: ${errorItem.Status}, error: ${errorItem.Error}");

				}
			};
			Options.ChannelOptionsCallback?.Invoke(options);
			var channel = new EcsDataStreamChannel<BenchmarkDocument>(options);
			if (!channel.BootstrapElasticsearch(Options.BootstrapMethod)) return;

			var benchmarks = CreateBenchmarkDocuments(summary);
			var writeResult = benchmarks.Select(b => channel.TryWrite(b)).All(b => b);

			var completedOnTime = waitHandle.Wait(TimeSpan.FromSeconds(20));
			if (!completedOnTime)
			{
				logger.WriteError($"No flush in 20 seconds, published: {writeResult}, possible error: {observedException?.Message}");
				if (observedException != null)
					logger.WriteError(observedException.ToString());
			}
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
						Benchmark = new BenchmarkData(r.ResultStatistics, r.Success),
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
