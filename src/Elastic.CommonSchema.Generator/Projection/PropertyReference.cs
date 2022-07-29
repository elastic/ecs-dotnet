using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Projection
{
	public abstract class PropertyReference
	{
		protected PropertyReference(string localPath, string fullPath)
		{
			LocalPath = localPath;
			FullPath = fullPath;
		}

		public string JsonProperty => FullPath.GetLocalProperty(LocalPath);
		public string Name => JsonProperty.PascalCase();


		public string LocalPath { get; }
		public string FullPath { get; set; }
	}

	public class ValueTypePropertyReference : PropertyReference
	{
		public ValueTypePropertyReference(string parentPath, string fullPath, Field field) : base(parentPath, fullPath) =>
			ClrType = field.GetClrType();

		public string ClrType { get; }
	}

	public class InlineObjectPropertyReference : PropertyReference
	{
		public InlineObjectPropertyReference(string parentPath, string fullPath, InlineObject inlineObject) : base(parentPath, fullPath) =>
			InlineObject = inlineObject;

		public InlineObject InlineObject { get; }
	}

	public class EntityPropertyReference : PropertyReference
	{
		public EntityPropertyReference(string parentPath, string fullPath, EntityClass entity) : base(parentPath, fullPath) => Entity = entity;

		public EntityClass Entity { get; }
	}
}
