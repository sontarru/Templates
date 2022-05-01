namespace FkThat.Templates.Worker.Extensions;

/// <summary>
/// Extension methods for logging.
/// </summary>
public static class LoggerExtensions
{
    private static readonly Action<ILogger, DateTimeOffset, Exception?> _workerRunning =
         LoggerMessage.Define<DateTimeOffset>(
            LogLevel.Information,
            new EventId(1, nameof(WorkerRunning)),
            "Worker running at: {Time}");

    /// <summary>
    /// Logs 'Worker running' message.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="dateTimeOffset">The time.</param>
    public static void WorkerRunning(this ILogger logger, DateTimeOffset dateTimeOffset) =>
            _workerRunning(logger, dateTimeOffset, null);
}
