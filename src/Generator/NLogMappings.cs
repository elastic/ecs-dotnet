using Generator.Schema;

namespace Generator
{
	public static class NLogMappings
	{
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
