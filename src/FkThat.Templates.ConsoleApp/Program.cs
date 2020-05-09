using FkThat.Templates.ConsoleApp;

using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();

services.AddTransient<IApplication, Application>();
services.AddTransient<ICommandFactory, CommandFactory>();
services.AddTransient<HelloCmd>();

using var scope = services.BuildServiceProvider().CreateScope();
var app = scope.ServiceProvider.GetRequiredService<IApplication>();
await app.RunAsync(args).ConfigureAwait(false);
