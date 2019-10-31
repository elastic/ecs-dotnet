using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Elastic
{
    public abstract class ECSItemBase
    {
        /// <summary>
        /// Container for additional metadata against this ECS event.
        /// </summary>
        [DataMember(Name = "_metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }
}