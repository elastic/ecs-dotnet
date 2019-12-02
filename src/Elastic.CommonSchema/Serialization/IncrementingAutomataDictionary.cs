// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Threading;
using Utf8Json.Internal;

namespace Elastic.CommonSchema.Serialization
{
	internal class IncrementingAutomataDictionary : AutomataDictionary
	{
		private int _propertiesCount = -1;

		public void Add(string key) => Add(key, Interlocked.Increment(ref _propertiesCount));
	}
}
