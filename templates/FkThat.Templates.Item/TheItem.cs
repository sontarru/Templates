namespace __namespace;

#if IS_CLASS
__accessModifier class TheItem
{
}
#endif
#if IS_INTERFACE
__accessModifier interface TheItem
{
}
#endif
#if IS_ENUM
__accessModifier enum TheItem
{
}
#endif
#if IS_CONTROLLER
[ClsCompliant(false)]
[ApiController]
[Route("api/[controller]")]
__accessModifier class TheItem: ControllerBase
{
}
#endif
#if IS_WORKER
__accessModifier class TheItem: BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
        }
    }
}
#endif
