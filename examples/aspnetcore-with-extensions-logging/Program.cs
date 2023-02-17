// -- Start an Elasticsearch Instance --

using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Ephemeral;
using Elasticsearch.Extensions.Logging;

using var cluster = new EphemeralCluster("8.4.0");
var client = CreateClient(cluster);
//check if an instance is already running before starting
if (!(await client.InfoAsync()).IsValidResponse)
	cluster.Start(TimeSpan.FromMinutes(1));
else Console.WriteLine("Using already running Elasticsearch instance");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Host.ConfigureLogging((_, loggingBuilder) =>
{
	loggingBuilder.AddElasticsearch(client.Transport, log =>
	{
		log.Tags = new[] { "debug" };
	}, channel =>
	{
		channel.ExportResponseCallback = (response, buffer) => Console.WriteLine($"Written  {buffer.Count} logs to Elasticsearch: {response.ApiCallDetails.HttpStatusCode}");
	});
});
var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();


static ElasticsearchClient CreateClient(EphemeralCluster cluster)
{
	var settings = new ElasticsearchClientSettings(cluster.NodesUris().First())
		.EnableDebugMode();
	return new ElasticsearchClient(settings);
}
