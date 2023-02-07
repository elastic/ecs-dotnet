# Elastic BenchmarkDotnet exporter

An exporter for [BenchmarkDotnet](https://github.com/dotnet/BenchmarkDotNet) that can index benchmarking result output directly into Elasticsearch.

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.CommonSchema.BenchmarkDotNetExporter](http://nuget.org/packages/Elastic.CommonSchema.BenchmarkDotNetExporter)

## How to Enable

```csharp
var options = new ElasticsearchBenchmarkExporterOptions(url)
{
	GitBranch = "externally-provided-branch",
	GitCommitMessage = "externally provided git commit message",
	GitRepositoryIdentifier = "repository"
};
var exporter = new ElasticsearchBenchmarkExporter(options);

var config = CreateDefaultConfig().With(exporter);
BenchmarkRunner.Run(typeof(Md5VsSha256), config);
```

The code snippet above configures the `ElasticsearchBenchmarkExporter` with the supplied `ElasticsearchBenchmarkExporterOptions`. It is possible to configure the exporter to use [Elastic Cloud](https://www.elastic.co/cloud/) as follows:

```csharp
var options = new ElasticsearchBenchmarkExporterOptions(url)
{
	CloudId = "CLOUD_ID_HERE"
};
```

Example _source from a search in Elasticsearch after a benchmark run:

```json
{
  "_index":"benchmark-dotnet-2020-01-01",
  "_type":"_doc",
  "_id":"pfFAh28B14pBZI_VO098",
  "_score":1.0,
  "_source":{
    "agent":{
      "git":{
        "branch_name":"externally-provided-branch",
        "commit_message":"externally provided git commit message",
        "repository":"repository"
      },
      "language":{
        "jit_info":"RyuJIT",
        "dot_net_sdk_version":"3.0.101",
        "benchmark_dot_net_caption":"BenchmarkDotNet",
        "has_ryu_jit":true,
        "build_configuration":"RELEASE",
        "benchmark_dot_net_version":"0.12.0",
        "version":".NET Core 3.0.1 (CoreCLR 4.700.19.47502, CoreFX 4.700.19.51008)"
      },
      "type":"Elastic.CommonSchema.BenchmarkDotNetExporter",
      "version":"1.0.0+7cedae2aaa06092ea253155279b835cee6160b3a"
    },
    "os":{
      "name":"Linux",
      "version":"ubuntu 18.10",
      "platform":"unix"
    },
    "message":null,
    "benchmark":{
      "q1":3632.625,
      "lower_outliers":[],
      "q3":5047.625,
      "confidence_interval":{
        "margin":14613.282591693971,
        "level":12,
        "mean":4123.291666666667,
        "lower":-10489.990925027305,
        "n":3,
        "standard_error":462.4594877151704
      },
      "percentiles":{
        "p0":3632.625,
        "p67":4151.345,
        "p25":3661.125,
        "p100":5047.625,
        "p90":4776.025000000001,
        "p80":4504.425,
        "p50":3689.625,
        "p85":4640.225,
        "p95":4911.825
      },
      "memory":{
        "bytes_allocated_per_operation":112,
        "total_operations":4,
        "gen2_collections":0,
        "gen1_collections":0,
        "gen0_collections":0
      },
      "max":5047.625,
      "interquartile_range":1415,
      "all_outliers":[],
      "upper_fence":7170.125,
      "standard_deviation":801.0033291649501,
      "kurtosis":0.6666666666666661,
      "n":3,
      "standard_error":462.4594877151704,
      "min":3632.625,
      "median":3689.625,
      "upper_outliers":[],
      "variance":641606.3333333333,
      "mean":4123.291666666667,
      "lower_fence":1510.125,
      "skewness":0.3827086238595402
    },
    "@timestamp":"2020-01-08T22:22:10.7917398+00:00",
    "host":{
      "hardware_timer_kind":"Unknown",
      "physical_processor_count":1,
      "logical_core_count":12,
      "in_docker":false,
      "processor_name":"Intel(R) Core(TM) i9-8950HK CPU @ 2.90GHz",
      "chronometer_frequency_hertz":1000000000,
      "has_attached_debugger":false,
      "physical_core_count":6,
      "architecture":"X64"
    },
    "log.level":null,
    "event":{
      "duration":1385324200,
      "measurement_stages":[
        {
          "operations":2,
          "iteration_mode":"Overhead",
          "iteration_stage":"Jitting"
        },
        {
          "operations":2,
          "iteration_mode":"Workload",
          "iteration_stage":"Jitting"
        },
        {
          "operations":4,
          "iteration_mode":"Overhead",
          "iteration_stage":"Warmup"
        },
        {
          "operations":4,
          "iteration_mode":"Overhead",
          "iteration_stage":"Actual"
        },
        {
          "operations":4,
          "iteration_mode":"Workload",
          "iteration_stage":"Warmup"
        },
        {
          "operations":4,
          "iteration_mode":"Workload",
          "iteration_stage":"Actual"
        },
        {
          "operations":4,
          "iteration_mode":"Workload",
          "iteration_stage":"Result"
        }
      ],
      "job_config":{
        "run_time":".NET Core 3.0",
        "jit":"Default",
        "launch":{
          "unroll_factor":2,
          "max_iteration_count":0,
          "launch_count":1,
          "iteration_count":3,
          "run_strategy":"Throughput",
          "iteration_time_in_milliseconds":0,
          "warm_count":3,
          "max_warmup_iteration_count":0,
          "invocation_count":4,
          "min_warmup_iteration_count":0,
          "min_iteration_count":0
        },
        "id":"ShortRun",
        "gc":{
          "heap_affinitize_mask":0,
          "server":false,
          "no_affinitize":false,
          "allow_very_large_objects":false,
          "retain_vm":false,
          "cpu_groups":false,
          "concurrent":false,
          "heap_count":0,
          "force":false
        },
        "platform":"AnyCpu"
      },
      "original":"Md5VsSha256.Sha256: ShortRun(Runtime=.NET Core 3.0, InvocationCount=4, IterationCount=3, LaunchCount=1, UnrollFactor=2, WarmupCount=3) [N=1000]",
      "method":"Elastic.CommonSchema.BenchmarkDotNetExporter.IntegrationTests.Md5VsSha256.Sha256(N: 1000)",
      "module":"Elastic.CommonSchema.BenchmarkDotNetExporter.IntegrationTests",
      "description":"Sha256",
      "action":"Sha256",
      "category":"Elastic.CommonSchema.BenchmarkDotNetExporter.IntegrationTests.Md5VsSha256-20200108-232208",
      "type":"Md5VsSha256",
      "parameters":"N=1000",
      "repetitions":{
        "measured":4,
        "warmup":4
      }
    }
  }
}
```

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
