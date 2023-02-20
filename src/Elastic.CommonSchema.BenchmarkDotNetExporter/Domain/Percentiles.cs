using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Mathematics;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain;

/// <summary></summary>
public class Percentiles
{
	/// <summary></summary>
	[JsonConstructor]
	public Percentiles() {}

	/// <summary></summary>
	[JsonPropertyName("p0"), DataMember(Name = "p0"), JsonInclude]
	public double P0 { get; internal set; }
	/// <summary></summary>
	[JsonPropertyName("p25"), DataMember(Name = "p25"), JsonInclude]
	public double P25 { get; internal set; }
	/// <summary></summary>
	[JsonPropertyName("p50"), DataMember(Name = "p50"), JsonInclude]
	public double P50 { get; internal set; }
	/// <summary></summary>
	[JsonPropertyName("p67"), DataMember(Name = "p67"), JsonInclude]
	public double P67 { get; internal set; }
	/// <summary></summary>
	[JsonPropertyName("p80"), DataMember(Name = "p80"), JsonInclude]
	public double P80 { get; internal set;  }
	/// <summary></summary>
	[JsonPropertyName("p85"), DataMember(Name = "p85"), JsonInclude]
	public double P85 { get; internal set; }
	/// <summary></summary>
	[JsonPropertyName("p90"), DataMember(Name = "p90"), JsonInclude]
	public double P90 { get; internal set; }
	/// <summary></summary>
	[JsonPropertyName("p95"), DataMember(Name = "p95"), JsonInclude]
	public double P95 { get; internal set; }
	/// <summary></summary>
	[JsonPropertyName("p100"), DataMember(Name = "p100"), JsonInclude]
	public double P100 { get; internal set; }

	/// <summary></summary>
	public Percentiles(PercentileValues values)
	{
		if (values == null) return;
		P0 = values.P0;
		P25 = values.P25;
		P50 = values.P50;
		P67 = values.P67;
		P80 = values.P80;
		P85 = values.P85;
		P90 = values.P90;
		P95 = values.P95;
		P100 = values.P100;
	}
}
