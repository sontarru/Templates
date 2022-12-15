namespace FkThat.Templates.Worker;

internal static class LoggerExtensions
{
    private static readonly Action<ILogger, Exception?> _helloWorld = LoggerMessage.Define(
        LogLevel.Information,
        new EventId(1, "HelloWorld"),
        "Hello, World!");

    public static void HelloWorld(this ILogger logger) => _helloWorld(logger, null);
}
