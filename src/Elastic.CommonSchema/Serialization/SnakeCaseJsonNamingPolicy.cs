using System.Text;
using System.Text.Json;

namespace Elastic.CommonSchema.Serialization
{
	internal class SnakeCaseJsonNamingPolicy : JsonNamingPolicy
	{
		public static string ToSnakeCase(string s)
		{
			if (string.IsNullOrEmpty(s)) return s;

			var sb = new StringBuilder();
			for (var i = 0; i < s.Length; i++)
			{
				var c = s[i];
				if (!char.IsUpper(c))
				{
					sb.Append(c);
					continue;
				}
				// first
				if (i == 0)
					sb.Append(char.ToLowerInvariant(c));
				else if (char.IsUpper(s[i - 1])) // WriteIO => write_io
					sb.Append(char.ToLowerInvariant(c));
				else
				{
					sb.Append("_");
					sb.Append(char.ToLowerInvariant(c));
				}
			}
			return sb.ToString();
		}

		public override string ConvertName(string name) => ToSnakeCase(name);
	}
}
