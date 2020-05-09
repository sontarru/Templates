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
            using var cancellationTokenSource = new CancellationTokenSource();

            System.Console.CancelKeyPress += (s, e) => {
                cancellationTokenSource.Cancel();
                e.Cancel = true;
            };

            var services = new ServiceCollection();
            ConfigureServices(services);
            using var container = services.BuildServiceProvider();
            using var scope = container.CreateScope();
            var application = scope.ServiceProvider.GetRequiredService<Application>();

            try
            {
                await application.RunAsync(args, cancellationTokenSource.Token)
                    .ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                await System.Console.Error.WriteLineAsync("The application was terminated.")
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Configures the DI services.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IConsole, ConsoleAdapter>();
            services.AddTransient<Application>();
        }
    }
}
