// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Serilog.Events;

namespace Elastic.CommonSchema.Serilog
{
	public static class ExtensionMethods
	{
		public static bool TryGetScalarPropertyValue(this LogEvent e, string key, out ScalarValue value)
		{
			if (!e.Properties.TryGetValue(key, out var scalarValue))
			{
				value = null;
				return false;
			}

			if (!(scalarValue is ScalarValue propertyValue))
			{
				value = null;
				return false;
			}

			value = propertyValue;
			return true;
		}
	}
}
