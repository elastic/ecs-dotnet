// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.IO;

namespace Generator
{
	public static class CodeConfiguration
	{
		private static string _root;
		public static string ElasticCommonSchemaGeneratedFolder { get; } = $@"{Root}Elastic.CommonSchema/";
		public static string ElasticCommonSchemaNESTGeneratedFolder { get; } = $@"{Root}Elastic.CommonSchemaNEST/";

		public static string ElasticNLogGeneratedFolder { get; } = $@"{Root}Elastic.CommonSchema.NLog/";

		private static string Root
		{
			get
			{
				if (_root != null)
					return _root;

				var currentDirectory = Directory.GetCurrentDirectory();
				var directoryInfo = new DirectoryInfo(currentDirectory);

				var runningAsDnx =
					directoryInfo.Name == "Generator" &&
					directoryInfo.Parent != null &&
					directoryInfo.Parent.Name == "ECS";

				_root = runningAsDnx ? "" : @"../../../../";
				return _root;
			}
		}

		public static string SpecificationFolder { get; } = $@"{Root}Specification/";
		public static string ViewFolder { get; } = $@"{Root}Generator/Views/";
	}
}
