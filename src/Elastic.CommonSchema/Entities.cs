using System.Text.Json.Serialization;
using Elastic.CommonSchema.Serialization;

namespace Elastic.CommonSchema;

// This file only contains manual additions to entities.
// These should be exceptions and not the norm.
// Most of the entities are generated under Entities.Generated.cs

[JsonConverter(typeof(EcsLogJsonConverter))]
public partial class Log
{

}
