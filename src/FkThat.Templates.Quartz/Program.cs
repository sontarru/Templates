using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Serilog;

namespace FkThat.Templates.Quartz
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
            services.AddTransient<ISchedulerFactory, StdSchedulerFactory>();
            services.AddTransient<IJobFactory, DependencyInjectionJobFactory>();
            services.AddTransient<IHostedService, SchedulerHostedService>();
            // job registrations
            services.AddTransient<HelloJob>();
        }
    }
}
