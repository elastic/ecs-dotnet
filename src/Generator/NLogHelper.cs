using System.Text;
using Generator.Schema;

namespace Generator
{
	public static class NLogHelper
	{
		public static bool Encode(this Field field)
		{
			switch (field.ObjectType)
			{
				case FieldType.Boolean:
				case FieldType.Float:
				case FieldType.Integer:
				case FieldType.Long:
					return false;
				default:
					return true;
			}
		}

		public static string GetMapping(Field field)
		{
			switch (field.FlatName)
			{
				case "@timestamp": return "${date}";
				case "log.level": return "${level}";
				case "labels": return "";
				case "message": return "${message}";
				case "ecs.version": return field.Schema.FullVersion;
				default: return string.Empty;
			}
		}
	}
}
