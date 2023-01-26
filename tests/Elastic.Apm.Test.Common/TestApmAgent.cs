namespace Elastic.Apm.Test.Common;

public static class TestApmAgent
{
	static TestApmAgent()
	{
		var configuration = new MockConfiguration("my-service", "my-service-node-name", "0.2.1", enabled: true);
		if (!Agent.IsConfigured)
			Agent.Setup(new AgentComponents(payloadSender: new NoopPayloadSender(), configurationReader: configuration));
	}

	public static void Configure() { }
}

public static class TestDisabledApmAgent
{
	static TestDisabledApmAgent()
	{
		var configuration = new MockConfiguration("my-service", "my-service-node-name", "0.2.1", enabled: false);
		if (!Agent.IsConfigured)
			Agent.Setup(new AgentComponents(payloadSender: new NoopPayloadSender(), configurationReader: configuration));
	}
	public static void Configure() { }
}
