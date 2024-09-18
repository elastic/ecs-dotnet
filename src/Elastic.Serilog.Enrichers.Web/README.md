# Elastic.Serilog.Enrichers.Web

Adds extension methods for aspnet (core and fullframework) to enrich emitted ECS data with important HTTP information.

```csharp
.UseSerilog((ctx, config) =>
{
  // Ensure HttpContextAccessor is accessible
  var httpAccessor = ctx.Configuration.Get<HttpContextAccessor>();

  config
    .Enrich.WithEcsHttpContext(httpAccessor);
```