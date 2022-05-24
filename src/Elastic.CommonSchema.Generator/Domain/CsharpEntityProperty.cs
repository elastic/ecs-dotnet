using System.Text.RegularExpressions;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Domain
{
	public class CsharpEntityProperty
	{
		public CsharpEntityProperty(string name, string fullPath)
		{
			Name = name;
			FullPath = fullPath;
		}

		public string Name { get; }
		public string FullPath { get; }

		public static bool TryCreate(string entityName, Field ecsField, out CsharpEntityProperty prop)
		{
			var re = new Regex($"^{entityName}\\.([^\\.]+)$");
			prop = null;
			if (!re.IsMatch(ecsField.FlatName))
				return false;

			prop = new CsharpEntityProperty(ecsField.FlatName.GetLastProperty(), ecsField.FlatName);
			return true;
		}
	}
	public class CsharpEntityReferenceProperty
	{
		public CsharpEntityReferenceProperty(string name, string fullPath)
		{
			Name = name;
			FullPath = fullPath;
		}

		public string Name { get; }
		public string FullPath { get; }
		public string CsharpEntityTypeName { get; internal set; }

		public static CsharpEntityReferenceProperty Create(string fullPath, CsharpEntityClass csharpEntityReference)
		{
			var re = new Regex($"^.+\\.([^\\.]+)$");
			return new CsharpEntityReferenceProperty(fullPath.GetLastProperty(), fullPath)
			{
				CsharpEntityTypeName = csharpEntityReference.Name,
			};
		}
	}

	public static class CsharpProperty {
		private static readonly Regex LastPropertyRegex = new($"^.+\\.([^\\.]+)$");

		public static string GetLastProperty(this string s) => LastPropertyRegex.Replace(s, "$1");
	}

	public class CsharpNestedEntityReferenceProperty
	{
		public CsharpNestedEntityReferenceProperty(string name, string fullPath)
		{
			Name = name;
			FullPath = fullPath;
		}

		public string Name { get; }
		public string FullPath { get; }
		public string CsharpEntityTypeName { get; internal set; }

		public static CsharpNestedEntityReferenceProperty Create(string fullPath, CsharpNestedEntityClass csharpEntityReference) =>
			new CsharpNestedEntityReferenceProperty(fullPath.GetLastProperty(), fullPath)
			{
				CsharpEntityTypeName = csharpEntityReference.Name,
			};
	}
}
