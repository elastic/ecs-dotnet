// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Linq;
using System.Reflection;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <inheritdoc cref="Agent"/>
	public class BenchmarkAgent : Agent
	{
		private static readonly AssemblyName Reference = typeof(BenchmarkAgent).Assembly.GetName();

		private static readonly AssemblyInformationalVersionAttribute Attribute =
			typeof(BenchmarkAgent)
				.Assembly
				.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false)
				.FirstOrDefault() as AssemblyInformationalVersionAttribute;

		/// <inheritdoc cref="Agent"/>
		public BenchmarkAgent()
		{
			Type = Reference.Name;
			Version = Attribute?.InformationalVersion ?? Reference.Version.ToString();
		}

		// TODO should this be on Agent?
		/// <summary></summary>
		public BenchmarkGit Git { get; set; }
		/// <summary></summary>
		public BenchmarkLanguage Language { get; set; }
	}
}
