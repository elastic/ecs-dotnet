// See https://aka.ms/new-console-template for more information

using Elastic.CommonSchema;

Console.WriteLine("Hello, World!");

var serialized = @$"{{}}";
var deserialized = EcsDocument.Deserialize(serialized);
if (deserialized == null) throw new Exception("deserialized is null");

serialized = @$"{{ ""agent"": {{ ""unknown"": ""value"" }} }}";
deserialized = EcsDocument.Deserialize(serialized);
if (deserialized == null) throw new Exception("deserialized is null");
if (deserialized.Agent == null) throw new Exception("deserialized agent is null");



var d = new EcsDocument { Agent = new Agent { Name = "some-agent" }, Log = new Log { Level = "debug" } };

serialized = d.Serialize();
if (string.IsNullOrEmpty(serialized)) throw new Exception("serialized is null");
Console.WriteLine(serialized);
