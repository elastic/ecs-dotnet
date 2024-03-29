// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;

namespace Elastic.CommonSchema.Generator.Schema.DTO
{
	/// <summary>
	///  ECS level
	/// </summary>
	public enum FieldLevel
	{
		[EnumMember(Value = "core")] Core,
		[EnumMember(Value = "extended")] Extended
	}
}
