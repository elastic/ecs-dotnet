// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary></summary>
	public class BenchmarkHost : Host
	{
		/// <summary></summary>
		[JsonPropertyName("processor_name"), DataMember(Name = "processor_name")]
		public string ProcessorName { get; set; }

		/// <summary></summary>
		[JsonPropertyName("physical_processor_count"), DataMember(Name = "physical_processor_count")]
		public int? PhysicalProcessorCount { get; set; }

		/// <summary></summary>
		[JsonPropertyName("physical_core_count"), DataMember(Name = "physical_core_count")]
		public int? PhysicalCoreCount { get; set; }

		/// <summary></summary>
		[JsonPropertyName("logical_core_count"), DataMember(Name = "logical_core_count")]
		public int? LogicalCoreCount { get; set; }

		/// <summary></summary>
		[JsonPropertyName("has_attached_debugger"), DataMember(Name = "has_attached_debugger")]
		public bool HasAttachedDebugger { get; set; }

		/// <summary></summary>
		[JsonPropertyName("hardware_timer_kind"), DataMember(Name = "hardware_timer_kind")]
		public string HardwareTimerKind { get; set; }

		/// <summary></summary>
		[JsonPropertyName("chronometer_frequency_hertz"), DataMember(Name = "chronometer_frequency_hertz")]
		public double ChronometerFrequencyHertz { get; set; }

		/// <summary></summary>
		[JsonPropertyName("vm_hypervisor"), DataMember(Name = "vm_hypervisor")]
		public string VirtualMachineHypervisor { get; set; }

		/// <summary></summary>
		[JsonPropertyName("in_docker"), DataMember(Name = "in_docker")]
		public bool InDocker { get; set; }
	}
}
