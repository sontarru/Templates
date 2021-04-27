using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FkThat.Templates.Cli
{
    /// <summary>
    /// Application bootstrap.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static async Task Main(string[] args)
        {
            try
            {
                using CancellationTokenSource cancellationTokenSource = new();

                Console.CancelKeyPress += (s, e) => {
                    cancellationTokenSource.Cancel();
                    e.Cancel = true;
                };

                ServiceCollection services = new();
                services.AddTdd();
                services.AddTransient<IApplication, Application>();
                ConfigureServices(services);
                using var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var application = scope.ServiceProvider.GetRequiredService<IApplication>();

                try
                {
                    await application.RunAsync(args, cancellationTokenSource.Token)
                        .ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    await Console.Error.WriteLineAsync("The application was terminated.")
                        .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                await Console.Error.WriteLineAsync($"Fatal error:{Environment.NewLine}{e}");
            }
        }

        /// <summary>
        /// Configures the DI services.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        private static void ConfigureServices(ServiceCollection services)
        {
            // Add your services here,
        }
    }
}
