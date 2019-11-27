using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using Utf8Json.Internal;

namespace Elastic.CommonSchema.Serialization
{
    internal class AutoAutomataDictionary : AutomataDictionary
    {
        private int _propertiesCount;
        
        public void Add(string key) => Add(key, Interlocked.Increment(ref _propertiesCount));
    }
}