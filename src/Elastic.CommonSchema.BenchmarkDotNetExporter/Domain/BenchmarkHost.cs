// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkHost : Host
	{
		[JsonPropertyName("processor_name"), DataMember(Name = "processor_name")]
		public string ProcessorName { get; set; }

		[JsonPropertyName("physical_processor_count"), DataMember(Name = "physical_processor_count")]
		public int? PhysicalProcessorCount { get; set; }

		[JsonPropertyName("physical_core_count"), DataMember(Name = "physical_core_count")]
		public int? PhysicalCoreCount { get; set; }

		[JsonPropertyName("logical_core_count"), DataMember(Name = "logical_core_count")]
		public int? LogicalCoreCount { get; set; }

		[JsonPropertyName("has_attached_debugger"), DataMember(Name = "has_attached_debugger")]
		public bool HasAttachedDebugger { get; set; }

		[JsonPropertyName("hardware_timer_kind"), DataMember(Name = "hardware_timer_kind")]
		public string HardwareTimerKind { get; set; }

		[JsonPropertyName("chronometer_frequency_hertz"), DataMember(Name = "chronometer_frequency_hertz")]
		public double ChronometerFrequencyHertz { get; set; }

		[JsonPropertyName("vm_hypervisor"), DataMember(Name = "vm_hypervisor")]
		public string VirtualMachineHypervisor { get; set; }

		[JsonPropertyName("in_docker"), DataMember(Name = "in_docker")]
		public bool InDocker { get; set; }
	}
}
