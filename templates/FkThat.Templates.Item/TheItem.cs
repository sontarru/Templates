namespace __namespace;

#if IS_PUBLIC
///<summary>
///  Represents TheItem.
///</summary>
#endif
#if IS_CLASS
__visibility class TheItem
{
}
#endif
#if IS_INTERFACE
__visibility interface TheItem
{
}
#endif
#if IS_ENUM
__visibility enum TheItem
{
}
#endif
#if IS_CONTROLLER
[ClsCompliant(false)]
[ApiController]
[Route("api/[controller]")]
__visibility class TheItem: ControllerBase
{
}
#endif
#if IS_WORKER
__visibility class TheItem: BackgroundService
{
#if IS_PUBLIC
    /// <summary>
    /// This method is called when the <see cref="IHostedService"/> starts. The implementation
    /// should return a task that represents the lifetime of the long running operation(s) being
    /// performed.
    /// </summary>
    /// <param name="stoppingToken">
    /// Triggered when <see cref="IHostedService.StopAsync(CancellationToken)"/> is called.
    /// </param>
#endif
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
        }
    }
}
#endif
