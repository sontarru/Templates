namespace FkThat.Templates.ConsoleApp;

/// <summary>
/// Main application class.
/// </summary>
public interface IApplication
{
    /// <summary>
    /// Runs the application asynchronously.
    /// </summary>
    /// <param name="args">The CLI arguments.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task RunAsync(IEnumerable<string> args, CancellationToken cancellationToken);
}
