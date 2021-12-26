using FkThat.Templates.Worker;
using Serilog;

var builder = Host.CreateDefaultBuilder(args);

builder.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.ConfigureServices(services => {
    services.AddHostedService<Worker>();
});

await builder.Build().RunAsync();
