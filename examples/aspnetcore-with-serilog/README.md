# Elastic Common Schema Usage Example

## Elastic.CommonSchema.Serilog and AspNetCore

 The example demonstrates how the `Elastic.CommonSchema.Serilog` package can be used to log Serilog events that are compatible with ECS and, and makes use of the following technologies:

 - Elastic.CommonSchema.Serilog 
 - ASP.NET Core
 - netcoreapp3.0
 
## Configuration

### Ensuring HttpContextAccessor is available

The availability of the `HttpContextAccessor` in `Startup.cs`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
	// Ensure that we make the HttpContextAccessor resolvable through the configuration
	services.AddHttpContextAccessor();

	services.AddControllers();
}
```

### Registering the EcsTextFormatter

The creation of the `EcsTextFormatter` in `Program.cs:`

```csharp
public static IWebHost BuildWebHost(string[] args) =>
	WebHost.CreateDefaultBuilder(args)
		.UseStartup<Startup>()
		.UseSerilog((ctx, config) =>
		{
			config.ReadFrom.Configuration(ctx.Configuration);

			// Ensure HttpContextAccessor is accessible
			var httpAccessor = ctx.Configuration.Get<HttpContextAccessor>();
			
			// Create a formatter configuration to se this accessor
			var formatterConfig = new EcsTextFormatterConfiguration();
			formatterConfig.MapHttpContext(httpAccessor);
			
			// Write events to the console using this configration
			var formatter = new EcsTextFormatter(formatterConfig);

			config.WriteTo.Console(formatter);
		})
		.UseKestrel()
		.Build();
```

## Running the sample

![image](https://user-images.githubusercontent.com/148974/76587014-ac34c400-6536-11ea-9e55-c062447a7f6f.png)

On run, the console will show various events written in ECS format, an example given below:

```json
{
  "@timestamp": "2022-08-30T16:17:18.4976763+11:00",
  "log.level": "Information",
  "message": "Request finished in 353.60360000000003ms 200 application/json; charset=utf-8",
  "metadata": {
    "message_template": "{HostingRequestFinishedLog:l}",
    "content_type": "application/json; charset=utf-8",
    "hosting_request_finished_log": "Request finished in 353.60360000000003ms 200 application/json; charset=utf-8",
    "event_id": {
      "id": 2
    },
    "span_id": "|b4fce741-48d10adaba0a6f30.",
    "trace_id": "b4fce741-48d10adaba0a6f30",
    "parent_id": ""
  },
  "client": {
    "address": "::1",
    "ip": "::1"
  },
  "ecs": {
    "version": "8.3.1"
  },
  "event": {
    "severity": 2,
    "timezone": "AUS Eastern Standard Time",
    "created": "2022-08-30T16:17:18.4976763+11:00",
    "duration": 353603600
  },
  "http": {
    "request": {
      "id": "0HLU6VK4GT6MU:00000001"
      "method": "GET"
    },
    "response": {
      "status_code": 200
    }
  },
  "log": {
    "logger": "Microsoft.AspNetCore.Hosting.Diagnostics",
    "original": null
  },
  "process": {
    "thread": {
      "id": 10
    },
    "pid": 16656,
    "name": "AspnetCoreExample",
    "executable": "AspnetCoreExample",
    "title": ""
  },
  "server": {
    "address": "localhost:5001",
    "domain": "localhost",
    "ip": "::1"
  },
  "url": {
    "original": "https://localhost:5001/weatherforecast",
    "full": "https://localhost:5001/weatherforecast",
    "scheme": "https",
    "domain": "localhost",
    "port": 5001,
    "path": "/weatherforecast"
  },
  "user_agent": {
    "os": {
      "full": "Windows 10",
      "family": "Windows",
      "version": "10"
    },
    "device": {
      "name": "Other"
    },
    "original": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36",
    "name": "Firefox",
    "version": "80.0.3987"
  }
}
```