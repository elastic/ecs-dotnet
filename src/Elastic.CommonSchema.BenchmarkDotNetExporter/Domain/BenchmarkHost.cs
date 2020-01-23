using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkHost : Host
	{
		[DataMember(Name = "processor_name")]
		public string ProcessorName { get; set; }

		[DataMember(Name = "physical_processor_count")]
		public int? PhysicalProcessorCount { get; set; }

		[DataMember(Name = "physical_core_count")]
		public int? PhysicalCoreCount { get; set; }

		[DataMember(Name = "logical_core_count")]
		public int? LogicalCoreCount { get; set; }

		[DataMember(Name = "has_attached_debugger")]
		public bool HasAttachedDebugger { get; set; }

		[DataMember(Name = "hardware_timer_kind")]
		public string HardwareTimerKind { get; set; }

		[DataMember(Name = "chronometer_frequency_hertz")]
		public double ChronometerFrequencyHertz { get; set; }

		[DataMember(Name = "vm_hypervisor")]
		public string VirtualMachineHypervisor { get; set; }

		[DataMember(Name = "in_docker")]
		public bool InDocker { get; set; }
	}
}
