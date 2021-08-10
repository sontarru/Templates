using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace FkThat.Templates.Daemon
{
    internal class Program
    {
        private static Task Main() =>
            CreateHostBuilder().Build().RunAsync();

        private static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .UseConsoleLifetime()
                .UseSerilog((context, configuration) =>
                    configuration.ReadFrom.Configuration(context.Configuration))
                .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<HelloDaemon>();
        }
    }
}
