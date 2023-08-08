// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.IO;

namespace Elastic.CommonSchema.Generator;

public static class CodeConfiguration
{
	static CodeConfiguration()
	{
		var rootInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
		do
		{
			var file = new FileInfo(Path.Combine(rootInfo.FullName, "license.txt"));
			if (file.Exists) break;
			rootInfo = rootInfo.Parent;

		} while (rootInfo != null && rootInfo != rootInfo.Root);

		if (rootInfo == null)
			throw new Exception("Can not resolve folder structure for ECS.NET codebase");

		Root = rootInfo.FullName;
		SourceFolder = Path.Combine(Root, "src");
		ToolFolder = Path.Combine(Root, "tools");
		ElasticCommonSchemaGeneratedFolder = Path.Combine(SourceFolder, "Elastic.CommonSchema");
		SpecificationFolder = Path.Combine(SourceFolder, "Specification");
		ViewFolder = Path.Combine(ToolFolder, "Elastic.CommonSchema.Generator", "Views");
	}

	public static string Root { get; }

	private static string SourceFolder { get; }
	private static string ToolFolder { get; }

	public static string ElasticCommonSchemaGeneratedFolder { get; }
	public static string SpecificationFolder { get; }
	public static string ViewFolder { get; }
}
