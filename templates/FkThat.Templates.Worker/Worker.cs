using FkThat.Templates.Worker.Extensions;

namespace FkThat.Templates.Worker;

/// <summary>
/// Sample background worker.
/// </summary>
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Worker"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// This method is called when the <see cref="IHostedService"/>
    /// starts. The implementation should return a task that represents the lifetime of the long
    /// running operation(s) being performed.
    /// </summary>
    /// <param name="stoppingToken">
    /// Triggered when <see
    /// cref="IHostedService.StopAsync(CancellationToken)"/>
    /// is called.
    /// </param>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.WorkerRunning(DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
        }
    }
}
