// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

namespace Generator
{
	public static class ExtensionMethods
	{
		public static string TrimStart(this string input, string value)
		{
			if (string.IsNullOrEmpty(value))
				return input;

			var result = input;
			while (result.StartsWith(value))
				result = result.Substring(value.Length);

			return result;
		}
	}
}
