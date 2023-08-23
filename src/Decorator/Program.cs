using Decorator;
using Decorator.Decorators;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var services = new ServiceCollection();
SetupInfrastructure();
var provider = services.BuildServiceProvider();

// Sofrtware design pattern Decorator:
// The decorator pattern is a design pattern that allows behavior to be added to an individual object,
// dynamically, without affecting the behavior of other objects from the same class.
// The decorator pattern is often useful for adhering to the Single Responsibility Principle,
// as it allows functionality to be divided between classes with unique areas of concern as well as to the Open-Closed Principle,
// by allowing the functionality of a class to be extended without being modified.

// Original service is wrapped with decorators
IUserClient client = provider.GetService<IUserClient>()!;

// Decorator executes all decorate-middlewares
await client.GetUsersAsync();

void SetupInfrastructure()
{
    var logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

    services.AddHttpClient();
    services.AddSingleton<ILogger>(logger);

    services.AddScoped<IUserClient, UserClient>();

    // We provide two decorators for main service,
    // Order is matter - decorators are placed in execution order
    services.Decorate<IUserClient, UserMetadataDecorator>();
    services.Decorate<IUserClient, SanitizeDecorator>();
}