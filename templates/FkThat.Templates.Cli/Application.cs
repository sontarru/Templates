namespace FkThat.Templates.Cli;

/// <summary>
/// Main application class.
/// </summary>
public class Application : IApplication
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Application"/> class.
    /// </summary>
    public Application()
    {
    }

    /// <summary>
    /// Runs the application asynchronously.
    /// </summary>
    /// <param name="args">The CLI arguments.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task RunAsync(IEnumerable<string> args, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync("Hello, world!").ConfigureAwait(false);
    }
}
