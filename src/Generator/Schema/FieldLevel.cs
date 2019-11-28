using System.Runtime.Serialization;

namespace Generator.Schema
{
	public enum FieldLevel
	{
		[EnumMember(Value = "core")] Core,
		[EnumMember(Value = "extended")] Extended
	}
}
