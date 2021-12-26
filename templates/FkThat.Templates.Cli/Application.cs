#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

namespace FkThat.Templates.Console;

/// <summary>
/// Main application class.
/// </summary>
public class Application
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
        await System.Console.Out.WriteLineAsync("Hello, world!").ConfigureAwait(false);
    }
}
