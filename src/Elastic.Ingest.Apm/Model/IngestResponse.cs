using System.Collections.Generic;
using System.Text.Json.Serialization;
using Elastic.Transport;

namespace Elastic.Ingest.Apm.Model
{
	public class EventIntakeResponse : ITransportResponse
	{
		[JsonIgnore]
		IApiCallDetails ITransportResponse.ApiCall { get; set; } = null!;
		[JsonIgnore]
		public IApiCallDetails ApiCall => ((ITransportResponse)this).ApiCall;

		[JsonPropertyName("accepted")]
		public long Accepted { get; set; }


		[JsonPropertyName("errors")]
		//[JsonConverter(typeof(ResponseItemsConverter))]
		public IReadOnlyCollection<IntakeErrorItem> Errors { get; set; } = null!;
	}

	public class IntakeErrorItem
	{
		[JsonPropertyName("message")]
		public string Message { get; set; } = null!;

		[JsonPropertyName("document")]
		public string Document { get; set; } = null!;
	}
}
