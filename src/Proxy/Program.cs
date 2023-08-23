using Microsoft.Extensions.DependencyInjection;
using Proxy;
using Serilog;

var services = new ServiceCollection();
SetupInfrastructure();
var provider = services.BuildServiceProvider();

// Sofrtware design pattern Proxy:
// A proxy, in its most general form, is a class functioning as an interface to something else.
// The proxy could interface to anything:
// a network connection, a large object in memory, a file, or some other resource that is expensive or impossible to duplicate.
// Use of the proxy can simply be forwarding to the real object, or can provide additional logic.
// In the proxy, extra functionality can be provided,
// for example caching when operations on the real object are resource intensive,
// or checking preconditions before operations on the real object are invoked.
// For the client, usage of a proxy object is similar to using the real object, because both implement the same interface.

// We don't know is it real serving object or its proxy version - the interface is the same
IUserClient client = provider.GetService<IUserClient>()!;

foreach (var _ in Enumerable.Range(0, 10))
{
    // Proxy client will try to take data from cache 
    await client.GetUsersAsync();
    await Task.Delay(TimeSpan.FromSeconds(1));
}

void SetupInfrastructure()
{
    var logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

    services.AddMemoryCache();
    services.AddHttpClient();
    services.AddSingleton<ILogger>(logger);

    services.AddScoped<IUserClient, CachedUserClient>();
}