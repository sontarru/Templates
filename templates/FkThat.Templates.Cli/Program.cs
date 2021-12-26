using FkThat.Templates.Cli;
using Microsoft.Extensions.DependencyInjection;

try
{
    using CancellationTokenSource cancellationTokenSource = new();

    Console.CancelKeyPress += (s, e) => {
        cancellationTokenSource.Cancel();
        e.Cancel = true;
    };

    ServiceCollection services = new();

    // Configure your services here

    services.AddTransient<IApplication, Application>();
    using var serviceProvider = services.BuildServiceProvider();
    using var scope = serviceProvider.CreateScope();
    var application = scope.ServiceProvider.GetRequiredService<IApplication>();

    try
    {
        await application.RunAsync(args, cancellationTokenSource.Token).ConfigureAwait(false);
    }
    catch (OperationCanceledException)
    {
        await Console.Error.WriteLineAsync("The application was terminated.").ConfigureAwait(false);
    }
}
catch (Exception e)
{
    await Console.Error.WriteLineAsync($"Fatal error:{Environment.NewLine}{e}")
        .ConfigureAwait(false);
}
