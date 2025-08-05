namespace Elastic.CommonSchema.NLog;

internal class NlogEcsDocumentCreationOptions : IEcsDocumentCreationOptions
{
	public static NlogEcsDocumentCreationOptions Default { get; } = new();
	public bool IncludeHost { get; set; } = true;
	public bool IncludeProcess { get; set; } = false;
	public bool IncludeUser { get; set; } = false;
	public bool IncludeActivityData { get; set; } = false;
}
