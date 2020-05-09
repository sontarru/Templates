namespace FkThat.Templates.Worker;

/// <summary>
/// Sample background worker.
/// </summary>
public class HelloWorker : BackgroundService
{
    private readonly ILogger<HelloWorker> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelloWorker"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public HelloWorker(ILogger<HelloWorker> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// This method is called when the <see cref="IHostedService"/> starts. The implementation
    /// should return a task that represents the lifetime of the long running operation(s) being performed.
    /// </summary>
    /// <param name="stoppingToken">
    /// Triggered when <see cref="IHostedService.StopAsync(CancellationToken)"/> is called.
    /// </param>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            stoppingToken.ThrowIfCancellationRequested();
            _logger.HelloWorld();
            await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken).ConfigureAwait(false);
        }
    }
}
