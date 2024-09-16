using Elastic.CommonSchema;

namespace Elastic.Extensions.Logging.Common;

/// <summary>
///
/// </summary>
public interface ILogEventCreationOptions : IEcsDocumentCreationOptions
{
	/// <summary>
	/// Gets or sets additional tags to pass in the message, for example you can tag with the environment name ('Development',
	/// 'Production', etc).
	/// </summary>
	string[]? Tags { get; set; }

	/// <summary>
	/// Gets or sets the separate to use for <c>IList</c> semantic values.
	/// </summary>
	string ListSeparator { get; set; }
}
