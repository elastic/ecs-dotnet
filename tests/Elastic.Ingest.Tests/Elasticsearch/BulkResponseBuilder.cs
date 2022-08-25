using System.Linq;

namespace Elastic.Ingest.Tests.Elasticsearch
{
	public static class BulkResponseBuilder
	{
		public static object CreateResponse(params int[] statusCodes) => new
		{
			items = statusCodes.Select(status => new { index = CreateItemResponse(status) }).ToArray()
		};

		private static object CreateItemResponse(int statusCode) =>
			statusCode switch
			{
				429 => new { status = statusCode, error = CreateErrorObject(statusCode) },
				400 => new { status = statusCode, error = CreateErrorObject(statusCode) },
				_ => new { status = statusCode }
			};

		private static object CreateErrorObject(in int statusCode) =>
			statusCode switch
			{
				500 => new { index = "index", reason = "bad request 500", type = "some_exception" },
				502 => new { index = "index", reason = "bad request 502", type = "some_exception" },
				503 => new { index = "index", reason = "bad request 503", type = "some_exception" },
				504 => new { index = "index", reason = "bad request 504", type = "some_exception" },
				429 => new { index = "index", reason = "rejected execution of org.", type = "es_rejected_execution_exception" },
				400 => new { index = "BADINDEX", reason = "invalid index name", type = "invalid_index_name_exception" },
				_ => new { status = statusCode }
			};
	}
}
